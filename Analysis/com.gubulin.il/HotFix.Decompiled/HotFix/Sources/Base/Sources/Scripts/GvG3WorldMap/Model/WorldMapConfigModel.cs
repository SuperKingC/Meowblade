using System;
using System.Collections.Generic;
using Assets.QuadTree;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class WorldMapConfigModel
{
	public class MapGroupInfo
	{
		public int Index;

		public Rect ViewRect;
	}

	public string IZConfigId = "";

	public List<IslandConfigData> Islands_List = new List<IslandConfigData>();

	public List<IslandConfigData> HiddenIslands = new List<IslandConfigData>();

	public HashSet<int> SpecialSuppressIslandIds = new HashSet<int>();

	public List<IslandConfigData> SpecialSuppressIslands = new List<IslandConfigData>();

	public List<NavLineConfigData> NavLine_List = new List<NavLineConfigData>();

	public Dictionary<int, IslandConfigData> Islands_Dict = new Dictionary<int, IslandConfigData>();

	public Dictionary<int, int> MainIslandsDict = new Dictionary<int, int>(4);

	public Dictionary<string, NavLineConfigData> NavLine_Dict = new Dictionary<string, NavLineConfigData>();

	public Dictionary<int, CampPrefabConfigModel> CampPrefab_Dict = new Dictionary<int, CampPrefabConfigModel>();

	public Dictionary<string, Dictionary<int, List<Vec3>>> Sprite_CampSlotPos = new Dictionary<string, Dictionary<int, List<Vec3>>>();

	public List<int> CampIds = new List<int>();

	public Dictionary<string, List<string>> SpriteGroupConfigs = new Dictionary<string, List<string>>();

	public Dictionary<string, List<string>> DecoGroupConfigs = new Dictionary<string, List<string>>();

	public SparseVoxelQuadTree<int> QuadTree;

	public SubTypeModel_PlayerCommand PlayerCommandConfig;

	public List<float> PlayerCommandContribLevel;

	public Dictionary<int, MapGroupInfo> GroupInfos;

	public List<GvGMode3BrawlEvent_BaseInfo> BrawlEventBaseInfos = new List<GvGMode3BrawlEvent_BaseInfo>();

	public int BrawlEventFinalStartDay => TryGetBrawlEvent(100).Day;

	public int BrawlEventFinalEndDay => TryGetBrawlEvent(101).EndDay;

	private T TryGet<T, K>(Dictionary<K, T> dict, K id)
	{
		if (dict.TryGetValue(id, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError($"[WorldMapConfigModel] 找不到 id = {id} 的 {typeof(T).Name}");
		throw new Exception($"[WorldMapConfigModel] 找不到 id = {id} 的 {typeof(T).Name}");
	}

	public NavLineConfigData TryGetNavLine(int headId, int tailId)
	{
		return TryGet(NavLine_Dict, $"{headId}_{tailId}");
	}

	public NavLineConfigData TryGetNavLine(string lineId)
	{
		return TryGet(NavLine_Dict, lineId);
	}

	public IslandConfigData TryGetIsland(int islandId)
	{
		return TryGet(Islands_Dict, islandId);
	}

	public MapGroupInfo GetGroupInfo(int groupId)
	{
		return TryGet(GroupInfos, groupId);
	}

	public GvGMode3BrawlEvent_BaseInfo TryGetBrawlEvent(int stepIdx)
	{
		return BrawlEventBaseInfos.Find((GvGMode3BrawlEvent_BaseInfo x) => x.StepIdx == stepIdx);
	}

	public GvGMode3BrawlEvent_BaseInfo TryGetBrawlEventByDay(int day)
	{
		GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = null;
		foreach (GvGMode3BrawlEvent_BaseInfo brawlEventBaseInfo in BrawlEventBaseInfos)
		{
			if (brawlEventBaseInfo.Day <= day && (gvGMode3BrawlEvent_BaseInfo == null || brawlEventBaseInfo.Day > gvGMode3BrawlEvent_BaseInfo.Day))
			{
				gvGMode3BrawlEvent_BaseInfo = brawlEventBaseInfo;
			}
		}
		return gvGMode3BrawlEvent_BaseInfo;
	}

	public bool IsBrawlEvent()
	{
		return WorldMapConfigHelper.IsBrawlFightEvent(IZConfigId);
	}
}
