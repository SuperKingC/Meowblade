using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class Throne : Building
{
	public object Controller;

	public Throne(GameManagers managers)
		: base(managers, "15")
	{
	}

	public void UpdateArtifacts()
	{
	}

	private void SetDoomArtifact(int level)
	{
	}

	private void SetDominionArtifact(int level)
	{
	}

	private void SetSlaveryArtifact(int level)
	{
	}

	public override bool HasAnyInform()
	{
		return CacheManager.Instance.Get<Cache_PrinceRedDot>().IsShowRedDot;
	}
}
