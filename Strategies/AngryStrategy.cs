using DemoStrategyPattern.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Strategies
{
	public class AngryStrategy : IStrategy
	{
		public void Execute(Character character)
		{
			var oldAtk = character.AttackDamage;
			character.AttackDamage += 10;
			Commentator.CommentateShout($"{character.Name} Became Angry!");
			Commentator.Commentate($"{character.Name}'s Attack increased from {oldAtk} to {character.AttackDamage}!");
		}
	}
}
