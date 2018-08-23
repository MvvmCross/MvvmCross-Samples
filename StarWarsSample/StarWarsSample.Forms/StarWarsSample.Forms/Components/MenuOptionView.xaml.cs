using System.Windows.Input;
using Xamarin.Forms;

namespace StarWarsSample.Forms.UI.Components
{
    public partial class MenuOptionView : StackLayout
    {
        public MenuOptionView()
        {
            InitializeComponent();
        }

        public string Text
        {
            set
            {
                Label.Text = value;
            }
        }

        public string Source
        {
            set
            {
                Icon.Source = value;
            }
        }
    }
}
