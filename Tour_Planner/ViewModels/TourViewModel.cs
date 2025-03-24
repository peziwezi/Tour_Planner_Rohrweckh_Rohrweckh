using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.BLL;
using Tour_Planner.Commands;
using Tour_Planner.Models;
using Tour_Planner.Views;

namespace Tour_Planner.ViewModels
{
    class TourViewModel : BaseViewModel
    {
        private readonly ITourManager tourManager;
        public event EventHandler<Tour?>? SelectedTourChanged;
        public ObservableCollection<Tour> Data { get; } = [];

        public ICommand AddTourCommand { get; }
        public ICommand DeleteTourCommand { get; }
        private Tour? selectedTour;
        public Tour? SelectedTour
        {
            get => selectedTour;
            set
            {
                selectedTour = value;
                OnPropertyChanged();
                OnSelectedItemChanged();
            }
        }
        public void SetTours(IEnumerable<Tour> tours)
        {
            Data.Clear();
            tours.ToList().ForEach(j => Data.Add(j));
        }

        public void AddTour(Tour tour)
        {
            Tour? savedTour = tourManager.AddTour(tour);
            if(savedTour != null)
            {
                Data.Add(savedTour);
            }
        }

        public void ModifyTour(Tour tour)
        {
            if (tour != null)
            {
                Tour oldTour = (Tour)Data.Where(x => x.Id == tour.Id);
                int index = Data.IndexOf(oldTour);
                Data[index] = tour;
            }
        }

        public void RemoveTour(Tour tour)
        {
            Data.Remove(tour);
            tourManager.DeleteTour(tour);
        }

        private void OnSelectedItemChanged()
        {
            SelectedTourChanged?.Invoke(this, SelectedTour);
        }
        public TourViewModel(ITourManager tourManager)
        {
            this.tourManager = tourManager;
            AddTourCommand = new RelayCommand((_) =>
            {
                var dlg = new AddTourDialog();
                dlg.DataContext = new AddTourViewModel(this);
                dlg.ShowDialog();
            });
            DeleteTourCommand = new RelayCommand((_) =>
            {
                if (SelectedTour == null)
                {
                    return;
                }
                RemoveTour(SelectedTour);
            }, (_) => SelectedTour != null);
        }
    }
}
