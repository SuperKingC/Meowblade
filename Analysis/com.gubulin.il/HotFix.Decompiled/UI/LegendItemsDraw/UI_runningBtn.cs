using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_runningBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public GImage n8;

	public GImage note;

	public const string URL = "ui://xogvri2hi0qy2";

	public static string Name = "UI_runningBtn";

	public static string GetURL()
	{
		return "ui://xogvri2hi0qy2";
	}

	public static UI_runningBtn CreateInstance()
	{
		return (UI_runningBtn)(object)UIPackage.CreateObject("LegendItemsDraw", "runningBtn");
	}

	public static UI_runningBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_runningBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hi0qy2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
