using System.ComponentModel;

namespace CrossLight.Views
{
    public class FooBarViewModel : INotifyPropertyChanged
    {
        public FooBarViewModel()
        {
            _foo = "hello";
            _bar = "world";
        }

        private string _foo;
        public string Foo
        {
            get { return _foo; }
            set { _foo = value; OnPropertyChanged("Foo"); OnPropertyChanged("FooBar"); }
        }

        private string _bar;
        public string Bar
        {
            get { return _bar; }
            set { _bar = value; OnPropertyChanged("Bar"); OnPropertyChanged("FooBar"); }
        }

        public string FooBar
        {
            get { return _foo + _bar; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}