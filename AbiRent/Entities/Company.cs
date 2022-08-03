using System.Collections.Generic;

namespace AbiRent.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WhatsApp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<CompanyCar> CompanyCars { get; set; }
    }
}
