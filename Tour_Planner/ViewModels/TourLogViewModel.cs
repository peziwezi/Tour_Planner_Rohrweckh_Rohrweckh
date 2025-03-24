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
        public event EventHandler<TourLog?>? SelectedItemChanged;
        public ObservableCollection<TourLog> Data { get; } = [];
        private readonly ITourLogManager tourLogManager;
        public ICommand AddTourLogCommand { get; }
        private TourLog? selectedTourlog;
        public TourLog? SelectedTourlog
        {
            get => selectedTourlog;
            set
            {
                selectedTourlog = value;
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

        public void RemoveTourLog(TourLog tourLog)
        {
            Data.Remove(tourLog);
        }

        private void OnSelectedTourlogChanged()
        {
            SelectedItemChanged?.Invoke(this, selectedTourlog);
        }
        public TourLogViewModel(ITourLogManager tourLogManager)
        {
            this.tourLogManager = tourLogManager;
            AddTourLogCommand = new RelayCommand((_) =>
            {
                var dlg = new AddTourLogDialog();
                dlg.DataContext = new AddTourLogViewModel(this);
                dlg.ShowDialog();
            });
        }
    }
}
