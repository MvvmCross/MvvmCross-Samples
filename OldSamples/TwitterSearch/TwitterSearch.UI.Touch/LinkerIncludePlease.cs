using System;

namespace TwitterSearch.UI.Touch
{
    // things in this class are only required in order to prevent the linker overoptimising!
    internal class LinkerIncludePlease
    {
        private void IncludeStuff()
        {
            UITextField textField = null;
            textField.Text = textField.Text + "";

            UIButton button = null;
            button.TouchUpInside += delegate (object sender, EventArgs e)
            {
            };
        }
    }
}