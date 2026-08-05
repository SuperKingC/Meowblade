using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using UI.GvGWorldMap3;
using UI.Tips;
using UnityEngine;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_LandOfEternalNightStep : GComponent, IFairyComponent
{
	public Controller Step;

	public Controller Type;

	public Controller BossState;

	public GLoader Icon;

	public GImage n2;

	public GList Steps;

	public GImage n4;

	public GLoader n5;

	public GTextField n7;

	public GTextField n28;

	public UI_btn_Continue ContinueProgress;

	public GGroup n36;

	public GProgressBar BossHealth;

	public UI_com_ShadowMaster ShadowMaster;

	public GImage n46;

	public GList BossBuff;

	public GTextField n40;

	public GTextField RevivalsCnt;

	public GMovieClip n42;

	public GMovieClip n43;

	public GTextField n44;

	public GGroup n35;

	public GTextField n26;

	public GTextField n45;

	public GTextField TestingMuId;

	public const string URL = "ui://249h3k3dzit42o";

	public static string Name = "UI_com_LandOfEternalNightStep";

	private UI_bar_ShadowEnergy3 _bossHealthBar;

	private bool Activated => Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed;

	private bool WaitCheckEternalNightBoss => !Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightBossAppear && Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight && !Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement && Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep == 2;

	public static string GetURL()
	{
		return "ui://249h3k3dzit42o";
	}

	public static UI_com_LandOfEternalNightStep CreateInstance()
	{
		return (UI_com_LandOfEternalNightStep)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_LandOfEternalNightStep");
	}

	public static UI_com_LandOfEternalNightStep CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfEternalNightStep).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Step = ((GComponent)this).GetController("Step");
		Type = ((GComponent)this).GetController("Type");
		BossState = ((GComponent)this).GetController("BossState");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Steps = (GList)((GComponent)this).GetChild("Steps");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://249h3k3dzit42o".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id2 = "ui://249h3k3dzit42o".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id2);
		ContinueProgress = (UI_btn_Continue)(object)((GComponent)this).GetChild("ContinueProgress");
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		BossHealth = (GProgressBar)((GComponent)this).GetChild("BossHealth");
		ShadowMaster = (UI_com_ShadowMaster)(object)((GComponent)this).GetChild("ShadowMaster");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		BossBuff = (GList)((GComponent)this).GetChild("BossBuff");
		n40 = (GTextField)((GComponent)this).GetChild("n40");
		string id3 = "ui://249h3k3dzit42o".Replace("ui://", "") + "-" + ((GObject)n40).id;
		((GObject)n40).text = LanguagesManager.GetDesc(id3);
		RevivalsCnt = (GTextField)((GComponent)this).GetChild("RevivalsCnt");
		n42 = (GMovieClip)((GComponent)this).GetChild("n42");
		n43 = (GMovieClip)((GComponent)this).GetChild("n43");
		n44 = (GTextField)((GComponent)this).GetChild("n44");
		string id4 = "ui://249h3k3dzit42o".Replace("ui://", "") + "-" + ((GObject)n44).id;
		((GObject)n44).text = LanguagesManager.GetDesc(id4);
		n35 = (GGroup)((GComponent)this).GetChild("n35");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id5 = "ui://249h3k3dzit42o".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id5);
		n45 = (GTextField)((GComponent)this).GetChild("n45");
		string id6 = "ui://249h3k3dzit42o".Replace("ui://", "") + "-" + ((GObject)n45).id;
		((GObject)n45).text = LanguagesManager.GetDesc(id6);
		TestingMuId = (GTextField)((GComponent)this).GetChild("TestingMuId");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		_bossHealthBar = (UI_bar_ShadowEnergy3)(object)BossHealth;
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderMainMissions = (Action<CampMainMissionUiModel>)Delegate.Combine(instance.RenderMainMissions, new Action<CampMainMissionUiModel>(UpdateUi));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Combine(instance2.OnFinalProgressInfoChange, new Action(UpdateUi));
		GvG3FlagShipMissionsManager instance3 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance3.OnCampProgressChange = (Action)Delegate.Combine(instance3.OnCampProgressChange, new Action(UpdateWaitCheckEternalNightBossUi));
		((GObject)ContinueProgress).onClick.Set(new EventCallback0(CheckEternalNightBoss));
		((GObject)_bossHealthBar.BossBreakDownTip).onClick.Set(new EventCallback1(DisplayBossBreakDownTip));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderMainMissions = (Action<CampMainMissionUiModel>)Delegate.Remove(instance.RenderMainMissions, new Action<CampMainMissionUiModel>(UpdateUi));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Remove(instance2.OnFinalProgressInfoChange, new Action(UpdateUi));
		GvG3FlagShipMissionsManager instance3 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance3.OnCampProgressChange = (Action)Delegate.Remove(instance3.OnCampProgressChange, new Action(UpdateWaitCheckEternalNightBossUi));
		((GObject)ContinueProgress).onClick.Clear();
		((GObject)_bossHealthBar.BossBreakDownTip).onClick.Clear();
	}

	private void UpdateUi(CampMainMissionUiModel model)
	{
		Render(model);
	}

	private void UpdateUi()
	{
		Render(Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightMainMission);
	}

	private void Render(CampMainMissionUiModel model)
	{
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		if (!Activated)
		{
			return;
		}
		if (WaitCheckEternalNightBoss)
		{
			Step.selectedIndex = 0;
			UpdateWaitCheckEternalNightBossUi();
			return;
		}
		Step.selectedIndex = (Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement ? 2 : (model.Step - 1));
		Steps.selectedIndex = Step.selectedIndex;
		C2S_GetFinalProgressInfo.Response finalInfo = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo;
		BindableProperty<string> finalBossIcon = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalBossIcon;
		SetBossIcon(finalBossIcon.Value);
		finalBossIcon.AddAction(SetBossIcon);
		if (Step.selectedIndex != 0)
		{
			if (Step.selectedIndex == 1)
			{
				BossState.selectedIndex = (finalInfo.BossInfo.EnterBossNearDeath ? 2 : 0);
				((GObject)RevivalsCnt).text = finalInfo.BossInfo.BossCanRebornCnt.ToString();
				((GComponent)BossHealth).GetChild("Energy").text = finalInfo.BossInfo.BossHp.ShortNumberFormat() + "/" + finalInfo.BossInfo.BossMaxHp.ShortNumberFormat();
				BossHealth.value = (double)finalInfo.BossInfo.BossHp / (double)finalInfo.BossInfo.BossMaxHp * 100.0;
				if (finalInfo.BossInfo.BossBuff != null)
				{
					BossBuff.itemRenderer = new ListItemRenderer(RenderBossBuff);
					BossBuff.numItems = finalInfo.BossInfo.BossBuff.Count;
				}
			}
			else if (Step.selectedIndex == 2)
			{
				BossState.selectedIndex = 1;
				if (finalInfo.BossInfo.BossBuff != null)
				{
					BossBuff.itemRenderer = new ListItemRenderer(RenderBossBuff);
					BossBuff.numItems = finalInfo.BossInfo.BossBuff.Count;
				}
			}
		}
		if (Define.GvGMode3UnderTesting)
		{
			((GObject)TestingMuId).text = $"({model.MainMission.MUid})";
		}
		void RenderBossBuff(int index, GObject obj)
		{
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			if (obj is UI.GvGWorldMap3.UI_com_Ability uI_com_Ability)
			{
				ItemAbility itemAbility = (ItemAbility)(((GObject)uI_com_Ability).data = finalInfo.BossInfo.BossBuff[index].ItemAbility);
				((GObject)uI_com_Ability.LvNum).text = $"LV{itemAbility.AbilityLevel}";
				GLoader asLoader = uI_com_Ability.icon.GetChild("Icon").asLoader;
				string url = (itemAbility.Icon = itemAbility.AbilityData.Icon.ToPublicResourcesRgbIcon());
				asLoader.url = url;
				uI_com_Ability.Type.SetSelectedIndex(1);
				((GObject)uI_com_Ability).onClick.Set(new EventCallback1(OnAbilityItemClick));
			}
		}
		void SetBossIcon(string bossIconUrl)
		{
			if (!((GObject)this).isDisposed)
			{
				ShadowMaster.Icon.url = bossIconUrl;
			}
		}
	}

	private void OnAbilityItemClick(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		if (val.data is ItemAbility itemAbility)
		{
			Vector2 val2 = default(Vector2);
			((Vector2)(ref val2))._002Ector(960f, 680f);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
			{
				{ "Pos", val2 },
				{ "Data", itemAbility.AbilityData },
				{ "Limit", 0 },
				{ "State", true },
				{ "GList", null },
				{ "SkillIconUrl", itemAbility.Icon },
				{ "Level", itemAbility.AbilityLevel }
			});
		}
	}

	private void UpdateWaitCheckEternalNightBossUi()
	{
		Type.selectedIndex = (WaitCheckEternalNightBoss ? 1 : 0);
	}

	private void CheckEternalNightBoss()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.TryPlayEternalNightUiTransitions(inform: true);
	}

	private static void DisplayBossBreakDownTip(EventContext context)
	{
		context.StopPropagation();
		UI_main_BossBreakDownTip.OpenBossBreakDownTip();
	}
}
