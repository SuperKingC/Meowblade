using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI.GameActivity.NestingGiftBag;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using UI.Contract;
using UnityEngine;

namespace UI.GameActivity;

public class UI_main_DeparturePresent : GComponent
{
	public GImage n0;

	public GImage n6;

	public GImage n3;

	public GImage n4;

	public GMovieClip n5;

	public UI_com_DeparturePresent DepartureGifts;

	public GImage n8;

	public GImage n9;

	public GImage n7;

	public GTextField n10;

	public const string URL = "ui://29q48tv6jorqaw";

	public static string Name = "UI_main_DeparturePresent";

	private const string RMB_SYMBOL = "RMB_Symbol";

	private int _orderingIndex;

	private UI_ActivityPanel _activityPanel;

	private HashSet<string> _freeclaimTags;

	private static List<NestingGiftBags> _nestingGiftBags => GameManagers.Instance.ActivityManager.DepartureGift;

	public static string GetURL()
	{
		return "ui://29q48tv6jorqaw";
	}

	public static UI_main_DeparturePresent CreateInstance()
	{
		return (UI_main_DeparturePresent)(object)UIPackage.CreateObject("GameActivity", "main_DeparturePresent");
	}

	public static UI_main_DeparturePresent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_DeparturePresent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6jorqaw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GMovieClip)((GComponent)this).GetChild("n5");
		DepartureGifts = (UI_com_DeparturePresent)(object)((GComponent)this).GetChild("DepartureGifts");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://29q48tv6jorqaw".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
	}

	public static bool DisplayRedNote()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return _nestingGiftBags.Any((NestingGiftBags gift) => gift.HasClaimableFreeGiftBag());
		}
		bool flag = IsRelatedStoryNodeVersion();
		bool flag2 = _nestingGiftBags.Any((NestingGiftBags gift) => gift.HasClaimableFreeGiftBag());
		return flag && flag2;
	}

	public static bool UiVisible()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return _nestingGiftBags.Any((NestingGiftBags gift) => gift.HasToBeUsedGiftBag());
		}
		bool flag = IsRelatedStoryNodeVersion();
		bool flag2 = _nestingGiftBags.Any((NestingGiftBags gift) => gift.HasToBeUsedGiftBag());
		return flag && flag2;
	}

	public void OnShipOrderSuccess()
	{
		if (_orderingIndex >= 0 && _orderingIndex < _nestingGiftBags.Count)
		{
			UpdatePaidGiftBag(_orderingIndex);
		}
	}

	private static bool IsRelatedStoryNodeVersion()
	{
		int storyNodeVersionById = GameManagers.Instance.UserArchiveManager.GetStoryNodeVersionById("1");
		HashSet<int> hashSet = new HashSet<int> { 3, 4, 5, 6, 7 };
		return hashSet.Contains(storyNodeVersionById);
	}

	public void Init(UI_ActivityPanel parentPanel)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		_activityPanel = parentPanel;
		_freeclaimTags = new HashSet<string>();
		DepartureGifts.Gifts.itemRenderer = new ListItemRenderer(GiftBagsRenderer);
	}

	public void Render()
	{
		DepartureGifts.Gifts.numItems = _nestingGiftBags.Count;
	}

	private void GiftBagsRenderer(int index, GObject obj)
	{
		if (!(obj is UI_com_DepartureGifts uI_com_DepartureGifts))
		{
			throw new Exception("UI_main_DeparturePresent obj is not UI_com_DepartureGifts");
		}
		NestingGiftBags nestingGiftBags = _nestingGiftBags[index];
		int num = index + 1;
		NestingGiftBags next = ((num > _nestingGiftBags.Count - 1) ? null : _nestingGiftBags[num]);
		LevelConditionRenderer(nestingGiftBags, next, uI_com_DepartureGifts.LevelCondition);
		if (index == 0)
		{
		}
		int giftUiType = nestingGiftBags.GetGiftUiType();
		uI_com_DepartureGifts.Type.SetSelectedIndex(giftUiType);
		uI_com_DepartureGifts.FreeGift.WidthController.SetSelectedIndex(giftUiType);
		FreeGiftRenderer(nestingGiftBags.FreeGiftBag, index, uI_com_DepartureGifts.FreeGift);
		PaidGiftRenderer(nestingGiftBags.PaidGiftBag, index, uI_com_DepartureGifts.PaidGift);
	}

	private void UpdateFreeGiftBag(int index)
	{
		if (!(((GComponent)DepartureGifts.Gifts).GetChildAt(index) is UI_com_DepartureGifts uI_com_DepartureGifts))
		{
			throw new Exception("UI_main_DeparturePresent obj is not UI_com_DepartureGifts");
		}
		NestingGiftBags nestingGiftBags = _nestingGiftBags[index];
		uI_com_DepartureGifts.Type.SetSelectedIndex(nestingGiftBags.GetGiftUiType());
		FreeGiftRenderer(nestingGiftBags.FreeGiftBag, index, uI_com_DepartureGifts.FreeGift);
		PaidGiftRenderer(nestingGiftBags.PaidGiftBag, index, uI_com_DepartureGifts.PaidGift);
	}

	private void UpdatePaidGiftBag(int index)
	{
		if (!(((GComponent)DepartureGifts.Gifts).GetChildAt(index) is UI_com_DepartureGifts uI_com_DepartureGifts))
		{
			throw new Exception("UI_main_DeparturePresent obj is not UI_com_DepartureGifts");
		}
		NestingGiftBags nestingGiftBags = _nestingGiftBags[index];
		PaidGiftRenderer(nestingGiftBags.PaidGiftBag, index, uI_com_DepartureGifts.PaidGift);
	}

	private static void LevelConditionRenderer(NestingGiftBags current, NestingGiftBags next, UI_com_DepartureLevelCondition levelUi)
	{
		levelUi.LevelState.SetSelectedIndex(current.LevelProgressUiIndex(next));
		levelUi.NodeType.SetSelectedIndex(current.LevelNodeIndex(next));
		((GObject)levelUi.UnlockTitle).text = current.UnlockTitle;
	}

	private void FreeGiftRenderer(INestingGift gift, int index, UI_btn_FreeGift ui)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		ui.Icon.url = gift.IconUrl;
		((GObject)ui.Number).text = gift.Name;
		int uiState = gift.GetUiState();
		ui.State.SetSelectedIndex(uiState);
		((GObject)ui).onClick.Set(new EventCallback1(OnUiClick));
		string text = $"DeparturePresentClaim{index + 1}";
		_freeclaimTags.Add(text);
		UiTagManager.Instance.Unregister(text);
		if (uiState == 1)
		{
			UiTagManager.Instance.Register(text, ui);
		}
		FGUIManager.Instance.AddTextSpecialEffects(ui.fxPos, "ui_stroke_button_3", Vector3.one * 100f);
		void OnUiClick(EventContext context)
		{
			context.StopPropagation();
			gift.OnClick(delegate
			{
				UpdateFreeGiftBag(index);
				CacheManager.Instance.Get<Cache_DeparturePresentRedDot>().ForceUpdate();
				float delaySeconds = ((_nestingGiftBags[index].PaidGiftBag != null) ? 1.4f : 0.2f);
				EffectHelper.CoroutineDelay(delaySeconds, delegate
				{
					if (!((GObject)this).isDisposed)
					{
						"DeparturePresentGoDrawCardTip".ToLanguage().ToConfirmPopup(delegate
						{
							UnityUiService.Instance.OpenPanel(UI_ContractPanel.Name, new Dictionary<string, object> { { "Parent", _activityPanel } });
						}, null, (AlignType)0);
					}
				});
			});
		}
	}

	private void PaidGiftRenderer(INestingGift gift, int index, UI_btn_PaidGift ui)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		if (gift != null)
		{
			RenderStoreItemInfo();
			RenderItemInfo();
			((GObject)ui).onClick.Set(new EventCallback0(OnUiClick));
		}
		void OnUiClick()
		{
			_orderingIndex = index;
			gift.OnClick(delegate
			{
				UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
			});
		}
		void RenderItemInfo()
		{
			ui.Icon.url = gift.IconUrl;
			((GObject)ui.Number).text = gift.Name;
			ui.State.SetSelectedIndex(gift.GetUiState());
		}
		void RenderStoreItemInfo()
		{
			PaidNestingGift paidNestingGift = (PaidNestingGift)gift;
			StoreItem storeItem = paidNestingGift.StoreItem;
			UiHelper.SetStoreItemDiscount(storeItem, ui.Discount, ribbonVisible: true);
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			((GObject)ui.LimitCount).text = $"{storeItem.PurchaseLimit - purchaseCntAtLimitPeriod}/{storeItem.PurchaseLimit}";
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			Dictionary<string, float> dictionary = storeItem.OriginPrice.First();
			string key = priceItemId.Key;
			string text = $"{Convert.ToInt32(dictionary.Values.First())}";
			string text2 = $"{Convert.ToInt32(priceItemId.Value)}";
			bool flag = key == "RMB";
			bool flag2 = true;
			ProductLocalInfo value = null;
			if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
			{
				if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value))
				{
					float price = value.Price;
					if (price > 0f)
					{
						text2 = $"{value.CurrencySymbol}{price:F2}";
					}
					else
					{
						flag2 = false;
						text2 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
					}
					float num = value.Price / storeItem.InternationalDiscount;
					text = ((!(num > 0f)) ? LanguagesManager.GetDesc("CsharpCodeTextPriceFree") : $"{value.CurrencySymbol}{num:F2}");
				}
				else
				{
					flag2 = false;
					text2 = "--";
					text = "--";
					if (string.IsNullOrEmpty(storeItem.ReferenceId) && priceItemId.Value <= 0f)
					{
						text2 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
					}
				}
			}
			else
			{
				string text3 = "RMB_Symbol".ToLanguage();
				text = text3 + text;
				text2 = text3 + text2;
			}
			((GObject)ui.OriginIntlPriceText).text = text;
			((GObject)ui.CurIntlPriceText).text = text2;
		}
	}

	public void OnDestroy()
	{
		if (_activityPanel == null)
		{
			return;
		}
		foreach (string freeclaimTag in _freeclaimTags)
		{
			UiTagManager.Instance.Unregister(freeclaimTag);
		}
	}
}
