using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestRestaurantNearMe
{
    internal class GeoCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinates(double latitude, double longitude) { Latitude = latitude; Longitude = longitude; }

        /* public int RestaurantID { get; set; }

        public GeoCoordinates(int restaurantID, double latitude, double longitude)
        {
            RestaurantID = restaurantID; Latitude = latitude; Longitude = longitude;
        }*/
    }
}
