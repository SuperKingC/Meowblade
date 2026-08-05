using System.Collections.Generic;
using System.Linq;

namespace Shift.Legion.Common.Managers;

public class UiTagManager
{
	private static UiTagManager _Instance;

	private Dictionary<string, HashSet<object>> _tagsDict;

	public const string PlotPanel = "PlotPanel";

	public const string TechnologyDoomTab = "Technology.DoomTab";

	public const string TechnologySlaveryTab = "Technology.SlaveryTab";

	public const string TechnologyDominionTab = "Technology.DominionTab";

	public const string TechnologyDoomArtifact = "Technology.DoomArtifact";

	public const string TechnologySlaveryArtifact = "Technology.SlaveryArtifact";

	public const string TechnologyDominionArtifact = "Technology.DominionArtifact";

	public const string TechnologyNode = "Technology.Node";

	public const string TechnologyActivateBtn = "Technology.ActivateBtn";

	public const string TechnologyUpgradeBtn = "Technology.UpgradeBtn";

	public const string BattleFormationBtn = "Battle.FormationBtn";

	public const string BattleStartBtn = "Battle.StartBtn";

	public const string BattleBonusCardList = "Battle.BonusCardList";

	public const string BattleBonusCard1 = "Battle.BonusCard1";

	public const string BattleBonusCard2 = "Battle.BonusCard2";

	public const string BattleBonusCard3 = "Battle.BonusCard3";

	public const string BattleConfirmClaimLotteryBtn = "Battle.ConfirmClaimLotteryBtn";

	public const string BattleConfirmSettlementBtn = "Battle.ConfirmSettlementBtn";

	public const string BattleCaptureBonus = "Battle.CaptureBonus";

	public const string BattleScoutBtn = "Battle.ScoutBtn";

	public const string BattleBackToPrepareBtn = "Battle.BackToPrepareBtn";

	public const string BattleBackToMainCityBtn = "Battle.BackToMainCityBtn";

	public const string BattleConfirmFailureBtn = "Battle.ConfirmFailureBtn";

	public const string BattleArmyGroup1 = "Battle.ArmyGroup1";

	public const string BattleArmyGroup2 = "Battle.ArmyGroup2";

	public const string BattleArmyGroup3 = "Battle.ArmyGroup3";

	public const string BattleArmyGroup4 = "Battle.ArmyGroup4";

	public const string BattleArmyGroup5 = "Battle.ArmyGroup5";

	public const string BattleEnemyGroup1 = "Battle.EnemyGroup1";

	public const string BattleEnemyGroup2 = "Battle.EnemyGroup2";

	public const string BattleEnemyGroup3 = "Battle.EnemyGroup3";

	public const string BattleEnemyGroup4 = "Battle.EnemyGroup4";

	public const string BattleEnemyGroup5 = "Battle.EnemyGroup5";

	public const string EnemyIntroductionExit = "EnemyIntroduction.Exit";

	public const string EnemyIntroductionBossSkill = "EnemyIntroduction.BossSkill";

	public const string SkillDetailPopupExit = "SkillDetailPopup.Exit";

	public const string BattleMissionCompletedPlayback = "Battle.MissionCompletedPlayback";

	public const string BattleFormations = "Battle.Formations";

	public const string BattleUnlockFormation = "Battle.UnlockFormation";

	public const string PlayBackFirst = "PlayBack.First";

	public const string PlayBackPlayBtn = "PlayBack.PlayBtn";

	public const string ENTER_MAIN_CITY = "Battle.EnterMainCity";

	public const string MainCityChatContentList = "MainCity.ChatContentList";

	public const string MainCityLegionBtn = "MainCity.LegionBtn";

	public const string MainCityGoToBattleBtn = "MainCity.GoToBattleBtn";

	public const string MainCityStorehouse = "MainCity.Storehouse";

	public const string MainCityCamp = "MainCity.Camp";

	public const string MainCityHallOfWar = "MainCity.HallOfWar";

	public const string MainCityPortalEarth = "MainCity.PortalEarth";

	public const string MainCityForge = "MainCity.Forge";

	public const string MainCityThrone = "MainCity.Throne";

	public const string MainCityBlackMarket = "MainCity.BlackMarket";

	public const string MainCityMilitaryIntelligence = "MainCity.MilitaryIntelligence";

