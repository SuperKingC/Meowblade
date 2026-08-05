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
using UI.Tips;
using UI.WeekActivity;
using UnityEngine;

namespace UI.GameActivity;

public class UI_com_SpinWeekSpin : GComponent, ISpinWheelPage
{
	public Controller rotateState;

	public GImage n20;

	public GImage n19;

	public UI_skipBtn skipBtn;

	public GImage n40;

	public UI_com_SpinItemGroup itemGroup;

	public UI_storeBtn storeBtn;

	public UI_drawBtn1 spinBtn;

	public UI_drawBtn2 spinBtnX50;

	public GImage n26;

	public GRichTextField exchangeRateText;

	public GList giftRecordList;

	public GImage n28;

	public UI_giftPackBtn giftPackBtn;

	public UI_weekCardBtn weekCardBtn;

	public GImage n29;

	public GImage n42;

	public GImage n33;

	public GMovieClip n32;

	public GImage n21;

	public GImage n24;

	public GMovieClip n25;

	public UI_probabilityBtn helpBtn;

	public GImage n31;

	public GLoader costIcon1;

	public GTextField cost1;

	public GGroup n36;

	public GLoader costIcon2;

	public GTextField cost2;

	public GGroup n39;

	public GTextField time;

	public GGraph flyAnim;

	public Transition t7;

	public Transition t8;

	public Transition t9;

	public Transition t10;

	public const string URL = "ui://29q48tv6gzy8f54";

	public static string Name = "UI_com_SpinWeekSpin";

	private const string SkipBtnKey = "SpinWeekSpinSkipBtn";

	private List<GLoader> _loaderList;

	private List<UI_rewardBtnWeekSpin> _iconList;

	private List<Vector3> _loaderPos;

	private bool _breakCurrentSpin;

	private GetWeeklyActivityResponse _response;

	private bool _isRotate;

	private bool _isStockDirty;

	private Action _onClickCloseResultPanel;

	public UI_ActivityPanel Parent { get; set; }

	public GGraph FlyAnim => flyAnim;

	public GLoader FlyAnimDest => storeBtn.ticketIcon;

	public UI_skipBtn SkipBtn => skipBtn;

	public UI_storeBtn StoreBtn => storeBtn;

	public static string GetURL()
	{
		return "ui://29q48tv6gzy8f54";
	}

	public static UI_com_SpinWeekSpin CreateInstance()
	{
		return (UI_com_SpinWeekSpin)(object)UIPackage.CreateObject("GameActivity", "com_SpinWeekSpin");
	}

