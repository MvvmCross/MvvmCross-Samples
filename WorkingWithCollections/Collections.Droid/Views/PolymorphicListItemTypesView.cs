using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Collections.Core.ViewModels.Samples.ListItems;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.Droid.BindingContext;

namespace Collections.Droid.Views
{
    [Activity(Label = "Polymorphic Types", ScreenOrientation = ScreenOrientation.Portrait)]
    public class PolymorphicListItemTypesView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_PolymorphicView);
            var list = FindViewById<MvxListView>(Resource.Id.TheListView);
            list.Adapter = new CustomAdapter(this, (IMvxAndroidBindingContext) BindingContext);
        }

        public class CustomAdapter : MvxAdapter
        {
            public CustomAdapter(Context context, IMvxAndroidBindingContext bindingContext)
                : base(context, bindingContext)
            {
            }

            public override int GetItemViewType(int position)
            {
                var item = GetRawItem(position);
                if (item is Kitten)
                    return 0;
                return 1;
            }

            public override int ViewTypeCount
            {
                get { return 2; }
            }

            protected override View GetBindableView(View convertView, object source, int templateId)
            {
                if (source is Kitten)
                    templateId = Resource.Layout.ListItem_Kitten;
                else if (source is Dog)
                    templateId = Resource.Layout.ListItem_Dog;

                return base.GetBindableView(convertView, source, templateId);
            }
        }
    }
}