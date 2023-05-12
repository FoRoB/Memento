using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Infrastructure;
using Memento.Infrastructure.Interfaces;
using Memento.Models;
using Memento.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Memento.ViewModels
{
    class FlashcardsViewModel : ObservableObject, IDisposableViewModel
    {
        public ObservableCollection<FlashcardsSet> Flashcards { get; }

        public ICollectionView FilterView { get; }

        private string _Filter = string.Empty;
        public string Filter
        {
            get => _Filter;
            set => SetProperty(ref _Filter, value);
        }

        public ICommand AddFlashcardsSetCommand { get; set; }
        public ICommand DeleteFlashcardsSetCommand { get; set; }
        public ICommand SettingFlashcardsSetCommand { get; set; }
        public ICommand StartFlashcardsSetCommand { get; set; }


        public FlashcardsViewModel()
        {
            //for test purposes
            #region test data
            var fl = new FlashcardsSet()
            {
                Name = "Полководцы",
                Description = "Имена полководцев",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl1 = new FlashcardsSet()
            {
                Name = "Правда или ложь",
                Description = "Ответа только два",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "C# - язык низкого уровня", Answer = "ложь", Rating = 1},
                    new Flashcard() {Question = "Unity использует C#", Answer = "правда", Rating = 2},
                    new Flashcard() {Question = "Python наследует синтаксис семейства С", Answer = "ложь", Rating = 2},
                    new Flashcard() {Question = "В C# запрещено множественное наследование", Answer = "правда", Rating = 4}
                }
            };
            var fl2 = new FlashcardsSet()
            {
                Name = "Английские слова",
                Description = "Перевод на русский",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl3 = new FlashcardsSet()
            {
                Name = "Хирагана",
                Description = "Японский алфавит",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl4 = new FlashcardsSet()
            {
                Name = "Катакана",
                Description = "Японский алфавит",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl5 = new FlashcardsSet()
            {
                Name = "Праздники",
                Description = "Даты праздников",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl6 = new FlashcardsSet()
            {
                Name = "Таблица Менделеева",
                Description = "Номер - элемент",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl7 = new FlashcardsSet()
            {
                Name = "Test7",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl8 = new FlashcardsSet()
            {
                Name = "Test8",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            #endregion
            Flashcards = new ObservableCollection<FlashcardsSet>() { fl, fl1, fl2, fl3, fl4, fl5, fl6, fl7, fl8 };
            //Flashcards = SerializeHelper.Deserialize<ObservableCollection<FlashcardsSet>>("FlashcardsSets.json");

            FilterView = CollectionViewSource.GetDefaultView(Flashcards);
            FilterView.Filter = x =>
            {
                if (x is FlashcardsSet flSet)
                {
                    return flSet.Name.Contains(Filter) || flSet.Description.Contains(Filter);
                }
                return false;
            };

            AddFlashcardsSetCommand = new RelayCommand(() =>
            {
                var fcSet = new FlashcardsSet();
                var win = new Window()
                {
                    Style = (Style)Application.Current.FindResource("CustomSubWindowStyle"),
                    Content = new FlashcardsSetViewModel(fcSet)
                };
                win.ShowDialog();
                Flashcards.Add(fcSet);
            });

            DeleteFlashcardsSetCommand = new RelayCommand<FlashcardsSet>((x) =>
            {
                if (x == null) return;
                Flashcards.Remove(x);
            });

            SettingFlashcardsSetCommand = new RelayCommand<FlashcardsSet>((x) =>
            {
                if (x == null) return;
                var win = new Window()
                {
                    Style = (Style)Application.Current.FindResource("CustomSubWindowStyle"),
                    Content = new FlashcardsSetViewModel(x)
                };
                win.ShowDialog();
                FilterView.Refresh();
            });

            StartFlashcardsSetCommand = new RelayCommand<FlashcardsSet>((x) =>
            {
                if (x == null || x.Flashcards?.Count == 0) return;
                var win = new Window()
                {
                    Style = (Style)Application.Current.FindResource("CustomSubWindowStyle"),
                    Content = new FlashcardsSetPerformViewModel(x)
                };
                win.ShowDialog();
            });


            PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case "Filter":
                        FilterView.Refresh();
                        break;
                }
            };
        }

        public async Task<bool> DisposeAsync()
        {
            await SerializeHelper.SerializeAsync("FlashcardsSets.json", Flashcards);
            return true;
        }

        public bool Dispose()
        {
            return DisposeAsync().Result;
        }
    }
}
