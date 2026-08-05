using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_HelpContent : GComponent
{
	public GImage n0;

	public const string URL = "ui://avplaivdbimotl0";

	public static string Name = "UI_HelpContent";

	public static string GetURL()
	{
		return "ui://avplaivdbimotl0";
	}

	public static UI_HelpContent CreateInstance()
	{
		return (UI_HelpContent)(object)UIPackage.CreateObject("Contract", "HelpContent");
	}

	public static UI_HelpContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdbimotl0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
