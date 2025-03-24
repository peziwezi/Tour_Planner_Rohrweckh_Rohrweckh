using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    class TourLogViewModel : BaseViewModel
    {
        public ObservableCollection<TourLog> Data { get; } = [];
    }
}
