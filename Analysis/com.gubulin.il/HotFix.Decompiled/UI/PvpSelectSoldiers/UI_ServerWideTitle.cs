using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideTitle : GButton
{
	public GImage n7;

	public GLoader icon;

	public Transition TurnPage;

	public const string URL = "ui://82mo10n5y6lgjdr9";

	public static string Name = "UI_ServerWideTitle";

	public static string GetURL()
	{
		return "ui://82mo10n5y6lgjdr9";
	}

	public static UI_ServerWideTitle CreateInstance()
	{
		return (UI_ServerWideTitle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideTitle");
	}

	public static UI_ServerWideTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5y6lgjdr9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		TurnPage = ((GComponent)this).GetTransition("TurnPage");
	}
}
