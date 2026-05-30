Sim sim = new Sim();
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
	sim.Tick();	
	map.PrintMap();
	foreach(IMoveable creature in moveableCreatures)
	{
		creature.ExecutePathStep(map);
	}

	//for testing.
	if (wolf.CurrentLocation == (19,22))
	{
		gameRunning = false;
	}

}
