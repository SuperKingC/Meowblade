using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_GoToCamp : GButton
{
	public Controller button;

	public GImage Bg;

	public GLoader icon;

	public GImage title;

	public GImage n3;

	public Transition t0;

	public const string URL = "ui://hda5vzklvv0u2j";

	public static string Name = "UI_GoToCamp";

	public static string GetURL()
	{
		return "ui://hda5vzklvv0u2j";
	}

	public static UI_GoToCamp CreateInstance()
	{
		return (UI_GoToCamp)(object)UIPackage.CreateObject("GameEndPanels", "GoToCamp");
	}

	public static UI_GoToCamp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToCamp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklvv0u2j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GImage)((GComponent)this).GetChild("title");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
