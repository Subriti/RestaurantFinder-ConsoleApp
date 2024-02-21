namespace FindClosestRestaurantNearMe
{
    internal class Restaurant
    {
        public int RestaurantID{get; set;}
        public string RestaurantName { get; set;}

        //for storing coordinates
        public GeoCoordinates GeoCoordinates { get; set;}

        public double Rating { get; set;}

    }
}
