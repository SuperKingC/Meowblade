using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_OpenGreenChannel : GButton
{
	public GImage n32;

	public GImage n30;

	public GTextField Count;

	public const string URL = "ui://4eq8fgd2d0fus9s";

	public static string Name = "UI_btn_OpenGreenChannel";

	public static string GetURL()
	{
		return "ui://4eq8fgd2d0fus9s";
	}

	public static UI_btn_OpenGreenChannel CreateInstance()
	{
		return (UI_btn_OpenGreenChannel)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_OpenGreenChannel");
	}

	public static UI_btn_OpenGreenChannel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OpenGreenChannel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2d0fus9s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
