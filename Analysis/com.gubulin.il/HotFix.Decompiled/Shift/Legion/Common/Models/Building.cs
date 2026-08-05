using System;
using System.Collections.Generic;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.Common.Models;

public class Building
{
	public const string TypeMine = "1";

	public const string TypeForest = "2";

	public const string TypeVortex = "3";

	public const string TypeForge = "4";

	public const string TypeFinishFactory = "5";

	public const string TypeLaboratory = "6";

	public const string TypeGvGExpeditionHallEntrance = "7";

	public const string TypeBeastary = "8";

	public const string TypeHellsKitchen = "9";

	public const string TypeCamp = "10";

	public const string TypeStorehouse = "11";

	public const string TypeSkyPortal = "12";

	public const string TypeHallOfWar = "13";

	public const string TypeMilitaryIntelligence7 = "14";

	public const string TypeThrone = "15";

	public const string TypeBlackMarketer = "16";

	public const string TypeMoltenCore = "17";

	public const string TypePVPEntrance = "18";

	public const string FeatureMine = "Mine";

	public const string FeatureWorkShop = "WorkShop";

	public const string FeatureCamp = "Camp";

	public const string FeatureStorehouse = "Storehouse";

	public const string FeatureThrone = "Throne";

	public const string FeatureMilitaryIntelligence7 = "MilitaryIntelligence7";

	public const string FeatureBlackMarketer = "BlackMarketer";

	public const string FeatureMoltenCore = "MoltenCore";

	public const string FeaturePVPEntrance = "PVPEntrance";

	public const string FeatureGvGExpeditionHallEntrance = "GvGExpeditionHallEntrance";

	protected string _buildingType;

	protected string _name;

	protected int _level;

	private Dictionary<int, BuildingEvoData> _evoData;

	public GDEBuildingData Data;

	public string Feature;

	public string Prefab;

	public Dictionary<string, object> PrefabConfig;

	public Dictionary<string, object> FeatureConfig;

	private BuildingStatus _status;

	private BuildingInfoEvo infoEvoData;

	public GameObject GameObject;

	private BoxCollider _boxCollider;

	protected GameManagers Managers;

	private string _UpgradeRequiredStorylineLevel;

	public virtual string BuildingType => _buildingType;

	public BuildingStatus Status
	{
		get
		{
			CheckStatus();
			return _status;
		}
		set
		{
			_status = value;
			Managers.UserArchiveManager.ChangeBuildingStatus(BuildingType, value);
		}
	}

	public BuildingConstructingConfig ConstructingConfig
	{
		get
		{
			return Managers.UserArchiveManager.GetBuildingConstructingConfig(BuildingType);
		}
		set
		{
			Managers.UserArchiveManager.SetBuildingConstructingConfig(BuildingType, value);
		}
	}

	public BuildingInfoEvo InfoEvoData
	{
		get
		{
			if (infoEvoData == null)
			{
				infoEvoData = new BuildingInfoEvo("Building" + BuildingType);
			}
			return infoEvoData;
		}
	}

	public virtual string Name
	{
		get
		{
			if (InfoEvoData.NameList.Count > 0 && Level >= 0 && InfoEvoData.NameList.Count > Level)
			{
				return InfoEvoData.NameList[Level];
			}
			return _name;
		}
	}

	public virtual string Bg
	{
		get
		{
			if (InfoEvoData.BgList.Count > 0 && Level >= 0 && InfoEvoData.BgList.Count > Level)
			{
				return InfoEvoData.BgList[Level];
			}
			return "";
		}
	}

	public virtual int Level
	{
		get
		{
			return _level;
		}
		set
		{
			_level = value;
		}
	}

	public string Desc
	{
		get
		{
			if (Data != null && !string.IsNullOrEmpty(Data.Desc))
			{
				return Data.Desc;
			}
			return "";
		}
	}

	public int NextLevel => Level + 1;

	public BoxCollider BoxCollider
	{
		get
		{
			if (_boxCollider == null && (Object)(object)GameObject != (Object)null)
			{
				_boxCollider = GameObject.GetComponent<BoxCollider>();
			}
			return _boxCollider;
		}
	}

	public string UpgradeRequiredStorylineLevel => _UpgradeRequiredStorylineLevel;

	public bool HasStorylineUpgradeRequirement => UpgradeRequiredStorylineLevel != null;

	public Dictionary<int, BuildingEvoData> EvoData
	{
		get
		{
			if (_evoData == null && BuildingManager.GetEvoData(BuildingType) != null)
			{
				_evoData = BuildingManager.GetEvoData(BuildingType);
			}
			return _evoData;
		}
	}

	public virtual int Slot
	{
		get
		{
			if (EvoData == null || !EvoData.ContainsKey(Level))
			{
				return 0;
			}
			return EvoData[Level].Slot;
		}
		set
		{
		}
	}

