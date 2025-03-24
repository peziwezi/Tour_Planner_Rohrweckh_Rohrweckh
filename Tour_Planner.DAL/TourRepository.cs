using Tour_Planner.Models;

namespace Tour_Planner.DAL
{
    public class TourRepository : ITourRepository
    {
        private readonly List<Tour> _tourList = [];

        public Tour Add(Tour tour)
        {
            tour.Id = _tourList.Count + 1;
            _tourList.Add(tour);
            return tour;
        }

        public void Update(Tour tour)
        {
            var foundTour = GetSingleTourById(tour.Id);
            if (foundTour != null)
            {
                int index = _tourList.IndexOf(foundTour);
                _tourList[index] = tour;
            }
        }

        public void Remove(Tour tour)
        {
            var foundTour = GetSingleTourById(tour.Id);
            if (foundTour != null)
            {
                _tourList.Remove(foundTour);
            }
        }

        public IEnumerable<Tour> GetAllTours()
        {
            // return a copy
            return new List<Tour>(_tourList);
        }

        public IEnumerable<Tour> GetToursByName(string searchPattern)
        {
            return _tourList
                .Where(f => f.Name.Contains(searchPattern, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        public Tour? GetSingleTourById(int id)
        {
            return _tourList.SingleOrDefault(j => j.Id == id);
        }
    }
}
