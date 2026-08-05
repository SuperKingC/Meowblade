using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_WorkerBubble : GComponent
{
	public GImage back;

	public GLoader icon;

	public GImage max;

	public UI_MateriaNuml n7;

	public const string URL = "ui://rujfbplhnwjt14";

	public static string Name = "UI_WorkerBubble";

	public static string GetURL()
	{
		return "ui://rujfbplhnwjt14";
	}

	public static UI_WorkerBubble CreateInstance()
	{
		return (UI_WorkerBubble)(object)UIPackage.CreateObject("SceneUi", "WorkerBubble");
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
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		max = (GImage)((GComponent)this).GetChild("max");
		n7 = (UI_MateriaNuml)(object)((GComponent)this).GetChild("n7");
	}
}
