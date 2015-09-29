using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using FragmentSample.Core.ViewModels;
using FragmentSample.Core.ViewModels.Dialog;

namespace FragmentSample.UI.Droid.Views
{
    public class NameDialogFragment : MvxDialogFragment
    {
        public NamesViewModel NamesViewModel
        {
            get { return (NamesViewModel) ViewModel; }
        }

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            base.EnsureBindingContextSet(savedState);

            var view = this.BindingInflate(Resource.Layout.Dialog_Names, null);

            var dialog = new AlertDialog.Builder(Activity);
            dialog.SetTitle("Name Dialog");
            dialog.SetView(view);
            dialog.SetNegativeButton("Cancel", (s, a) => { });
            dialog.SetPositiveButton("OK", (s, a) => 
                    Toast.MakeText(Activity.ApplicationContext, string.Format("Full name is: {0}", NamesViewModel.FullName), ToastLength.Short).Show()
                );
            return dialog.Create();
        }
    }
}