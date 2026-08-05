using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_buildingDirectionIndicator : GButton
{
	public Controller button;

	public GImage back;

	public GLoader icon;

	public const string URL = "ui://rujfbplhmol0z";

	public static string Name = "UI_buildingDirectionIndicator";

	public static string GetURL()
	{
		return "ui://rujfbplhmol0z";
	}

	public static UI_buildingDirectionIndicator CreateInstance()
	{
		return (UI_buildingDirectionIndicator)(object)UIPackage.CreateObject("SceneUi", "buildingDirectionIndicator");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
