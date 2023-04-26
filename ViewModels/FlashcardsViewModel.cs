using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Memento.ViewModels
{
    class FlashcardsViewModel : ObservableObject
    {
        public ICollection<FlashcardsSet> Flashcards { get; }

        public ICollectionView FilterView { get; }

        private string _Filter = string.Empty;
        public string Filter
        {
            get => _Filter;
            set => SetProperty(ref _Filter, value);
        }

        public ICommand AddFlashcardsSet { get; set; }
        public ICommand DeleteFlashcardsSet { get; set; }


        public FlashcardsViewModel()
        {
            //for test purposes
            #region test data
            var fl = new FlashcardsSet()
            {
                Name = "Test",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl1 = new FlashcardsSet()
            {
                Name = "Test1",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl2 = new FlashcardsSet()
            {
                Name = "Test2",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl3 = new FlashcardsSet()
            {
                Name = "Test3",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl4 = new FlashcardsSet()
            {
                Name = "Test4",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl5 = new FlashcardsSet()
            {
                Name = "Test5",
                Description = "Test",
                Flashcards = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                }
            };
            var fl6 = new FlashcardsSet()
            {
                Name = "Test6",
                Description = "Test",
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


            FilterView = CollectionViewSource.GetDefaultView(Flashcards);
            FilterView.Filter = x =>
            {
                if (x is FlashcardsSet flSet)
                {
                    return flSet.Name.Contains(Filter) || flSet.Description.Contains(Filter);
                }
                return false;
            };

            DeleteFlashcardsSet = new RelayCommand<FlashcardsSet>((x) =>
            {
                if(x == null) return;
                Flashcards.Remove(x);
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
    }
}
