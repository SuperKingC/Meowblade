using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_OpenTreasureHuntBossLevelBox : GButton
{
	public Controller button;

	public GGraph n4;

	public GImage n3;

	public const string URL = "ui://hda5vzklnm994t";

	public static string Name = "UI_OpenTreasureHuntBossLevelBox";

	public static string GetURL()
	{
		return "ui://hda5vzklnm994t";
	}

	public static UI_OpenTreasureHuntBossLevelBox CreateInstance()
	{
		return (UI_OpenTreasureHuntBossLevelBox)(object)UIPackage.CreateObject("GameEndPanels", "OpenTreasureHuntBossLevelBox");
	}

	public static UI_OpenTreasureHuntBossLevelBox CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OpenTreasureHuntBossLevelBox).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklnm994t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
