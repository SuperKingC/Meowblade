using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_YesButton : GButton
{
	public Controller button;

	public GImage bg;

	public GLoader n6;

	public const string URL = "ui://hda5vzklj0l8o";

	public static string Name = "UI_YesButton";

	public static string GetURL()
	{
		return "ui://hda5vzklj0l8o";
	}

	public static UI_YesButton CreateInstance()
	{
		return (UI_YesButton)(object)UIPackage.CreateObject("GameEndPanels", "YesButton");
	}

	public static UI_YesButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_YesButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklj0l8o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		bg = (GImage)((GComponent)this).GetChild("bg");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
	}
}
