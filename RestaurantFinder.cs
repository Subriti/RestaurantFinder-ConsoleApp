using FindClosestRestaurantNearMe;
using System.Device.Location;

public class RestaurantFinder
{
    internal List<Restaurants> FindRestaurantsWithinRadius(double radius)
    {
        Console.WriteLine("Finding all restaurants near you...\n");

        // Implement logic to find restaurants within the specified radius. (currently radius has no use)
        var restaurants = new List<Restaurants>
        {
            new Restaurants("Good Food Tandoori", 27.6922368,85.3016576),
            new Restaurants("Home Food Cafe", 27.6928855,85.2973397),
            new Restaurants("Himalayan Java Coffee - Kuleshwor", 27.6929607,85.2974491),
            new Restaurants("Tip Top Sweets- Kuleshwor", 27.6918226,85.2989081),
            new Restaurants("Dining House & Restaurant", 27.6929264,85.330528),
            new Restaurants("Aalucha, Durbar Square, Bhaktapur",27.671606,85.4256705),
            new Restaurants("Ace Lounge Restaurant & Bar",27.7156196,85.3205679),
            new Restaurants("Third Eye Restaurant",27.6950809,85.319126),
            new Restaurants("Gurkhas Grill",27.68062558854934, 85.30919730448794),
            new Restaurants("Travis Restaurants",27.692794323621655, 85.31133073645373),
            new Restaurants("Bawarchi Lounge",27.695883622476344, 85.30941789979848)
        };

        //working: get user location
        var userLocation = GeolocationService.GetCurrentUserLocation().Result;

        //Console.WriteLine($"User Location: {userLocation}\n");

        foreach (var restaurant in restaurants)
        {
            var restaurantLocation = new GeoCoordinate(restaurant.Latitude, restaurant.Longitude);
            restaurant.Distance = userLocation.GetDistanceTo(restaurantLocation) / 1000; // Convert to kilometers

            Utilities.ColorBlue();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"|{restaurant.Name}| ({restaurant.Latitude},{restaurant.Longitude})");
            //Console.WriteLine($"|{Math.Floor(restaurant.Distance*100)/100} Km |");
            Utilities.ColorMagenta();
            Console.WriteLine($"|{Math.Round(restaurant.Distance, 2)} Km |");
            Console.WriteLine("-------------------------------------------------------------");
            Utilities.ColorReset();
        }
        return restaurants;
    }

    internal Restaurants FindNearestRestaurant(List<Restaurants> restaurants)
    {
        Console.WriteLine("\nFinding the closest restaurant for you...");
        // Implement logic to find the nearest restaurant.
        // sorting the list using LINQ based on distance.
        return restaurants.OrderBy(r => r.Distance).FirstOrDefault();
    }
}
