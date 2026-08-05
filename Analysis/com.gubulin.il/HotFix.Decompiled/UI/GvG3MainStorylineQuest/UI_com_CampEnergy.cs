using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_CampEnergy : GComponent, IFairyComponent
{
	public Controller Camp;

	public GImage n0;

	public GImage n34;

	public GImage n36;

	public GImage n33;

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

	public GTextField n12;

	public GTextField n20;

	public GTextField n42;

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

	public const string URL = "ui://249h3k3dvihg1s";

	public static string Name = "UI_com_CampEnergy";

	private CampEnergyTweener campEnergyTweener;

	private int oldValue;

	private bool Activated => !Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed && !Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNightProgress;

	public static string GetURL()
	{
		return "ui://249h3k3dvihg1s";
	}

	public static UI_com_CampEnergy CreateInstance()
	{
		return (UI_com_CampEnergy)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_CampEnergy");
	}

	public static UI_com_CampEnergy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampEnergy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg1s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected O, but got Unknown
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		CampName = (GTextField)((GComponent)this).GetChild("CampName");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		CurrentEnergy = (GTextField)((GComponent)this).GetChild("CurrentEnergy");
		MoonIsland = (GTextField)((GComponent)this).GetChild("MoonIsland");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		TotalEfficiency = (GTextField)((GComponent)this).GetChild("TotalEfficiency");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id3 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id3);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id4 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id4);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id5 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id5);
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id6 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id6);
		StarIsland = (GTextField)((GComponent)this).GetChild("StarIsland");
		n35 = (UI_com_01)(object)((GComponent)this).GetChild("n35");
		MoonIslandIcon = (GLoader)((GComponent)this).GetChild("MoonIslandIcon");
		StarIslandIcon = (GLoader)((GComponent)this).GetChild("StarIslandIcon");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id7 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id7);
		MoonEfficiency = (GTextField)((GComponent)this).GetChild("MoonEfficiency");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id8 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id8);
		n41 = (GGroup)((GComponent)this).GetChild("n41");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id9 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id9);
		StarEfficiency = (GTextField)((GComponent)this).GetChild("StarEfficiency");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id10 = "ui://249h3k3dvihg1s".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id10);
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
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderCampEnergyDetails = (Action<CampEnergyDetails>)Delegate.Combine(instance.RenderCampEnergyDetails, new Action<CampEnergyDetails>(RenderCampEnergy));
		((GObject)MoonIslandIcon).onClick.Set(new EventCallback0(OpenMoonIslandDescription));
		((GObject)StarIslandIcon).onClick.Set(new EventCallback0(OpenStarIslandDescription));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderCampEnergyDetails = (Action<CampEnergyDetails>)Delegate.Remove(instance.RenderCampEnergyDetails, new Action<CampEnergyDetails>(RenderCampEnergy));
		((GObject)MoonIslandIcon).onClick.Clear();
		((GObject)StarIslandIcon).onClick.Clear();
	}

	private void RenderCampEnergy(CampEnergyDetails details)
	{
		if (!Activated)
		{
			return;
		}
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
}
