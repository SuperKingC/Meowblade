using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_DeleteBrn : GButton
{
	public GImage n125;

	public GImage n126;

	public const string URL = "ui://7ymaonxtaa6p2j";

	public static string Name = "UI_DeleteBrn";

	public static string GetURL()
	{
		return "ui://7ymaonxtaa6p2j";
	}

	public static UI_DeleteBrn CreateInstance()
	{
		return (UI_DeleteBrn)(object)UIPackage.CreateObject("GvGShipOverview", "DeleteBrn");
	}

	public static UI_DeleteBrn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DeleteBrn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtaa6p2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n125 = (GImage)((GComponent)this).GetChild("n125");
		n126 = (GImage)((GComponent)this).GetChild("n126");
	}
}
