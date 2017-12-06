using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Bumptech.Glide;

namespace MovieSearch.Droid
{
    public class MovieDetailAdapter : BaseAdapter<MovieDetail>
    {

        private readonly Activity _context;
        private readonly List<MovieDetail> _movieList;

        public MovieDetailAdapter(Activity context, List<MovieDetail> movieList)
        {
            this._context = context;
            this._movieList = movieList;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = convertView; // re--use an existing view, if one is available

            if (view == null)
                view = this._context.LayoutInflater.Inflate(Resource.Layout.MovieListItem, null);

            var movie = this._movieList[position];
            view.FindViewById<TextView>(Resource.Id.title).Text = movie.Title;
            /*if (movie.Actors.Count() >= 3)
            {
                view.FindViewById<TextView>(Resource.Id.cast).Text = movie.Actors[0] + ", " + movie.Actors[1] + ", " + movie.Actors[2];
            }
            else if (movie.Actors.Count() == 2)
            {
                view.FindViewById<TextView>(Resource.Id.cast).Text = movie.Actors[0] + ", " + movie.Actors[1];
            }
            else if (movie.Actors.Count() == 1)
            {
                view.FindViewById<TextView>(Resource.Id.cast).Text = movie.Actors[0];
            }*/

            //view.FindViewById<TextView>(Resource.Id.cast).Text = movie.Actors[0] + movie.Actors[1] + movie.Actors[2];
            //var resourceId =
            //this._context.Resources.GetIdentifier(person.ImageName, "drawable", this._context.PackageName);
            //var resourceId = Glide.With(view).Load(movie.ImageUrl).Into("drawable");
            //view.FindViewById<ImageView>(Resource.Id.picture).SetBackgroundResource((int)resourceId);


            return view;
        }

        //Fill in cound here, currently 0
        public override int Count => this._movieList.Count;

        public override MovieDetail this[int position] => this._movieList[position];
    }
}
