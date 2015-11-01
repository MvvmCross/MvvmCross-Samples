namespace DialogExamples.Droid.BindableElements
{
    public interface IBindableElement
        : IMvxBindingContextOwner
    {
        object DataContext { get; set; }
    }
}