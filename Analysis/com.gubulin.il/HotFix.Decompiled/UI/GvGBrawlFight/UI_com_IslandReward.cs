using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGBrawlFight;

public class UI_com_IslandReward : GComponent
{
	public Controller rewardType;

	public GImage n10;

	public GImage n12;

	public GLoader rewardIcon;

	public const string URL = "ui://hozu168r9ykh6i";

	public static string Name = "UI_com_IslandReward";

	public static string GetURL()
	{
		return "ui://hozu168r9ykh6i";
	}

	public static UI_com_IslandReward CreateInstance()
	{
		return (UI_com_IslandReward)(object)UIPackage.CreateObject("GvGBrawlFight", "com_IslandReward");
	}

	public static UI_com_IslandReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r9ykh6i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		rewardType = ((GComponent)this).GetController("rewardType");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
	}

	public void SetUpReward(IEvent_Brawl_Icon reward, GDEItemData itemConfig)
	{
		int num = (UI_com_buff.IsSpecialBuff(itemConfig) ? 1 : 0);
		rewardType.SetSelectedIndex(num);
		if (num == 0)
		{
			UI_btn_item uI_btn_item = (UI_btn_item)(object)rewardIcon.component;
			((GObject)uI_btn_item.rewardCount).text = reward.Cnt.ToString();
			FGUIManager.Instance.SetItemIconAndFrame(uI_btn_item.itemIcon, reward.ItemId);
		}
		else
		{
			UI_com_buff uI_com_buff = (UI_com_buff)(object)rewardIcon.component;
			uI_com_buff.Render(itemConfig, reward.Cnt);
		}
	}
}
