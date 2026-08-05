using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_OffensiveInstanceZonesLevel : GComponent
{
	public Controller PageController;

	public Controller PotentialController;

	public GImage BLevelBack;

	public GImage ALevelBack;

	public GImage SLevelBack;

	public GComponent PotentialIcon;

	public const string URL = "ui://f4wr270ric7j2t";

	public static string Name = "UI_OffensiveInstanceZonesLevel";

	public static string GetURL()
	{
		return "ui://f4wr270ric7j2t";
	}

	public static UI_OffensiveInstanceZonesLevel CreateInstance()
	{
		return (UI_OffensiveInstanceZonesLevel)(object)UIPackage.CreateObject("InstanceZones", "OffensiveInstanceZonesLevel");
	}

	public static UI_OffensiveInstanceZonesLevel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OffensiveInstanceZonesLevel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270ric7j2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		PotentialController = ((GComponent)this).GetController("PotentialController");
		BLevelBack = (GImage)((GComponent)this).GetChild("BLevelBack");
		ALevelBack = (GImage)((GComponent)this).GetChild("ALevelBack");
		SLevelBack = (GImage)((GComponent)this).GetChild("SLevelBack");
		PotentialIcon = (GComponent)((GComponent)this).GetChild("PotentialIcon");
	}
}
