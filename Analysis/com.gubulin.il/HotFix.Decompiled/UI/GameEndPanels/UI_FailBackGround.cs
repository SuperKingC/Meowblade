using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_FailBackGround : GComponent
{
	public GImage n6;

	public Transition t0;

	public const string URL = "ui://hda5vzklj0l8t";

	public static string Name = "UI_FailBackGround";

	public static string GetURL()
	{
		return "ui://hda5vzklj0l8t";
	}

	public static UI_FailBackGround CreateInstance()
	{
		return (UI_FailBackGround)(object)UIPackage.CreateObject("GameEndPanels", "FailBackGround");
	}

	public static UI_FailBackGround CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FailBackGround).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklj0l8t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
