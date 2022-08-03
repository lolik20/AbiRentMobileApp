namespace AbiRent.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
    }
}
