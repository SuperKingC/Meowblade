using System;
using System.Diagnostics;
using System.IO;

namespace Shift.Legion.ClientApi;

public static class SerializeExtension
{
	private static readonly NetProtobufSerializer _netSerializer = new NetProtobufSerializer();

	private static readonly Stopwatch _sw = new Stopwatch();

	public static T Deserialize<T>(this byte[] data)
	{
		using MemoryStream memoryStream = MemoryStreamManager.GetStream();
		data.CopyToMemoryStream(memoryStream, 0, data.Length);
		_sw.Reset();
		_sw.Start();
		T result = (T)_netSerializer.Deserialize(memoryStream, null, typeof(T));
		_sw.Stop();
		return result;
	}

	public static object Deserialize(this byte[] data, Type type)
	{
		using MemoryStream memoryStream = MemoryStreamManager.GetStream();
		data.CopyToMemoryStream(memoryStream, 0, data.Length);
		return _netSerializer.Deserialize(memoryStream, null, type);
	}

	public static byte[] Serialize(this object instance)
	{
		using MemoryStream memoryStream = MemoryStreamManager.GetStream();
		_netSerializer.Serialize(memoryStream, instance);
		return memoryStream.GetBytes();
	}
}
