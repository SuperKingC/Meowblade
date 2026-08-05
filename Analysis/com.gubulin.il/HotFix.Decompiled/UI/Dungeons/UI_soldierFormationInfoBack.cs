using FairyGUI;
using FairyGUI.Utils;

namespace UI.Dungeons;

public class UI_soldierFormationInfoBack : GButton
{
	public Controller button;

	public const string URL = "ui://e3srq2g9tfsim";

	public static string Name = "UI_soldierFormationInfoBack";

	public static string GetURL()
	{
		return "ui://e3srq2g9tfsim";
	}

	public static UI_soldierFormationInfoBack CreateInstance()
	{
		return (UI_soldierFormationInfoBack)(object)UIPackage.CreateObject("Dungeons", "soldierFormationInfoBack");
	}

	public static UI_soldierFormationInfoBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_soldierFormationInfoBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9tfsim", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
	}
}
