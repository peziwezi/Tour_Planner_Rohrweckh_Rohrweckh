using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;
using Tour_Planner.Models;
using Tour_Planner.Views;

namespace Tour_Planner.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public ICommand ExitCommand { get; }
        public ICommand AboutCommand { get; }
        public ICommand AddTourCommand { get; }
        public Action? Close { get; set; }
        public MainViewModel(SearchViewModel searchViewModel, TourViewModel tourViewModel, DetailsViewModel detailsViewModel, TourLogViewModel tourLogViewModel)
        {
            ExitCommand = new RelayCommand((_) =>
            {
                //?
            });

            AboutCommand = new RelayCommand((_) =>
            {
                var dlg = new AboutDialog();
                dlg.DataContext = new AboutViewModel();
                dlg.ShowDialog();
            });
            AddTourCommand = new RelayCommand((_) =>
            {
                var dlg = new AddTourDialog();
                dlg.DataContext = new AddTourViewModel(tourViewModel);
                dlg.ShowDialog();
            });

        }
    }
}
