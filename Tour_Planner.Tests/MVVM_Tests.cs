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
        TourManager tourManager = new TourManager(new TourRepository());
        TourLogManager tourLogManager = new TourLogManager(new TourLogRepository());
        SearchViewModel searchViewModel;
        TourViewModel tourViewModel;
        MainViewModel mainViewModel;
        DetailsViewModel detailsViewModel;
        TourLogViewModel tourLogViewModel;
        [SetUp]
        public void Setup()
        {
            searchViewModel = new SearchViewModel();
            tourViewModel = new TourViewModel(tourManager, tourLogManager);
            searchViewModel = new SearchViewModel();
            detailsViewModel = new DetailsViewModel();
            tourLogViewModel = new TourLogViewModel(tourLogManager);
            mainViewModel = new MainViewModel(tourManager, tourLogManager, searchViewModel, tourViewModel, detailsViewModel, tourLogViewModel);
        }

        [Test]
        public void Testing_Add_Command()
        {
            Tour test = new Tour("Test", "Test", "Test1", "Test2", "Tester", 1, 1, "");
            TourLog testLog = new TourLog(1, "Test", "Test", "Test1", 1, 1, 1);
            tourViewModel.AddTour(test);
            tourLogViewModel.AddTourLog(testLog);
            int testInt1 = tourManager.FindMatchingTours("Test").Count();
            int testInt2 = tourLogManager.FindMatchingTour(1).Count();
            Assert.That(testInt1, Is.EqualTo(1));
            Assert.That(testInt2, Is.EqualTo(1));
        }
        [Test]
        public void Testing_Delete_Command()
        {
            Tour test1 = new Tour("Test", "Test", "Test1", "Test2", "Tester", 1, 1, "");
            TourLog testLog1 = new TourLog(1, "Test", "Test", "Test1", 1, 1, 1);
        
            tourViewModel.AddTour(test1);
            tourLogViewModel.AddTourLog(testLog1);
            test1.Id = 1;
            testLog1.Id = 1;
            tourViewModel.RemoveTour(test1);
            tourLogViewModel.RemoveTourLog(testLog1);
            int testInt1 = tourManager.FindMatchingTours("Test").Count();
            int testInt2 = tourLogManager.FindMatchingTour(1).Count();
            Assert.That(testInt1, Is.EqualTo(0));
            Assert.That(testInt2, Is.EqualTo(0));
        }
        [Test]
        public void Testing_Modify_Command()
        {
            Tour test1 = new Tour("Test1", "Test1", "Test1", "Test2", "Tester", 1, 1, "");
            TourLog testLog1 = new TourLog(1, "Test", "Test", "Test1", 1, 1, 1);
            tourViewModel.AddTour(test1);
            tourLogViewModel.AddTourLog(testLog1);
            Tour test2 = new Tour("Test2", "Test2", "Test1", "Test2", "Tester", 1, 1, "");
            TourLog testLog2 = new TourLog(2, "Test", "Test", "Test1", 1, 1, 1);
            test2.Id = 1;
            testLog2.Id = 1;
            tourViewModel.ModifyTour(test2);
            tourLogViewModel.ModifyTourLog(testLog2);
            int testInt1 = tourManager.FindMatchingTours("Test2").Count();
            int testInt2 = tourLogManager.FindMatchingTour(2).Count();
            Assert.That(testInt1, Is.EqualTo(1));
            Assert.That(testInt2, Is.EqualTo(1));
        }
        [Test]
        public void Test_End_Command()
        {
            bool vaild = mainViewModel.ExitCommand.CanExecute(null);
            Assert.That(vaild, Is.True);
        }
    }
}