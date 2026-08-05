using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using UI.SpecialActivity;
using UI.Tips;
using UnityEngine;

namespace UI.WeekActivityPass;

public class UI_main_BuyWeekActPass : GComponent, IUiController
{
	public enum PageMode
	{
		Progress,
		WeekActPass
	}

	public class PageParam
	{
		public UI_main_WeekActivityPass Parent;

		public int DefaultLevel;

		public int MaxLevel;

		public PageMode Mode;

		public BattlePassActivityPayload NormalPayload;

		public BattlePassActivityPayload AdvancedPayload;

		public BattlePassActivityPayload PremiumPayload;
	}

	public Controller ShowPageType;

	public GGraph Mask;

	public UI_com_BuyBattlePass Progress;

	public UI_com_PassContainer Pass;

	public Transition ShowSelf;

	public const string URL = "ui://11dkggb8nk8f2x";

	public static string Name = "UI_main_BuyWeekActPass";

	public const string Param = "Param";

	private PageParam _pageParam;

	private const string LevelStoreItemId = "WeeklyMoon_BattlePassScore";

	public const string LevelItemId = "MoonBattlePassGeneralScore";

	private UI_main_WeekActivityPass _parent;

	private List<Claimable> _progressClaimables = new List<Claimable>();

	private StoreItem _levelStorItem;

	private int _mgtPerStoreItem = 0;

