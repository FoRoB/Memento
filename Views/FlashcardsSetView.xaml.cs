using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memento.Views
{
    /// <summary>
    /// Interaction logic for FlashcardsSetView.xaml
    /// </summary>
    public partial class FlashcardsSetView : UserControl
    {
        public FlashcardsSetView()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (ViewModels.FlashcardsSetViewModel)DataContext;
            vm.DoneCommand.Execute(null);
            Window.GetWindow(this).Close();
        }
    }
}
