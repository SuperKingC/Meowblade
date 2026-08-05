using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_btn_02 : GButton
{
	public GImage n19;

	public GLoader icon;

	public const string URL = "ui://lrjfe94hm4fq5n";

	public static string Name = "UI_btn_02";

	public static string GetURL()
	{
		return "ui://lrjfe94hm4fq5n";
	}

	public static UI_btn_02 CreateInstance()
	{
		return (UI_btn_02)(object)UIPackage.CreateObject("UpGrade", "btn_02");
	}

	public static UI_btn_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq5n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
