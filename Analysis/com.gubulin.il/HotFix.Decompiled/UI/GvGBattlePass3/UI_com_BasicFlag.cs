using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_BasicFlag : GComponent
{
	public GImage n152;

	public GImage n148;

	public GImage n153;

	public const string URL = "ui://bfjg32hukcdl5v";

	public static string Name = "UI_com_BasicFlag";

	public static string GetURL()
	{
		return "ui://bfjg32hukcdl5v";
	}

	public static UI_com_BasicFlag CreateInstance()
	{
		return (UI_com_BasicFlag)(object)UIPackage.CreateObject("GvGBattlePass3", "com_BasicFlag");
	}

	public static UI_com_BasicFlag CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BasicFlag).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hukcdl5v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		n153 = (GImage)((GComponent)this).GetChild("n153");
	}
}
