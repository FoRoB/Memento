using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private SolidColorBrush _RatingColor;
        public SolidColorBrush RatingColor
        {
            get => _RatingColor;
            set => SetProperty(ref _RatingColor, value);
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
            FcEnumerator = FcSet.GetSortedEnumerator();

            ChangeRatingTo1Command = new RelayCommand(() => ChangeRating(1), () => CanProceed);
            ChangeRatingTo2Command = new RelayCommand(() => ChangeRating(2), () => CanProceed);
            ChangeRatingTo3Command = new RelayCommand(() => ChangeRating(3), () => CanProceed);
            ChangeRatingTo4Command = new RelayCommand(() => ChangeRating(4), () => CanProceed);
            ChangeRatingTo5Command = new RelayCommand(() => ChangeRating(5), () => CanProceed);
            RestartCommand = new RelayCommand(() => Restart());

            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Rating")
                    RatingColor = ChangeRatingColor();
            };
            Initialize();
        }

        private void Initialize()
        {
            CanProceed = FcEnumerator.MoveNext();
            Question = FcEnumerator.Current.Question;
            Answer = FcEnumerator.Current.Answer;
            Rating = FcEnumerator.Current.Rating;
            OnPropertyChanged();
        }

        private void Restart()
        {
            FcEnumerator = FcSet.GetSortedEnumerator();
            RatingUp = 0;
            RatingDown = 0;
            Initialize();
        }

        private SolidColorBrush ChangeRatingColor()
        {
            if (Rating <= 0 || Rating > 5) return new SolidColorBrush(Colors.Transparent);
            return (SolidColorBrush)Application.Current.FindResource($"FlashcardRating{Rating}");
        }

        private void ChangeRating(int rating)
        {
            if (FcEnumerator.Current.Rating < rating)
                RatingUp++;
            if (FcEnumerator.Current.Rating > rating)
                RatingDown++;
            FcEnumerator.Current.Rating = rating;
            Initialize();
        }
    }
}
