using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_SingleSeasonMission : GComponent
{
	public Controller State;

	public GImage back;

	public GImage n39;

	public GTextField Desc;

	public GTextField Value;

	public GImage RewardFrame1;

	public GLoader RewardIcon1;

	public GTextField RewardCount1;

	public GImage RewardFrame2;

	public GLoader RewardIcon2;

	public GTextField RewardCount2;

	public GImage mask;

	public GImage n18;

	public const string URL = "ui://82mo10n5g21rdpf";

	public static string Name = "UI_SingleSeasonMission";

	public static string GetURL()
	{
		return "ui://82mo10n5g21rdpf";
	}

	public static UI_SingleSeasonMission CreateInstance()
	{
		return (UI_SingleSeasonMission)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SingleSeasonMission");
	}

	public static UI_SingleSeasonMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SingleSeasonMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5g21rdpf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		back = (GImage)((GComponent)this).GetChild("back");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Value = (GTextField)((GComponent)this).GetChild("Value");
		RewardFrame1 = (GImage)((GComponent)this).GetChild("RewardFrame1");
		RewardIcon1 = (GLoader)((GComponent)this).GetChild("RewardIcon1");
		RewardCount1 = (GTextField)((GComponent)this).GetChild("RewardCount1");
		RewardFrame2 = (GImage)((GComponent)this).GetChild("RewardFrame2");
		RewardIcon2 = (GLoader)((GComponent)this).GetChild("RewardIcon2");
		RewardCount2 = (GTextField)((GComponent)this).GetChild("RewardCount2");
		mask = (GImage)((GComponent)this).GetChild("mask");
		n18 = (GImage)((GComponent)this).GetChild("n18");
	}
}
