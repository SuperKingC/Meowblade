using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_LookBack : GButton
{
	public Controller button;

	public GImage bg;

	public GImage n7;

	public const string URL = "ui://hda5vzkln4414m";

	public static string Name = "UI_LookBack";

	public static string GetURL()
	{
		return "ui://hda5vzkln4414m";
	}

	public static UI_LookBack CreateInstance()
	{
		return (UI_LookBack)(object)UIPackage.CreateObject("GameEndPanels", "LookBack");
	}

	public static UI_LookBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LookBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzkln4414m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
