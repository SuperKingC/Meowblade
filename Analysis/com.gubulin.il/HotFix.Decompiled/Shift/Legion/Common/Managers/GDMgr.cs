using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using FairyGUI;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Shift.Legion.Common.Managers;

public static class GDMgr
{
	private class GDEInfoMultiMode<T>
	{
		public string FolderName;

		public Dictionary<string, T> Cache;

		public GDEInfoMultiMode(string _FolderName)
		{
			FolderName = _FolderName;
			Cache = new Dictionary<string, T>();
		}
	}

	private class GDEInfo
	{
		public string id;

		public Type type;

		public Type loader_type;

		public GDEInfo(string _id, Type _type, Type _loader_type)
		{
			id = _id;
			type = _type;
			loader_type = _loader_type;
		}
	}

	private static Dictionary<string, AsyncOperationHandle<TextAsset>> ab_Cache = new Dictionary<string, AsyncOperationHandle<TextAsset>>();

	public static ConcurrentQueue<ReleaseHandler> WaitToRelease = new ConcurrentQueue<ReleaseHandler>();

	private static Dictionary<Type, object> TypeCache_MultiMode = new Dictionary<Type, object>
	{
		{
			typeof(GDEAbilityData),
			new GDEInfoMultiMode<GDEAbilityData>("GDEAbilityData")
		},
		{
			typeof(GDELevelBonusData),
			new GDEInfoMultiMode<GDELevelBonusData>("GDELevelBonusData")
		},
		{
			typeof(GDELevelData),
			new GDEInfoMultiMode<GDELevelData>("GDELevelData")
		},
		{
			typeof(GDEPrizePoolData),
			new GDEInfoMultiMode<GDEPrizePoolData>("GDEPrizePoolData")
		},
		{
			typeof(GDESoldierData),
			new GDEInfoMultiMode<GDESoldierData>("GDESoldierData")
		},
		{
			typeof(GDEStoreContentConfigData),
			new GDEInfoMultiMode<GDEStoreContentConfigData>("GDEStoreContentConfigData")
		},
		{
			typeof(GDEStoryData),
			new GDEInfoMultiMode<GDEStoryData>("GDEStoryData")
		},
		{
			typeof(GDERankConfigData),
			new GDEInfoMultiMode<GDERankConfigData>("GDERankConfigData")
		},
		{
			typeof(GDEFormulaData),
			new GDEInfoMultiMode<GDEFormulaData>("GDEFormulaData")
		}
	};

