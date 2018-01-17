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

        public Uri murl = new Uri("http://localhost/api/films");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate 
            {
                ChargerFilms();
            };
        }

        void ChargerFilms()
        {
            mWeb = new WebClient();

            mWeb.DownloadDataAsync(murl);
            mWeb.DownloadDataCompleted += MWeb_DownloadDataCompleted;
            mWeb.Dispose();
        }
        private void MWeb_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                try
                {
                    string json = Encoding.UTF8.GetString(e.Result);
                    ListeFilms = JsonConvert.DeserializeObject<List<FilmDTO>>(json);
                    FilmViewAdapter adapter = new FilmViewAdapter(this, ListeFilms);
                    mView.Adapter = adapter;
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "Une erreur est survenue lors de la connexion avec le serveur central", ToastLength.Short).Show();
                }
            });

        }
    }
}

