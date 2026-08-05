using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_DropStart : GButton
{
	public Controller button;

	public Controller Type;

	public GImage Bg;

	public GGraph fxNack;

	public GLoader icon;

	public GRichTextField title;

	public Transition t0;

	public const string URL = "ui://hda5vzklkxzh16";

	public static string Name = "UI_DropStart";

	public static string GetURL()
	{
		return "ui://hda5vzklkxzh16";
	}

	public static UI_DropStart CreateInstance()
	{
		return (UI_DropStart)(object)UIPackage.CreateObject("GameEndPanels", "DropStart");
	}

	public static UI_DropStart CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DropStart).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklkxzh16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		fxNack = (GGraph)((GComponent)this).GetChild("fxNack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
