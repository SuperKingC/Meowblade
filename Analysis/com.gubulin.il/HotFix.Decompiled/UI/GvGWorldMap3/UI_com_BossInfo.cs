using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGIslandCard;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.Client.Sources.Extensions;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Spine.Unity;
using UI.EnemyIntroduction;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_BossInfo : GComponent
{
	public Controller State;

	public GImage n11;

	public GImage n20;

	public GImage n16;

	public UI_com_BossSpinWrapper BossSpine;

	public GImage n13;

	public GImage n26;

	public GTextField n1;

	public UI_com_ShadowMaster BossIcon;

	public GImage n15;

	public GTextField n9;

	public GTextField Countdown;

	public GTextField n5;

	public GTextField CanRebornCnt;

	public GTextField CurHealth;

	public GTextField n4;

	public GTextField n21;

	public GGraph BreakDownTipBack;

	public UI_btn_BossBreakDownTip n25;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2c6jrs6t";

	public static string Name = "UI_com_BossInfo";

	private Coroutine _rebornCountdown;

	private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

	private BossDetailInfo _bossDetailInfo;

	private string _bossSpineId;

	public static string GetURL()
	{
		return "ui://4eq8fgd2c6jrs6t";
	}

	public static UI_com_BossInfo CreateInstance()
	{
		return (UI_com_BossInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BossInfo");
	}

	public static UI_com_BossInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2c6jrs6t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		BossSpine = (UI_com_BossSpinWrapper)(object)((GComponent)this).GetChild("BossSpine");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2c6jrs6t".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		BossIcon = (UI_com_ShadowMaster)(object)((GComponent)this).GetChild("BossIcon");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://4eq8fgd2c6jrs6t".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://4eq8fgd2c6jrs6t".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
		CanRebornCnt = (GTextField)((GComponent)this).GetChild("CanRebornCnt");
		CurHealth = (GTextField)((GComponent)this).GetChild("CurHealth");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id4 = "ui://4eq8fgd2c6jrs6t".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id4);
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id5 = "ui://4eq8fgd2c6jrs6t".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id5);
		BreakDownTipBack = (GGraph)((GComponent)this).GetChild("BreakDownTipBack");
		n25 = (UI_btn_BossBreakDownTip)(object)((GComponent)this).GetChild("n25");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void OnLoad()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		_bossDetailInfo = new BossDetailInfo();
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnFinalProgressInfoChange = (Action)Delegate.Combine(instance.OnFinalProgressInfoChange, new Action(RenderBossInfo));
		((GObject)this).onClick.Add(new EventCallback0(ShowBossDetail));
		((GObject)BreakDownTipBack).onClick.Set(new EventCallback1(DisplayBossBreakDownTip));
		((GObject)n25).onClick.Set(new EventCallback1(DisplayBossBreakDownTip));
	}

	public void OnClose()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnFinalProgressInfoChange = (Action)Delegate.Remove(instance.OnFinalProgressInfoChange, new Action(RenderBossInfo));
		if (_rebornCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_rebornCountdown);
			_rebornCountdown = null;
		}
		((GObject)BossSpine.SpineWrapper).displayObject.Dispose();
		_bossDetailInfo = null;
		((GObject)BreakDownTipBack).onClick.Clear();
		((GObject)n25).onClick.Clear();
		((GObject)this).onClick.Clear();
	}

	public void OnRender(IslandStateModel islandState)
	{
		RenderBossConfigInfo(islandState);
		Singleton<GvG3FlagShipMissionsManager>.Instance.GetFinalProgressInfo();
	}

	private void RenderBossConfigInfo(IslandStateModel islandState)
	{
		_bossDetailInfo.BossUnitInfo = GetBossUnit();
		Soldier bossSoldier = GameManagers.Instance.SoldierManager.Get(_bossDetailInfo.BossUnitInfo.SoldierId, useCache: false);
		_bossSpineId = bossSoldier.Data.ParentSoldierId;
		UiHelper.LoadSoilderSpine_Addressable(BossSpine.SpineWrapper, _bossSpineId + "_" + bossSoldier.Skin, 40f, delegate(SkeletonAnimation animation)
		{
			if (!((GObject)this).isDisposed)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, bossSoldier.Skin);
				animation.AnimationState.SetAnimation(0, "idle", true);
			}
		}, isMask: true);
		BossIcon.Icon.url = bossSoldier.GetGvG3SoldierIconUrl();
		UnitInfo_Protocol GetBossUnit()
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
	}

	private void RenderBossInfo()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		C2S_GetFinalProgressInfo.FinalProgressBossInfo bossStateInfo = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo.BossInfo;
		bool flag = Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement || Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement;
		bool resurrecting = bossStateInfo.Resurrecting;
		if (flag)
		{
			State.SetSelectedIndex(2);
		}
		else if (resurrecting)
		{
			State.SetSelectedIndex(1);
			if (_rebornCountdown == null)
			{
				_rebornCountdown = FGUIManager.Instance.OpenIEnumerator(ShowCountdown());
			}
		}
		else if (bossStateInfo.EnterBossNearDeath)
		{
			State.SetSelectedIndex(3);
		}
		else
		{
			State.SetSelectedIndex(0);
		}
		((GObject)CanRebornCnt).text = $"{bossStateInfo.BossCanRebornCnt}";
		((GObject)CurHealth).text = $"{(double)bossStateInfo.BossHp / (double)bossStateInfo.BossMaxHp * 100.0:F2}%";
		IEnumerator ShowCountdown()
		{
			int countdown = bossStateInfo.NextRebornTimestamp - (int)GameController.Instance.GetServerTime();
			while (countdown > 0)
			{
				yield return _waitForSeconds;
				countdown = bossStateInfo.NextRebornTimestamp - (int)GameController.Instance.GetServerTime();
				((GObject)Countdown).text = UiHelper.ParseTime(countdown);
			}
			((GObject)Countdown).text = string.Empty;
			State.SetSelectedIndex(0);
		}
	}

	private void ShowBossDetail()
	{
		if (_bossDetailInfo.BossUnitInfo != null)
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(_bossDetailInfo.BossUnitInfo.SoldierId);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{
					"SoldierId",
					soldier.Data.ParentSoldierId
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
					_bossDetailInfo.BossState.BossAttack
				},
				{
					"DEF",
					_bossDetailInfo.BossState.BossDefense
				},
				{
					"HP",
					_bossDetailInfo.BossState.BossMaxHp
				},
				{
					"LegendItemBrief",
					new List<LegendItemBrief>()
				},
				{ "IsBoss", true },
				{
					"PotentialLevel",
					_bossDetailInfo.BossUnitInfo.PotentialLevel
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
				{ "ChangedSkin", soldier.Skin }
			});
		}
	}

	private static void DisplayBossBreakDownTip(EventContext context)
	{
		context.StopPropagation();
		UI_main_BossBreakDownTip.OpenBossBreakDownTip();
	}
}
