using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace DialogExamples.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        public ICommand GoSecondCommand
        {
            get { return new MvxCommand(() => ShowViewModel<SecondViewModel>());}
        }

        public ICommand GoLinearCommand
        {
            get { return new MvxCommand(() => ShowViewModel<LinearViewModel>()); }
        }

        public ICommand BindableElementsCommand
        {
            get { return new MvxCommand(() => ShowViewModel<ThirdViewModel>()); }
        }

        private bool _switchThis;
        public bool SwitchThis
        {
            get { return _switchThis; }
            set { _switchThis = value; RaisePropertyChanged(() => SwitchThis); }
        }

        private string _textProperty = "T";
        public string TextProperty
        {
            get { return _textProperty; }
            set { _textProperty = value; RaisePropertyChanged(() => TextProperty); }
        }

        private string _passwordProperty = "P";
        public string PasswordProperty
        {
            get { return _passwordProperty; }
            set { _passwordProperty = value; RaisePropertyChanged(() => PasswordProperty); }
        }

        private bool _checkThis;
        public bool CheckThis
        {
            get { return _checkThis; }
            set { _checkThis = value; RaisePropertyChanged(() => CheckThis); }
        }

        private readonly List<string> _dessertChoices = new List<string>()
            {
                "Cake",
                "Chocolate",
                "Ice cream",
                "Strawberries"
            };
        public List<string> DessertChoices
        {
            get { return _dessertChoices; }
        }

        private int _currentDessertIndex = 2;
        public int CurrentDessertIndex 
        {   
            get { return _currentDessertIndex; }
            set { _currentDessertIndex = value; RaisePropertyChanged(() => CurrentDessertIndex); }
        }
    }
}