	public static UI_com_SpinWeekSpin CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpinWeekSpin).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gzy8f54", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		rotateState = ((GComponent)this).GetController("rotateState");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		skipBtn = (UI_skipBtn)(object)((GComponent)this).GetChild("skipBtn");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		itemGroup = (UI_com_SpinItemGroup)(object)((GComponent)this).GetChild("itemGroup");
		storeBtn = (UI_storeBtn)(object)((GComponent)this).GetChild("storeBtn");
		spinBtn = (UI_drawBtn1)(object)((GComponent)this).GetChild("spinBtn");
		spinBtnX50 = (UI_drawBtn2)(object)((GComponent)this).GetChild("spinBtnX50");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		exchangeRateText = (GRichTextField)((GComponent)this).GetChild("exchangeRateText");
		giftRecordList = (GList)((GComponent)this).GetChild("giftRecordList");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		giftPackBtn = (UI_giftPackBtn)(object)((GComponent)this).GetChild("giftPackBtn");
		weekCardBtn = (UI_weekCardBtn)(object)((GComponent)this).GetChild("weekCardBtn");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n32 = (GMovieClip)((GComponent)this).GetChild("n32");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GMovieClip)((GComponent)this).GetChild("n25");
		helpBtn = (UI_probabilityBtn)(object)((GComponent)this).GetChild("helpBtn");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		costIcon1 = (GLoader)((GComponent)this).GetChild("costIcon1");
		cost1 = (GTextField)((GComponent)this).GetChild("cost1");
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		costIcon2 = (GLoader)((GComponent)this).GetChild("costIcon2");
		cost2 = (GTextField)((GComponent)this).GetChild("cost2");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		time = (GTextField)((GComponent)this).GetChild("time");
		flyAnim = (GGraph)((GComponent)this).GetChild("flyAnim");
		t7 = ((GComponent)this).GetTransition("t7");
		t8 = ((GComponent)this).GetTransition("t8");
		t9 = ((GComponent)this).GetTransition("t9");
		t10 = ((GComponent)this).GetTransition("t10");
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
		_iconList = new List<UI_rewardBtnWeekSpin>();
		_loaderList = new List<GLoader>();
		_onClickCloseResultPanel = OnClickCloseResultPanel;
		GObject[] children = ((GComponent)itemGroup).GetChildren();
		foreach (GObject val in children)
		{
			GLoader val2 = (GLoader)(object)((val is GLoader) ? val : null);
			if (val2 != null)
			{
				_iconList.Add(val2.component as UI_rewardBtnWeekSpin);
				_loaderList.Add(val2);
			}
		}
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
			RenderSpinWheel(-1);
			Render();
			RenderButtonNote();
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Update());
		}
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
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SpinAnim(response));
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

	private IEnumerator SpinAnim(DrawSpinWeeklyResponse response)
	{
		if (((GObject)this).isDisposed)
		{
			yield break;
		}
		_breakCurrentSpin = false;
		float startTime = Time.time;
		int prizeIndex = response.DrawResult[0];
		int maxRarity = _response.ActivityConfig.ExhibitPrizes[prizeIndex].Rarity;
		foreach (int prize in response.DrawResult)
		{
			SpinWeekActivityPayload.ExhibitPrize config = _response.ActivityConfig.ExhibitPrizes[prize];
			if (config.Rarity < maxRarity)
			{
				prizeIndex = prize;
				maxRarity = config.Rarity;
			}
		}
		rotateState.SetSelectedIndex(1);
		if (!((GButton)skipBtn).selected)
		{
			UI_ActivityPanel parent = Parent;
			parent.ETopMaskClicked = (Action)Delegate.Combine(parent.ETopMaskClicked, new Action(OnClickSkipAnim));
			Parent.SetPanelMask(isBlock: true);
			bool isMultiDraw = response.DrawResult.Count > 1;
			float totalTime = (isMultiDraw ? 2f : 1f);
			float rotateSpeed = (isMultiDraw ? 3f : 1f);
			while (!((GObject)this).isDisposed)
			{
				float animTime = Time.time - startTime;
				bool timeOver = animTime > totalTime;
				((GObject)itemGroup.rollingMask).rotation = animTime * 360f * rotateSpeed;
				if (_breakCurrentSpin || timeOver)
				{
					break;
				}
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
		if (!((GObject)this).isDisposed)
		{
			RenderSpinWheel(prizeIndex);
			rotateState.SetSelectedIndex(2);
			yield return (object)new WaitForSeconds(0.5f);
			if (!((GObject)this).isDisposed)
			{
				UI_com_SpinWeekHelper.ShowSpinResult(this, response, _response, _onClickCloseResultPanel);
			}
		}
	}

	private void RenderSpinWheel(int index)
	{
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)this).isDisposed)
		{
			return;
		}
		bool flag = index >= 0;
		List<SpinWeekActivityPayload.ExhibitPrize> exhibitPrizes = _response.ActivityConfig.ExhibitPrizes;
		index = Mathf.Clamp(index, 0, exhibitPrizes.Count - 1);
		int count = _iconList.Count;
		if (_loaderPos == null)
		{
			_loaderPos = new List<Vector3>();
			for (int i = 0; i < count; i++)
			{
				UI_rewardBtnWeekSpin uI_rewardBtnWeekSpin = _iconList[i];
				int index2 = i % exhibitPrizes.Count;
				SpinWeekActivityPayload.ExhibitPrize exhibitPrize = exhibitPrizes[index2];
				KeyValuePair<string, int> keyValuePair = exhibitPrize.PrizeContent.First();
				string key = keyValuePair.Key;
				int value = keyValuePair.Value;
				((GObject)uI_rewardBtnWeekSpin.num).text = value.ToString();
				uI_rewardBtnWeekSpin.icon.url = UiHelper.GetItemIconPath(key);
				uI_rewardBtnWeekSpin.icon.InitMaterialIntroductionBtn(key);
				_loaderPos.Add(((GObject)_loaderList[i]).position);
				bool flag2 = exhibitPrize.Rarity == 0;
				uI_rewardBtnWeekSpin.Type.SetSelectedIndex(flag2 ? 1 : 0);
			}
		}
		for (int j = 0; j < count; j++)
		{
			int index3 = (count - index + j + 6) % count;
			GLoader val = _loaderList[j];
			((GObject)val).position = _loaderPos[index3];
			UI_rewardBtnWeekSpin uI_rewardBtnWeekSpin2 = _iconList[j];
			uI_rewardBtnWeekSpin2.State.SetSelectedIndex(0);
		}
		if (flag)
		{
			UI_rewardBtnWeekSpin uI_rewardBtnWeekSpin3 = _iconList[index];
			uI_rewardBtnWeekSpin3.State.SetSelectedIndex(1);
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
