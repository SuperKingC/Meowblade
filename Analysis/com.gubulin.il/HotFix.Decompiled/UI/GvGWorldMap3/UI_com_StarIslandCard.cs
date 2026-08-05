using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGWorldMap3;

public class UI_com_StarIslandCard : GComponent, IIslandCard
{
	public Controller IslandState;

	public GImage n11;

	public GImage n13;

	public UI_com_IslandDefendersInfo Defenders;

	public UI_com_IslandProduction Output;

	public UI_com_OtherIslandFunctions OtherFunctions;

	public UI_com_IslandCamp CampInfo;

	public UI_com_IslandUserInfos UserEvents;

	public UI_com_IslandFunctions Functions;

	public GImage n16;

	public UI_btn_ShareIsland ShareIsland;

	public UI_btn_IslandCommand Command;

	public UI_com_IslandNpc Npc;

	public UI_com_IslandRewards IslandRewards;

	public UI_com_IslandBoss IslandBoss;

	public UI_com_ProtectedPeriodTime ProtectedPeriodTime;

	public UI_btn_Sweep Sweep;

	public UI_btn_FireSupport FireSupport;

	public const string URL = "ui://4eq8fgd2jxsodu";

	public static string Name = "UI_com_StarIslandCard";

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodu";
	}

	public static UI_com_StarIslandCard CreateInstance()
	{
		return (UI_com_StarIslandCard)(object)UIPackage.CreateObject("GvGWorldMap3", "com_StarIslandCard");
	}

	public static UI_com_StarIslandCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StarIslandCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IslandState = ((GComponent)this).GetController("IslandState");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Defenders = (UI_com_IslandDefendersInfo)(object)((GComponent)this).GetChild("Defenders");
		Output = (UI_com_IslandProduction)(object)((GComponent)this).GetChild("Output");
		OtherFunctions = (UI_com_OtherIslandFunctions)(object)((GComponent)this).GetChild("OtherFunctions");
		CampInfo = (UI_com_IslandCamp)(object)((GComponent)this).GetChild("CampInfo");
		UserEvents = (UI_com_IslandUserInfos)(object)((GComponent)this).GetChild("UserEvents");
		Functions = (UI_com_IslandFunctions)(object)((GComponent)this).GetChild("Functions");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		ShareIsland = (UI_btn_ShareIsland)(object)((GComponent)this).GetChild("ShareIsland");
		Command = (UI_btn_IslandCommand)(object)((GComponent)this).GetChild("Command");
		Npc = (UI_com_IslandNpc)(object)((GComponent)this).GetChild("Npc");
		IslandRewards = (UI_com_IslandRewards)(object)((GComponent)this).GetChild("IslandRewards");
		IslandBoss = (UI_com_IslandBoss)(object)((GComponent)this).GetChild("IslandBoss");
		ProtectedPeriodTime = (UI_com_ProtectedPeriodTime)(object)((GComponent)this).GetChild("ProtectedPeriodTime");
		Sweep = (UI_btn_Sweep)(object)((GComponent)this).GetChild("Sweep");
		FireSupport = (UI_btn_FireSupport)(object)((GComponent)this).GetChild("FireSupport");
	}

	public void OnClose(IslandStateModel islandState)
	{
		CampInfo.OnClose();
		Command.OnClose();
		IslandRewards.OnUnload();
		ShareIsland.OnClose();
		UserEvents.OnClose();
		ProtectedPeriodTime.OnUnload();
		Sweep.OnUnload();
		FireSupport.OnUnload(islandState);
		IslandBoss.OnClose();
	}

	public void OnLoad(IslandStateModel islandState)
	{
		IslandRewards.OnLoad();
		ShareIsland.OnLoad();
		UserEvents.OnLoad();
		ProtectedPeriodTime.OnLoad();
		Sweep.OnLoad();
		FireSupport.OnLoad(islandState);
		IslandBoss.OnLoad();
	}

	public void Render(IslandStateModel islandState)
	{
		CampInfo.OnRender(islandState);
		IslandRewards.OnRender(islandState);
		OtherFunctions.OnRender(islandState);
		Output.OnRender(islandState);
		ShowDefenders(islandState);
		Command.OnLoad(islandState.IslandId);
		ShareIsland.OnRender(islandState);
		UserEvents.OnRender(islandState);
		Functions.OnRender(islandState);
		IslandBoss.OnRender(islandState);
		ProtectedPeriodTime.OnRender(islandState);
		RenderSkillBtn(islandState);
	}

	public void Update(IslandStateModel islandState)
	{
		CampInfo.OnRender(islandState);
		IslandRewards.OnRender(islandState);
		Output.OnRender(islandState);
		ShowDefenders(islandState);
		Functions.OnRender(islandState);
		IslandBoss.OnRender(islandState);
		Sweep.OnRender(islandState);
		FireSupport.OnRender(islandState);
		RenderSkillBtn(islandState);
	}

	private void RenderSkillBtn(IslandStateModel islandState)
	{
		if (islandState.GetNpcStatus() == eGvGMode3IslandNPCStatus.Rebellion)
		{
			FireSupport.OnRender(islandState);
			IslandState.selectedIndex = 1;
		}
		else
		{
			Sweep.OnRender(islandState);
			IslandState.selectedIndex = 0;
		}
	}

	private void ShowDefenders(IslandStateModel islandState)
	{
		List<UI_main_IslandDefenders.UnitInfo> uiUnitInfos = islandState.DetailInfo.GetUiUnitInfos();
		Npc.OnRender(islandState, uiUnitInfos);
		Defenders.OnRender(islandState, uiUnitInfos);
	}
}
