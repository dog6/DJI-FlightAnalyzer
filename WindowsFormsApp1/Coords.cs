namespace DroneFlightAnalyzer.Util
{
    public class Coords
    {

        public float Longitude;
        public float Latitude;
        public float Elevation;

        public Coords(float x, float y, float z)
        {
            this.Longitude = x;
            this.Latitude = y;
            this.Elevation = z;
        }

        public Coords()
        {
            this.Longitude = 0;
            this.Latitude = 0;
            this.Elevation = 0;
        }

    }

}