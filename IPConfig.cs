using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FindClosestRestaurantNearMe
{
    class IPConfig
    {
        public static void RunIpConfigCommand()
        {
            Console.WriteLine("Accessing your current location...");
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
                    

                    //use IP to get location
                    
                    /*GeoCoordinate coordinate = new GeoCoordinate();

                    coordinate.Longitude = 0.0;
                    coordinate.Latitude = 0.0;

                    Console.WriteLine($"User longitude: {coordinate.Longitude}");
                    Console.WriteLine($"User longitude: {coordinate.Latitude}");*/
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
