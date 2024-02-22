using Azure.Core;
using FreeGeoIPCore;
using FreeGeoIPCore.AppCode;
using GoogleMapsGeocoding;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Primitives;
using NetTopologySuite;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestRestaurantNearMe
{
    internal class Data
    {
        public string ipAddress = "";

        GeometryFactory geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
        //Restaurant restaurant = new Restaurant(1,"Tiptop",geometryFactory.CreatePoint(new Coordinate(-5.9, 54.48)),4.9);

        private readonly IHttpContextAccessor httpContextAccessor;

        public Data(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string? GetClientIp()
        {
            ipAddress= httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

            /*GeoCoordinate geoCoordinate = new GeoCoordinate();
            geoCoordinate.Latitude;

            navigator.geolocation.getCurrentPosition((position) => {
                doSomething(position.coords.latitude, position.coords.longitude);
            });

            var location= Geocoding.Address.;
            Geocoder geocoder = new Geocoder();


            var geo= Geolocation.GeoCalculator;*/

            Console.WriteLine($"User IP is: {ipAddress}");
            return ipAddress;
        }
        
        public void Index(double longitude, double latitude)
        {
            FreeGeoIPClient ipClient = new FreeGeoIPClient();

            //string ipAddress = GetRequestIP(_httpContextAccessor);

            FreeGeoIPCore.Models.Location location = ipClient.GetLocation("192.168.1.117").Result;

            GeoCoordinate coordinate = new GeoCoordinate();

            // If location is provided then use over IP address
            if (longitude == 0.0 && latitude == 0.0)
            {
                coordinate.Longitude = location.Longitude;
                coordinate.Latitude = location.Latitude;
            }
            else
            {
                coordinate.Longitude = longitude;
                coordinate.Latitude = latitude;
            }
            Console.WriteLine($"User longitude: {coordinate.Longitude}");
            Console.WriteLine($"User longitude: {coordinate.Latitude}");
        }

        /*public static string GetRequestIP(IHttpContextAccessor httpContextAccessor, bool tryUseXForwardHeader = true)
        {
            string ip = null;

            // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
            if (ip.IsNullOrWhitespace() && httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.

            if (ip.IsNullOrWhitespace())
                throw new Exception("Unable to determine caller's IP.");

            // Remove port if on IP address
            ip = ip.Substring(0, ip.IndexOf(":"));

            return ip;
        }*/
    }
}
