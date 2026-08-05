using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_item : GButton
{
	public Controller button;

	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public const string URL = "ui://rujfbplhj93u12";

	public static string Name = "UI_item";

	public static string GetURL()
	{
		return "ui://rujfbplhj93u12";
	}

	public static UI_item CreateInstance()
	{
		return (UI_item)(object)UIPackage.CreateObject("SceneUi", "item");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
