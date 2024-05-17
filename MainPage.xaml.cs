using System;
using System.Text.Json;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {

        JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };


        public MainPage()
        {

            GetForecast(null, null);
            InitializeComponent();



            getTodaysDate.Text = DateTime.Now.ToString("M/d/yyyy");
        }

        private async void GetForecast(object sender, EventArgs e)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.None)
            {
                HttpClient client = new HttpClient();

                string response = await client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m&temperature_unit=fahrenheit&forecast_days=1");

                if (!string.IsNullOrEmpty(response))
                {
                    Forecast forecastData = JsonSerializer.Deserialize<Forecast>(response, _serializerOptions);

                    if (forecastData != null && forecastData.Hourly != null && forecastData.Hourly.Temperature_2m != null && forecastData.Hourly.Time != null)
                    {
                        List<DateTime> times = forecastData.Hourly.Time;
                        List<double> temperatures = forecastData.Hourly.Temperature_2m;

                        if (times.Count == temperatures.Count && times.Any())
                        {
                            // Create a list of formatted strings with time and temperature
                            List<string> forecastItems = new List<string>();

                            for (int i = 0; i < times.Count; i++)
                            {
                                // Convert time to 12-hour format with AM/PM notation
                                string formattedTime = times[i].ToString("h:mm tt");

                                // Create the forecast item string with formatted time and temperature
                                string formattedForecastItem = $"{formattedTime}: {temperatures[i]}°F";
                                forecastItems.Add(formattedForecastItem);
                            }

                            // Join the formatted forecast items into a single string separated by new lines
                            string formattedForecast = string.Join(Environment.NewLine, forecastItems);

                            ApiOutput.Text = formattedForecast;
                        }
                        else
                        {
                            ApiOutput.Text = "Forecast data mismatch";
                        }
                    }
                    else
                    {
                        ApiOutput.Text = "Invalid forecast data format";
                    }
                }
                else
                {
                    ApiOutput.Text = "Empty response from API";
                }
            }
            else
            {
                ApiOutput.Text = "No internet connection";
            }
        }



    }

}
