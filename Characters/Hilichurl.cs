using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern.Characters
{
	/// <summary>
	/// An enemy
	/// </summary>
    public class Hilichurl : Character
    {
		public Hilichurl() : base(
			name: "Hilichurl", title: "Goblin-like Monster",
			health: 200, 
			attackDamage: 20, 
			defense: 2
		) { }
	}
}
