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
        private readonly ITourLogManager tourLogManager;
        private readonly TourViewModel tourViewModel;

        public ICommand ExitCommand { get; }
        public ICommand AboutCommand { get; }
        public ICommand AddTourCommand { get; }
        public ICommand AddTourLogCommand { get; }

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

        public MainViewModel(ITourManager tourManager, ITourLogManager tourLogManager, SearchViewModel searchViewModel, TourViewModel tourViewModel, DetailsViewModel detailsViewModel, TourLogViewModel tourLogViewModel)
        {
            this.tourManager = tourManager;
            this.tourLogManager = tourLogManager;
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
                var dlg = new AddTourLogDialog();
                dlg.DataContext = new AddTourLogViewModel(tourLogViewModel);
                dlg.ShowDialog();
            });
            searchViewModel.SearchTextChanged += (_, searchText) =>
            {
                SearchTours(searchText);
            };

            tourViewModel.SelectedTourChanged += (_, tour) =>
            {
                SelectedTour = tour;
                detailsViewModel.GetDetails(tour);
            };

        }
        private void SearchTours(string? searchText)
        {
            var facts = tourManager.FindMatchingTours(searchText);
            tourViewModel.SetTours(facts);
        }
    }
}
