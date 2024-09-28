using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Практика_4
{
    /// <summary>
    /// Логика взаимодействия для DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        private List<Movie> movies = new List<Movie>();
        public DashboardWindow()
        {
            InitializeComponent();
            WelcomeTextBlock.Text = $"Добро пожаловать";
        }
        private void AddMovieButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(MovieTextBox.Text))
            {
                movies.Add(new Movie { Title = MovieTextBox.Text, IsWatched = false });
                UpdateMovieList();
                MovieTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Введите название фильма.");
            }
        }

        private void MarkAsWatchedButton_Click(object sender, RoutedEventArgs e)
        {
            if (MoviesListBox.SelectedItem is Movie selectedMovie)
            {
                selectedMovie.IsWatched = true;
                UpdateMovieList();
            }
        }

        private void UpdateMovieList()
        {
            MoviesListBox.ItemsSource = null;
            MoviesListBox.ItemsSource = movies;
        }

    }
    public class Movie
    {
        public string Title { get; set; }
        public bool IsWatched { get; set; }

        public override string ToString() => $"{Title} {(IsWatched ? "(Просмотрено)" : "")}";
    }
}
