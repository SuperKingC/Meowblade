using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_dec_Line : GComponent
{
	public GImage n180;

	public const string URL = "ui://fpjheycbej1av4fz";

	public static string Name = "UI_dec_Line";

	public static string GetURL()
	{
		return "ui://fpjheycbej1av4fz";
	}

	public static UI_dec_Line CreateInstance()
	{
		return (UI_dec_Line)(object)UIPackage.CreateObject("GvGAmplifierForge", "dec_Line");
	}

	public static UI_dec_Line CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Line).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbej1av4fz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n180 = (GImage)((GComponent)this).GetChild("n180");
	}
}
