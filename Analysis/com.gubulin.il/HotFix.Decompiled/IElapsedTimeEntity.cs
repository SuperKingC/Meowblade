public interface IElapsedTimeEntity
{
	ElapsedTimeComponent elapsedTime { get; }

	bool hasElapsedTime { get; }

	void AddElapsedTime(float newValue);

	void ReplaceElapsedTime(float newValue);

	void RemoveElapsedTime();
}
