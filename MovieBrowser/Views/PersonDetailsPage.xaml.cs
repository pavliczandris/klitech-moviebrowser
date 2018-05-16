﻿using MovieBrowser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MovieBrowser.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PersonDetailsPage : Page
    {
        public PersonDetailsPage()
        {
            this.InitializeComponent();
        }

        private void Movie_ItemClick(object sender, ItemClickEventArgs e)
        {
            var movie = (PersonMovieCreditsCast)e.ClickedItem;
            ViewModel.NavigatedToMovieDetails(movie.id);
        }

        private void TvShow_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tvShow = (PersonTvShowCreditsCast)e.ClickedItem;
            ViewModel.NavigatedToTvShowDetails(tvShow.id);
        }
    }
}
