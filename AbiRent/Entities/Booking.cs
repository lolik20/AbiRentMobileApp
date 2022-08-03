using AbiRent.Entities;
using System;

namespace RentServiceApp.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }
        public string Car { get; set; }
        public int DaysCount { get; set; }
        public int TotalPrice { get; set; }
        public string NumberWA { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
