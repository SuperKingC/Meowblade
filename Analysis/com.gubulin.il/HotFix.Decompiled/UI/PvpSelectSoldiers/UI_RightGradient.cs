using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RightGradient : GComponent
{
	public GImage n58;

	public const string URL = "ui://82mo10n5ok37dkr";

	public static string Name = "UI_RightGradient";

	public static string GetURL()
	{
		return "ui://82mo10n5ok37dkr";
	}

	public static UI_RightGradient CreateInstance()
	{
		return (UI_RightGradient)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RightGradient");
	}

	public static UI_RightGradient CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RightGradient).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ok37dkr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n58 = (GImage)((GComponent)this).GetChild("n58");
	}
}