	public const string MainCityLotteryBtn = "MainCity.LotteryBtn";

	public const string MainCityDungeonBtn = "MainCity.DungeonBtn";

	public const string MainCityTechnologyBtn = "MainCity.TechnologyBtn";

	public const string MainCityActivitiesBtn = "MainCity.ActivitiesBtn";

	public const string MainCityPageLeft = "MainCity.PageLeft";

	public const string MainCityPageRight = "MainCity.PageRight";

	public const string MainCityMailBoxBtn = "MainCity.MailBoxBtn";

	public const string MainCitySpecialEntrance = "MainCity.SpecialEntrance";

	public const string MainCityLegendItems = "MainCity.LegendItems";

	public const string MainCityPVPEntrance = "MainCity.PVPEntrance";

	public const string MainCityWorkerBtn = "MainCity.WorkerBtn";

	public const string MainCityVideoEntrance = "MainCity.VideoEntrance";

	public const string MAIN_CITY_EXPEDITION_HALL_ENTRANCE = "MainCity.ExpeditionHallEntrance";

	public const string RECHARGE_ACTIVITY_BTN = "MainCity.RechargeActivityBtn";

	public const string NewbieMissionPopup = "NewbieMission.Popup";

	public const string NewbieMissionMainCityCom = "NewbieMission.MainCityCom";

	public const string LegionPanelTabSoldier = "LegionPanel.TabSoldier";

	public const string LegionPanelTabPieces = "LegionPanel.TabPieces";

	public const string LegionPanelFirstSoldier = "LegionPanel.FirstSoldier";

	public const string LegionPanelFirstPieces = "LegionPanel.FirstPieces";

	public const string LegionPanelGoblinSoldier = "LegionPanel.GoblinSoldier";

	public const string LegionPanelGoblinScout = "LegionPanel.GoblinScout";

	public const string LegionPanelGoblinKnight = "LegionPanel.GoblinKnight";

	public const string LegionPanelGoblinProphet = "LegionPanel.GoblinProphet";

	public const string LegionPanelGoblinProphetPieces = "LegionPanel.GoblinProphetPieces";

	public const string LegionPanelGhostWarrior = "LegionPanel.GhostWarrior";

	public const string LegionPanelSummonBtn = "LegionPanel.SummonBtn";

	public const string LegionPanelCloseBtn = "LegionPanel.CloseBtn";

	public const string LegionPanelSoldier = "LegionPanel.Soldier";

	public const string LegionPanelSoldierPiece = "LegionPanel.SoldierPiece";

	public const string LegionPanel = "LegionPanel";

	public const string StationConfirmPanelAssignBtn = "StationConfirmPanel.AssignBtn";

	public const string SoldierCultivateTabInfo = "SoldierCultivate.TabInfo";

	public const string SoldierCultivateTabBreakthrough = "SoldierCultivate.TabBreakthrough";

	public const string SoldierCultivateTabEvolute = "SoldierCultivate.TabEvolute";

	public const string SoldierCultivateTabPotential = "SoldierCultivate.TabPotential";

	public const string SoldierCultivateTabSoulStone = "SoldierCultivate.TabSoulStone";

	public const string SoldierCultivateLevelUpBtn = "SoldierCultivate.LevelUpBtn";

	public const string SoldierCultivateFirstLevelUpItem = "SoldierCultivate.FirstLevelUpItem";

	public const string SoldierCultivateConfirmLevelUpBtn = "SoldierCultivate.ConfirmLevelUpBtn";

	public const string SoldierCultivateConfirmQuickLevelUpBtn = "SoldierCultivate.ConfirmQuickLevelUpBtn";

	public const string SoldierCultivateUpgradePotentialBtn = "SoldierCultivate.UpgradePotentialBtn";

	public const string SoldierCultivateCloseBtn = "SoldierCultivate.CloseBtn";

	public const string SoldierCultivateFirstSoulStone = "SoldierCultivate.FirstSoulStone";

	public const string SoldierCultivateSecondSoulStone = "SoldierCultivate.SecondSoulStone";

	public const string SoldierCultivateThirdSoulStone = "SoldierCultivate.ThirdSoulStone";

	public const string SoldierCultivateSoulStoneList = "SoldierCultivate.SoulStoneList";

