using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_com_TimeBar : GProgressBar
{
	public GImage n0;

	public GImage bar;

	public const string URL = "ui://vheg8vabnfmek";

	public static string Name = "UI_com_TimeBar";

	public static string GetURL()
	{
		return "ui://vheg8vabnfmek";
	}

	public static UI_com_TimeBar CreateInstance()
	{
		return (UI_com_TimeBar)(object)UIPackage.CreateObject("GvGPlayerCommand3", "com_TimeBar");
	}

	public static UI_com_TimeBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TimeBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabnfmek", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
