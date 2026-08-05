using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_OutTechHelpContent : GComponent
{
	public GImage n0;

	public const string URL = "ui://th385mttrp3co7t";

	public static string Name = "UI_com_OutTechHelpContent";

	public static string GetURL()
	{
		return "ui://th385mttrp3co7t";
	}

	public static UI_com_OutTechHelpContent CreateInstance()
	{
		return (UI_com_OutTechHelpContent)(object)UIPackage.CreateObject("GvGOuterTech", "com_OutTechHelpContent");
	}

	public static UI_com_OutTechHelpContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OutTechHelpContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttrp3co7t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
