using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Weather_Application_by_Ammar.UI_Screens;
using Weather_Application_by_Ammar.User_Classes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather_Application_by_Ammar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnCheckWeather_Click(object sender, RoutedEventArgs e)
        {
            // open other page
            //WeatherResultScreen wrs = new WeatherResultScreen();
            InputClass cls = new InputClass();
            cls.CountryName = tbCountryName.Text;
            cls.CityName = tbCityName.Text;

            this.Frame.Navigate(typeof(WeatherResultScreen),cls);
        }
    }
}
