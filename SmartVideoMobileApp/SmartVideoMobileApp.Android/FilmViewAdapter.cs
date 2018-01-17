using System;
using Android.Widget;
using Android.Views;
using System.Collections.Generic;
using Android.Content;
using Android;
using DTOLib;


namespace SmartApp
{
    public class FilmViewAdapter : BaseAdapter<FilmDTO>
    {
        private List<FilmDTO> ListeFilms;
        private Context Context;

        public FilmViewAdapter(Context context, List<FilmDTO> ListeFilms)
        {
            this.ListeFilms = ListeFilms;
            Context = context;

        }
        
        public override FilmDTO this[int position]
        {
            get
            {
                return ListeFilms[position];
            }
        }

        public override int Count
        {
            get
            {
                return ListeFilms.Count;

            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            /*View row = convertView;
            if (convertView == null)
            {
                row = LayoutInflater.From(Context).Inflate(Resource.Layout.listview_row, null, false);
            }
            TextView txtV = row.FindViewById<TextView>(Resource.Id.txtTitle);
            TextView txtR = row.FindViewById<TextView>(Resource.Id.txtRuntime);
            txtR.Text = ListeFilms[position].runtime + " minutes";
            txtV.Text = ListeFilms[position].titre;
            ImageView img = row.FindViewById<ImageView>(Resource.Id.imgPoster);
            Koush.UrlImageViewHelper.SetUrlDrawable(img, "http://image.tmdb.org/t/p/w185/" + ListeFilms[position].PosterPath, null, 60000);
            return row;*/

            return null;
        }
    }
}
