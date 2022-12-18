using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Characters
{
	public abstract class Character
	{
		public string Name { get; set; }
		public string Title { get; set; }
		public int Health { get; set; }
		public int AttackDamage { get; set; }
		public int Defense { get; set; }

		protected Character(string name, string title, int health, int attackDamage, int defense)
		{
			Name = name;
			Title = title;
			Health = health;
			AttackDamage = attackDamage;
			Defense = defense; 
		}

		public IStrategy? Strategy { get; set; }

		public void ExecuteStrategy() => Strategy?.Execute(this);
	}
}
