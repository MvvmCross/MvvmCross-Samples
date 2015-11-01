using Cirrious.MvvmCross.WindowsPhone.Views;
using CustomerManagement.Core.ViewModels;

namespace CustomerManagement.WindowsPhone.Views
{
    public abstract class BaseCustomerListView : MvxPhonePage<CustomerListViewModel> { }

    [MvxPhoneView("/Views/CustomerListView.xaml")]
    public partial class CustomerListView : BaseCustomerListView
    {
        // Constructor
        public CustomerListView()
        {
            InitializeComponent();

            ApplicationTitle.Text = "Customer Management";
            PageTitle.Text = "Customers";
        }
    }
}