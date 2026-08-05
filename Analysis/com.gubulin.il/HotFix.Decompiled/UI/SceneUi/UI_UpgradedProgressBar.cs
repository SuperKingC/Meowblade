using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_UpgradedProgressBar : GProgressBar
{
	public GGraph back;

	public GImage bar;

	public GTextField time;

	public GImage icon;

	public GImage upgradeTitle;

	public GImage repairedTitle;

	public const string URL = "ui://rujfbplhmol0x";

	public static string Name = "UI_UpgradedProgressBar";

	public static string GetURL()
	{
		return "ui://rujfbplhmol0x";
	}

	public static UI_UpgradedProgressBar CreateInstance()
	{
		return (UI_UpgradedProgressBar)(object)UIPackage.CreateObject("SceneUi", "UpgradedProgressBar");
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		bar = (GImage)((GComponent)this).GetChild("bar");
		time = (GTextField)((GComponent)this).GetChild("time");
		icon = (GImage)((GComponent)this).GetChild("icon");
		upgradeTitle = (GImage)((GComponent)this).GetChild("upgradeTitle");
		repairedTitle = (GImage)((GComponent)this).GetChild("repairedTitle");
	}
}
