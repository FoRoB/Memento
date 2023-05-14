using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Infrastructure;
using Memento.Infrastructure.Interfaces;
using Memento.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Memento.ViewModels
{
    internal class ExercisesViewModel : ObservableObject, IDisposableViewModel
    {
        public Stats Stats { get; set; }

        public ICommand Start2NBackCommand { get; set; }
        public ICommand Start3NBackCommand { get; set; }

        public ExercisesViewModel()
        {
            Start2NBackCommand = new RelayCommand(() => StartNBackExercise(2));
            Start3NBackCommand = new RelayCommand(() => StartNBackExercise(3));

            if (File.Exists("ExercisesStats.json"))
            {
                Stats = SerializeHelper.Deserialize<Stats>("ExercisesStats.json");
                Stats.AvailableCount = 2;
            }
            else
            {
                Stats = new Stats()
                {
                    AvailableCount = 2,
                    LastStarted = "не запускалось"
                };
            }
        }

        private void StartNBackExercise(int n)
        {
            RefreshStats($"{n}-n назад");
            var win = new Window()
            {
                Style = (Style)Application.Current.FindResource("CustomSubWindowStyle"),
                Content = new NBackExerciseViewModel(n)
            };
            win.ShowDialog();
        }

        public async Task<bool> DisposeAsync()
        {
            await SerializeHelper.SerializeAsync("ExercisesStats.json", Stats);
            return true;
        }

        public bool Dispose()
        {
            return DisposeAsync().Result;
        }

        private void RefreshStats(string name)
        {
            Stats.LastStarted = name;
        }
    }
}
