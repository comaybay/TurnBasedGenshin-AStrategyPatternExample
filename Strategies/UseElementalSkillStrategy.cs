using DemoStrategyPattern.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Strategies
{
	internal class UseElementalSkillStrategy : IStrategy
	{
		private Character _target;

		public UseElementalSkillStrategy(Character target)
		{
			_target = target;
		}

		public void Execute(Character attacker)
		{
			if (attacker is Player pAttacker)
			{
				if (pAttacker.IsElementalSkillReady())
				{
					Commentator.CommentateShout($"{attacker.Name} using her Elemental Skill on {_target.Name}!");
					pAttacker.UseElementalSkill(_target);
				}
				else
				{
					Commentator.Commentate($"{pAttacker.Name} tried to use her Elemental Burst, " +
						$"but did not have enough energy! ({pAttacker.ElementalSkillEnergy}/100)");
				}
			}
		}
	}
}
