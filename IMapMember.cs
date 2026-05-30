public interface IMapMember 
{
	public char Apperance {get; protected set;} 
	public bool CanMove {get; protected set;}
	public (int x, int y) CurrentLocation {get; set;}
}
