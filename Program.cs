using DemoStrategyPattern;
using DemoStrategyPattern.Characters;
using DemoStrategyPattern.Strategies;

Console.WindowHeight = Console.LargestWindowHeight - 12;
static void Wait()
{
	while (Console.KeyAvailable)
	{
		Console.ReadKey(true);
	}

	Console.ReadKey();
}

//=======

Player player = new Noelle();
Character enemy = new Hilichurl();

var playerStrategies = new List<IStrategy>() {
	new AttackStrategy(enemy),
	new UseElementalSkillStrategy(enemy),
	new AttackStrategy(enemy),
	new AttackStrategy(enemy),
	new UseElementalSkillStrategy(enemy),
	new AttackStrategy(enemy),
	new AttackStrategy(enemy),
	new UseElementalBurstStrategy(enemy),
	new AttackStrategy(enemy),
};

var enemyStrategies = new List<IStrategy>() {
	new AttackStrategy(player),
	new AngryStrategy(),
	new AttackStrategy(player),
	new DefenseStrategy(),
	new AttackStrategy(player),
	new AttackStrategy(player),
};

var characterTurns = new List<(Character Character, List<IStrategy> Strategies)>() { 
	(player, playerStrategies), 
	(enemy, enemyStrategies)
};

var characters = characterTurns.Select(ct => ct.Character).ToList();

bool matchContinue = true;
int round = 1;

Commentator.MatchName(player, enemy);
characters.ForEach(character => Commentator.CharacterInfo(character));
Commentator.PrepareNextRound(round);
Wait();

Console.Clear();

while (matchContinue)
{
	Commentator.MatchName(player, enemy);
	Commentator.RoundInfo(round);

	characters.ForEach(character => Commentator.CharacterInfo(character));

	Commentator.RoundStart(round);

	foreach (var (character, strategies) in characterTurns)
	{
		if (character.Health > 0)
		{
			Commentator.TurnInfo(character);
			character.Strategy = strategies[(round - 1) % strategies.Count];
			character.ExecuteStrategy();
		}
		else
		{
			Commentator.CharacterDown(character);
		}
	}

	Commentator.RoundEnd(round);
	
	characters.ForEach(character => Commentator.CharacterInfo(character));

	matchContinue = characters.All(character => character.Health > 0);
	if (matchContinue)
	{
		round++;
		Commentator.PrepareNextRound(round);
		Wait();
		Console.Clear();
	}
	else
	{
		var winCharacter = characters.First(character => character.Health > 0); 
		Commentator.DeclareWinner(winCharacter);
		Console.ReadLine();
	}
}


