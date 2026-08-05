using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_NextLevelScore : GComponent
{
	public GImage n1;

	public GTextField Tip;

	public const string URL = "ui://11dkggb8nk8f1x";

	public static string Name = "UI_com_NextLevelScore";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f1x";
	}

	public static UI_com_NextLevelScore CreateInstance()
	{
		return (UI_com_NextLevelScore)(object)UIPackage.CreateObject("WeekActivityPass", "com_NextLevelScore");
	}

	public static UI_com_NextLevelScore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NextLevelScore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f1x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
	}
}
