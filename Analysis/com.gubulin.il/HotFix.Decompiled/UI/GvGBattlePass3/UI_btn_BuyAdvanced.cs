using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_BuyAdvanced : GButton
{
	public Controller button;

	public GImage back;

	public GLoader n5;

	public const string URL = "ui://bfjg32huq1eq2n";

	public static string Name = "UI_btn_BuyAdvanced";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq2n";
	}

	public static UI_btn_BuyAdvanced CreateInstance()
	{
		return (UI_btn_BuyAdvanced)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_BuyAdvanced");
	}

	public static UI_btn_BuyAdvanced CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BuyAdvanced).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq2n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
	}
}
