using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.Commands;
using Tour_Planner.Interfaces;

namespace Tour_Planner.ViewModels
{
    public class AboutViewModel : BaseViewModel, ICloseWindow
    {
        public ICommand CloseCommand { get; }
        public Action? Close { get; set; }

        private string? aboutText = "This is a Tour Planner Programm by Daniel and Patrick Rohrweckh";
        public string? AboutText
        {
            get => aboutText;
        }
        public AboutViewModel()
        {
            CloseCommand = new RelayCommand((_) =>
            {
                Close?.Invoke();
            });
            
        }
    }
}
