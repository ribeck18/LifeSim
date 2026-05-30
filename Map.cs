public class Map 
{
	public char[,] MapArray {get; set;} = new char[25, 100];
	public char Dirt {get;} = '.';


	public (int x, int y) GetRandomLocation()
	{
		bool locationFound = false;
		(int x, int y) location = (-1,-1);

		while (locationFound == false)
		{
			Random rnd = new Random();

			int x = rnd.Next(0, MapArray.GetLength(0));
			int y = rnd.Next(0, MapArray.GetLength(1));

			location = (x, y);

			if (CheckLocationInBounds(location))
			{
				if (CheckSpotTaken(location))
				{
					continue;
				}

				locationFound = true;
			}
		}

		if (location == (-1,-1))
		{
			throw new InvalidOperationException("A Random unused, inbounds location could not be found.");
		}

		return location;			
	}

	public bool CheckSpotTaken((int x, int y) location)
	{
		char locationApperance = MapArray[location.x, location.y];
		
		if (locationApperance != Dirt)
		{
			return true;
		}

		return false;

	}

	public bool CheckLocationInBounds((int x, int y) location) 
	{
		if (location.x >= MapArray.GetLength(0) || location.y >= MapArray.GetLength(1))
		{
			return false;
		}
		if (location.x < 0 || location.y < 0)
		{
			return false;
		}

		return true;
	}

	//this is the temp function
	public void GenerateMap(int waterCount, int bushCount) 
	{
		//Dirt
		for (int x = 0; x < MapArray.GetLength(0); x++){
			for (int y = 0; y < MapArray.GetLength(1); y++) {
				MapArray[x,y] = Dirt;	
			}
		}

		//Waters
		for (int i=0; i < waterCount; i++)
		{
			Water water = new Water(GetRandomLocation());
			MapArray[water.CurrentLocation.x, water.CurrentLocation.y] = water.Apperance;
		}
		
		//Bushes
		for (int i=0; i < bushCount; i++)
		{
			Bush bush = new Bush(GetRandomLocation());
			MapArray[bush.CurrentLocation.x, bush.CurrentLocation.y] = bush.Apperance;
		}
	}

	public void PrintMap()
	{
		Console.Clear();
		for (int x = 0; x < MapArray.GetLength(0); x++)
		{
			for (int y = 0; y < MapArray.GetLength(1); y++)
			{
				Console.Write(MapArray[x,y]);
			}
			Console.WriteLine();
		}
	}






	//-------------Use this method when you are ready to make the map inanimate objects their own objects rather than written characters.
	// public (List<IMapMember>, List<IMapMember>) SpawnMapMembers(int waterCount, int BushCount) 
	// {
	// 	var immovables = new List<IMapMember>();
	// 	var moveables = new List<IMapMember>();
	// 	var waters = new List<Water>();
	//
	// 	for (int x = 0; x < MapArray.GetLength(0); x++) 
	// 	{
	// 		for (int y =0; y < MapArray.GetLength(1); y++) 
	// 		{
	// 			MapArray[x,y] = Dirt;
	// 		}
	// 	}
	//
	// 	for (int i = 0; i < waterCount; i++) 
	// 	{
	// 		//If first water create a new location
	// 		if (i == 0)
	// 		{
	// 			Water water = new Water(GetRandomLocation());
	// 			immovables.Add(water);
	// 			waters.Add(water);
	// 		}
	// 		//if a later water place adjacent to a random existing water.
	// 		else
	// 		{
	// 			bool badLocation = true;
	//
	// 			while (badLocation) 
	// 			{
	// 				Random rnd = new Random();
	// 				int rndWaterIndex = rnd.Next(0, waters.Count());	
	// 				Water existingWater = waters[rndWaterIndex];
	//
	//
	// 			}
	//
	// 		}
	// 	}
	//

		// return (immovables, moveables);
	// }

}
