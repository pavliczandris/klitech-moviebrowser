using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using MovieBrowser.Models;
using System.Collections.ObjectModel;
using MovieBrowser.Services;
using MovieBrowser.Views;

namespace MovieBrowser.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<ResultMovie> PopularMovies { get; set; } = new ObservableCollection<ResultMovie>();
        public ObservableCollection<ResultTvShow> PopularTvShows { get; set; } = new ObservableCollection<ResultTvShow>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new MovieBrowserService();

            //Load the movies if empty
            if(PopularMovies.Count==0)
            {
                var popularMovies = await service.GetPopularMovies();
                for (int i = 0; i < 20; i++)
                {
                    PopularMovies.Add(popularMovies.results[i]);
                }
            }
            //Load the tv shows if empty
            if (PopularTvShows.Count == 0)
            {
                var popularTvShows = await service.GetPopularTvShows();
                for (int i = 0; i < 20; i++)
                {
                    PopularTvShows.Add(popularTvShows.results[i]);
                }
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigatedToSearchPage(string queryText)
        {
            NavigationService.Navigate(typeof(SearchPage), queryText);
        }

        public void NavigatedToMovieDetails(int movieId)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), movieId);
        }

        public void NavigatedToTvShowDetails(int tvShowId)
        {
            NavigationService.Navigate(typeof(TvShowDetailsPage), tvShowId);
        }

    }
}
