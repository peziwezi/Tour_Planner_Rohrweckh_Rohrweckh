using Tour_Planner.DAL;
using Tour_Planner.Models;

namespace Tour_Planner.BLL
{
    public class TourManager : ITourManager
    {
        private readonly ITourRepository _repository;

        public TourManager(ITourRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Tour> FindMatchingTours(string? searchText = null)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return _repository.GetAllTours();
            }
            return _repository.GetAllToursByText(searchText);
        }

        public Tour? AddTour(Tour tour)
        {
            if (tour != null)
            {
                _repository.Add(tour);
            }
            return tour;
        }

        public void UpdateTour(Tour tour)
        {
            if (tour != null)
            {
                _repository.Update(tour);
            }
        }
        public void DeleteTour(Tour tour)
        {
            _repository.Remove(tour);
        }
    }
}
