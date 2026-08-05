using System.Collections.Generic;
using Assets.Scripts.Managers;
using GvG2.Common.Models;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GvG2;

public class MapDataManager
{
	private static WorldMapData _WorldMapData;

	private static Dictionary<int, string> _CampName;

	public Dictionary<string, Island> Islands_Dict;

	public Dictionary<int, Island> CampIslands_Dict;

	public List<int> OwnShipIds;

	private GameObject GvGWorldMap;

	public static WorldMapData WorldMapData
	{
		get
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			if (_WorldMapData == null)
			{
				string text = Addressables.LoadAssetAsync<TextAsset>((object)"GvG2/GvGWorldMapData").WaitForCompletion().text;
				_WorldMapData = JsonHelper.ToObject<WorldMapData>(text);
				foreach (IslandProps value in _WorldMapData.Islands_Dict.Values)
				{
					value.Name = LanguagesManager.GetDesc(value.Name);
				}
			}
			return _WorldMapData;
		}
	}

	public MapDataManager(GameObject GvGWorldMap, GvGMapRenderManager mapRenderManager)
	{
		this.GvGWorldMap = GvGWorldMap;
		Transform val = GvGWorldMap.transform.Find("Islands");
		BoxCollider[] componentsInChildren = ((Component)val).GetComponentsInChildren<BoxCollider>();
		Islands_Dict = new Dictionary<string, Island>();
		CampIslands_Dict = new Dictionary<int, Island>();
		BoxCollider[] array = componentsInChildren;
		foreach (BoxCollider val2 in array)
		{
			string name = ((Object)val2).name;
			Island island = new Island
			{
				Id = name,
				Props = WorldMapData.Islands_Dict[name],
				IslandObject = ((Component)((Component)val2).transform.parent).gameObject,
				Collider = (Collider)(object)val2
			};
			island.Init();
			mapRenderManager.AddNewCollider(name, (Collider)(object)val2, island);
			Islands_Dict.Add(name, island);
			if (island.Props.Type == IslandType.CampBase)
			{
				CampIslands_Dict.Add(island.Props.CampId, island);
			}
		}
	}

	public Island GetIslandById(string id)
	{
		if (Islands_Dict.TryGetValue(id, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError("找不到岛屿 Id = " + id);
		return null;
	}

	public Island GetCampIsland(int campId)
	{
		if (CampIslands_Dict.TryGetValue(campId, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError($"找不到大本营 CampId = {campId}");
		return null;
	}

	public static string GetCampIslandName(int campId)
	{
		if (_CampName == null)
		{
			_CampName = new Dictionary<int, string>();
			foreach (KeyValuePair<string, IslandProps> item in WorldMapData.Islands_Dict)
			{
				IslandProps value = item.Value;
				if (value.Type == IslandType.CampBase)
				{
					_CampName.Add(value.CampId, value.Name);
				}
			}
		}
		if (_CampName.TryGetValue(campId, out var value2))
		{
			return value2;
		}
		ILRuntimeDebug.LogError($"找不到大本营 CampId = {campId}");
		return "";
	}

	public NavLineProps GetNavLine(int headId, int tailId)
	{
		string text = $"{headId}_{tailId}";
		if (WorldMapData.NavLine_Dict.TryGetValue(text, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError("找不到航线 id = " + text);
		return null;
	}

	internal void ShowCampIslandOnly(Island myCamp)
	{
		((Component)GvGWorldMap.transform.Find("Lines")).gameObject.SetActive(false);
		Transform val = GvGWorldMap.transform.Find("Islands");
		for (int i = 0; i < val.childCount; i++)
		{
			Transform child = val.GetChild(i);
			((Component)child).gameObject.SetActive(((Object)child).name == myCamp.Id);
		}
	}

	internal void ShowAllIsland()
	{
		((Component)GvGWorldMap.transform.Find("Lines")).gameObject.SetActive(true);
		Transform val = GvGWorldMap.transform.Find("Islands");
		for (int i = 0; i < val.childCount; i++)
		{
			((Component)val.GetChild(i)).gameObject.SetActive(true);
		}
	}
}
