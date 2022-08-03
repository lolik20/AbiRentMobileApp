using System.Collections.Generic;

namespace AbiRent.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public Image Image { get; set; }
        public List<CompanyCar> CompanyCars { get; set; }
        public float FuelConsumption { get; set; }
        public int Places { get; set; }
        public int Baggage { get; set; }
        public TransmissonType TransmissonType { get; set; }
        public FuelType FuelType { get; set; }

    }
}
