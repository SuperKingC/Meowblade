using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_ShipListComp : GComponent
{
	public GGraph ShipListMask;

	public GList ShipList;

	public const string URL = "ui://7ymaonxttfhr3q";

	public static string Name = "UI_ShipListComp";

	public static string GetURL()
	{
		return "ui://7ymaonxttfhr3q";
	}

	public static UI_ShipListComp CreateInstance()
	{
		return (UI_ShipListComp)(object)UIPackage.CreateObject("GvGShipOverview", "ShipListComp");
	}

	public static UI_ShipListComp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShipListComp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxttfhr3q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShipListMask = (GGraph)((GComponent)this).GetChild("ShipListMask");
		ShipList = (GList)((GComponent)this).GetChild("ShipList");
	}
}
