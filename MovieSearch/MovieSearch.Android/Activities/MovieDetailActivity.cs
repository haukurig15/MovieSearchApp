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
using Newtonsoft.Json;

namespace MovieSearch.Droid.Activities
{
    [Activity(Label = "Movie info", Theme = "@style/MyTheme")]
    public class MovieDetailActivity : Activity
    {
        private MovieDetail _movieDetail;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var jsonStr = this.Intent.GetStringExtra("movieDetailList");
            this._movieDetail = JsonConvert.DeserializeObject<MovieDetail>(jsonStr);

            var movieDetail = new MovieDetail();

            SetContentView(Resource.Layout.MovieDetail);


            var toolbar = this.FindViewById<Toolbar>(Resource.Id.toolbar);
            this.SetActionBar(toolbar);
            this.ActionBar.Title = "Movie info";


            var movieTitle = this.FindViewById<TextView>(Resource.Id.detailTitle);
            var genres = this.FindViewById<TextView>(Resource.Id.genres);
            var runtime = this.FindViewById<TextView>(Resource.Id.runtime);
            var imageView = this.FindViewById<ImageView>(Resource.Id.movieImage);
            var overview = this.FindViewById<TextView>(Resource.Id.overview);

            var genre = "";
            for (int i = 0; i < this._movieDetail.Genre.Count(); i++){
                if (i == this._movieDetail.Genre.Count() - 1){
                    genre += this._movieDetail.Genre[i].Name;
                }
                else{
                    genre += this._movieDetail.Genre[i].Name + ", ";
                }
            }

            movieTitle.Text = $"{_movieDetail.Title} ({_movieDetail.Year:yyyy})";
            genres.Text = genre;
            runtime.Text = this._movieDetail.RunningTime + " min";
            Glide.With(this).Load("https://image.tmdb.org/t/p/w500" + _movieDetail.ImageUrl).Into(imageView);
            overview.Text = _movieDetail.Overview;


            // Create your application here
        }
    }
}
