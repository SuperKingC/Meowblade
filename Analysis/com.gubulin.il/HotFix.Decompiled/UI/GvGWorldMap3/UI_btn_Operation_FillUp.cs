using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_Operation_FillUp : GButton
{
	public GImage back;

	public GLoader n3;

	public const string URL = "ui://4eq8fgd2rp3569";

	public static string Name = "UI_btn_Operation_FillUp";

	public static string GetURL()
	{
		return "ui://4eq8fgd2rp3569";
	}

	public static UI_btn_Operation_FillUp CreateInstance()
	{
		return (UI_btn_Operation_FillUp)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_Operation_FillUp");
	}

	public static UI_btn_Operation_FillUp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Operation_FillUp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2rp3569", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n3 = (GLoader)((GComponent)this).GetChild("n3");
	}
}
