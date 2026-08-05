using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_Operation_CleanUp : GButton
{
	public GImage back;

	public GLoader n3;

	public const string URL = "ui://4eq8fgd2v3u53c";

	public static string Name = "UI_btn_Operation_CleanUp";

	public static string GetURL()
	{
		return "ui://4eq8fgd2v3u53c";
	}

	public static UI_btn_Operation_CleanUp CreateInstance()
	{
		return (UI_btn_Operation_CleanUp)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_Operation_CleanUp");
	}

	public static UI_btn_Operation_CleanUp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Operation_CleanUp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v3u53c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
