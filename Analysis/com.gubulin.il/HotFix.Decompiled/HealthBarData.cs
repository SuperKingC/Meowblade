using HotFix;
using ObjectPool;

public class HealthBarData : IPooled
{
	public bool ShouldShieldAlignWithRightSide;

	public float MaxHealthPoints;

	public float CurrentHealthPoints;

	public float ReducingHealthPointsPercentage;

	public float ReducingTime;

	public float HealthPointsPercentage;

	public float BaseShieldPointsPercentage;

	public float SpecialShieldPointsPercentage;

	public int opUniqueId { get; set; }

	public bool Active { get; set; }

	public void OnInstantiate()
	{
	}

	public void OnUnSpawn()
	{
		ShouldShieldAlignWithRightSide = false;
		MaxHealthPoints = 0f;
		CurrentHealthPoints = 0f;
		ReducingHealthPointsPercentage = 1f;
		ReducingTime = 0f;
		HealthPointsPercentage = 0f;
		BaseShieldPointsPercentage = 0f;
		SpecialShieldPointsPercentage = 0f;
	}

	public void UnSpawn()
	{
		ObjectPool<HealthBarData>.UnSpawn(this);
	}
}