	private static Dictionary<string, GDEInfo> TypeCache = new Dictionary<string, GDEInfo>
	{
		{
			"GDEActivityDataContainer",
			new GDEInfo("GDEActivityData", typeof(GDEActivityData), typeof(GDEActivityDataLoader))
		},
		{
			"GDEAchievementDataContainer",
			new GDEInfo("GDEAchievementData", typeof(GDEAchievementData), typeof(GDEAchievementDataLoader))
		},
		{
			"GDEAnimationDataContainer",
			new GDEInfo("GDEAnimationData", typeof(GDEAnimationData), typeof(GDEAnimationDataLoader))
		},
		{
			"GDEBreakthroughDataContainer",
			new GDEInfo("GDEBreakthroughData", typeof(GDEBreakthroughData), typeof(GDEBreakthroughDataLoader))
		},
		{
			"GDEBuildingDataContainer",
			new GDEInfo("GDEBuildingData", typeof(GDEBuildingData), typeof(GDEBuildingDataLoader))
		},
		{
			"GDEBuildingEvoDataContainer",
			new GDEInfo("GDEBuildingEvoData", typeof(GDEBuildingEvoData), typeof(GDEBuildingEvoDataLoader))
		},
		{
			"GDEChapterDataContainer",
			new GDEInfo("GDEChapterData", typeof(GDEChapterData), typeof(GDEChapterDataLoader))
		},
		{
			"GDEConfigurationDataContainer",
			new GDEInfo("GDEConfigurationData", typeof(GDEConfigurationData), typeof(GDEConfigurationDataLoader))
		},
		{
			"GDECrowdControlDataContainer",
			new GDEInfo("GDECrowdControlData", typeof(GDECrowdControlData), typeof(GDECrowdControlDataLoader))
		},
		{
			"GDEDungeonExperienceDataContainer",
			new GDEInfo("GDEDungeonExperienceData", typeof(GDEDungeonExperienceData), typeof(GDEDungeonExperienceDataLoader))
		},
		{
			"GDEDynamicPrizePoolDataContainer",
			new GDEInfo("GDEDynamicPrizePoolData", typeof(GDEDynamicPrizePoolData), typeof(GDEDynamicPrizePoolDataLoader))
		},
		{
			"GDEFormationDataContainer",
			new GDEInfo("GDEFormationData", typeof(GDEFormationData), typeof(GDEFormationDataLoader))
		},
		{
			"GDEFormationUnlockDataContainer",
			new GDEInfo("GDEFormationUnlockData", typeof(GDEFormationUnlockData), typeof(GDEFormationUnlockDataLoader))
		},
		{
			"GDEGuideScriptDataContainer",
			new GDEInfo("GDEGuideScriptData", typeof(GDEGuideScriptData), typeof(GDEGuideScriptDataLoader))
		},
		{
			"GDEInfoEvoDataContainer",
			new GDEInfo("GDEInfoEvoData", typeof(GDEInfoEvoData), typeof(GDEInfoEvoDataLoader))
		},
		{
			"GDEInvitingConfigDataContainer",
			new GDEInfo("GDEInvitingConfigData", typeof(GDEInvitingConfigData), typeof(GDEInvitingConfigDataLoader))
		},
		{
			"GDEItemDataContainer",
			new GDEInfo("GDEItemData", typeof(GDEItemData), typeof(GDEItemDataLoader))
		},
		{
			"GDELanguagesDataContainer",
			new GDEInfo("GDELanguagesData", typeof(GDELanguagesData), typeof(GDELanguagesDataLoader))
		},
		{
			"GDELegendItemChangePropsCostDataContainer",
			new GDEInfo("GDELegendItemChangePropsCostData", typeof(GDELegendItemChangePropsCostData), typeof(GDELegendItemChangePropsCostDataLoader))
		},
		{
			"GDELegendItemDataContainer",
			new GDEInfo("GDELegendItemData", typeof(GDELegendItemData), typeof(GDELegendItemDataLoader))
		},
		{
			"GDELegendItemEnhancementDataContainer",
			new GDEInfo("GDELegendItemEnhancementData", typeof(GDELegendItemEnhancementData), typeof(GDELegendItemEnhancementDataLoader))
		},
		{
			"GDELegendItemPropertyDataContainer",
			new GDEInfo("GDELegendItemPropertyData", typeof(GDELegendItemPropertyData), typeof(GDELegendItemPropertyDataLoader))
		},
		{
			"GDELotteryCaseDataContainer",
			new GDEInfo("GDELotteryCaseData", typeof(GDELotteryCaseData), typeof(GDELotteryCaseDataLoader))
		},
		{
			"GDEMapFXDataContainer",
			new GDEInfo("GDEMapFXData", typeof(GDEMapFXData), typeof(GDEMapFXDataLoader))
		},
		{
			"GDEMissionDataContainer",
			new GDEInfo("GDEMissionData", typeof(GDEMissionData), typeof(GDEMissionDataLoader))
		},
		{
			"GDEMissionSerialDataContainer",
			new GDEInfo("GDEMissionSerialData", typeof(GDEMissionSerialData), typeof(GDEMissionSerialDataLoader))
		},
		{
			"GDEModifierDataContainer",
			new GDEInfo("GDEModifierData", typeof(GDEModifierData), typeof(GDEModifierDataLoader))
		},
		{
			"GDEPiecesDataContainer",
			new GDEInfo("GDEPiecesData", typeof(GDEPiecesData), typeof(GDEPiecesDataLoader))
		},
		{
			"GDEPrizePoolComboDataContainer",
			new GDEInfo("GDEPrizePoolComboData", typeof(GDEPrizePoolComboData), typeof(GDEPrizePoolComboDataLoader))
		},
		{
			"GDEProductDataContainer",
			new GDEInfo("GDEProductData", typeof(GDEProductData), typeof(GDEProductDataLoader))
		},
		{
			"GDEProductEvoDataContainer",
			new GDEInfo("GDEProductEvoData", typeof(GDEProductEvoData), typeof(GDEProductEvoDataLoader))
		},
		{
			"GDEProjectileDataContainer",
			new GDEInfo("GDEProjectileData", typeof(GDEProjectileData), typeof(GDEProjectileDataLoader))
		},
		{
			"GDERecycleProductDataContainer",
			new GDEInfo("GDERecycleProductData", typeof(GDERecycleProductData), typeof(GDERecycleProductDataLoader))
		},
		{
			"GDERegionDataContainer",
			new GDEInfo("GDERegionData", typeof(GDERegionData), typeof(GDERegionDataLoader))
		},
		{
			"GDESignInSerialDataContainer",
			new GDEInfo("GDESignInSerialData", typeof(GDESignInSerialData), typeof(GDESignInSerialDataLoader))
		},
		{
			"GDESimplePoolDataContainer",
			new GDEInfo("GDESimplePoolData", typeof(GDESimplePoolData), typeof(GDESimplePoolDataLoader))
		},
		{
			"GDESoldierEvoDataContainer",
			new GDEInfo("GDESoldierEvoData", typeof(GDESoldierEvoData), typeof(GDESoldierEvoDataLoader))
		},
		{
			"GDESoldierExperienceDataContainer",
			new GDEInfo("GDESoldierExperienceData", typeof(GDESoldierExperienceData), typeof(GDESoldierExperienceDataLoader))
		},
		{
			"GDESoldierFormationDataContainer",
			new GDEInfo("GDESoldierFormationData", typeof(GDESoldierFormationData), typeof(GDESoldierFormationDataLoader))
		},
		{
			"GDESoldierItemSlotConfigDataContainer",
			new GDEInfo("GDESoldierItemSlotConfigData", typeof(GDESoldierItemSlotConfigData), typeof(GDESoldierItemSlotConfigDataLoader))
		},
		{
			"GDESoldierPotentialDataContainer",
			new GDEInfo("GDESoldierPotentialData", typeof(GDESoldierPotentialData), typeof(GDESoldierPotentialDataLoader))
		},
		{
			"GDESoldierProductDataContainer",
			new GDEInfo("GDESoldierProductData", typeof(GDESoldierProductData), typeof(GDESoldierProductDataLoader))
		},
		{
			"GDEStoreCategoryDataContainer",
			new GDEInfo("GDEStoreCategoryData", typeof(GDEStoreCategoryData), typeof(GDEStoreCategoryDataLoader))
		},
		{
			"GDEStorehouseDataContainer",
			new GDEInfo("GDEStorehouseData", typeof(GDEStorehouseData), typeof(GDEStorehouseDataLoader))
		},
		{
			"GDEStoryScriptDataContainer",
			new GDEInfo("GDEStoryScriptData", typeof(GDEStoryScriptData), typeof(GDEStoryScriptDataLoader))
		},
		{
			"GDEStrongholdDataContainer",
			new GDEInfo("GDEStrongholdData", typeof(GDEStrongholdData), typeof(GDEStrongholdDataLoader))
		},
		{
			"GDETechnologyDataContainer",
			new GDEInfo("GDETechnologyData", typeof(GDETechnologyData), typeof(GDETechnologyDataLoader))
		},
		{
			"GDETechnologyEffectDataContainer",
			new GDEInfo("GDETechnologyEffectData", typeof(GDETechnologyEffectData), typeof(GDETechnologyEffectDataLoader))
		},
		{
			"GDETipDataContainer",
			new GDEInfo("GDETipData", typeof(GDETipData), typeof(GDETipDataLoader))
		},
		{
			"GDETriggerDataContainer",
			new GDEInfo("GDETriggerData", typeof(GDETriggerData), typeof(GDETriggerDataLoader))
		},
		{
			"GDEUserExperienceDataContainer",
			new GDEInfo("GDEUserExperienceData", typeof(GDEUserExperienceData), typeof(GDEUserExperienceDataLoader))
		},
		{
			"GDELegendItemSetDataContainer",
			new GDEInfo("GDELegendItemSetData", typeof(GDELegendItemSetData), typeof(GDELegendItemSetDataLoader))
		},
		{
			"GDEDecorativeObjectsDataContainer",
			new GDEInfo("GDEDecorativeObjectsData", typeof(GDEDecorativeObjectsData), typeof(GDEDecorativeObjectsDataLoader))
		},
		{
			"GDEStoreContentConfigGameLevelFilterDataContainer",
			new GDEInfo("GDEStoreContentConfigGameLevelFilterData", typeof(GDEStoreContentConfigGameLevelFilterData), typeof(GDEStoreContentConfigGameLevelFilterDataLoader))
		},
		{
			"GDEGvGIslandMapConfigDataContainer",
			new GDEInfo("GDEGvGIslandMapConfigData", typeof(GDEGvGIslandMapConfigData), typeof(GDEGvGIslandMapConfigDataLoader))
		},
		{
			"GDEGvGCampMissionDataContainer",
			new GDEInfo("GDEGvGCampMissionData", typeof(GDEGvGCampMissionData), typeof(GDEGvGCampMissionDataLoader))
		},
		{
			"GDEMissionFrontEndOnlyDataContainer",
			new GDEInfo("GDEMissionFrontEndOnlyData", typeof(GDEMissionFrontEndOnlyData), typeof(GDEMissionFrontEndOnlyDataLoader))
		},
		{
			"GDELevelAssistanceDataContainer",
			new GDEInfo("GDELevelAssistanceData", typeof(GDELevelAssistanceData), typeof(GDELevelAssistanceDataLoader))
		},
		{
			"GDEBattleAudioConfigDataContainer",
			new GDEInfo("GDEBattleAudioConfigData", typeof(GDEBattleAudioConfigData), typeof(GDEBattleAudioConfigDataLoader))
		},
		{
			"GDESoldierMythDataContainer",
			new GDEInfo("GDESoldierMythData", typeof(GDESoldierMythData), typeof(GDESoldierMythDataLoader))
		},
		{
			"GDEGvGAmplifierConfigDataContainer",
			new GDEInfo("GDEGvGAmplifierConfigData", typeof(GDEGvGAmplifierConfigData), typeof(GDEGvGAmplifierConfigDataLoader))
		},
		{
			"GDEGvGTalentConfigDataContainer",
			new GDEInfo("GDEGvGTalentConfigData", typeof(GDEGvGTalentConfigData), typeof(GDEGvGTalentConfigDataLoader))
		},
		{
			"GDEGvGMode3CampMissionDataContainer",
			new GDEInfo("GDEGvGMode3CampMissionData", typeof(GDEGvGMode3CampMissionData), typeof(GDEGvGMode3CampMissionDataLoader))
		}
	};

