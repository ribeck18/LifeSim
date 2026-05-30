public interface IPredator 
{
	public List<IPrey> Prey {get; protected set;}

	public void Hunt();
	public IPrey ChoosePrey();
}
