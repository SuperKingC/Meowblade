using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_DropStartBig : GButton
{
	public Controller button;

	public GImage Bg;

	public GGraph fxBack;

	public GLoader icon;

	public GRichTextField title;

	public Transition ShowSelf;

	public const string URL = "ui://hda5vzkleqc72h";

	public static string Name = "UI_DropStartBig";

	public static string GetURL()
	{
		return "ui://hda5vzkleqc72h";
	}

	public static UI_DropStartBig CreateInstance()
	{
		return (UI_DropStartBig)(object)UIPackage.CreateObject("GameEndPanels", "DropStartBig");
	}

	public static UI_DropStartBig CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DropStartBig).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzkleqc72h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		fxBack = (GGraph)((GComponent)this).GetChild("fxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}
}
