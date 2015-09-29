using Cirrious.MvvmCross.Binding.BindingContext;
using CrossUI.Touch.Dialog.Elements;
using DialogExamples.Core.ViewModels;

namespace DialogExamples.Touch.BindableElements
{
    public class CustomStringElement
        : StringElement
          , IBindableElement
    {       
        public IMvxBindingContext BindingContext { get; set; }

        public CustomStringElement()
        {
            this.CreateBindingContext();
            this.DelayBind(() =>
                {
                    var set = this.CreateBindingSet<CustomStringElement, ThirdViewModel.Person>();
                    set.Bind().For(me => me.Caption).To(p => p.FirstName);
                    set.Bind().For(me => me.Value).To(p => p.LastName);
                    set.Apply();
                });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BindingContext.ClearAllBindings();
            }
            base.Dispose(disposing);
        }

        public virtual object DataContext
        {
            get { return BindingContext.DataContext; }
            set { BindingContext.DataContext = value; }
        }
    }
}