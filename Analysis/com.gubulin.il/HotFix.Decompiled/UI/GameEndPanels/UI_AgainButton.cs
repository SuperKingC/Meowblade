using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_AgainButton : GButton
{
	public Controller button;

	public GImage bg;

	public GImage n10;

	public GRichTextField ticket;

	public GLoader icon;

	public const string URL = "ui://hda5vzklf2584k";

	public static string Name = "UI_AgainButton";

	public static string GetURL()
	{
		return "ui://hda5vzklf2584k";
	}

	public static UI_AgainButton CreateInstance()
	{
		return (UI_AgainButton)(object)UIPackage.CreateObject("GameEndPanels", "AgainButton");
	}

	public static UI_AgainButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AgainButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklf2584k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		ticket = (GRichTextField)((GComponent)this).GetChild("ticket");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
