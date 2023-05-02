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
using System.Windows.Data;
using System.Windows.Input;

namespace Memento.ViewModels
{
    class FlashcardsSetViewModel : ObservableObject
    {
        public ICommand ResetNameCommand { get; set; }
        public ICommand ResetDescriptionCommand { get; set; }
        public ICommand ResetFlashcardsCommand { get; set; }
        public ICommand DoneCommand { get; set; }

        public FlashcardsSet OriginalFcSet { get; }

        private string _Name = string.Empty;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        private string _Description;
        public string Description
        {
            get => _Description;
            set => SetProperty(ref _Description, value);
        }

        public ICollection<Flashcard> Flashcards { get; set; }

        public ICollectionView FlashcardsView { get; }

        private string _Search = string.Empty;
        public string Search
        {
            get => _Search;
            set => SetProperty(ref _Search, value);
        }



        public FlashcardsSetViewModel()
        {

        }

        public FlashcardsSetViewModel(FlashcardsSet fs)
        {
            OriginalFcSet = fs;

            Name = OriginalFcSet.Name;
            Description = OriginalFcSet.Description;
            Flashcards = OriginalFcSet.CopyFlashcardsTo(new ObservableCollection<Flashcard>());

            ResetNameCommand = new RelayCommand(() => Name = OriginalFcSet.Name);
            ResetDescriptionCommand = new RelayCommand(() => Description = OriginalFcSet.Description);
            ResetFlashcardsCommand = new RelayCommand(() => Flashcards = OriginalFcSet.CopyFlashcardsTo(new ObservableCollection<Flashcard>()));
            DoneCommand = new RelayCommand(() =>
            {
                OriginalFcSet.Name = Name;
                OriginalFcSet.Description = Description;
                OriginalFcSet.Flashcards = Flashcards;
            });

            FlashcardsView = CollectionViewSource.GetDefaultView(Flashcards);
            FlashcardsView.Filter = x =>
            {
                if (x is Flashcard fc)
                {
                    return fc.Question.Contains(Search) || fc.Answer.Contains(Search);
                }
                return false;
            };

            PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case "Search":
                        FlashcardsView.Refresh();
                        break;
                }
            };
        }
    }
}
