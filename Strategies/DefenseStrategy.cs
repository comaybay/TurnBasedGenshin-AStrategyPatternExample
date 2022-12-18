using DemoStrategyPattern.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Strategies
{
	public class DefenseStrategy : IStrategy
	{
		public void Execute(Character character)
		{
			var oldDef = character.Defense;
			character.Defense += 10;
			Commentator.CommentateShout($"{character.Name} Defended itself!");
			Commentator.Commentate($"{character.Name}'s Defense increased from {oldDef} to {character.Defense}!");
		}
	}
}
