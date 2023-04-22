using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Memento.Infrastructure.Interfaces
{
    interface IMinimizable
    {
        WindowState WindowState { get; set; }
        void Minimize() => WindowState = WindowState.Minimized;
    }
}