	private int TotalMtg = 0;

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f2x";
	}

	public static UI_main_BuyWeekActPass CreateInstance()
	{
		return (UI_main_BuyWeekActPass)(object)UIPackage.CreateObject("WeekActivityPass", "main_BuyWeekActPass");
	}

	public static UI_main_BuyWeekActPass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BuyWeekActPass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShowPageType = ((GComponent)this).GetController("ShowPageType");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Progress = (UI_com_BuyBattlePass)(object)((GComponent)this).GetChild("Progress");
		Pass = (UI_com_PassContainer)(object)((GComponent)this).GetChild("Pass");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		Progress.Slider.RegisterUiEventListeners();
		Progress.Slider.OnChange = OnDragChange;
		Progress.Slider.OnLeave = OnDragLeave;
		((GObject)Progress.QuickBuyBtn).onClick.Set(new EventCallback0(OnClickQuickBuy));
		((GObject)Progress.AddBtn).onClick.Set(new EventCallback0(OnClickAdd));
		((GObject)Progress.MinusBtn).onClick.Set(new EventCallback0(OnClickMinus));
		((GObject)Progress.MaxBtn).onClick.Set(new EventCallback0(OnClickMax));
		((GObject)Pass.Advance.BuyBtn).onClick.Set(new EventCallback1(OnClickBuyAdvanced));
		((GObject)Pass.Premium.BuyBtn).onClick.Set(new EventCallback1(OnClickBuyAdvanced));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		GameManagers.Instance.Messenger.AddListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OrderShipSuccessEvent);
	}

	public void UnregisterUiEventListeners()
	{
		Progress.Slider.UnregisterUiEventListeners();
		Progress.Slider.OnChange = null;
		Progress.Slider.OnLeave = null;
		((GObject)Progress.QuickBuyBtn).onClick.Clear();
		((GObject)Progress.AddBtn).onClick.Clear();
		((GObject)Progress.MinusBtn).onClick.Clear();
		((GObject)Progress.MaxBtn).onClick.Clear();
		((GObject)Pass.Advance.BuyBtn).onClick.Clear();
		((GObject)Pass.Premium.BuyBtn).onClick.Clear();
		((GObject)Mask).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OrderShipSuccessEvent);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		PageParam pageParam = (PageParam)parameters["Param"];
		_parent = pageParam.Parent;
		_pageParam = pageParam;
		ShowPageType.SetSelectedIndex((int)pageParam.Mode);
		_levelStorItem = StoreItem.Get(GameManagers.Instance, "WeeklyMoon_BattlePassScore");
		KeyValuePair<string, float> priceAndCurrency = GetPriceAndCurrency(_levelStorItem);
		_mgtPerStoreItem = (int)priceAndCurrency.Value;
		TotalMtg = GameManagers.Instance.StockController.GetStock(priceAndCurrency.Key);
		bool flag = GameManagers.Instance.StockController.GetStock(_pageParam.AdvancedPayload.PaidCert) > 0;
		bool flag2 = GameManagers.Instance.StockController.GetStock(_pageParam.PremiumPayload.PaidCert) > 0;
		Pass.Advance.Activation.SetSelectedIndex(flag ? 1 : 0);
		Pass.Premium.Activation.SetSelectedIndex(flag2 ? 1 : 0);
		((GObject)Pass.Advance.BuyBtn).enabled = !flag;
		((GObject)Pass.Premium.BuyBtn).enabled = !flag2;
		Progress.LevelIcon.url = UiHelper.GetItemIconPath(_pageParam.NormalPayload.ScoreItem);
		Progress.BuyLevelIcon.url = UiHelper.GetItemIconPath(_pageParam.NormalPayload.ScoreItem);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		RenderClaimableList();
	}

	private void RenderClaimableList()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		if (_pageParam.Mode == PageMode.WeekActPass)
		{
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, CertItemId(BattlePassType.Advanced));
			RenderBuyInfo(Pass.Advance, storeItem);
			List<Claimable> claimableList = new List<Claimable>();
			Pass.Advance.ClaimableList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
			{
				//IL_007a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0084: Expected O, but got Unknown
				Claimable claimable = claimableList[index];
				UI_btn_ClaimableSlot uI_btn_ClaimableSlot = (UI_btn_ClaimableSlot)(object)obj;
				((GObject)uI_btn_ClaimableSlot.num).text = claimable.num.ToString();
				FGUIManager.Instance.SetItemIconAndFrame(uI_btn_ClaimableSlot.Icon, claimable.id);
				((GObject)uI_btn_ClaimableSlot).onClick.Set((EventCallback0)delegate
				{
					OnClickSlot(claimable.id);
				});
			};
			GetUnlockByPass(claimableList, Pass.Advance.ClaimableList, advance: true, premium: false);
			StoreItem storeItem2 = StoreItem.Get(GameManagers.Instance, CertItemId(BattlePassType.Premium));
			RenderBuyInfo(Pass.Premium, storeItem2);
			List<Claimable> claimableList2 = new List<Claimable>();
			Pass.Premium.ClaimableList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
			{
				//IL_007a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0084: Expected O, but got Unknown
				Claimable claimable = claimableList2[index];
				UI_btn_ClaimableSlot uI_btn_ClaimableSlot = (UI_btn_ClaimableSlot)(object)obj;
				((GObject)uI_btn_ClaimableSlot.num).text = claimable.num.ToString();
				FGUIManager.Instance.SetItemIconAndFrame(uI_btn_ClaimableSlot.Icon, claimable.id);
				((GObject)uI_btn_ClaimableSlot).onClick.Set((EventCallback0)delegate
				{
					OnClickSlot(claimable.id);
				});
			};
			GetUnlockByPass(claimableList2, Pass.Premium.ClaimableList, advance: false, premium: true);
		}
		else if (_pageParam.Mode == PageMode.Progress)
		{
			int num = _pageParam.DefaultLevel;
			int curLevel = _parent.CurLevel;
			if (num == -1)
			{
				num = GetNextSpecialLevel(curLevel);
			}
			((GObject)Progress.LevelNum).text = num.ToString();
			int max = Mathf.Max(_pageParam.MaxLevel - curLevel, 2);
			int value = num - curLevel;
			int step = 1;
			Progress.Slider.Init(1, max, value, step, 19f);
			Progress.ClaimableList.SetVirtual();
			Progress.ClaimableList.itemRenderer = new ListItemRenderer(ItemRenderer);
			OnDragLeave();
		}
	}

	private int GetNextSpecialLevel(int curLevel)
	{
		foreach (SlotData item in _parent.SpecialReward)
		{
			if (curLevel < item.Level)
			{
				return item.Level;
			}
		}
		return _pageParam.MaxLevel;
	}

	private void RenderBuyInfo(UI_com_BuyPassSmall page, StoreItem storeItem)
	{
		KeyValuePair<string, float> availablePriceItemId = UI_SpecialActivityPanel.GetAvailablePriceItemId(storeItem);
		string key = availablePriceItemId.Key;
		string text = $"{Convert.ToInt32(availablePriceItemId.Value)}";
		bool flag = key == "RMB";
		ProductLocalInfo value = null;
		((GObject)page.BuyBtn.priceGroup).visible = true;
		((GObject)page.BuyBtn.curIntlPriceText).visible = false;
		bool isRegionOutCN = HotUpdateProcess.Instance.IsRegionOutCN;
		if (isRegionOutCN && flag)
		{
			((GObject)page.BuyBtn.priceGroup).visible = false;
			((GObject)page.BuyBtn.curIntlPriceText).visible = true;
			text = ((!PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value)) ? "--" : value.FormattedPrice);
		}
		FGUIManager.Instance.GetCurrencySymbol(key, page.BuyBtn.Currency, null);
		((GObject)page.BuyBtn.Price).text = text;
		((GObject)page.BuyBtn.curIntlPriceText).text = text;
		((GObject)page.BuyBtn).data = storeItem;
	}

	private string CertItemId(BattlePassType type)
	{
		return type switch
		{
			BattlePassType.Advanced => "WeeklyMoon_BattlePass_AdvancedPaidCert", 
			BattlePassType.Premium => "WeeklyMoon_BattlePass_PremiumPaidCert", 
			_ => string.Empty, 
		};
	}

	private void GetClaimable(int level)
	{
		GetClaimableCoroutine(level, _progressClaimables, Progress.ClaimableList);
	}

	private void GetClaimableCoroutine(int targetLevel, List<Claimable> cacheList, GList viewList)
	{
		viewList.numItems = 0;
		cacheList.Clear();
		Dictionary<string, Claimable> dictionary = new Dictionary<string, Claimable>();
		Dictionary<string, Claimable> dictionary2 = new Dictionary<string, Claimable>();
		List<SlotData> rewardData = _parent.RewardData;
		for (int num = rewardData.Count - 1; num >= 0; num--)
		{
			SlotData slotData = rewardData[num];
			if (targetLevel <= 0 || slotData.Level <= targetLevel)
			{
				if (slotData.num_basic > 0 && slotData.state_basic != BonusStatus.CLAIMED)
				{
					AddClaimable(_pageParam.NormalPayload.SpecialBonus, dictionary, dictionary2, slotData.num_basic, slotData.id_basic);
				}
				if (_parent.AdvanceActivated && slotData.num_advanced > 0 && slotData.state_advanced != BonusStatus.CLAIMED)
				{
					AddClaimable(_pageParam.AdvancedPayload.SpecialBonus, dictionary, dictionary2, slotData.num_advanced, slotData.id_advanced);
				}
				if (_parent.PremiumActivated && slotData.num_premium > 0 && slotData.state_premium != BonusStatus.CLAIMED)
				{
					AddClaimable(_pageParam.PremiumPayload.SpecialBonus, dictionary, dictionary2, slotData.num_premium, slotData.id_premium);
				}
			}
		}
		cacheList.AddRange(dictionary.Values);
		cacheList.AddRange(dictionary2.Values);
		if (cacheList.Count == 2 && cacheList[0].id == "Money")
		{
			Claimable value = cacheList[1];
			Claimable value2 = cacheList[0];
			cacheList[0] = value;
			cacheList[1] = value2;
		}
		viewList.numItems = cacheList.Count;
	}

	private void GetUnlockByPass(List<Claimable> cacheList, GList viewList, bool advance, bool premium)
	{
		viewList.numItems = 0;
		cacheList.Clear();
		Dictionary<string, Claimable> dictionary = new Dictionary<string, Claimable>();
		Dictionary<string, Claimable> dictionary2 = new Dictionary<string, Claimable>();
		List<SlotData> rewardData = _parent.RewardData;
		for (int num = rewardData.Count - 1; num >= 0; num--)
		{
			SlotData slotData = rewardData[num];
			if (advance && slotData.num_advanced > 0)
			{
				AddClaimable(_pageParam.AdvancedPayload.SpecialBonus, dictionary, dictionary2, slotData.num_advanced, slotData.id_advanced);
			}
			if (premium && slotData.num_premium > 0)
			{
				AddClaimable(_pageParam.PremiumPayload.SpecialBonus, dictionary, dictionary2, slotData.num_premium, slotData.id_premium);
			}
		}
		List<Claimable> collection = new List<Claimable>();
		if (advance)
		{
			collection = SortReward(dictionary, _pageParam.AdvancedPayload.SpecialBonus);
		}
		else if (premium)
		{
			collection = SortReward(dictionary, _pageParam.PremiumPayload.SpecialBonus);
		}
		cacheList.AddRange(collection);
		cacheList.AddRange(dictionary2.Values);
		viewList.numItems = cacheList.Count;
	}

	private List<Claimable> SortReward(Dictionary<string, Claimable> rewardsDict, List<string> sortList)
	{
		List<Claimable> list = new List<Claimable>();
		foreach (string sort in sortList)
		{
			if (rewardsDict.TryGetValue(sort, out var value))
			{
				list.Add(value);
			}
		}
		return list;
	}

	private static void AddClaimable(List<string> bonus, Dictionary<string, Claimable> sp, Dictionary<string, Claimable> norm, int num, string itemId)
	{
		Claimable value = new Claimable
		{
			num = num,
			id = itemId
		};
		Claimable value3;
		if (bonus.Contains(itemId))
		{
			if (sp.TryGetValue(itemId, out var value2))
			{
				value2.num += num;
			}
			else
			{
				sp.Add(itemId, value);
			}
		}
		else if (norm.TryGetValue(itemId, out value3))
		{
			value3.num += num;
		}
		else
		{
			norm.Add(itemId, value);
		}
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		if (!((GObject)this).isDisposed)
		{
			Claimable claimable = _progressClaimables[index];
			UI_btn_ClaimableSlot uI_btn_ClaimableSlot = (UI_btn_ClaimableSlot)(object)obj;
			((GObject)uI_btn_ClaimableSlot.num).text = claimable.num.ToString();
			FGUIManager.Instance.SetItemIconAndFrame(uI_btn_ClaimableSlot.Icon, claimable.id);
			((GObject)uI_btn_ClaimableSlot).onClick.Set((EventCallback0)delegate
			{
				OnClickSlot(claimable.id);
			});
		}
	}

	private void UpdateBuyQuantityAndMtg()
	{
		int curLevel = _parent.CurLevel;
		int num = Mathf.Min(curLevel + Progress.Slider.Value, _pageParam.MaxLevel);
		int num2 = Mathf.Max(0, num - curLevel);
		((GObject)Progress.LevelNum).text = num.ToString();
		((GObject)Progress.Score).text = num2.ToString();
		int value = 1;
		_levelStorItem.Content.TryGetValue("MoonBattlePassGeneralScore", out value);
		int num3 = Mathf.CeilToInt(1f * (float)num2 / (float)value);
		int num4 = _mgtPerStoreItem * num3;
		string text = ((num4 > TotalMtg) ? "#ff0000" : "#9CF240");
		((GObject)Progress.QuickBuyText).text = string.Format("[color={0}]{1}[/color][color={2}]/[/color][color={3}]{4}[/color]", text, num4, "#9CF240", text, TotalMtg);
		((GObject)Progress.QuickBuyBtn).enabled = num2 > 0;
	}

	private void OnClickSlot(string id)
	{
		FGUIManager.Instance.ItemTip(id, ((GObject)this).sortingOrder, noCheckBtn: true);
	}

	private void OnClickBuyAdvanced(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		StoreItem storeItem = (StoreItem)((GObject)context.sender).data;
		ProductLocalInfo value = null;
		if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(storeItem.ReferenceId))
		{
			PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value);
		}
		PurchaseManager.Instance.InvokePurchase(storeItem, value, 1, (Action)null, doubleCheck: true);
	}

	private void OrderShipSuccessEvent(string storeItemId)
	{
		if ("WeeklyMoon_BattlePassScore" == storeItemId)
		{
			CacheManager.Instance.Get<Cache_WeekActPassScore>().IsSyncProduce = true;
		}
		else
		{
			_parent.UpdateRewardList();
		}
		End();
	}

	private void OnClickQuickBuy()
	{
		int curLevel = _parent.CurLevel;
		int num = Mathf.Min(curLevel + Progress.Slider.Value, _pageParam.MaxLevel);
		int num2 = num - curLevel;
		int value = 1;
		_levelStorItem.Content.TryGetValue("MoonBattlePassGeneralScore", out value);
		int num3 = Mathf.CeilToInt(1f * (float)num2 / (float)value);
		int num4 = _mgtPerStoreItem * num3;
		if (num4 > TotalMtg)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					"[color=#FFFF66]" + LanguagesManager.GetDesc("CsharpCodeZhTcText838") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText839") + "?[/color]"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								_parent.OnClickMTGBtn();
							}
						},
						{ "Cancel", null }
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else
		{
			ProductLocalInfo value2 = null;
			if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(_levelStorItem.ReferenceId))
			{
				PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(_levelStorItem.ReferenceId, out value2);
			}
			PurchaseManager.Instance.InvokePurchase(_levelStorItem, value2, num3, (Action)null, doubleCheck: true);
		}
	}

	private void OnDragChange()
	{
		UpdateBuyQuantityAndMtg();
	}

	private void OnDragLeave()
	{
		int curLevel = _parent.CurLevel;
		int level = Mathf.Min(curLevel + Progress.Slider.Value, _pageParam.MaxLevel);
		((GObject)Progress.LevelNum).text = level.ToString();
		GetClaimable(level);
	}

	private void OnClickAdd()
	{
		Progress.Slider.Value++;
		OnDragLeave();
	}

	private void OnClickMinus()
	{
		Progress.Slider.Value--;
		OnDragLeave();
	}

	private void OnClickMax()
	{
		Progress.Slider.ToMax();
		OnDragLeave();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void Destroy()
	{
	}

	private KeyValuePair<string, float> GetPriceAndCurrency(StoreItem storeItem)
	{
		foreach (Dictionary<string, float> item in storeItem.Price)
		{
			Dictionary<string, float>.Enumerator enumerator2 = item.GetEnumerator();
			enumerator2.MoveNext();
			KeyValuePair<string, float> current2 = enumerator2.Current;
			string key = current2.Key;
			float value = current2.Value;
			if (!key.Equals("RMB"))
			{
				return current2;
			}
		}
		return default(KeyValuePair<string, float>);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}
}
