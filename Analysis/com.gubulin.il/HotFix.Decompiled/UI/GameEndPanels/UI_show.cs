using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_show : GButton
{
	public Controller button;

	public GGraph n6;

	public GImage bg;

	public GImage n5;

	public const string URL = "ui://hda5vzklrjqw3c";

	public static string Name = "UI_show";

	public static string GetURL()
	{
		return "ui://hda5vzklrjqw3c";
	}

	public static UI_show CreateInstance()
	{
		return (UI_show)(object)UIPackage.CreateObject("GameEndPanels", "show");
	}

	public static UI_show CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_show).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklrjqw3c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
