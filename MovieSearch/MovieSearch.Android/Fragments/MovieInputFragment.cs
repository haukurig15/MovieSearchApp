
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using Newtonsoft.Json;
using Fragment = Android.Support.V4.App.Fragment;
using MovieSearch.Droid.Activities;

namespace MovieSearch.Droid.Fragments
{
    [Activity(Label = "MovieSearch", Theme = "@style/MyTheme")]
    public class MovieInputFragment : Fragment
    {
        private MovieServices _movieService;

        public MovieInputFragment(MovieServices movieService)
        {
            this._movieService = movieService;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle bundle)
        {
            var rootView = inflater.Inflate(Resource.Layout.MovieInput, container, false);

            // Get our button from the layout resource,
            // and attach an event to it
            var movieInputText = rootView.FindViewById<EditText>(Resource.Id.movieTextInputLabel);
            var getMovieButton = rootView.FindViewById<Button>(Resource.Id.getMovieButton);
            var displayMovieTextView = rootView.FindViewById<TextView>(Resource.Id.displayMovieSearchLabel);
            var spinner = rootView.FindViewById<ProgressBar>(Resource.Id.progressBar);
            spinner.Visibility = ViewStates.Invisible;

            getMovieButton.Click += async (object sender, EventArgs e) =>
            {
                spinner.Visibility = ViewStates.Visible;
                var manager = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
                manager.HideSoftInputFromWindow(movieInputText.WindowToken, 0);
                var movieResult = await _movieService.getListOfMoviesMatchingSearch(movieInputText.Text);
                var movieDetailResult = await _movieService.getListOfMovieDetails(movieResult);
                spinner.Visibility = ViewStates.Invisible;
                movieInputText.Text = "";
                var intent = new Intent(this.Context, typeof(MovieListActivity));
                intent.PutExtra("movieList", JsonConvert.SerializeObject(movieResult));
                intent.PutExtra("movieDetailList", JsonConvert.SerializeObject(movieDetailResult));
                this.StartActivity(intent);

            };



            return rootView;
        }
    }
}
