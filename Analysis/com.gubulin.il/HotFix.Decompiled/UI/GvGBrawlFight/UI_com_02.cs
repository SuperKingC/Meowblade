using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_com_02 : GComponent
{
	public Controller rewardType;

	public GImage n95;

	public GLoader rewardIcon;

	public GImage n96;

	public const string URL = "ui://hozu168riwm75r";

	public static string Name = "UI_com_02";

	public static string GetURL()
	{
		return "ui://hozu168riwm75r";
	}

	public static UI_com_02 CreateInstance()
	{
		return (UI_com_02)(object)UIPackage.CreateObject("GvGBrawlFight", "com_02");
	}

	public static UI_com_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168riwm75r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n95 = (GImage)((GComponent)this).GetChild("n95");
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		n96 = (GImage)((GComponent)this).GetChild("n96");
	}

	public void SetUpReward(RItem reward)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		GDEItemData itemConfig = GDMgr.Get<GDEItemData>(reward.ItemId);
		int num = (UI_com_buff.IsSpecialBuff(itemConfig) ? 1 : 0);
		rewardType.SetSelectedIndex(num);
		((GObject)rewardIcon).onClick.Set((EventCallback0)delegate
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			reward.ItemId.DisplayItemTip(hideCheckBtn: true, new ItemTipParams
			{
				ItemCount = reward.cnt,
				SkillPopupPos = new Vector2(960f, 665f)
			});
		});
		if (num == 0)
		{
			UI_btn_item uI_btn_item = (UI_btn_item)(object)rewardIcon.component;
			((GObject)uI_btn_item.rewardCount).text = reward.cnt.ToString();
			FGUIManager.Instance.SetItemIconAndFrame(uI_btn_item.itemIcon, reward.ItemId);
		}
		else
		{
			UI_com_buff uI_com_buff = (UI_com_buff)(object)rewardIcon.component;
			uI_com_buff.Render(itemConfig, reward.cnt);
		}
	}
}
