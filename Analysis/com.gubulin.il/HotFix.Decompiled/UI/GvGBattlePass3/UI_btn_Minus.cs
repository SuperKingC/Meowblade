using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_Minus : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://bfjg32huq1eq2w";

	public static string Name = "UI_btn_Minus";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq2w";
	}

	public static UI_btn_Minus CreateInstance()
	{
		return (UI_btn_Minus)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_Minus");
	}

	public static UI_btn_Minus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Minus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
	}
}
