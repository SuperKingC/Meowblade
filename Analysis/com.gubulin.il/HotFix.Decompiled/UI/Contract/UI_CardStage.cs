using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_CardStage : GComponent
{
	public GGraph StageWrapper;

	public GGraph PortalWrapper;

	public const string URL = "ui://avplaivdicfotn7";

	public static string Name = "UI_CardStage";

	public static string GetURL()
	{
		return "ui://avplaivdicfotn7";
	}

	public static UI_CardStage CreateInstance()
	{
		return (UI_CardStage)(object)UIPackage.CreateObject("Contract", "CardStage");
	}

	public static UI_CardStage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardStage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdicfotn7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StageWrapper = (GGraph)((GComponent)this).GetChild("StageWrapper");
		PortalWrapper = (GGraph)((GComponent)this).GetChild("PortalWrapper");
	}
}
