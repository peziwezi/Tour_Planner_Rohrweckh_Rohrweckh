using Tour_Planner.Models;

namespace Tour_Planner.DAL
{
    public class TourLogRepository:ITourLogRepository
    {
        private readonly List<TourLog> _tourLogList = [];

        public TourLog Add(TourLog tourLog)
        {
            tourLog.Id = _tourLogList.Count+1;
            _tourLogList.Add(tourLog);
            return tourLog;
        }

        public void Update(TourLog tourLog)
        {
            var foundTourLog = GetSingleTourLogById(tourLog.Id);
            if (foundTourLog != null)
            {
                _tourLogList.Remove(foundTourLog);
                _tourLogList.Add(tourLog);
            }
        }

        public void Remove(TourLog tourLog)
        {
            var foundTourLog = GetSingleTourLogById(tourLog.Id);
            if (foundTourLog != null)
            {
                _tourLogList.Remove(foundTourLog);
            }
        }
        public IEnumerable<TourLog> GetTourLogsByTourId(int tourId)
        {
            return _tourLogList
               .Where(p =>p.TourId == tourId)
               .ToList();
        }
        public TourLog? GetSingleTourLogById(int id)
        {
            return _tourLogList.SingleOrDefault(j => j.Id == id);
        }
    }
}
