using DemoStrategyPattern.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Strategies
{
	public class AttackStrategy : IStrategy
	{
		private Character _target;

		public AttackStrategy(Character target)
		{
			_target = target;
		}

		public void Execute(Character attacker)
		{
			var dmg = Math.Max(0, attacker.AttackDamage - _target.Defense);
			_target.Health -= dmg;
			Commentator.CommentateShout($"{attacker.Name} Attacked {_target.Name}!");
			Commentator.Commentate($"{_target.Name} took {dmg} damage!");

			if (attacker is Player pAttacker)
			{
				pAttacker.ElementalSkillEnergy += 35;
				pAttacker.ElementalBurstEnergy += 20;
				Commentator.Commentate($"{attacker.Name} Gained {35} Elemetal Skill Energy! ({pAttacker.ElementalSkillEnergy}/100)");
				Commentator.Commentate($"{attacker.Name} Gained {20} Elemetal Burst Energy! ({pAttacker.ElementalBurstEnergy}/100)");
			}
		}
	}
}
