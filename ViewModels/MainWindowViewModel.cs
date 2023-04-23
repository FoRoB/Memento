using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Infrastructure.Interfaces;

namespace Memento.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand DragWindowCommand { get; set; }
        public ICommand ToHomeViewCommand { get; set; }
        public ICommand ToFlashcardsViewCommand { get; set; }

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
            DragWindowCommand = new RelayCommand<IDraggable>(x => x?.DragMove());

            HomeVM = new HomeViewModel();
            FlashcardsVM = new FlashcardsViewModel();
            CurrentView = HomeVM;

            ToHomeViewCommand = new RelayCommand(() => CurrentView = HomeVM);
            ToFlashcardsViewCommand = new RelayCommand(() => CurrentView = FlashcardsVM);
        }
    }
}
