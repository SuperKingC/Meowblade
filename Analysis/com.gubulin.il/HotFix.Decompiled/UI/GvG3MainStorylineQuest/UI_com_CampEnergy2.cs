using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.GvGBrawlFight;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_CampEnergy2 : GComponent, IFairyComponent
{
	public Controller Camp;

	public Controller isBrawlFightEmpty;

	public Controller CampRank;

	public GImage n0;

	public GImage n36;

	public GImage n33;

	public GImage n49;

	public GImage n43;

	public GImage n40;

	public GImage n32;

	public GLoader n1;

	public GLoader n2;

	public GTextField CampName;

	public GTextField n5;

	public GTextField CurrentEnergy;

	public GTextField MoonIsland;

	public GTextField n9;

	public GTextField TotalEfficiency;

	public GTextField n11;

	public GTextField n20;

	public GTextField n42;

	public GTextField brawlFightTime;

	public GTextField brawlFightReward;

	public GLoader brawlFightHelpBtn;

	public GLoader n143;

	public GLoader brawlFightCampRank;

	public GGroup brawlFightInfo;

	public GImage n53;

	public GTextField n48;

	public GTextField StarIsland;

	public UI_com_01 n35;

	public GLoader MoonIslandIcon;

	public GLoader StarIslandIcon;

	public GTextField n26;

	public GTextField MoonEfficiency;

	public GTextField n30;

	public GGroup n41;

	public GTextField n27;

	public GTextField StarEfficiency;

	public GTextField n31;

	public GGroup n44;

	public const string URL = "ui://249h3k3diemus5r";

	public static string Name = "UI_com_CampEnergy2";

	private CampEnergyTweener campEnergyTweener;

	private int oldValue;

	private CampEnergyDetails _cache;

	private bool Activated => !Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed && !Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNightProgress;

	public static string GetURL()
	{
		return "ui://249h3k3diemus5r";
	}

	public static UI_com_CampEnergy2 CreateInstance()
	{
		return (UI_com_CampEnergy2)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_CampEnergy2");
	}

	public static UI_com_CampEnergy2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampEnergy2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3diemus5r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Expected O, but got Unknown
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Expected O, but got Unknown
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Expected O, but got Unknown
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Expected O, but got Unknown
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Expected O, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Expected O, but got Unknown
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		isBrawlFightEmpty = ((GComponent)this).GetController("isBrawlFightEmpty");
		CampRank = ((GComponent)this).GetController("CampRank");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		CampName = (GTextField)((GComponent)this).GetChild("CampName");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		CurrentEnergy = (GTextField)((GComponent)this).GetChild("CurrentEnergy");
		MoonIsland = (GTextField)((GComponent)this).GetChild("MoonIsland");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		TotalEfficiency = (GTextField)((GComponent)this).GetChild("TotalEfficiency");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id3 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id3);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id4 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id4);
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id5 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id5);
		brawlFightTime = (GTextField)((GComponent)this).GetChild("brawlFightTime");
		string id6 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)brawlFightTime).id;
		((GObject)brawlFightTime).text = LanguagesManager.GetDesc(id6);
		brawlFightReward = (GTextField)((GComponent)this).GetChild("brawlFightReward");
		string id7 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)brawlFightReward).id;
		((GObject)brawlFightReward).text = LanguagesManager.GetDesc(id7);
		brawlFightHelpBtn = (GLoader)((GComponent)this).GetChild("brawlFightHelpBtn");
		n143 = (GLoader)((GComponent)this).GetChild("n143");
		brawlFightCampRank = (GLoader)((GComponent)this).GetChild("brawlFightCampRank");
		brawlFightInfo = (GGroup)((GComponent)this).GetChild("brawlFightInfo");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id8 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id8);
		StarIsland = (GTextField)((GComponent)this).GetChild("StarIsland");
		n35 = (UI_com_01)(object)((GComponent)this).GetChild("n35");
		MoonIslandIcon = (GLoader)((GComponent)this).GetChild("MoonIslandIcon");
		StarIslandIcon = (GLoader)((GComponent)this).GetChild("StarIslandIcon");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id9 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id9);
		MoonEfficiency = (GTextField)((GComponent)this).GetChild("MoonEfficiency");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id10 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id10);
		n41 = (GGroup)((GComponent)this).GetChild("n41");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id11 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id11);
		StarEfficiency = (GTextField)((GComponent)this).GetChild("StarEfficiency");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id12 = "ui://249h3k3diemus5r".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id12);
		n44 = (GGroup)((GComponent)this).GetChild("n44");
	}

	public void Destroy()
	{
		campEnergyTweener.Kill();
	}

	public void Init()
	{
		oldValue = 0;
		campEnergyTweener = new CampEnergyTweener(oldValue, delegate(float val)
		{
			((GObject)CurrentEnergy).text = ((int)val).ToString();
		});
		int num = UI_main_BrawlFightEnroll.WhatDayIsToday();
		bool flag = num > 1;
		isBrawlFightEmpty.SetSelectedIndex((!flag) ? 1 : 0);
		if (flag)
		{
			int day = num - 1;
			((GObject)brawlFightTime).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("BrawlEventLastBattleName".ToLanguage(), GvGMode3BrawlEvent_BaseInfo.GetBrawlFightSettleTimeStr(day));
		}
	}

	public void ShowDiff(int diff)
	{
		if (diff != 0)
		{
			string text = ((diff < 0) ? "-" : "+");
			((GObject)n35.n35).text = text + diff;
			n35.t0.Play();
		}
	}

	public void RegisterUiEvent()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderCampEnergyDetails = (Action<CampEnergyDetails>)Delegate.Combine(instance.RenderCampEnergyDetails, new Action<CampEnergyDetails>(RenderCampEnergy));
		((GObject)MoonIslandIcon).onClick.Set(new EventCallback0(OpenMoonIslandDescription));
		((GObject)StarIslandIcon).onClick.Set(new EventCallback0(OpenStarIslandDescription));
		((GObject)brawlFightHelpBtn).onClick.Set(new EventCallback0(OnClickHelp));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderCampEnergyDetails = (Action<CampEnergyDetails>)Delegate.Remove(instance.RenderCampEnergyDetails, new Action<CampEnergyDetails>(RenderCampEnergy));
		((GObject)MoonIslandIcon).onClick.Clear();
		((GObject)StarIslandIcon).onClick.Clear();
		((GObject)brawlFightHelpBtn).onClick.Clear();
	}

	private void RenderCampEnergy(CampEnergyDetails details)
	{
		if (!Activated)
		{
			return;
		}
		_cache = details;
		Camp.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		((GObject)CampName).text = WorldMapConfigHelper.TryGetCampPrefabConfig(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId).CampName.ToLanguage();
		if (oldValue == 0)
		{
			campEnergyTweener.LastEndVal = details.CampEnergy;
			((GObject)CurrentEnergy).text = details.CampEnergy.ToString();
		}
		else
		{
			ShowDiff(details.CampEnergy - oldValue);
			campEnergyTweener.To(details.CampEnergy);
		}
		oldValue = details.CampEnergy;
		((GObject)TotalEfficiency).text = UiHelper.ShortNumberFormat(details.TotalEnergyEfficiencyPerDay, 2);
		List<CampEnergyDetailInfo> source = details.CampEnergyDetailInfos.Where((CampEnergyDetailInfo info) => info.IslandTypeValue == eIslandType.Moon || info.IslandTypeValue == eIslandType.MainMoon).ToList();
		if (source.Any())
		{
			((GObject)MoonIsland).text = source.Sum((CampEnergyDetailInfo island) => island.IslandCount).ToString();
			((GObject)MoonEfficiency).text = UiHelper.ShortNumberFormat(source.Sum((CampEnergyDetailInfo island) => island.EnergyEfficiencyPerDay), 2);
		}
		else
		{
			((GObject)MoonIsland).text = "--";
			((GObject)MoonEfficiency).text = "--";
		}
		CampEnergyDetailInfo campEnergyDetailInfo = details.CampEnergyDetailInfos.Find((CampEnergyDetailInfo info) => info.IslandTypeValue == eIslandType.Star);
		if (campEnergyDetailInfo != null)
		{
			((GObject)StarIsland).text = campEnergyDetailInfo.IslandCount.ToString();
			((GObject)StarEfficiency).text = UiHelper.ShortNumberFormat(campEnergyDetailInfo.EnergyEfficiencyPerDay, 2);
		}
		else
		{
			((GObject)StarIsland).text = "--";
			((GObject)StarEfficiency).text = "--";
		}
		int selectedIndex = Mathf.Clamp(details.BrawlEventRankLastDay - 1, 0, 3);
		CampRank.SetSelectedIndex(selectedIndex);
		((GObject)brawlFightReward).text = "BrawlEventCampRankRewardTip".ToLanguage().Format(details.BrawlEventCampEnergyLastDay);
	}

	private void OpenMoonIslandDescription()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandDescription.Name, new Dictionary<string, object> { 
		{
			"IslandType",
			eIslandType.Moon
		} });
	}

	private void OpenStarIslandDescription()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandDescription.Name, new Dictionary<string, object> { 
		{
			"IslandType",
			eIslandType.Star
		} });
	}

	private void OnClickHelp()
	{
	}
}
