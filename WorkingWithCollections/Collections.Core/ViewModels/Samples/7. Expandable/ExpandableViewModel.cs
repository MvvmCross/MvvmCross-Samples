using System;
using System.Collections.Generic;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.Core.ViewModels.Samples.Expandable
{
	public class ExpandableViewModel : BaseSampleViewModel
	{
		private List<KittenGroup> _kittenGroups;

		public ExpandableViewModel()
		{
			var kittenGroups = new List<KittenGroup>();

			for (int i = 0; i < 6; i++)
			{
				var kittenGroup = new KittenGroup();
				kittenGroup.Title = $"Kittens Group {i + 1}";
				kittenGroup.AddRange(CreateKittens(3));
				kittenGroups.Add(kittenGroup);
			}

			KittenGroups = kittenGroups;
		}

		public List<KittenGroup> KittenGroups
		{
			get { return _kittenGroups; }
			set { SetProperty(ref _kittenGroups, value); }
		}

		public class KittenGroup : List<Kitten>
		{
			public string Title { get; set; }
		}
	}
}
