using System.Collections.ObjectModel;
using Tour_Planner.BLL;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    class DetailsViewModel : BaseViewModel
    {
        public ObservableCollection<Tour> Data { get; set; } = [];
        public DetailsViewModel()
        {
        }
        public void GetDetails(Tour tour)
        {
            Data.Clear();
            Data.Add(tour);
        }
        public void ClearDetails()
        {
            Data.Clear();
        }
    }
}
