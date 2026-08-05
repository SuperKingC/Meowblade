using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.Tips;
using UI.WeekActivity;
using UnityEngine;

namespace UI.GameActivity;

public class UI_com_SpinWeekTree : GComponent, ISpinWheelPage
{
	public Controller rotateState;

	public GImage n20;

	public GImage n46;

	public GImage n47;

	public GImage n50;

	public GImage n49;

	public GImage n48;

	public GImage n51;

	public GImage n57;

	public GImage n58;

	public GMovieClip n52;

	public GMovieClip n53;

	public GGraph spineWrapper;

	public UI_com_rewardWeekTree rewardIcons;

	public GImage n45;

	public UI_drawBtn1 spinBtn;

	public UI_skipBtn skipBtn;

	public UI_storeBtn storeBtn;

	public UI_drawBtn2 spinBtnX50;

	public GImage n26;

	public GRichTextField exchangeRateText;

	public GList giftRecordList;

	public GImage n28;

	public UI_giftPackBtn giftPackBtn;

	public UI_weekCardBtn weekCardBtn;

	public GImage n29;

	public UI_probabilityBtn helpBtn;

	public GImage n31;

	public GLoader costIcon1;

	public GTextField cost1;

	public GGroup n36;

	public GLoader costIcon2;

	public GTextField cost2;

	public GGroup n39;

	public GTextField time;

	public GGraph vfxWrapper;

	public GGraph flyAnim;

	public Transition idle;

	public Transition gacha1;

	public Transition gacha2;

	public const string URL = "ui://29q48tv6ku17f6h";

	public static string Name = "UI_com_SpinWeekTree";

	private const string SkipBtnKey = "SpinWeekSpinSkipBtn";

	private bool _breakCurrentSpin;

	private GetWeeklyActivityResponse _response;

	private bool _isRotate;

	private bool _isStockDirty;

	private Action _onClickCloseResultPanel;

	private SkeletonAnimation _spineAnim;

	public UI_ActivityPanel Parent { get; set; }

	public GGraph FlyAnim => flyAnim;

	public GLoader FlyAnimDest => storeBtn.ticketIcon;

	public UI_skipBtn SkipBtn => skipBtn;

	public UI_storeBtn StoreBtn => storeBtn;

	public static string GetURL()
	{
		return "ui://29q48tv6ku17f6h";
	}

	public static UI_com_SpinWeekTree CreateInstance()
	{
		return (UI_com_SpinWeekTree)(object)UIPackage.CreateObject("GameActivity", "com_SpinWeekTree");
	}

