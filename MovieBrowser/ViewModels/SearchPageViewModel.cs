using MovieBrowser.Models;
using MovieBrowser.Services;
using MovieBrowser.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Template10.Utils;

namespace MovieBrowser.ViewModels
{
    class SearchPageViewModel : ViewModelBase
    {
        public ObservableCollection<SearchResult> SearchResults { get; set; } = new ObservableCollection<SearchResult>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var queryString = (string)parameter;
            Search(queryString);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Sends and asynchronous request to search movies, tv shows or people.
        /// </summary>
        /// <param name="queryString">Search query text - can't be empty</param>
        public async void Search(string queryString)
        {
            //The querySting needs to be URL encoded
            string encodedQuery = Uri.EscapeDataString(queryString);

            //Query validation: do nothing if invalid
            if (encodedQuery.Length == 0) return;

            //It can be a problem if we navigate back, because it loads again, so we have to clear it
            if (SearchResults.Count != 0) SearchResults.Clear();

            var service = new MovieBrowserService();
            SearchMulti result = await service.SearchMulti(encodedQuery);
            foreach (var item in result.results)
            {
                SearchResults.Add(item);
            }
        }

        /// <summary>
        /// Calls the navigation method for the given item.
        /// </summary>
        /// <param name="id">ID of item</param>
        /// <param name="mediaType">Media type of the item - can only be movie, tv or person</param>
        public void ShowDetails(int id, string mediaType)
        {
            if (mediaType == "movie") NavigatedToMovieDetails(id);
            if (mediaType == "tv") NavigatedToTvShowDetails(id);
            if (mediaType == "person") NavigatedToPersonDetails(id);
        }

        private void NavigatedToMovieDetails(int movieId)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), movieId);
        }

        private void NavigatedToTvShowDetails(int tvShowId)
        {
            NavigationService.Navigate(typeof(TvShowDetailsPage), tvShowId);
        }

        private void NavigatedToPersonDetails(int personId)
        {
            NavigationService.Navigate(typeof(PersonDetailsPage), personId);
        }
    }
}
