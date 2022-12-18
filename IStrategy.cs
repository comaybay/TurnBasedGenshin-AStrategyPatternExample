using DemoStrategyPattern.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern
{
	public interface IStrategy
	{
		public void Execute(Character character);
	}
}