	public static Dictionary<Type, object> AllConfig;

	private static bool isLoadFinished = false;

	private static Action after_load;

	private static int LoadedDataCnt = 0;

	private static Dictionary<string, Type> cache;

	private const string LanguageDataContainerKey = "GDELanguagesDataContainer";

	private static AsyncOperationHandle<TextAsset> languageHandler;

	public static bool isLanguageDataFinish = false;

	private static Dictionary<int, GDESoldierMythData> _soldierMythConfigs;

	private static readonly Dictionary<Type, Action> _actionTypes = new Dictionary<Type, Action> { 
	{
		typeof(GDEAbilityData),
		RemindClearCache
	} };

	public static Dictionary<int, GDESoldierMythData> SoldierMythConfigs
	{
		get
		{
			if (_soldierMythConfigs == null)
			{
				_soldierMythConfigs = new Dictionary<int, GDESoldierMythData>();
				IEnumerable<GDESoldierMythData> allItems = GetAllItems<GDESoldierMythData>();
				Dictionary<int, GDESoldierMythData> dictionary = new Dictionary<int, GDESoldierMythData>();
				foreach (GDESoldierMythData item in allItems)
				{
					dictionary.Add(item.Level, item);
				}
				_soldierMythConfigs = dictionary;
			}
			return _soldierMythConfigs;
		}
	}

