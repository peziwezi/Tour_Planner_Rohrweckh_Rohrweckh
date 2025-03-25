using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;
using Tour_Planner.Interfaces;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    class ModifyTourViewModel : BaseViewModel, ICloseWindow
    {
        public ICommand CloseCommand { get; }
        public ICommand SaveCommand { get; }
        private string? name;
        public string? Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private string? tourdescription;
        public string? TourDescription
        {
            get => tourdescription;
            set
            {
                tourdescription = value;
                OnPropertyChanged();
            }
        }
        private string? origin;
        public string? Origin
        {
            get => origin;
            set
            {
                origin = value;
                OnPropertyChanged();
            }
        }
        private string? destination;
        public string? Destination
        {
            get => destination;
            set
            {
                destination = value;
                OnPropertyChanged();
            }
        }
        private string? transporttype;
        public string? TransportType
        {
            get => transporttype;
            set
            {
                transporttype = value;
                OnPropertyChanged();
            }
        }
        public Action? Close { get; set; }

        public ModifyTourViewModel(TourViewModel tourViewModel)
        {
            CloseCommand = new RelayCommand((_) =>
            {
                Close?.Invoke();
            });
            SaveCommand = new RelayCommand((_) =>
            {
                if (name != null && tourdescription != null && origin != null && destination != null && transporttype != null)
                {
                    Tour tour = new Tour(name, tourdescription, origin, destination, transporttype, 10, 10, "Image.png");
                    tourViewModel.ModifyTour(tour);
                    Close?.Invoke();
                }
            });

        }
    }
}
