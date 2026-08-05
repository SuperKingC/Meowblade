using FairyGUI;
using FairyGUI.Utils;

namespace UI.SceneUi;

public class UI_ProductionNumFloating : GButton
{
	public Controller button;

	public GTextField title;

	public Transition DisAppear;

	public const string URL = "ui://rujfbplhmol0k";

	public static string Name = "UI_ProductionNumFloating";

	public static string GetURL()
	{
		return "ui://rujfbplhmol0k";
	}

	public static UI_ProductionNumFloating CreateInstance()
	{
		return (UI_ProductionNumFloating)(object)UIPackage.CreateObject("SceneUi", "ProductionNumFloating");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		title = (GTextField)((GComponent)this).GetChild("title");
		DisAppear = ((GComponent)this).GetTransition("DisAppear");
	}
}
