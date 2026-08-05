using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_btn__100 : GButton
{
	public GImage n193;

	public GTextField title;

	public const string URL = "ui://fpjheycbslenv4gm";

	public static string Name = "UI_btn__100";

	public static string GetURL()
	{
		return "ui://fpjheycbslenv4gm";
	}

	public static UI_btn__100 CreateInstance()
	{
		return (UI_btn__100)(object)UIPackage.CreateObject("GvGAmplifierForge", "btn_+100");
	}

	public static UI_btn__100 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn__100).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbslenv4gm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n193 = (GImage)((GComponent)this).GetChild("n193");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}
