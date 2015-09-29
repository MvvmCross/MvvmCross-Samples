using Cirrious.MvvmCross.Binding.Binders;
using Cirrious.MvvmCross.Binding.Bindings;
using Cirrious.MvvmCross.Binding.Bindings.SourceSteps;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CustomerManagement.Touch.Views
{
    public class CustomerListTableViewCell
        : MvxStandardTableViewCell
    {
		public const string BindingText = @"TitleText Name;DetailText Website";

        public static readonly MvxBindingDescription[] BindingDescriptions 
            = new []
                  {
                      new MvxBindingDescription()
                          {
                              TargetName = "TitleText",
                              Source = new MvxPathSourceStepDescription()
                                  {
                                      SourcePropertyPath = "Name"
                                  }
                          },
                      new MvxBindingDescription()
                          {
                              TargetName = "DetailText",
                              Source = new MvxPathSourceStepDescription()
                                  {
                                      SourcePropertyPath = "Website"
                                  }
                          },
                  };

        public CustomerListTableViewCell(UITableViewCellStyle cellStyle, NSString cellIdentifier)
            : base(BindingDescriptions, cellStyle, cellIdentifier)
        {
        }
    }
}