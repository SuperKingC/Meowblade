using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_QuickBuy : GButton
{
	public Controller button;

	public GImage n8;

	public GLoader n9;

	public const string URL = "ui://bfjg32huq1eq2x";

	public static string Name = "UI_btn_QuickBuy";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq2x";
	}

	public static UI_btn_QuickBuy CreateInstance()
	{
		return (UI_btn_QuickBuy)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_QuickBuy");
	}

	public static UI_btn_QuickBuy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_QuickBuy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GLoader)((GComponent)this).GetChild("n9");
	}
}
