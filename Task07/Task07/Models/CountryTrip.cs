using System;
using System.Collections.Generic;

namespace Task07.Models;

public partial class CountryTrip
{
    public int IdCountry { get; set; }

    public int IdTrip { get; set; }

    public DateTime RegisteredAt { get; set; }

    public virtual Country IdCountryNavigation { get; set; }

    public virtual Trip IdTripNavigation { get; set; }
}
