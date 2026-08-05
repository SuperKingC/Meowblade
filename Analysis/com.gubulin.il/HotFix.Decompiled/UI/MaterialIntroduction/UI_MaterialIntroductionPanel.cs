using FairyGUI;
using FairyGUI.Utils;

namespace UI.MaterialIntroduction;

public class UI_MaterialIntroductionPanel : GComponent
{
	public GGraph back;

	public GComponent tip;

	public UI_MaterialIntroduction tip1;

	public Transition showTip;

	public const string URL = "ui://l3jq1eamic7j2";

	public static string Name = "UI_MaterialIntroductionPanel";

	public static UI_MaterialIntroductionPanel CreateInstance()
	{
		return (UI_MaterialIntroductionPanel)(object)UIPackage.CreateObject("MaterialIntroduction", "MaterialIntroductionPanel");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		tip = (GComponent)((GComponent)this).GetChild("tip");
		tip1 = (UI_MaterialIntroduction)(object)((GComponent)this).GetChild("tip1");
		showTip = ((GComponent)this).GetTransition("showTip");
	}
}
