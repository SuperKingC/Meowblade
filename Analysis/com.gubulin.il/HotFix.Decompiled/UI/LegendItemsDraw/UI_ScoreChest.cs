using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsDraw;

public class UI_ScoreChest : GButton
{
	public Controller Status;

	public GImage ChestOpen;

	public GImage ChestClosed;

	public GImage Chest;

	public GGraph n12;

	public const string URL = "ui://xogvri2hkoygv";

	public static string Name = "UI_ScoreChest";

	public static string GetURL()
	{
		return "ui://xogvri2hkoygv";
	}

	public static UI_ScoreChest CreateInstance()
	{
		return (UI_ScoreChest)(object)UIPackage.CreateObject("LegendItemsDraw", "ScoreChest");
	}

	public static UI_ScoreChest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScoreChest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hkoygv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		ChestOpen = (GImage)((GComponent)this).GetChild("ChestOpen");
		ChestClosed = (GImage)((GComponent)this).GetChild("ChestClosed");
		Chest = (GImage)((GComponent)this).GetChild("Chest");
		n12 = (GGraph)((GComponent)this).GetChild("n12");
	}
}
