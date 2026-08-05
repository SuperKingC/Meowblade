using FairyGUI;
using FairyGUI.Utils;

namespace UI.MaterialIntroduction;

public class UI_consumption : GComponent
{
	public GRichTextField consumeTitle;

	public GRichTextField consumeNum;

	public const string URL = "ui://l3jq1eamic7j6";

	public static string Name = "UI_consumption";

	public static UI_consumption CreateInstance()
	{
		return (UI_consumption)(object)UIPackage.CreateObject("MaterialIntroduction", "consumption");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		consumeTitle = (GRichTextField)((GComponent)this).GetChild("consumeTitle");
		consumeNum = (GRichTextField)((GComponent)this).GetChild("consumeNum");
	}
}
