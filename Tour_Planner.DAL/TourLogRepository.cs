using Tour_Planner.Models;

namespace Tour_Planner.DAL
{
    public class TourLogRepository:ITourLogRepository
    {
        private readonly List<TourLog> _tourLogList = [];
        private int size;

        public TourLog Add(TourLog tourLog)
        {
            size++;
            tourLog.Id = size;
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

        public void RemoveListByTourID(int tourId)
        {
            List<TourLog> RemovalList = GetTourLogsByTourId(tourId).ToList();
            for(int i = 0; i < RemovalList.Count; i++)
            {
                _tourLogList.Remove(RemovalList[i]);
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