	public int NextSlot
	{
		get
		{
			if (EvoData == null || !EvoData.ContainsKey(NextLevel))
			{
				return 0;
			}
			return EvoData[NextLevel].Slot;
		}
	}

	public virtual int LeaseholdSlot => Managers.LeaseholdManager.GetLeaseholdWorkbenchByBuilding(BuildingType);

	public virtual int ExtraSlots => Managers.UserArchiveManager.GetExtraBuildingSlots(BuildingType);

	public Building(GameManagers managers, string buildingType)
	{
		GDEBuildingData gDEBuildingData = GDMgr.Get<GDEBuildingData>(buildingType);
		if (gDEBuildingData == null)
		{
		}
		Managers = managers;
		Data = gDEBuildingData;
		_name = gDEBuildingData?.Name;
		_buildingType = gDEBuildingData?.Key;
		_level = Managers.UserArchiveManager.GetBuildingLevel(_buildingType);
		Prefab = gDEBuildingData?.Prefab;
		Feature = gDEBuildingData?.Feature;
		if (!string.IsNullOrEmpty(gDEBuildingData?.PrefabConfig))
		{
			PrefabConfig = JsonHelper.ToObject<Dictionary<string, object>>(gDEBuildingData.PrefabConfig);
		}
		if (!string.IsNullOrEmpty(gDEBuildingData?.FeatureConfig))
		{
			FeatureConfig = JsonHelper.ToObject<Dictionary<string, object>>(gDEBuildingData.FeatureConfig);
		}
		if (gDEBuildingData != null && gDEBuildingData.Status == -1)
		{
			_status = BuildingStatus.Banned;
		}
		else
		{
			_status = Managers.UserArchiveManager.GetBuildingStatus(gDEBuildingData?.Key);
		}
		_UpgradeRequiredStorylineLevel = GetUpgradeRequiredStorylineLevel();
	}

	private string GetUpgradeRequiredStorylineLevel()
	{
		Dictionary<string, int> nextLevelRequirements = GetNextLevelRequirements();
		if (nextLevelRequirements != null)
		{
			foreach (string key in nextLevelRequirements.Keys)
			{
				if (key.StartsWith("LevelId."))
				{
					return key.Substring("LevelId.".Length);
				}
			}
		}
		return null;
	}

	public void CheckStatus()
	{
		BuildingConstructingConfig constructingConfig = ConstructingConfig;
		switch (_status)
		{
		case BuildingStatus.Constructing:
			if (constructingConfig.EndTime <= DateTimeHelper.Ticks || constructingConfig.UpgradeTo <= 0)
			{
				Status = BuildingStatus.Ready;
			}
			break;
		case BuildingStatus.Disabled:
			if (Managers.UserArchiveManager.GetBuildingMaxLevel(BuildingType) > 0)
			{
				Status = BuildingStatus.Abandoned;
			}
			break;
		}
	}

	public virtual void SetFeatures(Dictionary<string, object> newFeatureConfig = null)
	{
		if (newFeatureConfig != null)
		{
			FeatureConfig = newFeatureConfig;
		}
	}

	public int GetUnlockLevelBySlot(int curLevel, int index)
	{
		foreach (KeyValuePair<int, BuildingEvoData> evoDatum in EvoData)
		{
			if (evoDatum.Value.Slot == index && evoDatum.Key > curLevel)
			{
				return evoDatum.Key;
			}
		}
		return 0;
	}

	public int SomeLevelSlot(int level)
	{
		if (EvoData == null || !EvoData.ContainsKey(level))
		{
			return 0;
		}
		return EvoData[level].Slot;
	}

	public virtual Dictionary<string, int> GetNextLevelRequirements(bool ignoreModifier = false)
	{
		if (EvoData == null || !EvoData.ContainsKey(NextLevel))
		{
			return null;
		}
		if (ignoreModifier)
		{
			return EvoData[NextLevel].EvoRequire;
		}
		float percentFloatPayload = Managers.ModifierManager.GetPercentFloatPayload("BuildingUpgradeCost", new string[1] { "BuildingType" + BuildingType });
		Dictionary<string, int> dictionary;
		if (Math.Abs(percentFloatPayload) > float.Epsilon)
		{
			dictionary = new Dictionary<string, int>();
			percentFloatPayload += 1f;
			foreach (KeyValuePair<string, int> item in EvoData[NextLevel].EvoRequire)
			{
				dictionary.Add(item.Key, Mathf.RoundToInt((float)item.Value * percentFloatPayload));
			}
		}
		else
		{
			dictionary = EvoData[NextLevel].EvoRequire;
		}
		return dictionary;
	}

