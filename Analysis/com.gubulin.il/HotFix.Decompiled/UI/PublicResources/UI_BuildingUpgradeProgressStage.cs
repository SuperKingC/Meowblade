using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_BuildingUpgradeProgressStage : GComponent
{
	public GGraph n2;

	public UI_UpgradedProgressBar UpgradedProgressBar;

	public UI_UpdatingProgressBar UpdatingProgressBar;

	public const string URL = "ui://kt6rg65omol0ip";

	public static string Name = "UI_BuildingUpgradeProgressStage";

	public static string GetURL()
	{
		return "ui://kt6rg65omol0ip";
	}

	public static UI_BuildingUpgradeProgressStage CreateInstance()
	{
		return (UI_BuildingUpgradeProgressStage)(object)UIPackage.CreateObject("PublicResources", "BuildingUpgradeProgressStage");
	}

	public static UI_BuildingUpgradeProgressStage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuildingUpgradeProgressStage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0ip", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		UpgradedProgressBar = (UI_UpgradedProgressBar)(object)((GComponent)this).GetChild("UpgradedProgressBar");
		UpdatingProgressBar = (UI_UpdatingProgressBar)(object)((GComponent)this).GetChild("UpdatingProgressBar");
	}
}
