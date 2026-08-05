using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_Text01 : GComponent
{
	public GImage n25;

	public GImage n26;

	public const string URL = "ui://4eq8fgd2irkpcp";

	public static string Name = "UI_dec_Text01";

	public static string GetURL()
	{
		return "ui://4eq8fgd2irkpcp";
	}

	public static UI_dec_Text01 CreateInstance()
	{
		return (UI_dec_Text01)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_Text01");
	}

	public static UI_dec_Text01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Text01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2irkpcp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
	}
}
