using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_Operation_Jump : GButton
{
	public GImage back;

	public GLoader n6;

	public GImage n5;

	public const string URL = "ui://4eq8fgd2mk4p9q";

	public static string Name = "UI_btn_Operation_Jump";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mk4p9q";
	}

	public static UI_btn_Operation_Jump CreateInstance()
	{
		return (UI_btn_Operation_Jump)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_Operation_Jump");
	}

	public static UI_btn_Operation_Jump CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Operation_Jump).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mk4p9q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
