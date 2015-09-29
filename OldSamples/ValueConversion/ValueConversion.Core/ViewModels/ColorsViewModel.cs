using Cirrious.CrossCore.UI;
using Cirrious.MvvmCross.ViewModels;

namespace ValueConversion.Core.ViewModels
{
    public class ColorsViewModel : MvxViewModel
    {
        private int _blue;
        private MvxColor _color;
        private int _green;
        private int _red;

        public ColorsViewModel()
        {
            _red = 255;
            UpdateColor();
        }

        public int Red
        {
            get { return _red; }
            set
            {
                _red = value;
                RaisePropertyChanged(() => Red);
                UpdateColor();
            }
        }

        public int Green
        {
            get { return _green; }
            set
            {
                _green = value;
                RaisePropertyChanged(() => Green);
                UpdateColor();
            }
        }

        public int Blue
        {
            get { return _blue; }
            set
            {
                _blue = value;
                RaisePropertyChanged(() => Blue);
                UpdateColor();
            }
        }

        public MvxColor Color
        {
            get { return _color; }
            set
            {
                _color = value;
                RaisePropertyChanged(() => Color);
            }
        }

        private void UpdateColor()
        {
            Color = new MvxColor(Red, Green, Blue);
        }
    }
}