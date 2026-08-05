using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_CampaignContributionAccess : GComponent
{
	public GImage n0;

	public GTextField Desc;

	public const string URL = "ui://ebc4ciwrhe7dq5k";

	public static string Name = "UI_com_CampaignContributionAccess";

	public static string GetURL()
	{
		return "ui://ebc4ciwrhe7dq5k";
	}

	public static UI_com_CampaignContributionAccess CreateInstance()
	{
		return (UI_com_CampaignContributionAccess)(object)UIPackage.CreateObject("GvGOnIsland3", "com_CampaignContributionAccess");
	}

	public static UI_com_CampaignContributionAccess CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampaignContributionAccess).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrhe7dq5k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
	}
}
