using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

namespace UI.GvGWorldMap3;

public class UI_com_BigBossIslandCard : GComponent, IIslandCard
{
	public GImage n5;

	public GImage n6;

	public GImage n7;

	public UI_com_BossInfo BossInfo;

	public GImage n8;

	public UI_com_BossIslandRewards DisplayRewards;

	public UI_com_IslandFunctions Functions;

	public UI_com_IslandUserInfos UserEvents;

	public UI_com_BossIslandFunctions OtherFunctions;

	public UI_com_BestOfToday BestOfToday;

	public GImage n14;

	public UI_btn_ShareIsland ShareIsland;

	public const string URL = "ui://4eq8fgd2h4tpee";

	public static string Name = "UI_com_BigBossIslandCard";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpee";
	}

	public static UI_com_BigBossIslandCard CreateInstance()
	{
		return (UI_com_BigBossIslandCard)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BigBossIslandCard");
	}

	public static UI_com_BigBossIslandCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BigBossIslandCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpee", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		BossInfo = (UI_com_BossInfo)(object)((GComponent)this).GetChild("BossInfo");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		DisplayRewards = (UI_com_BossIslandRewards)(object)((GComponent)this).GetChild("DisplayRewards");
		Functions = (UI_com_IslandFunctions)(object)((GComponent)this).GetChild("Functions");
		UserEvents = (UI_com_IslandUserInfos)(object)((GComponent)this).GetChild("UserEvents");
		OtherFunctions = (UI_com_BossIslandFunctions)(object)((GComponent)this).GetChild("OtherFunctions");
		BestOfToday = (UI_com_BestOfToday)(object)((GComponent)this).GetChild("BestOfToday");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		ShareIsland = (UI_btn_ShareIsland)(object)((GComponent)this).GetChild("ShareIsland");
	}

	public void OnClose(IslandStateModel islandState)
	{
		ShareIsland.OnClose();
		UserEvents.OnClose();
		DisplayRewards.OnClose();
		BestOfToday.OnClose();
		BossInfo.OnClose();
	}

	public void OnLoad(IslandStateModel islandState)
	{
		ShareIsland.OnLoad();
		UserEvents.OnLoad();
		DisplayRewards.OnLoad();
		BestOfToday.OnLoad();
		BossInfo.OnLoad();
	}

	public void Render(IslandStateModel islandState)
	{
		Functions.OnRender(islandState);
		ShareIsland.OnRender(islandState);
		UserEvents.OnRender(islandState);
		DisplayRewards.OnRender();
		OtherFunctions.OnRender(islandState);
		BestOfToday.OnRender();
		BossInfo.OnRender(islandState);
	}

	public void Update(IslandStateModel islandState)
	{
		Functions.OnRender(islandState);
		OtherFunctions.OnRender(islandState);
		BossInfo.OnRender(islandState);
	}
}
