using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;

public class IslandShipDockInRecord
{
	private readonly Dictionary<int, List<Vec3>> _campSlotPos;

	private Dictionary<int, List<HashSet<int>>> _dockInRecords;

	public Vector3 IslandPos { get; }

	public IslandShipDockInRecord(int islandId)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandId);
		IslandPos = islandConfigData.Position;
		_campSlotPos = islandConfigData.CampSlotPos;
		InitDockInRecords(_campSlotPos);
	}

	private void InitDockInRecords(Dictionary<int, List<Vec3>> campSlots)
	{
		_dockInRecords = new Dictionary<int, List<HashSet<int>>>(4);
		foreach (KeyValuePair<int, List<Vec3>> campSlot in campSlots)
		{
			int count = campSlot.Value.Count;
			List<HashSet<int>> list = new List<HashSet<int>>(count);
			for (int i = 0; i < count; i++)
			{
				list.Add(new HashSet<int>());
			}
			_dockInRecords.Add(campSlot.Key, list);
		}
	}

	public void ClearShipDockInRecord(int entityId, int campId)
	{
		if (!_dockInRecords.TryGetValue(campId, out var value))
		{
			return;
		}
		foreach (HashSet<int> item in value)
		{
			if (item.Contains(entityId))
			{
				item.Remove(entityId);
				break;
			}
		}
	}

	public Vec3 GetShipDockInLastSlotPos(int entityId, int campId, int posIndex)
	{
		List<Vec3> list = _campSlotPos[campId];
		if (posIndex < 0 || posIndex >= list.Count)
		{
			return null;
		}
		_dockInRecords[campId][posIndex].Add(entityId);
		return list[posIndex];
	}

	public Vec3 GetShipDockInNewSlotPos(int entityId, int campId, out int posIndex)
	{
		posIndex = TryGetPosIndex(entityId, campId);
		return (posIndex != -1) ? GetShipDockInLastSlotPos(entityId, campId, posIndex) : RandomDockInPos(entityId, campId, out posIndex);
	}

	private int TryGetPosIndex(int entityId, int campId)
	{
		List<HashSet<int>> list = _dockInRecords[campId];
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].Contains(entityId))
			{
				return i;
			}
		}
		return -1;
	}

	private Vec3 RandomDockInPos(int entityId, int campId, out int posIndex)
	{
		List<int> emptySlot = GetEmptySlot(campId);
		List<Vec3> list = _campSlotPos[campId];
		if (emptySlot.Count == 0)
		{
			int index = Random.Range(0, list.Count - 1);
			Vec3 item = list[index];
			posIndex = list.IndexOf(item);
		}
		else
		{
			int index2 = Random.Range(0, emptySlot.Count - 1);
			posIndex = emptySlot[index2];
		}
		_dockInRecords[campId][posIndex].Add(entityId);
		return list[posIndex];
	}

	private List<int> GetEmptySlot(int campId)
	{
		List<int> list = new List<int>();
		List<HashSet<int>> list2 = _dockInRecords[campId];
		for (int i = 0; i < list2.Count; i++)
		{
			HashSet<int> hashSet = list2[i];
			if (hashSet.Count <= 0)
			{
				list.Add(i);
			}
		}
		return list;
	}
}
