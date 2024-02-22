using Newtonsoft.Json.Linq;
using System.Device.Location;
using System.Text.Json.Nodes;

public static class GeolocationService
{
    public static string ipAddress = "";
    public static string location="";

    public static GeoCoordinate GetCurrentUserLocation()
    {
        if (ipAddress=="" || location == "")
        {
            var ipAddress = GetIPAddress().Result; // Wait for IP address
            _ = GetLocation(ipAddress).AsyncState; // Continue with location retrieval
        }
        else
        {
            //Console.WriteLine($"\nUser GeoLocation 2 is: {location}\n");

            // Location already available
            var locAccess = location.Split(',');
            double.TryParse(locAccess[0], out var latitude);
            double.TryParse(locAccess[1], out var longitude);

            return new GeoCoordinate(latitude, longitude); // Vianet main jawalakhel coordinates
        }
        return new GeoCoordinate(27.6931158, 85.2939422);
    }

    private static async Task<string> GetIPAddress()
    {
        string ipURL = $"https://api64.ipify.org/?format=json";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(ipURL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(content);

                    ipAddress = (string)jsonObject.GetValue("ip");
                    //Console.WriteLine($"IP JsonObject: {ipAddress}");

                    return ipAddress; // Return IP address
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch
            {
                Console.WriteLine("Error accessing the IP Address API");
            }

            return null; // Return null if IP retrieval fails
        }
    }

    public static async Task GetLocation(string ipAddress)
    {
        // Logic to get user's coordinates from API

        //after getting IP, construct URL then get location
        string apiKey = "7e0d1c128f3fb9";
        string apiUrl = $"http://ipinfo.io/{ipAddress}/json?token={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(content);

                    location = (string)jsonObject.GetValue("loc");

                    //Console.WriteLine($"GeoLocation JsonObject: {jsonObject.GetValue("loc")}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch
            {
                Console.WriteLine("Error accessing the Location API");
            }
        }
    }

    public class IPInfoResponse
    {
        public string Ip { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Loc { get; set; }
        public string Org { get; set; }
    }
}