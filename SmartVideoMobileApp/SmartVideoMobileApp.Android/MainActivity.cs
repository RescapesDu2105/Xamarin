using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using DTOLib;
using System.Collections.Generic;
using System.Net;
using System;
using System.Text;
using Newtonsoft.Json;
using SmartApp;
using System.Net.Http;
using static Android.Provider.SyncStateContract;

namespace SmartVideoMobileApp.Droid
{
    [Activity(Label = "SmartVideoMobileApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        public ListView mView;
        public List<FilmDTO> ListeFilms;
        public WebClient mWeb;
        public Toolbar mTool;
        public Button mSearch;
        public HttpClient client;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.buttonChercher);

            button.Click += Button_Click; 
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            List<FilmDTO> Films = await ChargerFilms();
        }

        private async Task<List<FilmDTO>> ChargerFilms()
        {
            EditText TF = FindViewById<EditText>(Resource.Id.TF_Recherche);
            var response = await client.GetAsync(new Uri("http://localhost:62835/api/films/" + TF.Text));
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<FilmDTO> Films = JsonConvert.DeserializeObject<List<FilmDTO>>(content);
                Console.WriteLine(Films.Count);
                return Films;
            }
            return null;
        }
    }
}

