namespace Shift.Legion.ClientApi.RPC;

public static class SerializeExtension
{
	public static T As<T>(this byte[] data)
	{
		return data.Deserialize<T>();
	}
}
