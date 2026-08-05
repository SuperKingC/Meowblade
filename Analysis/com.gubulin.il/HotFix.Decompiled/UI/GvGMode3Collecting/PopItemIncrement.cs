namespace UI.GvGMode3Collecting;

public struct PopItemIncrement
{
	public int Value { get; }

	public string ItemId { get; }

	public long LastSyncTime { get; }

	public PopItemIncrement(string itemId, int value, long lastSyncMilliseconds)
	{
		Value = value;
		ItemId = itemId;
		LastSyncTime = lastSyncMilliseconds / 1000;
	}
}
