using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Rank.Helpers;
using UI.Tips;
using UnityEngine;

namespace UI.ReturningRewards;

public class UI_main_ReturningRewards : GComponent, IUiController
{
	public Controller RewardClaimed;

	public GLoader background;

	public GGraph n1;

	public GImage n17;

	public GImage n19;

	public GImage n20;

	public GImage n21;

	public GImage n16;

	public GImage n26;

	public GTextField n27;

	public GImage n23;

	public GImage n24;

	public GGroup n25;

	public GImage n29;

	public GButton backBtn;

	public UI_com_Title Title;

	public UI_com_Back ListBack;

	public UI_com_Instruction Instruction;

	public UI_btn_GerMore GetMore;

	public UI_com_ReturningScore RetruningScore;

	public UI_btn_RewardsPreview RewardsPreview;

	public UI_btn_MIssions Missions;

	public UI_com_ActivityCountdown Countdown;

	public UI_com_ExchangeMoney ExchangeMoney;

	public UI_com_PrizePool PrizePool;

	public GLoader flyAnim;

	public UI_btn_Help Help;

	public Transition Hold;

	public const string URL = "ui://rx5ntv98win2c";

	public static string Name = "UI_main_ReturningRewards";

	public const string ConfirmYellowUrl = "ui://Tips/艺术字-确认黄-text";

	private const string RECALL_WELFARE_PREVIEW_REWARD_CHECKED = "RecallwelfarePreviewRewardChecked";

	private const string RECALL_WELFARE_UI_PARAMS = "RecallWelfareUiParams";

	private const string RECALL_WELFARE_REWARDS_TITLE = "RecallWelfareRewardsTitle";

	private const int DRAW_CARD_COST = 10;

	private const int RECALL_WELFARE_DRAW_NOT_ENOUGH_SCORE = 81200086;

	private RecallWelfareUiParams _params;

	private List<UI_btn_RewardSlot> _slots;

	private Dictionary<int, LongPressGesture> _gestures = new Dictionary<int, LongPressGesture>();

	private ActivityManager Manager => GameManagers.Instance.ActivityManager;

	public static string GetURL()
	{
		return "ui://rx5ntv98win2c";
	}

	public static UI_main_ReturningRewards CreateInstance()
	{
		return (UI_main_ReturningRewards)(object)UIPackage.CreateObject("ReturningRewards", "main_ReturningRewards");
	}

