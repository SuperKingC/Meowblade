using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_RechargeActivityBtn : GButton
{
	public Controller status;

	public Controller note;

	public Controller Type;

	public Controller isShowCountDown;

	public GImage n3;

	public GImage n9;

	public GLoader n6;

	public GLoader n11;

	public GMovieClip n7;

	public GImage n8;

	public GGraph effPos;

	public GImage n12;

	public GTextField Time;

	public const string URL = "ui://j611zmymjvp7v44g";

	public static string Name = "UI_RechargeActivityBtn";

	public static string GetURL()
	{
		return "ui://j611zmymjvp7v44g";
	}

	public static UI_RechargeActivityBtn CreateInstance()
	{
		return (UI_RechargeActivityBtn)(object)UIPackage.CreateObject("MainCity", "RechargeActivityBtn");
	}

	public static UI_RechargeActivityBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeActivityBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymjvp7v44g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		status = ((GComponent)this).GetController("status");
		note = ((GComponent)this).GetController("note");
		Type = ((GComponent)this).GetController("Type");
		isShowCountDown = ((GComponent)this).GetController("isShowCountDown");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
		n11 = (GLoader)((GComponent)this).GetChild("n11");
		n7 = (GMovieClip)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		effPos = (GGraph)((GComponent)this).GetChild("effPos");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		Time = (GTextField)((GComponent)this).GetChild("Time");
	}
}
