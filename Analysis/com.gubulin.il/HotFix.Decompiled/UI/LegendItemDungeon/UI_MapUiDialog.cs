using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_MapUiDialog : GComponent
{
	public Controller Modle;

	public GImage Back;

	public UI_CameraCom Map;

	public UI_FloorInfo FloorInfo;

	public UI_Upward Upward;

	public UI_DrawLegendItem DrawLegendItem;

	public UI_SelectLevelMain SelectLevel;

	public UI_SelectLevel LeftShift;

	public UI_SelectLevel RightShift;

	public UI_Downward Downward;

	public UI_Progress Progress;

	public UI_LegendItemDetector Detector;

	public UI_PresetFormationBtn PresetFormationBtn;

	public const string URL = "ui://2eraz3j9y9rzj";

	public static string Name = "UI_MapUiDialog";

	public static string GetURL()
	{
		return "ui://2eraz3j9y9rzj";
	}

	public static UI_MapUiDialog CreateInstance()
	{
		return (UI_MapUiDialog)(object)UIPackage.CreateObject("LegendItemDungeon", "MapUiDialog");
	}

	public static UI_MapUiDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MapUiDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9y9rzj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Modle = ((GComponent)this).GetController("Modle");
		Back = (GImage)((GComponent)this).GetChild("Back");
		Map = (UI_CameraCom)(object)((GComponent)this).GetChild("Map");
		FloorInfo = (UI_FloorInfo)(object)((GComponent)this).GetChild("FloorInfo");
		Upward = (UI_Upward)(object)((GComponent)this).GetChild("Upward");
		DrawLegendItem = (UI_DrawLegendItem)(object)((GComponent)this).GetChild("DrawLegendItem");
		SelectLevel = (UI_SelectLevelMain)(object)((GComponent)this).GetChild("SelectLevel");
		LeftShift = (UI_SelectLevel)(object)((GComponent)this).GetChild("LeftShift");
		RightShift = (UI_SelectLevel)(object)((GComponent)this).GetChild("RightShift");
		Downward = (UI_Downward)(object)((GComponent)this).GetChild("Downward");
		Progress = (UI_Progress)(object)((GComponent)this).GetChild("Progress");
		Detector = (UI_LegendItemDetector)(object)((GComponent)this).GetChild("Detector");
		PresetFormationBtn = (UI_PresetFormationBtn)(object)((GComponent)this).GetChild("PresetFormationBtn");
	}
}
