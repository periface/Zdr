namespace Helpers
{
    public class Position
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

        public double GetDouble(string pos)
        {
            return double.Parse(pos);
        }
    }
}