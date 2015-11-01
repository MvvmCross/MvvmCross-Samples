using Cirrious.MvvmCross.WindowsPhone.Views;
using CustomerManagement.Core.ViewModels;

namespace CustomerManagement.WindowsPhone.Views
{
    public abstract class BaseCustomerEditView : MvxPhonePage<EditCustomerViewModel> { }

    [MvxPhoneView("/Views/CustomerEditView.xaml")]
    public partial class CustomerEditView : BaseCustomerEditView
    {
        public CustomerEditView()
        {
            InitializeComponent();
        }
    }
}