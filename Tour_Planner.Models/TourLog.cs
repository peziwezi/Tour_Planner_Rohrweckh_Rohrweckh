using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner.Models
{
    class TourLog
    {
        public string DateTime { get; set; }
        public string Comment { get; set; }
        public string Difficulty { get; set; }
        public double TotalDistance { get; set; }
        public double TotalTime { get; set; }
        public double Rating { get; set; }

        public TourLog(string datetime, string comment, string difficulty, double totaldistance, double totaltime, double rating)
        {
            DateTime = datetime;
            Comment = comment;
            Difficulty = difficulty;
            TotalDistance = totaldistance;
            TotalTime = totaltime;
            Rating = rating;
        }
    }
}
