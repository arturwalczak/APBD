using System;
using System.Collections.Generic;

namespace Task07.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string Name { get; set; }

    public virtual ICollection<CountryTrip> CountryTrips { get; } = new List<CountryTrip>();
}
