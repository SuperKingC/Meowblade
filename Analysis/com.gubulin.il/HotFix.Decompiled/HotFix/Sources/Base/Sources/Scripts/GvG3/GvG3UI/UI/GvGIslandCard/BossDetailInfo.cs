using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGIslandCard;

public class BossDetailInfo
{
	private Soldier _baseSoldier;

	private FakeSoldier _fakeSoldier;

	private Feature _feature;

	private List<string> _abilityList;

	public UnitInfo_Protocol BossUnitInfo { get; set; }

	public IslandBossInfo IslandBossInfo { get; set; }

	public C2S_GetFinalProgressInfo.FinalProgressBossInfo BossState => Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo.BossInfo;

	public Soldier BaseSoldier => _baseSoldier ?? (_baseSoldier = GameManagers.Instance.SoldierManager.Get(BossUnitInfo.SoldierId));

	public FakeSoldier FakeSoldier => _fakeSoldier ?? (_fakeSoldier = new FakeSoldier(BaseSoldier.Data.ParentSoldierId, BaseSoldier.Level, BaseSoldier.EvoLevel, BossUnitInfo.PotentialLevel));

	public Feature FeatureConfig => _feature ?? (_feature = "GvG3BossFeature".ToConfiguration<Dictionary<string, Feature>>()[BossUnitInfo.SoldierId]);

	public List<string> AbilityList => _abilityList ?? (_abilityList = BaseSoldier.AbilityList.Where((string aId) => aId.StartsWith("A") && GDMgr.TryGetWithErrorHandling<GDEAbilityData>(aId).Visible).ToList());
}
