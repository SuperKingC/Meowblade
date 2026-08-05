using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace UI.GvGWorldMap3;

public class UI_btn_BestOfToday : GButton, IFairyComponent
{
	public Controller button;

	public Controller HasLogs;

	public GImage n7;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public GList BattleLog;

	public GTextField n9;

	public GTextField n10;

	public GGroup n11;

	public GImage n12;

	public GImage n13;

	public GTextField n14;

	public GImage n15;

	public GImage n16;

	public const string URL = "ui://4eq8fgd2zit4a0";

	public static string Name = "UI_btn_BestOfToday";

	private bool Activated => !Singleton<GvG3FlagShipMissionsManager>.Instance.HasSettlement && !((GObject)this).isDisposed && Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight;

	public static string GetURL()
	{
		return "ui://4eq8fgd2zit4a0";
	}

	public static UI_btn_BestOfToday CreateInstance()
	{
		return (UI_btn_BestOfToday)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_BestOfToday");
	}

	public static UI_btn_BestOfToday CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BestOfToday).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2zit4a0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasLogs = ((GComponent)this).GetController("HasLogs");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		BattleLog = (GList)((GComponent)this).GetChild("BattleLog");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://4eq8fgd2zit4a0".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://4eq8fgd2zit4a0".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id3 = "ui://4eq8fgd2zit4a0".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id3);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
		if (Activated)
		{
			Singleton<GvG3FlagShipMissionsManager>.Instance.GetFinalProgressBossDamageTodayTop3();
		}
	}

	public void RegisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderBossDamage = (Action<List<FinalProgressBossDamageInfo>>)Delegate.Combine(instance.RenderBossDamage, new Action<List<FinalProgressBossDamageInfo>>(Render));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderBossDamage = (Action<List<FinalProgressBossDamageInfo>>)Delegate.Remove(instance.RenderBossDamage, new Action<List<FinalProgressBossDamageInfo>>(Render));
		((GButton)this).onChanged.Clear();
	}

	private void Render(List<FinalProgressBossDamageInfo> todayTop3)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		if (!Activated)
		{
			return;
		}
		HasLogs.selectedIndex = ((todayTop3.Count > 0) ? 1 : 0);
		if (todayTop3.Count >= 1 && todayTop3.Count < 3)
		{
			int num = 3 - todayTop3.Count;
			for (int i = 0; i < num; i++)
			{
				todayTop3.Add(null);
			}
		}
		BattleLog.itemRenderer = new ListItemRenderer(RenderLog);
		BattleLog.numItems = todayTop3.Count;
		void RenderLog(int index, GObject obj)
		{
			if (obj is UI_com_TodayBestBossBattleLog uI_com_TodayBestBossBattleLog)
			{
				FinalProgressBossDamageInfo finalProgressBossDamageInfo = todayTop3[index];
				if (finalProgressBossDamageInfo == null)
				{
					uI_com_TodayBestBossBattleLog.IsNotEmpty.selectedIndex = 0;
				}
				else
				{
					bool isInsuranceClone;
					string shipId = GvG3InsuranceHelper.TryStripInsuranceSuffix(finalProgressBossDamageInfo.ShipId, out isInsuranceClone);
					GvGMode3ShipModel myShipData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(shipId);
					ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(myShipData.PermanentData.ShipRace);
					string iconUrl = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
					uI_com_TodayBestBossBattleLog.IsNotEmpty.selectedIndex = 1;
					uI_com_TodayBestBossBattleLog.Rank.Rank.selectedIndex = index;
					((GObject)uI_com_TodayBestBossBattleLog.ShipName).text = (isInsuranceClone ? GvG3InsuranceHelper.GetInsuranceShipName() : myShipData.PermanentData.ShipName.ToRealShipName());
					uI_com_TodayBestBossBattleLog.ShipIcon.Icon.url = iconUrl;
					((GObject)uI_com_TodayBestBossBattleLog.Damage).text = finalProgressBossDamageInfo.TotalDamage.ShortNumberFormat();
				}
			}
		}
	}
}
