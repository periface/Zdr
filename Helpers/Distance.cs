using System;
using System.Globalization;

namespace Helpers
{
    public static class Distance
    {
        public enum DistanceUnit
        {
            Miles,
            Km
        }

        public static double HaversineDistance(Position pos1, Position pos2, DistanceUnit distanceUnit)
        {
            var lat1 = pos1.Lat.ParseInvariantCulture();
            var lon1 = pos1.Lng.ParseInvariantCulture();
            var lat2 = pos2.Lat.ParseInvariantCulture();
            var lon2 = pos2.Lng.ParseInvariantCulture();
            double R = (distanceUnit == DistanceUnit.Km) ? 6371 : 3958.8;
            var lat = (lat2 - lat1).ToRadians();
            var lng = (lon2 - lon1).ToRadians();
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                          Math.Cos(lat1.ToRadians()) * Math.Cos(lat2.ToRadians()) *
                          Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));
            return R * h2;
        }

        public static double ParseInvariantCulture(this string val)
        {
            return double.Parse(val, CultureInfo.InvariantCulture);
        }
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
