using Memento.Infrastructure.Interfaces;
using System.Windows;

namespace Memento.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClosable, IMinimizable
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
