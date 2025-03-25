using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Tour_Planner.BLL;
using Tour_Planner.Commands;
using Tour_Planner.Models;
using Tour_Planner.Views;

namespace Tour_Planner.ViewModels
{
    class TourLogViewModel : BaseViewModel
    {
        public event EventHandler<TourLog?>? SelectedTourLogChanged;
        public ObservableCollection<TourLog> Data { get; } = [];
        private readonly ITourLogManager tourLogManager;
        public Tour? SelectedTour;
        public ICommand? AddTourLogCommand { get; }
        public ICommand DeleteTourLogCommand { get; }
        private TourLog? selectedTourLog;
        public TourLog? SelectedTourLog
        {
            get => selectedTourLog;
            set
            {
                selectedTourLog = value;
                OnPropertyChanged();
                OnSelectedTourlogChanged();
            }
        }
        
        public void AddTourLog(TourLog tourLog)
        {
            TourLog? savedTourLog = tourLogManager.AddTourLog(tourLog);
            if (savedTourLog != null)
            {
                Data.Add(savedTourLog);
            }
        }

        public void ModifyTourLog(TourLog tourLog)
        {
            if(tourLog != null)
            {
                TourLog oldTourLog = (TourLog)Data.Where(x => x.Id == tourLog.Id);
                int index = Data.IndexOf(oldTourLog);
                Data[index] = tourLog;
            }
        }

        public void ClearTourlogs()
        {
            Data.Clear();
        }

        public void RemoveTourLog(TourLog tourLog)
        {
            Data.Remove(tourLog);
            tourLogManager.DeleteTourLog(tourLog);
        }

        public void GetSelectedTour(Tour tour)
        {
            if (tour != null)
            {
                Data.Clear();
                tourLogManager.FindMatchingTour(tour.Id).ToList().ForEach(j => Data.Add(j)); ;
                SelectedTour = tour;
            }
        }

        private void OnSelectedTourlogChanged()
        {
            SelectedTourLogChanged?.Invoke(this, SelectedTourLog);
        }
        public TourLogViewModel(ITourLogManager tourLogManager)
        {
            this.tourLogManager = tourLogManager;
            AddTourLogCommand = new RelayCommand((_) =>
            {
                if (SelectedTour != null)
                {
                    var dlg = new AddTourLogDialog();
                    dlg.DataContext = new AddTourLogViewModel(this);
                    dlg.ShowDialog();
                }
            }, (_) => SelectedTour != null);
            DeleteTourLogCommand = new RelayCommand((_) =>
            {
                if (SelectedTourLog == null)
                {
                    return;
                }
                RemoveTourLog(SelectedTourLog);
            }, (_) => SelectedTourLog != null);
        }
    }
}
