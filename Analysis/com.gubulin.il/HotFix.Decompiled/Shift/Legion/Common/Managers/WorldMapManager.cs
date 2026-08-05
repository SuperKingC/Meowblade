using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class WorldMapManager : Manager
{
	public static int MaxStrongholdProducePeriod = 180;

	private static List<string> _regionKeys;

	public static Dictionary<string, RegionStatus> Cache_RegionStatus = new Dictionary<string, RegionStatus>();

	private static Dictionary<string, Region> _regions;

	private static Dictionary<string, Stronghold> _strongholds;

	public readonly Dictionary<string, float> RegionAutoClaimRemainingTime = new Dictionary<string, float>();

	public readonly Dictionary<string, float> AutoProduceProgress = new Dictionary<string, float>();

	public readonly Dictionary<string, float> StrongholdsProduceProgress = new Dictionary<string, float>();

	public readonly Dictionary<string, Dictionary<string, float>> AutoProductionsCache = new Dictionary<string, Dictionary<string, float>>();

	public readonly Dictionary<string, Dictionary<string, float>> StrongholdsProductionsCache = new Dictionary<string, Dictionary<string, float>>();

	public int MaxAutoProducePeriod => Managers.UserArchiveManager.GetConfigValue<int>("AUTO_PRODUCE_CYCLE");

	private static List<string> RegionKeys
	{
		get
		{
			if (_regionKeys == null)
			{
				_regionKeys = new List<string>();
				IEnumerable<GDERegionData> allItems = GDMgr.GetAllItems<GDERegionData>();
				foreach (GDERegionData item in allItems)
				{
					_regionKeys.Add(item.Key);
				}
			}
			return _regionKeys;
		}
	}

	public static Dictionary<string, Region> Regions
	{
		get
		{
			if (_regions == null)
			{
				_regions = new Dictionary<string, Region>();
				IEnumerable<GDERegionData> allItems = GDMgr.GetAllItems<GDERegionData>();
				foreach (GDERegionData item in allItems)
				{
					Region region = new Region(item);
					_regions.Add(region.RegionId, region);
				}
				foreach (KeyValuePair<string, Stronghold> stronghold in Strongholds)
				{
					Stronghold value = stronghold.Value;
					if (_regions.TryGetValue(value.Data.Region, out var value2))
					{
						value2.Strongholds.Add(value);
						value.Region = value2;
					}
				}
			}
			return _regions;
		}
	}

	public static Dictionary<string, Stronghold> Strongholds
	{
		get
		{
			if (_strongholds == null)
			{
				_strongholds = new Dictionary<string, Stronghold>();
				IEnumerable<GDEStrongholdData> allItems = GDMgr.GetAllItems<GDEStrongholdData>();
				foreach (GDEStrongholdData item in allItems)
				{
					_strongholds.Add(item.Key, new Stronghold(item));
				}
			}
			return _strongholds;
		}
	}

	public void ClearDicCache()
	{
		Cache_RegionStatus.Clear();
	}

	public WorldMapManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		foreach (string key in Strongholds.Keys)
		{
			StrongholdsProduceProgress.Add(key, 0f);
			StrongholdsProductionsCache.Add(key, new Dictionary<string, float>());
		}
		return null;
	}

	public void RegisterUiObjects()
	{
		UiTagManager instance = UiTagManager.Instance;
	}

	public void UnregisterUiObjects()
	{
		UiTagManager instance = UiTagManager.Instance;
	}

	public float GetRegionProgress(string regionId)
	{
		if (Regions.TryGetValue(regionId, out var value))
		{
			return value.RegionProgress(Managers);
		}
		return 0f;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, bool>("CHAPTER_COMPLETE", OnChapterComplete);
		Managers.Messenger.AddListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvo);
		Managers.Messenger.AddListener<string, int>("SOLDIER_BREAKTHROUGH", OnSoldierBreakthrough);
		Managers.Messenger.AddListener<string, int>("SOLDIER_POTENTIAL_UPGRADED", OnSoldierPotentialUpgraded);
		Managers.Messenger.AddListener<string, int>("TECH_UPGRADED", OnTechUpgraded);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, bool>("CHAPTER_COMPLETE", OnChapterComplete);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvo);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_BREAKTHROUGH", OnSoldierBreakthrough);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_POTENTIAL_UPGRADED", OnSoldierPotentialUpgraded);
		Managers.Messenger.RemoveListener<string, int>("TECH_UPGRADED", OnTechUpgraded);
	}

	private void OnSoldierPotentialUpgraded(string soldierId, int potentialLevel)
	{
		UpdateStrongholdProdByOccupant(soldierId);
	}

	private void OnSoldierBreakthrough(string soldierId, int breakthroughLevel)
	{
		UpdateStrongholdProdByOccupant(soldierId);
	}

	private void OnSoldierEvo(string soldierId, int evoLevel)
	{
		UpdateStrongholdProdByOccupant(soldierId);
	}

	private void OnChapterComplete(string chapterId, bool newCompleteFlag)
	{
		if (ChapterManager.Chapters.TryGetValue(chapterId, out var value))
		{
			Cache_RegionStatus.Remove(value.Region);
			Chapter nextChapter = value.NextChapter;
			if (nextChapter != null)
			{
				Cache_RegionStatus.Remove(nextChapter.Region);
			}
			else
			{
				Cache_RegionStatus.Clear();
			}
		}
	}

	private void OnTechUpgraded(string techId, int level)
	{
		List<Modifier> techEffects = Managers.TechnologyManager.GetTechEffects(techId, level);
		if (techEffects == null || techEffects.All((Modifier modifier) => modifier.ModifierId != "OccupiedProduceEfficiency"))
		{
			return;
		}
		foreach (Stronghold item in from region in Regions.Values
			where region.Status(Managers) == RegionStatus.Occupied
			from stronghold in region.Strongholds
			where stronghold.IsOccupied(Managers)
			select stronghold)
		{
			item.RefreshStatus(Managers);
		}
	}

	private void UpdateStrongholdProdByOccupant(string soldierId)
	{
		foreach (KeyValuePair<string, StrongholdConfig> item in Managers.UserArchiveManager.GetAllStrongholdsStatus())
		{
			StrongholdConfig value = item.Value;
			if (value.Occupant == soldierId)
			{
				Managers.UserArchiveManager.AssignOccupantToStronghold(soldierId, item.Key);
				break;
			}
		}
	}

	public ActionResult SetStrongholdSoldier(string strongholdId, string soldierId)
	{
		if (!Strongholds.TryGetValue(strongholdId, out var value))
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.StrongholdNotFound
			};
		}
		if (string.IsNullOrEmpty(soldierId) || soldierId == "Unlock" || soldierId == "Lock")
		{
			value.WithdrawOccupantFromStronghold(Managers);
			return new ActionResult
			{
				Result = true
			};
		}
		if (value.Occupant(Managers) == soldierId)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.AlreadySelectedStrongholdSoldier
			};
		}
		if (Managers.UserArchiveManager.GetAssignedSoldiers().Contains(soldierId))
		{
			Stronghold stronghold = FindStrongholdBySoldierId(soldierId);
			if (value.IsOccupied(Managers))
			{
				string soldierId2 = value.Occupant(Managers);
				stronghold.WithdrawOccupantFromStronghold(Managers);
				value.WithdrawOccupantFromStronghold(Managers);
				stronghold.AssignOccupantToStronghold(Managers, soldierId2);
			}
			else
			{
				stronghold.WithdrawOccupantFromStronghold(Managers);
			}
		}
		value.AssignOccupantToStronghold(Managers, soldierId);
		return new ActionResult
		{
			Result = true
		};
	}

	private Stronghold FindStrongholdBySoldierId(string soldierId)
	{
		return Strongholds.Values.FirstOrDefault((Stronghold stronghold) => stronghold.Occupant(Managers) == soldierId);
	}

	public static Region GetNextRegion(string regionId)
	{
		int num = RegionKeys.IndexOf(regionId);
		if (num != -1 && ++num < RegionKeys.Count)
		{
			return Regions[RegionKeys[num]];
		}
		return null;
	}

	public static Region GetPrevRegion(string regionId)
	{
		int num = RegionKeys.IndexOf(regionId);
		if (--num >= 0)
		{
			return Regions[RegionKeys[num]];
		}
		return null;
	}
}
