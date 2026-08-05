using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_btn_01 : GButton
{
	public GImage n11;

	public const string URL = "ui://47lbpgx995pej5ltgv";

	public static string Name = "UI_btn_01";

	public static string GetURL()
	{
		return "ui://47lbpgx995pej5ltgv";
	}

	public static UI_btn_01 CreateInstance()
	{
		return (UI_btn_01)(object)UIPackage.CreateObject("Tips", "btn_01");
	}

	public static UI_btn_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx995pej5ltgv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
