using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_OneClickClaim : GButton
{
	public Controller button;

	public GImage back;

	public GLoader n8;

	public const string URL = "ui://bfjg32huq1eq2l";

	public static string Name = "UI_btn_OneClickClaim";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq2l";
	}

	public static UI_btn_OneClickClaim CreateInstance()
	{
		return (UI_btn_OneClickClaim)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_OneClickClaim");
	}

	public static UI_btn_OneClickClaim CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OneClickClaim).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}
