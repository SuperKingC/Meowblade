using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_VictoryBackGround : GComponent
{
	public GImage n6;

	public GImage n5;

	public GButton n7;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://hda5vzklj0l8w";

	public static string Name = "UI_VictoryBackGround";

	public static string GetURL()
	{
		return "ui://hda5vzklj0l8w";
	}

	public static UI_VictoryBackGround CreateInstance()
	{
		return (UI_VictoryBackGround)(object)UIPackage.CreateObject("GameEndPanels", "VictoryBackGround");
	}

	public static UI_VictoryBackGround CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VictoryBackGround).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklj0l8w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GButton)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
