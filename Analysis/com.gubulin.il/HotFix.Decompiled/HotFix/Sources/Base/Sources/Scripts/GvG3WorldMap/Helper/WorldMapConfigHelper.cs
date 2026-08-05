using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.QuadTree;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;

public static class WorldMapConfigHelper
{
	private class GroupConfig
	{
		public int StepIdx;

		public List<int> IslandIds;
	}

	public class SpecialSuppressIslandConfig
	{
		private static SpecialSuppressIslandConfig _config;

		public List<string> SpecialSuppressIsland;

		public static SpecialSuppressIslandConfig GetConfig()
		{
			if (_config == null)
			{
				_config = "SpecialSuppressIslandConfig".ToConfiguration<SpecialSuppressIslandConfig>();
			}
			return _config;
		}
	}

	public const string SkyIsland1 = "SkyIsland";

	public const string SkyIsland2 = "SkyIsland_VoidBrawl";

	private static bool _IsLoaded;

	private static Dictionary<int, CampPrefabConfigModel> _CampPrefabConfigs_Dict;

	private static WorldMapConfigModel _Configs;

	private static Dictionary<string, GvGMode3DefenderZone> _gvGMode3DefenderZoneConfigs;

	private static Dictionary<string, Dictionary<string, List<IslandDisplayReward>>> _gvGMode3DisplayRewardConfigs;

	public static bool IsLoaded => _IsLoaded;

	public static int CurUserId => GameController.Contexts.gameState.user.value.UserId;

	public static Dictionary<int, CampPrefabConfigModel> CampPrefabConfigs_Dict
	{
		get
		{
			if (_CampPrefabConfigs_Dict == null)
			{
				_CampPrefabConfigs_Dict = new Dictionary<int, CampPrefabConfigModel>();
				Dictionary<string, CampPrefabConfigModel> dictionary = "GVG_MODE3_CAMP_PREFABS".ToConfiguration<Dictionary<string, CampPrefabConfigModel>>();
				foreach (KeyValuePair<string, CampPrefabConfigModel> item in dictionary)
				{
					int key = int.Parse(item.Key);
					_CampPrefabConfigs_Dict.Add(key, item.Value);
				}
			}
			return _CampPrefabConfigs_Dict;
		}
	}

	public static WorldMapConfigModel Configs => _Configs;

