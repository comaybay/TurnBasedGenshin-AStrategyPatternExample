using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Characters
{
	/// <summary>
	/// A playable character in genshin
	/// </summary>
    public class Noelle : Player
    {
		public Noelle() : base(
			name: "Noelle", title: "Maid of Favonius",
			health: 100,
			attackDamage: 15,
			defense: 10
		) {}

		public override void UseElementalSkill(Character target)
		{
			var dmg = Math.Max(0, AttackDamage + (Defense * 2) - target.Defense);
			var oldDef = Defense;

			target.Health -= dmg;
			Defense += Defense;

			Commentator.Commentate($"{target.Name} took {dmg} damage!");
			Commentator.Commentate($"{Name}'s Defense increased from {oldDef} to {Defense}!");
		}

		public override void UseElementalBurst(Character target)
		{
			var dmg = Math.Max(0, (AttackDamage + (Defense * 4)) - target.Defense);
			var oldAtk = AttackDamage;

			target.Health -= dmg;
			AttackDamage += Defense * 2;

			Commentator.Commentate($"{target.Name} took {dmg} damage!");
			Commentator.Commentate($"{Name}'s Attack Damage increased from {oldAtk} to {AttackDamage}!");
		}
	}
}
