﻿namespace AbiRent.Entities
{
    public class CompanyCar
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }
    }
}
