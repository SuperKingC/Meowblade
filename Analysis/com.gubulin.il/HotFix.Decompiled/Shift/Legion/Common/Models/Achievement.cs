using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Achievement
{
	public GDEAchievementData Data;

	public readonly string AchievementId;

	public readonly string Name;

	public readonly string Desc;

	public readonly AchievementCat Category;

	public readonly AchievementType Type;

	public AchievementTarget Target;

	public List<Bonus> Bonuses;

	private static Dictionary<string, float> _cache_AchievementValue = new Dictionary<string, float>();

	public float TargetValue
	{
		get
		{
			if (Type == AchievementType.GuideMissionSummary && Target.Missions != null)
			{
				return Target.Missions.Count;
			}
			if (Type == AchievementType.ForeignGuideMissionSummary && Target.Missions != null)
			{
				return Target.Missions.Count;
			}
			if (Type == AchievementType.ChallengeMissionSummary)
			{
				return Target.Missions?.Count ?? 1;
			}
			return Target.Value;
		}
	}

	public AchievementStatus Status(GameManagers managers, bool use_cache = false)
	{
		if (HasClaimed(managers))
		{
			return AchievementStatus.Claimed;
		}
		if (VerifyTarget(managers, use_cache))
		{
			return AchievementStatus.PendingToClaim;
		}
		return AchievementStatus.Ongoing;
	}

	public Achievement(GDEAchievementData data)
	{
		Data = data;
		AchievementId = data.Key;
		Name = data.Name;
		Desc = data.Desc;
		Category = (AchievementCat)data.Category;
		Type = (AchievementType)data.Type;
		Bonuses = new List<Bonus>();
		if (!string.IsNullOrEmpty(data.Bonuses))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(data.Bonuses))
			{
				Bonuses.Add(Bonus.Get(item.Key, item.Value));
			}
		}
		ParseTarget(data.Target);
	}

	private void ParseTarget(string config)
	{
		if (config.IndexOf('{') == -1)
		{
			Target = new AchievementTarget
			{
				Value = NumericParser.Float(config)
			};
		}
		else if (!string.IsNullOrEmpty(config))
		{
			Target = JsonHelper.ToObject<AchievementTarget>(config);
		}
	}

	public float CurrentValue(GameManagers managers)
	{
		switch (Type)
		{
		case AchievementType.Workers:
			return managers.StockController.GetStock("ManPower");
		case AchievementType.ArmsVariety:
			return managers.UserArchiveManager.GetUnlockedSoldiers().Count;
		case AchievementType.SoldierEvo:
			if (!string.IsNullOrEmpty(Target.Id))
			{
				return managers.UserArchiveManager.GetSoldierEvolutionLevel(Target.Id);
			}
			return 0f;
		case AchievementType.SoldierEvoVariety:
		{
			if (Target.EvoLevel <= 0)
			{
				return 0f;
			}
			List<string> list8 = new List<string>();
			List<string> list9 = new List<string>();
			List<string> list10 = new List<string>();
			if (!string.IsNullOrEmpty(Target.Id))
			{
				list8.AddRange(Target.Id.Split(' '));
			}
			if (!string.IsNullOrEmpty(Target.AiType))
			{
				list9.AddRange(Target.AiType.Split(' '));
			}
			if (!string.IsNullOrEmpty(Target.Tags))
			{
				list10.AddRange(Target.Tags.Split(' '));
			}
			int num11 = 0;
			foreach (string unlockedSoldier in managers.UserArchiveManager.GetUnlockedSoldiers())
			{
				Soldier soldier2 = managers.SoldierManager.Get(unlockedSoldier);
				if ((list8.Count <= 0 || list8.Contains(unlockedSoldier)) && (list10.Count <= 0 || soldier2.Tags.Intersect(list10).Any()) && (list9.Count <= 0 || list9.Contains(soldier2.AiType)) && soldier2.EvoLevel >= Target.EvoLevel)
				{
					num11++;
				}
			}
			return num11;
		}
		case AchievementType.SoldierLevel:
			if (!string.IsNullOrEmpty(Target.Id))
			{
				return managers.UserArchiveManager.GetSoldierLevel(Target.Id);
			}
			return 0f;
		case AchievementType.SoldierLevelVariety:
		{
			if (Target.Level <= 0)
			{
				return 0f;
			}
			List<string> list5 = new List<string>();
			List<string> list6 = new List<string>();
			List<string> list7 = new List<string>();
			if (!string.IsNullOrEmpty(Target.Id))
			{
				list5.AddRange(Target.Id.Split(' '));
			}
			if (!string.IsNullOrEmpty(Target.AiType))
			{
				list6.AddRange(Target.AiType.Split(' '));
			}
			if (!string.IsNullOrEmpty(Target.Tags))
			{
				list7.AddRange(Target.Tags.Split(' '));
			}
			int num10 = 0;
			foreach (string unlockedSoldier2 in managers.UserArchiveManager.GetUnlockedSoldiers())
			{
				Soldier soldier = managers.SoldierManager.Get(unlockedSoldier2);
				if ((list5.Count <= 0 || list5.Contains(unlockedSoldier2)) && (list7.Count <= 0 || soldier.Tags.Intersect(list7).Any()) && (list6.Count <= 0 || list6.Contains(soldier.AiType)) && soldier.Level >= Target.Level)
				{
					num10++;
				}
			}
			return num10;
		}
		case AchievementType.SoldierPotential:
			if (!string.IsNullOrEmpty(Target.Id))
			{
				return managers.UserArchiveManager.GetSoldierPotentialLevel(Target.Id);
			}
			return 0f;
		case AchievementType.SoldierPotentialVariety:
		{
			if (Target.PotentialLevel < 0)
			{
				return 0f;
			}
			List<string> list11 = new List<string>();
			List<string> list12 = new List<string>();
			List<string> list13 = new List<string>();
			if (!string.IsNullOrEmpty(Target.Id))
			{
				list11.AddRange(Target.Id.Split(' '));
			}
			if (!string.IsNullOrEmpty(Target.AiType))
			{
				list12.AddRange(Target.AiType.Split(' '));
			}
			if (!string.IsNullOrEmpty(Target.Tags))
			{
				list13.AddRange(Target.Tags.Split(' '));
			}
			int num12 = 0;
			foreach (string unlockedSoldier3 in managers.UserArchiveManager.GetUnlockedSoldiers())
			{
				Soldier soldier3 = managers.SoldierManager.Get(unlockedSoldier3);
				if ((list11.Count <= 0 || list11.Contains(unlockedSoldier3)) && (list13.Count <= 0 || soldier3.Tags.Intersect(list13).Any()) && (list12.Count <= 0 || list12.Contains(soldier3.AiType)) && soldier3.PotentialLevel >= Target.PotentialLevel)
				{
					num12++;
				}
			}
			return num12;
		}
		case AchievementType.SoldierSecondLegendItemSlotUnlocked:
			if (!string.IsNullOrEmpty(Target.Id))
			{
				int i;
				for (i = 0; i < 2; i++)
				{
					if (!GameManagers.Instance.SoldierItemSlotsManager.IsSlotUnlocked(Target.Id, i))
					{
						return i;
					}
				}
				return i;
			}
			ILRuntimeDebug.LogError("Empty Target id of Achievement : " + AchievementId);
			return 0f;
		case AchievementType.SoldierUnlock:
			if (string.IsNullOrEmpty(Target.Id) && managers.UserArchiveManager.GetUnlockedSoldiers().Contains(Target.Id))
			{
				return 1f;
			}
			return 0f;
		case AchievementType.ArtifactPieces:
		case AchievementType.ArtifactPiecesUnlocked:
		{
			float num8 = 0f;
			List<TechnologyType> list4 = new List<TechnologyType>();
			if (!string.IsNullOrEmpty(Target.Type))
			{
				list4.AddRange(from typeStr in Target.Type.Split(',')
					select (TechnologyType)Convert.ToInt32(typeStr));
			}
			foreach (KeyValuePair<string, int> item in managers.UserArchiveManager.GetAllTechLevel())
			{
				if (!(item.Key == TechnologyManager.DoomArtifactKey) && !(item.Key == TechnologyManager.SlaveryArtifactKey) && !(item.Key == TechnologyManager.DominionArtifactKey))
				{
					GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(item.Key);
					if (gDETechnologyData != null && (list4.Count <= 0 || list4.Contains((TechnologyType)gDETechnologyData.Type)) && item.Value > 0)
					{
						num8 += (float)((Type == AchievementType.ArtifactPiecesUnlocked) ? 1 : item.Value);
					}
				}
			}
			return num8;
		}
		case AchievementType.DoomArtifactLevel:
			return managers.UserArchiveManager.GetDoomArtifactLevel();
		case AchievementType.SlaveryArtifactLevel:
			return managers.UserArchiveManager.GetSlaveryArtifactLevel();
		case AchievementType.DominionArtifactLevel:
			return managers.UserArchiveManager.GetDominionArtifactLevel();
		case AchievementType.UserLevel:
			return managers.UserArchiveManager.GetUserLevel();
		case AchievementType.DungeonLevel:
			return managers.UserArchiveManager.GetDungeonLevel();
		case AchievementType.AllStrongholdOccupiedByRegion:
		{
			float num17 = 0f;
			foreach (Region value11 in WorldMapManager.Regions.Values)
			{
				if (value11.IsStrongholdsEnabled(managers) && value11.Strongholds.All((Stronghold stronghold) => stronghold.IsOccupied(managers)))
				{
					num17 += 1f;
				}
			}
			return num17;
		}
		case AchievementType.RegionSize:
		{
			float num16 = 0f;
			foreach (Region value12 in WorldMapManager.Regions.Values)
			{
				if (!(value12.RegionProgress(managers) < 1f))
				{
					num16 += 1f;
				}
			}
			return num16;
		}
		case AchievementType.Summary:
		{
			float num15 = 0f;
			foreach (Achievement item2 in AchievementManager.GetAchievementsByCategory(Category))
			{
				if (item2.Status(managers) != AchievementStatus.Ongoing)
				{
					num15 += 1f;
				}
			}
			return num15;
		}
		case AchievementType.TotalRecharge:
		case AchievementType.IntlTotalRecharge:
			return managers.UserArchiveManager.GetTotalRecharge();
		case AchievementType.WeaponLevel:
			if (!string.IsNullOrEmpty(Target.Id))
			{
				return managers.UserArchiveManager.GetItemLevel(Target.Id);
			}
			return 0f;
		case AchievementType.WeaponLevelVariety:
		{
			if (Target.Level <= 0)
			{
				return 0f;
			}
			int num13 = 0;
			foreach (KeyValuePair<string, int> item3 in managers.UserArchiveManager.GetAllItemLevel())
			{
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item3.Key);
				if (gDEItemData != null && gDEItemData.ItemType == 2 && item3.Value >= Target.Level)
				{
					num13++;
				}
			}
			return num13;
		}
		case AchievementType.BuildingUnlocked:
		{
			int num6 = 0;
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			if (!string.IsNullOrEmpty(Target.Type))
			{
				list2.AddRange(Target.Type.Split(','));
			}
			if (!string.IsNullOrEmpty(Target.Feature))
			{
				list3.AddRange(Target.Feature.Split(','));
			}
			foreach (Building value13 in managers.BuildingManager.Buildings.Values)
			{
				if (value13.Level >= 1 && (list2.Count <= 0 || list2.Contains(value13.BuildingType)) && (list3.Count <= 0 || list3.Contains(value13.Feature)))
				{
					num6++;
				}
			}
			return num6;
		}
		case AchievementType.BuildingLevel:
			if (!string.IsNullOrEmpty(Target.Type))
			{
				return managers.BuildingManager.GetBuildingByType(Target.Type)?.Level ?? 0;
			}
			return 0f;
		case AchievementType.BuildingLevelVariety:
		{
			if (Target.Level <= 0)
			{
				return 0f;
			}
			List<string> list14 = new List<string>();
			List<string> list15 = new List<string>();
			if (!string.IsNullOrEmpty(Target.Type))
			{
				list14.AddRange(Target.Type.Split(','));
			}
			if (!string.IsNullOrEmpty(Target.Feature))
			{
				list15.AddRange(Target.Feature.Split(','));
			}
			int num14 = 0;
			foreach (Building value14 in managers.BuildingManager.Buildings.Values)
			{
				if (value14.Level >= Target.Level && (list14.Count <= 0 || list14.Contains(value14.BuildingType)) && (list15.Count <= 0 || list15.Contains(value14.Feature)))
				{
					num14++;
				}
			}
			return num14;
		}
		case AchievementType.LegendItemIdentifiedVariety:
		{
			Dictionary<string, int> value5 = managers.AchievementManager.IdentifiedLegendItems.GetValue();
			return value5.Sum((KeyValuePair<string, int> pair) => pair.Value);
		}
		case AchievementType.LegendItemIdentifiedRarity:
		{
			Dictionary<int, int> value2 = managers.AchievementManager.IdentifiedLegendItemsRarityStat.GetValue();
			if (Target.Stars > 0 && value2.TryGetValue(Target.Stars, out var value3))
			{
				return value3;
			}
			return 0f;
		}
		case AchievementType.PvPRank:
		{
			int historyTopRank = RankDataHelper.PvPRankTopRank.GetValue().HistoryTopRank;
			int currentTopRank = RankDataHelper.PvPRankTopRank.GetValue().CurrentTopRank;
			return (float)(-Math.Min(historyTopRank, currentTopRank)) + Target.Value * 2f;
		}
		case AchievementType.GvGJoined:
		{
			List<string> list = managers.UserArchiveManager.LoadGvGMode3CompletedHistory();
			int num5 = managers.UserArchiveManager.LoadGvGMode3HistoryRecord();
			GvGMode3ObserverRecord gvGMode3ObserverRecord = managers.UserArchiveManager.LoadGvGMode3Record();
			return (gvGMode3ObserverRecord.HasEnterIZ || gvGMode3ObserverRecord.LastIZId != -1) ? (list.Count + num5 + 1) : (list.Count + num5);
		}
		case AchievementType.GvGCompleted:
		{
			int num3 = managers.UserArchiveManager.LoadGvGMode3SettlementHistory();
			return (num3 > 0) ? 1 : 0;
		}
		case AchievementType.OwnedBluePrint:
		{
			List<string> ownedBluePrints = managers.UserArchiveManager.GetOwnedBluePrints();
			int ownedBluePrintsRecords = managers.UserArchiveManager.GetOwnedBluePrintsRecords();
			return ownedBluePrints.Count + ownedBluePrintsRecords;
		}
		case AchievementType.IdentifiedBluePrint:
		{
			int identifiedBluePrints = managers.UserArchiveManager.GetIdentifiedBluePrints();
			int identifiedBluePrintsRecords = managers.UserArchiveManager.GetIdentifiedBluePrintsRecords();
			return identifiedBluePrints + identifiedBluePrintsRecords;
		}
		case AchievementType.GvGStoreItemsRefresh:
		{
			int num2 = managers.UserArchiveManager.GvGStoreTotalDrawCount() / 3;
			return num2;
		}
		case AchievementType.GvGRareStone:
		{
			GvGRareStoneRecord gvGRareStoneRecord = managers.UserArchiveManager.LoadGvGMode3RareStoneRecord();
			return gvGRareStoneRecord.HistoryCount + gvGRareStoneRecord.Count;
		}
		case AchievementType.LegendItemRarityVariety:
		{
			Dictionary<int, int> value9 = managers.AchievementManager.LegendItemRarityStats.GetValue();
			if (Target.Stars > 0)
			{
				if (value9.TryGetValue(Target.Stars, out var value10))
				{
					return value10;
				}
				return 0f;
			}
			return value9.Sum((KeyValuePair<int, int> pair) => pair.Value);
		}
		case AchievementType.LegendItemEnhanceLevelVariety:
		{
			Dictionary<int, int> value7 = managers.AchievementManager.LegendItemEnhanceLevelStats.GetValue();
			if (value7.TryGetValue(Target.Level, out var value8))
			{
				return value8;
			}
			return 0f;
		}
		case AchievementType.LegendItemTotalChangeProperties:
			return managers.AchievementManager.LegendItemChangePropertyStats.GetValue();
		case AchievementType.LegendItemTotalReforge:
			return managers.AchievementManager.LegendItemReforgeStats.GetValue();
		case AchievementType.LegendItemBlackMarketDealing:
		{
			Dictionary<string, int> value6 = managers.AchievementManager.LegendItemFromBlackMarketStats.GetValue();
			return value6.Sum((KeyValuePair<string, int> pair) => pair.Value);
		}
		case AchievementType.LegendItemSetVariety:
			return managers.AchievementManager.ActivatedLegendItemSets.GetValue().Contains(Target.Id) ? 1 : 0;
		case AchievementType.LegendItemSetActivate:
		{
			List<string> value4 = managers.AchievementManager.ActivatedLegendItemSets.GetValue();
			return (!string.IsNullOrEmpty(Target.Id) && value4.Contains(Target.Id)) ? 1 : 0;
		}
		case AchievementType.PurchaseStats:
		{
			Dictionary<string, int> purchaseStat = managers.StoreManager.PurchaseStat.GetValue().PurchaseStat;
			int value;
			return purchaseStat.TryGetValue(Target.Id, out value) ? value : 0;
		}
		case AchievementType.DailyLoginStats:
			return managers.UserArchiveManager.GetDailyLoginStats();
		case AchievementType.GuideMissionSummary:
		case AchievementType.ForeignGuideMissionSummary:
		{
			if (Target.Missions == null || Target.Missions.Count <= 0)
			{
				return 0f;
			}
			float num9 = 0f;
			foreach (Mission value15 in MissionManager.NewbieMissions.Values)
			{
				if (value15.MissionState(GameManagers.Instance).Status == MissionStatus.Claimed && Target.Missions.Contains(value15.Id))
				{
					num9 += 1f;
				}
			}
			return num9;
		}
		case AchievementType.FormationsUnlock:
		{
			float num7 = 0f;
			foreach (KeyValuePair<string, GDEFormationData> unlockedFormation in GameManagers.Instance.FormationManager.GetUnlockedFormations())
			{
				if (FormationManager.PlayerUsableFormations.ContainsKey(unlockedFormation.Key))
				{
					num7 += 1f;
				}
			}
			return num7;
		}
		case AchievementType.ChallengeMissionSummary:
		{
			if (Target.Missions == null || Target.Missions.Count <= 0)
			{
				return 0f;
			}
			float num4 = 0f;
			foreach (KeyValuePair<string, Mission> pickedMission in managers.MissionManager.PickedMissions)
			{
				if (Target.Missions.Contains(pickedMission.Key) && pickedMission.Value.MissionState(managers).Status == MissionStatus.Claimed)
				{
					num4 += 1f;
				}
			}
			return num4;
		}
		case AchievementType.ChallengeAttackDungeon:
		case AchievementType.ChallengeLimitedTimeDungeon:
		case AchievementType.ChallengeEnterDungeon:
		case AchievementType.ChallengeTreasureHuntDifficultDungeon:
		case AchievementType.ChallengeLimitedTimeDifficultDungeon:
		{
			if (Target.Levels == null || Target.Levels.Count <= 0 || !managers.UserArchiveManager.IsForeignNewGuideMode())
			{
				return 0f;
			}
			float num = 0f;
			foreach (KeyValuePair<string, Dictionary<string, int>> clearStageStat in managers.ChapterManager.LevelProgressStats.GetValue().ClearStageStats)
			{
				foreach (KeyValuePair<string, int> item4 in clearStageStat.Value)
				{
					if (Target.Levels.Contains(item4.Key))
					{
						num += (float)item4.Value;
					}
				}
			}
			return num;
		}
		default:
			return 0f;
		}
	}

	public static void ClearCache_AchievementValue()
	{
		_cache_AchievementValue = new Dictionary<string, float>();
	}

	public bool VerifyTarget(GameManagers managers, bool use_cache = false)
	{
		if (use_cache)
		{
			if (!_cache_AchievementValue.ContainsKey(AchievementId))
			{
				_cache_AchievementValue.Add(AchievementId, 0f);
				_cache_AchievementValue[AchievementId] = CurrentValue(managers);
			}
			return _cache_AchievementValue[AchievementId] >= TargetValue;
		}
		return CurrentValue(managers) >= TargetValue;
	}

	public bool HasClaimed(GameManagers managers)
	{
		return managers.UserArchiveManager.GetAchievementProgress().Contains(AchievementId);
	}

	public bool ClaimBonus(GameManagers managers, Dictionary<string, float> claimed = null, bool broadcastInform = true)
	{
		if (!VerifyTarget(managers))
		{
			return false;
		}
		if (HasClaimed(managers))
		{
			return false;
		}
		foreach (Bonus bonuse in Bonuses)
		{
			bonuse.Claim(managers, claimed, null, forceClaim: true, broadcastInform);
		}
		managers.UserArchiveManager.UpdateAchievementProgress(AchievementId);
		return true;
	}
}
