public class Wolf: IMapMember, IMoveable, ILiving
{
	public char Apperance {get; set;} = 'W';
	public bool CanMove {get; set;} = true;
	public (int x, int y) CurrentLocation {get; set;}

	public string Health {get; set;}
	public int Hunger {get; set;}
	public int Thirst {get; set;}
	public int Age {get; set;}
	public bool IsLiving {get; set;}
	public bool IsMatable {get; set;}

	public List<IPrey> Prey {get; set;}

	private List<(int x, int y)> _currentPath = [];
	private int _currentStep;

	public Wolf(Map map, (int x, int y) location, List<IPrey> prey) 
	{
		CurrentLocation = location;
		Prey = prey;
		map.MapArray[location.x, location.y] = Apperance;
	}

	public List<(int x, int y)> PlanPath(Map map, List<(int x , int y)> targets)
	{
		var visited = new HashSet<(int x, int y)>();
		var queue = new Queue<(int x, int y)>();
		(int x, int y) selctedTarget = (-1, -1);
		var pathsDict = new Dictionary<(int x, int y), (int x, int y)>();
		var potentialTargets = new List<(int x, int y)>();
		var path = new List<(int x, int y)>();

		//Find the neighbors of each target.
		foreach ((int x, int y) target in targets)
		{
			var n1 = (x: target.x+1, y: target.y);
			var n2 = (x: target.x-1, y: target.y);
			var n3 = (x: target.x, y: target.y+1);
			var n4 = (x: target.x, y: target.y-1);

			if (map.MapArray[n1.x, n1.y] == map.Dirt && map.CheckLocationInBounds(n1) && map.CheckSpotTaken(n1) == false)
			{
				potentialTargets.Add(n1);
			}
			if (map.MapArray[n2.x, n2.y] == map.Dirt && map.CheckLocationInBounds(n2) && map.CheckSpotTaken(n2) == false)
			{
				potentialTargets.Add(n2);
			}
			if (map.MapArray[n3.x, n3.y] == map.Dirt && map.CheckLocationInBounds(n3) && map.CheckSpotTaken(n3) == false)
			{
				potentialTargets.Add(n3);
			}
			if (map.MapArray[n4.x, n4.y] == map.Dirt && map.CheckLocationInBounds(n4) && map.CheckSpotTaken(n4) == false)
			{
				potentialTargets.Add(n4);
			}
		}
	
		//Add current location to queue and visited 
		visited.Add(CurrentLocation);
		queue.Enqueue(CurrentLocation);

		while (queue.Count > 0)
		{
			var current = queue.Dequeue();	
			
			if (potentialTargets.Contains(current))
			{
				selctedTarget = current;
				break;
			}

			var n1 = (x: current.x+1, y: current.y);
			var n2 = (x: current.x-1, y: current.y);
			var n3 = (x: current.x, y: current.y+1);
			var n4 = (x: current.x, y: current.y-1);

			if (!visited.Contains(n1) && map.CheckLocationInBounds(n1) && !map.CheckSpotTaken(n1))
			{
				pathsDict[n1] = current;
				queue.Enqueue(n1);
				visited.Add(n1);
			}
			if (!visited.Contains(n2) && map.CheckLocationInBounds(n2) && !map.CheckSpotTaken(n2))
			{
				pathsDict[n2] = current;
				queue.Enqueue(n2);
				visited.Add(n2);
			}
			if (!visited.Contains(n3) && map.CheckLocationInBounds(n3) && !map.CheckSpotTaken(n3))
			{
				pathsDict[n3] = current;
				queue.Enqueue(n3);
				visited.Add(n3);
			}
			if (!visited.Contains(n4) && map.CheckLocationInBounds(n4) && !map.CheckSpotTaken(n4))
			{
				pathsDict[n4] = current;
				queue.Enqueue(n4);
				visited.Add(n4);
			}
		}
		
		if (selctedTarget == (-1,-1))
		{
			throw new InvalidOperationException("A path could not be planned for these targets.");
		}

		//Build a path from slectedTarget to CurrentLocation
		var currentTarget = selctedTarget;
		path.Add(currentTarget);
		while (currentTarget != CurrentLocation)
		{
			path.Add(currentTarget);
			currentTarget = pathsDict[currentTarget];
		}
		path.Reverse();

		_currentPath = path;
		_currentStep = 0;
		return path;
	}

	public void ExecutePathStep(Map map)
	{
		if (_currentPath.Count == 0 || _currentStep >= _currentPath.Count())
		{
			return;
		}

		var step = _currentPath[_currentStep];
		map.MapArray[CurrentLocation.x, CurrentLocation.y] = map.Dirt;
		map.MapArray[step.x, step.y] = Apperance;
		CurrentLocation = step;

		_currentStep++;
	}

	public void GoToNearest(Map map)
	{

	}
	public void GoToLocation(Map map)
	{

	}
	public void Wander(Map map)
	{

	}

	public void Mate()
	{

	}

	// public void Hunt()
	// {
	//
	// }
	//
	// public IPrey ChoosePrey()
	// {
	//
	// }

}
