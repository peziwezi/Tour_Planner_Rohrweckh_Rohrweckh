using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;
using Tour_Planner.Interfaces;

namespace Tour_Planner.ViewModels
{
    class MainViewModel : BaseViewModel, ICloseWindow
    {
        public ICommand ExitCommand { get; }
        public ICommand AboutCommand { get; }
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
            
        }
    }
}
