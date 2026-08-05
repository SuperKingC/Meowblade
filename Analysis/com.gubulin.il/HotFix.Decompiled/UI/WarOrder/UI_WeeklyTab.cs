using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_WeeklyTab : GButton
{
	public Controller button;

	public GImage selectBack;

	public GImage n13;

	public const string URL = "ui://ax280w58p8iij";

	public static string Name = "UI_WeeklyTab";

	public static string GetURL()
	{
		return "ui://ax280w58p8iij";
	}

	public static UI_WeeklyTab CreateInstance()
	{
		return (UI_WeeklyTab)(object)UIPackage.CreateObject("WarOrder", "WeeklyTab");
	}

	public static UI_WeeklyTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WeeklyTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58p8iij", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		selectBack = (GImage)((GComponent)this).GetChild("selectBack");
		n13 = (GImage)((GComponent)this).GetChild("n13");
	}
}
