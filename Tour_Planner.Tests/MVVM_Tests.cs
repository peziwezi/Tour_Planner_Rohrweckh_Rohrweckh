using Tour_Planner.ViewModels;
using Tour_Planner.BLL;
using Tour_Planner.DAL;
using Tour_Planner.Models;
using System.Net;
using NUnit.Framework.Internal;

namespace Tour_Planner.Tests
{
    public class MVVM_Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Testing_Add_Tour()
        {
            TourManager tourManager = new TourManager(new TourRepository());
            TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
            TourViewModel tourViewModel = new TourViewModel(tourManager, tourLogManager);
            Tour test = new Tour("Test", "Test", "Test1", "Test2", "Tester", 1, 1, "");
            tourViewModel.AddTour(test);
            int testInt = tourManager.FindMatchingTours("Test").Count();
            Assert.That(testInt, Is.EqualTo(1));
        }
        [Test]
        public void Testing_Delete_Tour()
        {
            TourManager tourManager = new TourManager(new TourRepository());
            TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
            TourViewModel tourViewModel = new TourViewModel(tourManager, tourLogManager);
            Tour test = new Tour("Test", "Test", "Test1", "Test2", "Tester", 1, 1, "");
            tourViewModel.AddTour(test);
            test.Id = 1;
            tourViewModel.RemoveTour(test);
            int testInt = tourManager.FindMatchingTours("Test").Count();
            Assert.That(testInt, Is.EqualTo(0));
        }
        [Test]
        public void Testing_Modify_Tour()
        {
            TourManager tourManager = new TourManager(new TourRepository());
            TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
            TourViewModel tourViewModel = new TourViewModel(tourManager, tourLogManager);
            Tour test1 = new Tour("Test1", "Test1", "Test1", "Test2", "Tester", 1, 1, "");
            tourViewModel.AddTour(test1);
            Tour test2 = new Tour("Test2", "Test2", "Test1", "Test2", "Tester", 1, 1, "");
            test2.Id = 1;
            tourViewModel.ModifyTour(test2);
            int testInt = tourManager.FindMatchingTours("Test2").Count();
            Assert.That(testInt, Is.EqualTo(1));
        }
        [Test]
        public void Testing_Add_TourLog()
        {
            TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
            TourLogViewModel tourLogViewModel = new TourLogViewModel(tourLogManager);
            TourLog testLog = new TourLog(1, "Test", "Test", "Test1", 1, 1, 1);
            tourLogViewModel.AddTourLog(testLog);
            int testInt = tourLogManager.FindMatchingTour(1).Count();
            Assert.That(testInt, Is.EqualTo(1));
        }
        [Test]
        public void Testing_Delete_TourLog()
        {
            TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
            TourLogViewModel tourLogViewModel = new TourLogViewModel(tourLogManager);
            TourLog testLog = new TourLog(1, "Test", "Test", "Test1", 1, 1, 1);
            tourLogViewModel.AddTourLog(testLog);
            testLog.Id = 1;
            tourLogViewModel.RemoveTourLog(testLog);
            int testInt = tourLogManager.FindMatchingTour(1).Count();
            Assert.That(testInt, Is.EqualTo(0));
        }
        [Test]
        public void Testing_Modify_TourLog()
        {
            TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
            TourLogViewModel tourLogViewModel = new TourLogViewModel(tourLogManager);
            TourLog testLog1 = new TourLog(1, "Test", "Test", "Test1", 1, 1, 1);
            tourLogViewModel.AddTourLog(testLog1);
            TourLog testLog2 = new TourLog(2, "Test", "Test", "Test1", 1, 1, 1);
            testLog2.Id = 1;
            tourLogViewModel.ModifyTourLog(testLog2);
            int testInt = tourLogManager.FindMatchingTour(2).Count();
            Assert.That(testInt, Is.EqualTo(1));
        }
        [Test]
        public void Test_End_Command()
        {
            TourManager tourManager = new TourManager(new TourRepository());
            TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
            TourViewModel tourViewModel = new TourViewModel(tourManager, tourLogManager);
            SearchViewModel searchViewModel = new SearchViewModel();
            DetailsViewModel detailsViewModel = new DetailsViewModel();
            TourLogViewModel tourLogViewModel = new TourLogViewModel(tourLogManager);
            MainViewModel mainViewModel = new MainViewModel(tourManager, tourLogManager, searchViewModel, tourViewModel, detailsViewModel, tourLogViewModel);
            bool vaild = mainViewModel.ExitCommand.CanExecute(null);
            Assert.That(vaild, Is.True);
        }
    }
}