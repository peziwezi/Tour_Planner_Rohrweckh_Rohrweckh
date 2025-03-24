using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tour_Planner.Models;
using Tour_Planner.DAL;
using Tour_Planner.BLL;

namespace Tour_Planner.Tests
{
    public class DAL_Tests
    {
        TourRepository _tourRepository;
        TourLogRepository _tourLogRepository;
        [SetUp]
        public void Setup()
        {
            _tourRepository = new TourRepository();
            _tourLogRepository = new TourLogRepository();
        }

        [Test]
        public void AddedTour_IsEqual_to_GivenTour()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            Tour testTour2 = _tourRepository.Add(testTour1); 
            testTour1.Id = 1;
            Assert.That(testTour2, Is.EqualTo(testTour1));
        }
        [Test]
        public void Id_Is_Set_Correctly()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            _tourRepository.Add(testTour1);
            _tourRepository.Add(testTour1);
            _tourRepository.Add(testTour1);
            Tour testTour2 = _tourRepository.Add(testTour1);
            Assert.That(testTour2.Id, Is.EqualTo(4));
        }
        [Test]
        public void Tour_added_to_Repository()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            _tourRepository.Add(testTour1);
            testTour1.Id = 1;
            List<Tour> testList = _tourRepository.GetAllTours().ToList();
            Tour testTour2 = testList[0];
            Assert.That(testTour2, Is.EqualTo(testTour1));
        }
        [Test]
        public void Tour_searched_by_Name()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            _tourRepository.Add(testTour1);
            testTour1.Id = 1;
            List<Tour> testList = _tourRepository.GetToursByName("Wien-Baden").ToList();
            Tour testTour2 = testList[0];
            Assert.That(testTour2, Is.EqualTo(testTour1));
        }
        [Test]
        public void Tour_searched_by_Id()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            _tourRepository.Add(testTour1);
            testTour1.Id = 1;
            Tour? testTour2 = _tourRepository.GetSingleTourById(1);
            Assert.That(testTour2, Is.EqualTo(testTour1));
        }
        [Test]
        public void Tour_deleted_from_Repository()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            _tourRepository.Add(testTour1);
            _tourRepository.Remove(testTour1);
            List<Tour> testList = _tourRepository.GetAllTours().ToList();
            Assert.That(testList.Count, Is.EqualTo(0));
        }
        [Test]
        public void Tour_updated()
        {
            Tour testTour1 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 24, "----");
            Tour testTour2 = new Tour("Wien-Baden", "Tour von Wien nach Baden", "Wien", "Baden", "Zug", 29, 29, "----");
            testTour2.Id = 1;
            _tourRepository.Add(testTour1);
            _tourRepository.Update(testTour2);
            List<Tour> testList = _tourRepository.GetToursByName("Wien-Baden").ToList();
            Assert.That(testList[0], Is.EqualTo(testTour2));
        }
        [Test]
        public void AddedTourLog_IsEqual_to_GivenTourLog()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 24, 2);
            TourLog testLog2 = _tourLogRepository.Add(testLog1);
            testLog1.Id = 1;
            Assert.That(testLog2, Is.EqualTo(testLog1));
        }
        [Test]
        public void LogId_Is_Set_Correctly()
        {

            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 24, 2);
            _tourLogRepository.Add(testLog1);
            _tourLogRepository.Add(testLog1);
            _tourLogRepository.Add(testLog1);
            TourLog testLog2 = _tourLogRepository.Add(testLog1);
            Assert.That(testLog2.Id, Is.EqualTo(4));
        }
        [Test]
        public void TourLog_added_to_Repository()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 24, 2);
            _tourLogRepository.Add(testLog1);
            testLog1.Id = 1;
            TourLog? testLog2 = _tourLogRepository.GetSingleTourLogById(1);
            Assert.That(testLog2, Is.EqualTo(testLog1));
        }
        [Test]
        public void TourLog_deleted_from_Repository()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 24, 2);
            _tourLogRepository.Add(testLog1);
            _tourLogRepository.Remove(testLog1);
            List<TourLog> testList = _tourLogRepository.GetTourLogsByTourId(1).ToList();
            Assert.That(testList.Count, Is.EqualTo(0));
        }
        [Test]
        public void TourLog_updated()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 24, 2);
            TourLog testLog2 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 29, 2);
            testLog2.Id = 1;
            _tourLogRepository.Add(testLog1);
            _tourLogRepository.Update(testLog2);
            List<TourLog> testList = _tourLogRepository.GetTourLogsByTourId(1).ToList();
            Assert.That(testList[0], Is.EqualTo(testLog2));
        }
        [Test]
        public void TourLog_set_to_correct_tour()
        {
            TourLog testLog1 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 24, 2);
            TourLog testLog2 = new TourLog(1, "24-03-2025-1610", "langweilig", "leicht", 29, 29, 2);
            TourLog testLog3 = new TourLog(2, "24-03-2025-1610", "langweilig", "leicht", 29, 29, 2);
            testLog2.Id = 1;
            _tourLogRepository.Add(testLog1);
            _tourLogRepository.Add(testLog2);
            _tourLogRepository.Add(testLog3);
            List<TourLog> testList = _tourLogRepository.GetTourLogsByTourId(2).ToList();
            Assert.That(testList[0], Is.EqualTo(testLog3));
        }
    }
}
