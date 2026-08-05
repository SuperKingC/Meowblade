using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.Tips;
using UnityEngine;

namespace UI.WarOrder;

public class UI_WarOrderBuyPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_WarOrderBuyDialog Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://ax280w58okbc1q";

	public static string Name = "UI_WarOrderBuyPanel";

	private UI_WarOrderPanel ParentPanel;

	private int Mode = 0;

	private List<Claimable> ClaimableData = new List<Claimable>();

	private StoreItem LevelStorItem;

	private int LevelPrice = 0;

	private int TotalMtg = 0;

	private const string LevelStoreItemId = "ActivityPackBattlePassScore";

	private const string CertStoreItemId = "ActivityPackBattlePassPaidCert";

	private Coroutine GetClaimableHandler = null;

	private bool IsShowAdvanced = false;

	public static string GetURL()
	{
		return "ui://ax280w58okbc1q";
	}

	public static UI_WarOrderBuyPanel CreateInstance()
	{
		return (UI_WarOrderBuyPanel)(object)UIPackage.CreateObject("WarOrder", "WarOrderBuyPanel");
	}

	public static UI_WarOrderBuyPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WarOrderBuyPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_WarOrderBuyDialog)(object)((GComponent)this).GetChild("Dialog");
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
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		ParentPanel = (UI_WarOrderPanel)parameters["Parent"];
		Mode = (int)parameters["Mode"];
		int num = (int)parameters["DefaultLevel"];
		Dialog.Mode.selectedIndex = Mode;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ShowSelf.Play();
		Dialog.QuickBuyText.UBBEnabled = true;
		if (Mode == 0)
		{
			IsShowAdvanced = true;
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, "ActivityPackBattlePassPaidCert");
			KeyValuePair<string, float> priceAndCurrency = GetPriceAndCurrency(storeItem);
			if ((float)GameManagers.Instance.StockController.GetStock(priceAndCurrency.Key) < priceAndCurrency.Value)
			{
				priceAndCurrency = GetPriceAndCurrency(storeItem, isVirtualCurrency: false);
			}
			string key = priceAndCurrency.Key;
			string text = $"{Convert.ToInt32(priceAndCurrency.Value)}";
			bool flag = key == "RMB";
			ProductLocalInfo value = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
			{
				((GObject)Dialog.BuyBtn.priceGroup).visible = false;
				((GObject)Dialog.BuyBtn.priceGroupIntl).visible = true;
				text = ((string.IsNullOrEmpty(storeItem.ReferenceId) || !PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value)) ? "--" : value.FormattedPrice);
			}
			else
			{
				((GObject)Dialog.BuyBtn.priceGroup).visible = true;
				((GObject)Dialog.BuyBtn.priceGroupIntl).visible = false;
			}
			FGUIManager.Instance.GetCurrencySymbol(key, Dialog.BuyBtn.Currency, null);
			((GObject)Dialog.BuyBtn.Price).text = text;
			((GObject)Dialog.BuyBtn.curIntlPriceText).text = text;
		}
		else
		{
			IsShowAdvanced = ParentPanel.IsAdvancedMode;
			LevelStorItem = StoreItem.Get(GameManagers.Instance, "ActivityPackBattlePassScore");
			KeyValuePair<string, float> priceAndCurrency2 = GetPriceAndCurrency(LevelStorItem);
			LevelPrice = (int)priceAndCurrency2.Value;
			TotalMtg = GameManagers.Instance.StockController.GetStock(priceAndCurrency2.Key);
			if (num == -1)
			{
				num = GetNextLevel(ParentPanel.CurLevel);
			}
			Dialog.LevelIcon.url = ParentPanel.CurLevelIcon.url;
			Dialog.BuyLevelIcon.url = ParentPanel.CurLevelIcon.url;
			((GObject)Dialog.LevelNum).text = num.ToString();
			int max = ParentPanel.LastLevelNum - ParentPanel.CurLevel;
			int value2 = num - ParentPanel.CurLevel;
			int step = 5;
			Dialog.Slider.Init(1, max, value2, step, 19f);
		}
		Dialog.ClaimableList.SetVirtual();
		Dialog.ClaimableList.itemRenderer = new ListItemRenderer(ItemRenderer);
		Dialog.ClaimableList.numItems = 0;
		StopGettingData();
		GetClaimableHandler = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetClaimableCoroutine(num));
	}

	private int GetNextLevel(int curLevel)
	{
		foreach (int specialNode in UI_WarOrderPanel.AdvancedPayload.SpecialNodes)
		{
			if (curLevel < specialNode)
			{
				return specialNode;
			}
		}
		return ParentPanel.LastLevelNum;
	}

	private IEnumerator GetClaimableCoroutine(int targetLevel = -1)
	{
		Dialog.ClaimableList.numItems = 0;
		ClaimableData.Clear();
		while (UI_WarOrderPanel.DataLoadingStatus != LoadingStatus.LOADED)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			yield return null;
		}
		List<Claimable> sp = new List<Claimable>();
		Dictionary<string, Claimable> norm = new Dictionary<string, Claimable>();
		int i = UI_WarOrderPanel.RewardData.Count - 1;
		while (i >= 0)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			SlotData levelSlot = UI_WarOrderPanel.RewardData[i];
			if (targetLevel == -1 || levelSlot.level <= targetLevel)
			{
				if (levelSlot.num_normal > 0 && levelSlot.state_normal != 2)
				{
					AddClaimable(sp, norm, levelSlot.icon_normal, levelSlot.num_normal, levelSlot.id_normal);
				}
				if (IsShowAdvanced)
				{
					if (levelSlot.num_advanced1 > 0 && levelSlot.state_advanced1 != 2)
					{
						AddClaimable(sp, norm, levelSlot.icon_advanced1, levelSlot.num_advanced1, levelSlot.id_advanced1);
					}
					if (levelSlot.num_advanced2 > 0 && levelSlot.state_advanced2 != 2)
					{
						AddClaimable(sp, norm, levelSlot.icon_advanced2, levelSlot.num_advanced2, levelSlot.id_advanced2);
					}
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

	private void AddClaimable(List<Claimable> sp, Dictionary<string, Claimable> norm, string icon, int num, string id)
	{
		Claimable claimable = new Claimable
		{
			icon = icon,
			num = num,
			id = id
		};
		Claimable value;
		if (UI_WarOrderPanel.AdvancedPayload.SpecialBonus.Contains(id))
		{
			sp.Add(claimable);
		}
		else if (norm.TryGetValue(id, out value))
		{
			value.num += num;
		}
		else
		{
			norm.Add(id, claimable);
		}
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		if (!((GObject)this).isDisposed)
		{
			Claimable data = ClaimableData[index];
			UI_ClaimableSlot uI_ClaimableSlot = (UI_ClaimableSlot)(object)obj;
			uI_ClaimableSlot.icon.url = data.icon;
			((GObject)uI_ClaimableSlot.num).text = data.num.ToString();
			((GObject)uI_ClaimableSlot).onClick.Set((EventCallback0)delegate
			{
				OnClickSlot(data.id);
			});
			int num = ((Item.ItemType(data.id) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(data.id) : Item.Level(GameManagers.Instance, data.id));
			num = ((num > 0) ? num : Item.Rarity(data.id));
			uI_ClaimableSlot.frame.url = $"ui://PublicResources/kuang_round 2_lv{num}";
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
		int value = Dialog.Slider.Value;
		((GObject)Dialog.BuyLevelNum).text = value.ToString();
		int num = LevelPrice * value;
		string text = ((num > TotalMtg) ? "#ff0000" : "#9CF240");
		((GObject)Dialog.QuickBuyText).text = string.Format("[color={0}]{1}[/color][color={2}]/[/color][color={3}]{4}[/color]", text, num, "#9CF240", text, TotalMtg);
	}

	private void OnClickSlot(string id)
	{
		FGUIManager.Instance.ItemTip(id, ((GObject)this).sortingOrder, noCheckBtn: true);
	}

	private void OnClickBuyAdvanced()
	{
		float remainingTime = ParentPanel.GetRemainingTime();
		if (remainingTime < 0f)
		{
			return;
		}
		StoreItem storeItem = StoreItem.Get(GameManagers.Instance, "ActivityPackBattlePassPaidCert");
		ProductLocalInfo productLocalInfo = null;
		if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(storeItem.ReferenceId))
		{
			PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out productLocalInfo);
		}
		float num = remainingTime / 86400f;
		if (num < 5f)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					string.Format("[color=#FFFF66]{0}[color=#FF3300]{1}[/color]{2}{3}{4}？[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText836"), Math.Ceiling(num), LanguagesManager.GetDesc("CsharpCodeZhTcText228"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText837"))
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								PurchaseManager.Instance.InvokePurchase(storeItem, productLocalInfo, 1, delegate
								{
									CacheManager.Instance.Get<Cache_WarOrderScore>().IsSyncProduce = true;
									End();
								});
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
			PurchaseManager.Instance.InvokePurchase(storeItem, productLocalInfo, 1, delegate
			{
				CacheManager.Instance.Get<Cache_WarOrderScore>().IsSyncProduce = true;
				End();
			}, doubleCheck: true);
		}
	}

	private void OnClickQuickBuy()
	{
		int value = Dialog.Slider.Value;
		int num = LevelPrice * value;
		if (num > TotalMtg)
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
								ParentPanel.OnClickMTGBtn();
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
			StoreItem storeItem = StoreItem.Get(GameManagers.Instance, "ActivityPackBattlePassScore");
			ProductLocalInfo value2 = null;
			if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(storeItem.ReferenceId))
			{
				PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2);
			}
			PurchaseManager.Instance.InvokePurchase(storeItem, value2, value, delegate
			{
				CacheManager.Instance.Get<Cache_WarOrderScore>().IsSyncProduce = true;
				End();
			}, doubleCheck: true);
		}
	}

	private void OnDragChange()
	{
		UpdateBuyQuantityAndMTG();
	}

	private void OnDragLeave()
	{
		int targetLevel = ParentPanel.CurLevel + Dialog.Slider.Value;
		((GObject)Dialog.LevelNum).text = targetLevel.ToString();
		StopGettingData();
		GetClaimableHandler = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetClaimableCoroutine(targetLevel));
	}

	private void OnClickAdd()
	{
		Dialog.Slider.Value += 5;
		OnDragLeave();
	}

	private void OnClickMinus()
	{
		Dialog.Slider.Value -= 5;
		OnDragLeave();
	}

	private void OnClickMax()
	{
		Dialog.Slider.ToMax();
		OnDragLeave();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == "MTG")
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
	}

	private KeyValuePair<string, float> GetPriceAndCurrency(StoreItem storeItem, bool isVirtualCurrency = true)
	{
		foreach (Dictionary<string, float> item in storeItem.Price)
		{
			Dictionary<string, float>.Enumerator enumerator2 = item.GetEnumerator();
			enumerator2.MoveNext();
			KeyValuePair<string, float> current2 = enumerator2.Current;
			string key = current2.Key;
			float value = current2.Value;
			if (isVirtualCurrency)
			{
				if (!key.Equals("RMB"))
				{
					return current2;
				}
			}
			else if (key.Equals("RMB"))
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
