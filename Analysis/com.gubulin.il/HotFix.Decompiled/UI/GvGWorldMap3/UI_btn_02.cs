using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_02 : GButton
{
	public GImage n41;

	public GImage n42;

	public const string URL = "ui://4eq8fgd2pepcs7j";

	public static string Name = "UI_btn_02";

	public static string GetURL()
	{
		return "ui://4eq8fgd2pepcs7j";
	}

	public static UI_btn_02 CreateInstance()
	{
		return (UI_btn_02)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_02");
	}

	public static UI_btn_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2pepcs7j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
	}
}
