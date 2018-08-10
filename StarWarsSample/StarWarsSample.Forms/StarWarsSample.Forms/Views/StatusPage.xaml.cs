using System;
using System.Collections.Generic;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using StarWarsSample.Core.ViewModels;
using Xamarin.Forms;

namespace StarWarsSample.Forms.UI.Views
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail)]
    public partial class StatusPage : MvxContentPage<StatusViewModel>
    {
        public StatusPage()
        {
            InitializeComponent();
        }
    }
}
