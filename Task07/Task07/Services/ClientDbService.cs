using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Task07.Models;


namespace Task07.Services
{
    public class ClientDbService : IClientDbService
    {
        private  S20293Context context;

        public ClientDbService(S20293Context context)
        {
            this.context = context;
        }
        public async Task DeleteClientAsync(int idClient)
        {
            var context = new S20293Context();
            bool hasTrips = await context.ClientTrips.AnyAsync(c => c.IdClient == idClient);

            if (hasTrips) throw new Exception("Client has a trip");
            Client client = await context.Clients.Where(row => row.IdClient == idClient).FirstOrDefaultAsync();
            context.Remove(client);

            await context.SaveChangesAsync();
            
        }
    }
}
