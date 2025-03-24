using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    class TourViewModel : BaseViewModel
    {
        public event EventHandler<Tour?>? SelectedItemChanged;
        public ObservableCollection<Tour> Data { get; } = [];

        private Tour? selectedItem;
        public Tour? SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                OnSelectedItemChanged();
            }
        }

        public void AddTourLog(Tour tour)
        {
            Data.Add(tour);
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
        }

        private void OnSelectedItemChanged()
        {
            SelectedItemChanged?.Invoke(this, SelectedItem);
        }
    }
}
