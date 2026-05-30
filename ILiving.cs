public interface ILiving 
{
	public string Health {get; set;}
	public int Hunger {get; protected set;}
	public int Thirst {get; protected set;}
	public int Age {get; protected set;}
	public bool IsLiving {get; set;}
	public bool IsMatable {get; set;}

	public void Mate();
}
