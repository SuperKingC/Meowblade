using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_HelpDialog : GComponent
{
	public GImage Background;

	public GImage n0;

	public const string URL = "ui://k2sprg26zc3o9l";

	public static string Name = "UI_HelpDialog";

	public static string GetURL()
	{
		return "ui://k2sprg26zc3o9l";
	}

	public static UI_HelpDialog CreateInstance()
	{
		return (UI_HelpDialog)(object)UIPackage.CreateObject("IslandComeAgain", "HelpDialog");
	}

	public static UI_HelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26zc3o9l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
