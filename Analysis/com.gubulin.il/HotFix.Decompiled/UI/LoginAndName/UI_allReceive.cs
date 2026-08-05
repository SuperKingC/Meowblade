using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_allReceive : GButton
{
	public Controller button;

	public Controller isQQ;

	public GImage n6;

	public GImage n5;

	public GGraph FxWrapper1;

	public GGraph FxWrapper2;

	public GImage n7;

	public GImage n8;

	public GTextField timeCountDown;

	public GTextField timeCountDownQQ;

	public Transition ShowSelf;

	public const string URL = "ui://yb3s7uv7op6kv";

	public static string Name = "UI_allReceive";

	public static string GetURL()
	{
		return "ui://yb3s7uv7op6kv";
	}

	public static UI_allReceive CreateInstance()
	{
		return (UI_allReceive)(object)UIPackage.CreateObject("LoginAndName", "allReceive");
	}

	public static UI_allReceive CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_allReceive).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7op6kv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isQQ = ((GComponent)this).GetController("isQQ");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		FxWrapper1 = (GGraph)((GComponent)this).GetChild("FxWrapper1");
		FxWrapper2 = (GGraph)((GComponent)this).GetChild("FxWrapper2");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		timeCountDown = (GTextField)((GComponent)this).GetChild("timeCountDown");
		timeCountDownQQ = (GTextField)((GComponent)this).GetChild("timeCountDownQQ");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}
}
