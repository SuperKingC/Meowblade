using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.AddCredit;
using UI.Guide;
using UI.InstanceZones;
using UI.LegendItemDungeon;
using UI.MilitaryAFKAssistant;
using UI.MonthCard;
using UnityEngine;

namespace UI.MilitaryIntelligence;

public class UI_MilitaryIntelligencePanel : GComponent, IUiController
{
	public GLoader background;

	public UI_Title titleCom;

	public GComponent addDiamondBtn;

	public GButton backBtn;

	public UI_CardLoader CardLoader;

	public GGraph workUI;

	public UI_btn_01 assistantBtn;

	public const string URL = "ui://nfd5v46uk67u0";

	public static string Name = "UI_MilitaryIntelligencePanel";

	private Coroutine updateCardsCoroutine;

	private readonly List<string> textureList = new List<string>();

	private List<Activity> curActivity;

	private readonly List<Activity> challengeActivities = new List<Activity>();

	private int neutralDungeonActivityIndex = -1;

	private bool toUnloadAni;

	private bool findTreasure;

	private static List<ActivityType> _activityTypes = new List<ActivityType>
	{
		ActivityType.AttackInstance,
		ActivityType.DefenseInstance,
		ActivityType.TimeLimitInstance
	};

	public static string GetURL()
	{
		return "ui://nfd5v46uk67u0";
	}

	public static UI_MilitaryIntelligencePanel CreateInstance()
	{
		return (UI_MilitaryIntelligencePanel)(object)UIPackage.CreateObject("MilitaryIntelligence", "MilitaryIntelligencePanel");
	}

