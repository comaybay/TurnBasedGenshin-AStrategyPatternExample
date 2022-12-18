using DemoStrategyPattern.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStrategyPattern
{
	public class Commentator
	{
		private static readonly int _decorationLength = 80;

		public static void Commentate(string comment)
		{
			Console.WriteLine($"> {comment}");
		}

		public static void CommentateShout(string comment)
		{
			Console.WriteLine($">>> {comment} <<<");
		}


		public static void MatchName(Character character1, Character character2) {
			Console.WriteLine($">>>{character1.Name} VS. {character2.Name}<<<");
		}

		public static void TurnInfo(Character character)
		{
			Console.WriteLine($"\n==={character.Name}'s Turn===");
		}
		public static void CharacterDown(Character character)
		{
			Console.WriteLine($"\n>>>{character.Name} is DOWN!<<<");
		}

		public static void CharacterInfo(Character character)
		{
			var title = $"{character.Name} - {character.Title}";
			Console.WriteLine($"\n{title} {new string('=', Math.Max(0, _decorationLength/2 - title.Length))}");
			
			if (character.Health > 0)
			{
				Console.WriteLine($"HP: {character.Health}, ATK: {character.AttackDamage}, DF: {character.Defense}");
			}
			else
			{
				Console.WriteLine($"STATUS: DEAD");
			}

			if ( character is Player player ) {
				string esReady = player.IsElementalSkillReady() ? "READY" : "NOT READY";
				string erReady = player.IsElementalBurstReady() ? "READY" : "NOT READY";
				Console.WriteLine(
					$"Elemental Skill: {esReady} ({player.ElementalSkillEnergy}/100), " +
					$"Elemental Burst: {erReady} ({player.ElementalBurstEnergy}/100)"
				);
			}
		}
		public static void PrepareNextRound(int round)
		{
			Console.WriteLine($"\n>>> Prepare for Round {round}! <<<");
		}

		public static void DeclareWinner(Character character)
		{
			Console.WriteLine($"\n>>> Match End <<<");
			Commentate($"{character.Name} - {character.Title} Won!!!");
		}

		public static void RoundInfo(int round)
		{
			Console.WriteLine($">>> Round {round} <<<");
		}

		public static void RoundStart(int round)
		{
			var roundStart = $"Round {round} Start";
			Console.WriteLine($"\n{roundStart} { new string('<', _decorationLength - roundStart.Length)}");
		}

		public static void RoundEnd(int round)
		{
			var roundEnd = $"Round {round} Ended";
			Console.WriteLine($"\n{roundEnd} {new string('<', _decorationLength - roundEnd.Length)}");
		}
	}
}
