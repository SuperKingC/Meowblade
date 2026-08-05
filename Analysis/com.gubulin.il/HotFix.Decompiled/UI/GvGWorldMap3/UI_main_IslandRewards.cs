using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Tips;

namespace UI.GvGWorldMap3;

public class UI_main_IslandRewards : GComponent, IUiController
{
	public Controller Page;

	public Controller Type;

	public GGraph back;

	public UI_com_BonusInfoDialog PopUp;

	public UI_btn_RewardType MainTab;

	public UI_btn_RewardType ExtraTab;

	public const string URL = "ui://4eq8fgd2h4tpes";

	public static string Name = "UI_main_IslandRewards";

	private IslandRewardsDisplayModel _curIslandReward;

	private IslandDisplayRewardType _mainRewardType;

	private IslandDisplayRewardType _subRewardType;

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpes";
	}

	public static UI_main_IslandRewards CreateInstance()
	{
		return (UI_main_IslandRewards)(object)UIPackage.CreateObject("GvGWorldMap3", "main_IslandRewards");
	}

	public static UI_main_IslandRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpes", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Page = ((GComponent)this).GetController("Page");
		Type = ((GComponent)this).GetController("Type");
		back = (GGraph)((GComponent)this).GetChild("back");
		PopUp = (UI_com_BonusInfoDialog)(object)((GComponent)this).GetChild("PopUp");
		MainTab = (UI_btn_RewardType)(object)((GComponent)this).GetChild("MainTab");
		ExtraTab = (UI_btn_RewardType)(object)((GComponent)this).GetChild("ExtraTab");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_curIslandReward = (parameters.TryGetValue("IslandDisplayRewards", out var value) ? ((IslandRewardsDisplayModel)value) : null);
		_mainRewardType = _curIslandReward.MainReward;
		_subRewardType = _curIslandReward.RandomEventReward;
		MainTab.Type.SetSelectedIndex((int)_mainRewardType);
		bool flag = _curIslandReward.RandomEventReward != IslandDisplayRewardType.Empty;
		Type.SetSelectedIndex(flag ? 1 : 0);
		Page.SetSelectedIndex(flag ? 1 : 0);
		OnPageChanged();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		Page.onChanged.Set(new EventCallback0(OnPageChanged));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		Page.onChanged.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnPageChanged()
	{
		IslandDisplayRewardType rewardType = ((Page.selectedIndex == 1) ? _subRewardType : _mainRewardType);
		Update(rewardType);
	}

	private void Update(IslandDisplayRewardType rewardType)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		PopUp.RewardType.SetSelectedIndex((int)rewardType);
		List<IslandDisplayReward> rewards = ((_mainRewardType == rewardType) ? _curIslandReward.MainRewardList : _curIslandReward.RandomEventRewardList);
		PopUp.RankBonusList.itemRenderer = new ListItemRenderer(RenderReward);
		PopUp.RankBonusList.numItems = rewards.Count;
		void RenderReward(int index, GObject obj)
		{
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			IslandDisplayReward reward;
			if (!(obj is UI_com_RankBonusSlot uI_com_RankBonusSlot))
			{
				ILRuntimeDebug.LogError("UI_main_IslandRewards.Update.RenderReward:obj is not UI_com_RankBonusSlot");
			}
			else
			{
				reward = rewards[index];
				RenderRewardRanking(reward, uI_com_RankBonusSlot);
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_RankBonusSlot.BonusBoxItem, reward.BoxItem, null, "", frameVisible: false);
				((GObject)uI_com_RankBonusSlot.BoxName).text = Item.Name(GameManagers.Instance, reward.BoxItem);
				uI_com_RankBonusSlot.ContentList.itemRenderer = new ListItemRenderer(RenderRewardItem);
				uI_com_RankBonusSlot.ContentList.numItems = reward.Items.Count;
			}
			void RenderRewardItem(int itemIndex, GObject itemGObject)
			{
				if (!(itemGObject is UI_com_Item uI_com_Item))
				{
					ILRuntimeDebug.LogError("UI_main_IslandRewards.Update.RenderRewardItem:itemGObject is not UI_com_Item");
				}
				else
				{
					KeyValuePair<string, string> keyValuePair = reward.Items[itemIndex];
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_Item.Icon, keyValuePair.Key);
					uI_com_Item.RankingTopThree.selectedIndex = reward.DisplayRankType;
					if (keyValuePair.Value == "小概率")
					{
						uI_com_Item.NumType.selectedIndex = 1;
					}
					else if (keyValuePair.Value == "中概率")
					{
						uI_com_Item.NumType.selectedIndex = 2;
					}
					else if (keyValuePair.Value == "高概率")
					{
						uI_com_Item.NumType.selectedIndex = 3;
					}
					else if (keyValuePair.Value == "必得")
					{
						uI_com_Item.NumType.selectedIndex = 4;
					}
					else
					{
						uI_com_Item.NumType.selectedIndex = 0;
					}
					((GObject)uI_com_Item.Num).text = keyValuePair.Value;
					uI_com_Item.Icon.InitMaterialIntroductionBtn(keyValuePair.Key);
				}
			}
		}
	}

	private void RenderRewardRanking(IslandDisplayReward reward, UI_com_RankBonusSlot bonusSlot)
	{
		bonusSlot.RankingTopThree.SetSelectedIndex(reward.DisplayRankType);
		((GObject)bonusSlot.Ranking).text = ((reward.DisplayRankType > 2) ? $"{reward.MinRank}~{reward.MaxRank}" : (reward.DisplayRankType + 1).ToString());
	}
}