	public int GetUpgradeTime(int assignedWorkers = 1)
	{
		if (EvoData == null || !EvoData.ContainsKey(NextLevel))
		{
			return 0;
		}
		float num = 1f + Managers.ModifierManager.GetPercentFloatPayload("BuildEfficiency");
		int upgradeTime = EvoData[NextLevel].UpgradeTime;
		float num2 = Mathf.Min((float)upgradeTime / Mathf.Pow(1.2f, (float)(assignedWorkers - 1)), (float)(upgradeTime - (assignedWorkers - 1)));
		int num3 = Mathf.RoundToInt(num2 / num);
		if (num3 < 0)
		{
			num3 = 0;
		}
		return num3;
	}

	public ActionResult CheckUpgradeCondition(int assignedWorkers, bool skipVerify = false)
	{
		if (assignedWorkers < 1 && Level >= 1)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.WorkersNumError
			};
		}
		if (!skipVerify && !CanUpgrade())
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.LevelUpFailed
			};
		}
		return new ActionResult
		{
			Result = true
		};
	}

	public virtual ActionResult Upgrade(int assignedWorkers = 1, bool skipVerify = false)
	{
		ActionResult result = CheckUpgradeCondition(assignedWorkers, skipVerify);
		if (!result.Result)
		{
			return result;
		}
		ConsumeUpgradeRequirements();
		SetupConstructing(assignedWorkers, NextLevel);
		return new ActionResult
		{
			Result = true
		};
	}

	public virtual void SetupConstructing(int assignedWorkers, int upgradeTo)
	{
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
		int upgradeTime = GetUpgradeTime(assignedWorkers);
		if (upgradeTime >= 0)
		{
			Status = BuildingStatus.Constructing;
			BuildingConstructingConfig buildingConstructingConfig = new BuildingConstructingConfig
			{
				StartTime = dateTimeOffset.Ticks,
				EndTime = dateTimeOffset.Ticks + (long)upgradeTime * 10000000L,
				UpgradeTo = upgradeTo,
				Workers = assignedWorkers
			};
			Managers.UserArchiveManager.SetBuildingConstructingConfig(BuildingType, buildingConstructingConfig);
			Managers.Messenger.Broadcast("BUILDING_START_UPGRADING", BuildingType, buildingConstructingConfig);
		}
		else
		{
			Status = BuildingStatus.Ready;
		}
	}

	public virtual void ConstructingComplete()
	{
		Status = BuildingStatus.Ready;
		Managers.Messenger.Broadcast("BUILDING_CONSTRUCTING_COMPLETE", BuildingType);
	}

	public bool IsReady()
	{
		BuildingConstructingConfig buildingConstructingConfig = Managers.UserArchiveManager.GetBuildingConstructingConfig(BuildingType);
		if (buildingConstructingConfig == null || buildingConstructingConfig.EndTime > DateTimeHelper.ServerNow.Ticks)
		{
			return false;
		}
		Status = BuildingStatus.Ready;
		return true;
	}

	public ActionResult FinishUpgradeForUseItem()
	{
		if (Level > 0)
		{
			return new ActionResult
			{
				Result = false
			};
		}
		Managers.UserArchiveManager.SetBuildingMaxLevel(BuildingType, 1);
		ConstructingComplete();
		Managers.UserArchiveManager.SetBuildingLevel(BuildingType, 1);
		Status = BuildingStatus.Running;
		Level = 1;
		CheckEvoData(Level);
		Managers.Messenger.Broadcast("BUILDING_UPGRADED_USE_ITEM", BuildingType, Level);
		return new ActionResult
		{
			Result = true
		};
	}

	public virtual ActionResult FinishUpgrade()
	{
		if (!IsReady())
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.BuildingAcceptFailed,
				Params = new object[2] { BuildingType, Status }
			};
		}
		Status = BuildingStatus.Running;
		BuildingConstructingConfig buildingConstructingConfig = Managers.UserArchiveManager.GetBuildingConstructingConfig(BuildingType);
		Managers.UserArchiveManager.SetBuildingLevel(BuildingType, buildingConstructingConfig.UpgradeTo);
		Level = buildingConstructingConfig.UpgradeTo;
		CheckEvoData(Level);
		Managers.Messenger.Broadcast("BUILDING_UPGRADED", BuildingType, Level);
		return new ActionResult
		{
			Result = true
		};
	}

	public bool CanUpgrade()
	{
		if (Status != BuildingStatus.Abandoned && Status != BuildingStatus.Running)
		{
			return false;
		}
		if (GetNextLevelRequirements() == null)
		{
			return false;
		}
		return CheckUpgradeUserLevelRequirement() && CheckUpgradeResourceRequirement() && CheckUpgradeStorylineLevelRequirement();
	}

	private bool CanUpgrade_WithoutResourceCheck()
	{
		if (Status != BuildingStatus.Abandoned && Status != BuildingStatus.Running)
		{
			return false;
		}
		if (GetNextLevelRequirements() == null)
		{
			return false;
		}
		return CheckUpgradeUserLevelRequirement() && CheckUpgradeStorylineLevelRequirement();
	}

	public bool CanUpgradeForDungeonUI()
	{
		if (Status != BuildingStatus.Abandoned && Status != BuildingStatus.Running)
		{
			return false;
		}
		if (GetNextLevelRequirements() == null)
		{
			return false;
		}
		return CheckUpgradeUserLevelRequirement();
	}

	public virtual bool CheckUpgradeUserLevelRequirement()
	{
		int buildingMaxLevel = Managers.UserArchiveManager.GetBuildingMaxLevel(BuildingType);
		if (NextLevel > buildingMaxLevel)
		{
			return false;
		}
		return true;
	}

	public virtual bool CheckUpgradeResourceRequirement()
	{
		Dictionary<string, int> nextLevelRequirements = GetNextLevelRequirements();
		if (nextLevelRequirements != null)
		{
			foreach (KeyValuePair<string, int> item in nextLevelRequirements)
			{
				string key = item.Key;
				if (key.StartsWith("LevelId.") || Managers.StockController.GetStock(key) >= item.Value)
				{
					continue;
				}
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(key);
				return false;
			}
		}
		return true;
	}

	public bool CheckUpgradeStorylineLevelRequirement()
	{
		if (UpgradeRequiredStorylineLevel == null)
		{
			return true;
		}
		if (Managers.UserArchiveManager.IsLevelCompleted(UpgradeRequiredStorylineLevel))
		{
			return true;
		}
		return false;
	}

	protected virtual void ConsumeUpgradeRequirements()
	{
		Dictionary<string, int> nextLevelRequirements = GetNextLevelRequirements();
		if (nextLevelRequirements == null)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[nextLevelRequirements.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in nextLevelRequirements)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 8,
				ContextValue = BuildingType,
				Type = 1
			};
		}
		Managers.StockController.ReadStockChangeRecords(array);
	}

	public bool HasNewMaxLevel()
	{
		int buildingMaxLevel = Managers.UserArchiveManager.GetBuildingMaxLevel(BuildingType);
		if (Level >= buildingMaxLevel)
		{
			return false;
		}
		NewMsgIncomingConfig value = Managers.NewMsgIncomingManager.NewMsgIncomingRecords.GetValue();
		int value2;
		return !value.BuildingMaxLevelChecked.TryGetValue(BuildingType, out value2) || value2 < buildingMaxLevel;
	}

	public virtual bool HasAnyInform()
	{
		if (Level > 0 && HasNewMaxLevel())
		{
			return true;
		}
		if (BuildingType == "18" || BuildingType == "7")
		{
			return CanUpgrade_WithoutResourceCheck();
		}
		return CanUpgrade();
	}

	public void CheckEvoData(int startLevel = 1, int endLevel = 0, bool checkOnly = false)
	{
		if (EvoData == null)
		{
			return;
		}
		if (endLevel <= 0)
		{
			endLevel = Level;
		}
		EvoData.TryGetValue(startLevel - 1, out var value);
		while (startLevel <= endLevel)
		{
			EvoData.TryGetValue(startLevel, out var value2);
			if (value != null)
			{
				List<Modifier> effects = value.GetEffects(Managers);
				if (effects != null)
				{
					foreach (Modifier item in effects)
					{
						if (!(item.ModifierId == "Bonus") && !(item.ModifierId == "TimeMachine") && !(item.ModifierId == "OfflineYieldTimeLimit"))
						{
							Managers.ModifierManager.ReadFromModifier(item, -1);
						}
					}
				}
			}
			if (value2 != null)
			{
				Slot = value2.Slot;
				List<Modifier> effects2 = value2.GetEffects(Managers);
				if (effects2 != null)
				{
					foreach (Modifier item2 in effects2)
					{
						if (checkOnly)
						{
							if (item2.ModifierId == "Bonus")
							{
								if (item2.PayloadDictionary.TryGetValue("Unlock", out var value3))
								{
									Modifier modifier = new Modifier(Managers, "Bonus", new Dictionary<string, object> { { "Unlock", value3 } });
									Managers.ModifierManager.ReadFromModifier(modifier);
								}
							}
							else if (!(item2.ModifierId == "TimeMachine") && !(item2.ModifierId == "OfflineYieldTimeLimit"))
							{
								Managers.ModifierManager.ReadFromModifier(item2);
							}
						}
						else
						{
							Managers.ModifierManager.ReadFromModifier(item2);
						}
					}
				}
			}
			value = value2;
			startLevel++;
		}
	}
}
