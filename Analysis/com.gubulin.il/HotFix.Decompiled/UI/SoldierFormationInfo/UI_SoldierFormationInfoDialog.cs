using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierFormationInfo;

public class UI_SoldierFormationInfoDialog : GComponent
{
	public GTextField content;

	public const string URL = "ui://r7u60zpohc8r2";

	public static string Name = "UI_SoldierFormationInfoDialog";

	public static string GetURL()
	{
		return "ui://r7u60zpohc8r2";
	}

	public static UI_SoldierFormationInfoDialog CreateInstance()
	{
		return (UI_SoldierFormationInfoDialog)(object)UIPackage.CreateObject("SoldierFormationInfo", "SoldierFormationInfoDialog");
	}

	public static UI_SoldierFormationInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierFormationInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r7u60zpohc8r2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		content = (GTextField)((GComponent)this).GetChild("content");
	}
}
