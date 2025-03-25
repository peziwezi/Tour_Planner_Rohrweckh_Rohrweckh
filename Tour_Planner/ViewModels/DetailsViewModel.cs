using System.Collections.ObjectModel;
using Tour_Planner.BLL;
using Tour_Planner.Models;

namespace Tour_Planner.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public ObservableCollection<Tour> Data { get; set; } = [];
        public string DisplayedImagePath
        {
            get 
            { 
                if(Data.Count != 0)
                {
                    return "pack://application:,,,/Tour_Planer;component/Images/" + Data[0].RouteInformation;
                }
                else
                {
                    return "";
                }
            }
        }
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
