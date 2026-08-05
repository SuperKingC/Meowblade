using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.AddCredit;
using UI.BlackMarketer;
using UI.GiftBag;
using UI.LegendItemDungeon;
using UI.LegendItemInfo;
using UI.LegendItemsStore;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemsDraw;

public class UI_LegendItemsDrawPanel : GComponent, IUiController
{
	private class LegendCard
	{
		public UI_LegendItemLoader Loader;

		private GTweener fadeTweener;

		private GTweener moveTweener;

		public GTweener CardMoveTweener;

		public LegendItemUi LegendItem;

		public Vector2 EndPos;

		private string MissibleName;

		private string ExplotionName;

		private const float MoveTime = 0.3f;

		private bool isFliped = false;

		public LegendCard(UI_LegendItemLoader loader)
		{
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			Loader = loader;
			string[] array = ((GObject)loader).data.ToString().Split(',');
			EndPos = new Vector2(NumericParser.Float(array[0]), NumericParser.Float(array[1]));
		}

		public void CardInit(LegendItemUi itemUi)
		{
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			isFliped = false;
			LegendItem = itemUi;
			((GObject)Loader).touchable = true;
			((GObject)Loader).visible = true;
			((GObject)Loader).alpha = 0f;
			((GObject)Loader).SetXY(960f, 610f);
			Loader.Icon.url = "ui://xogvri2hs2vzl";
			Loader.Icon.component.GetController("Type").selectedIndex = LegendItem.LegendItemData.Data.Rarity - 1;
			FGUIManager.Instance.AddTextSpecialEffects(Loader.Icon.component.GetChild("SfxBack").asGraph, "ui_active_glow_orange", new Vector3(250f, 250f, 250f));
			switch (LegendItem.LegendItemData.Data.Rarity)
			{
			case 1:
			case 2:
			case 3:
				MissibleName = "ui_missile_treasure_1";
				ExplotionName = "ui_explotion_treasure_1";
				break;
			case 4:
				MissibleName = "ui_missile_treasure_2";
				ExplotionName = "ui_explotion_treasure_2";
				break;
			case 5:
				MissibleName = "ui_missile_treasure_3";
				ExplotionName = "ui_explotion_treasure_3";
				break;
			}
			FGUIManager.Instance.AddTextSpecialEffects(Loader.MeteorSfxBack, MissibleName, new Vector3(50f, 50f, 50f), "Default", 0.5f, delegate(GameObject treasureMissible)
			{
				UiHelper.HideUiSfx(Loader.MeteorSfxBack, treasureMissible, 0.3f);
			});
		}

