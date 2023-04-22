using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Memento.Infrastructure.Interfaces;

namespace Memento.ViewModels
{
    class MainWindowViewModel : ObservableObject
    {
        public RelayCommand<IClosable> CloseWindowCommand { get; set; }
        public RelayCommand<IMinimizable> MinimizeWindowCommand { get; set; }

        public MainWindowViewModel()
        {
            CloseWindowCommand = new RelayCommand<IClosable>(x => x.Close());
            MinimizeWindowCommand = new RelayCommand<IMinimizable>(x => x.Minimize());
        }
    }
}
