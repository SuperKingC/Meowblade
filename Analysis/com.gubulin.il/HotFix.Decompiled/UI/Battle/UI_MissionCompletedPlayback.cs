using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_MissionCompletedPlayback : GButton
{
	public Controller button;

	public GImage n19;

	public GImage n20;

	public GImage n21;

	public GImage note;

	public GLoader Finger;

	public const string URL = "ui://twlbabicr5kt42";

	public static string Name = "UI_MissionCompletedPlayback";

	public static string GetURL()
	{
		return "ui://twlbabicr5kt42";
	}

	public static UI_MissionCompletedPlayback CreateInstance()
	{
		return (UI_MissionCompletedPlayback)(object)UIPackage.CreateObject("Battle", "MissionCompletedPlayback");
	}

	public static UI_MissionCompletedPlayback CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionCompletedPlayback).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicr5kt42", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		note = (GImage)((GComponent)this).GetChild("note");
		Finger = (GLoader)((GComponent)this).GetChild("Finger");
	}
}
