using CommunityToolkit.Mvvm.Input;
using Memento.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Memento.ViewModels
{
    class FlashcardsSetWindowViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand DragWindowCommand { get; set; }

        public FlashcardsSetWindowViewModel()
        {
            CloseWindowCommand = new RelayCommand<IClosable>(x => x?.Close());
            DragWindowCommand = new RelayCommand<IDraggable>(x => x?.DragMove());
        }
    }
}
