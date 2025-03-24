using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Tour_Planner.Commands;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    class TourLogViewModel : BaseViewModel
    {
        public event EventHandler<TourLog?>? SelectedItemChanged;
        public ObservableCollection<TourLog> Data { get; } = [];

        private TourLog? selectedItem;
        public TourLog? SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
                OnSelectedItemChanged();
            }
        }
        
        public void AddTourLog(TourLog tourLog)
        {
            Data.Add(tourLog);
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

        private void OnSelectedItemChanged()
        {
            SelectedItemChanged?.Invoke(this, SelectedItem);
        }
    }
}
