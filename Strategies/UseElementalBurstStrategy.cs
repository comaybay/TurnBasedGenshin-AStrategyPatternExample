using DemoStrategyPattern.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Strategies
{
	internal class UseElementalBurstStrategy : IStrategy
	{
		private Character _target;

		public UseElementalBurstStrategy(Character target)
		{
			_target = target;
		}

		public void Execute(Character attacker)
		{
			if (attacker is Player pAttacker) { 
				if (pAttacker.IsElementalBurstReady())
				{
					Commentator.CommentateShout($"{pAttacker.Name} using her Elemental Burst on {_target.Name}!");
					pAttacker.UseElementalBurst(_target);
				}
				else
				{
					Commentator.Commentate($"{pAttacker.Name} tried to use her Elemental Burst, " +
						$"but did not have enough energy! ({pAttacker.ElementalBurstEnergy}/100)");
				}
			}
		}
	}
}
