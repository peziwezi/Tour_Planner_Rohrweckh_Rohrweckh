using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;
using Tour_Planner.BLL;
using Tour_Planner.DAL;
using Tour_Planner.ViewModels;

namespace Tour_Planner;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var tourRepository = new TourRepository();
        var tourManager = new TourManager(tourRepository);
        var tourLogRepository = new TourLogRepository();
        var tourLogManager = new TourLogManager(tourLogRepository);
        var searchViewModel = new SearchViewModel(tourManager);
        var tourViewModel = new TourViewModel(tourManager);
        var detailsViewModel = new DetailsViewModel(tourManager);
        var tourLogViewModel = new TourLogViewModel(tourLogManager);
        var wnd = new MainWindow
        {
            DataContext = new MainViewModel(tourManager, tourLogManager,searchViewModel, tourViewModel, detailsViewModel, tourLogViewModel),
            SearchBar = { DataContext = searchViewModel },
            TourView = { DataContext = tourViewModel },
            DetailsView = { DataContext = detailsViewModel },
            TourLogView = { DataContext = tourLogViewModel }
        };

        wnd.Show();
    }
}

