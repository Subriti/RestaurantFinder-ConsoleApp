namespace FindClosestRestaurantNearMe
{
    internal static class Utilities
    {
        static List<Restaurants> nearbyRestaurants = new();

       /* static GeolocationService geolocationService = new ();
        static RestaurantFinder restaurantFinder = new (geolocationService);*/

        static RestaurantFinder restaurantFinder = new();

        public static void GetNearbyRestaurants()
        {
            // Find restaurants within 2KM radius
            nearbyRestaurants = restaurantFinder.FindRestaurantsWithinRadius(2);
        }

        public static void FindClosestRestaurant()
        {
            if (nearbyRestaurants.Count==0)
            {
                //first populate the list
                GetNearbyRestaurants();
            }

            // Find and display the nearest restaurant
            var nearestRestaurant = restaurantFinder.FindNearestRestaurant(nearbyRestaurants);

            if (nearestRestaurant != null)
            {
                Console.WriteLine($"\nNearest Restaurant: {nearestRestaurant.Name}");
                Console.WriteLine($"Distance: {nearestRestaurant.Distance:F2} KM");
            }
            else
            {
                Console.WriteLine("No restaurants found within the specified radius.");
            }
        }
    }
}
