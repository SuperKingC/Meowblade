using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ClassicCardBack : GComponent
{
	public GButton cardReverseSide;

	public const string URL = "ui://avplaivdoppx1l";

	public static string Name = "UI_ClassicCardBack";

	public static string GetURL()
	{
		return "ui://avplaivdoppx1l";
	}

	public static UI_ClassicCardBack CreateInstance()
	{
		return (UI_ClassicCardBack)(object)UIPackage.CreateObject("Contract", "ClassicCardBack");
	}

	public static UI_ClassicCardBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClassicCardBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdoppx1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		cardReverseSide = (GButton)((GComponent)this).GetChild("cardReverseSide");
	}
}
