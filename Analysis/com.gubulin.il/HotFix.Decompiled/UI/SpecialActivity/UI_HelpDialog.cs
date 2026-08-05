using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_HelpDialog : GComponent
{
	public GImage back;

	public UI_HelpContent Content;

	public const string URL = "ui://kozswd8hbwf1f41";

	public static string Name = "UI_HelpDialog";

	public static string GetURL()
	{
		return "ui://kozswd8hbwf1f41";
	}

	public static UI_HelpDialog CreateInstance()
	{
		return (UI_HelpDialog)(object)UIPackage.CreateObject("SpecialActivity", "HelpDialog");
	}

	public static UI_HelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hbwf1f41", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Content = (UI_HelpContent)(object)((GComponent)this).GetChild("Content");
	}
}
