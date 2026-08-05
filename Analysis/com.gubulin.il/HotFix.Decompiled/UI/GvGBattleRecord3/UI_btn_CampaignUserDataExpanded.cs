using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_CampaignUserDataExpanded : GButton
{
	public GImage n10;

	public GList ShipData;

	public const string URL = "ui://b3fc6085v9ok2c";

	public static string Name = "UI_btn_CampaignUserDataExpanded";

	public static string GetURL()
	{
		return "ui://b3fc6085v9ok2c";
	}

	public static UI_btn_CampaignUserDataExpanded CreateInstance()
	{
		return (UI_btn_CampaignUserDataExpanded)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_CampaignUserDataExpanded");
	}

	public static UI_btn_CampaignUserDataExpanded CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CampaignUserDataExpanded).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085v9ok2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		ShipData = (GList)((GComponent)this).GetChild("ShipData");
	}
}
