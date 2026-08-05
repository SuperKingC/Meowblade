using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_LeftGradient : GComponent
{
	public GImage n56;

	public const string URL = "ui://82mo10n5ok37dkq";

	public static string Name = "UI_LeftGradient";

	public static string GetURL()
	{
		return "ui://82mo10n5ok37dkq";
	}

	public static UI_LeftGradient CreateInstance()
	{
		return (UI_LeftGradient)(object)UIPackage.CreateObject("PvpSelectSoldiers", "LeftGradient");
	}

	public static UI_LeftGradient CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LeftGradient).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ok37dkq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n56 = (GImage)((GComponent)this).GetChild("n56");
	}
}
