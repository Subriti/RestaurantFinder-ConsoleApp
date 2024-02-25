using FindClosestRestaurantNearMe;
using System.Device.Location;

public class RestaurantFinder
{
    internal List<Restaurants> FindRestaurants()
    {
        Console.WriteLine("Finding all restaurants near you...\n");

        var restaurants= InitialiseRestaurants();

        var userLocation = GeolocationService.GetCurrentUserLocation().Result;

        foreach (var restaurant in restaurants)
        {
            //get restaurant coordinates
            var restaurantLocation = new GeoCoordinate(restaurant.Latitude, restaurant.Longitude);
            //calculate distance between user location and restaurant location
            restaurant.Distance = userLocation.GetDistanceTo(restaurantLocation) / 1000; // Convert to kilometers
            DisplayRestaurantsList(restaurant);
        }
        return restaurants;
    }

    private void DisplayRestaurantsList(Restaurants restaurant)
    {
        Utilities.ColorBlue();
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine($"|{restaurant.Name}| ({restaurant.Latitude},{restaurant.Longitude})");
        //Console.WriteLine($"|{Math.Floor(restaurant.Distance*100)/100} Km |");
        Utilities.ColorMagenta();
        Console.WriteLine($"|{Math.Round(restaurant.Distance, 2)} Km |");
        Console.WriteLine("-------------------------------------------------------------");
        Utilities.ColorReset();
    }

    internal Restaurants FindNearestRestaurant(List<Restaurants> restaurants)
    {
        Console.WriteLine("\nFinding the closest restaurant for you...");
        // Implement logic to find the nearest restaurant.
        // sorting the list using LINQ based on distance.
        return restaurants.OrderBy(r => r.Distance).FirstOrDefault();
    }

    List<Restaurants> InitialiseRestaurants()
    {
        var restaurants = new List<Restaurants>
        {
            new Restaurants("Good Food Tandoori", 27.692838266851215, 85.29909707368195),
            new Restaurants("Home Food Cafe", 27.694232772222136, 85.29881532507581),
            new Restaurants("Himalayan Java Coffee - Kuleshwor", 27.694547051838562, 85.29874524882327),
            new Restaurants("Tip Top Sweets- Kuleshwor", 27.690822205030543, 85.2988751770263),
            new Restaurants("Dining House & Restaurant", 27.68394191364491, 85.33356597429243),
            new Restaurants("Aalucha, Durbar Square, Bhaktapur",27.671606,85.4256705),
            new Restaurants("Ace Lounge Restaurant & Bar",27.7156196,85.3205679),
            new Restaurants("Third Eye Restaurant",27.714433802737705, 85.31009190919819),
            new Restaurants("Gurkhas Grill",27.679798470764126, 85.31031092417545),
            new Restaurants("Travis Restaurants",27.692794323621655, 85.31133073645373),
            new Restaurants("Bawarchi Lounge",27.695883622476344, 85.30941789979848)
        };
        return restaurants;
    }
}
