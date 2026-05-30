public interface IPrey 
{
	public List<IPredator> Predators {get; protected set;}

	public IPredator FleePredator();
}
