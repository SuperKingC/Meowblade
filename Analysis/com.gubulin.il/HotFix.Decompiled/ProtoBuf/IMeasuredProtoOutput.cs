namespace ProtoBuf;

public interface IMeasuredProtoOutput<TOutput> : IProtoOutput<TOutput>
{
	MeasureState<T> Measure<T>(T value, object userState = null);

	void Serialize<T>(MeasureState<T> measured, TOutput destination);
}
