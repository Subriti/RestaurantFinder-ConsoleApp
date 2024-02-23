// See https://aka.ms/new-console-template for more information
using FindClosestRestaurantNearMe;

Console.ForegroundColor = ConsoleColor.DarkCyan;
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
Utilities.ColorReset();
string userSelection;

do
{
    Console.WriteLine("\n*********************************");
    Console.WriteLine("*\tSelect an action\t*");
    Console.WriteLine("*********************************\n");

    Console.WriteLine("1: Get your location");
    Console.WriteLine("2: Get nearby restaurants");
    Console.WriteLine("3: Find the closest restaurant");
    Console.WriteLine("9: Quit application");

    Utilities.ColorBlue();
    Console.Write("Your selection: ");

    //load the data beforehand
    var userLocation = GeolocationService.GetCurrentUserLocation();

    userSelection = Console.ReadLine();
    Utilities.ColorReset();

    Console.WriteLine("");
    switch (userSelection)
    {
        case "1":
            Console.WriteLine($"Fetching user location...");
            Utilities.ColorBlue();
            Console.WriteLine($"Your Location is: {userLocation.Result}\n");
            Utilities.ColorReset();
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