using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Weather_Application_by_Ammar.User_Classes;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Weather_Application_by_Ammar.UI_Screens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeatherResultScreen : Page
    {
        public WeatherResultScreen()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            InputClass cls = new InputClass();
            cls = (InputClass)e.Parameter;
            // this is a comment.
            try
            {
                string cityName = cls.CityName;
                string countryName = cls.CountryName;
                var client = new HttpClient();

                
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                                "http://api.openweathermap.org/data/2.5/weather?q=" + cityName+"&APPID=40f2119109e348ab1e9fb702ced81160");

                #region Solution by Asfend [ Rejected ]
                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                //    "http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "," + countryName +
                //    "&appid = 40f2119109e348ab1e9fb702ced81160");
                #endregion

                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = response.Content;
                    string restultString = await result.ReadAsStringAsync();
                    // var data = JsonConvert.
                    var data = JsonConvert.DeserializeObject<RootObject>(restultString);

                    //lblWeatherResults.Text = data.weather.ToString();
                    lblCountryCityName.Text = data.sys.country.ToString() +" - "+ data.name;

                    lblTemprature.Text = data.main.temp.ToString();

                    lblTempratureMaxMin.Text = "Maximum = "+data.main.temp_max.ToString()
                        +" -  Minimum = "+ data.main.temp_min.ToString();
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageDialog msg = new MessageDialog("Unauthorized call", "Error");
                    await msg.ShowAsync();
                }
                else
                {
                    MessageDialog msg = new MessageDialog("No response received","No results");
                    await msg.ShowAsync();

                }

            }
            catch (Exception ee)
            {
                MessageDialog msg = new MessageDialog("There is a problem in fetching weather details\n\n" + ee.Message, "Error");
                await msg.ShowAsync();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
            //Application.Current.Exit();
        }

    }
}
