using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NetTopologySuite;
using System.Text.Json.Nodes;
using System.Net.Http.Json;
using System.Net.Http;

namespace FindClosestRestaurantNearMe
{
    internal static class Utilities
    {
        private static readonly IHttpContextAccessor _httpContextAccessor;

        static List<double> userLocationData = new();
        static List<Restaurant> nearbyRestaurants = new();

        public static async Task GetUserLocationCoordinatesAsync()
        {
            Console.WriteLine("Accessing your current location...");

            Data data = new(_httpContextAccessor);
            data.GetClientIp();
            data.Index(0.0, 0.0);

            string ipAddress = data.ipAddress;
            Console.WriteLine($"Public IP Address: {ipAddress}");

            //print maybe in list or store latitude longitude in list<float>
            var latitude = 0.0;
            var longitude = 0.0;

            userLocationData.Add(latitude);
            userLocationData.Add(longitude); //access garda always do list[0] and list [1];
        }

        /*static async Task<string> GetPublicIpAddress()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://api64.ipify.org?format=json");
                var result = System.Text.Json.JsonSerializer.Deserialize<IpifyResponse>(response);
                return result.Ip;
            }
        }*/

        /*public static string GetIp()
        {
            //string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //if (string.IsNullOrEmpty(ip))
            //{
                //ip = = Request.ServerVariables["REMOTE_ADDR"];
               string ip= _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            //}
            return ip;
        }*/

        public static void GetNearbyRestaurants()
        {
            Console.WriteLine("Finding all restaurants near you...");
            //make api call with radius and everything get json

            //json tanne convert it to restaurant object
            //Restaurant restaurant = new Restaurant();

            //store geocoordinates
            GeoCoordinates geoCoordinates = new GeoCoordinates(0.0, 0.0);


            //creating Topology instance

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);





            //print maybe in list or store latitude longitude in list<float>
            var latitude = 0.0;
            var longitude = 0.0;

            userLocationData.Add(latitude);
            userLocationData.Add(longitude); //access garda always do list[0] and list [1];
        }

        public static void FindClosestRestaurant()
        {
            //apply algorithm ; find the closest by distance calculation
            Console.WriteLine("Finding the closest restaurant for you...");

            //closest bhettauna chai can use CreateGeometryFactory
        }
    }
}
