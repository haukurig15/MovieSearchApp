
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
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using Newtonsoft.Json;

namespace MovieSearch.Droid
{
    [Activity(Label = "Movie list", Theme = "@style/MyTheme")]
    public class MovieListActivity : ListActivity
    {
        private List<Movie> _movieList;
        private MovieDetail _movieDetail;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            MovieDbFactory.RegisterSettings(new MovieDbSettings());
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            var movieService = new MovieServices(movieApi);

            var jsonStr = this.Intent.GetStringExtra("movieList");
            this._movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonStr);

            this.ListView.ItemClick += async (sender, args) =>
            {

                _movieDetail = await movieService.getMovieDetails(this._movieList[args.Position].Id);

                var intent = new Intent(this, typeof(MovieDetailActivity));
                intent.PutExtra("movieDetailList", JsonConvert.SerializeObject(this._movieDetail));
                this.StartActivity(intent);
            };

            this.ListAdapter = new MovieListAdapter(this, this._movieList);


            // Create your application here
        }
    }
}
