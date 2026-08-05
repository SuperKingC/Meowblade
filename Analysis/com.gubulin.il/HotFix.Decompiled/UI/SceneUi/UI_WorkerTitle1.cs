using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_WorkerTitle1 : GComponent
{
	public GGraph back;

	public GTextField name;

	public GLoader icon;

	public const string URL = "ui://rujfbplhx2iy1d";

	public static string Name = "UI_WorkerTitle1";

	public static string GetURL()
	{
		return "ui://rujfbplhx2iy1d";
	}

	public static UI_WorkerTitle1 CreateInstance()
	{
		return (UI_WorkerTitle1)(object)UIPackage.CreateObject("SceneUi", "WorkerTitle1");
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
		back = (GGraph)((GComponent)this).GetChild("back");
		name = (GTextField)((GComponent)this).GetChild("name");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
