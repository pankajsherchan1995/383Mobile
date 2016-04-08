﻿using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Sp16p3g8MobileApp
{
    public class MovieListPage : ContentPage
    {
        ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var webService = new MovieService();
            var response = await webService.GetMovieAsync();
            foreach (var movie in response)
            {
                movies.Add(new Movie()
                {
                    ID = movie.ID,
                    Name = movie.Name,
                    ReleaseDate = movie.ReleaseDate,
                    Rating = movie.Rating,
                    Description = movie.Description
                });

            }
        }

        public MovieListPage()
        {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

                /**
                Implementing the search functionality
                **/

                Title = "Movies";
                Padding = new Thickness(20, Device.OnPlatform(20, 20, 20), 20, 20);
                SearchBar movieSearchBar = new SearchBar
                {
                    Placeholder = "Search Movies",

                };



            ListView listView = new ListView();
            listView.ItemsSource = movies;


            movieSearchBar.TextChanged += (sender, e) =>
                {
                    if (string.IsNullOrWhiteSpace(movieSearchBar.Text))
                        listView.ItemsSource = movies;
                    else
                        listView.ItemsSource = movies.Where(p => p.Name.ToLower().Contains(movieSearchBar.Text.ToLower()));

                };

                movieSearchBar.SearchButtonPressed += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(movieSearchBar.Text))
                    {
                        listView.ItemsSource = movies.Where(p => p.Name.ToLower().Contains(movieSearchBar.Text.ToLower()));
                    }
                };

                listView.ItemTemplate = new DataTemplate(typeof(MovieTemplate));


                var layout = new StackLayout { };
                layout.Children.Add(movieSearchBar);
                layout.Children.Add(listView);

                Content = layout;


                listView.ItemSelected += async (sender, e) =>
                {
                    if (e.SelectedItem != null)
                    {
                        Movie item = (Movie)e.SelectedItem;
                        listView.SelectedItem = null;
                        await Navigation.PushAsync(new MovieDetailPage(item));
                    }

                };
            }


       
    }

     
       
  }









