using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using DroneFlightAnalyzer.Util;

namespace DroneFlightAnalyzer.Util
{

    public static class SmallzGraphing
    {

        public static int CINEMA_SPEED = 5;
        public static int NORMAL_SPEED = 10; // anything faster is 'fast'
        public static System.Drawing.Color CINEMA_SPEED_COLOR = System.Drawing.Color.Yellow;
        public static System.Drawing.Color NORMAL_SPEED_COLOR = System.Drawing.Color.Lime;
        public static System.Drawing.Color FAST_SPEED_COLOR = System.Drawing.Color.Red;

        private static System.Drawing.Point aboveOffset = new System.Drawing.Point(0, 50);
        private static System.Drawing.Point belowOffset = new System.Drawing.Point(0, -50);
        private static System.Drawing.Point leftOffset = new System.Drawing.Point(-50, 0);
        private static System.Drawing.Point rightOffset = new System.Drawing.Point(50, 0);

        /// <summary>
        /// Gets styling for plot
        /// </summary>
        /// <returns>PlotStyle for plot</returns>
        public static PlotStyle GetPlotStyle()
        {
            var plotStyle = new PlotStyle();
            plotStyle.AxisColor = ScottPlot.Color.FromColor(System.Drawing.Color.White);
            plotStyle.DataBackgroundColor = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(255, 32, 32, 32));
            plotStyle.FigureBackgroundColor = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(255, 48, 48, 48));
            return plotStyle;
        }

        /// <summary>
        /// Plots linegraph of float array
        /// </summary>
        /// <param name="data">Float[] to plot.</param>
        /// <param name="color">ScottPlot.Color color to draw plot with</param>
        /// <param name="plot">Reference to FormsPlot</param>
        /// <param name="lineWidth">Width of line drawn.</param>
        public static void PlotFloatData(float[] data, ScottPlot.Color color, FormsPlot plot, float lineWidth = 2.0f)
        {
            var signal = plot.Plot.Add.Signal(data, color: color);
            signal.LineWidth = lineWidth;
        }

        /// <summary>
        /// Adds a map marker at a given point to a<br/>
        /// given overlay with a given title, offset, and marker type
        /// </summary>
        /// <param name="point">PointLatLng to place map marker</param>
        /// <param name="overlay">Reference to GMapOverlay</param>
        /// <param name="title">Title of marker</param>
        /// <param name="offset">Offset of marker</param>
        /// <param name="markerType">Which type of GMarkerGoogleType to place</param>
        public static void AddMapMarker(PointLatLng point, GMapOverlay overlay, string title, System.Drawing.Point offset, GMarkerGoogleType markerType = GMarkerGoogleType.blue_dot)
        {
            GMarkerGoogle marker = new GMarkerGoogle(point, markerType);
            marker.ToolTipText = $"{title}";
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTip.Offset = offset;
            overlay.Markers.Add(marker);
        }

        public static List<PointLatLng> GetPointsUpToIndex(int maxIndex, List<DroneData> data) => data.Where(d => d.Coordinates.Latitude != 0 && d.Coordinates.Longitude != 0).Select(d => d.CoordsAsPointLatLng()).Take((int)maxIndex).ToList();

        public static System.Drawing.Color InterpolateColor(System.Drawing.Color color1, System.Drawing.Color color2, float t)
        {
            // Clamp t between 0 and 1
            t = Math.Max(0, Math.Min(1, t));

            int r = (int)(color1.R + (color2.R - color1.R) * t);
            int g = (int)(color1.G + (color2.G - color1.G) * t);
            int b = (int)(color1.B + (color2.B - color1.B) * t);
            int a = (int)(color1.A + (color2.A - color1.A) * t); // optional

            return System.Drawing.Color.FromArgb(a, r, g, b);
        }

        public static Pen GetPenUsingHorizontalSpeed(float droneSpeed, List<DroneData> dataPoints, float lineThickness = 3f)
        {

            // Find topspeed
            int fastestPointIndex = dataPoints.Select((data, index) => new { Data = data, Index = index })
                                              .OrderByDescending(x => x.Data.HorizontalSpeed)
                                              .First().Index;
            float topSpeed = dataPoints[fastestPointIndex].HorizontalSpeed;

            // Get line thickness from altitude

            if (droneSpeed <= DJIDataReader.ConvertSpeed(CINEMA_SPEED, DJIDataReader.selectedSpeedUnit))
            {
                // Slow speed
                float t = (droneSpeed - 0) / (DJIDataReader.ConvertSpeed(CINEMA_SPEED, DJIDataReader.selectedSpeedUnit) - droneSpeed);
                System.Drawing.Color col = InterpolateColor(CINEMA_SPEED_COLOR, NORMAL_SPEED_COLOR, t);
                return new Pen(col, lineThickness);
            }
            else if (droneSpeed > DJIDataReader.ConvertSpeed(CINEMA_SPEED, DJIDataReader.selectedSpeedUnit) && droneSpeed < DJIDataReader.ConvertSpeed(NORMAL_SPEED, DJIDataReader.selectedSpeedUnit))
            {
                // Normal speed
                float t = (droneSpeed - DJIDataReader.ConvertSpeed(CINEMA_SPEED, DJIDataReader.selectedSpeedUnit)) / (DJIDataReader.ConvertSpeed(NORMAL_SPEED, DJIDataReader.selectedSpeedUnit) - droneSpeed);
                System.Drawing.Color col = InterpolateColor(NORMAL_SPEED_COLOR, FAST_SPEED_COLOR, t);
                return new Pen(col, lineThickness);
            }
            else
            {
                // Fast speed
                float t = (droneSpeed - DJIDataReader.ConvertSpeed(NORMAL_SPEED, DJIDataReader.selectedSpeedUnit)) / (topSpeed - droneSpeed);
                System.Drawing.Color col = InterpolateColor(FAST_SPEED_COLOR, System.Drawing.Color.Red, t);
                return new Pen(col, lineThickness);
            }
        }

        /// <summary>
        /// Places marker representing highest point during flight.
        /// </summary>
        /// <param name="dataPoints">List of DroneData points</param>
        /// <param name="flightpathOverlay">Reference to GMapOverlay</param>
        public static void PlaceApogeePointMarker(List<DroneData> dataPoints, GMapOverlay flightpathOverlay, int currentIndex)
        {
            // find apogeePoint
            int apogeePointIndex = dataPoints.Select((data, index) => new { Data = data, Index = index }).OrderByDescending(x => x.Data.Altitude).First().Index;

            // Mark apogee point
            if (currentIndex >= apogeePointIndex)
            {
                AddMapMarker(dataPoints[apogeePointIndex].CoordsAsPointLatLng(), flightpathOverlay,
                      $"Altitude ({DJIDataReader.ConvertDistance(dataPoints[apogeePointIndex].Altitude, DJIDataReader.selectedAltitudeUnit)}"
                      + $" {DJIDataReader.GetAltitudeLabel()})",
                       rightOffset,
                       GMarkerGoogleType.blue_small);
            }
        }

        /// <summary>
        /// Places Start and End markers representing takeoff and landing points
        /// </summary>
        /// <param name="flightpathOverlay">Reference to GMapOverlay</param>
        /// <param name="dataPoints">List of DroneData points</param>
        /// <param name="totalFlightDistanceInMeters">Reference to static float that stores total flight distance in meters</param>
        public static void PlaceStartAndEndMarkers(GMapOverlay flightpathOverlay, List<DroneData> dataPoints, float totalFlightDistanceInMeters)
        {
            // Place start marker
            AddMapMarker(dataPoints[0].CoordsAsPointLatLng(), flightpathOverlay, "Start", aboveOffset, GMarkerGoogleType.green);

            // Find end marker
            int dataCount = dataPoints.Count - 1;
            float totalDistanceToDisplay = DJIDataReader.ConvertDistance(totalFlightDistanceInMeters, DJIDataReader.selectedDistanceUnit); // converted appropriately

            // Place end marker
            AddMapMarker(dataPoints[dataCount].CoordsAsPointLatLng(),
                flightpathOverlay,
                $"End \n({Math.Round(totalDistanceToDisplay, 2)} {DJIDataReader.GetDistanceLabel()})",
                belowOffset,
                GMarkerGoogleType.red);
        }

        /// <summary>
        /// Places marker representing point where drone was traveling the fastest.
        /// </summary>
        /// <param name="dataPoints">List of DroneData points</param>
        /// <param name="flightpathOverlay">Reference to GMapOverlay</param>
        public static void PlaceFastestPointMarker(List<DroneData> dataPoints, GMapOverlay flightpathOverlay, int currentIndex)
        {
            // Find fastest point
            int fastestPointIndex = dataPoints.Select(
                (data, index) => new { Data = data, Index = index }).OrderByDescending(x => x.Data.HorizontalSpeed).First().Index;
            float topSpeed = DJIDataReader.ConvertSpeed(dataPoints[fastestPointIndex].HorizontalSpeed, DJIDataReader.selectedSpeedUnit);

            // Mark fastest point

            if (currentIndex >= fastestPointIndex)
            {
                AddMapMarker(dataPoints[fastestPointIndex].CoordsAsPointLatLng(),
                    flightpathOverlay, $"Fastest point ({Math.Round(topSpeed, 1)}"
                    + $" {DJIDataReader.GetSpeedLabel()})", leftOffset, GMarkerGoogleType.orange_small);
            }
        }

        /// <summary>
        /// Places marker representing furthest drone was away from controller
        /// </summary>
        /// <param name="dataPoints">List of DroneData points</param>
        /// <param name="flightpathOverlay">Reference to GMapOverlay</param>
        public static void PlaceFurthestPointMarker(List<DroneData> dataPoints, GMapOverlay flightpathOverlay, int currentIndex)
        {
            // Find furthest point
            int furthestPointIndex = 0;
            if (currentIndex >= 1)
            {
                furthestPointIndex = dataPoints.Take(currentIndex).Select((data, index) => new { Data = data, Index = index }).OrderByDescending(x => x.Data.Distance).First().Index;
            }

            float furthestDistance = DJIDataReader.ConvertDistance(dataPoints[furthestPointIndex].Distance, DJIDataReader.selectedDistanceUnit);

            // Mark furthest point
            AddMapMarker(dataPoints[furthestPointIndex].CoordsAsPointLatLng(), flightpathOverlay,
                    $"Distance ({Math.Round(furthestDistance, 2)}"
                    + $"{DJIDataReader.GetDistanceLabel()})",
                    aboveOffset,
                    GMarkerGoogleType.purple_small);

            // Draw beeline from furthest point to start point
            GMapRoute furthestPointRoute = new GMapRoute(new List<PointLatLng> { dataPoints[0].CoordsAsPointLatLng(),
            dataPoints[furthestPointIndex].CoordsAsPointLatLng() },
                "Furthest Point Beeline");

            furthestPointRoute.Stroke = new Pen(System.Drawing.Color.Magenta, 2);
            flightpathOverlay.Routes.Add(furthestPointRoute);
        }


        public static float InterpolateFloats(float a, float b, float t) => a + (b - a) * t;


        /// <summary>
        /// Plots flight onto GMapOverlay given a set of DroneData points
        /// </summary>
        /// <param name="maxIndex">How many datapoints to draw on map</param>
        /// <param name="dataPoints">List of DroneData points</param>
        /// <param name="flightpathOverlay">Reference to GMapOverlay</param>
        /// <returns></returns>
        public static float PlotFlightOnMap(int maxIndex, List<DroneData> dataPoints, GMapOverlay flightpathOverlay)
        {
            double totalFlightDistanceInKilometers = 0;

            var points = GetPointsUpToIndex(maxIndex, dataPoints);
            if (points.Count < 2) return 0;

            var smoothedPoints = SmoothWithMovingAverage(points, 2);

            // Group points into segments with similar speed ranges
            List<PointLatLng> segment = new List<PointLatLng> { smoothedPoints[0] };
            float previousSpeed = (dataPoints[0].HorizontalSpeed + dataPoints[1].HorizontalSpeed) / 2;

            Pen currentPen = GetPenUsingHorizontalSpeed(previousSpeed, dataPoints);

            for (int i = 1; i < smoothedPoints.Count; i++)
            {

                float currentAvgAltitude = (dataPoints[i].Altitude + dataPoints[i - 1].Altitude) / 2f;
                float currentAltitudeT = currentAvgAltitude / 120f;
                float lineThickness = InterpolateFloats(2f, 6f, currentAltitudeT);

                float currentSpeed = (dataPoints[i].HorizontalSpeed + dataPoints[i - 1].HorizontalSpeed) / 2;
                Pen newPen = GetPenUsingHorizontalSpeed(currentSpeed, dataPoints, lineThickness);

                // If the speed class (and thus pen) changes, flush the current segment
                if (!PensAreEqual(currentPen, newPen))
                {
                    if (segment.Count > 1)
                    {
                        var route = new GMapRoute(segment, "Flight Segment");
                        route.Stroke = currentPen;
                        flightpathOverlay.Routes.Add(route);
                        totalFlightDistanceInKilometers += route.Distance;
                    }

                    // Start new segment
                    segment = new List<PointLatLng> { smoothedPoints[i - 1], smoothedPoints[i] };
                    currentPen = newPen;
                }
                else
                {
                    segment.Add(smoothedPoints[i]);
                }
            }

            // Add final segment
            if (segment.Count > 1)
            {
                var route = new GMapRoute(segment, "Flight Segment Final");
                route.Stroke = currentPen;
                flightpathOverlay.Routes.Add(route);
                totalFlightDistanceInKilometers += route.Distance;
            }

            return (float)totalFlightDistanceInKilometers;
        }


        private static bool PensAreEqual(Pen p1, Pen p2)
        {
            return p1.Color == p2.Color && p1.Width == p2.Width;
        }


        public static void AddFlightInfoMarkers(GMapOverlay flightpathOverlay, List<DroneData> dataPoints, double totalFlightDistanceInKilometers, int currentIndex)
        {
            // Mark takeoff and landing
            float totalFlightDistanceInMeters = (float)totalFlightDistanceInKilometers * 1000; // convert km to m
            PlaceStartAndEndMarkers(flightpathOverlay, dataPoints, totalFlightDistanceInMeters);
            PlaceFastestPointMarker(dataPoints, flightpathOverlay, currentIndex);
            PlaceFurthestPointMarker(dataPoints, flightpathOverlay, currentIndex);
            PlaceApogeePointMarker(dataPoints, flightpathOverlay, currentIndex);
        }

        public static List<PointLatLng> SmoothWithMovingAverage(List<PointLatLng> points, int windowSize)
        {
            var smoothed = new List<PointLatLng>();
            for (int i = 0; i < points.Count; i++)
            {
                double sumLat = 0, sumLng = 0;
                int count = 0;
                for (int j = i - windowSize; j <= i + windowSize; j++)
                {
                    if (j >= 0 && j < points.Count)
                    {
                        sumLat += points[j].Lat;
                        sumLng += points[j].Lng;
                        count++;
                    }
                }
                smoothed.Add(new PointLatLng(sumLat / count, sumLng / count));
            }
            return smoothed;
        }


    }
}