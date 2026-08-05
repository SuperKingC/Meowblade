using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_LevelSelectorLabel : GComponent
{
	public Controller onGoingController;

	public GGraph n1;

	public UI_com_LabelPreparing labelPreparing;

	public UI_com_LabelOnGoing labelOnGoing;

	public const string URL = "ui://8x5gc8j2ex2w4";

	public static string Name = "UI_com_LevelSelectorLabel";

	public static string GetURL()
	{
		return "ui://8x5gc8j2ex2w4";
	}

	public static UI_com_LevelSelectorLabel CreateInstance()
	{
		return (UI_com_LevelSelectorLabel)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_LevelSelectorLabel");
	}

	public static UI_com_LevelSelectorLabel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LevelSelectorLabel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2ex2w4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		onGoingController = ((GComponent)this).GetController("onGoingController");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		labelPreparing = (UI_com_LabelPreparing)(object)((GComponent)this).GetChild("labelPreparing");
		labelOnGoing = (UI_com_LabelOnGoing)(object)((GComponent)this).GetChild("labelOnGoing");
	}
}
