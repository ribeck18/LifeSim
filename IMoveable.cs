public interface IMoveable 
{
	public void ExecutePathStep(Map map);
	public List<(int x, int y)> PlanPath(Map map, List<(int x, int y)> targets);	
	public void GoToNearest(Map map);
	public void GoToLocation(Map map);
	public void Wander(Map map);
}