	public static int numMax()
	{
		return TypeCache.Count;
	}

	public static void CheckLoadFinished(Action _after_load)
	{
		after_load = _after_load;
		FGUIManager.Instance.OpenIEnumerator(Coroutine_CheckLoadFinished());
	}

	private static IEnumerator Coroutine_CheckLoadFinished()
	{
		yield return (object)new WaitForSeconds(0.1f);
		if (isLoadFinished)
		{
			after_load?.Invoke();
			after_load = null;
		}
		else
		{
			FGUIManager.Instance.OpenIEnumerator(Coroutine_CheckLoadFinished());
		}
	}

	public static void TryAddDynamicConfig<T>(Dictionary<string, T> dynamicConfig)
	{
		Type typeFromHandle = typeof(T);
		if (TypeCache_MultiMode.TryGetValue(typeFromHandle, out var value))
		{
			GDEInfoMultiMode<T> gDEInfoMultiMode = value as GDEInfoMultiMode<T>;
			if (!AllConfig.ContainsKey(typeFromHandle))
			{
				AllConfig.Add(typeFromHandle, gDEInfoMultiMode.Cache);
			}
		}
		Dictionary<string, T> dictionary = (Dictionary<string, T>)AllConfig[typeFromHandle];
		foreach (KeyValuePair<string, T> item in dynamicConfig)
		{
			dictionary[item.Key] = item.Value;
		}
		AllConfig[typeFromHandle] = dictionary;
	}

