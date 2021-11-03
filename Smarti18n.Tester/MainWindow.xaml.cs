using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using System.ComponentModel;

namespace Smarti18n.Tester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private User _SelectedUser;
        public User SelectedUser {

            get { return _SelectedUser; }
            set
            {
                if (_SelectedUser != value)
                {
                    _SelectedUser = value;
                    RaisePropertyChanged(nameof(SelectedUser));
                }
            }
        }
        public ObservableCollection<User> Users { get; set; }
        public ICollection<string> Langs { get; set; } = LangManager.AvailableCultures;
        public MainWindow()
        {
            InitializeComponent();

            Users = new ObservableCollection<User>()
            {
                new User()
            {
                Name = "Eric",
                LastName = "Avery",
                bio = "Jethro",
                foo = 5,
                bar = 4
            },
                new User()
            {
                Name = "Mothra",
                LastName = "Jax",
                bio = "Mioro",
                foo = 3,
                bar = -1
            },
                new User()
            {
                Name = "Gold",
                LastName = "Bax",
                bio = "Viia",
                foo = 0,
                bar = 89
            },
                new User()
            {
                Name = "Dial",
                LastName = "O'Bie",
                bio = "Poiio",
                foo = 25,
                bar = 15
            },
                new User()
            {
                Name = "Jenkins",
                LastName = "PostBurry",
                bio = "Philapopp",
                foo = 2,
                bar = 8
            }
        };
            SelectedUser = new User();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private void EvoqueBtb_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Evoqued");
        }

        private void ManageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReadBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LangField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lang = LangManager.AvailableCultures.Contains(LangField.Text) ? LangField.Text : "en";
            LangManager.Instance.CurrentCulture = new System.Globalization.CultureInfo(lang);
        }
    }
}
