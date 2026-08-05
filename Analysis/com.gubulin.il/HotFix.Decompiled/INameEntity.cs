public interface INameEntity
{
	NameComponent name { get; }

	bool hasName { get; }

	void AddName(string newValue);

	void ReplaceName(string newValue);

	void RemoveName();
}
