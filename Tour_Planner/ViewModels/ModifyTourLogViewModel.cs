using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;
using Tour_Planner.Interfaces;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    public class ModifyTourLogViewModel : BaseViewModel, ICloseWindow
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
        private double? difficulty;
        public double? Difficulty
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

        void SetValues(TourLog tourLog)
        {
            datetime = tourLog.DateTime;
            comment = tourLog.Comment;
            difficulty = tourLog.Difficulty;
            totaldistance = tourLog.TotalDistance;
            totaltime = tourLog.TotalTime;
            rating = tourLog.Rating;
        }

        public Action? Close { get; set; }

        public ModifyTourLogViewModel(TourLogViewModel tourlogViewModel,TourLog priorTourlog)
        {
            SetValues(priorTourlog);
            CloseCommand = new RelayCommand((_) =>
            {
                Close?.Invoke();
            });
            SaveCommand = new RelayCommand((_) =>
            {
                if (datetime != null && comment != null && difficulty != null && totaldistance != null && totaltime != null && rating != null)
                {
                    TourLog tourlog = new TourLog(priorTourlog.TourId, datetime, comment, (double)difficulty, (double)totaldistance, (double)totaltime, (double)rating);
                    tourlog.Id = priorTourlog.Id;
                    tourlogViewModel.ModifyTourLog(tourlog);
                    Close?.Invoke();
                }
            }, (_) => (datetime != null && comment != null && difficulty != null && totaldistance != null && totaltime != null && rating != null));

        }
    }
}
