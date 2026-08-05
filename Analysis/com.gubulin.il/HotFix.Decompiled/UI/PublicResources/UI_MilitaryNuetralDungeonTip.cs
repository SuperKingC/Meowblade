using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_MilitaryNuetralDungeonTip : GComponent
{
	public Controller Status;

	public Transition EquipmentListDisappear;

	public const string URL = "ui://kt6rg65ojy5av4c7";

	public static string Name = "UI_MilitaryNuetralDungeonTip";

	public static string GetURL()
	{
		return "ui://kt6rg65ojy5av4c7";
	}

	public static UI_MilitaryNuetralDungeonTip CreateInstance()
	{
		return (UI_MilitaryNuetralDungeonTip)(object)UIPackage.CreateObject("PublicResources", "MilitaryNuetralDungeonTip");
	}

	public static UI_MilitaryNuetralDungeonTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MilitaryNuetralDungeonTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ojy5av4c7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		EquipmentListDisappear = ((GComponent)this).GetTransition("EquipmentListDisappear");
	}
}
