using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_BattleResultIsland : GButton
{
	public Controller button;

	public GGraph n7;

	public GLoader islandicon;

	public GLoader Mode;

	public GTextField IslandName;

	public GImage n5;

	public const string URL = "ui://hozu168rnq4c3m";

	public static string Name = "UI_btn_BattleResultIsland";

	public static string GetURL()
	{
		return "ui://hozu168rnq4c3m";
	}

	public static UI_btn_BattleResultIsland CreateInstance()
	{
		return (UI_btn_BattleResultIsland)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_BattleResultIsland");
	}

	public static UI_btn_BattleResultIsland CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BattleResultIsland).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnq4c3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		islandicon = (GLoader)((GComponent)this).GetChild("islandicon");
		Mode = (GLoader)((GComponent)this).GetChild("Mode");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
