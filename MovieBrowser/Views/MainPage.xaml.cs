using MovieBrowser.Models;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace MovieBrowser.Views
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Movie_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movie = (ResultMovie)e.ClickedItem;
            ViewModel.NavigatedToMovieDetails(movie.id);
        }

        private void TvShow_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tvShow = (ResultTvShow)e.ClickedItem;
            ViewModel.NavigatedToTvShowDetails(tvShow.id);
        }

        private void SearchButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.NavigatedToSearchPage(SearchTextBox.Text);
        }
    }
}