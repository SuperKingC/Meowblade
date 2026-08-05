using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_OurHPbar : GProgressBar
{
	public GImage n3;

	public GImage bar;

	public const string URL = "ui://kqd1t06of258a";

	public static string Name = "UI_OurHPbar";

	public static string GetURL()
	{
		return "ui://kqd1t06of258a";
	}

	public static UI_OurHPbar CreateInstance()
	{
		return (UI_OurHPbar)(object)UIPackage.CreateObject("QuickBattle", "OurHPbar");
	}

	public static UI_OurHPbar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OurHPbar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of258a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GImage)((GComponent)this).GetChild("n3");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
