using System;
using AppKit;
using Foundation;

namespace XPlatformMenus.Mac.Views
{
	public class SourceListDelegate : NSOutlineViewDelegate
	{
		#region Private variables
		private SourceListView _controller;
		#endregion

		#region Constructors
		public SourceListDelegate(SourceListView controller)
		{
			// Initialize
			this._controller = controller;
		}
		#endregion

		#region Override Methods
		public override nfloat GetRowHeight(NSOutlineView outlineView, NSObject item)
		{
			// if it is a HeaderCell, we should resize
			if (((SourceListItem)item).HasChildren)
			{
				return 17.0f;
			}
			else 
			{
				return 26.0f;
			}
		}

		public override bool ShouldEditTableColumn(NSOutlineView outlineView, NSTableColumn tableColumn, Foundation.NSObject item)
		{
			return false;
		}

		public override NSCell GetCell(NSOutlineView outlineView, NSTableColumn tableColumn, Foundation.NSObject item)
		{
			nint row = outlineView.RowForItem(item);
			return tableColumn.DataCellForRow(row);
		}

		public override bool IsGroupItem(NSOutlineView outlineView, Foundation.NSObject item)
		{
			return ((SourceListItem)item).HasChildren;
		}

		public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
		{
			NSTableCellView view = null;

			// Is this a group item?
			if (((SourceListItem)item).HasChildren)
			{
				view = (NSTableCellView)outlineView.MakeView("HeaderCell", this);
			}
			else {
				view = (NSTableCellView)outlineView.MakeView("DataCell", this);
				view.ImageView.Image = ((SourceListItem)item).Icon;

			}

			// Initialize view
			view.TextField.StringValue = ((SourceListItem)item).Title;

			// Return new view
			return view;
		}

		public override bool ShouldSelectItem(NSOutlineView outlineView, Foundation.NSObject item)
		{
			return (outlineView.GetParent(item) != null);
		}

		public override void SelectionDidChange(NSNotification notification)
		{
			NSIndexSet selectedIndexes = _controller.SelectedRows;

			// More than one item selected?
			if (selectedIndexes.Count > 1)
			{
				// Not handling this case
			}
			else {
				// Grab the item
				var item = _controller.Data.ItemForRow((int)selectedIndexes.FirstIndex);

				// Was an item found?
				if (item != null)
				{
					// Fire the clicked event for the item
					item.RaiseClickedEvent();

					// Inform caller of selection
					_controller.RaiseItemSelected(item);
				}
			}
		}
		#endregion
	}
}