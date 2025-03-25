using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.BLL;
using Tour_Planner.DAL;
using Tour_Planner.Models;

namespace Tour_Planner.Tests
{
    public class BLL_Tests
    {

        TourRepository tourRepository { get; set; }
        TourManager manager { get; set; }
        TourLogRepository logRepository { get; set; }
        TourLogManager tourLogManager { get; set; }
        [SetUp]
        public void Setup()
        {
            tourRepository = new TourRepository();
            manager = new TourManager(tourRepository);
            logRepository = new TourLogRepository();
            tourLogManager = new TourLogManager(logRepository);
        }

        [Test]
        public void AddedTour_IsEqual_to_GivenTour()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            Tour? testTour2 = manager.AddTour(testTour1);
            testTour1.Id = 1;
            Assert.That(testTour2, Is.EqualTo(testTour1));
        }
        [Test]
        public void TourId_Is_Set_Correctly()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            manager.AddTour(testTour1);
            manager.AddTour(testTour1);
            manager.AddTour(testTour1);
            Tour? testTour2 = manager.AddTour(testTour1);
            int testwert;
            if (testTour2 != null)
            {
                testwert = testTour2.Id;
            }
            else
            {
                testwert = 0;
            }
            Assert.That(testwert, Is.EqualTo(4));
        }
        [Test]
        public void Tour_added_to_Repository()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            manager.AddTour(testTour1);
            testTour1.Id = 1;
            List<Tour> testList = manager.FindMatchingTours("Wien-Baden").ToList();
            Tour testTour2 = testList[0];
            Assert.That(testTour2, Is.EqualTo(testTour1));
        }
        [Test]
        public void Tour_deleted_from_Repository()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            manager.AddTour(testTour1);
            manager.DeleteTour(testTour1);
            List<Tour> testList = manager.FindMatchingTours("Wien-Baden").ToList();
            Assert.That(testList.Count, Is.EqualTo(0));
        }
        [Test]
        public void Tour_updated()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            Tour testTour2 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 29, "----");
            testTour2.Id = 1;
            manager.AddTour(testTour1);
            manager.UpdateTour(testTour2);
            List<Tour> testList = manager.FindMatchingTours("Wien-Baden").ToList();
            Assert.That(testList[0], Is.EqualTo(testTour2));
        }
        [Test]
        public void AddedTourLog_IsEqual_to_GivenTourLog()
        {
            TourLog testLog1 = new TourLog(1,"24-03-2025-1610", "langweilig", 2, 29, 24, 2);
            TourLog? testLog2 = tourLogManager.AddTourLog(testLog1);
            testLog1.Id = 1;
            Assert.That(testLog2, Is.EqualTo(testLog1));
        }
        [Test]
        public void LogId_Is_Set_Correctly()
        {

            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", 2, 29, 24, 2);
            tourLogManager.AddTourLog(testLog1);
            tourLogManager.AddTourLog(testLog1);
            tourLogManager.AddTourLog(testLog1);
            TourLog? testLog2 = tourLogManager.AddTourLog(testLog1);
            int testwert;
            if (testLog2 != null)
            {
                testwert = testLog2.Id;
            }
            else
            {
                testwert = 0;
            }
            Assert.That(testwert, Is.EqualTo(4));
        }
        [Test]
        public void TourLog_added_to_Repository()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", 2, 29, 24, 2);
            tourLogManager.AddTourLog(testLog1);
            testLog1.Id = 1;
            List<TourLog> testList = tourLogManager.FindMatchingTour(1).ToList();
            TourLog testLog2 = testList[0];
            Assert.That(testLog2, Is.EqualTo(testLog1));
        }
        [Test]
        public void TourLog_deleted_from_Repository()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", 2, 29, 24, 2);
            tourLogManager.AddTourLog(testLog1);
            tourLogManager.DeleteTourLog(testLog1);
            List<TourLog> testList = tourLogManager.FindMatchingTour(1).ToList();
            Assert.That(testList.Count, Is.EqualTo(0));
        }
        [Test]
        public void TourLog_updated()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", 2, 29, 24, 2);
            TourLog testLog2 = new TourLog(1, "24-03-2025-1610", "langweilig", 2, 29, 29, 2);
            testLog2.Id = 1;
            tourLogManager.AddTourLog(testLog1);
            tourLogManager.UpdateTourLog(testLog2);
            List<TourLog> testList = tourLogManager.FindMatchingTour(1).ToList();
            Assert.That(testList[0], Is.EqualTo(testLog2));
        }
        [Test]
        public void TourLog_set_to_correct_tour()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", 2, 29, 24, 2);
            TourLog testLog2 = new TourLog(1, "24-03-2025-1610", "langweilig", 2, 29, 29, 2);
            TourLog testLog3 = new TourLog(2, "24-03-2025-1610", "langweilig", 2, 29, 29, 2);
            testLog2.Id = 1;
            tourLogManager.AddTourLog(testLog1);
            tourLogManager.AddTourLog(testLog2);
            tourLogManager.AddTourLog(testLog3);
            List<TourLog> testList = tourLogManager.FindMatchingTour(2).ToList();
            Assert.That(testList[0], Is.EqualTo(testLog3));
        }
    }
}
