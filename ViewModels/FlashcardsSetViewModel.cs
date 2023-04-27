using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Memento.ViewModels
{
    class FlashcardsSetViewModel : ObservableObject
    {
        public ICommand UpdateSources;

        private FlashcardsSet _Flashcards;
        public FlashcardsSet Flashcards
        {
            get => _Flashcards;
            set => SetProperty(ref _Flashcards, value);
        }

        private ICollection<Flashcard> _fl;

        public ICollection<Flashcard> FL
        {
            get { return _fl; }
            set => SetProperty(ref _fl, value);
        }


        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { SetProperty(ref myVar, value); }
        }


        public FlashcardsSetViewModel()
        {
            var fl = new ObservableCollection<Flashcard>()
                {
                    new Flashcard() {Question = "what", Answer = "yes", Rating = 1},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "what", Answer = "no", Rating = 5},
                    new Flashcard() {Question = "who", Answer = "me", Rating = 3}
                };
            FL = fl;
        }

        public FlashcardsSetViewModel(FlashcardsSet fs)
        {
            Flashcards = fs;
        }
    }
}
