using System;
using System.Collections.Generic;
using ILRuntime_LitJson;
using Shift.Legion.Common.Managers;

namespace GvG3;

public class MockPushManager
{
	private Dictionary<string, List<(int, string)>> Group_int;

	private Dictionary<string, List<(SocketManager.ePackageId, string)>> Group_enum;

	private void EnsureInit()
	{
		if (Group_int == null)
		{
			Group_int = new Dictionary<string, List<(int, string)>>();
			Group_enum = new Dictionary<string, List<(SocketManager.ePackageId, string)>>();
		}
	}

	public void AddToGroup(string groupName, int packageId, string json)
	{
		EnsureInit();
		if (!Group_int.ContainsKey(groupName))
		{
			Group_int.Add(groupName, new List<(int, string)>());
		}
		Group_int[groupName].Add((packageId, json));
	}

	public void AddToGroup(string groupName, SocketManager.ePackageId packageId, string json)
	{
		EnsureInit();
		if (!Group_enum.ContainsKey(groupName))
		{
			Group_enum.Add(groupName, new List<(SocketManager.ePackageId, string)>());
		}
		Group_enum[groupName].Add((packageId, json));
	}

	public void Push(SocketManager.ePackageId packageId, string json)
	{
		Push((int)packageId, json);
	}

	public void Push(int packageId, string json)
	{
		if (SocketManager.Map_PackageId_PackageIdTypes.TryGetValue(packageId, out var value))
		{
			SocketManager.BaseSocketPackageBodyContext baseSocketPackageBodyContext = Activator.CreateInstance(value.BaseBodyContext) as SocketManager.BaseSocketPackageBodyContext;
			SocketManager.BaseSocketPackageBody req = JsonMapper.ToObject(json, value.Request) as SocketManager.BaseSocketPackageBody;
			baseSocketPackageBodyContext.Req = req;
			baseSocketPackageBodyContext.OnPush();
		}
	}

	public void Push(SocketManager.ePackageId packageId, SocketManager.BaseSocketPackageBody reqBody)
	{
		if (SocketManager.Map_PackageId_PackageIdTypes.TryGetValue((int)packageId, out var value))
		{
			SocketManager.BaseSocketPackageBodyContext baseSocketPackageBodyContext = Activator.CreateInstance(value.BaseBodyContext) as SocketManager.BaseSocketPackageBodyContext;
			baseSocketPackageBodyContext.Req = reqBody;
			baseSocketPackageBodyContext.OnPush();
		}
	}

	public void PushGroup(string groupName)
	{
		if (Group_int.TryGetValue(groupName, out var value))
		{
			foreach (var item in value)
			{
				Push(item.Item1, item.Item2);
			}
		}
		if (!Group_enum.TryGetValue(groupName, out var value2))
		{
			return;
		}
		foreach (var item2 in value2)
		{
			Push(item2.Item1, item2.Item2);
		}
	}
}
