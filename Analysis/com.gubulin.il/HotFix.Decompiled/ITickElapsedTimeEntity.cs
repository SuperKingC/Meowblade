public interface ITickElapsedTimeEntity
{
	TickElapsedTimeComponent tickElapsedTime { get; }

	bool hasTickElapsedTime { get; }

	void AddTickElapsedTime(float newValue);

	void ReplaceTickElapsedTime(float newValue);

	void RemoveTickElapsedTime();
}
