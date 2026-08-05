using System;
using System.Collections.Generic;
using System.Reflection;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi;

public static class ProtocolHelper
{
	private static Dictionary<int, Type> _packetMap;

	private static Dictionary<int, Type> _packetResponseMap;

	public static Dictionary<int, Type> PacketMap
	{
		get
		{
			if (_packetMap == null)
			{
				_packetMap = new Dictionary<int, Type>();
				Type[] types = typeof(IPacketBody).Assembly.GetTypes();
				Type[] array = types;
				foreach (Type type in array)
				{
					if (type.GetCustomAttribute<ProtoContractAttribute>() != null)
					{
						object obj = Activator.CreateInstance(type);
						if (obj is IPacketBody packetBody && !type.Name.Contains("Response"))
						{
							_packetMap.Add(packetBody.PacketId, type);
						}
					}
				}
			}
			return _packetMap;
		}
	}

	public static Dictionary<int, Type> PacketResponseMap
	{
		get
		{
			if (_packetResponseMap == null)
			{
				_packetResponseMap = new Dictionary<int, Type>();
				Type[] types = typeof(IPacketBody).Assembly.GetTypes();
				Type[] array = types;
				foreach (Type type in array)
				{
					if (type.GetCustomAttribute<ProtoContractAttribute>() != null)
					{
						object obj = Activator.CreateInstance(type);
						if (obj is IPacketBody packetBody && type.Name.Contains("Response"))
						{
							_packetResponseMap.Add(packetBody.PacketId, type);
						}
					}
				}
			}
			return _packetResponseMap;
		}
	}
}
