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


namespace MovieSearch.Droid
{
    public class TopRatedFragment : Fragment
    {
        private MovieServices _movieService;
        private List<Movie> _movieList = new List<Movie>();
        private List<MovieDetail> _movieDetailList = new List<MovieDetail>();
        private ProgressBar _spinner;
        private ListView _listView;

        public TopRatedFragment(MovieServices movieService)
        {
            this._movieService = movieService;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.MovieTopList, container, false);
            this._spinner = rootView.FindViewById<ProgressBar>(Resource.Id.progressBar);



            this._listView = rootView.FindViewById<ListView>(Resource.Id.listView);

            this._listView.ItemClick += (sender, args) =>
            {

                var intent = new Intent(this.Activity, typeof(MovieDetailActivity));
                intent.PutExtra("movieDetailList", JsonConvert.SerializeObject(this._movieDetailList[args.Position]));
                this.StartActivity(intent);
            };

            return rootView;
        }


        public async Task FetchMovies(){
            this._spinner.Visibility = ViewStates.Visible;
            this._movieList = await _movieService.getListOfTopRatedMovies();
            this._movieDetailList = await _movieService.getListOfMovieDetails(this._movieList);
            this._spinner.Visibility = ViewStates.Invisible;
            this._listView.Adapter = new MovieListAdapter(this.Activity, this._movieList);

        }

        public void clearTopRatedList(){
            
            this._movieList.Clear();
            this._movieDetailList.Clear();
        }

    }
}