using FairyGUI;
using FairyGUI.Utils;

namespace UI.MaterialIntroduction;

public class UI_Content : GComponent
{
	public GLoader icon;

	public UI_MaterialIntroductionRight RightContent;

	public const string URL = "ui://l3jq1eamic7j4";

	public static string Name = "UI_Content";

	public static UI_Content CreateInstance()
	{
		return (UI_Content)(object)UIPackage.CreateObject("MaterialIntroduction", "Content");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		RightContent = (UI_MaterialIntroductionRight)(object)((GComponent)this).GetChild("RightContent");
	}
}
