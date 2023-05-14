using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ICommand ToHomeViewCommand { get; set; }
        public ICommand ToFlashcardsViewCommand { get; set; }
        public ICommand ToExercisesViewCommand { get; set; }
        public ICommand ToSettingsViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public FlashcardsViewModel FlashcardsVM { get; set; }
        public ExercisesViewModel ExercisesVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

        private object _CurrentView;
        public object CurrentView
        {
            get => _CurrentView;
            set => SetProperty(ref _CurrentView, value);
        }

        public MainWindowViewModel()
        {

            HomeVM = new HomeViewModel();
            FlashcardsVM = new FlashcardsViewModel();
            ExercisesVM = new ExercisesViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentView = HomeVM;

            ToHomeViewCommand = new RelayCommand(() => NavigateTo(HomeVM));
            ToFlashcardsViewCommand = new RelayCommand(() => NavigateTo(FlashcardsVM));
            ToExercisesViewCommand = new RelayCommand(() => NavigateTo(ExercisesVM));
            ToSettingsViewCommand = new RelayCommand(() => NavigateTo(SettingsVM));
        }

        internal void NavigateTo(object toViewModel)
        {
            if(CurrentView is IDisposableViewModel currVM)
                currVM.Dispose();
            CurrentView = toViewModel;
        }
    }
}
