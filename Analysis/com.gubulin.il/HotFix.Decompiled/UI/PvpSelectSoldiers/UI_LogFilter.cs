using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_LogFilter : GButton
{
	public Controller button;

	public UI_LogFilterBtn Win;

	public UI_LogFilterBtn Fail;

	public const string URL = "ui://82mo10n5t7wpdez";

	public static string Name = "UI_LogFilter";

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpdez";
	}

	public static UI_LogFilter CreateInstance()
	{
		return (UI_LogFilter)(object)UIPackage.CreateObject("PvpSelectSoldiers", "LogFilter");
	}

	public static UI_LogFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LogFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpdez", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Win = (UI_LogFilterBtn)(object)((GComponent)this).GetChild("Win");
		Fail = (UI_LogFilterBtn)(object)((GComponent)this).GetChild("Fail");
	}
}
