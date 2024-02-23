namespace FindClosestRestaurantNearMe
{
    internal static class Utilities
    {
        static List<Restaurants> nearbyRestaurants = new();

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
                ColorBlue();
                Console.WriteLine($"\nNearest Restaurant: {nearestRestaurant.Name}");
                ColorMagenta();
                Console.WriteLine($"Distance: {nearestRestaurant.Distance:F2} KM");
                ColorReset();
            }
            else
            {
                Console.WriteLine("No restaurants found within the specified radius.");
            }
        }
        public static void ColorBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        public static void ColorReset()
        {
            Console.ResetColor();
        }
        public static void ColorMagenta()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
}
