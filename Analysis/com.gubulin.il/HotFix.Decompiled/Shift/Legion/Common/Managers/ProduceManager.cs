using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class ProduceManager : Manager
{
	private DateTimeOffset _lastProduceCheckAt;

	private readonly Dictionary<WorkShop, List<int>> _workerStatusDurationDict = new Dictionary<WorkShop, List<int>>();

	private readonly Dictionary<WorkShop, List<(int, WorkerStatus)>> _workerStatusInnerCdDict = new Dictionary<WorkShop, List<(int, WorkerStatus)>>();

	private const string RegionProdProgressRef = "Money";

	private const int RegionProdMinPeriod = 9;

	public readonly int CheckingCycle;

	private Dictionary<string, string> _prodItemToBuildingFeature;

	private List<string> _needAutoClaimRegions = new List<string>();

	private List<string> _needInformLevels = new List<string>();

	private List<string> _needInformStrongholds = new List<string>();

	private Dictionary<string, float> _autoProduceBonusBuffer = new Dictionary<string, float>();

	private List<int> campSlotsNeedCheck = new List<int>();

	public Dictionary<string, string> ProdItemToBuildingFeature
	{
		get
		{
			if (_prodItemToBuildingFeature == null)
			{
				_prodItemToBuildingFeature = new Dictionary<string, string>();
				foreach (GDEProductData allItem in GDMgr.GetAllItems<GDEProductData>())
				{
					if (allItem.BuildType.Count >= 1 && Managers.BuildingManager.Buildings.TryGetValue(allItem.BuildType.First(), out var value))
					{
						_prodItemToBuildingFeature.Add(allItem.ItemId, value.Feature);
					}
				}
			}
			return _prodItemToBuildingFeature;
		}
	}

	public ProduceManager(GameManagers managers)
		: base(managers)
	{
		CheckingCycle = Mathf.RoundToInt(30.000029f);
	}

	public override Task Init()
	{
		LoadBuildings();
		return null;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, string>("STRONGHOLD_ASSIGNED_OCCUPANT", OnStrongholdAssignedOccupant);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, string>("STRONGHOLD_ASSIGNED_OCCUPANT", OnStrongholdAssignedOccupant);
	}

	private void LoadBuildings()
	{
		foreach (Building value in Managers.BuildingManager.Buildings.Values)
		{
			if (value.Feature == "Mine" || value.Feature == "WorkShop")
			{
				_workerStatusInnerCdDict.Add((WorkShop)value, new List<(int, WorkerStatus)>());
				_workerStatusDurationDict.Add((WorkShop)value, new List<int>());
			}
		}
	}

	private void OnStrongholdAssignedOccupant(string strongholdId, string soldierId)
	{
		Dictionary<string, float> strongholdsProduceProgress = Managers.WorldMapManager.StrongholdsProduceProgress;
		if (strongholdsProduceProgress.ContainsKey(strongholdId))
		{
			strongholdsProduceProgress[strongholdId] = 0f;
		}
	}

	public void SyncProduceStatus(SyncProduceResponse res)
	{
		long serverTime = GameController.Instance.GetServerTime();
		campSlotsNeedCheck.Clear();
		for (int i = 0; i < Managers.BuildingManager.GetBuildingByType("10").Slot; i++)
		{
			campSlotsNeedCheck.Add(i);
		}
		if (res.ProduceStates != null && res.ProduceStates.Length != 0)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Dictionary<string, Dictionary<int, Workbench>> all_All_Workbench = GameController.Contexts.Service<BaseSceneService>().Get_All_All_Workbench();
			for (int j = 0; j < res.ProduceStates.Length; j++)
			{
				ProduceState produceState = res.ProduceStates[j];
				if (produceState.BuildingType == "17")
				{
					continue;
				}
				if (!Managers.BuildingManager.Buildings.ContainsKey(produceState.BuildingType))
				{
					ILRuntimeDebug.LogError("[SyncProduceStatus] Managers.BuildingManager.Buildings 中没有BuildingType {0}", produceState.BuildingType);
					continue;
				}
				if (!dictionary.ContainsKey(produceState.BuildingType))
				{
					dictionary.Add(produceState.BuildingType, 0);
				}
				Building building = Managers.BuildingManager.Buildings[produceState.BuildingType];
				if (!(building.BuildingType == "12"))
				{
					if (building.Feature == "Camp")
					{
						Managers.RecruitingCampDataManager.TryStartProduceSoldier(produceState, serverTime);
						campSlotsNeedCheck.Remove(j);
					}
					else
					{
						if (!all_All_Workbench.ContainsKey(produceState.BuildingType))
						{
							if (GameController.Contexts.gameState.isMainCityInitialized)
							{
								ILRuntimeDebug.LogError("[SyncProduceStatus] All_All_Workbench 中没有BuildingType {0}", produceState.BuildingType);
							}
							continue;
						}
						if (!all_All_Workbench[produceState.BuildingType].ContainsKey(produceState.WorkbenchIndex))
						{
							ILRuntimeDebug.LogError("[SyncProduceStatus] All_All_Workbench BuildingType中没有WorkbenchIndex {0}", produceState.WorkbenchIndex);
							continue;
						}
						Workbench workbench = all_All_Workbench[produceState.BuildingType][produceState.WorkbenchIndex];
						workbench.RefreshProduceState(dictionary[produceState.BuildingType], produceState);
					}
				}
				dictionary[produceState.BuildingType]++;
			}
		}
		foreach (int item in campSlotsNeedCheck)
		{
			int num = GameManagers.Instance.RecruitingCampDataManager.IsNowProducing[item];
			if (num != 3)
			{
				continue;
			}
			PortalSoldier portalSoldier = CampController.Instance?.GetPortalSoldier(item);
			if (portalSoldier == null)
			{
				continue;
			}
			Dictionary<string, float> dictionary2 = portalSoldier?.SoldierWeapons;
			if (dictionary2 == null)
			{
				continue;
			}
			foreach (string key in res.PendingStocks.Keys)
			{
				if (dictionary2.ContainsKey(key))
				{
					portalSoldier?.Show_LackResource();
					break;
				}
			}
		}
	}
}
