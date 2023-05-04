using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Memento.ViewModels
{
    internal class FlashcardsSetPerformViewModel : ObservableObject
    {
        private bool CanProceed { get; set; }

        private string _Question;
        public string Question
        {
            get => _Question;
            set => SetProperty(ref _Question, value);
        }

        private string _Answer;
        public string Answer
        {
            get => _Answer;
            set => SetProperty(ref _Answer, value);
        }

        private int _Rating;
        public int Rating
        {
            get => _Rating;
            set => SetProperty(ref _Rating, value);
        }

        private int _RatingUp;
        public int RatingUp
        {
            get => _RatingUp;
            set => SetProperty(ref _RatingUp, value);
        }

        private int _RatingDown;
        public int RatingDown
        {
            get => _RatingDown;
            set => SetProperty(ref _RatingDown, value);
        }

        private FlashcardsSet _FcSet;
        public FlashcardsSet FcSet
        {
            get => _FcSet;
            set => SetProperty(ref _FcSet, value);
        }

        private IEnumerator<Flashcard> FcEnumerator { get; set; }

        public ICommand ChangeRatingTo1Command { get; set; }
        public ICommand ChangeRatingTo2Command { get; set; }
        public ICommand ChangeRatingTo3Command { get; set; }
        public ICommand ChangeRatingTo4Command { get; set; }
        public ICommand ChangeRatingTo5Command { get; set; }
        public ICommand RestartCommand { get; set; }

        public FlashcardsSetPerformViewModel(FlashcardsSet flashcardsSet)
        {
            FcSet = flashcardsSet;
            Initialize();

            ChangeRatingTo1Command = new RelayCommand(() => ChangeRating(1), () => CanProceed);
            ChangeRatingTo2Command = new RelayCommand(() => ChangeRating(2), () => CanProceed);
            ChangeRatingTo3Command = new RelayCommand(() => ChangeRating(3), () => CanProceed);
            ChangeRatingTo4Command = new RelayCommand(() => ChangeRating(4), () => CanProceed);
            ChangeRatingTo5Command = new RelayCommand(() => ChangeRating(5), () => CanProceed);
            RestartCommand = new RelayCommand(() => Initialize());
        }

        private void Initialize()
        {
            FcEnumerator = FcSet.GetSortedEnumerator();
            CanProceed = FcEnumerator.MoveNext();
            Question = FcEnumerator.Current.Question;
            Answer = FcEnumerator.Current.Answer;
            Rating = FcEnumerator.Current.Rating;
            RatingUp = 0;
            RatingDown = 0;
        }

        private void ChangeRating(int rating)
        {
            if (FcEnumerator.Current.Rating < rating)
                RatingUp++;
            if (FcEnumerator.Current.Rating > rating)
                RatingDown++;
            FcEnumerator.Current.Rating = rating;
            CanProceed = FcEnumerator.MoveNext();
            Question = FcEnumerator.Current.Question;
            Answer = FcEnumerator.Current.Answer;
            Rating = FcEnumerator.Current.Rating;
            OnPropertyChanged();
        }
    }
}
