using System;
using Android.Support.V7.Widget;

namespace StarWarsSample.Droid.Controls
{
    public class RecyclerViewOnScrollListener : RecyclerView.OnScrollListener
    {
        public delegate void LoadMoreEventHandler(object sender, EventArgs e);

        public int RemainingItemsToTriggerFetch { get; set; } = 8;

        public event LoadMoreEventHandler LoadMoreEvent;

        private LinearLayoutManager LayoutManager;

        public RecyclerViewOnScrollListener(LinearLayoutManager layoutManager)
        {
            LayoutManager = layoutManager;
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);

            var visibleItemCount = recyclerView.ChildCount;
            var totalItemCount = recyclerView.GetAdapter().ItemCount;
            var pastVisiblesItems = LayoutManager.FindFirstVisibleItemPosition();

            if (totalItemCount != 0
                //&& pastVisiblesItems > 0
                &&
                (
                    RemainingItemsToTriggerFetch >= totalItemCount
                    || (visibleItemCount + pastVisiblesItems + RemainingItemsToTriggerFetch) >= totalItemCount
                ))
            {
                LoadMoreEvent?.Invoke(this, null);
            }
        }
    }
}
