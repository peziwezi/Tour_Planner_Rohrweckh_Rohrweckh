namespace Tour_Planner.Models
{
    public class Tour
    {
        public string Name { get; set; }
        public string TourDescription { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string TransportType { get; set; }
        public double TourDistance { get; set; }
        public double EstimatedTime { get; set; }
        public string RouteInformation { get; set; }

        public Tour(string name, string tourdescription, string origin, string destination, string transporttype, double tourdistance, double estimatedtime, string routeinformation)
        {
            Name = name;
            TourDescription = tourdescription;
            Origin = origin;
            Destination = destination;
            TransportType = transporttype;
            TourDistance = tourdistance;
            EstimatedTime = estimatedtime;
            RouteInformation = routeinformation;

        }
    }
}
