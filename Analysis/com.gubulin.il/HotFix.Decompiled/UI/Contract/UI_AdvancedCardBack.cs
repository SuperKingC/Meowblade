using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_AdvancedCardBack : GComponent
{
	public GButton n11;

	public const string URL = "ui://avplaivdmxsj21";

	public static string Name = "UI_AdvancedCardBack";

	public static string GetURL()
	{
		return "ui://avplaivdmxsj21";
	}

	public static UI_AdvancedCardBack CreateInstance()
	{
		return (UI_AdvancedCardBack)(object)UIPackage.CreateObject("Contract", "AdvancedCardBack");
	}

	public static UI_AdvancedCardBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AdvancedCardBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdmxsj21", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n11 = (GButton)((GComponent)this).GetChild("n11");
	}
}
