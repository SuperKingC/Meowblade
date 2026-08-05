using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_RechargeActivityBtn02 : GButton
{
	public Controller note;

	public Controller isShowCountDown;

	public GImage n3;

	public GLoader n6;

	public GMovieClip n7;

	public GImage n8;

	public GGraph effPos;

	public GImage n12;

	public GTextField Time;

	public const string URL = "ui://j611zmym8kd4v45e";

	public static string Name = "UI_RechargeActivityBtn02";

	public static string GetURL()
	{
		return "ui://j611zmym8kd4v45e";
	}

	public static UI_RechargeActivityBtn02 CreateInstance()
	{
		return (UI_RechargeActivityBtn02)(object)UIPackage.CreateObject("MainCity", "RechargeActivityBtn02");
	}

	public static UI_RechargeActivityBtn02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeActivityBtn02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmym8kd4v45e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		note = ((GComponent)this).GetController("note");
		isShowCountDown = ((GComponent)this).GetController("isShowCountDown");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
		n7 = (GMovieClip)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		effPos = (GGraph)((GComponent)this).GetChild("effPos");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		Time = (GTextField)((GComponent)this).GetChild("Time");
	}
}
