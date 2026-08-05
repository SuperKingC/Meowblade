using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_UniversalPopupTip : GComponent
{
	public GImage n0;

	public GRichTextField title;

	public const string URL = "ui://kt6rg65oag1qv4r6";

	public static string Name = "UI_com_UniversalPopupTip";

	public static string GetURL()
	{
		return "ui://kt6rg65oag1qv4r6";
	}

	public static UI_com_UniversalPopupTip CreateInstance()
	{
		return (UI_com_UniversalPopupTip)(object)UIPackage.CreateObject("PublicResources", "com_UniversalPopupTip");
	}

	public static UI_com_UniversalPopupTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UniversalPopupTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oag1qv4r6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		title = (GRichTextField)((GComponent)this).GetChild("title");
	}
}
