using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Rank.Helpers;
using Spine;
using Spine.Unity;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GvGOuterTech;

public class UI_com_TechLotteryPage : GComponent
{
	private enum eAnim
	{
		Show,
		Idle,
		Gacha
	}

	private enum eTrans
	{
		NormalTrans,
		NewTransIn,
		NewTransOut,
		DefaultTrans
	}

	private enum eState
	{
		BeforeDraw,
		PlayingDrawSpine,
		PlayingDrawTransition,
		ShowFinalResult
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<SkeletonAnimation> _003C_003E9__48_1;

		public static Func<RItem, DrawTechItem> _003C_003E9__55_1;

		public static Action<UI_com_UniversalPopupTip> _003C_003E9__65_2;

		public static EventCallback1 _003C_003E9__65_1;

		internal void _003CInit_003Eb__48_1(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "tx", true);
		}

		internal DrawTechItem _003COnStartDrawCard_003Eb__55_1(RItem rItem)
		{
			TechData techData = new TechData(rItem.ItemId);
			return new DrawTechItem
			{
				TechData = techData,
				LastLevel = techData.Level,
				DrawCount = rItem.cnt
			};
		}

		internal void _003CShowAccelerateStatusTipsPanel_003Eb__65_1(EventContext context)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			context.StopPropagation();
			GObject target = (GObject)context.sender;
			FairyGUITip.ShowTip(target, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = LanguagesManager.GetDesc("OuterTechSpeedPlanStatusTips");
			});
		}

		internal void _003CShowAccelerateStatusTipsPanel_003Eb__65_2(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = LanguagesManager.GetDesc("OuterTechSpeedPlanStatusTips");
		}
	}

	public Controller State;

	public Controller HasPushGiftBag;

	public GGraph back;

	public UI_eff_portal n148;

	public GGraph SpineLoader_bg;

	public GGraph SpineLoader;

	public UI_btn_Close CloseBtn;

	public GButton Help;

	public UI_dec_block01 n137;

	public UI_btn_Draw DrawBtn;

	public GImage n138;

	public GTextField ChipCount;

	public GLoader ChipIcon;

	public GGroup n141;

	public UI_com_DrawingCard DrawingCard;

	public UI_dec_block05 n135;

	public GTextField CardCount;

	public GGraph eff_WhiteScreen;

	public GGraph TouchingMask;

	public UI_btn_SkipAnimBtn SkipAnimBtn;

	public UI_btn_PushGiftBag PushGiftBagBtn;

	public GGroup n146;

	public UI_btn_AccelerateGiftBag AccGiftBagBtn;

	public UI_btn_AccelerateClaim AccClaimBtn;

	public Transition Show;

	public Transition Hide;

	public Transition NormalTrans;

	public Transition NewTransIn;

	public Transition NewTransOut;

	public Transition DefaultTrans;

	public Transition HideSpeedPlan;

	public Transition ShowSpeedPlan;

	public const string URL = "ui://th385mttlgfv1h";

	public static string Name = "UI_com_TechLotteryPage";

	private SkeletonAnimation SpineAnimation;

	private GameObject SpineGameObject;

	private GameObject SpineGameObject_bg;

	private eAnim CurAnimState;

	private CoroutineQueue AnimCoroutineQueue;

	private List<DrawTechItem> DrawItems;

	private bool HasTouchToSkipTrans = false;

	private int TotalDrawCardCount;

	private StoreItem SpeedPlanGiftBag;

	private UI_main_AccelerateStatusPage AccelerateStatusPage;

	public static string GetURL()
	{
		return "ui://th385mttlgfv1h";
	}

	public static UI_com_TechLotteryPage CreateInstance()
	{
		return (UI_com_TechLotteryPage)(object)UIPackage.CreateObject("GvGOuterTech", "com_TechLotteryPage");
	}

	public static UI_com_TechLotteryPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TechLotteryPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttlgfv1h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		HasPushGiftBag = ((GComponent)this).GetController("HasPushGiftBag");
		back = (GGraph)((GComponent)this).GetChild("back");
		n148 = (UI_eff_portal)(object)((GComponent)this).GetChild("n148");
		SpineLoader_bg = (GGraph)((GComponent)this).GetChild("SpineLoader_bg");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		CloseBtn = (UI_btn_Close)(object)((GComponent)this).GetChild("CloseBtn");
		Help = (GButton)((GComponent)this).GetChild("Help");
		n137 = (UI_dec_block01)(object)((GComponent)this).GetChild("n137");
		DrawBtn = (UI_btn_Draw)(object)((GComponent)this).GetChild("DrawBtn");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		ChipCount = (GTextField)((GComponent)this).GetChild("ChipCount");
		ChipIcon = (GLoader)((GComponent)this).GetChild("ChipIcon");
		n141 = (GGroup)((GComponent)this).GetChild("n141");
		DrawingCard = (UI_com_DrawingCard)(object)((GComponent)this).GetChild("DrawingCard");
		n135 = (UI_dec_block05)(object)((GComponent)this).GetChild("n135");
		CardCount = (GTextField)((GComponent)this).GetChild("CardCount");
		eff_WhiteScreen = (GGraph)((GComponent)this).GetChild("eff_WhiteScreen");
		TouchingMask = (GGraph)((GComponent)this).GetChild("TouchingMask");
		SkipAnimBtn = (UI_btn_SkipAnimBtn)(object)((GComponent)this).GetChild("SkipAnimBtn");
		PushGiftBagBtn = (UI_btn_PushGiftBag)(object)((GComponent)this).GetChild("PushGiftBagBtn");
		n146 = (GGroup)((GComponent)this).GetChild("n146");
		AccGiftBagBtn = (UI_btn_AccelerateGiftBag)(object)((GComponent)this).GetChild("AccGiftBagBtn");
		AccClaimBtn = (UI_btn_AccelerateClaim)(object)((GComponent)this).GetChild("AccClaimBtn");
		Show = ((GComponent)this).GetTransition("Show");
		Hide = ((GComponent)this).GetTransition("Hide");
		NormalTrans = ((GComponent)this).GetTransition("NormalTrans");
		NewTransIn = ((GComponent)this).GetTransition("NewTransIn");
		NewTransOut = ((GComponent)this).GetTransition("NewTransOut");
		DefaultTrans = ((GComponent)this).GetTransition("DefaultTrans");
		HideSpeedPlan = ((GComponent)this).GetTransition("HideSpeedPlan");
		ShowSpeedPlan = ((GComponent)this).GetTransition("ShowSpeedPlan");
	}

	public void Init()
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		Hide.invalidateBatchingEveryFrame = true;
		Show.invalidateBatchingEveryFrame = true;
		NormalTrans.invalidateBatchingEveryFrame = true;
		NewTransIn.invalidateBatchingEveryFrame = true;
		NewTransOut.invalidateBatchingEveryFrame = true;
		DrawingCard.NormalTrans.invalidateBatchingEveryFrame = true;
		DrawingCard.NewTransIn.invalidateBatchingEveryFrame = true;
		DrawingCard.NewTransOut.invalidateBatchingEveryFrame = true;
		SpeedPlanGiftBag = new StoreItem(GameManagers.Instance, "GVGCardPack001");
		AnimCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		SpineGameObject = UiHelper.LoadSpine_AB("OuterTechGacha", 100f, delegate(SkeletonAnimation animation)
		{
			SpineAnimation = animation;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			PlaySpineAnim(CurAnimState);
		});
		GoWrapper val = new GoWrapper(SpineGameObject);
		val.supportStencil = true;
		SpineLoader.SetNativeObject((DisplayObject)(object)val);
		SpineGameObject_bg = UiHelper.LoadSpine_AB("changwaikeji_tx", 100f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "tx", true);
		});
		val = new GoWrapper(SpineGameObject_bg);
		val.supportStencil = true;
		SpineLoader_bg.SetNativeObject((DisplayObject)(object)val);
		Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(delegate
		{
			PushGiftBagBtn.Init();
			RenderGiftBagBtn();
			RenderAccelerateTip();
			RenderAccelerateGiftBag();
		});
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
		((GObject)DrawBtn).onClick.Set(new EventCallback0(OnStartDrawCard));
		((GObject)TouchingMask).onClick.Set(new EventCallback0(OnClickTouchingMask));
		((GObject)SkipAnimBtn).onClick.Set(new EventCallback0(OnClickSkipAnimBtn));
		((GObject)Help).onClick.Set(new EventCallback1(OnClickHelpBtn));
		PushGiftBagBtn.RegisterUiEventListeners();
		GvGOuterTechManager instance = Singleton<GvGOuterTechManager>.Instance;
		instance.OnGiftBagChange = (Action)Delegate.Combine(instance.OnGiftBagChange, new Action(OnGiftBagChange));
		GvGOuterTechManager instance2 = Singleton<GvGOuterTechManager>.Instance;
		instance2.OnNoticeChange = (Action)Delegate.Combine(instance2.OnNoticeChange, new Action(UpdateChipCount));
		SharedMessenger.AddListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OnOrderShipSuccessWithStoreItemId);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)DrawBtn).onClick.Clear();
		((GObject)TouchingMask).onClick.Clear();
		((GObject)SkipAnimBtn).onClick.Set(new EventCallback0(OnClickSkipAnimBtn));
		((GObject)Help).onClick.Clear();
		PushGiftBagBtn.UnregisterUiEventListeners();
		GvGOuterTechManager instance = Singleton<GvGOuterTechManager>.Instance;
		instance.OnGiftBagChange = (Action)Delegate.Remove(instance.OnGiftBagChange, new Action(OnGiftBagChange));
		GvGOuterTechManager instance2 = Singleton<GvGOuterTechManager>.Instance;
		instance2.OnNoticeChange = (Action)Delegate.Remove(instance2.OnNoticeChange, new Action(UpdateChipCount));
		SharedMessenger.RemoveListener<string>("ORDER_SHIP_SUCCESS_WITH_STOREITEM", OnOrderShipSuccessWithStoreItemId);
	}

	public void OnShow()
	{
		SwitchState(eState.BeforeDraw);
	}

	public void OnActive()
	{
	}

	public void OnInactive()
	{
		AnimCoroutineQueue.Clear();
	}

	public void OnDestroy()
	{
		Object.Destroy((Object)(object)SpineGameObject);
		Object.Destroy((Object)(object)SpineGameObject_bg);
		AnimCoroutineQueue.Clear();
		PushGiftBagBtn.Destroy();
	}

	private void OnStartDrawCard()
	{
		((GObject)DrawBtn).enabled = false;
		((GObject)AccClaimBtn).enabled = false;
		((GObject)AccGiftBagBtn).enabled = false;
		HideSpeedPlan.Play();
		Singleton<GvGOuterTechManager>.Instance.DrawOuterTech(delegate(DrawOuterTechResponse res)
		{
			if (res == null)
			{
				((GObject)AccClaimBtn).enabled = true;
				((GObject)AccGiftBagBtn).enabled = true;
				((GObject)DrawBtn).enabled = true;
				ShowSpeedPlan.Play();
			}
			else
			{
				DrawItems = res.DrawResult.Select(delegate(RItem rItem)
				{
					TechData techData = new TechData(rItem.ItemId);
					return new DrawTechItem
					{
						TechData = techData,
						LastLevel = techData.Level,
						DrawCount = rItem.cnt
					};
				}).ToList();
				SwitchState(eState.PlayingDrawSpine);
			}
		});
	}

	private void OnClickTouchingMask()
	{
		HasTouchToSkipTrans = true;
	}

	private void OnClickSkipAnimBtn()
	{
		AnimCoroutineQueue.Clear();
		SwitchState(eState.ShowFinalResult);
	}

	private void OnClickHelpBtn(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_OutTechHelpPanel.Name, new Dictionary<string, object>());
	}

	private void OnGiftBagChange()
	{
		RenderGiftBagBtn();
	}

	private void OnSpeedPlanOperated()
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		Singleton<GvGOuterTechManager>.Instance.SyncSpeedPlan(delegate
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			RenderAccelerateTip();
			RenderAccelerateGiftBag();
		});
	}

	private void OnOrderShipSuccessWithStoreItemId(string storeItemId)
	{
		if (storeItemId == "GVGCardPack001")
		{
			OnSpeedPlanOperated();
			GameLocalDataManager.SetSpeedPlanLastPurchase(DateTimeHelper.ServerNowTimestamp);
		}
	}

	private void RenderGiftBagBtn()
	{
		if (Singleton<GvGOuterTechManager>.Instance.HasPushedGiftBag)
		{
			HasPushGiftBag.selectedIndex = 1;
			PushGiftBagBtn.Update();
		}
		else
		{
			HasPushGiftBag.selectedIndex = 0;
		}
	}

	private void RenderAccelerateTip()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		((GObject)AccClaimBtn).onClick.Clear();
		if (Singleton<GvGOuterTechManager>.Instance.IsSpeedPlanAvailable)
		{
			if (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount > 0 && !Singleton<GvGOuterTechManager>.Instance.SpeedPlan.Claimed)
			{
				((GObject)AccClaimBtn).onClick.Set(new EventCallback0(ClaimChipsByAccelerate));
				AccClaimBtn.AccStatus.selectedIndex = 1;
				((GObject)AccClaimBtn.Qty).text = $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount}";
			}
			else if (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.TotalCount > Singleton<GvGOuterTechManager>.Instance.SpeedPlan.ClaimedCount)
			{
				((GObject)AccClaimBtn).onClick.Set(new EventCallback0(ShowAccelerateStatusTipsPanel));
				AccClaimBtn.AccStatus.selectedIndex = 0;
				((GObject)AccClaimBtn.Qty).text = $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.NextClaimCount}";
			}
			else
			{
				((GObject)AccClaimBtn).onClick.Set(new EventCallback0(ShowAccelerateStatusTipsPanel));
				AccClaimBtn.AccStatus.selectedIndex = 2;
				((GObject)AccClaimBtn.Qty).text = "";
			}
		}
		else
		{
			((GObject)AccClaimBtn).visible = false;
		}
	}

	private void ClaimChipsByAccelerate()
	{
		Singleton<GvGOuterTechManager>.Instance.ClaimSpeedPlan(OnSpeedPlanOperated);
	}

	private void ShowAccelerateStatusTipsPanel()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		if (AccelerateStatusPage != null)
		{
			((GObject)AccelerateStatusPage).Dispose();
		}
		AccelerateStatusPage = UI_main_AccelerateStatusPage.CreateInstance_ILRuntime();
		((GObject)AccelerateStatusPage.mask).onClick.Set((EventCallback0)delegate
		{
			((GObject)AccelerateStatusPage).Dispose();
		});
		EventListener onClick = ((GObject)AccelerateStatusPage.Dialog.HelpBtn).onClick;
		object obj = _003C_003Ec._003C_003E9__65_1;
		if (obj == null)
		{
			EventCallback1 val = delegate(EventContext context)
			{
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0014: Expected O, but got Unknown
				//IL_0037: Unknown result type (might be due to invalid IL or missing references)
				//IL_003d: Unknown result type (might be due to invalid IL or missing references)
				context.StopPropagation();
				GObject target = (GObject)context.sender;
				FairyGUITip.ShowTip(target, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip popup)
				{
					((GObject)popup.title).text = LanguagesManager.GetDesc("OuterTechSpeedPlanStatusTips");
				});
			};
			_003C_003Ec._003C_003E9__65_1 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback1)obj);
		((GObject)AccelerateStatusPage.Dialog.TotalHeld).text = $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.TotalGvGCount}";
		((GObject)AccelerateStatusPage.Dialog.TotalJoined).text = $"{Singleton<GvGOuterTechManager>.Instance.GvGTotalJoined}";
		int totalCount = Singleton<GvGOuterTechManager>.Instance.SpeedPlan.TotalCount;
		int claimedCount = Singleton<GvGOuterTechManager>.Instance.SpeedPlan.ClaimedCount;
		int num = totalCount - claimedCount;
		string text = ((num > 0) ? $"{num}" : "[color=#FF1A1A]0[/color]");
		text += $"/{totalCount}";
		((GObject)AccelerateStatusPage.Dialog.TotalAccCnt).text = text;
		if (!Singleton<GvGOuterTechManager>.Instance.SpeedPlan.Claimed || Singleton<GvGOuterTechManager>.Instance.SpeedPlan.ClaimedCount == 0)
		{
			AccelerateStatusPage.Dialog.AccStatus.selectedIndex = 0;
			((GObject)AccelerateStatusPage.Dialog.ClaimCnt).text = $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.NextClaimCount}";
		}
		else if (totalCount > claimedCount)
		{
			AccelerateStatusPage.Dialog.AccStatus.selectedIndex = 2;
			((GObject)AccelerateStatusPage.Dialog.ClaimCnt).text = ((Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount > 0) ? $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.CouldClaimCount}" : "");
			((GObject)AccelerateStatusPage.Dialog.NextClaimCnt).text = $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.NextClaimCount}";
		}
		else
		{
			AccelerateStatusPage.Dialog.AccStatus.selectedIndex = 3;
		}
		((GComponent)GRoot.inst).AddChild((GObject)(object)AccelerateStatusPage);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)AccelerateStatusPage);
		FGUIManager.SetToFullScreen((GObject)(object)AccelerateStatusPage);
		AccelerateStatusPage.showPopup.Play();
	}

	private void RenderAccelerateGiftBag()
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		((GObject)AccGiftBagBtn).onClick.Clear();
		if (Singleton<GvGOuterTechManager>.Instance.IsSpeedPlanGiftBagAvailable)
		{
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(SpeedPlanGiftBag);
			if (priceItemId.Key == "MTG")
			{
				AccGiftBagBtn.CurrencyType.selectedIndex = 0;
				FGUIManager.Instance.GetCurrencySymbol(priceItemId.Key, AccGiftBagBtn.CurrencyIcon, null);
				((GObject)AccGiftBagBtn.Price).text = $"{priceItemId.Value}";
			}
			else
			{
				AccGiftBagBtn.CurrencyType.selectedIndex = 1;
				((GObject)AccGiftBagBtn.RMBPrice).text = string.Format("{0}{1}", LanguagesManager.GetDesc("RMB_Symbol"), priceItemId.Value);
			}
			((GObject)AccGiftBagBtn.Qty).text = SpeedPlanGiftBag.Content.Values.First().ToString();
			((GObject)AccGiftBagBtn.BuyLimit).text = string.Format(LanguagesManager.GetDesc("OuterTechSpeedPlanGiftBagBuyLimit"), $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlanGiftBagRemaining}", $"{Singleton<GvGOuterTechManager>.Instance.SpeedPlan.GiftPurchaseLimit}");
			if (Singleton<GvGOuterTechManager>.Instance.SpeedPlanGiftBagRemaining > 0)
			{
				((GObject)AccGiftBagBtn).onClick.Set(new EventCallback0(AccelerateGiftBagDealConfirm));
				AccGiftBagBtn.GiftBagStauts.selectedIndex = 0;
			}
			else if (Singleton<GvGOuterTechManager>.Instance.SpeedPlan.GiftPurchaseLimit > 0)
			{
				((GObject)AccGiftBagBtn).onClick.Set(new EventCallback0(AccelerateGiftBagSellOutTip));
				AccGiftBagBtn.GiftBagStauts.selectedIndex = 1;
			}
			else
			{
				((GObject)AccGiftBagBtn).visible = false;
			}
		}
		else
		{
			((GObject)AccGiftBagBtn).visible = false;
		}
	}

	private void AccelerateGiftBagDealConfirm()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
		{
			{
				"Name",
				SpeedPlanGiftBag.Name ?? ""
			},
			{ "CanBuy", true },
			{ "GiftBag", SpeedPlanGiftBag },
			{
				"PurchaseLimit",
				Singleton<GvGOuterTechManager>.Instance.SpeedPlan.GiftPurchaseLimit
			},
			{
				"PurchaseLimitTips",
				LanguagesManager.GetDesc("OuterTechSpeedPlanGiftBagPurchaseTips")
			},
			{ "DoubleCheckToBuy", true },
			{ "Parent", this }
		});
	}

	private void AccelerateGiftBagSellOutTip()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("OuterTechSpeedPlanGiftBagSellOutTips") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void UpdateChipCount()
	{
		((GObject)DrawBtn).enabled = Singleton<GvGOuterTechManager>.Instance.HasDrawChance;
		((GObject)DrawBtn.note).visible = Singleton<GvGOuterTechManager>.Instance.HasDrawChance;
		FGUIManager.Instance.SetItemIconAndFrame(ChipIcon, "I63121", null, "", frameVisible: false);
		if (Singleton<GvGOuterTechManager>.Instance.ChipCount <= Singleton<GvGOuterTechManager>.Instance.MaxDrawCount)
		{
			((GObject)ChipCount).text = $"{Singleton<GvGOuterTechManager>.Instance.ChipCount}";
		}
		else
		{
			((GObject)ChipCount).text = $"{Singleton<GvGOuterTechManager>.Instance.ChipCount}/{Singleton<GvGOuterTechManager>.Instance.MaxDrawCount}";
		}
	}

	private TrackEntry PlaySpineAnim(eAnim anim)
	{
		CurAnimState = anim;
		if ((Object)(object)SpineAnimation == (Object)null)
		{
			return null;
		}
		string text = $"{CurAnimState}";
		if (CurAnimState == eAnim.Show)
		{
			return SpineAnimation.AnimationState.SetAnimation(0, text, false);
		}
		if (CurAnimState == eAnim.Idle)
		{
			return SpineAnimation.AnimationState.SetAnimation(0, text, true);
		}
		if (CurAnimState == eAnim.Gacha)
		{
			text = $"{CurAnimState}_{Random.Range(0, 3)}";
			return SpineAnimation.AnimationState.SetAnimation(0, text, false);
		}
		return null;
	}

	private Transition PlayTransition(eTrans transType)
	{
		NormalTrans.Stop();
		NewTransIn.Stop();
		NewTransOut.Stop();
		switch (transType)
		{
		case eTrans.NormalTrans:
			NormalTrans.Play();
			return NormalTrans;
		case eTrans.NewTransIn:
			NewTransIn.Play();
			return NewTransIn;
		case eTrans.NewTransOut:
			NewTransOut.Play();
			return NewTransOut;
		default:
			return null;
		}
	}

	private void SwitchState(eState state)
	{
		State.SetSelectedIndex((int)state);
		switch (state)
		{
		case eState.BeforeDraw:
			HasTouchToSkipTrans = false;
			UpdateChipCount();
			((GObject)AccClaimBtn).enabled = true;
			((GObject)AccGiftBagBtn).enabled = true;
			ShowSpeedPlan.Play();
			AnimCoroutineQueue.AddCoroutine(SM_PlaySpineAnim(eAnim.Show));
			AnimCoroutineQueue.AddCoroutine(SM_PlaySpineAnim(eAnim.Idle));
			break;
		case eState.PlayingDrawSpine:
			AnimCoroutineQueue.AddCoroutine(SM_PlaySpineAnim(eAnim.Gacha));
			AnimCoroutineQueue.AddCoroutine(SM_ToNextState(eState.PlayingDrawTransition));
			break;
		case eState.PlayingDrawTransition:
		{
			HasTouchToSkipTrans = false;
			PlayTransition(eTrans.DefaultTrans);
			List<int> list = new List<int>();
			HashSet<int> hashSet = new HashSet<int>();
			for (int num = 0; num < DrawItems.Count; num++)
			{
				DrawTechItem drawTechItem = DrawItems[num];
				if (drawTechItem.LastLevel == 0)
				{
					hashSet.Add(num);
				}
				for (int num2 = 0; num2 < drawTechItem.DrawCount; num2++)
				{
					list.Add(num);
				}
			}
			list.Shuffle();
			int num3 = 0;
			foreach (int item in list)
			{
				DrawTechItem card = DrawItems[item];
				if (hashSet.Contains(item))
				{
					hashSet.Remove(item);
					AnimCoroutineQueue.AddCoroutine(SM_PlayNewCardTransitionIn(card, ++num3));
					AnimCoroutineQueue.AddCoroutine(SM_WaitToPlayNewCardTransitionOut(card));
				}
				else
				{
					AnimCoroutineQueue.AddCoroutine(SM_PlayNormalCardTransision(card, ++num3));
				}
			}
			TotalDrawCardCount = num3;
			AnimCoroutineQueue.AddCoroutine(SM_ToNextState(eState.ShowFinalResult));
			break;
		}
		case eState.ShowFinalResult:
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_TechResultPanel.Name, new Dictionary<string, object>
			{
				{ "DrawItems", DrawItems },
				{
					"OnClose",
					new UICallbackParam<Action>(delegate
					{
						SwitchState(eState.BeforeDraw);
					})
				}
			});
			break;
		}
	}

	private IEnumerator SM_PlaySpineAnim(eAnim anim)
	{
		TrackEntry trackEntry = PlaySpineAnim(anim);
		if (trackEntry != null && anim != eAnim.Idle)
		{
			yield return (object)new WaitForSeconds(trackEntry.AnimationEnd);
		}
	}

	private IEnumerator SM_ToNextState(eState state)
	{
		SwitchState(state);
		yield break;
	}

	private IEnumerator SM_PlayNormalCardTransision(DrawTechItem card, int index)
	{
		DrawingCard.RenderNormalCard(card);
		((GObject)CardCount).text = $"{index}/{TotalDrawCardCount}";
		Transition trans = PlayTransition(eTrans.NormalTrans);
		yield return (object)new WaitForSeconds(0.5f);
		HasTouchToSkipTrans = false;
		while (trans.playing && !HasTouchToSkipTrans)
		{
			yield return null;
		}
		HasTouchToSkipTrans = false;
	}

	private IEnumerator SM_PlayNewCardTransitionIn(DrawTechItem card, int index)
	{
		DrawingCard.RenderNewCard(card);
		((GObject)CardCount).text = $"{index}/{TotalDrawCardCount}";
		Transition trans = PlayTransition(eTrans.NewTransIn);
		while (trans.playing)
		{
			yield return null;
		}
	}

	private IEnumerator SM_WaitToPlayNewCardTransitionOut(DrawTechItem card)
	{
		HasTouchToSkipTrans = false;
		while (!HasTouchToSkipTrans)
		{
			yield return null;
		}
		HasTouchToSkipTrans = false;
		Transition trans = PlayTransition(eTrans.NewTransOut);
		while (trans.playing)
		{
			yield return null;
		}
	}
}
