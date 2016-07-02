using System;
using System.Collections.Generic;
using Collections.Core.ViewModels.Samples.ListItems;

namespace Collections.Core
{
	public class KittenGroup : List<Kitten>
	{
		public string Title { get; set; }

		public KittenGroup(IEnumerable<Kitten> collection) : base(collection)
		{
			
		}
	}
}