		public void CardMove()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Expected O, but got Unknown
			fadeTweener = ((GObject)Loader).TweenFade(1f, 0.3f);
			moveTweener = ((GObject)Loader).TweenMove(EndPos, 0.3f).OnComplete((GTweenCallback)delegate
			{
				//IL_0026: Unknown result type (might be due to invalid IL or missing references)
				FGUIManager.Instance.AddTextSpecialEffects(Loader.FlickerSfxBack, ExplotionName, new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureExplosion)
				{
					UiHelper.HideUiSfx(Loader.FlickerSfxBack, treasureExplosion, 1f);
				});
			});
		}

		public void SetEndState()
		{
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			GTweener cardMoveTweener = CardMoveTweener;
			if (cardMoveTweener != null)
			{
				cardMoveTweener.Kill(false);
			}
			CardMoveTweener = null;
			GTweener obj = fadeTweener;
			if (obj != null)
			{
				obj.Kill(false);
			}
			fadeTweener = null;
			GTweener obj2 = moveTweener;
			if (obj2 != null)
			{
				obj2.Kill(false);
			}
			moveTweener = null;
			((GObject)Loader).alpha = 1f;
			((GObject)Loader).xy = EndPos;
		}

		public void Dispose()
		{
			GTweener cardMoveTweener = CardMoveTweener;
			if (cardMoveTweener != null)
			{
				cardMoveTweener.Kill(false);
			}
			CardMoveTweener = null;
			GTweener obj = fadeTweener;
			if (obj != null)
			{
				obj.Kill(false);
			}
			fadeTweener = null;
			GTweener obj2 = moveTweener;
			if (obj2 != null)
			{
				obj2.Kill(false);
			}
			moveTweener = null;
			LegendItem = null;
		}

		private void LoadFrontUrl()
		{
		}

		public void FlipCard()
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			if (isFliped)
			{
				return;
			}
			isFliped = true;
			if (!((GObject)Loader).touchable || Loader == null || ((GObject)Loader).isDisposed)
			{
				return;
			}
			SetEndState();
			Loader.Draw.Stop();
			((GObject)Loader).touchable = false;
			Loader.Draw.SetHook("middle", (TransitionHook)delegate
			{
				//IL_0081: Unknown result type (might be due to invalid IL or missing references)
				if (Loader != null && !((GObject)Loader).isDisposed)
				{
					Loader.Icon.url = "ui://xogvri2hs2vzm";
					GButton asButton = Loader.Icon.component.GetChild("Content").asButton;
					FGUIManager.Instance.AddTextSpecialEffects(((GComponent)asButton).GetChild("SfxBack").asGraph, "ui_active_glow_orange", new Vector3(250f, 250f, 250f));
					((GObject)asButton).scaleX = -1f;
					RenderLegendItemContent(asButton, LegendItem);
				}
			});
			Loader.Draw.Play(new PlayCompleteCallback(LegendItemsDrawPanel.JudgeShowAllCards));
		}

		public void CardDisappear()
		{
			((GObject)Loader).alpha = 0f;
			((GObject)Loader).visible = false;
		}
	}

	public Controller PageController;

	public Controller TipController;

	public GLoader background;

	public UI_battery n17;

	public UI_curtainMain n16;

	public GImage n24;

	public GImage n25;

	public UI_curtainTop n15;

	public UI_trombone n18;

	public UI_trombone n19;

	public UI_trombone n20;

	public UI_trombone n21;

	public UI_trombone n22;

	public UI_trombone n23;

	public GGroup Backs;

	public UI_Title Title;

	public GButton BackBtn;

	public GButton Help;

	public GComponent diamondAddBtn;

	public GComponent addTicketBtn;

	public GComponent addCouponBtn;

	public GGroup Titles;

	public GGraph SlotMachineBack;

	public GGraph MacineSfxBack;

	public GGraph MainSfxBack;

	public GGroup MachineBacks;

	public GGraph MerchantPoint2;

	public GGraph MerchantPoint1;

	public GGraph MerchantBack;

	public UI_LegendItemLoader LegendItemLoader0;

	public UI_LegendItemLoader LegendItemLoader1;

	public UI_LegendItemLoader LegendItemLoader2;

	public UI_LegendItemLoader LegendItemLoader3;

	public UI_LegendItemLoader LegendItemLoader4;

	public UI_LegendItemLoader LegendItemLoader5;

	public UI_LegendItemLoader LegendItemLoader6;

	public UI_LegendItemLoader LegendItemLoader7;

	public UI_LegendItemLoader LegendItemLoader8;

	public UI_LegendItemLoader LegendItemLoader9;

	public UI_runningBtn runningBtn;

	public GLoader runningTicketIcon;

	public GTextField runningCost;

	public GGroup Costs;

	public GTextField tip;

	public UI_ScoreProgress ScoreProgress;

	public UI_LegendItemStore LegendItemStore;

	public GGraph DialogMask;

	public UI_ResultDialog ResultDialog;

	public UI_HelpPanel HelpPanel;

	public GGraph slideFloor;

	public GGraph InterruptBack;

	public Transition ShowTip;

	public Transition ShowResults;

	public Transition PopupResults;

	public const string URL = "ui://xogvri2hi0qy0";

	public static string Name = "UI_LegendItemsDrawPanel";

	private List<string> skeletonList = new List<string>();

	public static UI_LegendItemsDrawPanel LegendItemsDrawPanel;

	private const string MerchantIdle2 = "idle2";

	private const string MerchantWorking = "work_treasure";

	private const float MerchantWorkTime = 1.333f;

	private const string MerchantIdle = "idle";

	private const string MerchantRotating = "rotate";

	private const string MerchantSpine = "merchant2";

	private const float MerchantSize = 100f;

	private const string MerchantSkin = "skin1";

	private SkeletonAnimation merchant;

	private const string UiTreasurePortal = "ui_treasuregacha_portal";

	private const string TreasureExplosion1 = "ui_treasuregacha_portal_explosion_1";

	private const string TreasureExplosion2 = "ui_treasuregacha_portal_explosion_2";

	private const string MachineIdle = "idle";

	private const string MachineOpen = "open";

	private const float OpenTime = 1.1f;

	private const float MachineDisappearDelay = 0.5f;

	private const float MachineOpenDelay = 0.8f;

	private const string MachineSpine = "arcade_machine";

	private const float MachineSize = 100f;

	private const string MachineSkin = "default";

	private SkeletonAnimation machine;

	private const int DrawCounts = 10;

	private List<LegendCard> legendCards = new List<LegendCard>();

	private SwipeGesture _swipeGesture;

	public List<KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>> cardAndPosrangeList = new List<KeyValuePair<GButton, KeyValuePair<Vector2, Vector2>>>();

	private bool isMouseMoving = false;

	private int CardNum;

	public List<string> textureList = new List<string>();

	private Activity legendItemLottery;

	private string generalTicketId;

	private string specialTicketId;

	public UI_ProductionNumFloating NumFloatingGem;

	public UI_ProductionNumFloating NumFloatingGem1;

	public UI_ProductionNumFloating NumFloatingGem2;

	private bool isDrawing = false;

	private List<KeyValuePair<Bonus, int>> awardList = new List<KeyValuePair<Bonus, int>>();

	private bool ScoreProgressVisible;

	private Coroutine DrawProcess;

	public static string GetURL()
	{
		return "ui://xogvri2hi0qy0";
	}

	public static UI_LegendItemsDrawPanel CreateInstance()
	{
		return (UI_LegendItemsDrawPanel)(object)UIPackage.CreateObject("LegendItemsDraw", "LegendItemsDrawPanel");
	}

	public static UI_LegendItemsDrawPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemsDrawPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://xogvri2hi0qy0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		TipController = ((GComponent)this).GetController("TipController");
		background = (GLoader)((GComponent)this).GetChild("background");
		n17 = (UI_battery)(object)((GComponent)this).GetChild("n17");
		n16 = (UI_curtainMain)(object)((GComponent)this).GetChild("n16");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n15 = (UI_curtainTop)(object)((GComponent)this).GetChild("n15");
		n18 = (UI_trombone)(object)((GComponent)this).GetChild("n18");
		n19 = (UI_trombone)(object)((GComponent)this).GetChild("n19");
		n20 = (UI_trombone)(object)((GComponent)this).GetChild("n20");
		n21 = (UI_trombone)(object)((GComponent)this).GetChild("n21");
		n22 = (UI_trombone)(object)((GComponent)this).GetChild("n22");
		n23 = (UI_trombone)(object)((GComponent)this).GetChild("n23");
		Backs = (GGroup)((GComponent)this).GetChild("Backs");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Help = (GButton)((GComponent)this).GetChild("Help");
		diamondAddBtn = (GComponent)((GComponent)this).GetChild("diamondAddBtn");
		addTicketBtn = (GComponent)((GComponent)this).GetChild("addTicketBtn");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		Titles = (GGroup)((GComponent)this).GetChild("Titles");
		SlotMachineBack = (GGraph)((GComponent)this).GetChild("SlotMachineBack");
		MacineSfxBack = (GGraph)((GComponent)this).GetChild("MacineSfxBack");
		MainSfxBack = (GGraph)((GComponent)this).GetChild("MainSfxBack");
		MachineBacks = (GGroup)((GComponent)this).GetChild("MachineBacks");
		MerchantPoint2 = (GGraph)((GComponent)this).GetChild("MerchantPoint2");
		MerchantPoint1 = (GGraph)((GComponent)this).GetChild("MerchantPoint1");
		MerchantBack = (GGraph)((GComponent)this).GetChild("MerchantBack");
		LegendItemLoader0 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader0");
		LegendItemLoader1 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader1");
		LegendItemLoader2 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader2");
		LegendItemLoader3 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader3");
		LegendItemLoader4 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader4");
		LegendItemLoader5 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader5");
		LegendItemLoader6 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader6");
		LegendItemLoader7 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader7");
		LegendItemLoader8 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader8");
		LegendItemLoader9 = (UI_LegendItemLoader)(object)((GComponent)this).GetChild("LegendItemLoader9");
		runningBtn = (UI_runningBtn)(object)((GComponent)this).GetChild("runningBtn");
		runningTicketIcon = (GLoader)((GComponent)this).GetChild("runningTicketIcon");
		runningCost = (GTextField)((GComponent)this).GetChild("runningCost");
		Costs = (GGroup)((GComponent)this).GetChild("Costs");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://xogvri2hi0qy0".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		ScoreProgress = (UI_ScoreProgress)(object)((GComponent)this).GetChild("ScoreProgress");
		LegendItemStore = (UI_LegendItemStore)(object)((GComponent)this).GetChild("LegendItemStore");
		DialogMask = (GGraph)((GComponent)this).GetChild("DialogMask");
		ResultDialog = (UI_ResultDialog)(object)((GComponent)this).GetChild("ResultDialog");
		HelpPanel = (UI_HelpPanel)(object)((GComponent)this).GetChild("HelpPanel");
		slideFloor = (GGraph)((GComponent)this).GetChild("slideFloor");
		InterruptBack = (GGraph)((GComponent)this).GetChild("InterruptBack");
		ShowTip = ((GComponent)this).GetTransition("ShowTip");
		ShowResults = ((GComponent)this).GetTransition("ShowResults");
		PopupResults = ((GComponent)this).GetTransition("PopupResults");
	}

	public void BeforeDestroy()
	{
		LegendItemsDrawPanel = null;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		LegendItemsDrawPanel = this;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		SetBuildingName();
		ScoreProgressVisible = true;
		((GObject)ScoreProgress).visible = ScoreProgressVisible;
		ILRequestHelper<GetLegendItemLotteryActivityProgressesResponse>.Request((EventContext)null, (Func<Task<GetLegendItemLotteryActivityProgressesResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetLegendItemLotteryActivityProgresses()), (Action<GetLegendItemLotteryActivityProgressesResponse>)delegate(GetLegendItemLotteryActivityProgressesResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Dictionary<string, LotteryActivityProgress> legendItemLotteryActivityProgresses = GameManagers.Instance.ActivityManager.LegendItemLotteryActivityProgresses;
				foreach (KeyValuePair<string, int> scoreOfLotteryActivity in response.ScoreOfLotteryActivities)
				{
					if (legendItemLotteryActivityProgresses.TryGetValue(scoreOfLotteryActivity.Key, out var value))
					{
						value.Score = scoreOfLotteryActivity.Value;
					}
					else
					{
						legendItemLotteryActivityProgresses.Add(scoreOfLotteryActivity.Key, new LotteryActivityProgress(scoreOfLotteryActivity.Key)
						{
							Score = scoreOfLotteryActivity.Value
						});
					}
				}
				GetDrawActivity();
				SetRightClickBtn();
				UpdateCouponNum(generalTicketId);
				UpdateTicketNum(specialTicketId);
				MainUiInit();
			}
		});
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)addCouponBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(AddCoupon));
		((GObject)addTicketBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(AddTicket));
		((GObject)LegendItemStore).onClick.Add(new EventCallback0(OpenLegendItemsStore));
		((GObject)ResultDialog.againBtn).onClick.Add(new EventCallback1(DrawAgain));
		((GObject)ResultDialog.confirmBtn).onClick.Add(new EventCallback1(ReturnInitPage));
		((GObject)Help).onClick.Add(new EventCallback0(ShowHelpPanel));
		((GObject)HelpPanel.Mask).onClick.Add(new EventCallback0(CloseHelpPanel));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)addCouponBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(AddCoupon));
		((GObject)addTicketBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(AddTicket));
		((GObject)LegendItemStore).onClick.Remove(new EventCallback0(OpenLegendItemsStore));
		((GObject)ResultDialog.againBtn).onClick.Remove(new EventCallback1(DrawAgain));
		((GObject)ResultDialog.confirmBtn).onClick.Remove(new EventCallback1(ReturnInitPage));
		((GObject)Help).onClick.Remove(new EventCallback0(ShowHelpPanel));
		((GObject)HelpPanel.Mask).onClick.Remove(new EventCallback0(CloseHelpPanel));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	private void ShowHelpPanel()
	{
		((GObject)HelpPanel).visible = true;
		HelpPanel.ShowDialog.Play();
	}

	private void CloseHelpPanel()
	{
		((GObject)HelpPanel).visible = false;
	}

	private void End()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		((DisplayObject)Stage.inst).onTouchBegin.Remove(new EventCallback1(LegendCardOnTouchBegin));
		((DisplayObject)Stage.inst).onTouchMove.Remove(new EventCallback1(LegendCardOnTouchMove));
		((DisplayObject)Stage.inst).onTouchEnd.Remove(new EventCallback1(LegendCardOnTouchEnd));
		for (int i = 0; i < legendCards.Count; i++)
		{
			legendCards[i].Dispose();
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int j = 0; j < textureList.Count; j++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[j]);
		}
		for (int k = 0; k < skeletonList.Count; k++)
		{
			SpawnManager.Instance.UnloadAnimation(skeletonList[k]);
		}
		UI_BlackMarketerPanel.BlackMarketerPanel?.UpdateItemCard(Name);
	}

	private void SetRightClickBtn()
	{
		if (!string.IsNullOrWhiteSpace(specialTicketId) && specialTicketId != generalTicketId)
		{
			((GObject)addTicketBtn).visible = true;
		}
		else
		{
			((GObject)addTicketBtn).visible = false;
		}
		if (!string.IsNullOrWhiteSpace(generalTicketId))
		{
			addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(generalTicketId);
		}
		if (!string.IsNullOrWhiteSpace(specialTicketId))
		{
			addTicketBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(specialTicketId);
		}
	}

	private void UpdateDiamondNum()
	{
		((GObject)diamondAddBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Gem").ToString();
	}

	private void UpdateCouponNum(string itemId)
	{
		if (!string.IsNullOrWhiteSpace(itemId))
		{
			((GObject)addCouponBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(itemId).ToString();
		}
	}

	private void UpdateTicketNum(string itemId)
	{
		if (!string.IsNullOrWhiteSpace(itemId))
		{
			((GObject)addTicketBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(itemId).ToString();
		}
	}

	private void LoadMerchantSpine()
	{
		merchant = UiHelper.SpineLoad(MerchantBack, "merchant2", 100f, "skin1", "idle2", skeletonList);
		((GObject)MerchantBack).scaleX = -1f;
	}

	private void MerchantInit()
	{
		((GObject)MerchantBack).visible = true;
		((GObject)MerchantBack).SetXY(((GObject)MerchantPoint1).x, ((GObject)MerchantPoint1).y);
		merchant.AnimationName = "idle2";
		merchant.loop = true;
	}

	private void MerchantWork()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		merchant.AnimationName = "work_treasure";
		merchant.loop = true;
		((GComponent)(object)this).SetTimeout(1.333f).OnComplete((GTweenCallback)delegate
		{
			merchant.AnimationName = "idle";
			merchant.loop = true;
		});
	}

	private void MerchantRotate()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		merchant.AnimationName = "rotate";
		((GObject)MerchantBack).TweenMove(((GObject)MerchantPoint2).xy, 0.3f).OnComplete((GTweenCallback)delegate
		{
			((GObject)MerchantBack).visible = false;
		});
	}

	private void LoadMachineSpine()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		machine = UiHelper.SpineLoad(SlotMachineBack, "arcade_machine", 100f, "default", "idle", skeletonList);
		FGUIManager.Instance.AddTextSpecialEffects(MacineSfxBack, "ui_treasuregacha_portal", new Vector3(100f, 100f, 100f));
	}

	private void MachineInit()
	{
		((GObject)SlotMachineBack).visible = true;
		((GObject)MacineSfxBack).visible = true;
		((GObject)MainSfxBack).visible = true;
		machine.state.ClearTracks();
		machine.state.AddAnimation(0, "idle", true, 0f);
	}

	private void MachineOpening()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)(object)this).SetTimeout(0.8f).OnComplete((GTweenCallback)delegate
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(MainSfxBack, "ui_treasuregacha_portal_explosion_1", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject treasureExplosion)
			{
				UiHelper.HideUiSfx(MainSfxBack, treasureExplosion, 1f);
			});
		});
		machine.state.AddAnimation(1, "open", false, 0f);
		((GComponent)(object)this).SetTimeout(1.1f).OnComplete((GTweenCallback)delegate
		{
			machine.state.ClearTracks();
			machine.state.AddAnimation(0, "idle", true, 0f);
		});
	}

	private void MachineDisappear()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		FGUIManager.Instance.AddTextSpecialEffects(MainSfxBack, "ui_treasuregacha_portal_explosion_2", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject treasureExplosion)
		{
			UiHelper.HideUiSfx(MainSfxBack, treasureExplosion, 1.5f);
		});
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			((GObject)SlotMachineBack).visible = false;
			((GObject)MacineSfxBack).visible = false;
			((GObject)MainSfxBack).visible = false;
		});
	}

	private void LoadLegendCards()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		for (int i = 0; i < 10; i++)
		{
			UI_LegendItemLoader loader = ((GComponent)this).GetChild($"LegendItemLoader{i}") as UI_LegendItemLoader;
			legendCards.Add(new LegendCard(loader));
			((GObject)legendCards[i].Loader.Icon).touchable = false;
			((GObject)legendCards[i].Loader).data = i;
			((GObject)legendCards[i].Loader).onClick.Set(new EventCallback1(LegendCardsClick));
		}
		((DisplayObject)Stage.inst).onTouchBegin.Add(new EventCallback1(LegendCardOnTouchBegin));
		((DisplayObject)Stage.inst).onTouchMove.Add(new EventCallback1(LegendCardOnTouchMove));
		((DisplayObject)Stage.inst).onTouchEnd.Add(new EventCallback1(LegendCardOnTouchEnd));
	}

	public static void RenderLegendItemContent(GButton btn, LegendItemUi legendItem)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		if (btn != null && !((GObject)btn).isDisposed)
		{
			string url = $"ui://PublicResources/frame_treasure_square_{legendItem.LegendItemData.Data.Rarity}";
			((GComponent)btn).GetChild("FrameIcon").asLoader.url = url;
			string icon = legendItem.LegendItemData.Data.Icon;
			((GComponent)btn).GetChild("Icon").asLoader.LoadArmsIcon(icon);
			((GComponent)btn).GetController("ClassController").selectedIndex = legendItem.LegendItemData.Data.Rarity - 1;
			if (((GComponent)btn).GetController("Type").selectedIndex == 1)
			{
				((GComponent)btn).GetChild("name").asTextField.color = Color32.op_Implicit(UiHelper.colorItemList[legendItem.LegendItemData.Data.Rarity - 1]);
				((GComponent)btn).GetChild("name").text = legendItem.LegendItemData.Data.Name;
			}
		}
	}

	private void MainUiInit()
	{
		((GObject)InterruptBack).touchable = false;
		((GObject)ResultDialog).visible = false;
		((GObject)DialogMask).alpha = 0f;
		((GObject)addTicketBtn).alpha = 1f;
		((GObject)addCouponBtn).alpha = 1f;
		LoadMachineSpine();
		LoadMerchantSpine();
		LoadLegendCards();
		((GObject)Costs).visible = true;
		((GObject)ScoreProgress).visible = ScoreProgressVisible;
		((GObject)LegendItemStore).visible = true;
	}

	private void SkipDrawProcess()
	{
		((GObject)InterruptBack).touchable = false;
		FGUIManager.Instance.CloseIEnumerator(DrawProcess);
		((GObject)Costs).visible = false;
		((GObject)ScoreProgress).visible = false;
		((GObject)LegendItemStore).visible = false;
		((GObject)MerchantBack).visible = false;
		((GObject)SlotMachineBack).visible = false;
		((GObject)MacineSfxBack).visible = false;
		((GObject)MainSfxBack).visible = false;
		for (int i = 0; i < legendCards.Count; i++)
		{
			legendCards[i].SetEndState();
		}
		TipController.selectedIndex = 1;
		((GObject)tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText185") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText186");
	}

	private IEnumerator PlayDrawProcess()
	{
		((GObject)Costs).visible = false;
		((GObject)ScoreProgress).visible = false;
		((GObject)LegendItemStore).visible = false;
		MachineOpening();
		MerchantWork();
		yield return (object)new WaitForSeconds(1.5f);
		for (int i = 0; i < legendCards.Count; i++)
		{
			int cardIndex = i;
			legendCards[cardIndex].CardMoveTweener = ((GComponent)(object)legendCards[cardIndex].Loader).SetTimeout((float)cardIndex * 0.3f).OnComplete((GTweenCallback)delegate
			{
				legendCards[cardIndex].CardMove();
			});
		}
		yield return (object)new WaitForSeconds(0.15f);
		MerchantRotate();
		yield return (object)new WaitForSeconds(3f);
		MachineDisappear();
		TipController.selectedIndex = 1;
		((GObject)InterruptBack).touchable = false;
		SkipDrawProcess();
	}

	private void ShowDrawResult()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		((GObject)InterruptBack).touchable = false;
		for (int i = 0; i < legendCards.Count; i++)
		{
			legendCards[i].CardDisappear();
		}
		((GObject)DialogMask).alpha = 0f;
		((GObject)ResultDialog).visible = true;
		((GObject)ResultDialog).touchable = false;
		ResultDialog.legendItems.itemRenderer = new ListItemRenderer(RenderLegendItem);
		ResultDialog.legendItems.numItems = legendCards.Count;
		PopupResults.Play((PlayCompleteCallback)delegate
		{
			TipController.selectedIndex = 0;
			((GObject)ResultDialog).touchable = true;
		});
	}

	private void DrawAgain(EventContext context)
	{
		Restart();
		DrawBtnClickEvent(context);
	}

	private void OpenLegendItemsStore()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsStorePanel.Name, null);
	}

	private void ReturnInitPage(EventContext context)
	{
		Restart();
		((GObject)Costs).visible = true;
		((GObject)ScoreProgress).visible = ScoreProgressVisible;
		((GObject)LegendItemStore).visible = true;
	}

	private void RenderLegendItem(int index, GObject obj)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = obj.asButton;
		RenderLegendItemContent(((GComponent)asButton).GetChild("Content").asButton, legendCards[index].LegendItem);
		((GObject)asButton).data = legendCards[index].LegendItem;
		((GObject)asButton).onClick.Set(new EventCallback1(CheckLegendItemInfo));
		UI_LegendItem uI_LegendItem = (UI_LegendItem)(object)((GComponent)asButton).GetChild("Content");
		FGUIManager.Instance.AddTextSpecialEffects(uI_LegendItem.SfxBack, "ui_active_glow_orange", new Vector3(250f, 250f, 250f));
	}

	private void CheckLegendItemInfo(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		LegendItemUi item = ((GObject)context.sender).data as LegendItemUi;
		UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(item);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
	}

	private void Restart()
	{
		((GObject)ResultDialog).visible = false;
		((GObject)DialogMask).alpha = 0f;
		MachineInit();
		MerchantInit();
	}

	private void LegendCardsClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)context.sender).data;
		legendCards[index].FlipCard();
	}

	private void LegendCardOnTouchBegin(EventContext context)
	{
		isMouseMoving = true;
	}

	private void LegendCardOnTouchMove(EventContext context)
	{
		if (!isMouseMoving)
		{
			return;
		}
		GObject touchTarget = GRoot.inst.touchTarget;
		if (touchTarget != null && touchTarget.touchable && !string.IsNullOrWhiteSpace(touchTarget.gameObjectName) && touchTarget.gameObjectName.Contains("LegendItemLoader"))
		{
			for (int i = 0; i < legendCards.Count; i++)
			{
				legendCards[i].FlipCard();
			}
		}
	}

	private void LegendCardOnTouchEnd(EventContext context)
	{
		if (isMouseMoving)
		{
			isMouseMoving = false;
		}
	}

	public void JudgeShowAllCards()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		if (--CardNum <= 0)
		{
			((GObject)InterruptBack).touchable = true;
			((GObject)InterruptBack).onClick.Set(new EventCallback0(ShowDrawResult));
			((GObject)tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText169");
		}
	}

	private void GetDrawActivity()
	{
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		legendItemLottery = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.LegendItemLottery).First();
		if (legendItemLottery == null)
		{
			return;
		}
		if (legendItemLottery.GetStatus(GameManagers.Instance) != ActivityStatus.Disabled)
		{
			Dictionary<string, ActivityContentPayload> dictionary = legendItemLottery.ContentPayload(GameManagers.Instance);
			int num = 0;
			foreach (KeyValuePair<string, ActivityContentPayload> item in dictionary)
			{
				string key = item.Key;
				LotteryActivityPayload lotteryActivityPayload = (LotteryActivityPayload)item.Value;
				List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
				for (int i = 0; i < lotteryActivityPayload.Tickets.Count; i++)
				{
					foreach (KeyValuePair<string, int> item2 in lotteryActivityPayload.Tickets[i])
					{
						list.Add(new KeyValuePair<string, int>(item2.Key, item2.Value));
						if (item2.Key != "Gem")
						{
							if (legendItemLottery.Period == ActivityPeriod.Permanent && generalTicketId == null)
							{
								generalTicketId = item2.Key;
							}
							else if (item2.Key != generalTicketId && specialTicketId == null)
							{
								specialTicketId = item2.Key;
							}
						}
					}
				}
				KeyValuePair<string, string> keyValuePair = SetCastIconAndNum(list);
				if (num == 1)
				{
					int stock = GameManagers.Instance.StockController.GetStock(keyValuePair.Key);
					((GObject)runningCost).text = $"{stock}/{keyValuePair.Value}";
					((GObject)ResultDialog.againBtn.runningCost).text = $"{stock}/{keyValuePair.Value}";
					runningTicketIcon.url = "ui://PublicResources/" + keyValuePair.Key;
					ResultDialog.againBtn.runningTicketIcon.url = "ui://PublicResources/" + keyValuePair.Key;
					((GObject)runningBtn).data = lotteryActivityPayload;
					((GObject)ResultDialog.againBtn).data = lotteryActivityPayload;
					((GObject)runningBtn.note).visible = lotteryActivityPayload.CheckTicket(GameManagers.Instance, null, out var _);
					((GObject)runningBtn).onClick.Set(new EventCallback1(DrawBtnClickEvent));
				}
				num++;
			}
			if (legendItemLottery.BonusProgress != null && legendItemLottery.BonusProgress.Count > 0)
			{
				double num2 = 0.0;
				if (GameManagers.Instance.ActivityManager.LegendItemLotteryActivityProgresses.TryGetValue(legendItemLottery.ActivityId, out var value))
				{
					num2 = value.Score;
				}
				double num3 = legendItemLottery.BonusProgress.First().Key;
				((GProgressBar)ScoreProgress).value = num2 / num3 * 100.0;
				if (num2 < num3)
				{
					ScoreProgress.Tyep.selectedIndex = 0;
					((GObject)ScoreProgress.sfxBack).visible = false;
					((GObject)ScoreProgress.chest).onClick.Set((EventCallback0)delegate
					{
						FGUIManager.Instance.ItemTip(legendItemLottery.BonusProgress.First().Value.First().Key, ((GObject)this).sortingOrder, noCheckBtn: true);
					});
				}
				else
				{
					ScoreProgress.Tyep.selectedIndex = 1;
					ScoreProgress.BoxBreathing.Play();
					((GObject)ScoreProgress.chest).data = legendItemLottery;
					((GObject)ScoreProgress.chest).onClick.Set(new EventCallback1(GetDrawReward));
				}
				((GObject)ScoreProgress.curNum).text = Convert.ToInt32(num2).ToString();
				((GObject)ScoreProgress.totalNum).text = Convert.ToInt32(num3).ToString();
			}
			else
			{
				ScoreProgressVisible = false;
			}
		}
		else
		{
			End();
		}
	}

	private void GetDrawReward(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		Activity activity = (Activity)val.data;
		if (!activity.CanClaimBonus(GameManagers.Instance))
		{
			return;
		}
		GProgressBar progressBar = ((GObject)val.parent).asProgress;
		ILRequestHelper<ActivityClaimResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().ActivityClaim(activity.ActivityId), delegate(ActivityClaimResponse response)
		{
			//IL_0474: Unknown result type (might be due to invalid IL or missing references)
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.BonusList == null || response.BonusList.Count < 0)
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText174") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText175") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			}
			else
			{
				StockChangeRecord[] array = new StockChangeRecord[response.BonusList.Count];
				int num = 0;
				foreach (ModelsBonus bonus in response.BonusList)
				{
					array[num++] = new StockChangeRecord
					{
						ItemId = bonus.ItemId,
						Offset = bonus.Qty,
						Context = 4,
						ContextValue = activity.ActivityId,
						Type = 1
					};
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(array);
				if (Shift.Legion.Common.Models.Item.ItemType(response.BonusList.First().ItemId) == 15)
				{
					string itemId = response.BonusList.First().ItemId;
					List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
					Dictionary<string, int> dictionary = new Dictionary<string, int>();
					foreach (Modifier item in list)
					{
						if (item.ModifierId == "Items")
						{
							foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
							{
								dictionary.Add(item2.Key, Convert.ToInt32(item2.Value));
							}
						}
					}
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
					{
						{
							"Name",
							SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId) ?? ""
						},
						{ "ShowSelectedReward", true },
						{
							"SelectItems",
							dictionary.ToList()
						},
						{ "NoClose", true },
						{ "SelectItemId", itemId }
					});
				}
				else
				{
					foreach (ModelsBonus bonus2 in response.BonusList)
					{
						SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { $"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, bonus2.ItemId)}+{bonus2.Qty}" }, 121, arg3: false);
					}
				}
				double num2 = 0.0;
				float key = activity.BonusProgress.First().Key;
				if (GameManagers.Instance.ActivityManager.LegendItemLotteryActivityProgresses.TryGetValue(legendItemLottery.ActivityId, out var value))
				{
					value.Score -= (int)key;
					num2 = value.Score;
				}
				if (num2 < (double)key)
				{
					((GComponent)progressBar).GetController("Tyep").selectedIndex = 0;
					((GComponent)progressBar).GetChild("sfxBack").visible = false;
					if (((GComponent)progressBar).GetTransition("BoxBreathing").playing)
					{
						((GComponent)progressBar).GetTransition("BoxBreathing").Stop();
						((GComponent)progressBar).GetChild("chest").SetScale(1f, 1f);
						((GComponent)progressBar).GetChild("sfxBack").SetScale(1f, 1f);
					}
				}
				else
				{
					((GComponent)progressBar).GetController("Tyep").selectedIndex = 1;
					FGUIManager.Instance.AddTextSpecialEffects(((GComponent)progressBar).GetChild("sfxBack").asGraph, "activated_fx", new Vector3(90f, 90f, 90f));
					((GComponent)progressBar).GetTransition("BoxBreathing").Play();
				}
				progressBar.TweenValue(num2 / (double)key * 100.0, 0.5f);
				((GComponent)progressBar).GetChild("curNum").text = Convert.ToInt32(num2).ToString();
				((GComponent)progressBar).GetChild("totalNum").text = Convert.ToInt32(key).ToString();
			}
		});
	}

	private async Task<bool> GetDrawResult(LotteryActivityPayload optionPayload)
	{
		Dictionary<string, int> ticketConfig;
		bool enough = optionPayload.CheckTicket(GameManagers.Instance, null, out ticketConfig);
		if (enough)
		{
			List<KeyValuePair<Bonus, int>> drawResult = await optionPayload.Draw(GameManagers.Instance);
			awardList.Clear();
			LegendItemsHelper.IsFirstLegendItemsDraw = false;
			if (drawResult.Count < 10)
			{
				return false;
			}
			if (GameManagers.Instance.ActivityManager.LegendItemLotteryActivityProgresses.TryGetValue(legendItemLottery.ActivityId, out var activityProgress))
			{
				activityProgress.Score += drawResult.Count;
			}
			else
			{
				GameManagers.Instance.ActivityManager.LegendItemLotteryActivityProgresses.Add(legendItemLottery.ActivityId, new LotteryActivityProgress(legendItemLottery.ActivityId)
				{
					Score = drawResult.Count
				});
			}
			for (int i = 0; i < drawResult.Count; i++)
			{
				KeyValuePair<Bonus, int> bonusInfoKv = drawResult[i];
				Bonus bonus = bonusInfoKv.Key;
				awardList.Add(new KeyValuePair<Bonus, int>(bonus, bonusInfoKv.Value));
			}
		}
		else
		{
			CanNotDrawTip();
		}
		return enough;
	}

	private void CanNotDrawTip()
	{
		if (!GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1005").Contains("P520"))
		{
			LanguagesManager.GetDesc("LegendItemTicketNotEnoughTip").ToConfirmPopup(null, null, (AlignType)0, 40, mirrorBtns: false, needCancelButton: false);
			return;
		}
		string text = Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, generalTicketId);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				" " + text + LanguagesManager.GetDesc("CsharpCodeZhTcText338") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText339") + "？"
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemDungeonPanel.Name, null);
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private async Task Draw(EventContext context)
	{
		LotteryActivityPayload optionPayload = (LotteryActivityPayload)((GObject)context.sender).data;
		int _uiNotTouchableIndex = GameController.Contexts.Service<IUiService>().SetUiNotTouchable(Name);
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			if (isDrawing)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
			}
		});
		if (await GetDrawResult(optionPayload))
		{
			ShowCards(awardList);
			isDrawing = false;
		}
		else
		{
			isDrawing = false;
			if (!((GObject)Costs).visible)
			{
				((GObject)Costs).visible = true;
			}
			if (!((GObject)ScoreProgress).visible)
			{
				((GObject)ScoreProgress).visible = ScoreProgressVisible;
			}
			if (!((GObject)LegendItemStore).visible)
			{
				((GObject)LegendItemStore).visible = true;
			}
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		GameController.Contexts.Service<IUiService>().SetUiTouchable(_uiNotTouchableIndex);
		GetDrawActivity();
	}

	private void ShowCards(List<KeyValuePair<Bonus, int>> bonusKeyValuePairs)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		List<LegendItemUi> list = new List<LegendItemUi>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < bonusKeyValuePairs.Count; i++)
		{
			Bonus key = bonusKeyValuePairs[i].Key;
			string itemId = key.ItemId;
			list2.Add(itemId);
			int qty = key.Qty;
			int num = i;
			Dictionary<string, float> dict = key.Claim(GameManagers.Instance);
			long key2 = long.Parse(dict.First().Key);
			LegendItem legendItem = GameManagers.Instance.InventoryManager.LegendItems[key2];
			LegendItemUi legendItemUi = new LegendItemUi(legendItem.InstanceId, legendItem);
			LegendItemsHelper.UpdateLegendItems(legendItemUi);
			list.Add(legendItemUi);
		}
		LegendItemsHelper.UpdateGetLegendItemStars(list);
		ThinkingDataHelper.Instance.LegendItemsDraw(list2);
		for (int j = 0; j < list.Count && j <= 9; j++)
		{
			legendCards[j].CardInit(list[j]);
		}
		CardNum = legendCards.Count;
		DrawProcess = FGUIManager.Instance.OpenIEnumerator(PlayDrawProcess());
		((GObject)InterruptBack).touchable = true;
		((GObject)InterruptBack).onClick.Set(new EventCallback0(SkipDrawProcess));
	}

	private void DrawBtnClickEvent(EventContext context)
	{
		if (!isDrawing)
		{
			isDrawing = true;
			Draw(context);
		}
	}

	private KeyValuePair<string, string> SetCastIconAndNum(List<KeyValuePair<string, int>> cost, bool forTalkingData = false)
	{
		cost.Reverse();
		KeyValuePair<string, string> keyValuePair = default(KeyValuePair<string, string>);
		string text = "";
		string text2 = "";
		string text3 = "";
		if (cost.Count >= 1)
		{
			KeyValuePair<string, int> keyValuePair2 = cost[cost.Count - 1];
			text2 = keyValuePair2.Key;
			text3 = $"{keyValuePair2.Value}";
		}
		foreach (KeyValuePair<string, int> item in cost)
		{
			if (item.Key == "Gem")
			{
				text2 = item.Key;
				text3 = item.Value.ShortNumberFormat();
			}
			if (item.Key != "Gem" && GameManagers.Instance.StockController.GetStock(item.Key) >= item.Value)
			{
				text2 = item.Key;
				text3 = $"{item.Value}";
				break;
			}
		}
		if (forTalkingData)
		{
			keyValuePair = new KeyValuePair<string, string>(text2, text3);
		}
		else
		{
			if (text2 != "GemTicket")
			{
				text2 = UiHelper.GetIcon(text2);
			}
			keyValuePair = new KeyValuePair<string, string>(text2, text + text3);
		}
		return keyValuePair;
	}

	private void AddDiamond()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
			},
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void AddCoupon()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemDungeonPanel.Name, null);
	}

	private void AddTicket()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
		{
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel")
			},
			{
				"Order",
				((GObject)this).sortingOrder
			},
			{ "TabName", "宝物" }
		});
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		if (itemId == generalTicketId)
		{
			((GObject)addCouponBtn.GetChild("num").asTextField).text = $"{stock}";
			int num = ((addCouponBtn.GetChild("num").data != null) ? ((int)addCouponBtn.GetChild("num").data) : stock);
			if (num != stock && stock > num)
			{
				int num2 = stock - num;
				if (NumFloatingGem1 == null)
				{
					NumFloatingGem1 = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				}
				if (!((GObject)NumFloatingGem1).onStage)
				{
					FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem1, addCouponBtn, stock - num);
				}
				else
				{
					((GObject)NumFloatingGem1.Title).text = $"+{(int)((GObject)NumFloatingGem1.Title).data + num2}";
					((GObject)NumFloatingGem1.Title).data = (int)((GObject)NumFloatingGem1.Title).data + num2;
				}
			}
			addCouponBtn.GetChild("num").data = stock;
			addCouponBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addCouponBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			GetDrawActivity();
		}
		else
		{
			if (!(itemId == specialTicketId))
			{
				return;
			}
			((GObject)addTicketBtn.GetChild("num").asTextField).text = $"{stock}";
			int num3 = ((addTicketBtn.GetChild("num").data != null) ? ((int)addTicketBtn.GetChild("num").data) : stock);
			if (num3 != stock && stock > num3)
			{
				int num4 = stock - num3;
				if (NumFloatingGem2 == null)
				{
					NumFloatingGem2 = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				}
				if (!((GObject)NumFloatingGem2).onStage)
				{
					FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem2, addTicketBtn, stock - num3);
				}
				else
				{
					((GObject)NumFloatingGem2.Title).text = $"+{(int)((GObject)NumFloatingGem2.Title).data + num4}";
					((GObject)NumFloatingGem2.Title).data = (int)((GObject)NumFloatingGem2.Title).data + num4;
				}
			}
			addTicketBtn.GetChild("num").data = stock;
			addTicketBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addTicketBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			GetDrawActivity();
		}
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText832");
	}
}
