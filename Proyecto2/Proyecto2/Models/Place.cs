using System.Collections.Generic;

namespace Proyecto2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Icon Icon { get; set; }
    }

    public class Icon
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
    }

    public class Main
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Geocodes
    {
        public Main Main { get; set; }
    }

    public class Location
    {
        public string Country { get; set; }
        public string CrossStreet { get; set; }
        public string FormattedAddress { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
    }

    public class Venue
    {
        public string FsqId { get; set; }
        public List<Category> Categories { get; set; }
        public List<object> Chains { get; set; }
        public int Distance { get; set; }
        public Geocodes Geocodes { get; set; }
        public string Link { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public Dictionary<string, object> RelatedPlaces { get; set; }
        public string Timezone { get; set; }
    }

    public class Places
    {
        public List<Venue> Results { get; set; }
    }
}