	public const string SoldierCultivateSoulStoneCompositeBtn = "SoldierCultivate.SoulStoneCompositeBtn";

	public const string SoldierCultivateSoulStoneConfirmBtn = "SoldierCultivate.SoulStoneConfirmBtn";

	public const string SoldierCultivateOneClickFillStone = "SoldierCultivate.OneClickFillStone";

	public const string SoldierCultivateWeapons = "SoldierCultivate.Weapons";

	public const string SoldierPotentialUpgradeSuccessConfirmBtn = "SoldierPotentialUpgradeSuccess.ConfirmBtn";

	public const string SoldierEvoluteSuccessConfirmBtn = "SoldierEvoluteSuccess.ConfirmBtn";

	public const string SoldierCultivateFormationSoldierAmountBtn = "SoldierCultivate.FormationSoldierAmountBtn";

	public const string StorehouseTabUsableItem = "Storehouse.TabUsableItem";

	public const string StorehouseTabWeapon = "Storehouse.TabWeapon";

	public const string StorehouseTabResource = "Storehouse.TabResource";

	public const string StorehouseUpgradeBtn = "Storehouse.UpgradeBtn";

	public const string StorehouseCloseBtn = "Storehouse.CloseBtn";

	public const string StorehouseItem = "Storehouse.Item";

	public const string CampFirstProduction = "Camp.FirstProduction";

	public const string CampConfirmChangeBtn = "Camp.ConfirmChangeBtn";

	public const string CampConfirmProduceBtn = "Camp.ConfirmProduceBtn";

	public const string CampFirstMaterial = "Camp.FirstMaterial";

	public const string CollectionPanelAddWorkerBtn = "CollectionPanel.AddWorkerBtn";

	public const string CollectionPanelReduceWorkerBtn = "CollectionPanel.ReduceWorkerBtn";

	public const string CollectionPanelConfirmDistributionBtn = "CollectionPanel.ConfirmDistributionBtn";

	public const string CollectionPanelUpgradeBtn = "CollectionPanel.UpgradeBtn";

	public const string CollectionPanelPortal = "CollectionPanel.Portal";

	public const string ResourceSelectPanelCopper = "ResourceSelectPanel.Copper";

	public const string ResourceSelectPanelMarble = "ResourceSelectPanel.Marble";

	public const string ResourceSelectPanelProduct = "ResourceSelectPanel.Product";

	public const string ResourceSelectConfirmChosenBtn = "ResourceSelectPanel.ConfirmChosenBtn";

	public const string WorkshopFirstProductionAddWorkerBtn = "Workshop.FirstProductionAddWorkerBtn";

	public const string WorkshopFirstProductionReduceWorkerBtn = "Workshop.FirstProductionReduceWorkerBtn";

	public const string WorkshopFirstProductionUpgradeBtn = "Workshop.FirstProductionUpgradeBtn";

	public const string WorkshopConfirmDistributionBtn = "Workshop.ConfirmDistributionBtn";

	public const string WorkshopUpgradeBtn = "Workshop.UpgradeBtn";

	public const string WorkshopItem = "Workshop.Item";

	public const string WorkshopAddWorkerBtn = "Workshop.AddWorkerBtn";

	public const string WorkshopReduceWorkerBtn = "Workshop.ReduceWorkerBtn";

	public const string WorkshopItemUpgradeBtn = "Workshop.ItemUpgradeBtn";

	public const string BuildingUpgradePanelConfirmBtn = "BuildingUpgradePanel.ConfirmBtn";

	public const string BuildingUpgradePanelAddWorkerBtn = "BuildingUpgradePanel.AddWorkerBtn";

	public const string BuildingUpgradePanelReduceWorkerBtn = "BuildingUpgradePanel.ReduceWorkerBtn";

	public const string ProductUpgradePanelConfirmBtn = "ProductUpgradePanel.ConfirmBtn";

	public const string MaterialIntroductionPanelProduceBtn = "MaterialIntroductionPanel.ProduceBtn";

	public const string TakeItemsClaimBtn = "TakeItems.ClaimBtn";

	public const string TakeItemsBuyBtn = "TakeItems.BuyBtn";

	public const string ContractPanel = "ContractPanel";

	public const string SoldierShowPanel = "SoldierShowPanel";

