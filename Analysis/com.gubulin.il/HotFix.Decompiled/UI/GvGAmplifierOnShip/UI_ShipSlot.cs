using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_ShipSlot : GButton
{
	public Controller button;

	public GImage n163;

	public GTextField ShipName;

	public GButton RaceType;

	public GImage n164;

	public GTextField ShipIndex;

	public const string URL = "ui://pwlamcyxpm8p16";

	public static string Name = "UI_ShipSlot";

	public static string GetURL()
	{
		return "ui://pwlamcyxpm8p16";
	}

	public static UI_ShipSlot CreateInstance()
	{
		return (UI_ShipSlot)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "ShipSlot");
	}

	public static UI_ShipSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShipSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxpm8p16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n163 = (GImage)((GComponent)this).GetChild("n163");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		RaceType = (GButton)((GComponent)this).GetChild("RaceType");
		n164 = (GImage)((GComponent)this).GetChild("n164");
		ShipIndex = (GTextField)((GComponent)this).GetChild("ShipIndex");
	}
}
