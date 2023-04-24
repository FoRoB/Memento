using Memento.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Memento.Views
{
    /// <summary>
    /// Interaction logic for FlashcardsSetWindow.xaml
    /// </summary>
    public partial class FlashcardsSetWindow : Window, IClosable, IDraggable
    {
        public FlashcardsSetWindow()
        {
            InitializeComponent();
        }
    }
}