	public const string SoldierShowPanelConfirmBtn = "SoldierShowPanel.ConfirmBtn";

	public const string WorldMapBattleBtn = "WorldMap.BattleBtn";

	public const string WorldMapRegionFirstStrongholdBtn = "WorldMap.RegionFirstStrongholdBtn";

	public const string WorldMapRegionSecondStrongholdBtn = "WorldMap.RegionSecondStrongholdBtn";

	public const string WorldMapForestMistRegion = "WorldMap.ForestMistRegion";

	public const string BlackMarketLotteryEntrance = "BlackMarket.LotteryEntrance";

	public const string BlackMarketEntrance = "BlackMarket.Entrance";

	public const string BlackMarketExitBtn = "BlackMarket.ExitBtn";

	public const string MilitaryIntelligenceDungeonInstanceEntrance = "MilitaryIntelligence.DungeonInstanceEntrance";

	public const string MilitaryIntelligenceTimeLimitDungeonInstanceEntrance = "MilitaryIntelligence.TimeLimitDungeonInstanceEntrance";

	public const string LotteryPanelFirstLotteryOption = "LotteryPanel.FirstLotteryOption";

	public const string LotteryPanelSecondLotteryOption = "LotteryPanel.SecondLotteryOption";

	public const string LotteryPanelNewbieLotteryOption = "LotteryPanel.NewbieLotteryOption";

	public const string LotteryPanelGemDisplay = "LotteryPanel.GemDisplay";

	public const string LotteryPanelTicketDisplay = "LotteryPanel.TicketDisplay";

	public const string LotteryPanelAddGemBtn = "LotteryPanel.AddGemBtn";

	public const string LotteryPanelAddTicketBtn = "LotteryPanel.AddTicketBtn";

	public const string LotteryPanelFirstLotteryResult = "LotteryPanel.FirstLotteryResult";

	public const string LotteryPanelSecondLotteryResult = "LotteryPanel.SecondLotteryResult";

	public const string LotteryPanelClaimBtn = "LotteryPanel.ClaimBtn";

	public const string LotteryPanelDrawAgainBtn = "LotteryPanel.DrawAgainBtn";

	public const string LotteryPanelInterruptBack = "LotteryPanel.InterruptBack";

	public const string LotteryPanelExitBtn = "LotteryPanel.ExitBtn";

	public const string LotteryPanelTipPosClickGraph = "LotteryPanel.TipPosClickGraph";

	public const string LotteryPanelNewbieCard = "LotteryPanel.NewbieCard";

	public const string LotteryPanelNewbieCardSoldier = "LotteryPanel.NewbieCardSoldier";

	public const string DungeonInstancePanelFirstLevelEntrance = "DungeonInstancePanel.FirstLevelEntrance";

	public const string DungeonInstancePanelFirstLevelMassBtn = "DungeonInstancePanel.FirstLevelMassButton";

	public const string DungeonInstancePanelLevelEntrance = "DungeonInstancePanel.LevelEntrance";

	public const string DungeonInstancePanelLevelMassBtn = "DungeonInstancePanel.LevelMassButton";

	public const string DungeonInstancePanelScoreBonusBar = "DungeonInstancePanel.ScoreBonusBar";

	public const string DungeonPanelBuildingCard = "DungeonPanel.BuildingCard";

	public const string DungeonPanelBuildingRepairBtn = "DungeonPanel.BuildingRepairBtn";

	public const string DungeonPanelBuildingUpgradeBtn = "DungeonPanel.BuildingUpgradeBtn";

	public const string DungeonPanelBuildingAcceptBtn = "DungeonPanel.BuildingAcceptBtn";

	public const string GiftBagPanelItemList = "GiftBagPanel.ItemList";

	public const string UpgradeSuccessPanelFrameLoader = "UpgradeSuccessPanel.FrameLoader";

	public const string HomeActivitiesPanelTabs = "HomeActivitiesPanel.Tabs";

	public const string HomeActivitiesPanelSpringFestivalTab = "HomeActivitiesPanel.SpringFestivalTab";

	public const string LegendItemsFirstItem = "LegendItems.FirstItem";

	public const string LegendItemCultivation = "LegendItem.Cultivation";

	public const string MatchingPanelSoldierList = "MatchingPanel.SoldierList";

