using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_SlotBuy : GButton
{
	public Controller button;

	public GImage n12;

	public GImage n11;

	public Transition t0;

	public const string URL = "ui://bfjg32huq1eq33";

	public static string Name = "UI_btn_SlotBuy";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq33";
	}

	public static UI_btn_SlotBuy CreateInstance()
	{
		return (UI_btn_SlotBuy)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_SlotBuy");
	}

	public static UI_btn_SlotBuy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SlotBuy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
