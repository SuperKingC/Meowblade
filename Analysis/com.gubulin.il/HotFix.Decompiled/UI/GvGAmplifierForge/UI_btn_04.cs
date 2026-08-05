using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_btn_04 : GButton
{
	public GImage n28;

	public const string URL = "ui://fpjheycbslenv4gh";

	public static string Name = "UI_btn_04";

	public static string GetURL()
	{
		return "ui://fpjheycbslenv4gh";
	}

	public static UI_btn_04 CreateInstance()
	{
		return (UI_btn_04)(object)UIPackage.CreateObject("GvGAmplifierForge", "btn_04");
	}

	public static UI_btn_04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbslenv4gh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n28 = (GImage)((GComponent)this).GetChild("n28");
	}
}
