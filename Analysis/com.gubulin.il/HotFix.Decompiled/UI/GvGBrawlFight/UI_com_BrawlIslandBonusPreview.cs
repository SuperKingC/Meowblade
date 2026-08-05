using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlIslandBonusPreview : GComponent
{
	public Controller RewardType;

	public Controller IsFinal;

	public GImage n0;

	public GImage n12;

	public UI_com_Gameplay GameplayUi;

	public UI_com_IslandRewardPreview RewardPreview;

	public UI_com_FinalRewardPreview FinalRewardPreview;

	public UI_btn_RewardType Gameplay;

	public UI_btn_RewardType FinalReward;

	public UI_btn_RewardType IslandReward;

	public GTextField n7;

	public GTextField n10;

	public GImage n14;

	public GTextField n8;

	public GGroup n15;

	public const string URL = "ui://hozu168rniiv68";

	public static string Name = "UI_com_BrawlIslandBonusPreview";

	public static string GetURL()
	{
		return "ui://hozu168rniiv68";
	}

	public static UI_com_BrawlIslandBonusPreview CreateInstance()
	{
		return (UI_com_BrawlIslandBonusPreview)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlIslandBonusPreview");
	}

	public static UI_com_BrawlIslandBonusPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlIslandBonusPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv68", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RewardType = ((GComponent)this).GetController("RewardType");
		IsFinal = ((GComponent)this).GetController("IsFinal");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		GameplayUi = (UI_com_Gameplay)(object)((GComponent)this).GetChild("GameplayUi");
		RewardPreview = (UI_com_IslandRewardPreview)(object)((GComponent)this).GetChild("RewardPreview");
		FinalRewardPreview = (UI_com_FinalRewardPreview)(object)((GComponent)this).GetChild("FinalRewardPreview");
		Gameplay = (UI_btn_RewardType)(object)((GComponent)this).GetChild("Gameplay");
		FinalReward = (UI_btn_RewardType)(object)((GComponent)this).GetChild("FinalReward");
		IslandReward = (UI_btn_RewardType)(object)((GComponent)this).GetChild("IslandReward");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://hozu168rniiv68".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://hozu168rniiv68".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id3 = "ui://hozu168rniiv68".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id3);
		n15 = (GGroup)((GComponent)this).GetChild("n15");
	}
}
