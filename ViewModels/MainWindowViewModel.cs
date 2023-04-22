using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Infrastructure.Interfaces;

namespace Memento.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        public RelayCommand<IClosable> CloseWindowCommand { get; set; }
        public RelayCommand<IMinimizable> MinimizeWindowCommand { get; set; }
        public RelayCommand ToHomeViewCommand { get; set; }
        public RelayCommand ToFlashcardsViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public FlashcardsViewModel FlashcardsVM { get; set; }

        private object currentView;
        public object CurrentView
        {
            get => currentView;
            set => SetProperty(ref currentView, value);
        }

        public MainWindowViewModel()
        {
            CloseWindowCommand = new RelayCommand<IClosable>(x => x?.Close());
            MinimizeWindowCommand = new RelayCommand<IMinimizable>(x => x?.Minimize());

            HomeVM = new HomeViewModel();
            FlashcardsVM = new FlashcardsViewModel();
            CurrentView = HomeVM;

            ToHomeViewCommand = new RelayCommand(() => CurrentView = HomeVM);
            ToFlashcardsViewCommand = new RelayCommand(() => CurrentView = FlashcardsVM);
        }
    }
}
