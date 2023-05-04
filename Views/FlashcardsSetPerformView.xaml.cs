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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memento.Views
{
    /// <summary>
    /// Interaction logic for FlashcardsSetPerformView.xaml
    /// </summary>
    public partial class FlashcardsSetPerformView : UserControl
    {
        public FlashcardsSetPerformView()
        {
            InitializeComponent();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            AnswerTextBlock.Visibility = AnswerTextBlock.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            ShowButton.Content = ShowButton.Content.ToString() == FindResource("lang_ShowAnswer").ToString() ? FindResource("lang_HideAnswer") : FindResource("lang_ShowAnswer");
        }
    }
}
