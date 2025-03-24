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
    class AboutViewModel : BaseViewModel, ICloseWindow
    {
        public ICommand CloseCommand { get; }
        public Action? Close { get; set; }

        public AboutViewModel()
        {
            CloseCommand = new RelayCommand((_) =>
            {
                Close?.Invoke();
            });
        }
    }
}
