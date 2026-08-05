using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGIslandCard;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.EnemyIntroduction;

namespace UI.GvGWorldMap3;

public class UI_com_IslandBoss : GComponent
{
	public Controller State;

	public UI_bar_IslandBossHp Hp;

	public GImage n6;

	public UI_com_ShadowMaster BossIcon;

	public GMovieClip n0;

	public GTextField n5;

	public GImage n8;

	public const string URL = "ui://4eq8fgd2h5gss91";

	public static string Name = "UI_com_IslandBoss";

	private BossDetailInfo _bossDetailInfo;

	public static string GetURL()
	{
		return "ui://4eq8fgd2h5gss91";
	}

	public static UI_com_IslandBoss CreateInstance()
	{
		return (UI_com_IslandBoss)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandBoss");
	}

	public static UI_com_IslandBoss CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandBoss).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h5gss91", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		Hp = (UI_bar_IslandBossHp)(object)((GComponent)this).GetChild("Hp");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		BossIcon = (UI_com_ShadowMaster)(object)((GComponent)this).GetChild("BossIcon");
		n0 = (GMovieClip)((GComponent)this).GetChild("n0");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://4eq8fgd2h5gss91".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}

	public void OnLoad()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Add(new EventCallback0(ShowBossDetail));
		_bossDetailInfo = new BossDetailInfo();
	}

	public void OnClose()
	{
		((GObject)this).onClick.Clear();
		_bossDetailInfo = null;
	}

	public void OnRender(IslandStateModel islandState)
	{
		List<UI_main_IslandDefenders.UnitInfo> uiUnitInfos = islandState.DetailInfo.GetUiUnitInfos();
		UI_main_IslandDefenders.UnitInfo unitInfo = uiUnitInfos.Find((UI_main_IslandDefenders.UnitInfo u) => u.HasBoss);
		if (unitInfo == null)
		{
			((GObject)this).visible = false;
			return;
		}
		((GObject)this).visible = true;
		_bossDetailInfo.BossUnitInfo = GetBossUnit(islandState);
		_bossDetailInfo.IslandBossInfo = islandState.DetailInfo.BossInfo;
		string soldierId = unitInfo.UnitInfos.Find((UnitInfo_Protocol u) => u.IsBossUnit)?.SoldierId;
		BossIcon.Icon.url = GameManagers.Instance.SoldierManager.Get(soldierId).GetGvG3SoldierIconUrl();
		((GProgressBar)Hp).value = islandState.DetailInfo.BossHp;
		State.SetSelectedIndex((islandState.State == eGvGMode3IslandState.Fighting) ? 1 : 0);
	}

	private static UnitInfo_Protocol GetBossUnit(IslandStateModel islandState)
	{
		UnitInfo_Protocol unitInfo_Protocol = null;
		using (Dictionary<string, List<UnitInfo_Protocol>>.ValueCollection.Enumerator enumerator = islandState.DetailInfo.GetUnitInfos().Values.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				List<UnitInfo_Protocol> current = enumerator.Current;
				unitInfo_Protocol = current.Find((UnitInfo_Protocol u) => u.IsBossUnit);
			}
		}
		if (unitInfo_Protocol == null)
		{
			throw new Exception("UI_com_BossInfo bossUnit is null");
		}
		return unitInfo_Protocol;
	}

	private void ShowBossDetail()
	{
		Soldier bossSoldier;
		if (_bossDetailInfo.BossUnitInfo != null)
		{
			bossSoldier = GameManagers.Instance.SoldierManager.Get(_bossDetailInfo.BossUnitInfo.SoldierId);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{
					"SoldierId",
					bossSoldier.Data.ParentSoldierId
				},
				{ "FakeSoldierData", _bossDetailInfo.FakeSoldier },
				{
					"Num",
					_bossDetailInfo.BossUnitInfo.PerTeamMemberCnt
				},
				{
					"CombatPower",
					_bossDetailInfo.BossUnitInfo.CombatPower
				},
				{
					"ATK",
					_bossDetailInfo.IslandBossInfo.BossAttack
				},
				{
					"DEF",
					_bossDetailInfo.IslandBossInfo.BossDefense
				},
				{
					"HP",
					_bossDetailInfo.IslandBossInfo.BossMaxHp
				},
				{
					"LegendItemBrief",
					new List<LegendItemBrief>()
				},
				{ "IsBoss", true },
				{
					"PotentialLevel",
					GetBossPotentialLevel()
				},
				{
					"SpecialityName",
					_bossDetailInfo.FeatureConfig.FeatureUiName
				},
				{
					"SpecialityText",
					_bossDetailInfo.FeatureConfig.FeatureDesc
				},
				{ "ChangedAbilities", _bossDetailInfo.AbilityList },
				{ "ChangedSkin", bossSoldier.Skin }
			});
		}
		int GetBossPotentialLevel()
		{
			return (bossSoldier.Tags != null && bossSoldier.Tags.Contains("WORLD_BOSS")) ? 9 : _bossDetailInfo.BossUnitInfo.PotentialLevel;
		}
	}
}
