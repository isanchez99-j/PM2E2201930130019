using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using RestSharp;
using Proyecto2.Models;
using System.Diagnostics;
using static SQLite.SQLite3;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Xamarin.Essentials;

namespace Proyecto2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LugaresCercanos : ContentPage
    {
        public LugaresCercanos()
        {
            InitializeComponent();
           
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            using (HttpClient Client = new HttpClient())
            {
                try
                {
                    Client.DefaultRequestHeaders.Add("Accept", "application/json");
                    Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "fsq3aak/Qa6tRSnqp3o7IzIcCjJ1AsvTt6ZQf3tFxud8vS8=");
                    var Response = await Client.GetAsync("https://api.foursquare.com/v3/places/search?ll=14.67%2C-86.21");
                    
                    var res = Response.Content.ReadAsStringAsync().Result;
                    var reponseObj = JsonConvert.DeserializeObject<Places>(res);

                    Lista.ItemsSource = reponseObj.Results;
                }
                catch (Exception e)
                {
                    var CatchException = e.ToString();
                }
            }
        }

        public async void Cargar_Sitios()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
      
            using (HttpClient Client = new HttpClient())
            {
                try
                {
                    var Response = await Client.GetAsync("https://api.foursquare.com/v3/places/search?ll=14.67%2C-86.21");
                    Client.DefaultRequestHeaders.Add("Accept", "application/json");
                    Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "fsq3aak/Qa6tRSnqp3o7IzIcCjJ1AsvTt6ZQf3tFxud8vS8=");

                    var response = Response.Content.ReadAsStringAsync().Result;
                    var reponseObj = JsonConvert.DeserializeObject<Places>(response);

                    Lista.ItemsSource = reponseObj.Results;
                }
                catch (Exception e)
                {
                    var CatchException = e.ToString();
                }
            }
        }

        private async void ListSitio_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sitio = (Venue)e.Item;

            bool answer = await DisplayAlert("AVISO", "¿Quiere ir al mapa?", "Si", "No");

            if (answer == true)
            {
                // Opens the map
                var location = new Xamarin.Essentials.Location(sitio.Geocodes.Main.Latitude, sitio.Geocodes.Main.Longitude);
                var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

                await Xamarin.Essentials.Map.OpenAsync(location, options);
            };
        }
    }
}