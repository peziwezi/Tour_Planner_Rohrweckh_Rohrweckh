using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;
using Tour_Planner.BLL;
using Tour_Planner.Views;
using Tour_Planner.Models;
using Tour_Planner.Interfaces;

namespace Tour_Planner.ViewModels
{
    class MainViewModel : BaseViewModel, ICloseWindow
    {
        private readonly ITourManager tourManager;
        private readonly TourViewModel tourViewModel;

        public ICommand ExitCommand { get; }
        public ICommand AboutCommand { get; }
        public ICommand AddTourCommand { get; }
        public ICommand? AddTourLogCommand { get; }
        public ICommand DeleteTourCommand { get; }
        public ICommand DeleteTourLogCommand { get; }
        public ICommand ModifyTourCommand { get; }
        public ICommand ModifyTourLogCommand { get; }

        public Action? Close { get; set; }
       
        private Tour? selectedTour;
        public Tour? SelectedTour
        {
            get => selectedTour;
            set
            {
                selectedTour = value;
                OnPropertyChanged();
            }
        }
 
        private TourLog? selectedTourLog;
        public TourLog? SelectedTourLog
        {
            get => selectedTourLog;
            set
            {
                selectedTourLog = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(ITourManager tourManager, ITourLogManager tourLogManager, SearchViewModel searchViewModel, TourViewModel tourViewModel, DetailsViewModel detailsViewModel, TourLogViewModel tourLogViewModel)
        {
            this.tourManager = tourManager;
            this.tourViewModel = tourViewModel;
            SearchTours(null);

            ExitCommand = new RelayCommand((_) =>
            {
                //?
                Close?.Invoke();
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
            AddTourLogCommand = new RelayCommand((_) =>
            {
                if (tourLogViewModel.SelectedTour != null)
                {
                    var dlg = new AddTourLogDialog();
                    dlg.DataContext = new AddTourLogViewModel(tourLogViewModel);
                    dlg.ShowDialog();
                }
            }, (_) => SelectedTour != null);
            ModifyTourCommand = new RelayCommand((_) =>
            {
                if (SelectedTour == null)
                {
                    return;
                }
                var dlg = new ModifyTourDialog();
                dlg.DataContext = new ModifyTourViewModel(tourViewModel, SelectedTour);
                dlg.ShowDialog();
            }, (_) => SelectedTour != null);
            ModifyTourLogCommand = new RelayCommand((_) =>
            {
                if (SelectedTourLog == null)
                {
                    return;
                }
                var dlg = new ModifyTourLogDialog();
                dlg.DataContext = new ModifyTourLogViewModel(tourLogViewModel, SelectedTourLog);
                dlg.ShowDialog();
            }, (_) => SelectedTourLog != null);
            DeleteTourCommand = new RelayCommand((_) =>
            {
                if (SelectedTour == null)
                {
                    return;
                }
                tourViewModel.RemoveTour(SelectedTour);
            }, (_) => SelectedTour != null);
            DeleteTourLogCommand = new RelayCommand((_) =>
            {
                if (SelectedTourLog == null)
                {
                    return;
                }
                tourLogViewModel.RemoveTourLog(SelectedTourLog);
            }, (_) => SelectedTourLog != null);
            searchViewModel.SearchTextChanged += (_, searchText) =>
            {
                SearchTours(searchText);
            };
            tourViewModel.SelectedTourChanged += (_, tour) =>
            {
                if (tour != null)
                {
                    SelectedTour = tour;
                    detailsViewModel.GetDetails(tour);
                    
                    tourLogViewModel.GetSelectedTour(tour);
                }
                else
                {
                    detailsViewModel.ClearDetails();
                    tourLogViewModel.ClearTourlogs();
                    tourLogViewModel.SelectedTour = null;
                }
            };
            tourLogViewModel.SelectedTourLogChanged += (_, tourLog) =>
            {
                if (tourLog != null)
                {
                    SelectedTourLog = tourLog;
                }
            };
        }
        private void SearchTours(string? searchText)
        {
            var facts = tourManager.FindMatchingTours(searchText);
            tourViewModel.SetTours(facts);
        }
    }
}
