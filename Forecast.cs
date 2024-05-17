using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Forecast
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GenerationTimeMs { get; set; }
        public int UtcOffsetSeconds { get; set; }
        public string? Timezone { get; set; }
        public string? TimezoneAbbreviation { get; set; }
        public double Elevation { get; set; }
        public HourlyUnits HourlyUnits { get; set; }
        public HourlyData Hourly { get; set; }
    }

    public class HourlyUnits
    {
        public string Time { get; set; }
        public string Temperature_2m { get; set; }
    }

    public class HourlyData
    {
        public List<DateTime> Time { get; set; }
        public List<double> Temperature_2m { get; set; }
    }
}
