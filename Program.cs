// See https://aka.ms/new-console-template for more information
using FindClosestRestaurantNearMe;
using FreeGeoIPCore;
using Newtonsoft.Json.Linq;
using System.Device.Location;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("\r\n             _____             _                                    _    \r" +
    "\n            |  __ \\           | |                                  | |   \r" +
    "\n            | |__) | ___  ___ | |_  __ _  _   _  _ __  __ _  _ __  | |_  \r" +
    "\n            |  _  / / _ \\/ __|| __|/ _` || | | || '__|/ _` || '_ \\ | __| \r" +
    "\n            | | \\ \\|  __/\\__ \\| |_| (_| || |_| || |  | (_| || | | || |_  \r" +
    "\n            |_|  \\_\\\\___||___/ \\__|\\__,_| \\__,_||_|   \\__,_||_| |_| \\__| \r" +
    "\n                         ______  _             _                         \r" +
    "\n                        |  ____|(_)           | |                        \r" +
    "\n                        | |__    _  _ __    __| |  ___  _ __             \r" +
    "\n                        |  __|  | || '_ \\  / _` | / _ \\| '__|            \r" +
    "\n                        | |     | || | | || (_| ||  __/| |               \r" +
    "\n                        |_|     |_||_| |_| \\__,_| \\___||_|               \r" +
    "\n                                                                         \r" +
    "\n                                                                         \r");
Console.ResetColor();
//Console.WriteLine("\r\n .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .-----------------. .----------------.   \r
//\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |  \r
//\n| |  _______     | || |  _________   | || |    _______   | || |  _________   | || |      __      | || | _____  _____ | || |  _______     | || |      __      | || | ____  _____  | || |  _________   | |  \r
//\n| | |_   __ \\    | || | |_   ___  |  | || |   /  ___  |  | || | |  _   _  |  | || |     /  \\     | || ||_   _||_   _|| || | |_   __ \\    | || |     /  \\     | || ||_   \\|_   _| | || | |  _   _  |  | |  \r
//\n| |   | |__) |   | || |   | |_  \\_|  | || |  |  (__ \\_|  | || | |_/ | | \\_|  | || |    / /\\ \\    | || |  | |    | |  | || |   | |__) |   | || |    / /\\ \\    | || |  |   \\ | |   | || | |_/ | | \\_|  | |  \r
//\n| |   |  __ /    | || |   |  _|  _   | || |   '.___`-.   | || |     | |      | || |   / ____ \\   | || |  | '    ' |  | || |   |  __ /    | || |   / ____ \\   | || |  | |\\ \\| |   | || |     | |      | |  \r
//\n| |  _| |  \\ \\_  | || |  _| |___/ |  | || |  |`\\____) |  | || |    _| |_     | || | _/ /    \\ \\_ | || |   \\ `--' /   | || |  _| |  \\ \\_  | || | _/ /    \\ \\_ | || | _| |_\\   |_  | || |    _| |_     | |  \r
//\n| | |____| |___| | || | |_________|  | || |  |_______.'  | || |   |_____|    | || ||____|  |____|| || |    `.__.'    | || | |____| |___| | || ||____|  |____|| || ||_____|\\____| | || |   |_____|    | |  \r
//\n| |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |  \r
//\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |  \r
//\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'   \r
//\n .----------------.  .----------------.  .-----------------. .----------------.  .----------------.  .----------------.                                                                                   \r
//\n| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |                                                                                  \r
//\n| |  _________   | || |     _____    | || | ____  _____  | || |  ________    | || |  _________   | || |  _______     | |                                                                                  \r
//\n| | |_   ___  |  | || |    |_   _|   | || ||_   \\|_   _| | || | |_   ___ `.  | || | |_   ___  |  | || | |_   __ \\    | |                                                                                  \r
//\n| |   | |_  \\_|  | || |      | |     | || |  |   \\ | |   | || |   | |   `. \\ | || |   | |_  \\_|  | || |   | |__) |   | |                                                                                  \r
//\n| |   |  _|      | || |      | |     | || |  | |\\ \\| |   | || |   | |    | | | || |   |  _|  _   | || |   |  __ /    | |                                                                                  \r
//\n| |  _| |_       | || |     _| |_    | || | _| |_\\   |_  | || |  _| |___.' / | || |  _| |___/ |  | || |  _| |  \\ \\_  | |                                                                                  \r
//\n| | |_____|      | || |    |_____|   | || ||_____|\\____| | || | |________.'  | || | |_________|  | || | |____| |___| | |                                                                                  \r
//\n| |              | || |              | || |              | || |              | || |              | || |              | |                                                                                  \r
//\n| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |                                                                                  \r
//\n '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'                                                                                   \r
//\n");

