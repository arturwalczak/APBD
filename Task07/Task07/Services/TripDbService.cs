using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Task07.Models;
using Task07.Models.DTO;

namespace Task07.Services
{
    public class TripDbService : ITripDbService
    {
        private S20293Context context;

        public TripDbService(S20293Context context)
        {
            this.context = context;
        }

        public async Task AddTripToClientAsync(int idTrip, AddTripToClientRequestDto dto)
        {
            Client client = new Client();
            var context = new S20293Context();
            
            bool clientExists = await context.Clients.AnyAsync(c => c.Pesel == dto.Pesel);
            if (!clientExists)
            {
                System.Diagnostics.Debug.WriteLine( "client doesnt exist" );
                client = new Client
                {                    
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Telephone = dto.Telephone,
                    Pesel = dto.Pesel
                };

                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();
            }
            
            bool clientReservedTrip = await context.ClientTrips.AnyAsync(row => row.IdClient == client.IdClient && row.IdTrip == idTrip);
            if (clientReservedTrip) throw new Exception("Client has already reserved that trip");

            
            if (idTrip != dto.IdTrip)
            {
                throw new Exception("tripID from body != tripID from route");
            }

            bool tripExists = await context.Trips.AnyAsync(c => c.IdTrip == idTrip);
            if (!tripExists)
            {
                throw new Exception("trip doesnt exist");
            }

            Client clientID = await context.Clients.Where(row => row.Pesel == dto.Pesel).FirstOrDefaultAsync();
            Trip tripID = await context.Trips.Where(row => row.IdTrip == dto.IdTrip).FirstOrDefaultAsync();
            await context.ClientTrips.AddAsync(new ClientTrip
            {
                IdClient = clientID.IdClient,
                IdTrip = tripID.IdTrip,
                RegisteredAt = DateTime.Now,
                PaymentDate = dto.PaymentDate
            });
            await context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<GetTripsResponseDto>> GetTripsAsync()
        {
            var context = new S20293Context();
            var trips = await context.Trips.Select(row => new GetTripsResponseDto
            {
                Name = row.Name,
                Description = row.Description,
                DateFrom = row.DateFrom,
                DateTo = row.DateTo,
                MaxPeople = row.MaxPeople,
                Countries = row.CountryTrips.Select(row => new CountryResponseDto { Name = row.IdCountryNavigation.Name }),
                Clients = row.ClientTrips.Select(row => new ClientResponseDto
                {
                    FirstName = row.IdClientNavigation.FirstName,
                    LastName = row.IdClientNavigation.LastName
                })
            }).OrderByDescending(column => column.DateFrom).ToListAsync();

            if (!trips.Any()) throw new Exception("Databse empty");

            return trips;
        }
    }
}