	public static UI_MilitaryIntelligencePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MilitaryIntelligencePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uk67u0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		CardLoader = (UI_CardLoader)(object)((GComponent)this).GetChild("CardLoader");
		workUI = (GGraph)((GComponent)this).GetChild("workUI");
		assistantBtn = (UI_btn_01)(object)((GComponent)this).GetChild("assistantBtn");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = ((parameters == null || !parameters.TryGetValue("SortingOrder", out var value)) ? 1 : ((int)value));
		findTreasure = parameters != null && parameters.TryGetValue("FindTreasure", out var value2) && (bool)value2;
		GList cardList = CardLoader.cardList;
		((GObject)cardList).x = ((GObject)cardList).x + 25f;
		FGUIManager.Instance.GetNeutralDungeonDataAsync(delegate(NeutralDungeonData dData)
		{
			if (dData == null)
			{
				End();
			}
			else
			{
				CardLoaderInit();
				UpdateDiamondNum();
				SetBuildingName();
				InitWorkerSpine();
				StartUpdateCards();
			}
		});
		if (GameController.Configs.TryGetValue("ClickSimulatorEnabled", out var value3) && value3 == "1")
		{
			if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted("P830"))
			{
				((GObject)assistantBtn).visible = false;
				return;
			}
			((GObject)assistantBtn).visible = true;
			((GObject)assistantBtn).grayed = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") <= 0 || !GameManagers.Instance.UserArchiveManager.IsLevelCompleted("P1130");
			((GObject)assistantBtn).touchable = true;
		}
		else
		{
			((GObject)assistantBtn).visible = false;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)assistantBtn).onClick.Add(new EventCallback0(OnClickAssistantBtn));
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)addDiamondBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(addDiamond));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnBackToMilitaryIntelligencePanel);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)assistantBtn).onClick.Remove(new EventCallback0(OnClickAssistantBtn));
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)addDiamondBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(addDiamond));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnBackToMilitaryIntelligencePanel);
	}

	public void OnShow()
	{
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building14_Click");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MilitaryIntelligence.DungeonInstanceEntrance");
		if (CardLoader.cardList.numItems > 0 && findTreasure)
		{
			instance.Unregister("TreasureBtn");
		}
		if (Timers.inst.Exists(new TimerCallback(UpdateActivityOpenTime)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateActivityOpenTime));
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	private void FindTreasureBtn(int btnIndex = 0)
	{
		if (CardLoader.cardList.numItems > 0 && findTreasure)
		{
			UiTagManager instance = UiTagManager.Instance;
			GButton asButton = ((GComponent)((GComponent)CardLoader.cardList).GetChildAt(btnIndex).asButton).GetChild("treasureBtn").asButton;
			((GObject)asButton).touchable = false;
			instance.Register("TreasureBtn", asButton);
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			List<string> list = new List<string>();
			list.Add("TreasureBtn");
			dictionary.Add("Highlight", list);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Guide.Name, dictionary);
		}
	}

	private void addDiamond()
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

	private void OnClickAssistantBtn()
	{
		if (((GObject)assistantBtn).grayed)
		{
			if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted("P1130"))
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("TipsMilitaryAFKAssistantUnlockCase") }, 121, arg3: false);
			}
			else if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") <= 0)
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("TipsMilitaryAFKAssistantNeedPrimeContract") }, 121, arg3: false);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
				{
					{
						"Activity",
						FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
					},
					{
						"Order",
						((GObject)this).sortingOrder
					},
					{ "Parent", this }
				});
			}
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_MilitaryAFKAssistant.Name, null);
		}
	}

	private void SetBuildingName()
	{
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText429");
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == "Gem")
		{
			int stock = GameManagers.Instance.StockController.GetStock(itemId);
			((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ShortNumberFormat() ?? "";
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
		}
	}

	private void UpdateDiamondNum()
	{
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Gem").ShortNumberFormat();
	}

	private void SetTreasure()
	{
		for (int i = 0; i < ((GComponent)CardLoader).numChildren; i++)
		{
			GButton button = ((GComponent)((GComponent)CardLoader).GetChildAt(i).asButton).GetChild("treasureBtn").asButton;
			string text = "";
			text = ((i != 0) ? "" : "");
			string iconPath = UiHelper.GetIconPath(text);
			AssetsManager.Instance.LoadAsset<Texture2D>(iconPath).Then((Action<Texture2D>)delegate(Texture2D asset)
			{
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Expected O, but got Unknown
				((GComponent)button).GetChild("icon").asLoader.texture = new NTexture((Texture)(object)asset);
				textureList.Add(iconPath);
			});
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
	}

	private void ResolveTitleBonus(string imgUrl, GButton button)
	{
		((GComponent)button).GetController("StatusController").selectedIndex = 0;
		if (string.IsNullOrWhiteSpace(imgUrl))
		{
			imgUrl = "I30009_5";
		}
		((GComponent)button).GetChild("icon").asLoader.url = "ui://PublicResources/" + imgUrl;
	}

	private void OnBackToMilitaryIntelligencePanel(string uiName)
	{
		if (!(uiName != UI_InstanceZonesPanel.Name))
		{
			StartUpdateCards();
		}
	}

	private void StartUpdateCards(Action<CheckActivitiesOverPeriodResponse, bool, bool> callback = null)
	{
		if (updateCardsCoroutine == null)
		{
			updateCardsCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateCards(callback));
		}
	}

	private void AfterUpdateCards()
	{
		updateCardsCoroutine = null;
		int btnIndex = 0;
		for (int i = 0; i < challengeActivities.Count; i++)
		{
			Activity activity = challengeActivities[i];
			if (activity.Type == ActivityType.TimeLimitInstance)
			{
				btnIndex = i;
				break;
			}
		}
		FindTreasureBtn(btnIndex);
	}

	private IEnumerator UpdateCards(Action<CheckActivitiesOverPeriodResponse, bool, bool> callback = null)
	{
		Task<NeutralDungeonData> getNeutralActivityTask = FGUIManager.Instance.GetNeutralDungeonActivity(forceUpdate: true);
		while (!getNeutralActivityTask.IsCompleted && !getNeutralActivityTask.IsCanceled)
		{
			yield return (object)new WaitForSeconds(0.2f);
		}
		if (getNeutralActivityTask.IsCompleted)
		{
			Activity neutralDungeonActivity = getNeutralActivityTask.Result?.Activity;
			if (neutralDungeonActivity == null)
			{
				ILRuntimeDebug.LogError("UI_MilitaryIntelligencePanel GetNeutralDungeonActivity Failed");
			}
			else if (neutralDungeonActivityIndex == -1)
			{
				challengeActivities.Add(neutralDungeonActivity);
				neutralDungeonActivityIndex = challengeActivities.Count - 1;
			}
			else
			{
				challengeActivities[neutralDungeonActivityIndex] = neutralDungeonActivity;
			}
		}
		else
		{
			ILRuntimeDebug.LogError("UI_MilitaryIntelligencePanel GetNeutralDungeonActivity Failed");
		}
		GameManagers.Instance.ActivityManager.CheckActivities(null, _activityTypes, delegate(CheckActivitiesOverPeriodResponse response, bool hasNewData, bool hasNewActivityRecord)
		{
			if (!((GObject)this).isDisposed)
			{
				CardLoaderInit();
				callback?.Invoke(response, hasNewData, hasNewActivityRecord);
				AfterUpdateCards();
			}
		});
	}

	public void CardLoaderInit()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		Activity currentSingletonActivityByType = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.AttackInstance);
		Activity currentSingletonActivityByType2 = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.DefenseInstance);
		Activity currentSingletonActivityByType3 = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.TimeLimitInstance);
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.TreasureHunt);
		Activity activity = FGUIManager.Instance.NeutralDungeonData?.Activity;
		List<Activity> list = new List<Activity>();
		if (currentSingletonActivityByType3 != null && currentSingletonActivityByType3.GetStatus(GameManagers.Instance) != ActivityStatus.Pending)
		{
			list.Add(currentSingletonActivityByType3);
		}
		if (currentSingletonActivityByType2 != null)
		{
			list.Add(currentSingletonActivityByType2);
		}
		if (currentSingletonActivityByType != null)
		{
			list.Add(currentSingletonActivityByType);
		}
		if (activitiesByType != null)
		{
			list.AddRange(activitiesByType);
		}
		if (activity != null)
		{
			list.Add(activity);
			neutralDungeonActivityIndex = list.Count - 1;
		}
		challengeActivities.Clear();
		CardLoader.cardList.numItems = 0;
		challengeActivities.AddRange(list);
		List<string> list2 = new List<string>();
		for (int i = 0; i < list.Count; i++)
		{
			Activity activity2 = list[i];
			list2.Add(list[i].ActivityId);
			if (activity2.ChildIds.Count <= 0)
			{
				continue;
			}
			for (int j = 0; j < activity2.ChildIds.Count; j++)
			{
				string item = activity2.ChildIds[j];
				if (!list2.Contains(item))
				{
					list2.Add(item);
				}
			}
		}
		GameManagers.Instance.ActivityManager.ReviewActivities(list2);
		RenderCardList();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MilitaryIntelligence.DungeonInstanceEntrance");
		instance.Unregister("MilitaryIntelligence.TimeLimitDungeonInstanceEntrance");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		int num = 0;
		for (int k = 0; k < CardLoader.cardList.numItems; k++)
		{
			GObject child = ((GComponent)CardLoader.cardList).GetChildAt(k).asCom.GetChild("Cover");
			Activity activity3 = challengeActivities[k];
			dictionary.Add(activity3.ActivityId, child);
			if (activity3.Type == ActivityType.TimeLimitInstance)
			{
				instance.Register("MilitaryIntelligence.TimeLimitDungeonInstanceEntrance", child);
			}
		}
		instance.Register("MilitaryIntelligence.DungeonInstanceEntrance", dictionary);
	}

	private void RenderCardList()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(UpdateActivityOpenTime)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateActivityOpenTime));
		}
		CardLoader.cardList.itemRenderer = new ListItemRenderer(RenderCard);
		CardLoader.cardList.numItems = challengeActivities.Count;
		UpdateNeutralDungeonEntrance();
		UpdateActivityOpenTime(null);
		if (!Timers.inst.Exists(new TimerCallback(UpdateActivityOpenTime)))
		{
			Timers.inst.Add(1f, 0, new TimerCallback(UpdateActivityOpenTime));
		}
	}

	private void RenderCard(int index, GObject obj)
	{
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Expected O, but got Unknown
		GComponent asCom = obj.asCom;
		Activity activity = challengeActivities[index];
		string uiName = activity.UiName;
		int num = int.Parse(activity.UiParams["Type"].ToString());
		Controller controller = asCom.GetController("TypeController");
		Controller controller2 = asCom.GetController("StatusController");
		asCom.GetChild("ExclamationTipBtn").visible = false;
		asCom.GetChild("timeAndCase").visible = false;
		asCom.GetChild("bgFX").visible = false;
		asCom.GetChild("LimitTimeOpenTip").visible = false;
		switch (num)
		{
		case 0:
			controller.selectedIndex = 0;
			break;
		case 1:
			controller.selectedIndex = 2;
			break;
		case 2:
			controller.selectedIndex = 1;
			break;
		case 4:
			controller.selectedIndex = 4;
			break;
		case 5:
			controller.selectedIndex = 5;
			break;
		default:
			controller.selectedIndex = 0;
			break;
		}
		ActivityStatus activityStatus = activity.GetStatus(GameManagers.Instance);
		ActivityType activityType = activity.Type;
		ActivityPeriod period = activity.Period;
		GButton asButton = asCom.GetChild("treasureBtn").asButton;
		ResolveTitleBonus(activity.ImgUrl, asButton);
		asCom.GetChild("title").text = activity.Name ?? "";
		if (activityType == ActivityType.TreasureHunt)
		{
			ActivityStatus activityStatus2 = activityStatus;
			if (activityStatus2 == ActivityStatus.Pending)
			{
				controller2.selectedIndex = 1;
				((GObject)asCom).touchable = false;
				asCom.GetChild("content").text = "";
				asCom.GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)86, (byte)185, byte.MaxValue, byte.MaxValue));
				asCom.GetChild("tip2nd").text = GetActivityCasetText(activity);
				asCom.GetChild("tip2nd").visible = true;
				asCom.GetChild("timeAndCase").visible = true;
				asCom.GetChild("title").grayed = true;
				asCom.GetChild("content").grayed = true;
				asCom.GetChild("treasureBtn").grayed = true;
			}
			else
			{
				controller2.selectedIndex = 0;
				((GObject)asCom).touchable = true;
				asCom.GetChild("content").text = LegendItemDungeonUiHelper.GetCurAvailableTickets();
				asCom.GetChild("title").grayed = false;
				asCom.GetChild("content").grayed = false;
				asCom.GetChild("treasureBtn").grayed = false;
			}
			Action action = delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(uiName, null);
			};
			((GObject)asCom).onClick.Set((EventCallback0)delegate
			{
				LegendItemDungeonUiHelper.OpenLegendItemDungeonPanel(action);
			});
			return;
		}
		if (period == ActivityPeriod.Single || period == ActivityPeriod.NDaysCycle || period == ActivityPeriod.Hybrid)
		{
			if (activityStatus == ActivityStatus.Enabled)
			{
				int time = (int)activity.CurRemainingTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime())).TotalSeconds;
				asCom.GetChild("timeAndCase").visible = true;
				asCom.GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)86, (byte)185, byte.MaxValue, byte.MaxValue));
				asCom.GetChild("tip2nd").text = UiHelper.ParseTimeChinsesDH(time) + LanguagesManager.GetDesc("CsharpCodeZhTcText281");
			}
			else if (activityStatus == ActivityStatus.Underline)
			{
				asCom.GetChild("timeAndCase").visible = true;
				asCom.GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)86, (byte)185, byte.MaxValue, byte.MaxValue));
				asCom.GetChild("tip2nd").text = LanguagesManager.GetDesc("CsharpCodeZhTcText431") + " " + activity.GetPeriodTimeDesc(shortFormat: true);
			}
		}
		string text = "#FFFFFF";
		int stock = GameManagers.Instance.StockController.GetStock(activity.TicketItem);
		if (stock == 0)
		{
			text = "#DC143C";
		}
		if (activityStatus == ActivityStatus.Enabled || activityStatus == ActivityStatus.Settlement)
		{
			controller2.selectedIndex = 0;
			((GObject)asCom).touchable = true;
			asCom.GetChild("content").text = "[color=" + text + "]" + stock.ShortNumberFormat() + "/" + activity.TicketLimit.ShortNumberFormat() + "[/color]" + activity.GetTicketExtraLimitDesc();
			asCom.GetChild("content").data = stock;
		}
		else if (activityStatus == ActivityStatus.Underline)
		{
			if (activityType == ActivityType.NeutralDungeonInstance)
			{
				controller2.selectedIndex = 2;
			}
			else
			{
				controller2.selectedIndex = 1;
			}
			((GObject)asCom).touchable = false;
			asCom.GetChild("content").text = "[color=" + text + "]" + stock.ShortNumberFormat() + "/" + activity.TicketLimit.ShortNumberFormat() + "[/color]" + activity.GetTicketExtraLimitDesc();
			asCom.GetChild("content").data = stock;
		}
		else if (activityStatus == ActivityStatus.Pending)
		{
			controller2.selectedIndex = 2;
			((GObject)asCom).touchable = false;
			asCom.GetChild("extraCase").visible = false;
			asCom.GetChild("content").text = "";
			asCom.GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)86, (byte)185, byte.MaxValue, byte.MaxValue));
			asCom.GetChild("tip2nd").text = GetActivityCasetText(activity);
			asCom.GetChild("tip2nd").visible = true;
			asCom.GetChild("timeAndCase").visible = true;
			if (activityType == ActivityType.TimeLimitInstance)
			{
				asCom.GetChild("title").text = activity.Name ?? "";
				asCom.GetChild("content").text = activity.GetPeriodTimeDesc(shortFormat: true) ?? "";
				ResolveTitleBonus(activity.ImgUrl, asButton);
				((GObject)asButton).grayed = false;
				asCom.GetChild("title").grayed = false;
				asCom.GetChild("content").grayed = false;
			}
		}
		Activity value = activity;
		if (activityType == ActivityType.TimeLimitInstance)
		{
			asCom.GetChild("ExclamationTipBtn").visible = activity.CanClaimBonus(GameManagers.Instance);
			string activityLastStayAt = GameLocalDataManager.GetActivityLastStayAt(activity.ActivityId);
			if (activityLastStayAt != activity.ActivityId)
			{
				foreach (KeyValuePair<string, ActivityContentPayload> item in activity.ContentPayload(GameManagers.Instance))
				{
					if (!(item.Value is ChapterActivityPayload { IsPortal: not false } chapterActivityPayload))
					{
						continue;
					}
					value = ((chapterActivityPayload.PortalTargetActivity == null) ? activity : chapterActivityPayload.PortalTargetActivity);
					break;
				}
			}
		}
		Dictionary<string, object> dic = new Dictionary<string, object>
		{
			{ "Type", num },
			{ "Activity", value },
			{ "Parent", this },
			{
				"SortingOrder",
				((GObject)this).sortingOrder
			}
		};
		((GObject)asCom).data = dic;
		((GObject)asCom).onClick.Set((EventCallback0)delegate
		{
			if (activityType == ActivityType.NeutralDungeonInstance)
			{
				NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
				if (!neutralDungeonData.HasUnlocked())
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("NeutralDungeon_Need_Pass_P310_PlaceHolder") ?? "" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
					return;
				}
			}
			if (activityStatus != ActivityStatus.Enabled)
			{
				List<string> arg2 = new List<string> { LanguagesManager.GetDesc("nfd5v46uk67ue-n9_k67u") ?? "" };
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(uiName, dic);
			}
		});
	}

	private void UpdateNeutralDungeonEntrance()
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
		int num = neutralDungeonData.TimeGoingOn();
		GButton asButton = ((GComponent)CardLoader.cardList).GetChildAt(neutralDungeonActivityIndex).asButton;
		((GComponent)asButton).GetChild("title").text = neutralDungeonData.Activity.Name;
		((GComponent)asButton).GetChild("content").text = $"{GameManagers.Instance.StockController.GetStock(neutralDungeonData.Activity.TicketItem)}/{neutralDungeonData.Activity.TicketLimit}{neutralDungeonData.GetTicketExtraLimitDesc()}";
		((GComponent)asButton).GetChild("timeAndCase").visible = true;
		((GComponent)asButton).GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)174, (byte)242, (byte)36, byte.MaxValue));
		((GComponent)asButton).GetChild("tip2nd").text = LanguagesManager.GetDesc("NeutralDungeon_Weekend_Only_PlaceHolder");
		if (!neutralDungeonData.HasUnlocked())
		{
			((GComponent)asButton).GetController("StatusController").selectedIndex = 2;
			((GComponent)asButton).GetChild("extraCase").visible = true;
			((GComponent)asButton).GetChild("tip3rd").text = LanguagesManager.GetDesc("NeutralDungeon_Need_Pass_P310_PlaceHolder");
		}
		else if (num >= 0 && neutralDungeonData.Activity.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
		{
			((GComponent)CardLoader.cardList).SetChildIndex((GObject)(object)asButton, 0);
			if (neutralDungeonActivityIndex != 0)
			{
				Activity item = challengeActivities[neutralDungeonActivityIndex];
				challengeActivities.RemoveAt(neutralDungeonActivityIndex);
				challengeActivities.Insert(0, item);
				neutralDungeonActivityIndex = 0;
			}
			((GComponent)asButton).GetChild("bgFX").visible = true;
			((GComponent)asButton).GetChild("LimitTimeOpenTip").visible = true;
			((GObject)asButton).onClick.Set((EventCallback0)delegate
			{
				Activity activity = challengeActivities[neutralDungeonActivityIndex];
				if (!neutralDungeonData.HasUnlocked())
				{
					List<string> arg = new List<string> { LanguagesManager.GetDesc("NeutralDungeon_Need_Pass_P310_PlaceHolder") ?? "" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					ActivityStatus status = activity.GetStatus(GameManagers.Instance);
					if (status != ActivityStatus.Enabled)
					{
						List<string> arg2 = new List<string> { LanguagesManager.GetDesc("nfd5v46uk67ue-n9_k67u") ?? "" };
						SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
					}
					else
					{
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_InstanceZonesPanel.Name, new Dictionary<string, object>
						{
							{ "Type", 5 },
							{ "Activity", neutralDungeonData.Activity }
						});
					}
				}
			});
		}
		else
		{
			((GComponent)asButton).GetController("StatusController").selectedIndex = 2;
		}
	}

	private void PlayTicketNumUpdateEffect(GObject textGObject, int stock, string contentColor, int ticketLimit)
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		if (textGObject.data == null)
		{
			textGObject.text = "[color=" + contentColor + "]" + stock.ShortNumberFormat() + "/" + ticketLimit.ShortNumberFormat() + "[/color]";
			textGObject.data = stock;
			return;
		}
		int num = (int)textGObject.data;
		if (num == stock)
		{
			return;
		}
		GTween.To((float)num, (float)stock, 0.75f).SetEase((EaseType)0).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
		{
			if (!textGObject.isDisposed)
			{
				textGObject.text = $"[color={contentColor}]{Convert.ToInt32(Mathf.Floor(tweener.value.x))}/{ticketLimit.ShortNumberFormat()}[/color]";
			}
		})
			.OnComplete((GTweenCallback)delegate
			{
				if (!textGObject.isDisposed)
				{
					textGObject.text = "[color=" + contentColor + "]" + stock.ShortNumberFormat() + "/" + ticketLimit.ShortNumberFormat() + "[/color]";
					textGObject.data = stock;
				}
			});
	}

	private string GetActivityCasetText(Activity _activity)
	{
		string text = "";
		if (_activity.LevelCase != null && _activity.LevelCase.Count > 0)
		{
			text += LanguagesManager.GetDesc("CsharpCodeZhTcText13");
			for (int i = 0; i < _activity.LevelCase.Count; i++)
			{
				string text2 = _activity.LevelCase[i];
				text2 = text2.Remove(0, 1);
				text2 = text2.Insert(1, "-");
				text += text2;
				if (i == _activity.LevelCase.Count - 1)
				{
					text += LanguagesManager.GetDesc("CsharpCodeZhTcText113");
				}
			}
		}
		if (_activity.SoldierCase != null && _activity.SoldierCase.Count > 0)
		{
			text += Environment.NewLine;
			foreach (KeyValuePair<string, Dictionary<string, int>> item in _activity.SoldierCase)
			{
				text += GameManagers.Instance.SoldierManager.Get(item.Key).Name;
				foreach (KeyValuePair<string, int> item2 in item.Value)
				{
					text += string.Format("{0}{1}{2}", item2.Key, LanguagesManager.GetDesc("CsharpCodeZhTcText432"), item2.Value);
				}
				text += Environment.NewLine;
			}
		}
		return text;
	}

	private void InitWorkerSpine()
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
		SpawnManager.Instance.LoadAnimation("Goblinworker_UI_001").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
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
					string text = "skin_fuben";
					SpineHelper.SetSkin((ISkeletonAnimation)(object)val2, text);
					val2.AnimationState.AddAnimation(1, "idle", true, 0f);
				}
			}
		});
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(80f, 80f, 80f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scaleX = 1f;
			workUI.SetNativeObject((DisplayObject)(object)val);
		}
	}

	private void UpdateActivityOpenTime(object parameter)
	{
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		if (GameManagers.Instance == null)
		{
			return;
		}
		for (int i = 0; i < CardLoader.cardList.numItems; i++)
		{
			GComponent asCom = ((GComponent)CardLoader.cardList).GetChildAt(i).asCom;
			if (i == neutralDungeonActivityIndex)
			{
				NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
				if (!neutralDungeonData.HasUnlocked())
				{
					continue;
				}
				if (neutralDungeonData.TimeGoingOn() > 0 && neutralDungeonData.Activity.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
				{
					DateTimeOffset serverNow = DateTimeHelper.ServerNow;
					int num = 0;
					int time = (int)(neutralDungeonData.CurEndTime - serverNow).TotalSeconds - num;
					asCom.GetChild("timeAndCase").visible = true;
					asCom.GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)86, (byte)185, byte.MaxValue, byte.MaxValue));
					asCom.GetChild("tip2nd").text = UiHelper.ParseTimeChinsesDH(time) + LanguagesManager.GetDesc("CsharpCodeZhTcText559");
				}
				else
				{
					asCom.GetController("StatusController").selectedIndex = 2;
					asCom.GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)174, (byte)242, (byte)36, byte.MaxValue));
					asCom.GetChild("tip2nd").text = LanguagesManager.GetDesc("NeutralDungeon_Weekend_Only_PlaceHolder");
				}
			}
			Activity activity = challengeActivities[i];
			if (activity.Type != ActivityType.TreasureHunt && (activity.Type == ActivityType.TimeLimitInstance || activity.Period == ActivityPeriod.Single) && activity.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
			{
				asCom.GetChild("timeAndCase").visible = true;
				asCom.GetChild("tip2nd").asTextField.color = Color32.op_Implicit(new Color32((byte)86, (byte)185, byte.MaxValue, byte.MaxValue));
				int time2 = Convert.ToInt32(activity.CurRemainingTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime())).TotalSeconds);
				asCom.GetChild("tip2nd").text = UiHelper.ParseTimeChinsesDH(time2) + LanguagesManager.GetDesc("CsharpCodeZhTcText281");
			}
		}
	}
}
