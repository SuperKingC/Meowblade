using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_SeasonRewardPreview : GComponent
{
	public Controller Type;

	public GImage n13;

	public GLoader ExtraLargeReward;

	public GLoader LargeReward;

	public GLoader MediumReward;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GTextField title;

	public const string URL = "ui://82mo10n5x1jldd9";

	public static string Name = "UI_SeasonRewardPreview";

	public static string GetURL()
	{
		return "ui://82mo10n5x1jldd9";
	}

	public static UI_SeasonRewardPreview CreateInstance()
	{
		return (UI_SeasonRewardPreview)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SeasonRewardPreview");
	}

	public static UI_SeasonRewardPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SeasonRewardPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jldd9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		ExtraLargeReward = (GLoader)((GComponent)this).GetChild("ExtraLargeReward");
		LargeReward = (GLoader)((GComponent)this).GetChild("LargeReward");
		MediumReward = (GLoader)((GComponent)this).GetChild("MediumReward");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5x1jldd9".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}

	public void RenderReward()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		FGUIManager.Instance.SetItemIconAndFrame(ExtraLargeReward, "I40234");
		((GObject)ExtraLargeReward).data = "I40234";
		((GObject)ExtraLargeReward).onClick.Set(new EventCallback1(RewardClick));
		FGUIManager.Instance.SetItemIconAndFrame(LargeReward, "I40235");
		((GObject)LargeReward).data = "I40235";
		((GObject)LargeReward).onClick.Set(new EventCallback1(RewardClick));
		FGUIManager.Instance.SetItemIconAndFrame(MediumReward, "I40236");
		((GObject)MediumReward).data = "I40236";
		((GObject)MediumReward).onClick.Set(new EventCallback1(RewardClick));
	}

	private void RewardClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		FGUIManager.Instance.ItemTip(itemId, 1, noCheckBtn: true);
	}
}
