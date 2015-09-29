using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace MoreControls.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {       
        private List<Shape> _shapes = new List<Shape>() { Shape.Circle, Shape.Square, Shape.Triangle};
        public List<Shape> Shapes
        {
            get
            {
                return _shapes;
            }
        }

        private Shape _current;
        public Shape Current
        {
            get { return _current; }
            set { _current = value; RaisePropertyChanged(() => Current); }
        }        
    }
}
