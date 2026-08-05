using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_dec_TitleText : GComponent
{
	public GImage n8;

	public GImage n7;

	public const string URL = "ui://p4ocf6q0whk915";

	public static string Name = "UI_dec_TitleText";

	public static string GetURL()
	{
		return "ui://p4ocf6q0whk915";
	}

	public static UI_dec_TitleText CreateInstance()
	{
		return (UI_dec_TitleText)(object)UIPackage.CreateObject("GvGRandomEvent3", "dec_TitleText");
	}

	public static UI_dec_TitleText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_TitleText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0whk915", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
