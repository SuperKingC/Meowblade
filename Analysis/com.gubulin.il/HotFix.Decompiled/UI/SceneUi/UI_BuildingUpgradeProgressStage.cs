using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_BuildingUpgradeProgressStage : GComponent
{
	public UI_UpgradedProgressBar UpgradedProgressBar;

	public UI_UpdatingProgressBar UpdatingProgressBar;

	public const string URL = "ui://rujfbplhmol0y";

	public static string Name = "UI_BuildingUpgradeProgressStage";

	public static string GetURL()
	{
		return "ui://rujfbplhmol0y";
	}

	public static UI_BuildingUpgradeProgressStage CreateInstance()
	{
		return (UI_BuildingUpgradeProgressStage)(object)UIPackage.CreateObject("SceneUi", "BuildingUpgradeProgressStage");
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		UpgradedProgressBar = (UI_UpgradedProgressBar)(object)((GComponent)this).GetChild("UpgradedProgressBar");
		UpdatingProgressBar = (UI_UpdatingProgressBar)(object)((GComponent)this).GetChild("UpdatingProgressBar");
	}
}
