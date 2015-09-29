using System;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Collections.Core.ViewModels.Samples.LargeDynamic
{
    public class LargeDynamicViewModel : BaseSampleViewModel
    {
        private MyCustomList _kittens;

        public LargeDynamicViewModel()
        {
            Kittens = new MyCustomList();
        }

        public MyCustomList Kittens
        {
            get { return _kittens; }
            set
            {
                _kittens = value;
                RaisePropertyChanged(() => Kittens);
            }
        }

        public ICommand AddKittenCommand
        {
            get { return new MvxCommand(DoAddKitten); }
        }

        public ICommand KillKittensCommand
        {
            get { return new MvxCommand(DoKillKittens); }
        }

        private void DoAddKitten()
        {
            var kitten = CreateKitten();
            Kittens.Add(kitten);
        }

        private void DoKillKittens()
        {
            var toKillCount = Math.Min(10, Kittens.Count);
            for (var i = 0; i < toKillCount; i++)
            {
                Kittens.RemoveAt(0);
            }
        }
    }
}