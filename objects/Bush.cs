public class Bush: IMapMember 
{
	public char Apperance {get; set;} = '#';
	public bool CanMove {get; set;} = false;
	public (int x, int y) CurrentLocation {get; set;}

	public Bush((int x, int y) location) 
	{
		CurrentLocation = location;
	}
}