	public static void LoadLanguageData()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		if (AllConfig == null)
		{
			AllConfig = new Dictionary<Type, object>();
		}
		if (ShouldLoadGameDataFromLocal())
		{
			byte[] array = LoadGameDataFileAllBytesFromLocal(null, "GDELanguagesDataContainer");
			if (array != null)
			{
				LoadDataDeserialize("GDELanguagesDataContainer", array);
			}
		}
		else
		{
			languageHandler = Addressables.LoadAssetAsync<TextAsset>((object)"GDELanguagesDataContainer");
			TextAsset asset = languageHandler.WaitForCompletion();
			OnLoadLanguageData(asset);
		}
	}

	private static void OnLoadLanguageData(TextAsset _asset)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		if (TypeCache.ContainsKey("GDELanguagesDataContainer"))
		{
			Type loader_type = TypeCache["GDELanguagesDataContainer"].loader_type;
			DataContainer val = ProtoBufHelper.Deserialize_DataContainer(_asset.bytes);
			object value = loader_type.GetMethod("Load").Invoke(null, new object[1] { val });
			AllConfig.Add(TypeCache["GDELanguagesDataContainer"].type, value);
			SharedMessenger.Broadcast("GET_PROGRESSBAR_NUM");
			isLanguageDataFinish = true;
			WaitToRelease.Enqueue(new ReleaseHandler
			{
				OperactionHandler = AsyncOperationHandle<TextAsset>.op_Implicit(languageHandler),
				Name = "GDELanguagesDataContainer"
			});
		}
	}

	private static void LoadDataDeserialize(string __container, byte[] data)
	{
		DataContainer val = ProtoBufHelper.Deserialize_DataContainer(data);
		Type loader_type = TypeCache[__container].loader_type;
		object value = loader_type.GetMethod("Load").Invoke(null, new object[1] { val });
		AllConfig.Add(TypeCache[__container].type, value);
	}

	public static void LoadData()
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		isLoadFinished = false;
		if (AllConfig == null)
		{
			AllConfig = new Dictionary<Type, object>();
		}
		if (cache == null)
		{
			cache = new Dictionary<string, Type>();
		}
		LoadedDataCnt = 0;
		if (ShouldLoadGameDataFromLocal())
		{
			foreach (string key in TypeCache.Keys)
			{
				if (!("GDELanguagesDataContainer" == key))
				{
					byte[] array = LoadGameDataFileAllBytesFromLocal(null, key);
					if (array != null)
					{
						OnLoadData_Editor(key, array);
					}
				}
			}
			return;
		}
		AsyncOperationHandle<IList<TextAsset>> val = Addressables.LoadAssetsAsync<TextAsset>((object)"GDEFiles", (Action<TextAsset>)null);
		val.Completed += OnLoadData;
	}

	private static void OnLoadData_Editor(string __container, byte[] data)
	{
		LoadDataDeserialize(__container, data);
		LoadedDataCnt++;
		int num = TypeCache.Count - 1;
		double num2 = LoadedDataCnt / num;
		if (LoadedDataCnt == num)
		{
			isLoadFinished = true;
		}
	}

	private static void OnLoadData(AsyncOperationHandle<IList<TextAsset>> res)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.OpenIEnumerator(DeserializeDatas(res));
	}

	private static IEnumerator DeserializeDatas(AsyncOperationHandle<IList<TextAsset>> res)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		IList<TextAsset> list_asset = res.Result;
		for (int i = 0; i < list_asset.Count; i++)
		{
			TextAsset _asset = list_asset[i];
			if (!(((Object)_asset).name == "GDELanguagesDataContainer") && TypeCache.ContainsKey(((Object)_asset).name))
			{
				Type _loader_type = TypeCache[((Object)_asset).name].loader_type;
				DataContainer _Container = ProtoBufHelper.Deserialize_DataContainer(_asset.bytes);
				object val = _loader_type.GetMethod("Load").Invoke(null, new object[1] { _Container });
				AllConfig.Add(TypeCache[((Object)_asset).name].type, val);
				SharedMessenger.Broadcast("GET_PROGRESSBAR_NUM");
				yield return null;
			}
		}
		yield return null;
		WaitToRelease.Enqueue(new ReleaseHandler
		{
			OperactionHandler = AsyncOperationHandle<IList<TextAsset>>.op_Implicit(res),
			Name = "GDEFiles"
		});
		isLoadFinished = true;
	}

	public static IEnumerable<T> GetAllItems<T>()
	{
		Type typeFromHandle = typeof(T);
		if (TypeCache_MultiMode.ContainsKey(typeFromHandle))
		{
			ILRuntimeDebug.LogError("[GDMgr] {0} is MultiMode， CanNot GetAllItems", typeFromHandle.Name);
			return null;
		}
		if (!AllConfig.ContainsKey(typeFromHandle))
		{
			ILRuntimeDebug.LogError("[GDMgr] {0} not in AllConfig！GetAllItems Failed", typeFromHandle);
			return null;
		}
		return ((Dictionary<string, T>)AllConfig[typeFromHandle]).Values;
	}

	public static void Prewarm_MultiMode<T>(List<string> keys)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		Type typeFromHandle = typeof(T);
		IList<IResourceLocation> list = Addressables.LoadResourceLocationsAsync((object)keys, (Type)null).WaitForCompletion();
		foreach (IResourceLocation item in list)
		{
			AsyncOperationHandle<TextAsset> val = Addressables.LoadAssetAsync<TextAsset>(item);
			TextAsset val2 = val.WaitForCompletion();
			if (!((Object)(object)val2 == (Object)null))
			{
				GDEInfoMultiMode<T> gDEInfoMultiMode = TypeCache_MultiMode[typeFromHandle] as GDEInfoMultiMode<T>;
				if (!AllConfig.ContainsKey(typeFromHandle))
				{
					AllConfig.Add(typeFromHandle, gDEInfoMultiMode.Cache);
				}
				if (!((Dictionary<string, T>)AllConfig[typeFromHandle]).ContainsKey(((Object)val2).name))
				{
					T value = val2.bytes.Deserialize<T>();
					((Dictionary<string, T>)AllConfig[typeFromHandle]).Add(((Object)val2).name, value);
					WaitToRelease.Enqueue(new ReleaseHandler
					{
						OperactionHandler = AsyncOperationHandle<TextAsset>.op_Implicit(val),
						Name = ((Object)val2).name
					});
				}
			}
		}
	}

	public static bool TryAdd<T>(string key, T _obj)
	{
		if (string.IsNullOrEmpty(key))
		{
			return false;
		}
		Type typeFromHandle = typeof(T);
		return DictionaryExtensions.TryAddValue<string, T>((Dictionary<string, T>)AllConfig[typeFromHandle], key, _obj);
	}

	public static bool Has<T>(string key)
	{
		Type typeFromHandle = typeof(T);
		if (!AllConfig.ContainsKey(typeFromHandle))
		{
			GDEInfoMultiMode<T> gDEInfoMultiMode = TypeCache_MultiMode[typeFromHandle] as GDEInfoMultiMode<T>;
			AllConfig.Add(typeFromHandle, gDEInfoMultiMode.Cache);
		}
		return ((Dictionary<string, T>)AllConfig[typeFromHandle]).ContainsKey(key);
	}

	public static T Get<T>(string key)
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrEmpty(key))
		{
			return default(T);
		}
		Type typeFromHandle = typeof(T);
		if (TypeCache_MultiMode.ContainsKey(typeFromHandle))
		{
			GDEInfoMultiMode<T> gDEInfoMultiMode = TypeCache_MultiMode[typeFromHandle] as GDEInfoMultiMode<T>;
			if (!AllConfig.ContainsKey(typeFromHandle))
			{
				AllConfig.Add(typeFromHandle, gDEInfoMultiMode.Cache);
			}
			if (!((Dictionary<string, T>)AllConfig[typeFromHandle]).ContainsKey(key))
			{
				string key2 = gDEInfoMultiMode.FolderName + "/" + key;
				byte[] array = LoadGameDataFileAllBytes(gDEInfoMultiMode.FolderName, key);
				if (array == null)
				{
					return default(T);
				}
				T val = array.Deserialize<T>();
				((Dictionary<string, T>)AllConfig[typeFromHandle]).Add(key, val);
				if (ab_Cache.TryGetValue(key2, out var value))
				{
					WaitToRelease.Enqueue(new ReleaseHandler
					{
						OperactionHandler = AsyncOperationHandle<TextAsset>.op_Implicit(value),
						Name = key
					});
					ab_Cache.Remove(key2);
				}
				return val;
			}
			return ((Dictionary<string, T>)AllConfig[typeFromHandle])[key];
		}
		if (!AllConfig.ContainsKey(typeFromHandle))
		{
			ILRuntimeDebug.LogError("[GDMgr] {0} not in AllConfig！Get Failed key is {1}", typeFromHandle, key);
			return default(T);
		}
		if (!((Dictionary<string, T>)AllConfig[typeFromHandle]).ContainsKey(key))
		{
			return default(T);
		}
		return ((Dictionary<string, T>)AllConfig[typeFromHandle])[key];
	}

	public static bool ShouldLoadGameDataFromLocal()
	{
		return false;
	}

	public static byte[] LoadGameDataFileAllBytes(string folder, string name)
	{
		if (ShouldLoadGameDataFromLocal())
		{
			return LoadGameDataFileAllBytesFromLocal(folder, name);
		}
		return LoadGameDataFileAllBytesFromAddressables(folder + "/" + name);
	}

	public static void ReleaseGameDataFileAllText(string name)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (ab_Cache.TryGetValue(name, out var value))
		{
			WaitToRelease.Enqueue(new ReleaseHandler
			{
				OperactionHandler = AsyncOperationHandle<TextAsset>.op_Implicit(value),
				Name = name
			});
			ab_Cache.Remove(name);
		}
	}

	public static string LoadGameDataFileAllText(string folder, string name)
	{
		if (ShouldLoadGameDataFromLocal())
		{
			return LoadGameDataFileAllTextFromLocal(folder, name);
		}
		return LoadGameDataFileAllTextFromAddressables(name);
	}

	private static string GetGameDataFileLocalPath(string folder, string name)
	{
		string path = Path.Combine(Application.streamingAssetsPath, "GameDataContainers");
		if (folder != null)
		{
			path = Path.Combine(path, folder);
		}
		return Path.Combine(path, name + ".bytes");
	}

	private static string LoadGameDataFileAllTextFromLocal(string folder, string name)
	{
		string gameDataFileLocalPath = GetGameDataFileLocalPath(folder, name);
		if (File.Exists(gameDataFileLocalPath))
		{
			return File.ReadAllText(gameDataFileLocalPath);
		}
		return null;
	}

	private static byte[] LoadGameDataFileAllBytesFromLocal(string folder, string name)
	{
		string gameDataFileLocalPath = GetGameDataFileLocalPath(folder, name);
		if (File.Exists(gameDataFileLocalPath))
		{
			return File.ReadAllBytes(gameDataFileLocalPath);
		}
		return null;
	}

	private static string LoadGameDataFileAllTextFromAddressables(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		AsyncOperationHandle<TextAsset> value = Addressables.LoadAssetAsync<TextAsset>((object)name);
		TextAsset val = value.WaitForCompletion();
		ab_Cache[name] = value;
		return val.text;
	}

	private static byte[] LoadGameDataFileAllBytesFromAddressables(string name)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		IList<IResourceLocation> list = Addressables.LoadResourceLocationsAsync((object)name, (Type)null).WaitForCompletion();
		if (list != null && list.Count > 0)
		{
			AsyncOperationHandle<TextAsset> value = Addressables.LoadAssetAsync<TextAsset>((object)name);
			TextAsset val = value.WaitForCompletion();
			ab_Cache[name] = value;
			return val.bytes;
		}
		return null;
	}

	public static T TryGetWithErrorHandling<T>(string key)
	{
		try
		{
			return Get<T>(key);
		}
		catch (Exception innerException)
		{
			if (_actionTypes.TryGetValue(typeof(T), out var value))
			{
				value?.Invoke();
			}
			throw new Exception("TryGetWithErrorHandling key=" + key, innerException);
		}
	}

	public static void RemindClearCache()
	{
		"LoginFailedTip1".ToLanguage().ToConfirmPopup(GameController.Quit, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
	}
}
