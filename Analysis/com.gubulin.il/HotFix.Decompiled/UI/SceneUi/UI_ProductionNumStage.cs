using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_ProductionNumStage : GComponent
{
	public GGraph line0;

	public GGraph line1;

	public const string URL = "ui://rujfbplhmol0j";

	public static string Name = "UI_ProductionNumStage";

	public static string GetURL()
	{
		return "ui://rujfbplhmol0j";
	}

	public static UI_ProductionNumStage CreateInstance()
	{
		return (UI_ProductionNumStage)(object)UIPackage.CreateObject("SceneUi", "ProductionNumStage");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		line0 = (GGraph)((GComponent)this).GetChild("line0");
		line1 = (GGraph)((GComponent)this).GetChild("line1");
	}
}
