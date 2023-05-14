using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Memento.ViewModels
{
    internal class NBackExerciseViewModel : ObservableObject
    {
        public string ExerciseName { get; set; }

        private int _IncorrectAnswers;
        public int IncorrectAnswers
        {
            get => _IncorrectAnswers;
            set => SetProperty(ref _IncorrectAnswers, value);
        }

        private int _CorrectAnswers;
        public int CorrectAnswers
        {
            get => _CorrectAnswers;
            set => SetProperty(ref _CorrectAnswers, value);
        }

        private string _SequenceStart;
        public string SequenceStart
        {
            get => _SequenceStart;
            set => SetProperty(ref _SequenceStart, value);
        }

        private string sequence;

        private int sequenceCurrIndex;
        private char _SequenceCurr;
        public char SequenceCurr
        {
            get => _SequenceCurr;
            set => SetProperty(ref _SequenceCurr, value);
        }

        private bool CanProceed { get; set; }

        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }
        public ICommand RestartCommand { get; set; }

        public NBackExerciseViewModel(int n)
        {
            ExerciseName = $"{n}-n назад";
            CanProceed = true;
            Initialize(n);

            YesCommand = new RelayCommand(() =>
            {
                if (sequence[sequenceCurrIndex - n] == SequenceCurr)
                    CorrectAnswers++;
                else
                    IncorrectAnswers++;
                ToNextElement();
            }, () => CanProceed);
            NoCommand = new RelayCommand(() =>
            {
                if (sequence[sequenceCurrIndex - n] != SequenceCurr)
                    CorrectAnswers++;
                else
                    IncorrectAnswers++;
                ToNextElement();
            }, () => CanProceed);
            RestartCommand = new RelayCommand(() => Initialize(n));
        }

        private void Initialize(int n)
        {
            sequence = RandomString(12);
            SequenceStart = sequence.Substring(0, n);
            sequenceCurrIndex = n;
            SequenceCurr = sequence[sequenceCurrIndex];
            Restart();
        }

        private void Restart()
        {
            CorrectAnswers = 0;
            IncorrectAnswers = 0;
            CanProceed = true;
        }

        private void ToNextElement()
        {
            sequenceCurrIndex++;
            if (sequenceCurrIndex < sequence.Length)
                SequenceCurr = sequence[sequenceCurrIndex];
            else
                CanProceed = false;
        }

        private static string RandomString(int length)
        {
            Random rand = new Random();
            string charbase = "123456";
            return new string(Enumerable.Range(0, length)
                   .Select(_ => charbase[rand.Next(charbase.Length)])
                   .ToArray());
        }
    }
}
