using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGWorldMap3;

public class UI_com_MoonIslandCard : GComponent, IIslandCard
{
	public Controller IslandBelong;

	public GImage n0;

	public GImage n12;

	public GImage n15;

	public UI_com_IslandDefendersInfo Defenders;

	public UI_com_MoonIslandFunctions MoonIslandFunctions;

	public UI_com_OtherIslandFunctions OtherFunctions;

	public UI_com_IslandCamp CampInfo;

	public UI_com_IslandNpc Npc;

	public UI_com_IslandUserInfos UserEvents;

	public UI_com_IslandFunctions Functions;

	public GImage n13;

	public UI_btn_IslandCommand Command;

	public UI_btn_ShareIsland ShareIsland;

	public UI_btn_ProgressReward ProgressReward;

	public UI_com_IslandRewards IslandRewards;

	public GTextField n14;

	public UI_com_IslandBoss IslandBoss;

	public const string URL = "ui://4eq8fgd2h4tpe3";

	public static string Name = "UI_com_MoonIslandCard";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpe3";
	}

	public static UI_com_MoonIslandCard CreateInstance()
	{
		return (UI_com_MoonIslandCard)(object)UIPackage.CreateObject("GvGWorldMap3", "com_MoonIslandCard");
	}

	public static UI_com_MoonIslandCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MoonIslandCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpe3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IslandBelong = ((GComponent)this).GetController("IslandBelong");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		Defenders = (UI_com_IslandDefendersInfo)(object)((GComponent)this).GetChild("Defenders");
		MoonIslandFunctions = (UI_com_MoonIslandFunctions)(object)((GComponent)this).GetChild("MoonIslandFunctions");
		OtherFunctions = (UI_com_OtherIslandFunctions)(object)((GComponent)this).GetChild("OtherFunctions");
		CampInfo = (UI_com_IslandCamp)(object)((GComponent)this).GetChild("CampInfo");
		Npc = (UI_com_IslandNpc)(object)((GComponent)this).GetChild("Npc");
		UserEvents = (UI_com_IslandUserInfos)(object)((GComponent)this).GetChild("UserEvents");
		Functions = (UI_com_IslandFunctions)(object)((GComponent)this).GetChild("Functions");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Command = (UI_btn_IslandCommand)(object)((GComponent)this).GetChild("Command");
		ShareIsland = (UI_btn_ShareIsland)(object)((GComponent)this).GetChild("ShareIsland");
		ProgressReward = (UI_btn_ProgressReward)(object)((GComponent)this).GetChild("ProgressReward");
		IslandRewards = (UI_com_IslandRewards)(object)((GComponent)this).GetChild("IslandRewards");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://4eq8fgd2h4tpe3".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		IslandBoss = (UI_com_IslandBoss)(object)((GComponent)this).GetChild("IslandBoss");
	}

	public void OnClose(IslandStateModel islandState)
	{
		CampInfo.OnClose();
		Command.OnClose();
		IslandRewards.OnUnload();
		MoonIslandFunctions.OnClose();
		ShareIsland.OnClose();
		UserEvents.OnClose();
		ProgressReward.OnClose();
		IslandBoss.OnClose();
	}

	public void OnLoad(IslandStateModel islandState)
	{
		IslandRewards.OnLoad();
		MoonIslandFunctions.OnLoad();
		ShareIsland.OnLoad();
		UserEvents.OnLoad();
		ProgressReward.OnLoad();
		IslandBoss.OnLoad();
	}

	public void Render(IslandStateModel islandState)
	{
		CampInfo.OnRender(islandState);
		IslandRewards.OnRender(islandState);
		RenderMoonIslandFunc(islandState);
		OtherFunctions.OnRender(islandState);
		ShowDefenders(islandState);
		Command.OnLoad(islandState.IslandId);
		ShareIsland.OnRender(islandState);
		UserEvents.OnRender(islandState);
		Functions.OnRender(islandState);
		ProgressReward.OnRender(islandState.IslandId);
		IslandBoss.OnRender(islandState);
	}

	public void Update(IslandStateModel islandState)
	{
		CampInfo.OnRender(islandState);
		IslandRewards.OnRender(islandState);
		ShowDefenders(islandState);
		RenderMoonIslandFunc(islandState);
		Functions.OnRender(islandState);
		IslandBoss.OnRender(islandState);
	}

	private void ShowDefenders(IslandStateModel islandState)
	{
		List<UI_main_IslandDefenders.UnitInfo> uiUnitInfos = islandState.DetailInfo.GetUiUnitInfos();
		Npc.OnRender(islandState, uiUnitInfos);
		Defenders.OnRender(islandState, uiUnitInfos);
	}

	private void RenderMoonIslandFunc(IslandStateModel islandState)
	{
		string shipIdStaySomeIsland = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipIdStaySomeIsland(islandState.IslandId);
		IslandFuncStatus islandFuncStatus = ((islandState.GetBelongStatus() == eGvGMode3IslandBelongStatus.OwnSide) ? (string.IsNullOrEmpty(shipIdStaySomeIsland) ? IslandFuncStatus.Unavailable : IslandFuncStatus.Available) : IslandFuncStatus.Preview);
		MoonIslandFunctions.OnRender(islandState, islandFuncStatus);
		IslandBelong.SetSelectedIndex((int)islandFuncStatus);
	}
}
