namespace FindClosestRestaurantNearMe
{
    internal class GeoCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinates(double latitude, double longitude) { Latitude = latitude; Longitude = longitude; }
    }
}
