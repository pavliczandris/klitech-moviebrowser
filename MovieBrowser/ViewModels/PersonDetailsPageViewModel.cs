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
    public class PersonDetailsPageViewModel : ViewModelBase
    {
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { Set(ref _person, value); }
        }

        public ObservableCollection<PersonMovieCreditsCast> Movies { get; set; } = new ObservableCollection<PersonMovieCreditsCast>();
        public ObservableCollection<PersonTvShowCreditsCast> TvShows { get; set; } = new ObservableCollection<PersonTvShowCreditsCast>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var personId = (int)parameter;
            var service = new MovieBrowserService();
            //Don't borther the server if we dont have to
            if (Person == null)
            {
                Person = await service.GetPerson(personId);
            }
            //Load the movies if empty and order by descending popularity
            if (Movies.Count==0)
            {
                PersonMovieCredits movieCredits = await service.GetPersonMovieCredits(personId);
                var movies = new List<PersonMovieCreditsCast>(movieCredits.cast.OrderByDescending(x => x.popularity));
                foreach (var item in movies)
                {
                    Movies.Add(item);
                }
            }
            //Load the tv shows if empty and order by descending popularity
            if (TvShows.Count==0)
            {
                PersonTvShowCredits tvShowCredits = await service.GetPersonTvShowCredits(personId);
                var tvShows = new List<PersonTvShowCreditsCast>(tvShowCredits.cast.OrderByDescending(x => x.popularity));
                foreach (var item in tvShows)
                {
                    TvShows.Add(item);
                }
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
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
