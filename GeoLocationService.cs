using Newtonsoft.Json.Linq;
using RTools_NTS.Util;
using System.Device.Location;
using System.Net.Http.Json;
using System.Runtime;
using System.Text.Json;

public class GeolocationService
{
    public string ipAddress = "";
    public string location = "";
    public GeoCoordinate GetCurrentUserLocation()
    {
        HttpClient client = new HttpClient();

        var userIP = "";
        string URL =$"https://ipinfo.io/110.44.123.15?token=7e0d1c128f3fb9";
        //string URL = $"ipinfo.io / {userIP} ? token = 7e0d1c128f3fb9";

        string iP = "110.44.123.15";
        _ = GetLocation();


        // Implement logic to get user's coordinates (either from API or system)
        return new GeoCoordinate(27.6931158, 85.2939422); // Kuleshwor - current coordinates
    }

    public async Task GetIPAddress()
    {
        string ipURL = $"https://api64.ipify.org/?format=json";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                //get IP first; if success
                HttpResponseMessage response = await client.GetAsync(ipURL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(content);

                    ipAddress = (string)jsonObject.GetValue("ip");
                    Console.WriteLine($"IP JsonObject: {ipAddress}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch
            {
                Console.WriteLine("Error accessing the IP Adsress API");
            }
        }
    }

    public async Task GetLocation()
    {
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
                    HttpResponseMessage locationResponse = await client.GetAsync(apiUrl);
                    var content1 = await response.Content.ReadAsStringAsync();
                    JObject jsonObject1 = JObject.Parse(content1);
                    Console.WriteLine($"GeoLocation JsonObject: {jsonObject1.GetValue("loc")}");
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