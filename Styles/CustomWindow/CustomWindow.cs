using System;
using System.Windows;
using System.Windows.Input;

namespace Memento.Styles.CustomWindow
{
    internal static class LocalExtensions
    {
        public static void ForWindowFromTemplate(this object templateFrameworkElement, Action<Window> action)
        {
            Window window = ((FrameworkElement)templateFrameworkElement).TemplatedParent as Window;
            if (window != null) action(window);
        }
    }

    public partial class CustomWindow
    {
        public void CloseButtonClick(object s, RoutedEventArgs e)
        {
            s.ForWindowFromTemplate(w => w.Close());
        }

        public void MinimizeButtonClick(object s, RoutedEventArgs e)
        {
            s.ForWindowFromTemplate(w => w.WindowState = WindowState.Minimized);
        }

        public void HeaderMouseLeftButtonDown(object s, MouseButtonEventArgs e)
        {
            s.ForWindowFromTemplate(w => w.DragMove());
        }
    }
}
