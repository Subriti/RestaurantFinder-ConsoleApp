using NetTopologySuite.Geometries;

namespace FindClosestRestaurantNearMe
{
    internal class Restaurant
    {
        public int RestaurantID{get; set;}
        public string RestaurantName { get; set;}

        //for storing coordinates
        public Point GeoCoordinates { get; set;}

        public double Rating { get; set;}

        public Restaurant(int restaurantID, string restaurantName, Point geoCoordinates, double rating)
        {
            RestaurantID = restaurantID;
            RestaurantName = restaurantName;
            GeoCoordinates = geoCoordinates;
            Rating = rating;
        }   
    }
}
