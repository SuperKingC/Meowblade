public interface ITickIntervalEntity
{
	TickIntervalComponent tickInterval { get; }

	bool hasTickInterval { get; }

	void AddTickInterval(float newValue);

	void ReplaceTickInterval(float newValue);

	void RemoveTickInterval();
}
