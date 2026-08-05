using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_IslandCampaignDialog : GComponent
{
	public Controller State;

	public GImage back;

	public GImage n6;

	public GTextField n1;

	public GTextField IslandName;

	public GList CampaignRecords;

	public GTextField n4;

	public GImage n5;

	public const string URL = "ui://b3fc6085owu51";

	public static string Name = "UI_com_IslandCampaignDialog";

	public static string GetURL()
	{
		return "ui://b3fc6085owu51";
	}

	public static UI_com_IslandCampaignDialog CreateInstance()
	{
		return (UI_com_IslandCampaignDialog)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_IslandCampaignDialog");
	}

	public static UI_com_IslandCampaignDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandCampaignDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085owu51", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://b3fc6085owu51".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		CampaignRecords = (GList)((GComponent)this).GetChild("CampaignRecords");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://b3fc6085owu51".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
