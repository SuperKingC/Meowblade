using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_storylinestepbar : GComponent
{
	public Controller IsEternalNight;

	public GImage n0;

	public const string URL = "ui://4eq8fgd2kcmt80";

	public static string Name = "UI_dec_storylinestepbar";

	public static string GetURL()
	{
		return "ui://4eq8fgd2kcmt80";
	}

	public static UI_dec_storylinestepbar CreateInstance()
	{
		return (UI_dec_storylinestepbar)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_storylinestepbar");
	}

	public static UI_dec_storylinestepbar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_storylinestepbar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kcmt80", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsEternalNight = ((GComponent)this).GetController("IsEternalNight");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
