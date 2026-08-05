using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_BuildingTitle : GComponent
{
	public GGraph back;

	public GLoader icon;

	public GTextField name;

	public GLoader n5;

	public GTextField n6;

	public const string URL = "ui://rujfbplhmol00";

	public static string Name = "UI_BuildingTitle";

	public static string GetURL()
	{
		return "ui://rujfbplhmol00";
	}

	public static UI_BuildingTitle CreateInstance()
	{
		return (UI_BuildingTitle)(object)UIPackage.CreateObject("SceneUi", "BuildingTitle");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		name = (GTextField)((GComponent)this).GetChild("name");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
	}
}