	public const string MatchingPanelFakeSoldierList = "MatchingPanel.FakeSoldierList";

	public const string CampExitBtn = "Camp.ExitBtn";

	public const string GvGWorldMap2CampScore = "GvGWorldMap2.CampScore";

	public const string GvGWorldMap2MyLegion = "GvGWorldMap2.MyLegion";

	public const string GvGWorldMap2HoldingPercents = "GvGWorldMap2.HoldingPercents";

	public const string GvGWorldMap2StrategyBtn = "GvGWorldMap2.StrategyBtn";

	public const string MyTroopsClose = "MyTroops.Close";

	public const string MyCampIsland = "MyCampIsland";

	public const string MyCampIslandFakeClick = "MyCampIsland.FakeClick";

	public const string MainIslandPanelClose = "MainIslandPanel.Close";

	public const string CampCheckSoldierLimit = "Camp.CheckSoldierLimit";

	public const string GvGBossDetailShow = "GvG.BossDetailShow";

	public const string GvGSelectSoldierPopup = "GvG.SelectSoldierPopup";

	public static UiTagManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new UiTagManager();
			}
			return _Instance;
		}
	}

	public Dictionary<string, HashSet<object>> TagDicts => _tagsDict;

	private UiTagManager()
	{
		InitInstance();
	}

	public void InitInstance()
	{
		_tagsDict = new Dictionary<string, HashSet<object>>();
	}

	public void Register(string tag, object uiObject)
	{
		if (!_tagsDict.ContainsKey(tag))
		{
			_tagsDict.Add(tag, new HashSet<object> { uiObject });
		}
		else
		{
			_tagsDict[tag].Add(uiObject);
		}
	}

	public void Unregister(string tag, object uiObject)
	{
		if (_tagsDict.ContainsKey(tag))
		{
			_tagsDict[tag].Remove(uiObject);
		}
	}

	public void Unregister(string tag)
	{
		if (_tagsDict.ContainsKey(tag))
		{
			_tagsDict[tag].Clear();
		}
	}

	public HashSet<object> FindObjectsByTags(string[] tags)
	{
		HashSet<object>[] array = new HashSet<object>[tags.Length];
		for (int i = 0; i < tags.Length; i++)
		{
			array[i] = FindObjectsByTag(tags[i]);
		}
		HashSet<object> hashSet = array[0];
		for (int j = 1; j < tags.Length; j++)
		{
			hashSet = (HashSet<object>)hashSet.Intersect(array[j]);
		}
		return hashSet;
	}

	public HashSet<object> FindObjectsByTag(string tag)
	{
		if (_tagsDict.ContainsKey(tag))
		{
			return _tagsDict[tag];
		}
		return new HashSet<object>();
	}

	public object FindObjectByTags(string[] tags)
	{
		HashSet<object>[] array = new HashSet<object>[tags.Length];
		for (int i = 0; i < tags.Length; i++)
		{
			array[i] = FindObjectsByTag(tags[i]);
		}
		HashSet<object> hashSet = array[0];
		for (int j = 1; j < tags.Length; j++)
		{
			hashSet = (HashSet<object>)hashSet.Intersect(array[j]);
		}
		return hashSet.First();
	}

	public object FindObjectByTag(string tag)
	{
		object value = null;
		if (tag.Contains(":"))
		{
			string[] array = tag.Split(':');
			if (array.Length == 2)
			{
				FindObjectsMapByTag(array[0])?.TryGetValue(array[1], out value);
			}
		}
		else if (tag.Contains("@"))
		{
			string[] array2 = tag.Split('@');
			if (array2.Length == 2)
			{
				Dictionary<string, object> dictionary = FindObjectsMapByTag(array2[0]);
				int num = int.Parse(array2[1]);
				if (dictionary != null && num > 0 && num <= dictionary.Count)
				{
					value = dictionary.Values.ToArray()[num - 1];
				}
			}
		}
		if (value == null && _tagsDict.TryGetValue(tag, out var value2) && value2.Count > 0)
		{
			value = value2.First();
		}
		return value;
	}

	public Dictionary<string, object> FindObjectsMapByTag(string tag)
	{
		return (Dictionary<string, object>)FindObjectByTag(tag);
	}
}
