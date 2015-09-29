using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace FragmentSample.Core.ViewModels.Shakespeare
{
    public class TitlesViewModel
        : BaseViewModel
    {
        private static string[] _titles =
            {
                "Henry IV (1)",
                "Henry V",
                "Henry VIII",
                "Richard II",
                "Richard III",
                "Merchant of Venice",
                "Othello",
                "King Lear"
            };

        public string[] Titles
        {
            get { return _titles; }
        }

        public ICommand ShowCommand
        {
            get 
            {
                return new MvxCommand<string>(title =>
                    {
                        var position = 0;
                        for (position = 0; position < _titles.Length; position++)
                            if (_titles[position] == title)
                                break;

                        ShowViewModel<DetailViewModel>(new { title, index = position });
                    });
            }
        }
    }
}
