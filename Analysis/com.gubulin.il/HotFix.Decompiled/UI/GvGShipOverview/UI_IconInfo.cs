using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_IconInfo : GButton
{
	public GImage n147;

	public GLoader icon;

	public GTextField Info;

	public const string URL = "ui://7ymaonxtb2oh2q";

	public static string Name = "UI_IconInfo";

	public static string GetURL()
	{
		return "ui://7ymaonxtb2oh2q";
	}

	public static UI_IconInfo CreateInstance()
	{
		return (UI_IconInfo)(object)UIPackage.CreateObject("GvGShipOverview", "IconInfo");
	}

	public static UI_IconInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IconInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtb2oh2q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n147 = (GImage)((GComponent)this).GetChild("n147");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Info = (GTextField)((GComponent)this).GetChild("Info");
	}
}
