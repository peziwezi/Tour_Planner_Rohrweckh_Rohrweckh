using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tour_Planner.BLL;
using Tour_Planner.Commands;
using Tour_Planner.Interfaces;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    public class AddTourLogViewModel : BaseViewModel, ICloseWindow
    {
        public ICommand CloseCommand { get; }
        public ICommand SaveCommand { get; }
        private string? datetime;
        public string? DateTime
        {
            get => datetime;
            set
            {
                datetime = value;
                OnPropertyChanged();
            }
        }
        private string? comment;
        public string? Comment
        {
            get => comment;
            set
            {
                comment = value;
                OnPropertyChanged();
            }
        }
        private string? difficulty;
        public string? Difficulty
        {
            get => difficulty;
            set
            {
                difficulty = value;
                OnPropertyChanged();
            }
        }
        private double? totaldistance;
        public double? TotalDistance
        {
            get => totaldistance;
            set
            {
                totaldistance = value;
                OnPropertyChanged();
            }
        }
        private double? totaltime;
        public double? TotalTime
        {
            get => totaltime;
            set
            {
                totaltime = value;
                OnPropertyChanged();
            }
        }
        private double? rating;
        public double? Rating
        {
            get => rating;
            set
            {
                rating = value;
                OnPropertyChanged();
            }
        }
        public Action? Close { get; set; }

        public AddTourLogViewModel(TourLogViewModel tourLogViewModel)
        {

            CloseCommand = new RelayCommand((_) =>
            {
                Close?.Invoke();
            });
            SaveCommand = new RelayCommand((_) =>
            {
                if (tourLogViewModel != null && tourLogViewModel.SelectedTour != null)
                {
                    int tourId = tourLogViewModel.SelectedTour.Id;

                    if (datetime != null && comment != null && difficulty != null && totaldistance != null && totaltime != null && rating != null)
                    {
                        TourLog tourlog = new TourLog(tourId, datetime, comment, difficulty, (double)totaldistance, (double)totaltime, (double)rating);
                        tourLogViewModel.AddTourLog(tourlog);
                        Close?.Invoke();
                    }
                }
            }, (_) => (datetime != null && comment != null && difficulty != null && totaldistance != null && totaltime != null && rating != null));

        }
    }
}
