using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tour_Planner.BLL;
using Tour_Planner.Commands;

namespace Tour_Planner.ViewModels
{
    internal class SearchViewModel : BaseViewModel
    {
        public event EventHandler<string?>? SearchTextChanged;

        public ICommand SearchCommand { get; }

        public ICommand ClearCommand { get; }

        private string? searchText;
        public string? SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }

        public SearchViewModel(ITourManager tourManager)
        {
            SearchCommand = new RelayCommand((_) =>
            {
                this.SearchTextChanged?.Invoke(this, SearchText);
            });

            ClearCommand = new RelayCommand((_) =>
            {
                SearchText = "";
                this.SearchTextChanged?.Invoke(this, SearchText);
            });
        }
    }
}
