public interface IIdEntity
{
	IdComponent id { get; }

	bool hasId { get; }

	void AddId(int newValue);

	void ReplaceId(int newValue);

	void RemoveId();
}
