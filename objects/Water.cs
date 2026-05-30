public class Water: IMapMember 
{
	public char Apperance {get; set;} = '~';
	public bool CanMove {get; set;} = false;
	public (int x, int y) CurrentLocation {get; set;}

	public Water((int x, int y) location) 
	{
		CurrentLocation = location;
	}
}
