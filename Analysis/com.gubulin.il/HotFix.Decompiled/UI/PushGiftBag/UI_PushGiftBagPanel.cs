using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.MainCity;
using UnityEngine;

namespace UI.PushGiftBag;

public class UI_PushGiftBagPanel : GComponent, IUiController
{
	public Controller Status;

	public GGraph Mask;

	public UI_PageButtonLeft PageButtonLeft;

	public UI_PageButtonRight PageButtonRight;

	public UI_Dialog Dialog;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public Transition ShowDialog;

	public const string URL = "ui://ume49e0adecw8";

	public static string Name = "UI_PushGiftBagPanel";

	private List<string> _textureList = new List<string>();

	private bool toUnloadAni;

	private Coroutine TimeLimitRemainingCoroutine;

	private int curSelectedIndex;

	private List<StoreItem> pushStoreItems = new List<StoreItem>();

	private UI_MainCity MainCityPanel;

	private List<Bonus> _items = new List<Bonus>();

	private List<StoreItem> customStoreItems;

	private bool RefreshAfterPurchase;

	private bool ShowCountDown;

	public static string GetURL()
	{
		return "ui://ume49e0adecw8";
	}

	public static UI_PushGiftBagPanel CreateInstance()
	{
		return (UI_PushGiftBagPanel)(object)UIPackage.CreateObject("PushGiftBag", "PushGiftBagPanel");
	}

