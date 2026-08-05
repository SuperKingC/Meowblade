using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_CheckRoute : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://4eq8fgd2v3u53a";

	public static string Name = "UI_btn_CheckRoute";

	public static string GetURL()
	{
		return "ui://4eq8fgd2v3u53a";
	}

	public static UI_btn_CheckRoute CreateInstance()
	{
		return (UI_btn_CheckRoute)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_CheckRoute");
	}

	public static UI_btn_CheckRoute CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckRoute).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v3u53a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
