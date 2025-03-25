using Tour_Planner.Models;

namespace Tour_Planner.BLL
{
    public interface ITourLogManager
    {
        TourLog? AddTourLog(TourLog tourLog);
        void UpdateTourLog(TourLog tourLog);
        void DeleteTourLog(TourLog tourLog);
        void DeleteConnectedTourlogs(int tourId);

        IEnumerable<TourLog> FindMatchingTour(int tourId);
    }
}
