using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlIslandBonusPreview : GComponent, IUiController
{
	private class BrawlEventFinalBonusConfig
	{
		public string[] BonusFfa;

		public string[] BonusFaction;
	}

	public GGraph Mask;

	public UI_com_BrawlIslandBonusPreview PreviewUi;

	public Transition t0;

	public const string URL = "ui://hozu168rniiv67";

	public static string Name = "UI_main_BrawlIslandBonusPreview";

	private Dictionary<BrawlEventBonusType, List<IBrawlPreviewBonuses>> _bonuses;

	private const string MISSION_SUB_TYPE = "MISSION_SUB_TYPE";

	private const string REWARDS_PREVIEW = "REWARDS_PREVIEW";

	private const string IS_FINAL = "IS_FINAL";

	public static string GetURL()
	{
		return "ui://hozu168rniiv67";
	}

	public static UI_main_BrawlIslandBonusPreview CreateInstance()
	{
		return (UI_main_BrawlIslandBonusPreview)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlIslandBonusPreview");
	}

	public static UI_main_BrawlIslandBonusPreview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlIslandBonusPreview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rniiv67", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PreviewUi = (UI_com_BrawlIslandBonusPreview)(object)((GComponent)this).GetChild("PreviewUi");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public static void OpenBrawlIslandBonusPreview(BrawlPreviewBonusParams bonusParams)
	{
		GetDetailInfoByMUID(bonusParams.MUID, delegate(List<IBrawlPreviewBonuses> bonuses)
		{
			Dictionary<BrawlEventBonusType, List<IBrawlPreviewBonuses>> dictionary = new Dictionary<BrawlEventBonusType, List<IBrawlPreviewBonuses>>(3) { 
			{
				BrawlEventBonusType.BrawlEventFinal,
				bonuses
			} };
			SubTypeModel_BE brawlSubTypeData = GvG3FlagShipMissionsConfigHelper.EventMissionConfig(bonusParams.MissionConfigId).BrawlSubTypeData;
			dictionary.Add(BrawlEventBonusType.BrawlEventCamp, ConvertPreviewBonuses(brawlSubTypeData.BrawlEventCamp));
			dictionary.Add(BrawlEventBonusType.BrawlEventPlayer, ConvertPreviewBonuses(brawlSubTypeData.BrawlEventPlayer));
			GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
			{
				{ "MISSION_SUB_TYPE", bonusParams.IslandSubType },
				{ "REWARDS_PREVIEW", dictionary },
				{ "IS_FINAL", bonusParams.IsFinal }
			});
		});
	}

	private static List<IBrawlPreviewBonuses> ConvertPreviewBonuses(List<BrawlEventRankRewardsConfig> rewards)
	{
		List<IBrawlPreviewBonuses> list = new List<IBrawlPreviewBonuses>();
		foreach (BrawlEventRankRewardsConfig reward in rewards)
		{
			List<IBrawlPreviewBonusItem> list2 = new List<IBrawlPreviewBonusItem>(reward.Normal.Select((KeyValuePair<string, int> kv) => new BrawlPreviewBonusItem(kv)));
			IEnumerable<BrawlPreviewBonusItem> enumerable = reward.Extra.Select((KeyValuePair<string, int> kv) => new BrawlPreviewBonusItem(kv));
			foreach (BrawlPreviewBonusItem item2 in enumerable)
			{
				item2.SetExtra(isExtra: true);
			}
			list2.AddRange(enumerable);
			BrawlPreviewBonuses item = new BrawlPreviewBonuses(reward.Rank, list2);
			list.Add(item);
		}
		return list;
	}

	private static void GetDetailInfoByMUID(int muid, Action<List<IBrawlPreviewBonuses>> onFinished)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_GetDetailInfoByMUID
		{
			Req = new C2S_BrawlEvent_GetDetailInfoByMUID.Request
			{
				MUID = muid
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_GetDetailInfoByMUID.Response response = (C2S_BrawlEvent_GetDetailInfoByMUID.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<IBrawlPreviewBonuses> obj = ConvertRankRewardsConfigs(response.FinalRewards ?? new List<BrawlEventRankRewardsConfig_ToProtocol>());
				onFinished(obj);
			}
		});
	}

	private static List<IBrawlPreviewBonuses> ConvertRankRewardsConfigs(List<BrawlEventRankRewardsConfig_ToProtocol> configs)
	{
		List<IBrawlPreviewBonuses> list = new List<IBrawlPreviewBonuses>();
		if (configs.Count <= 0)
		{
			return list;
		}
		foreach (BrawlEventRankRewardsConfig_ToProtocol config in configs)
		{
			List<IBrawlPreviewBonusItem> bonuses = new List<IBrawlPreviewBonusItem>(config.Rewards.Select((RItem item2) => new BrawlPreviewBonusItem(item2)));
			BrawlPreviewBonuses item = new BrawlPreviewBonuses(config.Rank, bonuses);
			list.Add(item);
		}
		return list;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		int num = (int)parameters["MISSION_SUB_TYPE"];
		eGvGMode3CampMissionSubType eGvGMode3CampMissionSubType = (eGvGMode3CampMissionSubType)num;
		PreviewUi.GameplayUi.Loader.url = $"ui://GvGBrawlFight/com_Gameplay{eGvGMode3CampMissionSubType}";
		bool flag = (bool)parameters["IS_FINAL"];
		PreviewUi.IsFinal.SetSelectedIndex(flag ? 1 : 0);
		_bonuses = (Dictionary<BrawlEventBonusType, List<IBrawlPreviewBonuses>>)parameters["REWARDS_PREVIEW"];
		RenderPlayerRewardPreview();
		RenderCampRewardPreview();
		RenderFinalRewardPreview();
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderPlayerRewardPreview()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		List<IBrawlPreviewBonuses> bonuses = _bonuses[BrawlEventBonusType.BrawlEventPlayer];
		PreviewUi.RewardPreview.PlayerRankRewards.itemRenderer = new ListItemRenderer(PlayerRewardRenderer);
		PreviewUi.RewardPreview.PlayerRankRewards.numItems = bonuses.Count;
		PreviewUi.RewardPreview.PlayerRankRewards.ResizeToFit(bonuses.Count);
		void PlayerRewardRenderer(int index, GObject obj)
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			if (!(obj is UI_com_PlayerRankRewardPreview uI_com_PlayerRankRewardPreview))
			{
				throw new Exception("[UI_main_BrawlIslandBonusPreview]:RenderPlayerRewardPreview.PlayerRewardRenderer obj is not UI_com_PlayerRankRewardPreview");
			}
			IBrawlPreviewBonuses bonus = bonuses[index];
			GetRankingType(bonus, uI_com_PlayerRankRewardPreview);
			uI_com_PlayerRankRewardPreview.Items.itemRenderer = new ListItemRenderer(ItemRenderer);
			uI_com_PlayerRankRewardPreview.Items.numItems = bonus.Bonuses.Count;
			void ItemRenderer(int itemIndex, GObject itemObj)
			{
				if (!(itemObj is UI_com_Item itemUi))
				{
					throw new Exception("[UI_main_BrawlIslandBonusPreview]:RenderPlayerRewardPreview.ItemRenderer obj is not UI_com_Item");
				}
				RenderPreviewBonusItem(itemUi, bonus.Bonuses[itemIndex]);
			}
		}
	}

	private void RenderCampRewardPreview()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		List<IBrawlPreviewBonuses> bonuses = _bonuses[BrawlEventBonusType.BrawlEventCamp];
		PreviewUi.RewardPreview.CampRankRewards.itemRenderer = new ListItemRenderer(CampRewardRenderer);
		PreviewUi.RewardPreview.CampRankRewards.numItems = bonuses.Count;
		PreviewUi.RewardPreview.CampRankRewards.ResizeToFit(bonuses.Count);
		void CampRewardRenderer(int index, GObject obj)
		{
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			if (!(obj is UI_com_CampRankRewardPreview uI_com_CampRankRewardPreview))
			{
				throw new Exception("[UI_main_BrawlIslandBonusPreview]:RenderCampRewardPreview.CampRewardRenderer obj is not UI_com_CampRankRewardPreview");
			}
			IBrawlPreviewBonuses bonus = bonuses[index];
			uI_com_CampRankRewardPreview.Ranking.SetSelectedIndex(bonus.Rank[1] - 1);
			uI_com_CampRankRewardPreview.Items.itemRenderer = new ListItemRenderer(ItemRenderer);
			uI_com_CampRankRewardPreview.Items.numItems = bonus.Bonuses.Count;
			void ItemRenderer(int itemIndex, GObject itemObj)
			{
				if (!(itemObj is UI_com_Item itemUi))
				{
					throw new Exception("[UI_main_BrawlIslandBonusPreview]:RenderCampRewardPreview.ItemRenderer obj is not UI_com_Item");
				}
				RenderPreviewBonusItem(itemUi, bonus.Bonuses[itemIndex]);
			}
		}
	}

	private void RenderFinalRewardPreview()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		List<IBrawlPreviewBonuses> bonuses = _bonuses[BrawlEventBonusType.BrawlEventFinal];
		PreviewUi.FinalRewardPreview.FinalRewards.itemRenderer = new ListItemRenderer(FinalRewardRenderer);
		PreviewUi.FinalRewardPreview.FinalRewards.numItems = bonuses.Count;
		PreviewUi.FinalRewardPreview.FinalRewards.ResizeToFit(bonuses.Count);
		RenderBonusPlusPools();
		void FinalRewardRenderer(int index, GObject obj)
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			if (!(obj is UI_com_PlayerRankRewardPreview uI_com_PlayerRankRewardPreview))
			{
				throw new Exception("[UI_main_BrawlIslandBonusPreview]:RenderFinalRewardPreview.FinalRewardRenderer obj is not UI_com_PlayerRankRewardPreview");
			}
			IBrawlPreviewBonuses bonus = bonuses[index];
			GetRankingType(bonus, uI_com_PlayerRankRewardPreview);
			uI_com_PlayerRankRewardPreview.Items.itemRenderer = new ListItemRenderer(ItemRenderer);
			uI_com_PlayerRankRewardPreview.Items.numItems = bonus.Bonuses.Count;
			void ItemRenderer(int itemIndex, GObject itemObj)
			{
				if (!(itemObj is UI_com_Item itemUi))
				{
					throw new Exception("[UI_main_BrawlIslandBonusPreview]:RenderFinalRewardPreview.ItemRenderer obj is not UI_com_Item");
				}
				RenderPreviewBonusItem(itemUi, bonus.Bonuses[itemIndex]);
			}
		}
	}

	private void RenderBonusPlusPools()
	{
		BrawlEventFinalBonusConfig brawlEventFinalBonusConfig = "BrawlEventFinalBonusConfig".ToConfiguration<BrawlEventFinalBonusConfig>();
		UI_com_FinalRewardPreview finalRewardPreview = PreviewUi.FinalRewardPreview;
		RenderBonusPlusPoolRewardList(finalRewardPreview.ffaPart.rewardList, brawlEventFinalBonusConfig.BonusFfa);
		((GObject)finalRewardPreview.ffaPart).height = ((GObject)finalRewardPreview.ffaPart.bg).height;
		RenderBonusPlusPoolRewardList(finalRewardPreview.factionPart.rewardList, brawlEventFinalBonusConfig.BonusFaction);
		((GObject)finalRewardPreview.factionPart).height = ((GObject)finalRewardPreview.factionPart.bg).height;
	}

	private void RenderBonusPlusPoolRewardList(GList rewardList, string[] itemIds)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		rewardList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			string itemId = itemIds[index];
			GDEItemData itemConfig = GDMgr.Get<GDEItemData>(itemId);
			bool flag = UI_com_buff.IsSpecialBuff(itemConfig);
			UI_com_RewardsList uI_com_RewardsList = (UI_com_RewardsList)(object)item;
			uI_com_RewardsList.type.SetSelectedIndex((!flag) ? 1 : 0);
			if (!flag)
			{
				UI_btn_item02 uI_btn_item = (UI_btn_item02)(object)uI_com_RewardsList.Rewards.component;
				FGUIManager.Instance.SetItemIconAndFrame(uI_btn_item.itemIcon, itemId);
			}
			else
			{
				UI_com_buff uI_com_buff = (UI_com_buff)(object)uI_com_RewardsList.Rewards.component;
				uI_com_buff.Render(itemConfig, 0, UI_com_buff.ShowMode.None);
			}
			((GObject)uI_com_RewardsList.Rewards).onClick.Set((EventCallback0)delegate
			{
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				itemId.DisplayItemTip(hideCheckBtn: true, new ItemTipParams
				{
					ItemCount = 1,
					SkillPopupPos = new Vector2(960f, 665f)
				});
			});
		};
		int num = (rewardList.numItems = itemIds.Length);
		rewardList.ResizeToFit(num);
	}

	private static void GetRankingType(IBrawlPreviewBonuses bonuses, UI_com_PlayerRankRewardPreview ui)
	{
		int num = bonuses.Rank[0];
		int num2 = bonuses.Rank[1];
		int num3 = ((num2 != num) ? 3 : ((num2 <= 3) ? (num2 - 1) : 3));
		ui.RankingTopThree.SetSelectedIndex(num3);
		if (num3 > 2)
		{
			((GObject)ui.Ranking).text = ((num != num2) ? $"{num}~{num2}" : num2.ToString());
		}
	}

	private static void RenderPreviewBonusItem(UI_com_Item itemUi, IBrawlPreviewBonusItem item)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		FGUIManager.Instance.SetItemIconAndFrame(itemUi.Icon, item.ItemId);
		((GObject)itemUi.Num).text = item.Cnt.ShortNumberFormat();
		itemUi.IsExtra.SetSelectedIndex(item.IsExtra ? 1 : 0);
		((GObject)itemUi).data = item.ItemId;
		((GObject)itemUi).onClick.Set(new EventCallback1(DisplayItemTip));
	}

	private static void DisplayItemTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		itemId.DisplayItemTip();
	}
}
