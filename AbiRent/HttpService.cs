using AbiRent.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AbiRent
{
    public class HttpService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public HttpService()
        {
        }
        public static async Task<List<CarResponse>> GetCars(string city)
        {
            var response = _httpClient.GetAsync($"https://abi-rent.com/api/home/cars?city={city}");
            var stringJson = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CarResponse>>(stringJson);
            return result;
        }
        public static async Task<List<City>> GetCities()
        {
            var response = _httpClient.GetAsync("https://abi-rent.com/api/home/cities");
            var stringJson = await response.Result.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<City>>(stringJson);
            return result;
        }
    }
    public class CarResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public float FuelConsumption { get; set; }
        public int Places { get; set; }
        public int Baggage { get; set; }
        public TransmissonType TransmissonType { get; set; }
        public FuelType FuelType { get; set; }

    }
}
