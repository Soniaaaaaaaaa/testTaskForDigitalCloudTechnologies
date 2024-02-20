using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test202.Core;
using test202.Services;

namespace test202.MVVM.ViewModel
{
    public class HomeVM : Core.ViewModel
    {
        private INavigationService _navigationService;
        public INavigationService Navigation
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToDetailCommand { get; set; }

        public HomeVM(INavigationService navService)
        {
            Navigation = navService;
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeVM>(); }, o => true);
            NavigateToDetailCommand = new RelayCommand(o => { Navigation.NavigateTo<DetailVM>(); }, o => true);
        }
    }
}
