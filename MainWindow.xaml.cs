using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WeatherApp : Window
    {
        public WeatherApp()
        {
            InitializeComponent();
            GetCurrentWeather();
        }

        enum Units {standard, metric, imperial};
        enum Lang {af, al, ar, az, bg, ca, cz, da, de, el, en, eu, fa, fi, fr, gl, he, hi, hr, hu, id, it, ja, kr, la, lt, mk, no, nl, pl, pt, pt_br, ro, ru, sv, sk, sl, sp, es, sr, th, tr, uk, vi, zh_cn, zu };


        public string Location = "Praha";
        private string APIKey = "";

        private Units UnitsChoice = Units.metric;
        private Lang LangChoice = Lang.en;



        private async void GetCurrentWeather()
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={Location}&appid={APIKey}&units={UnitsChoice}&lang={LangChoice}";

            API_Response data = await API_Caller.Get(url);

            if (data.Successuful)
            {
                var info = JsonConvert.DeserializeObject<WeatherInfo>(data.Response);


                Description.Content = info.weather[0].description.ToLowerInvariant();
                ActualTemp.Content = $"{info.main.temp.ToString("0")}°C";
                WeatherIcon.Source = new BitmapImage(new Uri($@"Icons/w{info.weather[0].icon}.png", UriKind.Relative));
                Wind.Content = $"{info.wind.speed} m/s";
                Humidity.Content = $"{info.main.humidity}%";
                Pressure.Content = $"{info.main.pressure} hpa";
                Cloudiness.Content = $"{info.clouds.all}%";
                FeelTemp.Content = $"Feels like: {info.main.feels_like.ToString("0")}°C";
                MaxTemp.Content = $"Max: {info.main.temp_max.ToString("0")}°C";
                MinTemp.Content = $"Min: {info.main.temp_min.ToString("0")}°C";
            }
            else
            {
                MessageBox.Show(@"No weather information found
incorrect format of city name", "Weather Info",  MessageBoxButton.OK);
            }
        }

        private void LocationInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Location = LocationInput.Text;
                GetCurrentWeather();
            }
        }
    }
}
