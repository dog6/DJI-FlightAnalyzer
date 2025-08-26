using GMap.NET;

namespace DroneFlightAnalyzer.Util
{
    public class DroneData
    {

        public Coords Coordinates;
        public float VeritcalSpeed;
        public float HorizontalSpeed;
        public float Altitude;
        public float Distance;

        public DroneData(Coords coordinates, float altitude, float distance, float verticalSpeed, float horizontalSpeed)
        {
            this.Coordinates = coordinates;
            this.Distance = distance;
            this.Altitude = altitude;
            this.VeritcalSpeed = verticalSpeed;
            this.HorizontalSpeed = horizontalSpeed;
        }

        public PointLatLng CoordsAsPointLatLng() => new PointLatLng(Coordinates.Latitude, Coordinates.Longitude);

    }
}
