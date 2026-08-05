using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_UnlockButton : GButton
{
	public Controller button;

	public Controller isLong;

	public GImage unlockAll;

	public GTextField Price1;

	public GTextField Price;

	public GImage n7;

	public GLoader n8;

	public GImage n9;

	public GMovieClip n10;

	public Transition t0;

	public const string URL = "ui://mapat4i5l28yv4ru";

	public static string Name = "UI_UnlockButton";

	public static string GetURL()
	{
		return "ui://mapat4i5l28yv4ru";
	}

	public static UI_UnlockButton CreateInstance()
	{
		return (UI_UnlockButton)(object)UIPackage.CreateObject("ProgressionMission", "UnlockButton");
	}

	public static UI_UnlockButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5l28yv4ru", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isLong = ((GComponent)this).GetController("isLong");
		unlockAll = (GImage)((GComponent)this).GetChild("unlockAll");
		Price1 = (GTextField)((GComponent)this).GetChild("Price1");
		string id = "ui://mapat4i5l28yv4ru".Replace("ui://", "") + "-" + ((GObject)Price1).id;
		((GObject)Price1).text = LanguagesManager.GetDesc(id);
		Price = (GTextField)((GComponent)this).GetChild("Price");
		string id2 = "ui://mapat4i5l28yv4ru".Replace("ui://", "") + "-" + ((GObject)Price).id;
		((GObject)Price).text = LanguagesManager.GetDesc(id2);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GLoader)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GMovieClip)((GComponent)this).GetChild("n10");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