	public static void Init(string _IZConfigId, Action onLoaded = null)
	{
		if (_Configs != null && _Configs.IZConfigId == _IZConfigId)
		{
			onLoaded?.Invoke();
		}
		else
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(InitCoroutine(_IZConfigId, onLoaded));
		}
	}

	public static IEnumerator InitCoroutine(string _IZConfigId, Action onLoaded = null)
	{
		if (_Configs != null && _Configs.IZConfigId == _IZConfigId)
		{
			yield break;
		}
		_IsLoaded = false;
		AsyncOperationHandle<TextAsset> handler = Addressables.LoadAssetAsync<TextAsset>((object)("GvG/GvGWorldMapData_" + _IZConfigId));
		yield return handler;
		if ((int)handler.Status != 1)
		{
			ILRuntimeDebug.LogError("[WorldMapConfigHelper] Addressables 无法加载文件 GvG/GvGWorldMapData_" + _IZConfigId);
			yield break;
		}
		string json = handler.Result.text;
		Addressables.Release<TextAsset>(handler);
		WorldMapData worldMapData = null;
		Task<WorldMapData> task = Task.Run(() => worldMapData = JsonHelper.ToObject<WorldMapData>(json));
		while (!task.IsCanceled && !task.IsCompleted && worldMapData == null)
		{
			yield return null;
		}
		_Configs = new WorldMapConfigModel();
		_Configs.IZConfigId = _IZConfigId;
		_Configs.SpriteGroupConfigs = worldMapData.SpriteGroupConfigs;
		_Configs.DecoGroupConfigs = worldMapData.DecoGroupConfigs;
		_Configs.CampIds = new List<int>(CampPrefabConfigs_Dict.Keys);
		_Configs.GroupInfos = new Dictionary<int, WorldMapConfigModel.MapGroupInfo>();
		InitConfigBrawlEvent(_IZConfigId);
		List<GroupConfig> regionConfig = (_IZConfigId + "_CameraIslands").ToConfiguration<List<GroupConfig>>();
		Rect maxRect = Rect.MinMaxRect(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);
		bool useQuadTree = true;
		List<string> specialSuppressIsland = SpecialSuppressIslandConfig.GetConfig().SpecialSuppressIsland;
		foreach (KeyValuePair<string, IslandProps> item in worldMapData.Islands_Dict)
		{
			IslandProps prop = item.Value;
			float xMin = prop.X - prop.S_ColX * 0.5f;
			float xMax = xMin + prop.S_ColX;
			float yMin = prop.Z - prop.S_ColZ * 0.5f;
			float yMax = yMin + prop.S_ColZ;
			IslandConfigData data = new IslandConfigData
			{
				Props = prop,
				Position = new Vector3(prop.X, 0f, prop.Z),
				ViewRect = Rect.MinMaxRect(xMin, yMin, xMax, yMax),
				ColliderScale = new Vector3(prop.S_ColX, 1f, prop.S_ColZ),
				PlaneScale = new Vector3(prop.S, 1f, prop.S),
				PlaneRotation = Quaternion.AngleAxis(prop.Ang_Model, Vector3.up),
				CampAreaScale = new Vector3(prop.CampAreaSize, 1f, prop.CampAreaSize),
				FogAreaScale = new Vector3(prop.FogAreaSize, 1f, prop.FogAreaSize),
				CampSlotPos = GetCampSlotPos(prop.SpriteGroup),
				Name = GetIslandName(_IZConfigId, prop.Id),
				Pos2D = new Vec2(prop.X, prop.Z)
			};
			_Configs.Islands_List.Add(data);
			_Configs.Islands_Dict.Add(prop.Id, data);
			if (data.IsHiddenIsland)
			{
				_Configs.HiddenIslands.Add(data);
			}
			if (specialSuppressIsland.Contains(data.Props.GDEData.Key))
			{
				_Configs.SpecialSuppressIslandIds.Add(prop.Id);
				_Configs.SpecialSuppressIslands.Add(data);
			}
			if (data.Props.Type == eIslandType.MainMoon && !_Configs.MainIslandsDict.ContainsKey(data.Props.CampId))
			{
				_Configs.MainIslandsDict[data.Props.CampId] = prop.Id;
			}
			if (useQuadTree)
			{
				if (xMin < ((Rect)(ref maxRect)).xMin)
				{
					((Rect)(ref maxRect)).xMin = xMin;
				}
				if (yMin < ((Rect)(ref maxRect)).yMin)
				{
					((Rect)(ref maxRect)).yMin = yMin;
				}
				if (xMax > ((Rect)(ref maxRect)).xMax)
				{
					((Rect)(ref maxRect)).xMax = xMax;
				}
				if (yMax > ((Rect)(ref maxRect)).yMax)
				{
					((Rect)(ref maxRect)).yMax = yMax;
				}
			}
			if (LoadingHelper.ShouldYield_EnterIZ())
			{
				yield return null;
			}
		}
		foreach (GroupConfig config in regionConfig)
		{
			WorldMapConfigModel.MapGroupInfo groupInfo = new WorldMapConfigModel.MapGroupInfo
			{
				Index = config.StepIdx
			};
			Rect viewRect = Rect.MinMaxRect(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);
			foreach (int islandId in config.IslandIds)
			{
				IslandConfigData island = _Configs.TryGetIsland(islandId);
				((Rect)(ref viewRect)).xMin = Mathf.Min(((Rect)(ref viewRect)).xMin, island.Position.x);
				((Rect)(ref viewRect)).yMin = Mathf.Min(((Rect)(ref viewRect)).yMin, island.Position.z);
				((Rect)(ref viewRect)).xMax = Mathf.Max(((Rect)(ref viewRect)).xMax, island.Position.x);
				((Rect)(ref viewRect)).yMax = Mathf.Max(((Rect)(ref viewRect)).yMax, island.Position.z);
			}
			groupInfo.ViewRect = viewRect;
			_Configs.GroupInfos.Add(groupInfo.Index, groupInfo);
		}
		foreach (KeyValuePair<string, NavLineProps> item2 in worldMapData.NavLine_Dict)
		{
			NavLineProps prop2 = item2.Value;
			Vector3 headPos = prop2.Pts[0].Vec;
			Vector3 tailPos = prop2.Pts[prop2.Pts.Count - 1].Vec;
			Vector3 val = tailPos - headPos;
			Vector3 dir = ((Vector3)(ref val)).normalized;
			NavLineConfigData data2 = new NavLineConfigData
			{
				Props = prop2,
				Dir = dir,
				Start = headPos,
				ViewRect = Rect.MinMaxRect(Mathf.Min(headPos.x, tailPos.x), Mathf.Min(headPos.z, tailPos.z), Mathf.Max(headPos.x, tailPos.x), Mathf.Max(headPos.z, tailPos.z)),
				Center = new Vec2(dir.x / 2f + headPos.x, dir.z / 2f + headPos.z),
				Scale = new Vector3(prop2.Len, 1f, 1f),
				Rotation = Quaternion.FromToRotation(Vector3.right, dir)
			};
			_Configs.NavLine_List.Add(data2);
			_Configs.NavLine_Dict.Add(prop2.Id, data2);
			if (LoadingHelper.ShouldYield_EnterIZ())
			{
				yield return null;
			}
		}
		if (useQuadTree)
		{
			yield return GenerateQuadTree(maxRect);
		}
		GDEGvGMode3CampMissionData missionData = GDMgr.Get<GDEGvGMode3CampMissionData>("GCM_PLAYERCOMMAND");
		_Configs.PlayerCommandConfig = JsonHelper.ToObject<SubTypeModel_PlayerCommand>(missionData.SubTypeData);
		_Configs.PlayerCommandContribLevel = new List<float>();
		foreach (KeyValuePair<string, float> kv in _Configs.PlayerCommandConfig.ContributionPointAdd)
		{
			_Configs.PlayerCommandContribLevel.Add(kv.Value);
		}
		_Configs.PlayerCommandContribLevel.Sort();
		_IsLoaded = true;
		onLoaded?.Invoke();
	}

	private static IEnumerator GenerateQuadTree(Rect maxRect)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		maxRect = new Rect(((Rect)(ref maxRect)).position - Vector2.one, ((Rect)(ref maxRect)).size + Vector2.one * 2f);
		_Configs.QuadTree = new SparseVoxelQuadTree<int>(maxRect, 7);
		foreach (IslandConfigData island in _Configs.Islands_List)
		{
			_Configs.QuadTree.Insert(island.ViewRect, island.Props.Id);
			if (LoadingHelper.ShouldYield_EnterIZ())
			{
				yield return null;
			}
		}
	}

	private static Dictionary<int, List<Vec3>> GetCampSlotPos(string spriteGroup)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		string[] array = spriteGroup.Split('_');
		string text = array[0] + "_" + array[1];
		if (_Configs.Sprite_CampSlotPos.TryGetValue(text, out var value))
		{
			return value;
		}
		AsyncOperationHandle<GameObject> val = Addressables.LoadAssetAsync<GameObject>((object)("GvG/IslandSlot/" + text + ".slots.prefab"));
		Transform transform = val.WaitForCompletion().transform;
		value = new Dictionary<int, List<Vec3>>();
		foreach (int campId in _Configs.CampIds)
		{
			List<Vec3> list = new List<Vec3>();
			value.Add(campId, list);
			Transform val2 = transform.Find($"Camp_{campId}");
			for (int i = 0; i < val2.childCount; i++)
			{
				Transform child = val2.GetChild(i);
				Vector3 val3 = child.localPosition + val2.localPosition;
				list.Add(new Vec3(val3.x, val3.y, val3.z));
			}
		}
		Addressables.Release<GameObject>(val);
		_Configs.Sprite_CampSlotPos.Add(text, value);
		return value;
	}

	public static GvGMode3DefenderZone GetGvGMode3DefenderZoneConfigs(int islandId)
	{
		string mapId = Configs.TryGetIsland(islandId).Props.MapId;
		if (_gvGMode3DefenderZoneConfigs == null)
		{
			_gvGMode3DefenderZoneConfigs = new Dictionary<string, GvGMode3DefenderZone>();
		}
		if (!_gvGMode3DefenderZoneConfigs.TryGetValue(mapId, out var value))
		{
			GDEGvGIslandMapConfigData gDEGvGIslandMapConfigData = GDMgr.Get<GDEGvGIslandMapConfigData>(mapId) ?? throw new Exception("GetGvGMode3DefenderZoneConfigs error, Key=$" + mapId);
			value = JsonHelper.ToObject<GvGMode3DefenderZone>(gDEGvGIslandMapConfigData.DefenderZone);
			_gvGMode3DefenderZoneConfigs.Add(gDEGvGIslandMapConfigData.Key, value);
		}
		return value;
	}

	public static Dictionary<string, List<IslandDisplayReward>> GetGvGMode3DisplayRewardConfigs(int islandId)
	{
		if (_gvGMode3DisplayRewardConfigs == null)
		{
			_gvGMode3DisplayRewardConfigs = new Dictionary<string, Dictionary<string, List<IslandDisplayReward>>>();
		}
		string mapId = Configs.TryGetIsland(islandId).Props.MapId;
		if (!_gvGMode3DisplayRewardConfigs.TryGetValue(mapId, out var value))
		{
			GDEGvGIslandMapConfigData gDEGvGIslandMapConfigData = GDMgr.Get<GDEGvGIslandMapConfigData>(mapId) ?? throw new Exception("GetGvGMode3DefenderZoneConfigs error, Key=$" + mapId);
			value = (string.IsNullOrEmpty(gDEGvGIslandMapConfigData.DisplayReward) ? null : JsonHelper.ToObject<Dictionary<string, List<IslandDisplayReward>>>(gDEGvGIslandMapConfigData.DisplayReward));
			if (value != null)
			{
				_gvGMode3DisplayRewardConfigs.Add(mapId, value);
			}
		}
		return value;
	}

	public static CampPrefabConfigModel TryGetCampPrefabConfig(int campId)
	{
		if (CampPrefabConfigs_Dict.TryGetValue(campId, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError($"[TryGetCampPrefabConfig] 找不到 campId={campId} 的配置");
		throw new Exception($"[TryGetCampPrefabConfig] 找不到 campId={campId} 的配置");
	}

	public static string GetIslandName(string iZConfigId, int islandId)
	{
		return $"IslandName_{iZConfigId}_{islandId}".ToLanguage();
	}

	public static string GetCurIZIslandName(int islandId)
	{
		return GetIslandName(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId, islandId);
	}

	public static string GetDeco(IslandProps islandProps, int izid)
	{
		int seed = izid * 1000000 + islandProps.Id * 100;
		return GetRandomPrefabFromGroup(_Configs.DecoGroupConfigs, islandProps.DecoGroup, seed);
	}

	public static string GetSprite(IslandProps islandProps, int izid)
	{
		int seed = izid * 1000000 + islandProps.Id * 100 + 1;
		return GetRandomPrefabFromGroup(_Configs.SpriteGroupConfigs, islandProps.SpriteGroup, seed);
	}

	public static string GetRandomPrefabFromGroup(Dictionary<string, List<string>> groupConfig, string groupName, int seed)
	{
		if (!groupConfig.TryGetValue(groupName, out var value))
		{
			throw new Exception("[WorldMapConfigHelper] 找不到面片组 groupName=" + groupName);
		}
		if (value.Count == 0)
		{
			return null;
		}
		Random random = new Random(seed);
		string text = value[random.Next(0, value.Count)];
		if (text == "Empty")
		{
			text = null;
		}
		return text;
	}

	private static void InitConfigBrawlEvent(string _IZConfigId)
	{
		if (IsBrawlFightEvent(_IZConfigId))
		{
			_Configs.BrawlEventBaseInfos = "GvGMode3BrawlEvent_BaseInfos".ToConfiguration<List<GvGMode3BrawlEvent_BaseInfo>>();
		}
	}

	public static bool IsBrawlFightEvent(string izId)
	{
		return izId == "SkyIsland_VoidBrawl";
	}
}
