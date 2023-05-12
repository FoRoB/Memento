using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Memento.ViewModels
{
    internal class SettingsViewModel : ObservableObject
    {
        public ICommand ChangeLanguageToRussian { get; set; }
        public ICommand ChangeLanguageToEnglish { get; set; }

        public SettingsViewModel()
        {
            //ChangeLanguageToRussian = new RelayCommand(() =>
            //{
            //    App.Language = new System.Globalization.CultureInfo("ru-RU");
            //});
            //ChangeLanguageToEnglish = new RelayCommand(() =>
            //{
            //    App.Language = new System.Globalization.CultureInfo("en-US");
            //});
        }
    }
}
