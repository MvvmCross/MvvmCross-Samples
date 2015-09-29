using System;

namespace MonoTouchCellTutorial.Core.Models
{
	public class AnimalGenerator
	{
		private readonly Random _random = new Random();
		protected int Random (int count)
		{
			return _random.Next(count);
		}
		
		protected bool RandomBool ()
		{
			return Random(2) == 1;
		}
	}
}