Map map = new Map();
List<ILiving> livingCreatures = [];
List<IMoveable> moveableCreatures = [];
bool gameRunning = true;

map.GenerateMap(10, 10);
map.PrintMap();

//Spawn inital creatures
Wolf wolf = new Wolf(map, (1,1), []);
livingCreatures.Add(wolf);
moveableCreatures.Add(wolf);



//For testing delete later 

var targets = new List<(int x, int y)>();
targets.Add((19,22));
wolf.PlanPath(map, targets);

//GameLoop
while (gameRunning)
{
	map.PrintMap();
	foreach(IMoveable creature in moveableCreatures)
	{
		creature.ExecutePathStep(map);
	}

	gameRunning = false;
}
