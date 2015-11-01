using Cirrious.MvvmCross.Views;
using TwitterSearch.Test.Mocks;

namespace TwitterSearch.Test
{
    public class MvxTest : MvxIoCSupportingTest
    {
        protected MockMvxViewDispatcher CreateMockNavigation()
        {
            var dispatcher = new MockMvxViewDispatcher();
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(dispatcher);
            Ioc.RegisterSingleton<IMvxViewDispatcher>(dispatcher);
            return dispatcher;
        }
    }
}