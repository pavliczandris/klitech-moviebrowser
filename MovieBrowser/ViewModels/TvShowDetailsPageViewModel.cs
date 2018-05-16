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
    public class TvShowDetailsPageViewModel : ViewModelBase
    {
        private TvShow _tvShow;
        public TvShow TvShow
        {
            get { return _tvShow; }
            set { Set(ref _tvShow, value); }
        }

        public ObservableCollection<Cast> CastList { get; set; } = new ObservableCollection<Cast>();
        public ObservableCollection<Season> Seasons { get; set; } = new ObservableCollection<Season>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var tvShowId = (int)parameter;
            var service = new MovieBrowserService();
            //Don't borther the server if we dont have to
            if (TvShow == null)
            {
                TvShow = await service.GetTvShow(tvShowId);
            }
            //Load cast if empty
            if (CastList.Count == 0)
            {
                Credits credits = await service.GetTvShowCredits(tvShowId);
                for (int i = 0; i < credits.cast.Length; i++)
                {
                    CastList.Add(credits.cast[i]);
                }
            }
            //Load seasons if empty
            if (Seasons.Count == 0)
            {
                for (int i = 1; i <= TvShow.number_of_seasons; i++)
                {
                    Season season = await service.GetSeason(TvShow.id, i);
                    Seasons.Add(season);
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
