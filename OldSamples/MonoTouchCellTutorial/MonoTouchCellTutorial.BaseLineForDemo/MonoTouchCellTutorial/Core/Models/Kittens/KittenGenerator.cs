using System;
using System.Collections.Generic;

namespace MonoTouchCellTutorial.Core.Models.Kittens
{
    public class KittenGenerator : AnimalGenerator
    {
        private readonly List<string> _names = new List<string>() { 
			"Tiddles", 
			"Amazon", 
			"Pepsi", 
			"Solomon", 
			"Butler", 
			"Snoopy", 
			"Harry", 
			"Holly", 
			"Paws", 
			"Polly", 
			"Dixie", 
			"Fern", 
			"Cousteau", 
			"Frankenstein", 
			"Bazooka", 
			"Casanova", 
			"Fudge", 
			"Comet" };

        public Kitten CreateNewKitten()
        {
            return new Kitten()
                {
                    Name = _names[Random(_names.Count)],
                    ImageUrl = string.Format("http://placekitten.com/{0}/{0}", Random(20) + 300),
					LitterTrained = RandomBool()
                };
        }
    }
}