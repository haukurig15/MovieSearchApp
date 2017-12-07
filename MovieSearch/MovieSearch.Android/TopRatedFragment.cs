using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Fragment = Android.Support.V4.App.Fragment;
//using Fragment  = Android.Support.V4.App.Fragment;


namespace MovieSearch.Droid
{
    public class TopRatedFragment : Fragment
    {
        private MovieServices _movieService;
        private List<Movie> _movieList = new List<Movie>();
        private List<MovieDetail> _movieDetailList;
        private ProgressBar _spinner;
        private ListView _listView;

        public TopRatedFragment(MovieServices movieService)
        {
            this._movieService = movieService;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Contract.Ensures(Contract.Result<View>() != null);
            var rootView = inflater.Inflate(Resource.Layout.MovieTopListItem, container, false);
            this._spinner = rootView.FindViewById<ProgressBar>(Resource.Id.progressBar);

            //this._movieList.Add(new Movie { Title = "movie"});


            this._listView = rootView.FindViewById<ListView>(Android.Resource.Id.List);

            this._listView.ItemClick += (sender, args) =>
            {

                var intent = new Intent(this.Activity, typeof(MovieDetailActivity));
                intent.PutExtra("movieDetailList", JsonConvert.SerializeObject(this._movieDetailList[args.Position]));
                this.StartActivity(intent);
            };
        
           
           // this._listView.Adapter = new MovieListAdapter(this.Activity, this._movieList);
            // listView = rootView.FindViewById(Resource.Id.);
            //listView.ItemClick += OnListItemClick;

            //this.ListAdapter = new MovieListAdapter(this.Activity, this._movieList);
                     
           /* new Handler().PostDelayed(async () => {
                spinner.Visibility = ViewStates.Visible;
                var movieResult = await _movieService.getListOfTopRatedMovies();
                var movieDetailResult = await _movieService.getListOfMovieDetails(movieResult);

                var intent = new Intent(this.Context, typeof(MovieListActivity));
                intent.PutExtra("movieList", JsonConvert.SerializeObject(movieResult));
                intent.PutExtra("movieDetailList", JsonConvert.SerializeObject(movieDetailResult));
                this.StartActivity(intent);
            }, 100);
            spinner.Visibility = ViewStates.Invisible;*/

            //   var jsonStr = this.Intent.GetStringExtra("movieList");
            //   this._movieList = JsonConvert.DeserializeObject<List<Movie>>(jsonStr);

            //   var jsonStrDetail = this.Intent.GetStringExtra("movieDetailList");
            //   this._movieDetailList = JsonConvert.DeserializeObject<List<MovieDetail>>(jsonStrDetail);
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return rootView;
        }


        public async Task FetchMovies(){
           // this._spinner.Visibility = ViewStates.Visible;
            this._movieList = await _movieService.getListOfTopRatedMovies();
            this._movieDetailList = await _movieService.getListOfMovieDetails(this._movieList);
            this._spinner.Visibility = ViewStates.Invisible;
            this._listView.Adapter = new MovieListAdapter(this.Activity, this._movieList);

        }

    }
}