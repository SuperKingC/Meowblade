using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_IconAndSfx : GComponent
{
	public GLoader icon;

	public GGraph SfxBack;

	public const string URL = "ui://rujfbplho9xc18";

	public static string Name = "UI_IconAndSfx";

	public static string GetURL()
	{
		return "ui://rujfbplho9xc18";
	}

	public static UI_IconAndSfx CreateInstance()
	{
		return (UI_IconAndSfx)(object)UIPackage.CreateObject("SceneUi", "IconAndSfx");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
	}
}
