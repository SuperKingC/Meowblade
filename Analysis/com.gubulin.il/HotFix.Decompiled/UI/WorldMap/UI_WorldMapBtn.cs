using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_WorldMapBtn : GButton
{
	public Controller button;

	public Controller c1;

	public GImage n12;

	public GImage n13;

	public GImage n14;

	public GImage n15;

	public GImage n16;

	public const string URL = "ui://c9n2h0ksiqpzc";

	public static string Name = "UI_WorldMapBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksiqpzc";
	}

	public static UI_WorldMapBtn CreateInstance()
	{
		return (UI_WorldMapBtn)(object)UIPackage.CreateObject("WorldMap", "WorldMapBtn");
	}

	public static UI_WorldMapBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorldMapBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksiqpzc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		c1 = ((GComponent)this).GetController("c1");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
	}
}
