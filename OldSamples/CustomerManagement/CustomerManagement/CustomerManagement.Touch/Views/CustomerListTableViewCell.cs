using Cirrious.MvvmCross.Binding.Bindings;
using Cirrious.MvvmCross.Binding.Bindings.SourceSteps;
using MonoTouch.Foundation;

namespace CustomerManagement.Touch.Views
{
    public class CustomerListTableViewCell
        : MvxStandardTableViewCell
    {
        public const string BindingText = @"TitleText Name;DetailText Website";

        public static readonly MvxBindingDescription[] BindingDescriptions
            = new[]
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