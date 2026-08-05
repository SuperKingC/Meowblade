public interface IDurationEntity
{
	DurationComponent duration { get; }

	bool hasDuration { get; }

	void AddDuration(float newValue);

	void ReplaceDuration(float newValue);

	void RemoveDuration();
}
