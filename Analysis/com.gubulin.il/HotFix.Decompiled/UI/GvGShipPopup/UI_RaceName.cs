using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_RaceName : GComponent
{
	public GTextField Title;

	public const string URL = "ui://pwrbvhpvo9lr39";

	public static string Name = "UI_RaceName";

	public static string GetURL()
	{
		return "ui://pwrbvhpvo9lr39";
	}

	public static UI_RaceName CreateInstance()
	{
		return (UI_RaceName)(object)UIPackage.CreateObject("GvGShipPopup", "RaceName");
	}

	public static UI_RaceName CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RaceName).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvo9lr39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
