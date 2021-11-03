using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace Smarti18n.Tester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LangManager.Instance.CultureChanged += App_CultureChanged;
            LangManager.Instance.CurrentCulture = new CultureInfo("fr");

            //Smarti18n.Utilities.GenerateTranslationFolder<User>(new string[] { "en", "fr", "tu", "Zn-Ch", "po", "ru" }, LangDir: "SupLang");
        }

        private void App_CultureChanged(CultureInfo obj)
        {
            //MessageBox.Show("App Culture changed");
        }
    }
}
