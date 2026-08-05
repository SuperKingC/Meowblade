using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_CampaignContributionAccess : GComponent
{
	public GImage n2;

	public GTextField Desc;

	public const string URL = "ui://b3fc6085he7dff";

	public static string Name = "UI_com_CampaignContributionAccess";

	public static string GetURL()
	{
		return "ui://b3fc6085he7dff";
	}

	public static UI_com_CampaignContributionAccess CreateInstance()
	{
		return (UI_com_CampaignContributionAccess)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_CampaignContributionAccess");
	}

	public static UI_com_CampaignContributionAccess CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampaignContributionAccess).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085he7dff", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
	}
}
