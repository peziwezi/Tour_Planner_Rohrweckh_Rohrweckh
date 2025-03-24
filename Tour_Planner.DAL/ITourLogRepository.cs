using Tour_Planner.Models;

namespace Tour_Planner.DAL
{
    public interface ITourLogRepository
    {
        TourLog Add(TourLog tourLog);
        void Update(TourLog tourLog);
        void Remove(TourLog tourLog);

        IEnumerable<TourLog> GetTourLogsByTourId(int tourId);
        TourLog? GetSingleTourLogById(int id);
    }
}