	public static UI_main_ReturningRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ReturningRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RewardClaimed = ((GComponent)this).GetController("RewardClaimed");
		background = (GLoader)((GComponent)this).GetChild("background");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id = "ui://rx5ntv98win2c".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id);
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GGroup)((GComponent)this).GetChild("n25");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		ListBack = (UI_com_Back)(object)((GComponent)this).GetChild("ListBack");
		Instruction = (UI_com_Instruction)(object)((GComponent)this).GetChild("Instruction");
		GetMore = (UI_btn_GerMore)(object)((GComponent)this).GetChild("GetMore");
		RetruningScore = (UI_com_ReturningScore)(object)((GComponent)this).GetChild("RetruningScore");
		RewardsPreview = (UI_btn_RewardsPreview)(object)((GComponent)this).GetChild("RewardsPreview");
		Missions = (UI_btn_MIssions)(object)((GComponent)this).GetChild("Missions");
		Countdown = (UI_com_ActivityCountdown)(object)((GComponent)this).GetChild("Countdown");
		ExchangeMoney = (UI_com_ExchangeMoney)(object)((GComponent)this).GetChild("ExchangeMoney");
		PrizePool = (UI_com_PrizePool)(object)((GComponent)this).GetChild("PrizePool");
		flyAnim = (GLoader)((GComponent)this).GetChild("flyAnim");
		Help = (UI_btn_Help)(object)((GComponent)this).GetChild("Help");
		Hold = ((GComponent)this).GetTransition("Hold");
	}

	public static void Open(RecallWelfareUiParams parameters)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object> { { "RecallWelfareUiParams", parameters } });
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)backBtn).onClick.Set(new EventCallback0(End));
		((GObject)RewardsPreview).onClick.Set(new EventCallback1(OnRewardsPreviewClick));
		((GObject)Missions).onClick.Set(new EventCallback0(OnMissionsClick));
		((GObject)Help).onClick.Set(new EventCallback1(OnHelpClick));
		ExchangeMoney.RegisterEvent();
		GetMore.Register();
		Manager.AddOnTotalScoreChanged(UpdateScore);
		SharedMessenger.AddListener<Cache_RecallWelfare_RedDot>("ON_RECALL_WELFARE_MISSION_PROGRESS_CHANGED", OnRecallWelfareRedDotChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)backBtn).onClick.Clear();
		((GObject)RewardsPreview).onClick.Clear();
		((GObject)Missions).onClick.Clear();
		((GObject)Help).onClick.Clear();
		ExchangeMoney.UnregisterEvent();
		GetMore.Unregister();
		Manager.RemoveOnTotalScoreChanged(UpdateScore);
		SharedMessenger.RemoveListener<Cache_RecallWelfare_RedDot>("ON_RECALL_WELFARE_MISSION_PROGRESS_CHANGED", OnRecallWelfareRedDotChange);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (!parameters.TryGetValue("RecallWelfareUiParams", out var value))
		{
			throw new Exception("UI_main_ReturningRewards parameters is null");
		}
		_params = (RecallWelfareUiParams)value;
		ExchangeMoney.Init(_params.Money);
		UpdateRewardClaimedStatus();
		UpdateScore(_params.TotalScore);
		_slots = LoadAllSlots();
	}

	public void OnShow()
	{
		Countdown.OnShow(_params.EndTimestamp);
		RenderAllSlots();
		OnRecallWelfareRedDotChange(CacheManager.Instance.Get<Cache_RecallWelfare_RedDot>());
		TryOpenRewardPreview();
	}

	public void BeforeDestroy()
	{
		Countdown.BeforeDestroy();
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void UpdateRewardClaimedStatus()
	{
		RewardClaimed.SetSelectedIndex(_params.AllRewardsClaimed ? 1 : 0);
	}

	private void UpdateScore(int score)
	{
		_params.TotalScore = score;
		ExchangeMoney.UpdateScore(score);
		RetruningScore.Update(score);
	}

	private void OnRecallWelfareRedDotChange(Cache_RecallWelfare_RedDot cache)
	{
		Missions.Claimeable.SetSelectedIndex(cache.IsShowRedDot ? 1 : 0);
	}

	private void OnRewardsPreviewClick(EventContext context)
	{
		OnRewardsPreviewClick();
	}

	private static void OnHelpClick(EventContext context)
	{
		UI_main_ReturningInstructions.Open();
	}

	private void OnRewardsPreviewClick(bool isFirst = false)
	{
		RecallWelfarePreviewParams recallWelfarePreviewParams = Manager.CreatePreviewParams();
		recallWelfarePreviewParams.IsFirst = isFirst;
		if (isFirst)
		{
			recallWelfarePreviewParams.OnFirstChecked = PlayRewardsFly;
		}
		UI_main_ReturningRewardsPreview.Open(recallWelfarePreviewParams);
	}

	private void OnMissionsClick()
	{
		List<IRecallWelfareMission> missions = Manager.CreateMissions();
		UI_main_ReturningMissions.Open(missions);
	}

	private void TryOpenRewardPreview()
	{
		string key = string.Format("{0}_{1}", "RecallwelfarePreviewRewardChecked", _params.EndTimestamp);
		bool flag;
		if (!GameLocalDataManager.HasKey(key))
		{
			GameLocalDataManager.SetBool(key, value: true);
			flag = false;
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			OnRewardsPreviewClick(isFirst: true);
		}
	}

	private List<UI_btn_RewardSlot> LoadAllSlots()
	{
		List<UI_btn_RewardSlot> list = new List<UI_btn_RewardSlot>();
		for (int i = 0; i < ((GComponent)PrizePool.Prizes).numChildren; i++)
		{
			UI_btn_RewardSlot uI_btn_RewardSlot = (UI_btn_RewardSlot)(object)((GComponent)PrizePool.Prizes).GetChildAt(i);
			if (uI_btn_RewardSlot.IsCard.selectedIndex == 0)
			{
				list.Add(uI_btn_RewardSlot);
			}
		}
		return list;
	}

	private void RenderAllSlots()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		if (RewardClaimed.selectedIndex == 1)
		{
			return;
		}
		for (int i = 0; i < _slots.Count; i++)
		{
			UI_btn_RewardSlot uI_btn_RewardSlot = _slots[i];
			((GObject)uI_btn_RewardSlot).data = i;
			((GObject)uI_btn_RewardSlot).onClick.Set(new EventCallback1(OnSlotClick));
			if (i >= _params.PrizesCount)
			{
				((GObject)uI_btn_RewardSlot).enabled = false;
				continue;
			}
			UI_mc_Luckdraw01 card = uI_btn_RewardSlot.Card;
			if (!_params.DrawedPrizes.TryGetValue(i, out var value))
			{
				card.State.SetSelectedIndex(0);
				card.ToBack.Play();
				card.ToBack.Stop(true, true);
				((GObject)card).data = i;
				_gestures[i] = CreateLongPressGesture((GComponent)(object)card);
			}
			else
			{
				card.State.SetSelectedIndex(1);
				FGUIManager.Instance.SetItemIconAndFrame(card.Content.icon, value.ItemId, null, "", frameVisible: false);
				((GObject)card.Content.Qty).text = $"x{value.Qty}";
				card.Content.Type.SetSelectedIndex(value.Rarity);
				card.ToFront.Play();
				card.ToFront.Stop(true, true);
			}
		}
	}

	private void OnSlotClick(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		int num = (int)((GObject)context.sender).data;
		UI_btn_RewardSlot uI_btn_RewardSlot = _slots[num];
		if (uI_btn_RewardSlot.Card.State.selectedIndex == 1 && _params.DrawedPrizes.TryGetValue(num, out var value))
		{
			value.ItemId.DisplayItemTip();
			return;
		}
		if (_params.TotalScore < 10)
		{
			ILRequestHelper.ShowErrorCode(81200086);
			return;
		}
		DrawCards(new List<int> { num });
	}

	private void DrawCards(List<int> ids)
	{
		Manager.DrawRecallWelfare(ids, OnDrawCards, OnStockChanged);
	}

	private void OnDrawCards(Dictionary<int, IRecallWelfarePrize> prizes)
	{
		foreach (int key in prizes.Keys)
		{
			_params.DrawedPrizes[key] = prizes[key];
		}
		foreach (int key2 in prizes.Keys)
		{
			if (_gestures.TryGetValue(key2, out var value))
			{
				value.Dispose();
			}
		}
		UpdateCards(prizes);
	}

	private void OnStockChanged(List<StockChangeRecord> changeRecords)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		((GComponent)(object)PrizePool).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			List<Bonus> bonusList = changeRecords.Select((StockChangeRecord scr) => Bonus.Get(scr.ItemId, scr.Offset)).ToList();
			OpenTakeItemsPanelForPack("RecallWelfareRewardsTitle".ToLanguage(), bonusList, DisplayTips);
		});
		void DisplayTips()
		{
			changeRecords.DisplayStockChangedRecords();
		}
	}

	private static void OpenTakeItemsPanelForPack(string rewardsTitle, List<Bonus> bonusList, Action onConfirm = null)
	{
		if (bonusList.Count <= 4)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Name", rewardsTitle },
				{ "Items", bonusList },
				{ "ShowBox", true },
				{ "ResultList", bonusList },
				{ "ConfirmBtnTitle", "ui://Tips/艺术字-确认黄-text" },
				{ "ConfirmAction", onConfirm }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, parameters);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ShowOfflineEarnings.Name, new Dictionary<string, object>
			{
				{ "Bonus", bonusList },
				{ "Time", 0 },
				{ "Status", 2 },
				{ "Title", rewardsTitle },
				{ "ConfirmAction", onConfirm },
				{ "ExitButtonVisible", false }
			});
		}
	}

	private void UpdateCards(Dictionary<int, IRecallWelfarePrize> prizes)
	{
		foreach (KeyValuePair<int, IRecallWelfarePrize> prize in prizes)
		{
			IRecallWelfarePrize value = prize.Value;
			UI_mc_Luckdraw01 card = _slots[prize.Key].Card;
			card.State.SetSelectedIndex(1);
			FGUIManager.Instance.SetItemIconAndFrame(card.Content.icon, value.ItemId, null, "", frameVisible: false);
			((GObject)card.Content.Qty).text = $"x{value.Qty}";
			card.Content.Type.SetSelectedIndex(value.Rarity);
			card.ToFront.Play();
		}
	}

	private LongPressGesture CreateLongPressGesture(GComponent target)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		LongPressGesture val = new LongPressGesture((GObject)(object)target)
		{
			trigger = 0f,
			interval = 0.03f,
			once = false
		};
		val.onBegin.Set(new EventCallback1(OnLongPressBegin));
		val.onAction.Set(new EventCallback1(OnLongPressAction));
		val.onEnd.Set(new EventCallback1(OnLongPressEnd));
		return val;
	}

	private void OnLongPressBegin(EventContext context)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Vector2 xy = ((GObject)PrizePool).GlobalToLocal(new Vector2(context.inputEvent.x, context.inputEvent.y));
		((GObject)PrizePool.Circle).xy = xy;
		((GProgressBar)PrizePool.Circle).value = 0.0;
	}

	private void OnLongPressAction(EventContext context)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		UI_com_Circle circle = PrizePool.Circle;
		((GProgressBar)circle).value = ((GProgressBar)circle).value + 2.0;
		if (((GProgressBar)PrizePool.Circle).value >= 10.0)
		{
			Stage.inst.CancelClick(context.inputEvent.touchId);
			PrizePool.IsLongPress.SetSelectedIndex(1);
		}
		if (((GProgressBar)PrizePool.Circle).value >= ((GProgressBar)PrizePool.Circle).max)
		{
			LongPressGesture val = (LongPressGesture)context.sender;
			int index = (int)val.host.data;
			val.Cancel();
			PrizePool.IsLongPress.SetSelectedIndex(0);
			LongPressDraw(index);
		}
	}

	private void OnLongPressEnd(EventContext context)
	{
		PrizePool.IsLongPress.SetSelectedIndex(0);
	}

	private void LongPressDraw(int index)
	{
		if (_params.TotalScore < 10)
		{
			ILRequestHelper.ShowErrorCode(81200086);
			return;
		}
		List<int> ids = CreateRandomIds(index);
		DrawCards(ids);
	}

	private List<int> CreateRandomIds(int index)
	{
		List<int> list = new List<int> { index };
		List<int> canDrawIds = GetCanDrawIds(index);
		int n = (_params.TotalScore - 10) / 10;
		list.AddRange(canDrawIds.Choose(n));
		return list;
	}

	private List<int> GetCanDrawIds(int clickIndex)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < _slots.Count; i++)
		{
			if (i < _params.PrizesCount && !_params.DrawedPrizes.ContainsKey(i) && clickIndex != i)
			{
				list.Add(i);
			}
		}
		return list;
	}

	private void PlayRewardsFly()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		List<PreviewRewardEffect> list = new List<PreviewRewardEffect>();
		for (int i = 0; i < ((GComponent)PrizePool.Prizes).numChildren; i++)
		{
			UI_btn_RewardSlot uI_btn_RewardSlot = (UI_btn_RewardSlot)(object)((GComponent)PrizePool.Prizes).GetChildAt(i);
			if (uI_btn_RewardSlot.IsCard.selectedIndex != 1)
			{
				Vector2 val = ((GObject)uI_btn_RewardSlot).LocalToRoot(new Vector2(((GObject)uI_btn_RewardSlot).width, ((GObject)uI_btn_RewardSlot).height) / 2f, GRoot.inst);
				list.Add(new PreviewRewardEffect
				{
					X = val.x,
					Y = val.y
				});
			}
		}
		UI_main_ReturningFirstTimeFX.Open(list);
	}
}
