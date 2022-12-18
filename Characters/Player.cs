using DemoStrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Characters
{
	public abstract class Player : Character
	{
		protected Player(string name, string title, int health, int attackDamage, int defense) : 
			base(name, title, health, attackDamage, defense) {}

		private int _elementalSkillEnergy = 0;
		public int ElementalSkillEnergy { 
			get => _elementalSkillEnergy; 
			set => _elementalSkillEnergy = Math.Min(value, 100);
		}

		private int _elementalBurstEnergy = 0;
		public int ElementalBurstEnergy { 
			get => _elementalBurstEnergy; 
			set => _elementalBurstEnergy = Math.Min(value, 100);
		}

		public bool IsElementalSkillReady() => ElementalSkillEnergy == 100;
		public bool IsElementalBurstReady() => ElementalBurstEnergy == 100;

		public abstract void UseElementalSkill(Character target);
		public abstract void UseElementalBurst(Character target);
	}
}
