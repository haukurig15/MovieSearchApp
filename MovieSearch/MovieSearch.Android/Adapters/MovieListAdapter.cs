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

namespace MovieSearch.Droid.Adapters
{
    public class MovieListAdapter: BaseAdapter<Movie>
    {

        private readonly Activity _context;
        private readonly List<Movie> _movieList;

        public MovieListAdapter(Activity context, List<Movie> movieList)
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
            view.FindViewById<TextView>(Resource.Id.title).Text = $"{movie.Title} ({movie.Year:yyyy})";
            if(movie.Actors.Count() >= 3){
                view.FindViewById<TextView>(Resource.Id.cast).Text = movie.Actors[0] + ", " + movie.Actors[1] + ", " + movie.Actors[2];
            }
            else if (movie.Actors.Count() == 2)
            {
                view.FindViewById<TextView>(Resource.Id.cast).Text = movie.Actors[0] + ", " + movie.Actors[1];
            }
            else if (movie.Actors.Count() == 1)
            {
                view.FindViewById<TextView>(Resource.Id.cast).Text = movie.Actors[0];
            }
            else{
                view.FindViewById<TextView>(Resource.Id.cast).Text = "";
            }


            var imageView = view.FindViewById<ImageView>(Resource.Id.movieImage);
            Glide.With(_context).Load("https://image.tmdb.org/t/p/w500" + movie.ImageUrl).Into(imageView);


            return view;
        }

        //Fill in cound here, currently 0
        public override int Count => this._movieList.Count;

        public override Movie this[int position] => this._movieList[position];
    }
}
