using System.Device.Location;

public class GeolocationService
{
    public GeoCoordinate GetCurrentUserLocation()
    {
        // Implement logic to get user's coordinates (either from API or system)
        return new GeoCoordinate(27.6931158, 85.2939422); // Kuleshwor - current coordinates
    }
}