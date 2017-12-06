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
using MovieSearch;
using MovieSearch.Droid;

namespace HelloWorld.Droid
{
    [Activity(Label = "MovieSearch", Theme = "@style/MyTheme.Splash", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MovieDbFactory.RegisterSettings(new MovieDbSettings());
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            var movieService = new MovieServices(movieApi);

            // Create your application here
            MainActivity.movieService = movieService;



            this.StartActivity(typeof(MainActivity));
            this.Finish();
        }
    }
}
