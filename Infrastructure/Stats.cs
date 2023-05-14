using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Infrastructure
{
    internal class Stats : ObservableObject
    {
        private string _LastStarted = string.Empty;
        public string LastStarted
        {
            get => _LastStarted;
            set => SetProperty(ref _LastStarted, value);
        }

        private int _AvailableCount;
        public int AvailableCount
        {
            get => _AvailableCount;
            set => SetProperty(ref _AvailableCount, value);
        }
    }
}
