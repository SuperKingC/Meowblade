using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_showPicture : GButton
{
	public Controller button;

	public Controller StatusController;

	public GImage n8;

	public UI_BossIcon icon;

	public GImage n9;

	public const string URL = "ui://f4wr270rsbjw48";

	public static string Name = "UI_showPicture";

	public static string GetURL()
	{
		return "ui://f4wr270rsbjw48";
	}

	public static UI_showPicture CreateInstance()
	{
		return (UI_showPicture)(object)UIPackage.CreateObject("InstanceZones", "showPicture");
	}

	public static UI_showPicture CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_showPicture).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rsbjw48", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		StatusController = ((GComponent)this).GetController("StatusController");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (UI_BossIcon)(object)((GComponent)this).GetChild("icon");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
