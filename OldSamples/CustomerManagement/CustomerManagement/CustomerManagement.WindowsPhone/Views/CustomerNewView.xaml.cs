using Cirrious.MvvmCross.WindowsPhone.Views;
using CustomerManagement.Core.ViewModels;

namespace CustomerManagement.WindowsPhone.Views
{
    public abstract class BaseCustomerNewView : MvxPhonePage<NewCustomerViewModel> { }

    [MvxPhoneView("/Views/CustomerNewView.xaml")]
    public partial class CustomerNewView : BaseCustomerNewView
    {
        public CustomerNewView()
        {
            InitializeComponent();
        }
    }
}