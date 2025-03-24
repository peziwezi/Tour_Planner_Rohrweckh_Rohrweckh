using Tour_Planner.DAL;
using Tour_Planner.Models;

namespace Tour_Planner.BLL
{
    public class TourLogManager : ITourLogManager
    {
        private readonly ITourLogRepository _repository;

        public TourLogManager(ITourLogRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TourLog> FindMatchingTour(int tourId)
        {
            return _repository.GetTourLogsByTourId(tourId);
        }

        public TourLog? AddTourLog(TourLog tourLog)
        {
            if (tourLog != null)
            {
                _repository.Add(tourLog);
            }
            return tourLog;
        }

        public void UpdateTourLog(TourLog tourLog)
        {
            if (tourLog != null)
            {
                _repository.Update(tourLog);
            }
        }
        public void DeleteTourLog(TourLog tourLog)
        {
            _repository.Remove(tourLog);
        }
    }
}
