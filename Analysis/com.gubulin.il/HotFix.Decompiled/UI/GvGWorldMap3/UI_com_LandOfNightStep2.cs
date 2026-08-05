using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.Tips;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_LandOfNightStep2 : GComponent, IFairyComponent
{
	public GImage n35;

	public GImage n34;

	public GImage n31;

	public UI_btn_CampOverview CampOverview;

	public GTextField n15;

	public UI_bar_ShadowEnergy2 ShadowProgress;

	public UI_bar_ShadowEnergy3 BossHealth;

	public UI_com_ShadowMaster ShadowMaster;

	public GList MyBuff;

	public GList BossBuff;

	public UI_btn_MotherShip FlagShip;

	public GTextField n21;

	public GTextField RevivalsCnt;

	public GMovieClip n32;

	public GMovieClip n33;

	public const string URL = "ui://4eq8fgd2zit4a9";

	public static string Name = "UI_com_LandOfNightStep2";

	private bool Activated => !WorldMapConfigHelper.Configs.IsBrawlEvent() && Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight && !((GObject)this).isDisposed && Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep == 2;

	public static string GetURL()
	{
		return "ui://4eq8fgd2zit4a9";
	}

	public static UI_com_LandOfNightStep2 CreateInstance()
	{
		return (UI_com_LandOfNightStep2)(object)UIPackage.CreateObject("GvGWorldMap3", "com_LandOfNightStep2");
	}

	public static UI_com_LandOfNightStep2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LandOfNightStep2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2zit4a9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		CampOverview = (UI_btn_CampOverview)(object)((GComponent)this).GetChild("CampOverview");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://4eq8fgd2zit4a9".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		ShadowProgress = (UI_bar_ShadowEnergy2)(object)((GComponent)this).GetChild("ShadowProgress");
		BossHealth = (UI_bar_ShadowEnergy3)(object)((GComponent)this).GetChild("BossHealth");
		ShadowMaster = (UI_com_ShadowMaster)(object)((GComponent)this).GetChild("ShadowMaster");
		MyBuff = (GList)((GComponent)this).GetChild("MyBuff");
		BossBuff = (GList)((GComponent)this).GetChild("BossBuff");
		FlagShip = (UI_btn_MotherShip)(object)((GComponent)this).GetChild("FlagShip");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://4eq8fgd2zit4a9".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		RevivalsCnt = (GTextField)((GComponent)this).GetChild("RevivalsCnt");
		n32 = (GMovieClip)((GComponent)this).GetChild("n32");
		n33 = (GMovieClip)((GComponent)this).GetChild("n33");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		((GObject)CampOverview).onClick.Set(new EventCallback0(ShowCampPlayers));
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Combine(instance2.OnFinalProgressInfoChange, new Action(Render));
		((GObject)FlagShip).onClick.Set(new EventCallback1(FocusIsland));
		((GObject)BossHealth.BossBreakDownTip).onClick.Set(new EventCallback1(DisplayBossBreakDownTip));
	}

	public void UnregisterUiEvent()
	{
		((GObject)CampOverview).onClick.Clear();
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnFinalProgressInfoChange = (Action)Delegate.Remove(instance2.OnFinalProgressInfoChange, new Action(Render));
		((GObject)FlagShip).onClick.Clear();
		((GObject)BossHealth.BossBreakDownTip).onClick.Clear();
	}

	public void Render()
	{
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		C2S_GetFinalProgressInfo.Response finalInfo;
		if (Activated)
		{
			CampOverview.Camp.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			GvG3FlagShipMissionModel eternalNightMission = Singleton<GvG3FlagShipMissionsManager>.Instance.GetEternalNightMission();
			finalInfo = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo;
			BindableProperty<string> finalBossIcon = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalBossIcon;
			SetBossIcon(finalBossIcon.Value);
			finalBossIcon.AddAction(SetBossIcon);
			if (eternalNightMission == null)
			{
				((GProgressBar)ShadowProgress).value = 100.0;
			}
			else
			{
				int collectShadowEnergy = eternalNightMission.Data.CollectShadowEnergy;
				int num = (int)eternalNightMission.CheckValues[0];
				int num2 = num - collectShadowEnergy;
				int num3 = (int)finalInfo.CampShadowEnergy - num2;
				((GProgressBar)ShadowProgress).value = (double)num3 / (double)num * 100.0;
			}
			if (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement || Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement)
			{
				BossHealth.Status.SetSelectedIndex(1);
			}
			else if (finalInfo.BossInfo.EnterBossNearDeath)
			{
				BossHealth.Status.SetSelectedIndex(2);
			}
			else
			{
				BossHealth.Status.SetSelectedIndex(0);
			}
			((GObject)RevivalsCnt).text = finalInfo.BossInfo.BossCanRebornCnt.ToString();
			((GObject)BossHealth.Energy).text = finalInfo.BossInfo.BossHp.ShortNumberFormat() + "/" + finalInfo.BossInfo.BossMaxHp.ShortNumberFormat();
			((GProgressBar)BossHealth).value = (double)finalInfo.BossInfo.BossHp / (double)finalInfo.BossInfo.BossMaxHp * 100.0;
			if (finalInfo.PlayerBuff != null)
			{
				MyBuff.itemRenderer = new ListItemRenderer(RenderMyBuff);
				MyBuff.numItems = finalInfo.PlayerBuff.Count;
			}
			if (finalInfo.BossInfo.BossBuff != null)
			{
				BossBuff.itemRenderer = new ListItemRenderer(RenderBossBuff);
				BossBuff.numItems = finalInfo.BossInfo.BossBuff.Count;
			}
			((GObject)FlagShip).data = new LocationData
			{
				IslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId,
				Type = 3,
				Step = 0
			};
		}
		void RenderBossBuff(int index, GObject obj)
		{
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			if (obj is UI_com_Ability uI_com_Ability)
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
		void RenderMyBuff(int index, GObject obj)
		{
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			if (obj is UI_com_Ability uI_com_Ability)
			{
				ItemAbility itemAbility = (ItemAbility)(((GObject)uI_com_Ability).data = finalInfo.PlayerBuff[index].ItemAbility);
				((GObject)uI_com_Ability.LvNum).text = $"LV{itemAbility.AbilityLevel}";
				GLoader asLoader = uI_com_Ability.icon.GetChild("Icon").asLoader;
				string url = (itemAbility.Icon = itemAbility.AbilityData.Icon.ToPublicResourcesRgbIcon());
				asLoader.url = url;
				uI_com_Ability.Type.SetSelectedIndex(0);
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

	private void ShowCampPlayers()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.GetCampInfo(ShowCampInfo);
		static void ShowCampInfo(C2S_GetCampInfo.Response response)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_CampPlayers.Name, new Dictionary<string, object> { { "CampInfo", response } });
		}
	}

	private void FocusIsland(EventContext context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		LocationData locationData = (LocationData)val.data;
		if (locationData != null)
		{
			UI_com_Islandlocation uI_com_Islandlocation = FairyGUITip.ShowTip<UI_com_Islandlocation>(val, eFairyGUITipDir.Down);
			uI_com_Islandlocation.Step.selectedIndex = locationData.Step;
			uI_com_Islandlocation.Type.selectedIndex = locationData.Type;
			((GObject)uI_com_Islandlocation.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(locationData.IslandId)?.Name;
			((GObject)uI_com_Islandlocation.Positioning).onClick.Set((EventCallback0)delegate
			{
				GvGWorldMapController.Instance.FocusIslandById(locationData.IslandId);
			});
		}
	}

	private static void DisplayBossBreakDownTip(EventContext context)
	{
		context.StopPropagation();
		UI_main_BossBreakDownTip.OpenBossBreakDownTip();
	}
}
