using Cirrious.CrossCore;

namespace FragmentSample.Core.ViewModels.Tab
{
    public class TabViewModel : BaseViewModel
    {
        public TabViewModel()
        {
            Vm1 = Mvx.IocConstruct<FirstTabViewModel>();
            Vm2 = Mvx.IocConstruct<SecondTabViewModel>();
            Vm3 = Mvx.IocConstruct<ThirdTabViewModel>();
        }

        public BaseViewModel Vm1 { get; set; }
        public BaseViewModel Vm2 { get; set; }
        public BaseViewModel Vm3 { get; set; }
    }
}