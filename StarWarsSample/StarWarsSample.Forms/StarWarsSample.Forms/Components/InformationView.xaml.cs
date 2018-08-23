using Xamarin.Forms;

namespace StarWarsSample.Forms.UI.Components
{
    public partial class InformationView : Grid
    {
        public InformationView()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            set
            {
                Label.Text = value;
            }
        }

        public string ValueText
        {
            set
            {
                Value.Text = value;
            }
        }
    }
}
