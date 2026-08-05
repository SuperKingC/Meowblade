using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_PropetryContent : GComponent
{
	public UI_Propetry SubEntries;

	public UI_Propetry FxEntry;

	public UI_Propetry SuitEntry;

	public const string URL = "ui://lzvt5p2vi09eb";

	public static string Name = "UI_PropetryContent";

	public static string GetURL()
	{
		return "ui://lzvt5p2vi09eb";
	}

	public static UI_PropetryContent CreateInstance()
	{
		return (UI_PropetryContent)(object)UIPackage.CreateObject("LegendItemInfo", "PropetryContent");
	}

	public static UI_PropetryContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PropetryContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vi09eb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		SubEntries = (UI_Propetry)(object)((GComponent)this).GetChild("SubEntries");
		FxEntry = (UI_Propetry)(object)((GComponent)this).GetChild("FxEntry");
		SuitEntry = (UI_Propetry)(object)((GComponent)this).GetChild("SuitEntry");
	}
}
