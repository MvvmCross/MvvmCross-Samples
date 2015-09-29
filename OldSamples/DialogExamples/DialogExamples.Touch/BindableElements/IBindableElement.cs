using Cirrious.MvvmCross.Binding.BindingContext;

namespace DialogExamples.Touch.BindableElements
{
    public interface IBindableElement
        : IMvxBindingContextOwner
    {
        object DataContext { get; set; }
    }
}
