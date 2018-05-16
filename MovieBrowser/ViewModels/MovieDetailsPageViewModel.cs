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

namespace MovieBrowser.ViewModels
{
    public class MovieDetailsPageViewModel : ViewModelBase
    {
        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
            set { Set(ref _movie, value); }
        }

        public ObservableCollection<Cast> CastList { get; set; } = new ObservableCollection<Cast>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var movieId = (int)parameter;
            var service = new MovieBrowserService();
            //Don't borther the server if we dont have to
            if (Movie == null)
            {
                Movie = await service.GetMovie(movieId);
            }
            //Load the cast if empty
            if (CastList.Count==0)
            {
                Credits credits = await service.GetMovieCredits(movieId);
                for (int i = 0; i < credits.cast.Length; i++)
                {
                    CastList.Add(credits.cast[i]);
                }
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigatedToPersonDetails(int personId)
        {
            NavigationService.Navigate(typeof(PersonDetailsPage), personId);
        }
    }
}
