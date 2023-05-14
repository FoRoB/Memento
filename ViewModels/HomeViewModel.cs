using CommunityToolkit.Mvvm.ComponentModel;
using Memento.Infrastructure;
using Memento.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.ViewModels
{
    class HomeViewModel : ObservableObject
    {
        private Stats _StatsFlashcards;
        public Stats StatsFlashcards
        {
            get => _StatsFlashcards;
            set => SetProperty(ref _StatsFlashcards, value);
        }

        private Stats _StatsExercises;
        public Stats StatsExercises
        {
            get => _StatsExercises;
            set => SetProperty(ref _StatsExercises, value);
        }

        public HomeViewModel()
        {
            StatsFlashcards = GetStats("FlashcardsStats.json");
            StatsExercises = GetStats("ExercisesStats.json");
        }

        private Stats GetStats(string path)
        {
            if (File.Exists(path))
                return SerializeHelper.Deserialize<Stats>(path);
            else return new Stats()
            {
                AvailableCount = 0,
                LastStarted = "не запускалось"
            };
        }
    }
}
