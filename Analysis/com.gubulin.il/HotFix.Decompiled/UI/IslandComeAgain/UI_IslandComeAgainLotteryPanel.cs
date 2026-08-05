using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.PublicResources;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_IslandComeAgainLotteryPanel : GComponent, IUiController
{
	public Controller Type;

	public UI_mc_Bg01 Mask;

	public GLoader background;

	public UI_eff_BGLight01 n19;

	public UI_eff_BGLight02 n27;

	public UI_mc_ShelfAnimation Content;

	public UI_mc_Curtain01 n4;

	public UI_mc_Curtain02 n6;

	public UI_mc_Curtain03 n2;

	public UI_mc_Businessman Businessman;

	public UI_btn_RewardInfo CheckReward;

	public UI_btn_Page01 LastPool;

	public UI_btn_Page02 NextPool;

	public GButton backBtn;

	public GComponent CurrencyAddBtn;

	public GImage n30;

	public GTextField tip;

	public GGroup n32;

	public const string URL = "ui://k2sprg26laau4a";

	public static string Name = "UI_IslandComeAgainLotteryPanel";

	private UI_ProductionNumFloating NumFloating;

	private string CurrencyItemId = FGUIManager.Instance.IslandComeAgainActivities?[0].ScoreItem;

	private DynamicIslandComeAgainActivity activity;

	private Coroutine prizePoolUnlockCountDownCoroutine;

	private WaitForSeconds everyMinute;

	private int playReceiveIndex = -1;

	private List<IslandComeAgainPrizePool> IslandComeAgainPrizePools = new List<IslandComeAgainPrizePool>();

	private int DrawOnceCost;

	private int CurrentPoolIndex;

	public static string GetURL()
	{
		return "ui://k2sprg26laau4a";
	}

	public static UI_IslandComeAgainLotteryPanel CreateInstance()
	{
		return (UI_IslandComeAgainLotteryPanel)(object)UIPackage.CreateObject("IslandComeAgain", "IslandComeAgainLotteryPanel");
	}

	public static UI_IslandComeAgainLotteryPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainLotteryPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (UI_mc_Bg01)(object)((GComponent)this).GetChild("Mask");
		background = (GLoader)((GComponent)this).GetChild("background");
		n19 = (UI_eff_BGLight01)(object)((GComponent)this).GetChild("n19");
		n27 = (UI_eff_BGLight02)(object)((GComponent)this).GetChild("n27");
		Content = (UI_mc_ShelfAnimation)(object)((GComponent)this).GetChild("Content");
		n4 = (UI_mc_Curtain01)(object)((GComponent)this).GetChild("n4");
		n6 = (UI_mc_Curtain02)(object)((GComponent)this).GetChild("n6");
		n2 = (UI_mc_Curtain03)(object)((GComponent)this).GetChild("n2");
		Businessman = (UI_mc_Businessman)(object)((GComponent)this).GetChild("Businessman");
		CheckReward = (UI_btn_RewardInfo)(object)((GComponent)this).GetChild("CheckReward");
		LastPool = (UI_btn_Page01)(object)((GComponent)this).GetChild("LastPool");
		NextPool = (UI_btn_Page02)(object)((GComponent)this).GetChild("NextPool");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		CurrencyAddBtn = (GComponent)((GComponent)this).GetChild("CurrencyAddBtn");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://k2sprg26laau4a".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		n32 = (GGroup)((GComponent)this).GetChild("n32");
	}

	public void BeforeDestroy()
	{
		if (prizePoolUnlockCountDownCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(prizePoolUnlockCountDownCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		PrizePoolInit();
		ShowCurrency();
	}

	public void OnShow()
	{
		PrizePoolIsEmpty();
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
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)LastPool).onClick.Add(new EventCallback0(ToLastPool));
		((GObject)NextPool).onClick.Add(new EventCallback0(ToNextPool));
		((GObject)CheckReward).onClick.Add(new EventCallback0(ShowPrizePoolInfo));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<int>("ISLAND_COME_AGAIN_UPDATE_CURRNET_PRIZE_POOL", UpdateCurrentPrizePool);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnCheckRewardPanelClose);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)LastPool).onClick.Remove(new EventCallback0(ToLastPool));
		((GObject)NextPool).onClick.Remove(new EventCallback0(ToNextPool));
		((GObject)CheckReward).onClick.Remove(new EventCallback0(ShowPrizePoolInfo));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<int>("ISLAND_COME_AGAIN_UPDATE_CURRNET_PRIZE_POOL", UpdateCurrentPrizePool);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnCheckRewardPanelClose);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == CurrencyItemId)
		{
			UpdateCurrency();
			CurrencyAddBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(CurrencyAddBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
	}

	private void ShowCurrency()
	{
		UpdateCurrency();
		CurrencyAddBtn.GetChild("addButton").visible = false;
		CurrencyAddBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(CurrencyItemId);
	}

	public void UpdateCurrency()
	{
		int stock = GameManagers.Instance.StockController.GetStock(CurrencyItemId);
		((GObject)CurrencyAddBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(CurrencyItemId).ToString();
		int num = ((CurrencyAddBtn.GetChild("num").data != null) ? ((int)CurrencyAddBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, CurrencyAddBtn, stock - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		CurrencyAddBtn.GetChild("num").data = stock;
	}

	private void PrizePoolInit()
	{
		activity = FGUIManager.Instance.IslandComeAgainActivities?[0];
		if (activity != null)
		{
			IslandComeAgainPrizePools = activity.GetAllPrizePool();
			CurrencyItemId = activity.ScoreItem;
			CurrentPoolIndex = activity.GetAvailablePoolIndex();
			RenderPrizePool();
		}
	}

	private void PrizePoolIsEmpty()
	{
		if (activity != null && activity.PrizePoolIsEmpty())
		{
			End();
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainExchangeCurrencyPanel.Name, null);
		}
	}

	private void SetPrizePoolType()
	{
		int count = IslandComeAgainPrizePools.Count;
		if (CurrentPoolIndex == 0)
		{
			Type.selectedIndex = 0;
		}
		else if (CurrentPoolIndex == count - 1)
		{
			Type.selectedIndex = 2;
		}
		else
		{
			Type.selectedIndex = 1;
		}
	}

	private void RenderPrizePool()
	{
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		IslandComeAgainPrizePool islandComeAgainPrizePool = IslandComeAgainPrizePools[CurrentPoolIndex];
		DrawOnceCost = activity.TicketDrawOnce(islandComeAgainPrizePool.PoolKey.ToString());
		((GObject)Content.Content.Currency).text = $"{DrawOnceCost}";
		if (playReceiveIndex > 0)
		{
			RenderPrizeItem(playReceiveIndex, ((GComponent)Content.Content.UnlockPrizePool).GetChildAt(playReceiveIndex));
			RenderBigPrize();
			playReceiveIndex = -1;
			return;
		}
		FGUIManager.Instance.SetItemIconAndFrame(Content.Content.CurrencyIcon, CurrencyItemId, null, "", frameVisible: false);
		((GObject)Content.Content.CurrencyIcon).SetScale(0.3f, 0.3f);
		SetPrizePoolType();
		Content.Content.Type.selectedIndex = CurrentPoolIndex;
		Content.Content.Cloth01.State.selectedIndex = CurrentPoolIndex;
		Content.Content.Cloth03.State.selectedIndex = CurrentPoolIndex;
		if (islandComeAgainPrizePool.PoolIsLock(out var time))
		{
			Content.Content.State.selectedIndex = 1;
			((GObject)Content.Content.CountDown).text = time;
			if (prizePoolUnlockCountDownCoroutine == null)
			{
				everyMinute = new WaitForSeconds(60f);
				prizePoolUnlockCountDownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdatePrizePoolUnlockTime());
			}
		}
		else
		{
			Content.Content.State.selectedIndex = 0;
			Content.Content.UnlockPrizePool.itemRenderer = new ListItemRenderer(RenderPrizeItem);
			Content.Content.UnlockPrizePool.numItems = islandComeAgainPrizePool.Reward.Count;
		}
		RenderBigPrize();
	}

	private void RenderBigPrize()
	{
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		IslandComeAgainPrizePool islandComeAgainPrizePool = IslandComeAgainPrizePools[CurrentPoolIndex];
		Businessman.BigPrize.State.selectedIndex = (islandComeAgainPrizePool.BigPrizeReceived() ? 1 : 0);
		IslandComeAgainPrizePool.ItemInfo bigPrize = islandComeAgainPrizePool.GetBigPrize();
		FGUIManager.Instance.SetItemIconAndFrame(Businessman.BigPrize.BigPrizeItem.icon, bigPrize.ItemId, null, "", frameVisible: false);
		if (Item.ItemType(bigPrize.ItemId) == 10)
		{
			Businessman.BigPrize.BigPrizeItem.IconScale.selectedIndex = 1;
		}
		else if (Item.ItemType(bigPrize.ItemId) == 3)
		{
			Businessman.BigPrize.BigPrizeItem.IconScale.selectedIndex = 2;
		}
		else
		{
			Businessman.BigPrize.BigPrizeItem.IconScale.selectedIndex = 0;
		}
		((GObject)Businessman.BigPrize.BigPrizeItem.Qty).text = bigPrize.Qty.ToString();
		((GObject)Businessman.BigPrize.PrizeName).text = Item.Name(GameManagers.Instance, bigPrize.ItemId);
		((GObject)Businessman.BigPrize).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bigPrize.ItemId, 1, noCheckBtn: true);
		});
	}

	private void RenderPrizeItem(int index, GObject obj)
	{
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		if (!(obj is UI_mc_Luckdraw01 uI_mc_Luckdraw))
		{
			return;
		}
		IslandComeAgainPrizePool islandComeAgainPrizePool = IslandComeAgainPrizePools[CurrentPoolIndex];
		IslandComeAgainPrizePool.ItemInfo itemInfo;
		bool flag = islandComeAgainPrizePool.CurrentPrizeLoaderUsed(index, out itemInfo);
		uI_mc_Luckdraw.State.selectedIndex = (flag ? 1 : 0);
		if (flag && itemInfo != null)
		{
			uI_mc_Luckdraw.Content.Type.selectedIndex = ((itemInfo.Rarity > 1) ? 1 : 0);
			uI_mc_Luckdraw.Content.PrizeItem.Type.selectedIndex = uI_mc_Luckdraw.Content.Type.selectedIndex;
			FGUIManager.Instance.SetItemIconAndFrame(uI_mc_Luckdraw.Content.PrizeItem.icon, itemInfo.ItemId, null, "", frameVisible: false);
			if (Item.ItemType(itemInfo.ItemId) == 10)
			{
				uI_mc_Luckdraw.Content.PrizeItem.IconScale.selectedIndex = 1;
			}
			else if (Item.ItemType(itemInfo.ItemId) == 3)
			{
				uI_mc_Luckdraw.Content.PrizeItem.IconScale.selectedIndex = 2;
			}
			else
			{
				uI_mc_Luckdraw.Content.PrizeItem.IconScale.selectedIndex = 0;
			}
			((GObject)uI_mc_Luckdraw.Content.PrizeItem.Qty).text = itemInfo.Qty.ToString();
			((GObject)uI_mc_Luckdraw).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemInfo.ItemId, 1, noCheckBtn: true);
			});
		}
		if (flag)
		{
			uI_mc_Luckdraw.ToFront.Play();
			if (playReceiveIndex != index)
			{
				uI_mc_Luckdraw.ToFront.Stop(true, true);
			}
		}
		else
		{
			uI_mc_Luckdraw.ToBack.Play();
			uI_mc_Luckdraw.ToBack.Stop(true, true);
		}
		((GObject)uI_mc_Luckdraw).data = index;
		if (!flag)
		{
			((GObject)uI_mc_Luckdraw).onClick.Set(new EventCallback1(Draw));
		}
	}

	private IEnumerator UpdatePrizePoolUnlockTime()
	{
		while (true)
		{
			IslandComeAgainPrizePool currentPool = IslandComeAgainPrizePools[CurrentPoolIndex];
			if (currentPool.PoolIsLock(out var countdown))
			{
				((GObject)Content.Content.CountDown).text = countdown;
			}
			yield return everyMinute;
			countdown = null;
		}
	}

	private void OnCheckRewardPanelClose(string panel)
	{
		if (string.Equals(panel, UI_IslandComeAgainCheckRewardPanel.Name))
		{
			((GObject)LastPool).visible = true;
			((GObject)NextPool).visible = true;
		}
	}

	private void UpdateCurrentPrizePool(int poolIndex)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		if (poolIndex <= CurrentPoolIndex)
		{
			Content.ToLastPool.SetHook("Refresh", new TransitionHook(RenderPrizePool));
			Content.ToLastPool.Play();
		}
		else
		{
			Content.ToNextPool.SetHook("Refresh", new TransitionHook(RenderPrizePool));
			Content.ToNextPool.Play();
		}
		CurrentPoolIndex = poolIndex;
	}

	private void ToLastPool()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		CurrentPoolIndex--;
		if (CurrentPoolIndex < 0)
		{
			CurrentPoolIndex = 0;
		}
		((GObject)LastPool).touchable = false;
		((GObject)NextPool).touchable = false;
		((GObject)Content).touchable = false;
		Content.ToLastPool.SetHook("Refresh", new TransitionHook(RenderPrizePool));
		Content.ToLastPool.Play((PlayCompleteCallback)delegate
		{
			((GObject)LastPool).touchable = true;
			((GObject)NextPool).touchable = true;
			((GObject)Content).touchable = true;
		});
	}

	private void ToNextPool()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		CurrentPoolIndex++;
		if (CurrentPoolIndex > IslandComeAgainPrizePools.Count - 1)
		{
			CurrentPoolIndex = IslandComeAgainPrizePools.Count - 1;
		}
		((GObject)LastPool).touchable = false;
		((GObject)NextPool).touchable = false;
		((GObject)Content).touchable = false;
		Content.ToNextPool.SetHook("Refresh", new TransitionHook(RenderPrizePool));
		Content.ToNextPool.Play((PlayCompleteCallback)delegate
		{
			((GObject)LastPool).touchable = true;
			((GObject)NextPool).touchable = true;
			((GObject)Content).touchable = true;
		});
	}

	private void Draw(EventContext context)
	{
		EventDispatcher sender = context.sender;
		object obj = ((GObject)(((sender is GObject) ? sender : null)?)).data;
		if (obj == null)
		{
			return;
		}
		int prizePoolIndex = (int)obj;
		IslandComeAgainPrizePool currentPool = IslandComeAgainPrizePools[CurrentPoolIndex];
		ILRequestHelper<GetDynamicIslandComeAgainRewardResponse>.Request((EventContext)null, (Func<Task<GetDynamicIslandComeAgainRewardResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDynamicIslandComeAgainReward(-1L, currentPool.PoolKey, prizePoolIndex)), (Action<GetDynamicIslandComeAgainRewardResponse>)delegate(GetDynamicIslandComeAgainRewardResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<IslandComeAgainPrizePool.ItemInfo> reward = response.GetReward();
				if (reward == null)
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText296") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					StockChangeRecord[] array = new StockChangeRecord[reward.Count + 1];
					int num = 0;
					foreach (IslandComeAgainPrizePool.ItemInfo item in reward)
					{
						array[num++] = new StockChangeRecord
						{
							ItemId = item.ItemId,
							Offset = item.Qty,
							Context = 105,
							ContextValue = item.ItemId,
							Type = 1
						};
					}
					array[num] = new StockChangeRecord
					{
						ItemId = CurrencyItemId,
						Offset = -response.RealCost,
						Context = 104,
						ContextValue = CurrencyItemId,
						Type = 1
					};
					GameManagers.Instance.StockController.ReadStockChangeRecords(array);
					foreach (IslandComeAgainPrizePool.ItemInfo item2 in reward)
					{
						if (Item.ItemType(item2.ItemId) == 10)
						{
							Bonus.Get(item2.ItemId, item2.Qty).Claim(GameManagers.Instance, null, StockInContext.GvGDrawCost);
						}
					}
					currentPool.UpdateRewardInfo(reward[0], prizePoolIndex);
					IslandComeAgainPrizePools[CurrentPoolIndex] = FGUIManager.Instance.IslandComeAgainActivities?[0].UpdatePrizePool(currentPool.PoolKey, reward);
					playReceiveIndex = prizePoolIndex;
					RenderPrizePool();
					PrizePoolIsEmpty();
				}
			}
		});
	}

	private void ShowPrizePoolInfo()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainCheckRewardPanel.Name, new Dictionary<string, object> { { "CurrentPoolIndex", CurrentPoolIndex } });
		((GObject)LastPool).visible = false;
		((GObject)NextPool).visible = false;
	}
}
