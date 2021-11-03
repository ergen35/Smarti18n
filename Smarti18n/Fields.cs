using System.ComponentModel;

namespace Smarti18n
{
    public class Fields : INotifyPropertyChanged
    {

        private string _home;
        private string _help;
        private string _about;
        private string _view;


        //Properties
        [Transalatable]
        public string Home
        {
            get { return _home; }
            set
            {
                if (_home != value)
                {
                    _home = value;
                    RaisePropertyChanged(nameof(Home));
                }
            }
        }

        [Transalatable]
        public string Help
        {
            get { return _help; }
            set
            {
                if (_help != value)
                {
                    _help = value;
                    RaisePropertyChanged(nameof(Help));
                }
            }
        }

        [Transalatable]
        public string About
        {
            get { return _about; }
            set
            {
                if (_about != value)
                {
                    _about = value;
                    RaisePropertyChanged(nameof(About));
                }
            }
        }

        [Transalatable]
        public string View
        {
            get { return _view; }
            set
            {
                if (_view != value)
                {
                    _view = value;
                    RaisePropertyChanged(nameof(View));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
