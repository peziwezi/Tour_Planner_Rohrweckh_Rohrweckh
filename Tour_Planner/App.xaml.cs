using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;
using Tour_Planner.ViewModels;

namespace Tour_Planner;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var searchViewModel = new SearchViewModel();
        var tourViewModel = new TourViewModel();
        var detailsViewModel = new DetailsViewModel();
        var tourLogViewModel = new TourLogViewModel();
        var wnd = new MainWindow
        {
            DataContext = new MainViewModel(searchViewModel, tourViewModel, detailsViewModel, tourLogViewModel),
            SearchBar = { DataContext = searchViewModel },
            TourView = { DataContext = tourViewModel },
            DetailsView = { DataContext = detailsViewModel },
            TourLogView = { DataContext = tourLogViewModel }
        };

        wnd.Show();
    }
}

