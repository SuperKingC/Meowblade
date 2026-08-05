using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_InstanceZonesReward : GComponent
{
	public GImage back;

	public GList StaticRewards;

	public GTextField rewardPoints;

	public GLoader pointsIcon;

	public Transition ShowPoints;

	public const string URL = "ui://hda5vzkleqc72g";

	public static string Name = "UI_InstanceZonesReward";

	public static string GetURL()
	{
		return "ui://hda5vzkleqc72g";
	}

	public static UI_InstanceZonesReward CreateInstance()
	{
		return (UI_InstanceZonesReward)(object)UIPackage.CreateObject("GameEndPanels", "InstanceZonesReward");
	}

	public static UI_InstanceZonesReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InstanceZonesReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzkleqc72g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		StaticRewards = (GList)((GComponent)this).GetChild("StaticRewards");
		rewardPoints = (GTextField)((GComponent)this).GetChild("rewardPoints");
		string id = "ui://hda5vzkleqc72g".Replace("ui://", "") + "-" + ((GObject)rewardPoints).id;
		((GObject)rewardPoints).text = LanguagesManager.GetDesc(id);
		pointsIcon = (GLoader)((GComponent)this).GetChild("pointsIcon");
		ShowPoints = ((GComponent)this).GetTransition("ShowPoints");
	}
}
