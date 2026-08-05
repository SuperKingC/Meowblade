using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_TodayTopDmgBtn : GButton
{
	public Controller button;

	public GImage n1;

	public const string URL = "ui://0i520nzm121eo4g";

	public static string Name = "UI_TodayTopDmgBtn";

	public static string GetURL()
	{
		return "ui://0i520nzm121eo4g";
	}

	public static UI_TodayTopDmgBtn CreateInstance()
	{
		return (UI_TodayTopDmgBtn)(object)UIPackage.CreateObject("LordOfDreams", "TodayTopDmgBtn");
	}

	public static UI_TodayTopDmgBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TodayTopDmgBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm121eo4g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
