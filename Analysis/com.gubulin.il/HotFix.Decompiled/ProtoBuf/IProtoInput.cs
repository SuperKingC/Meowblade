namespace ProtoBuf;

public interface IProtoInput<TInput>
{
	T Deserialize<T>(TInput source, T value = default(T), object userState = null);
}
