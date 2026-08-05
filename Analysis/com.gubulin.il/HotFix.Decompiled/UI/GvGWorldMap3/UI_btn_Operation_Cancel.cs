using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_Operation_Cancel : GButton
{
	public GImage n3;

	public const string URL = "ui://4eq8fgd2v3u53f";

	public static string Name = "UI_btn_Operation_Cancel";

	public static string GetURL()
	{
		return "ui://4eq8fgd2v3u53f";
	}

	public static UI_btn_Operation_Cancel CreateInstance()
	{
		return (UI_btn_Operation_Cancel)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_Operation_Cancel");
	}

	public static UI_btn_Operation_Cancel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Operation_Cancel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v3u53f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
