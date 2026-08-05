namespace ProtoBuf;

public interface IProtoOutput<TOutput>
{
	void Serialize<T>(TOutput destination, T value, object userState = null);
}
