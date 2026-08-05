using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BattlePass;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.PaymentOptions;
using UI.Tips;
using UnityEngine;

namespace UI.GvGBattlePass3;

public class UI_main_BuyBattlePass : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BuyBattlePass Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://bfjg32huq1eq3e";

	public static string Name = "UI_main_BuyBattlePass";

	private UI_main_GvG3BattlePass _battlePassMainUi;

	private int _mode = 0;

	private List<Claimable> ClaimableData = new List<Claimable>();

	private StoreItem LevelStorItem;

	private int ContributionPointPrice = 0;

	private int TotalMtg = 0;

	private const string LevelStoreItemId = "GvG3BattlePassScore";

	private Coroutine GetClaimableHandler = null;

	private bool _isShowAdvanced = false;

	private bool _premiumActivated = false;

	private GvG3BattlePassManager.ConfigData _config;

	private static readonly Dictionary<int, bool> _buyBtnClicked = new Dictionary<int, bool>(2);

	public bool IsIzInSettlement => Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement;

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq3e";
	}

	public static UI_main_BuyBattlePass CreateInstance()
	{
		return (UI_main_BuyBattlePass)(object)UIPackage.CreateObject("GvGBattlePass3", "main_BuyBattlePass");
	}

	public static UI_main_BuyBattlePass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BuyBattlePass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_BuyBattlePass)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	private static bool BuyBtnEnabled(int mode)
	{
		bool value;
		return !_buyBtnClicked.TryGetValue(mode, out value) || !value;
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
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		Dialog.Slider.RegisterUiEventListeners();
		Dialog.Slider.OnChange = OnDragChange;
		Dialog.Slider.OnLeave = OnDragLeave;
		((GObject)Dialog.BuyBtn).onClick.Set(new EventCallback0(OnClickBuyAdvanced));
		((GObject)Dialog.QuickBuyBtn).onClick.Set(new EventCallback0(OnClickQuickBuy));
		((GObject)Dialog.AddBtn).onClick.Set(new EventCallback0(OnClickAdd));
		((GObject)Dialog.MinusBtn).onClick.Set(new EventCallback0(OnClickMinus));
		((GObject)Dialog.MaxBtn).onClick.Set(new EventCallback0(OnClickMax));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		Dialog.Slider.UnregisterUiEventListeners();
		((GObject)Dialog.BuyBtn).onClick.Clear();
		((GObject)Dialog.QuickBuyBtn).onClick.Clear();
		((GObject)Dialog.AddBtn).onClick.Clear();
		((GObject)Dialog.MinusBtn).onClick.Clear();
		((GObject)Dialog.MaxBtn).onClick.Clear();
		((GObject)Mask).onClick.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		_battlePassMainUi = (UI_main_GvG3BattlePass)parameters["Parent"];
		_mode = (int)parameters["Mode"];
		int defaultLevel = (int)parameters["DefaultLevel"];
		Dialog.Mode.selectedIndex = _mode;
		((GObject)Dialog.BuyBtn).enabled = BuyBtnEnabled(_mode);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ShowSelf.Play();
		Dialog.QuickBuyText.UBBEnabled = true;
		if (IsIzInSettlement)
		{
			RenderClaimableList();
		}
		else
		{
			Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(RenderClaimableList);
		}
		static int GetNextSpecialLevel(int curLevel)
		{
			foreach (SpecialSlot item in UI_main_GvG3BattlePass.SpecialReward)
			{
				if (curLevel < item.Data.NominalLevel)
				{
					return item.Data.NominalLevel;
				}
			}
			return UI_main_GvG3BattlePass.MaxCurContributionLevel;
		}
		static string GetRegionCnCurrency(string currencySymbol, float price)
		{
			if (currencySymbol == "RMB")
			{
				return currencySymbol;
			}
			int stock = GameManagers.Instance.StockController.GetStock(currencySymbol);
			return (stock >= Mathf.CeilToInt(price)) ? currencySymbol : "RMB";
		}
		void RenderBuyInfo(StoreItem storeItem)
		{
			KeyValuePair<string, float> priceAndCurrency = GetPriceAndCurrency(storeItem);
			string text = priceAndCurrency.Key;
			string text2 = $"{Convert.ToInt32(priceAndCurrency.Value)}";
			bool flag = text == "RMB";
			ProductLocalInfo value = null;
			((GObject)Dialog.BuyBtn.priceGroup).visible = true;
			((GObject)Dialog.BuyBtn.curIntlPriceText).visible = false;
			bool isRegionOutCN = HotUpdateProcess.Instance.IsRegionOutCN;
			if (isRegionOutCN && flag)
			{
				((GObject)Dialog.BuyBtn.priceGroup).visible = false;
				((GObject)Dialog.BuyBtn.curIntlPriceText).visible = true;
				text2 = ((!PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value)) ? "--" : value.FormattedPrice);
			}
			if (!isRegionOutCN)
			{
				text = GetRegionCnCurrency(text, priceAndCurrency.Value);
			}
			FGUIManager.Instance.GetCurrencySymbol(text, Dialog.BuyBtn.Currency, null);
			((GObject)Dialog.BuyBtn.Price).text = text2;
			((GObject)Dialog.BuyBtn.curIntlPriceText).text = text2;
			((GObject)Dialog.BuyBtn).data = text;
		}
		void RenderClaimableList()
		{
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected O, but got Unknown
			if (_mode == 0)
			{
				_isShowAdvanced = true;
				StoreItem storeItem = StoreItem.Get(GameManagers.Instance, CertItemId(BattlePassType.Advanced));
				RenderBuyInfo(storeItem);
			}
			else if (_mode == 2)
			{
				_premiumActivated = true;
				StoreItem storeItem2 = StoreItem.Get(GameManagers.Instance, CertItemId(BattlePassType.Premium));
				RenderBuyInfo(storeItem2);
			}
			else if (_mode == 1)
			{
				_isShowAdvanced = _battlePassMainUi.IsAdvancedMode;
				_premiumActivated = _battlePassMainUi.PremiumActivated;
				LevelStorItem = StoreItem.Get(GameManagers.Instance, "GvG3BattlePassScore");
				KeyValuePair<string, float> priceAndCurrency = GetPriceAndCurrency(LevelStorItem);
				ContributionPointPrice = (int)priceAndCurrency.Value;
				TotalMtg = GameManagers.Instance.StockController.GetStock(priceAndCurrency.Key);
				int num = _battlePassMainUi.CurContributionLevel();
				if (defaultLevel == -1)
				{
					defaultLevel = GetNextSpecialLevel(num);
				}
				((GObject)Dialog.LevelNum).text = defaultLevel.ToString();
				int max = UI_main_GvG3BattlePass.MaxCurContributionLevel - num;
				int value = defaultLevel - num;
				int step = 1;
				Dialog.Slider.Init(1, max, value, step, 19f);
			}
			Dialog.ClaimableList.SetVirtual();
			Dialog.ClaimableList.itemRenderer = new ListItemRenderer(ItemRenderer);
			Dialog.ClaimableList.numItems = 0;
			StopGettingData();
			GetClaimable(defaultLevel);
		}
	}

	private static string CertItemId(BattlePassType type)
	{
		ActivityBundle bundle = Singleton<GvG3BattlePassManager>.Instance.GetBundle();
		return type switch
		{
			BattlePassType.Advanced => bundle.Advanced?.PaidCert, 
			BattlePassType.Premium => bundle.Premium?.PaidCert, 
			_ => string.Empty, 
		};
	}

	private string CertStoreItemId()
	{
		ActivityBundle bundle = Singleton<GvG3BattlePassManager>.Instance.GetBundle();
		return _mode switch
		{
			0 => bundle.Advanced?.PaidCert, 
			2 => bundle.Premium?.PaidCert, 
			_ => string.Empty, 
		};
	}

	private void GetClaimable(int level)
	{
		if (_config != null)
		{
			CalcClaimable();
			return;
		}
		Singleton<GvG3BattlePassManager>.Instance.GetConfigData(delegate(GvG3BattlePassManager.ConfigData config)
		{
			_config = config;
			CalcClaimable();
		});
		void CalcClaimable()
		{
			GetClaimableHandler = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetClaimableCoroutine(level));
		}
	}

	private IEnumerator GetClaimableCoroutine(int targetLevel = -1)
	{
		Dialog.ClaimableList.numItems = 0;
		ClaimableData.Clear();
		while (UI_main_GvG3BattlePass.DataLoadingStatus != LoadingStatus.LOADED)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			yield return null;
		}
		List<Claimable> sp = new List<Claimable>();
		Dictionary<string, Claimable> norm = new Dictionary<string, Claimable>();
		List<SlotData> rewards = UI_main_GvG3BattlePass.RewardData;
		int i = rewards.Count - 1;
		while (i >= 0)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			SlotData levelSlot = rewards[i];
			if (levelSlot.IsActualNode && (targetLevel == -1 || levelSlot.NominalLevel <= targetLevel))
			{
				if (levelSlot.num_basic > 0 && levelSlot.state_basic != 2)
				{
					AddClaimable(_config.NormalPayload.SpecialBonus, sp, norm, levelSlot.num_basic, levelSlot.id_basic);
				}
				if (_isShowAdvanced && levelSlot.num_advanced > 0 && levelSlot.state_advanced != 2)
				{
					AddClaimable(_config.AdvancedPayload.SpecialBonus, sp, norm, levelSlot.num_advanced, levelSlot.id_advanced);
				}
				if (_premiumActivated && levelSlot.num_premium > 0 && levelSlot.state_premium != 2)
				{
					AddClaimable(_config.PremiumPayload.SpecialBonus, sp, norm, levelSlot.num_premium, levelSlot.id_premium);
				}
			}
			int num = i - 1;
			i = num;
		}
		ClaimableData.AddRange(sp);
		ClaimableData.AddRange(norm.Values);
		if (ClaimableData.Count == 2 && ClaimableData[0].id == "Money")
		{
			Claimable item = ClaimableData[0];
			ClaimableData[0] = ClaimableData[1];
			ClaimableData[1] = item;
		}
		UpdateClaimableList();
	}

	private static void AddClaimable(List<string> bonus, List<Claimable> sp, Dictionary<string, Claimable> norm, int num, string itemId)
	{
		Claimable claimable = new Claimable
		{
			num = num,
			id = itemId
		};
		Claimable value;
		if (bonus.Contains(itemId))
		{
			sp.Add(claimable);
		}
		else if (norm.TryGetValue(itemId, out value))
		{
			value.num += num;
		}
		else
		{
			norm.Add(itemId, claimable);
		}
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		if (!((GObject)this).isDisposed)
		{
			Claimable claimable = ClaimableData[index];
			UI_btn_ClaimableSlot uI_btn_ClaimableSlot = (UI_btn_ClaimableSlot)(object)obj;
			((GObject)uI_btn_ClaimableSlot.num).text = claimable.num.ToString();
			FGUIManager.Instance.SetItemIconAndFrame(uI_btn_ClaimableSlot.Icon, claimable.id);
			((GObject)uI_btn_ClaimableSlot).onClick.Set((EventCallback0)delegate
			{
				OnClickSlot(claimable.id);
			});
		}
	}

	private void UpdateClaimableList()
	{
		if (!((GObject)this).isDisposed)
		{
			Dialog.ClaimableList.numItems = ClaimableData.Count;
		}
	}

	private void UpdateBuyQuantityAndMTG()
	{
		int num = _battlePassMainUi.CurContributionLevel();
		int targetLevel = Mathf.Min(num + Dialog.Slider.Value, UI_main_GvG3BattlePass.MaxCurContributionLevel);
		int targetContribution;
		int num2 = _battlePassMainUi.CurContributionToTargetLevel(targetLevel, out targetContribution);
		((GObject)Dialog.BuyLevel).text = targetLevel.ToString();
		((GObject)Dialog.Score).text = num2.ToString();
		int num3 = ContributionPointPrice * num2;
		if (LevelStorItem.Content.TryGetValue("I65001", out var value))
		{
			num3 = Mathf.CeilToInt(1f * (float)num3 / (float)value);
		}
		string text = ((num3 > TotalMtg) ? "#ff0000" : "#9CF240");
		((GObject)Dialog.QuickBuyText).text = string.Format("[color={0}]{1}[/color][color={2}]/[/color][color={3}]{4}[/color]", text, num3, "#9CF240", text, TotalMtg);
		((GObject)Dialog.QuickBuyBtn).enabled = num2 > 0;
	}

	private void OnClickSlot(string id)
	{
		FGUIManager.Instance.ItemTip(id, ((GObject)this).sortingOrder, noCheckBtn: true);
	}

	private void OnClickBuyAdvanced()
	{
		if (((GObject)Dialog.BuyBtn).data?.ToString() == "MTG")
		{
			ShowTipBuyByMtg(OnConfirmBuy);
		}
		else
		{
			OnConfirmBuy();
		}
	}

	private static void ShowTipBuyByMtg(Action onConfirm)
	{
		string tipText = "CsharpCodeZhTcText98".ToLanguage() + "？";
		tipText.ToConfirmPopup(onConfirm, null, (AlignType)1);
	}

	private void OnConfirmBuy()
	{
		int mode = _mode;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PaymentOptionsDialog.Name, new Dictionary<string, object> { 
		{
			"StoreItemId",
			CertStoreItemId()
		} }, multiMode: false, ignoreQueue: false, null, delegate
		{
			_buyBtnClicked[mode] = true;
			((GObject)Dialog.BuyBtn).enabled = BuyBtnEnabled(mode);
			End();
		});
	}

	private void OnClickQuickBuy()
	{
		int num = _battlePassMainUi.CurContributionLevel();
		int targetLevel = Mathf.Min(num + Dialog.Slider.Value, UI_main_GvG3BattlePass.MaxCurContributionLevel);
		int targetContribution;
		int num2 = _battlePassMainUi.CurContributionToTargetLevel(targetLevel, out targetContribution);
		int num3 = ContributionPointPrice * num2;
		if (LevelStorItem.Content.TryGetValue("I65001", out var value))
		{
			num3 = Mathf.CeilToInt(1f * (float)num3 / (float)value);
		}
		if (num3 > TotalMtg)
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
								_battlePassMainUi.OnClickMTGBtn();
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
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PaymentOptionsDialog.Name, new Dictionary<string, object>
			{
				{ "StoreItemId", "GvG3BattlePassScore" },
				{ "Quantity", num3 }
			}, multiMode: false, ignoreQueue: false, null, delegate
			{
				End();
			});
		}
	}

	private void OnDragChange()
	{
		UpdateBuyQuantityAndMTG();
	}

	private void OnDragLeave()
	{
		int num = _battlePassMainUi.CurContributionLevel();
		int level = Mathf.Min(num + Dialog.Slider.Value, UI_main_GvG3BattlePass.MaxCurContributionLevel);
		((GObject)Dialog.LevelNum).text = level.ToString();
		StopGettingData();
		GetClaimable(level);
	}

	private void OnClickAdd()
	{
		Dialog.Slider.Value++;
		OnDragLeave();
	}

	private void OnClickMinus()
	{
		Dialog.Slider.Value--;
		OnDragLeave();
	}

	private void OnClickMax()
	{
		Dialog.Slider.ToMax();
		OnDragLeave();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == "MTG" && _mode == 1)
		{
			TotalMtg = GameManagers.Instance.StockController.GetStock("MTG");
			UpdateBuyQuantityAndMTG();
		}
	}

	public void StopGettingData()
	{
		if (GetClaimableHandler != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(GetClaimableHandler);
		}
		GetClaimableHandler = null;
	}

	private void End()
	{
		StopGettingData();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void Destroy()
	{
		ClaimableData.Clear();
		_battlePassMainUi = null;
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