	public static UI_PushGiftBagPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PushGiftBagPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecw8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PageButtonLeft = (UI_PageButtonLeft)(object)((GComponent)this).GetChild("PageButtonLeft");
		PageButtonRight = (UI_PageButtonRight)(object)((GComponent)this).GetChild("PageButtonRight");
		Dialog = (UI_Dialog)(object)((GComponent)this).GetChild("Dialog");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		RefreshAfterPurchase = true;
		ShowCountDown = true;
		if (parameters.TryGetValue("SortingOrder", out var value))
		{
			((GObject)this).sortingOrder = (int)value;
		}
		else
		{
			((GObject)this).sortingOrder = 1;
		}
		if (parameters.ContainsKey("Parent"))
		{
			IUiController uiController = (IUiController)parameters["Parent"];
			if (uiController is UI_MainCity)
			{
				MainCityPanel = (UI_MainCity)uiController;
			}
		}
		if (parameters.TryGetValue("NoCountdownText", out var value2))
		{
			ShowCountDown = false;
			((GObject)Dialog.NoCountdownText).text = value2.ToString();
		}
		if (parameters.TryGetValue("RefreshAfterPurchase", out var value3))
		{
			RefreshAfterPurchase = (bool)value3;
		}
		customStoreItems = (parameters.TryGetValue("CustomStoreItems", out var value4) ? ((List<StoreItem>)value4) : null);
		Dialog.Title.title2.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		PanelInit();
	}

	public void OnShow()
	{
		if (TimeLimitRemainingCoroutine == null)
		{
			TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitRemaining());
		}
		if (FGUIManager.Instance.curPushGiftBagActivity != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in FGUIManager.Instance.curPushGiftBagActivity.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(FGUIManager.Instance.curPushGiftBagActivity.ActivityId, item.Key);
			}
		}
		ShowDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ConfirmBuyBtn).onClick.Add(new EventCallback0(ConfirmBuyClick));
		((GObject)PageButtonLeft).data = -1;
		((GObject)PageButtonRight).data = 1;
		((GObject)PageButtonLeft).onClick.Add(new EventCallback1(RefreshSelectedIndex));
		((GObject)PageButtonRight).onClick.Add(new EventCallback1(RefreshSelectedIndex));
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.ConfirmBuyBtn).onClick.Remove(new EventCallback0(ConfirmBuyClick));
		((GObject)PageButtonLeft).onClick.Remove(new EventCallback1(RefreshSelectedIndex));
		((GObject)PageButtonRight).onClick.Remove(new EventCallback1(RefreshSelectedIndex));
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
	}

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			if (pushStoreItems.Count > 0)
			{
				if (pushStoreItems[curSelectedIndex] == null)
				{
					continue;
				}
				bool limitTime = false;
				int remainingTime = 0;
				if (pushStoreItems[curSelectedIndex].ExpireTimestamp > 0)
				{
					limitTime = true;
					remainingTime = pushStoreItems[curSelectedIndex].ExpireTimestamp - (int)GameController.Instance.GetServerTime();
				}
				else if (pushStoreItems[curSelectedIndex].ValidTime > 0)
				{
					remainingTime = GameManagers.Instance.StoreManager.GetLimitTimeMerchandiseRemainingTime(FGUIManager.Instance.curPushGiftBagActivity.ActivityId, pushStoreItems[curSelectedIndex].StoreItemId);
				}
				if (limitTime && ShowCountDown)
				{
					Dialog.HasTimeLimit.selectedIndex = 0;
					if (remainingTime >= 0)
					{
						((GObject)Dialog.countdown).text = UI_PushGiftBtn.GetRemainTimeDes(remainingTime);
					}
					else
					{
						((GObject)Dialog.countdown).text = LanguagesManager.GetDesc("CsharpCodeZhTcText425");
					}
				}
				else
				{
					Dialog.HasTimeLimit.selectedIndex = 1;
					((GObject)Dialog.countdown).text = "";
				}
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
	}

	private void PanelInit()
	{
		if (customStoreItems != null)
		{
			pushStoreItems = customStoreItems;
			curSelectedIndex = 0;
		}
		else
		{
			pushStoreItems.Clear();
			pushStoreItems.AddRange(FGUIManager.Instance.pushStoreItems);
			int num = FGUIManager.Instance.pushStoreItems.IndexOf(FGUIManager.Instance.NewPushStoreItem);
			curSelectedIndex = ((num >= 0) ? num : 0);
		}
		if (pushStoreItems.Count <= 0)
		{
			End();
		}
		else
		{
			UpdateMainPanel();
		}
	}

	private void RefreshSelectedIndex(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)context.sender).data;
		curSelectedIndex += num;
		if (curSelectedIndex < 0)
		{
			curSelectedIndex = pushStoreItems.Count - 1;
		}
		if (curSelectedIndex > pushStoreItems.Count - 1)
		{
			curSelectedIndex = 0;
		}
		UpdateMainPanel();
	}

	private void UpdateMainPanel()
	{
		StoreItem storeItem = pushStoreItems[curSelectedIndex];
		if (storeItem.Tags != null && storeItem.Tags.Contains("GvGMode3Push"))
		{
			((GObject)Dialog.n35).visible = true;
			((GObject)Dialog.n34).visible = true;
		}
		else
		{
			((GObject)Dialog.n35).visible = false;
			((GObject)Dialog.n34).visible = false;
		}
		bool visible = storeItem.Tags != null && storeItem.Tags.Contains("ShowBigSave");
		((GObject)Dialog.n37).visible = visible;
		((GObject)Dialog.Title.title1).text = storeItem.SubDesc ?? "";
		RenderItemList();
		if (storeItem.IsPassedFilters && !storeItem.IsSoldOut && storeItem.IsKickedOff && !storeItem.IsExpired)
		{
			((GObject)Dialog.ConfirmBuyBtn).grayed = false;
			((GObject)Dialog.ConfirmBuyBtn).enabled = true;
		}
		else
		{
			((GObject)Dialog.ConfirmBuyBtn).grayed = true;
			((GObject)Dialog.ConfirmBuyBtn).enabled = false;
		}
		KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
		Dictionary<string, float> dictionary = storeItem.OriginPrice.First();
		string key = priceItemId.Key;
		string text = $"{Convert.ToInt32(dictionary.Values.First())}";
		string text2 = $"{Convert.ToInt32(priceItemId.Value)}";
		bool flag = key == "RMB";
		ProductLocalInfo value = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
		{
			((GObject)Dialog.priceGroup).visible = false;
			((GObject)Dialog.priceGroupIntl).visible = true;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value))
			{
				text2 = value.FormattedPrice;
				text = $"{value.CurrencySymbol}{value.Price / storeItem.InternationalDiscount:F2}";
			}
			else
			{
				text2 = "--";
			}
		}
		else
		{
			((GObject)Dialog.priceGroup).visible = true;
			((GObject)Dialog.priceGroupIntl).visible = false;
		}
		((GObject)Dialog.Price2nd).text = text;
		((GObject)Dialog.Price1st).text = text2;
		((GObject)Dialog.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText958"), text2);
		((GObject)Dialog.countdown).text = "";
		Dialog.currentCurrencyIcon.url = "ui://PublicResources/" + key;
		Dialog.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		if (pushStoreItems.Count > 1)
		{
			Status.selectedIndex = 1;
		}
		else
		{
			Status.selectedIndex = 0;
		}
	}

	private void RenderItemList()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		_items.Clear();
		List<Bonus> list = new List<Bonus>();
		foreach (KeyValuePair<string, int> item in pushStoreItems[curSelectedIndex].Content)
		{
			list.Add(Bonus.Get(item.Key, item.Value));
		}
		_items = list;
		Dialog.ItemList.itemRenderer = new ListItemRenderer(ItemRender);
		Dialog.ItemList.numItems = _items.Count;
	}

	private void ItemRender(int index, GObject obj)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		UI_TakeItemContent uI_TakeItemContent = (UI_TakeItemContent)(object)obj;
		FGUIManager.Instance.SetItemIconAndFrame(uI_TakeItemContent.icon, _items[index].ItemId, _textureList);
		((GObject)uI_TakeItemContent.num).text = $"{_items[index].Qty}";
		((GObject)uI_TakeItemContent).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(_items[index].ItemId, ((GObject)this).sortingOrder, noCheckBtn: true, reserveRes: false, this);
		});
	}

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		MainCityPanel?.UpdateMoneyAndGemNum(result);
		if (RefreshAfterPurchase)
		{
			SharedMessenger.Broadcast("ON_PUSH_GIFT_BAG_REFRESH");
		}
		PlayMissileSfx();
	}

	private void PlayMissileSfx()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			End();
		});
	}

	private void SpineInit()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		GameObject canvasObject = default(GameObject);
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SpawnManager.Instance.LoadAnimation("merchant_UI").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				toUnloadAni = true;
				GameObject obj2 = canvasObject;
				SkeletonAnimation val2 = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
				if ((Object)(object)val2 != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)val2).skeletonDataAsset = asset;
					((SkeletonRenderer)val2).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)val2, "skin1");
					val2.AnimationState.AddAnimation(0, "idle", true, 0f);
				}
			}
		});
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(100f, 100f, 100f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scaleX = 1f;
			Dialog.SpineBack.SetNativeObject((DisplayObject)(object)val);
		}
	}

	private void ConfirmBuyClick()
	{
		if (pushStoreItems.Count > 0)
		{
			StoreItem storeItem = pushStoreItems[curSelectedIndex];
			if (!FGUIManager.Instance.NotEnoughToPayTip(storeItem, ((GObject)this).sortingOrder))
			{
				End();
				return;
			}
			ProductLocalInfo value = null;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId))
			{
				PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value);
			}
			PurchaseManager.Instance.InvokePurchase(storeItem, value, 1, (Action)null, doubleCheck: true);
		}
		else
		{
			End();
		}
	}
}
