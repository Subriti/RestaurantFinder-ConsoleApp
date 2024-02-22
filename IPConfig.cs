using FreeGeoIPCore;
using Newtonsoft.Json.Linq;
using System.Device.Location;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace FindClosestRestaurantNearMe
{
    class IPConfig
    {
        public static void RunIpConfigCommand()
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                // Run ipconfig command
                string command = "ipconfig";
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Error:");
                    Console.WriteLine(error);
                }

                // Extract IPv4 addresses using regex
                string ipv4Pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
                MatchCollection matches = Regex.Matches(output, ipv4Pattern);

                Console.WriteLine("\nIPv4 Addresses:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value); //IP get garyo => works till here


                    //free geoIP client is outdated
                    FreeGeoIPClient ipClient = new FreeGeoIPClient();

                    try
                    {
                        FreeGeoIPCore.Models.Location location = ipClient.GetLocation(match.Value).Result;
                        Console.WriteLine(location);

                        GeoCoordinate coordinate = new GeoCoordinate();

                        coordinate.Longitude = location.Longitude;
                        coordinate.Latitude = location.Latitude;

                        Console.WriteLine($"User longitude: {coordinate.Longitude}");
                        Console.WriteLine($"User longitude: {coordinate.Latitude}");
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError in FreeGeoIPCode");
                        Console.ResetColor();

                        //take IP and get location
                         Console.WriteLine(CityStateCountByIp(match.Value));
                    }

                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // this doesnot work: API IPStack bc normal private IP is inaccessible hence null: so no need for access key
        public static string CityStateCountByIp(string IP)
        {
            string url = "http://api.ipstack.com/" + IP + "?access_key=XX384X1XX028XX1X66XXX4X04XXXX98X";
            var request = WebRequest.Create(url);

            using (WebResponse wrs = request.GetResponse())
            {
                using (Stream stream = wrs.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();
                        var obj = JObject.Parse(json);

                        //current error: access key is wrong
                        Console.WriteLine("API STACK ERROR: ");
                        Console.WriteLine(obj.ToString()); 
                        
                        string City = (string)obj["city"];
                        string Country = (string)obj["region_name"];
                        string CountryCode = (string)obj["country_code"];

                        return (CountryCode + " - " + Country + "," + City);
                    }
                }
            }


            return "";

        }
    }
}
