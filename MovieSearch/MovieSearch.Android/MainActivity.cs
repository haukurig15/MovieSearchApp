using System;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using Newtonsoft.Json;
using Fragment = Android.Support.V4.App.Fragment;




namespace MovieSearch.Droid
{
    

    [Activity (Label = "Movie Search", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
	public class MainActivity : FragmentActivity
	{

        public static List<Movie> Movie { get; set; }

        //private MovieServices _movieService;
        //private List<Movie> _movieList;


        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
           

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            var fragments = new Fragment[]
            {
                new MovieInputFragment(Movie),
                new OtherFragment(),
            };

            var titles = CharSequence.ArrayFromStringArray(new[] { "Search", "Top Rated" });

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager.Adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, fragments, titles);

            var tabLayout = this.FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(viewPager);

            var toolbar = this.FindViewById<Toolbar>(Resource.Id.toolbar);
            this.SetActionBar(toolbar);
            this.ActionBar.Title = "Movie Search";

		}
	}
}


