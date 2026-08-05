namespace Shift.Legion.Common.Models;

public class WorkerInfo
{
	public int UserId;

	public string Name;

	public int Level;

	public float Potential = 1f;

	public object Clone()
	{
		return new WorkerInfo
		{
			UserId = UserId,
			Name = Name,
			Level = Level,
			Potential = Potential
		};
	}
}
