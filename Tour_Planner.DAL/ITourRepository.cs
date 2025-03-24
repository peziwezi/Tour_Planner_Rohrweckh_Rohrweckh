using Tour_Planner.Models;

namespace Tour_Planner.DAL
{
    public interface ITourRepository
    {
        Tour Add(Tour tour);
        void Update(Tour tour);
        void Remove(Tour tour);

        IEnumerable<Tour> GetAllTours();
        IEnumerable<Tour> GetToursByName(string searchPattern);
        Tour? GetSingleTourById(int id);
    }
}
