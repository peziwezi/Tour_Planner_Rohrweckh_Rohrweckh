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
    class TourViewModel : BaseViewModel
    {
        public event EventHandler<Tour?>? SelectedItemChanged;
        public ObservableCollection<Tour> Data { get; } = [];

        public ICommand AddTourCommand { get; }
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

        public void AddTour(Tour tour)
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
        public TourViewModel()
        {
            AddTourCommand = new RelayCommand((_) =>
            {
                var dlg = new AddTourDialog();
                dlg.DataContext = new AddTourViewModel(this);
                dlg.ShowDialog();
            });
        }
    }
}
