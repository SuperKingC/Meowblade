using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_btn_02 : GButton
{
	public GImage n129;

	public const string URL = "ui://j611zmymiianv45h";

	public static string Name = "UI_btn_02";

	public static string GetURL()
	{
		return "ui://j611zmymiianv45h";
	}

	public static UI_btn_02 CreateInstance()
	{
		return (UI_btn_02)(object)UIPackage.CreateObject("MainCity", "btn_02");
	}

	public static UI_btn_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymiianv45h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n129 = (GImage)((GComponent)this).GetChild("n129");
	}
}
