
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
        private List<MovieDetail> _movieDetailList;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            var jsonStr = this.Intent.GetStringExtra("movieList");
            this._movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonStr);

            var jsonStrDetail = this.Intent.GetStringExtra("movieDetailList");
            this._movieDetailList = JsonConvert.DeserializeObject<List<MovieDetail>>(jsonStrDetail);

            this.ListView.ItemClick += (sender, args) =>
            {

                var intent = new Intent(this, typeof(MovieDetailActivity));
                intent.PutExtra("movieDetailList", JsonConvert.SerializeObject(this._movieDetailList[args.Position]));
                this.StartActivity(intent);
            };

            this.ListAdapter = new MovieListAdapter(this, this._movieList);


            // Create your application here
        }
    }
}
