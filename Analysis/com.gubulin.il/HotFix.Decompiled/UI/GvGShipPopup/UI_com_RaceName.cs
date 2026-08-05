using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_com_RaceName : GComponent
{
	public GTextField Title;

	public const string URL = "ui://pwrbvhpv998c67";

	public static string Name = "UI_com_RaceName";

	public static string GetURL()
	{
		return "ui://pwrbvhpv998c67";
	}

	public static UI_com_RaceName CreateInstance()
	{
		return (UI_com_RaceName)(object)UIPackage.CreateObject("GvGShipPopup", "com_RaceName");
	}

	public static UI_com_RaceName CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RaceName).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpv998c67", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Title = (GTextField)((GComponent)this).GetChild("Title");
	}
}
