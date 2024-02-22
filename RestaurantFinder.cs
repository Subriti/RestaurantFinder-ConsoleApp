using FindClosestRestaurantNearMe;
using System.Device.Location;

public class RestaurantFinder
{
    /*private readonly GeolocationService _geolocationService;

    public RestaurantFinder(GeolocationService geolocationService)
    {
        _geolocationService = geolocationService;
    }*/

    internal List<Restaurants> FindRestaurantsWithinRadius(double radius)
    {
        Console.WriteLine("Finding all restaurants near you...\n");

        // Implement logic to find restaurants within the specified radius. (currently radius has no use)
        var restaurants = new List<Restaurants>
        {
            new Restaurants("Good Food Tandoori, Kathmandu", 27.6922368,85.3016576),
            new Restaurants("Home Food Cafe", 27.6928855,85.2973397),
            new Restaurants("Himalayan Java Coffee - Kuleshwor", 27.6929607,85.2974491),
            new Restaurants("Tip Top Sweets- Kuleshwor", 27.6918226,85.2989081),
            new Restaurants("Restaurant 1",30.7751,90.4185),
            new Restaurants("Restaurant 2",37.7748,22.4190),
            new Restaurants("Restaurant 3",30.7755,-12.4180)
        };

        //working: get user location
        //var userLocation = _geolocationService.GetCurrentUserLocation();
        var userLocation = GeolocationService.GetCurrentUserLocation();

        Console.WriteLine("User Location: "+userLocation);

        foreach (var restaurant in restaurants)
        {
            var restaurantLocation = new GeoCoordinate(restaurant.Latitude, restaurant.Longitude);
            restaurant.Distance = userLocation.GetDistanceTo(restaurantLocation) / 1000; // Convert to kilometers

            Console.WriteLine("\nRestaurant Location: " + restaurantLocation);
            Console.WriteLine($"Distance from Your location to {restaurant.Name} is {restaurant.Distance}\n");
        }
        return restaurants;
    }

    internal Restaurants FindNearestRestaurant(List<Restaurants> restaurants)
    {
        Console.WriteLine("Finding the closest restaurant for you...");
        // Implement logic to find the nearest restaurant.
        // sorting the list using LINQ based on distance.
        return restaurants.OrderBy(r => r.Distance).FirstOrDefault();
    }
}
