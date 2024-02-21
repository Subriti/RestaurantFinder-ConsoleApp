using System.Text.Json.Nodes;

namespace FindClosestRestaurantNearMe
{
    internal static class Utilities
    {
        static List<double> userLocationData = new();
        static List<Restaurant> nearbyRestaurants = new();

        public static void GetUserLocationCoordinates()
        {
            Console.WriteLine("Accessing your current location...");
            //print maybe in list or store latitude longitude in list<float>
            var latitude = 0.0;
            var longitude = 0.0;

            userLocationData.Add(latitude);
            userLocationData.Add(longitude); //access garda always do list[0] and list [1];
        }

        public static void GetNearbyRestaurants()
        {
            Console.WriteLine("Finding all restaurants near you...");
            //make api call with radius and everything get json

            //json tanne convert it to restaurant object
            Restaurant restaurant = new Restaurant();

            //store geocoordinates
            GeoCoordinates geoCoordinates = new GeoCoordinates(0.0, 0.0);

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
        }
    }
}
