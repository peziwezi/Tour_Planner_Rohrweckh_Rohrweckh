using Tour_Planner.Models;

namespace Tour_Planner.BLL
{
    public interface ITourManager
    {
        Tour? AddTour(Tour tour);
        void UpdateTour(Tour tour);
        void DeleteTour(Tour tour);

        IEnumerable<Tour> FindMatchingTours(string? searchText = null);
    }
}