	public static UI_com_SpinWeekTree CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpinWeekTree).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6ku17f6h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		rotateState = ((GComponent)this).GetController("rotateState");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n52 = (GMovieClip)((GComponent)this).GetChild("n52");
		n53 = (GMovieClip)((GComponent)this).GetChild("n53");
		spineWrapper = (GGraph)((GComponent)this).GetChild("spineWrapper");
		rewardIcons = (UI_com_rewardWeekTree)(object)((GComponent)this).GetChild("rewardIcons");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		spinBtn = (UI_drawBtn1)(object)((GComponent)this).GetChild("spinBtn");
		skipBtn = (UI_skipBtn)(object)((GComponent)this).GetChild("skipBtn");
		storeBtn = (UI_storeBtn)(object)((GComponent)this).GetChild("storeBtn");
		spinBtnX50 = (UI_drawBtn2)(object)((GComponent)this).GetChild("spinBtnX50");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		exchangeRateText = (GRichTextField)((GComponent)this).GetChild("exchangeRateText");
		giftRecordList = (GList)((GComponent)this).GetChild("giftRecordList");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		giftPackBtn = (UI_giftPackBtn)(object)((GComponent)this).GetChild("giftPackBtn");
		weekCardBtn = (UI_weekCardBtn)(object)((GComponent)this).GetChild("weekCardBtn");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		helpBtn = (UI_probabilityBtn)(object)((GComponent)this).GetChild("helpBtn");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		costIcon1 = (GLoader)((GComponent)this).GetChild("costIcon1");
		cost1 = (GTextField)((GComponent)this).GetChild("cost1");
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		costIcon2 = (GLoader)((GComponent)this).GetChild("costIcon2");
		cost2 = (GTextField)((GComponent)this).GetChild("cost2");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		time = (GTextField)((GComponent)this).GetChild("time");
		vfxWrapper = (GGraph)((GComponent)this).GetChild("vfxWrapper");
		flyAnim = (GGraph)((GComponent)this).GetChild("flyAnim");
		idle = ((GComponent)this).GetTransition("idle");
		gacha1 = ((GComponent)this).GetTransition("gacha1");
		gacha2 = ((GComponent)this).GetTransition("gacha2");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		((GObject)spinBtn).onClick.Set(new EventCallback0(OnClickDoSpin));
		((GObject)spinBtnX50).onClick.Set(new EventCallback0(OnClickDoSpinX50));
		((GObject)weekCardBtn).onClick.Set(new EventCallback0(OnClickWeekCardBtn));
		((GObject)giftPackBtn).onClick.Set(new EventCallback0(OnClickGiftPackBtn));
		((GObject)storeBtn).onClick.Set(new EventCallback0(OnClickStoreBtn));
		((GObject)skipBtn).onClick.Set(new EventCallback0(OnClickSkipBtn));
		((GObject)helpBtn).onClick.Set(new EventCallback0(OnClickHelpTip));
		GameManagers.Instance.Messenger.AddListener<GetWeeklyActivityResponse>("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", OnSpinActivityProgressChange);
		GameManagers.Instance.Messenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)spinBtn).onClick.Clear();
		((GObject)spinBtnX50).onClick.Clear();
		((GObject)weekCardBtn).onClick.Clear();
		((GObject)giftPackBtn).onClick.Clear();
		((GObject)storeBtn).onClick.Clear();
		((GObject)skipBtn).onClick.Clear();
		((GObject)helpBtn).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<GetWeeklyActivityResponse>("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", OnSpinActivityProgressChange);
		GameManagers.Instance.Messenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void Init()
	{
		_onClickCloseResultPanel = OnClickCloseResultPanel;
		bool selected = false;
		if (GameLocalDataManager.HasKey("SpinWeekSpinSkipBtn"))
		{
			selected = GameLocalDataManager.GetBool("SpinWeekSpinSkipBtn");
		}
		((GButton)skipBtn).selected = selected;
		InitPage();
		rotateState.SetSelectedIndex(0);
	}

	private IEnumerator Update()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			if (_isStockDirty && !_isRotate)
			{
				RenderItemCount();
			}
			UpdateRemainTime();
			yield return wait;
		}
	}

	private void InitPage()
	{
		_response = ActivityManager.SpinWeekActivity;
		if (_response != null)
		{
			if (_response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(_response.ErrorCode);
				return;
			}
			RenderDrawRewards();
			Render();
			RenderButtonNote();
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Update());
			LoadSpine();
		}
	}

	private void LoadSpine()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = (GameObject)Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		SkeletonAnimation skeletonGraphic = val.GetComponent<SkeletonAnimation>();
		SpawnManager.Instance.LoadAnimation("Goblinworker_UI_001").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				((SkeletonRenderer)skeletonGraphic).skeletonDataAsset = asset;
				((SkeletonRenderer)skeletonGraphic).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)skeletonGraphic, "skin_weektree");
				skeletonGraphic.AnimationState.SetAnimation(0, "weekactivity_tree_idle", true);
				skeletonGraphic.timeScale = 1f;
			}
		});
		val.transform.localScale = new Vector3(60f, 60f, 60f);
		val.transform.localPosition = -new Vector3(0f, 0f, 0f);
		val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val2 = new GoWrapper(val);
		((DisplayObject)val2).SetXY(0f, 0f);
		((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
		_spineAnim = skeletonGraphic;
		spineWrapper.SetNativeObject((DisplayObject)(object)val2);
	}

	private void UpdateRemainTime()
	{
		int num = (int)(_response.ActivityConfig.EndTime - GameController.Instance.GetServerTime());
		string arg = UiHelper.ParseTimeChinsesDH(num);
		((GObject)time).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("SpinWeekActivityTimeTip".ToLanguage(), arg);
	}

	private void OnClickDoSpin()
	{
		OnClickDoSpin(1);
	}

	private void OnClickDoSpinX50()
	{
		int stock = GameManagers.Instance.StockController.GetStock(_response.ActivityConfig.LotteryItemId);
		stock = Mathf.Min(stock, UI_com_SpinWeekHelper.MaxMultiLotteryCount);
		OnClickDoSpin(stock);
	}

	private async void OnClickDoSpin(int lotteryCount)
	{
		if (lotteryCount > 0 && !_isRotate)
		{
			_isRotate = true;
			DrawSpinWeeklyResponse response = await GameController.Contexts.Service<INetworkService>().DrawSpinWeekly(lotteryCount);
			if (response.ErrorCode != 0)
			{
				_isRotate = false;
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ChopAnim(response));
			}
		}
	}

	private void OnClickWeekCardBtn()
	{
		if (!_isRotate)
		{
			UnityUiService.Instance.OpenPanel(UI_popup_weekSpinCard.Name, new Dictionary<string, object>());
		}
	}

	public void OnClickGiftPackBtn()
	{
		if (!_isRotate)
		{
			UnityUiService.Instance.OpenPanel(UI_popup_weekGiftPackPanel.Name, new Dictionary<string, object>());
		}
	}

	private void OnClickStoreBtn()
	{
		if (!_isRotate)
		{
			UnityUiService.Instance.OpenPanel(UI_main_weekActivityStorePanel.Name, new Dictionary<string, object> { { "ActivityInfo", _response } });
		}
	}

	private IEnumerator ChopAnim(DrawSpinWeeklyResponse response)
	{
		if (((GObject)this).isDisposed)
		{
			yield break;
		}
		_breakCurrentSpin = false;
		UnityUiService.Instance.PreLoadPackage("WeekActivity", null);
		bool isMultiDraw = response.DrawResult.Count > 1;
		rotateState.SetSelectedIndex((!isMultiDraw) ? 1 : 2);
		Transition targetTrans = (isMultiDraw ? gacha2 : gacha1);
		bool isSkipMode = ((GButton)skipBtn).selected;
		float skipTime = targetTrans.GetLabelTime("skipMode");
		if (!isSkipMode)
		{
			string animName = (isMultiDraw ? "weekactivity_tree_2" : "weekactivity_tree_1");
			_spineAnim.AnimationState.SetAnimation(0, animName, false);
		}
		string particleName = (isMultiDraw ? "FX/Prefabs/WeekActivity_Tree_2" : "FX/Prefabs/WeekActivity_Tree_1");
		FGUIManager.Instance.AddTextSpecialEffects(vfxWrapper, particleName, new Vector3(100f, 100f, 100f));
		bool isComplete = false;
		if (!isSkipMode)
		{
			UI_ActivityPanel parent = Parent;
			parent.ETopMaskClicked = (Action)Delegate.Combine(parent.ETopMaskClicked, new Action(OnClickSkipAnim));
			Parent.SetPanelMask(isBlock: true);
			targetTrans.Play(1, 0f, 0f, skipTime, (PlayCompleteCallback)delegate
			{
				isComplete = true;
			});
			while (!isComplete && !_breakCurrentSpin)
			{
				yield return null;
			}
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			Parent.SetPanelMask(isBlock: false);
			UI_ActivityPanel parent2 = Parent;
			parent2.ETopMaskClicked = (Action)Delegate.Remove(parent2.ETopMaskClicked, new Action(OnClickSkipAnim));
		}
		isComplete = false;
		targetTrans.Play(1, 0f, skipTime, -1f, (PlayCompleteCallback)delegate
		{
			isComplete = true;
		});
		while (!isComplete)
		{
			yield return null;
		}
		if (!((GObject)this).isDisposed)
		{
			rotateState.SetSelectedIndex(3);
			_spineAnim.AnimationState.SetAnimation(0, "weekactivity_tree_idle", true);
			UI_com_SpinWeekHelper.ShowSpinResult(this, response, _response, _onClickCloseResultPanel);
		}
	}

	private void RenderDrawRewards()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		List<SpinWeekActivityPayload.ExhibitPrize> exhibitPrizes = _response.ActivityConfig.ExhibitPrizes;
		for (int i = 0; i < ((GComponent)rewardIcons).numChildren; i++)
		{
			GObject childAt = ((GComponent)rewardIcons).GetChildAt(i);
			GLoader val = (GLoader)(object)((childAt is GLoader) ? childAt : null);
			if (val != null)
			{
				UI_rewardBtnWeekTree uI_rewardBtnWeekTree = (UI_rewardBtnWeekTree)(object)val.component;
				int index = i % exhibitPrizes.Count;
				SpinWeekActivityPayload.ExhibitPrize exhibitPrize = exhibitPrizes[index];
				KeyValuePair<string, int> keyValuePair = exhibitPrize.PrizeContent.First();
				string key = keyValuePair.Key;
				int value = keyValuePair.Value;
				((GObject)uI_rewardBtnWeekTree.Num).text = $"x{value}";
				FGUIManager.Instance.SetItemIconAndFrame(uI_rewardBtnWeekTree.itemIcon, key, null, "", frameVisible: false);
				uI_rewardBtnWeekTree.itemIcon.InitMaterialIntroductionBtn(key);
				bool flag = exhibitPrize.Rarity == 0;
				uI_rewardBtnWeekTree.Quality.SetSelectedIndex(flag ? 1 : 0);
			}
		}
	}

	private void Render()
	{
		RenderItemCount();
		UI_com_SpinWeekHelper.RenderAnnouncement((GComponent)(object)this, null, _response, giftRecordList);
	}

	private void RenderItemCount()
	{
		_isStockDirty = false;
		int stock = GameManagers.Instance.StockController.GetStock(_response.ActivityConfig.ExchangeItemId);
		((GObject)storeBtn.ticketCount).text = stock.ToString();
		storeBtn.ticketIcon.url = UiHelper.GetItemIconPath(_response.ActivityConfig.ExchangeItemId);
		UI_com_SpinWeekHelper.InitExchangeRateText(exchangeRateText, _response.ActivityConfig.ExchangeRate, _response.ActivityConfig.LotteryItemId, _response.ActivityConfig.ExchangeItemId);
		int stock2 = GameManagers.Instance.StockController.GetStock(_response.ActivityConfig.LotteryItemId);
		costIcon1.url = UiHelper.GetItemIconPath(_response.ActivityConfig.LotteryItemId);
		costIcon2.url = costIcon1.url;
		((GObject)spinBtn).enabled = stock2 > 0;
		int num = ((stock2 < UI_com_SpinWeekHelper.MaxMultiLotteryCount && stock2 > 0) ? stock2 : UI_com_SpinWeekHelper.MaxMultiLotteryCount);
		((GObject)spinBtnX50).enabled = stock2 > 1;
		((GObject)cost1).text = "x1";
		((GObject)cost2).text = $"x{num}";
		((GObject)spinBtnX50.drawTitle).text = "SpinWeekSpinX50BtnText".ToLanguage().Format(num);
		Parent.RefreshCurrencyGroup();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		_isStockDirty = true;
	}

	private void OnSpinActivityProgressChange(GetWeeklyActivityResponse response)
	{
		GetWeeklyActivityResponse response2 = _response;
		_response = response;
		RenderButtonNote();
		UI_com_SpinWeekHelper.RenderAnnouncement((GComponent)(object)this, response2, _response, giftRecordList);
	}

	private void RenderButtonNote()
	{
		((GObject)giftPackBtn.note).visible = _response.HasNotPurchaseGiftPack();
		((GObject)weekCardBtn.note).visible = _response.HasNotClaimedWeekCard();
	}

	private void OnClickSkipAnim()
	{
		_breakCurrentSpin = true;
	}

	private void OnClickSkipBtn()
	{
		GameLocalDataManager.SetBool("SpinWeekSpinSkipBtn", ((GButton)skipBtn).selected);
	}

	private void OnClickHelpTip()
	{
		UnityUiService.Instance.OpenPanel(UI_popup_probabilityDescription.Name, new Dictionary<string, object>());
	}

	private void OnClickCloseResultPanel()
	{
		_isRotate = false;
	}
}
