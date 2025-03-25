using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Tour_Planner.BLL;
using Tour_Planner.Models;


namespace Tour_Planner.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {
        public ObservableCollection<Tour> Data { get; set; } = [];

        private ImageSource? imageSource;

        public ImageSource? ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        private readonly string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
        public DetailsViewModel()
        {
            SetImageSource("");
        }
        public void GetDetails(Tour tour)
        {
            Data.Clear();
            Data.Add(tour);
            SetImageSource(tour.RouteInformation);
        }
        public void ClearDetails()
        {
            Data.Clear();
            SetImageSource("");
        }
        private void SetImageSource(string? imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                ImageSource = null; // Standardbild
                return;
            }

            string fullPath = Path.Combine(imageFolder, imagePath);

            if (!File.Exists(fullPath))
            {
                ImageSource = null; // Falls Bild fehlt
                return;
            }

            ImageSource = LoadImage(imagePath);
        }

        private ImageSource? LoadImage(string fileName)
        {
            string fullPath = Path.Combine(imageFolder, fileName);
            return new BitmapImage(new Uri(fullPath, UriKind.Absolute));
        }
    }
}
