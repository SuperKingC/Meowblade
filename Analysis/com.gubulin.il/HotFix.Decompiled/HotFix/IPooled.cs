namespace HotFix;

public interface IPooled
{
	int opUniqueId { get; set; }

	bool Active { get; set; }

	void OnInstantiate();

	void OnUnSpawn();

	void UnSpawn();
}
