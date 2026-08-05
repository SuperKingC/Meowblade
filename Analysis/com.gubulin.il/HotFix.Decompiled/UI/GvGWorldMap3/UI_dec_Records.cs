using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_Records : GComponent
{
	public GImage n8;

	public GImage n3;

	public GImage n5;

	public const string URL = "ui://4eq8fgd2rf6isaz";

	public static string Name = "UI_dec_Records";

	public static string GetURL()
	{
		return "ui://4eq8fgd2rf6isaz";
	}

	public static UI_dec_Records CreateInstance()
	{
		return (UI_dec_Records)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_Records");
	}

	public static UI_dec_Records CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Records).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2rf6isaz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
