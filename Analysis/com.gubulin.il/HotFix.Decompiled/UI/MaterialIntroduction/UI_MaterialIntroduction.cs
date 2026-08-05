using FairyGUI;
using FairyGUI.Utils;

namespace UI.MaterialIntroduction;

public class UI_MaterialIntroduction : GComponent
{
	public Controller PageController;

	public GGraph interceptBack;

	public GImage windowBack;

	public UI_RepairBtn checkBtn;

	public UI_Content Content;

	public UI_consumption consumption;

	public const string URL = "ui://l3jq1eamic7j3";

	public static string Name = "UI_MaterialIntroduction";

	public static UI_MaterialIntroduction CreateInstance()
	{
		return (UI_MaterialIntroduction)(object)UIPackage.CreateObject("MaterialIntroduction", "MaterialIntroduction");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		interceptBack = (GGraph)((GComponent)this).GetChild("interceptBack");
		windowBack = (GImage)((GComponent)this).GetChild("windowBack");
		checkBtn = (UI_RepairBtn)(object)((GComponent)this).GetChild("checkBtn");
		Content = (UI_Content)(object)((GComponent)this).GetChild("Content");
		consumption = (UI_consumption)(object)((GComponent)this).GetChild("consumption");
	}
}
