using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_OutTechHelpDialog : GComponent
{
	public GImage back;

	public UI_com_OutTechHelpContent Content;

	public const string URL = "ui://th385mttrp3co7s";

	public static string Name = "UI_com_OutTechHelpDialog";

	public static string GetURL()
	{
		return "ui://th385mttrp3co7s";
	}

	public static UI_com_OutTechHelpDialog CreateInstance()
	{
		return (UI_com_OutTechHelpDialog)(object)UIPackage.CreateObject("GvGOuterTech", "com_OutTechHelpDialog");
	}

	public static UI_com_OutTechHelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OutTechHelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttrp3co7s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Content = (UI_com_OutTechHelpContent)(object)((GComponent)this).GetChild("Content");
	}
}