string userSelection;

do
{
    Console.WriteLine("\n********************");
    Console.WriteLine("* Select an action *");
    Console.WriteLine("********************\n");

    Console.WriteLine("1: Get your location");
    Console.WriteLine("2: Get nearby restaurants");
    Console.WriteLine("3: Find the closest restaurant");
    Console.WriteLine("9: Quit application");
    Console.Write("Your selection: ");

    userSelection = Console.ReadLine();
    Console.WriteLine("");
    switch (userSelection)
    {
        case "1":
            //Utilities.GetUserLocationCoordinatesAsync();
            //GetLocationAsync();
            IPConfig.RunIpConfigCommand();
            var geolocationService = new GeolocationService();
            var restaurantFinder = new RestaurantFinder(geolocationService);

            // Find restaurants within 2KM radius
            List<Restaurants> restaurants = restaurantFinder.FindRestaurantsWithinRadius(2);

            // Find and display the nearest restaurant
            var nearestRestaurant = restaurantFinder.FindNearestRestaurant(restaurants);

            if (nearestRestaurant != null)
            {
                Console.WriteLine($"Nearest Restaurant: {nearestRestaurant.Name}");
                Console.WriteLine($"Distance: {nearestRestaurant.Distance:F2} KM");
            }
            else
            {
                Console.WriteLine("No restaurants found within the specified radius.");
            }
            break;
        case "2":
            Utilities.GetNearbyRestaurants();
            break;
        case "3":
            Utilities.FindClosestRestaurant();
            break;
        case "9": break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
}
while (userSelection != "9");

Console.WriteLine("Thanks for using the application");

static void Main()
    {
       
    }

async Task<string> GetCachedLocation()
{
    try
    {
        /* Location location = await Geolocation.Default.GetLastKnownLocationAsync();

         if (location != null)
             return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";*/
    }
    catch (Exception ex)
    {
        // Unable to get location
    }

    return "None";
}

async Task GetLocationAsync()
{
    string city = "Kuleshwor, Kathmandu, Nepal";
    /* GeoCoordinate coordinates = await GetCoordinates(city);

     Console.WriteLine($"Latitude: {coordinates.Latitude}");
     Console.WriteLine($"Longitude: {coordinates.Longitude}");
 */

    using HttpClient client = new();
    await ProcessRepositoriesAsync(client, city);
}

static async Task<GeoCoordinate> GetCoordinates(string city)
{
    GeoCoordinate coordinates = new GeoCoordinate();
    string query = $"https://nominatim.openstreetmap.org/search.php?q={city}&format=jsonv2";
    string result = GetRequest(query);
    dynamic dynamicResult = JObject.Parse(result);
    Console.WriteLine(dynamicResult[1]);

    coordinates.Latitude = dynamicResult[0].lat;
    coordinates.Longitude = dynamicResult[0].lon;

    return coordinates;
}


static async Task ProcessRepositoriesAsync(HttpClient client, String City)
{
    var baseURL = $"https://nominatim.openstreetmap.org/search.php?q={City}&format=jsonv2";

    try
    {
        Console.WriteLine("\nFetching Data ...");

        var result = await client.GetStringAsync(baseURL);
        //Console.WriteLine("\n" + result);
        //memory efficient because strongly typed; compiled before; less chances of error
        JObject jsonObject = JObject.Parse(result);
        Console.WriteLine("JsonObject: " + jsonObject);
        string condition = (string)jsonObject[0]["lat"];
        string lon = (string)jsonObject[0]["lon"];

        Console.WriteLine("\nCurrent Condition: " + condition + lon + "\n\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n{ex.Message}");
    }
}

static string GetRequest(string url)
{
    using (HttpClient client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36");

        HttpResponseMessage response = client.GetAsync(url).Result;
        response.EnsureSuccessStatusCode();

        using (Stream stream = response.Content.ReadAsStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}


/*static void GetLocationProperty()
{
    System.Device.Location.GeoCoordinate watch = new GeoCoordinate();
    var watcher = new GeoCoordinateWatcher();

    // Do not suppress prompt, and wait 1000 milliseconds to start.
    watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));

    GeoCoordinate coord = watcher.Position.Location;

    if (coord.IsUnknown != true)
    {
        Console.WriteLine("Lat: {0}, Long: {1}",
            coord.Latitude,
            coord.Longitude);
    }
    else
    {
        Console.WriteLine("Unknown latitude and longitude.");
    }
}*/

