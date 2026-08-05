using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_Max : GButton
{
	public Controller button;

	public GLoader n8;

	public const string URL = "ui://bfjg32huq1eq2z";

	public static string Name = "UI_btn_Max";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq2z";
	}

	public static UI_btn_Max CreateInstance()
	{
		return (UI_btn_Max)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_Max");
	}

	public static UI_btn_Max CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Max).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}
