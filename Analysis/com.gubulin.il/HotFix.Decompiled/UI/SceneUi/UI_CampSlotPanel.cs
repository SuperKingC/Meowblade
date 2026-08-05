using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_CampSlotPanel : GComponent
{
	public GList EquipmentList;

	public GProgressBar ProgressBar;

	public GGraph n2;

	public Transition EquipmentListDisappear;

	public const string URL = "ui://rujfbplhf4ho11";

	public static string Name = "UI_CampSlotPanel";

	public static string GetURL()
	{
		return "ui://rujfbplhf4ho11";
	}

	public static UI_CampSlotPanel CreateInstance()
	{
		return (UI_CampSlotPanel)(object)UIPackage.CreateObject("SceneUi", "CampSlotPanel");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		EquipmentList = (GList)((GComponent)this).GetChild("EquipmentList");
		ProgressBar = (GProgressBar)((GComponent)this).GetChild("ProgressBar");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		EquipmentListDisappear = ((GComponent)this).GetTransition("EquipmentListDisappear");
	}
}
