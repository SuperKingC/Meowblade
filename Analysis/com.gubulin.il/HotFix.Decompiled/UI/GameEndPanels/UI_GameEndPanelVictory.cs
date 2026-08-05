using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.InstanceZones;
using UI.LegendItemDungeon;
using UI.QuickBattle;
using UI.Restart;
using UI.Tips;
using UnityEngine;

namespace UI.GameEndPanels;

public class UI_GameEndPanelVictory : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<SkeletonAnimation> _003C_003E9__77_0;

		public static Action _003C_003E9__97_0;

		public static GTweenCallback _003C_003E9__98_2;

		public static PlayCompleteCallback _003C_003E9__111_0;

		public static Action _003C_003E9__119_0;

		internal void _003CInit_003Eb__77_0(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_victory", true);
		}

		internal void _003CChoiceListFade_003Eb__97_0()
		{
		}

		internal void _003COn3Pick1BonusConfirmed_003Eb__98_2()
		{
			UiAudioManager.Instance.PlaySoundEffect("ItemDrop");
		}

		internal void _003CListInit_003Eb__111_0()
		{
		}

		internal void _003CQuickBattleAgain_003Eb__119_0()
		{
		}
	}

	public Controller PageController;

	public Controller VictoryState;

	public GGraph BlackGround;

	public UI_DropStart pointA;

	public UI_DropStart pointB;

	public UI_DropStart pointC;

	public UI_DropStart pointD;

	public UI_DropStart pointE;

	public UI_DropStart pointF;

	public UI_VictoryBackGround Light;

	public GList ChoiceList;

	public GButton YesButton;

	public GLoader DropBackground;

	public GRichTextField IncomeText;

	public GList VictoryDropList;

	public GGroup Drops;

	public GButton ConfirmSelectionsBtn;

	public GButton ReceiveBtn;

	public UI_InstanceZonesReward InstanceZonesReward;

	public UI_RewardAndChoose RewardAndChoose;

	public GTextField titleBackup;

	public UI_restartBtn restart;

	public GGraph missbleSfxBack;

	public UI_AgainButton againBtn;

	public UI_EndIcon EndIcon;

	public Transition Rotate;

	public Transition Drop;

	public Transition ShowRewardAndChoose;

	public const string URL = "ui://hda5vzklj0l8v";

	public static string Name = "UI_GameEndPanelVictory";

	private const string BONUS_TYPE_TECH = "Technology";

	private const string BONUS_TYPE_ITEM = "Item";

	private const int DISTANCE = 100;

	private readonly List<GameObject> animationList = new List<GameObject>();

	private List<GButton> buttonList;

	private int cardIndex;

	private int chosenIndex;

	private int clearStages;

	public float dropEndTime;

	private readonly List<string> dropIconNameList = new List<string>();

	[HideInInspector]
	public Vector2 FortifiedPointPos;

	private bool isDefensive;

	private bool isOffensive;

	private Level level;

	private float GetScore;

	private List<Bonus> popupCardData;

	private Vector3 soldierScale;

	private double curLevelGetExp;

	private int stages;

	private int stepOne;

	private float missbleSfxDelay = 0f;

	private int userExpBtnIndex;

	private List<GTweener> tweeners = new List<GTweener>();

	private readonly List<string> textureList = new List<string>();

	private List<string> _capturedLevels;

	private List<Bonus> _finalBonuses = new List<Bonus>();

	private Dictionary<string, List<Bonus>> _fixBonuses;

	private List<Bonus> _lotteryBonuses;

	private int battleResult = 1;

	private object battleStats;

	private Dictionary<string, int> redDeadStats = new Dictionary<string, int>();

	private int freeCount;

	private Dictionary<string, int> backInTimeCost = new Dictionary<string, int>();

	private string battleId;

	private bool canBackInTime;

	private bool QuickBattle;

	private bool showSoldiersNumTip;

	private bool isPortal;

	private bool showAgainBattleBtn;

	private string uiTitleAnimName = "ui_title_lightray_rotate";

	private float TransitionsTimeScale = 1f;

	private Coroutine _WaitLevelCompleted;

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://hda5vzklj0l8v".Replace("ui://", ""), ((GObject)titleBackup).id, PageController.selectedIndex);
		((GObject)titleBackup).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://hda5vzklj0l8v";
	}

	public static UI_GameEndPanelVictory CreateInstance()
	{
		return (UI_GameEndPanelVictory)(object)UIPackage.CreateObject("GameEndPanels", "GameEndPanelVictory");
	}

	public static UI_GameEndPanelVictory CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GameEndPanelVictory).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklj0l8v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		VictoryState = ((GComponent)this).GetController("VictoryState");
		BlackGround = (GGraph)((GComponent)this).GetChild("BlackGround");
		pointA = (UI_DropStart)(object)((GComponent)this).GetChild("pointA");
		pointB = (UI_DropStart)(object)((GComponent)this).GetChild("pointB");
		pointC = (UI_DropStart)(object)((GComponent)this).GetChild("pointC");
		pointD = (UI_DropStart)(object)((GComponent)this).GetChild("pointD");
		pointE = (UI_DropStart)(object)((GComponent)this).GetChild("pointE");
		pointF = (UI_DropStart)(object)((GComponent)this).GetChild("pointF");
		Light = (UI_VictoryBackGround)(object)((GComponent)this).GetChild("Light");
		ChoiceList = (GList)((GComponent)this).GetChild("ChoiceList");
		YesButton = (GButton)((GComponent)this).GetChild("YesButton");
		DropBackground = (GLoader)((GComponent)this).GetChild("DropBackground");
		IncomeText = (GRichTextField)((GComponent)this).GetChild("IncomeText");
		string id = "ui://hda5vzklj0l8v".Replace("ui://", "") + "-" + ((GObject)IncomeText).id;
		((GObject)IncomeText).text = LanguagesManager.GetDesc(id);
		VictoryDropList = (GList)((GComponent)this).GetChild("VictoryDropList");
		Drops = (GGroup)((GComponent)this).GetChild("Drops");
		ConfirmSelectionsBtn = (GButton)((GComponent)this).GetChild("ConfirmSelectionsBtn");
		ReceiveBtn = (GButton)((GComponent)this).GetChild("ReceiveBtn");
		InstanceZonesReward = (UI_InstanceZonesReward)(object)((GComponent)this).GetChild("InstanceZonesReward");
		RewardAndChoose = (UI_RewardAndChoose)(object)((GComponent)this).GetChild("RewardAndChoose");
		titleBackup = (GTextField)((GComponent)this).GetChild("titleBackup");
		string id2 = "ui://hda5vzklj0l8v".Replace("ui://", "") + "-" + ((GObject)titleBackup).id;
		((GObject)titleBackup).text = LanguagesManager.GetDesc(id2);
		restart = (UI_restartBtn)(object)((GComponent)this).GetChild("restart");
		missbleSfxBack = (GGraph)((GComponent)this).GetChild("missbleSfxBack");
		againBtn = (UI_AgainButton)(object)((GComponent)this).GetChild("againBtn");
		EndIcon = (UI_EndIcon)(object)((GComponent)this).GetChild("EndIcon");
		Rotate = ((GComponent)this).GetTransition("Rotate");
		Drop = ((GComponent)this).GetTransition("Drop");
		ShowRewardAndChoose = ((GComponent)this).GetTransition("ShowRewardAndChoose");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)ConfirmSelectionsBtn).onClick.Add(new EventCallback1(ChoiceListFade));
		((GObject)ReceiveBtn).onClick.Add(new EventCallback0(OnConfirmClaim));
		((GObject)againBtn).onClick.Add(new EventCallback0(QuickBattleAgain));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)ConfirmSelectionsBtn).onClick.Remove(new EventCallback1(ChoiceListFade));
		((GObject)ReceiveBtn).onClick.Remove(new EventCallback0(OnConfirmClaim));
		((GObject)againBtn).onClick.Remove(new EventCallback0(QuickBattleAgain));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UiHelper.LoadSpine_AB(EndIcon.VictorySfx, uiTitleAnimName, 100f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_victory", true);
		});
		if (parameters.TryGetValue("clearStages", out var value))
		{
			clearStages = (int)value;
		}
		if (parameters.TryGetValue("stages", out var value2))
		{
			stages = (int)value2;
		}
		if (parameters.TryGetValue("level", out var value3))
		{
			level = (Level)value3;
		}
		else
		{
			level = GameController.Contexts.Service<IBattleFieldService>().Level;
		}
		if (parameters.TryGetValue("capturedLevels", out var value4))
		{
			_capturedLevels = (List<string>)value4;
		}
		if (parameters.TryGetValue("fixBonuses", out var value5))
		{
			_fixBonuses = (Dictionary<string, List<Bonus>>)value5;
		}
		if (parameters.TryGetValue("lotteryBonuses", out var value6))
		{
			_lotteryBonuses = (List<Bonus>)value6;
		}
		if (parameters.TryGetValue("result", out var value7))
		{
			battleResult = (int)value7;
		}
		if (parameters.TryGetValue("stats", out var value8))
		{
			battleStats = value8;
		}
		if (parameters.TryGetValue("deadStats", out var value9))
		{
			redDeadStats = (Dictionary<string, int>)value9;
		}
		if (parameters.TryGetValue("QuickBattle", out var value10))
		{
			QuickBattle = (bool)value10;
		}
		if (parameters.TryGetValue("ShowSoldiersNumTip", out var value11))
		{
			showSoldiersNumTip = (bool)value11;
		}
		if (parameters.TryGetValue("CanBackInTime", out var value12))
		{
			canBackInTime = (bool)value12;
			if (canBackInTime)
			{
				if (parameters.TryGetValue("FreeCount", out var value13))
				{
					freeCount = (int)value13;
				}
				if (parameters.TryGetValue("Cost", out var value14))
				{
					backInTimeCost = (Dictionary<string, int>)value14;
				}
			}
		}
		if (parameters.TryGetValue("BattleId", out var value15))
		{
			battleId = value15.ToString();
		}
		if (parameters.TryGetValue("IsPortal", out var value16))
		{
			isPortal = (bool)value16;
		}
		if (parameters.TryGetValue("TicketNum", out var value17))
		{
			showAgainBattleBtn = (bool)value17;
		}
		switch (level.BattleMode)
		{
		case BattleMode.DefenceMode:
			isDefensive = true;
			break;
		case BattleMode.MultiWaveAttackMode:
			isOffensive = true;
			break;
		}
		if (isDefensive || (level.Chapter != null && (level.Chapter.Type == ChapterType.RepeatableInstance || level.Chapter.Type == ChapterType.RepeatableInstancePortal || level.Chapter.Type == ChapterType.TreasureHunt || level.Chapter.Type == ChapterType.RepeatableInstanceNeutral)))
		{
			PageController.selectedIndex = 2;
			((GObject)ReceiveBtn).alpha = 0f;
			((GObject)ReceiveBtn).touchable = false;
			InitHeadPortraitValue();
			((GObject)RewardAndChoose.experienceIncrement).alpha = 0f;
			PlayGetInstanceZonesReward();
			if (level.Chapter.Type != ChapterType.TreasureHunt)
			{
				ConfirmBattleBonus(level);
			}
		}
		else if (isOffensive)
		{
			PageController.selectedIndex = 4;
			((GObject)ReceiveBtn).alpha = 0f;
			((GObject)ReceiveBtn).touchable = false;
			InitHeadPortraitValue();
			((GObject)RewardAndChoose.experienceIncrement).alpha = 0f;
			PlayOffensiveInstanceZonesReward();
			ConfirmBattleBonus(level);
		}
		else
		{
			PageController.selectedIndex = 3;
			((GObject)ConfirmSelectionsBtn).alpha = 0f;
			((GObject)ConfirmSelectionsBtn).touchable = false;
			((GObject)ReceiveBtn).alpha = 0f;
			((GObject)ReceiveBtn).touchable = false;
			RewardAndChoose.PageController.selectedIndex = 0;
			RewardAndChoose.SetControllerPageText();
			if (GameController.Contexts.Service<IBattleFieldService>().Level.AutoProduceBonus.Count == 0)
			{
				((GObject)RewardAndChoose.IncomeBtn).visible = false;
			}
			float num = 0f;
			string text = "";
			float num2 = 0f;
			foreach (KeyValuePair<string, float> autoProduceBonu in GameController.Contexts.Service<IBattleFieldService>().Level.AutoProduceBonus)
			{
				num += autoProduceBonu.Value;
				text = autoProduceBonu.Key;
			}
			num2 = UiHelper.GetLevelMoneyOutput(level.LevelId, containBonus: false);
			float num3 = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency") + 1f;
			((GObject)RewardAndChoose.IncomeBtn.curIncome).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(((num - num2) * num3).ToString()) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248");
			((GObject)RewardAndChoose.IncomeBtn.curIncome).data = num * num3;
			((GObject)RewardAndChoose.IncomeBtn.nextIncome).data = (num - num2) * num3;
			((GObject)RewardAndChoose.IncomeBtn.nextIncome).text = "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint((num2 * num3).ToString()) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248");
			if (!string.IsNullOrWhiteSpace(text))
			{
				string icon = UiHelper.GetIcon(text);
				RewardAndChoose.IncomeBtn.icon.url = "ui://PublicResources/" + icon;
			}
			InitHeadPortraitValue();
			((GObject)RewardAndChoose.experienceIncrement).alpha = 0f;
			cardIndex = 0;
			RenderIntrinsicRewards();
			ListInit();
			ShowChoiceList();
		}
		SetControllerPageText();
		if (QuickBattle && (level.Chapter.Type == ChapterType.RepeatableInstance || level.Chapter.Type == ChapterType.RepeatableInstanceOffensive || level.Chapter.Type == ChapterType.RepeatableInstanceDefensive || level.Chapter.Type == ChapterType.RepeatableInstancePortal || level.Chapter.Type == ChapterType.RepeatableInstanceNeutral))
		{
			((GObject)BlackGround).alpha = 0f;
		}
		((GObject)EndIcon.ChooseText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText244") + ": " + level.Name;
		FGUIManager.Instance.GameEndPanelVictoryPanel = this;
	}

	private void GetTreasureHuntBattleResult()
	{
		if (level.Chapter.Type == ChapterType.TreasureHunt && canBackInTime)
		{
			((GObject)restart).y = 911f;
			((GObject)restart).visible = true;
			Action value = delegate
			{
				End();
				EnterNextLevel();
				UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
			};
			Dictionary<string, object> data = new Dictionary<string, object>
			{
				{ "FreeCount", freeCount },
				{ "Cost", backInTimeCost },
				{ "Action", value },
				{ "BattleId", battleId },
				{ "CurLevel", level }
			};
			((GObject)restart).data = data;
		}
	}

	private void OpenRestartDialog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, object> parameters = (Dictionary<string, object>)((GObject)context.sender).data;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_RestartPanel.Name, parameters);
	}

	private void InitHeadPortraitValue()
	{
		int userLevel = GameManagers.Instance.UserArchiveManager.GetUserLevel();
		((GObject)RewardAndChoose.levelText).text = ((userLevel == 0) ? "" : (LanguagesManager.GetDesc("CsharpCodeZhTcText194") + userLevel));
		((GObject)RewardAndChoose.nameText).text = FGUIManager.Instance.TruncateTextLength(LanguagesManager.GetDesc("CsharpCodeZhTcText395"), 20);
		double num = GameManagers.Instance.ConfigDataManager.GetUserCurLevelExp();
		double num2 = GameManagers.Instance.UserArchiveManager.GetUserExp();
		double num3 = GameManagers.Instance.ConfigDataManager.GetUserNextLevelExp();
		double value = (num2 - num) / (num3 - num) * 100.0;
		((GProgressBar)RewardAndChoose.experienceBar).value = value;
		((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(num2 - num)}/{Convert.ToInt32(num3 - num)}";
	}

	private float GetMoneySfxPlayDelay()
	{
		double num = GameManagers.Instance.UserArchiveManager.GetUserExp();
		double num2 = GameManagers.Instance.ConfigDataManager.GetUserNextLevelExp();
		if (curLevelGetExp < num2 - num)
		{
			missbleSfxDelay = 1f;
		}
		else
		{
			double num3 = num + curLevelGetExp;
			if (num2 <= num3)
			{
				missbleSfxDelay = 1.05f;
			}
			else
			{
				missbleSfxDelay = 1.5f;
			}
		}
		return missbleSfxDelay;
	}

	private void SetLevelExperienceBar()
	{
		double num = GameManagers.Instance.UserArchiveManager.GetUserExp();
		double num2 = GameManagers.Instance.ConfigDataManager.GetUserCurLevelExp();
		double num3 = GameManagers.Instance.ConfigDataManager.GetUserNextLevelExp();
		int userLevel = GameManagers.Instance.UserArchiveManager.GetUserLevel();
		if (curLevelGetExp < num3 - num)
		{
			double value = (num + curLevelGetExp - num2) / (num3 - num2) * 100.0;
			((GProgressBar)RewardAndChoose.experienceBar).value = value;
			((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(num + curLevelGetExp - num2)}/{Convert.ToInt32(num3 - num2)}";
			return;
		}
		double num4 = num + curLevelGetExp;
		int num5 = userLevel;
		double num6 = num3;
		double num7 = num2;
		for (int i = userLevel; i < GameManagers.Instance.ConfigDataManager.UserExpData.Count; i++)
		{
			int exp = GameManagers.Instance.ConfigDataManager.UserExpData[i].Exp;
			if ((double)exp > num4)
			{
				num5 = i - 1;
				num6 = exp;
				num7 = GameManagers.Instance.ConfigDataManager.UserExpData[i - 1].Exp;
				break;
			}
		}
		((GObject)RewardAndChoose.levelText).text = ((num5 == 0) ? "" : (LanguagesManager.GetDesc("CsharpCodeZhTcText194") + num5));
		double num8 = num4 - num7;
		if (num8 > 0.0)
		{
			double value2 = (num4 - num7) / (num6 - num7) * 100.0;
			((GProgressBar)RewardAndChoose.experienceBar).value = value2;
			((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(num4 - num7)}/{Convert.ToInt32(num6 - num7)}";
		}
		else
		{
			((GProgressBar)RewardAndChoose.experienceBar).value = 100.0;
			((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(num4 - num7)}/{Convert.ToInt32(num6 - num7)}";
		}
	}

	private void ShowExperienceGrowth()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		if (RewardAndChoose.StaticRewards.numItems == 0)
		{
			return;
		}
		GObject childAt = ((GComponent)RewardAndChoose.StaticRewards).GetChildAt(userExpBtnIndex);
		Vector2 val = childAt.LocalToGlobal(new Vector2(childAt.width / 2f, childAt.height / 2f));
		val = ((GObject)this).GlobalToLocal(val);
		((GObject)missbleSfxBack).SetXY(val.x, val.y);
		FGUIManager.Instance.AddTextSpecialEffects(missbleSfxBack, "exp_missile_green", Vector3.zero);
		Vector2 val2 = ((GObject)RewardAndChoose.experienceBar.SfxBack).LocalToGlobal(Vector2.zero);
		val2 = ((GObject)this).GlobalToLocal(val2);
		int userLevel = GameManagers.Instance.UserArchiveManager.GetUserLevel();
		double curLevelExp = GameManagers.Instance.ConfigDataManager.GetUserCurLevelExp();
		double curExp = GameManagers.Instance.UserArchiveManager.GetUserExp();
		double nextLevelExp = GameManagers.Instance.ConfigDataManager.GetUserNextLevelExp();
		GTweenCallback val5 = default(GTweenCallback);
		if (curLevelGetExp < nextLevelExp - curExp)
		{
			GTweener val3 = ((GObject)missbleSfxBack).TweenMove(val2, 0.5f / TransitionsTimeScale).OnComplete((GTweenCallback)delegate
			{
				//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected O, but got Unknown
				//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c7: Expected O, but got Unknown
				//IL_00cc: Expected O, but got Unknown
				((GObject)missbleSfxBack).AddRelation((GObject)(object)RewardAndChoose.experienceBar.bar, (RelationType)6);
				float getExp = 0f;
				double num2 = (curExp + curLevelGetExp - curLevelExp) / (nextLevelExp - curLevelExp) * 100.0;
				UiAudioManager.Instance.PlaySoundEffect("ExperienceGrowth");
				GTweener obj = ((GProgressBar)RewardAndChoose.experienceBar).TweenValue(num2, 0.5f).OnUpdate((GTweenCallback)delegate
				{
					getExp = Mathf.Lerp(getExp, (float)curLevelGetExp, 2f * Time.deltaTime);
					((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(curExp + (double)getExp - curLevelExp)}/{Convert.ToInt32(nextLevelExp - curLevelExp)}";
				});
				GTweenCallback obj2 = val5;
				if (obj2 == null)
				{
					GTweenCallback val6 = delegate
					{
						((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(curExp + curLevelGetExp - curLevelExp)}/{Convert.ToInt32(nextLevelExp - curLevelExp)}";
					};
					GTweenCallback val7 = val6;
					val5 = val6;
					obj2 = val7;
				}
				GTweener val8 = obj.OnComplete(obj2);
				val8.SetTimeScale(TransitionsTimeScale);
				tweeners.Add(val8);
			});
			val3.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val3);
			return;
		}
		double totalExp = curExp + curLevelGetExp;
		int nextLevel = userLevel;
		double newNextLevelExp = nextLevelExp;
		double newLevelExp = curLevelExp;
		for (int num = userLevel; num < GameManagers.Instance.ConfigDataManager.UserExpData.Count; num++)
		{
			int exp = GameManagers.Instance.ConfigDataManager.UserExpData[num].Exp;
			if ((double)exp > totalExp)
			{
				nextLevel = num - 1;
				newNextLevelExp = exp;
				newLevelExp = GameManagers.Instance.ConfigDataManager.UserExpData[num - 1].Exp;
				break;
			}
		}
		GTweenCallback val9 = default(GTweenCallback);
		GTweenCallback val12 = default(GTweenCallback);
		GTweener val4 = ((GObject)missbleSfxBack).TweenMove(val2, 0.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected O, but got Unknown
			//IL_00ce: Expected O, but got Unknown
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_0147: Expected O, but got Unknown
			((GObject)missbleSfxBack).AddRelation((GObject)(object)RewardAndChoose.experienceBar.bar, (RelationType)6);
			float getExp1 = 0f;
			double getExp1st = nextLevelExp - curExp;
			UiAudioManager.Instance.PlaySoundEffect("ExperienceGrowth");
			GTweener obj = ((GProgressBar)RewardAndChoose.experienceBar).TweenValue(100.0, 0.45f).OnUpdate((GTweenCallback)delegate
			{
				getExp1 = Mathf.Lerp(getExp1, (float)getExp1st, 2.2222223f * Time.deltaTime);
				((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(curExp + (double)getExp1 - curLevelExp)}/{Convert.ToInt32(nextLevelExp - curLevelExp)}";
			});
			GTweenCallback obj2 = val5;
			if (obj2 == null)
			{
				GTweenCallback val6 = delegate
				{
					//IL_0136: Unknown result type (might be due to invalid IL or missing references)
					((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(nextLevelExp - curLevelExp)}/{Convert.ToInt32(nextLevelExp - curLevelExp)}";
					((GObject)RewardAndChoose.experienceBar.bar).alpha = 0f;
					((GObject)missbleSfxBack).visible = false;
					((GProgressBar)RewardAndChoose.experienceBar).value = 0.0;
					((GObject)RewardAndChoose.levelText).text = ((nextLevel == 0) ? "" : (LanguagesManager.GetDesc("CsharpCodeZhTcText194") + nextLevel));
					FGUIManager.Instance.AddTextSpecialEffects(RewardAndChoose.levelSfxBack, FGUIManager.Instance.uiGreen, Vector3.zero);
				};
				GTweenCallback val7 = val6;
				val5 = val6;
				obj2 = val7;
			}
			GTweener val8 = obj.OnComplete(obj2);
			val8.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val8);
			GTweener obj3 = ((GComponent)(object)this).SetTimeout(0.55f / TransitionsTimeScale);
			GTweenCallback obj4 = val9;
			if (obj4 == null)
			{
				GTweenCallback val10 = delegate
				{
					//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
					//IL_00bc: Expected O, but got Unknown
					//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
					//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
					//IL_00d6: Expected O, but got Unknown
					//IL_00db: Expected O, but got Unknown
					float getExp2 = 0f;
					double getExp2nd = totalExp - newLevelExp;
					UiAudioManager.Instance.PlaySoundEffect("LevelUp");
					if (getExp2nd > 0.0)
					{
						double num2 = (totalExp - newLevelExp) / (newNextLevelExp - newLevelExp) * 100.0;
						UiAudioManager.Instance.PlaySoundEffect("ExperienceGrowth");
						GTweener obj5 = ((GProgressBar)RewardAndChoose.experienceBar).TweenValue(num2, 0.45f).OnUpdate((GTweenCallback)delegate
						{
							((GObject)RewardAndChoose.experienceBar.bar).alpha = 1f;
							((GObject)missbleSfxBack).visible = true;
							getExp2 = Mathf.Lerp(getExp2, (float)getExp2nd, 2.2222223f * Time.deltaTime);
							((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(getExp2)}/{Convert.ToInt32(newNextLevelExp - newLevelExp)}";
						});
						GTweenCallback obj6 = val12;
						if (obj6 == null)
						{
							GTweenCallback val13 = delegate
							{
								((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(totalExp - newLevelExp)}/{Convert.ToInt32(newNextLevelExp - newLevelExp)}";
							};
							GTweenCallback val14 = val13;
							val12 = val13;
							obj6 = val14;
						}
						GTweener val15 = obj5.OnComplete(obj6);
						val15.SetTimeScale(TransitionsTimeScale);
						tweeners.Add(val15);
					}
					else
					{
						((GObject)RewardAndChoose.experienceBar.num).text = $"{Convert.ToInt32(totalExp - newLevelExp)}/{Convert.ToInt32(newNextLevelExp - newLevelExp)}";
					}
				};
				GTweenCallback val7 = val10;
				val9 = val10;
				obj4 = val7;
			}
			GTweener val11 = obj3.OnComplete(obj4);
			val11.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val11);
		});
		val4.SetTimeScale(TransitionsTimeScale);
		tweeners.Add(val4);
		if (nextLevelExp <= totalExp)
		{
			missbleSfxDelay = 1.05f;
		}
		else
		{
			missbleSfxDelay = 1.5f;
		}
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		if (ChoiceList.numItems > 0)
		{
			instance.Register("Battle.BonusCardList", ChoiceList);
			instance.Register("Battle.BonusCard1", ((GComponent)ChoiceList).GetChildAt(0));
			if (ChoiceList.numItems > 1)
			{
				instance.Register("Battle.BonusCard2", ((GComponent)ChoiceList).GetChildAt(1));
				if (ChoiceList.numItems > 2)
				{
					instance.Register("Battle.BonusCard3", ((GComponent)ChoiceList).GetChildAt(2));
				}
			}
		}
		RewardAndChoose.StaticRewards.ResizeToFit(RewardAndChoose.StaticRewards.numItems);
		instance.Register("Battle.ConfirmClaimLotteryBtn", ConfirmSelectionsBtn);
		instance.Register("Battle.ConfirmSettlementBtn", ReceiveBtn);
		instance.Register("Battle.CaptureBonus", RewardAndChoose.IncomeBtn);
		UiAudioManager.Instance.PlayBackgroundSound("BattleWinBgm");
		if (QuickBattle && "RankBattleFieldLevel" == level.LevelId)
		{
			((GObject)BlackGround).alpha = 0.9f;
		}
	}

	public void BeforeDestroy()
	{
		FGUIManager.Instance.GameEndPanelVictoryPanel = null;
	}

	public void Destroy()
	{
		SpawnManager.Instance.UnloadAnimation(uiTitleAnimName);
		UiTagManager instance = UiTagManager.Instance;
		if (ChoiceList.numItems > 0)
		{
			instance.Unregister("Battle.BonusCardList", ChoiceList);
			instance.Unregister("Battle.BonusCard1", ((GComponent)ChoiceList).GetChildAt(0));
			if (ChoiceList.numItems > 1)
			{
				instance.Unregister("Battle.BonusCard2", ((GComponent)ChoiceList).GetChildAt(1));
				if (ChoiceList.numItems > 2)
				{
					instance.Unregister("Battle.BonusCard3", ((GComponent)ChoiceList).GetChildAt(2));
				}
			}
		}
		instance.Unregister("Battle.ConfirmClaimLotteryBtn", ConfirmSelectionsBtn);
		instance.Unregister("Battle.ConfirmSettlementBtn", ReceiveBtn);
		instance.Unregister("Battle.CaptureBonus", RewardAndChoose.IncomeBtn);
		UiAudioManager.Instance.StopBackgroundSound("BattleWinBgm");
	}

	private void End()
	{
		FGUIManager.Instance.CloseIEnumerator(_WaitLevelCompleted);
		if (isDefensive)
		{
			PageController.selectedIndex = 3;
			SetControllerPageText();
			InstanceZonesReward.StaticRewards.RemoveChildrenToPool();
		}
		else
		{
			RewardAndChoose.StaticRewards.RemoveChildrenToPool();
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		dropIconNameList.Clear();
		animationList.Clear();
		if (FGUIManager.Instance.DamageMeter != null)
		{
			FGUIManager.Instance.DamageMeter.End();
		}
	}

	public void OnConfirmClaim()
	{
		((GObject)ReceiveBtn).touchable = false;
		if (QuickBattle)
		{
			QuickLevelClaimBonus();
			GObject showingUi = GameController.Contexts.Service<IUiService>().GetShowingUi(UI_InstanceZonesPanel.Name);
			if (showingUi != null)
			{
				UI_InstanceZonesPanel uI_InstanceZonesPanel = (UI_InstanceZonesPanel)(object)showingUi;
				uI_InstanceZonesPanel.SetQuickBattlePanelBackVisible(_visible: false);
				if (isPortal)
				{
					uI_InstanceZonesPanel.WormholeEvent(null);
				}
				else
				{
					uI_InstanceZonesPanel.UpdateTimeLimitInstanceZones();
				}
			}
			string currentLevelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			Level level = (string.IsNullOrEmpty(currentLevelId) ? null : GameManagers.Instance.ChapterManager.GetLevelInstance(currentLevelId));
			GameController.Contexts.Service<IBattleFieldService>().Level = level;
		}
		else if (this.level.Chapter.Type == ChapterType.TreasureHunt)
		{
			if (!string.IsNullOrEmpty(LegendItemDungeonUiHelper.BossLevelId) && this.level.LevelId == LegendItemDungeonUiHelper.BossLevelId)
			{
				RewardAndChoose.TreasureHuntBossLevelBox.End();
				LevelClaimLevelBonus();
				return;
			}
			Action resultFalseAction = delegate
			{
				((GObject)ReceiveBtn).touchable = true;
			};
			ConfirmBattleBonus(this.level, LevelClaimLevelBonus, resultFalseAction);
		}
		else
		{
			LevelClaimLevelBonus();
		}
	}

	private bool TreasureHuntBossLevelBonusListInit()
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		if (level.Chapter.Type == ChapterType.TreasureHunt && !string.IsNullOrEmpty(LegendItemDungeonUiHelper.BossLevelId) && level.LevelId == LegendItemDungeonUiHelper.BossLevelId)
		{
			((GObject)RewardAndChoose.StaticRewards).alpha = 0f;
			((GObject)RewardAndChoose.StaticRewards).SetScale(0f, 0f);
			((GObject)RewardAndChoose.TreasureHuntBossLevelBox).onClick.Set(new EventCallback0(ClaimTreasureHuntBossBonus));
			Action action = delegate
			{
				//IL_0013: Unknown result type (might be due to invalid IL or missing references)
				//IL_001d: Expected O, but got Unknown
				RewardAndChoose.ShowTreasureHuntBossLevelBonus.Play((PlayCompleteCallback)delegate
				{
					ShowExperienceGrowth();
					((GObject)ReceiveBtn).touchable = true;
					((GObject)ReceiveBtn).alpha = 1f;
				});
			};
			RewardAndChoose.TreasureHuntBossLevelBox.Init(action);
			return false;
		}
		return true;
	}

	private void ClaimTreasureHuntBossBonus()
	{
		Action callback = delegate
		{
			TreasureHuntBossLevelRewardRender();
			for (int i = 0; i < RewardAndChoose.StaticRewards.numItems; i++)
			{
				GButton asButton = ((GComponent)RewardAndChoose.StaticRewards).GetChildAt(i).asButton;
				((GObject)asButton).alpha = 1f;
			}
			RewardAndChoose.TreasureHuntBossLevelBox.Play();
		};
		ConfirmBattleBonus(level, callback);
	}

	public void TreasureHuntBossLevelRewardRender()
	{
		if (_finalBonuses == null || _finalBonuses.Count <= 0)
		{
			return;
		}
		RewardAndChoose.StaticRewards.RemoveChildrenToPool();
		Dictionary<string, int> dictionary = new Dictionary<string, int>
		{
			{ "I40015", 0 },
			{ "I40016", 0 },
			{ "I40017", 0 },
			{ "I40018", 0 }
		};
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		int num = 0;
		foreach (Bonus finalBonuse in _finalBonuses)
		{
			if (dictionary.ContainsKey(finalBonuse.ItemId))
			{
				dictionary[finalBonuse.ItemId] = finalBonuse.Qty;
			}
			if (!dictionary2.ContainsKey(finalBonuse.ItemId))
			{
				dictionary2.Add(finalBonuse.ItemId, finalBonuse.Qty);
			}
			else
			{
				dictionary2[finalBonuse.ItemId] += finalBonuse.Qty;
			}
			if (finalBonuse.Qty > 0)
			{
				if (finalBonuse.ItemId == "UserExp")
				{
					curLevelGetExp = finalBonuse.Qty;
					userExpBtnIndex = num;
				}
				RewardAndChoose.StaticRewards.AddItemFromPool("ui://hda5vzklvv0u2q");
				((GObject)((GComponent)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(num).asButton).GetChild("title").asTextField).text = $"+{finalBonuse.Qty}";
				LaodV_DropListItems(num, finalBonuse);
				num++;
			}
		}
		if (RewardAndChoose.StaticRewards.numItems <= 3)
		{
			RewardAndChoose.StaticRewards.columnGap = 12;
		}
		else if (RewardAndChoose.StaticRewards.numItems > 3)
		{
			RewardAndChoose.StaticRewards.columnGap = -8;
		}
	}

	private async void LevelClaimLevelBonus()
	{
		level.ClaimLevelBonus(GameManagers.Instance, _finalBonuses);
		if (GetScore > 0f)
		{
			level.FromUiParams.Add("GetScore", GetScore);
			level.FromUiParams.Add("LevelId", level.LevelId);
		}
		if (level.LevelId == LegendItemDungeonUiHelper.CurLevelId)
		{
			LegendItemDungeonUiHelper.GetTreasureHuntActivityProgress(await GameController.Contexts.Service<INetworkService>().GetTreasureHuntActivityProgress());
		}
		CacheManager.Instance.Get<Cache_StoreContentConfigData>().UpdateBlackMarketStoreItems(level.LevelId);
		End();
		if (level.LevelId == "P520")
		{
			await LegendItemsHelper.GetLegendItemsData();
		}
		EnterNextLevel();
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
	}

	public void QuickLevelClaimBonusForPlayVideo()
	{
		level.ClaimLevelBonus(GameManagers.Instance, _finalBonuses);
	}

	private async void QuickLevelClaimBonus()
	{
		level.ClaimLevelBonus(GameManagers.Instance, _finalBonuses);
		End();
		UiAudioManager.Instance.PlaySoundEffect("CoinDrop");
	}

	private void EnterNextLevel()
	{
		ScriptApi.CreateTimer(0.5f, delegate
		{
			if (GameController.Contexts.Service<IUiService>().HasShowingUi())
			{
				EnterNextLevel();
			}
			else if (!level.PlayAfterClaim(GameManagers.Instance) && !level.PlayAfterComplete(GameManagers.Instance))
			{
				for (int i = 0; i < textureList.Count; i++)
				{
					AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
				}
				GameController.Contexts.Service<IBattleFieldService>().EnterNextLevel();
			}
		});
	}

	private void ChoiceListButton(GButton button, int index)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		if (chosenIndex != -1 && (Object)(object)animationList[chosenIndex] != (Object)null)
		{
			animationList[chosenIndex].transform.localScale = soldierScale;
		}
		chosenIndex = index;
		((GObject)ConfirmSelectionsBtn).alpha = 1f;
		((GObject)ConfirmSelectionsBtn).touchable = true;
		for (int i = 0; i < ChoiceList.numItems; i++)
		{
			if (chosenIndex == i && (Object)(object)animationList[i] != (Object)null)
			{
				animationList[i].transform.localScale = soldierScale * 1.05f;
			}
		}
	}

	private void ChoiceListFade(EventContext eventContext)
	{
		if (popupCardData[chosenIndex].Category == 2 && GameManagers.Instance.TechnologyManager.IsUnlockDuplicated(popupCardData[chosenIndex].ItemId))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText245") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText246") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText247") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{ "Confirm", On3Pick1BonusConfirmed },
						{
							"Cancel",
							delegate
							{
							}
						}
					}
				},
				{ "PageIndex", 0 },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else
		{
			On3Pick1BonusConfirmed();
		}
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
	}

	private void On3Pick1BonusConfirmed()
	{
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		EndIcon.maximize.Play();
		((GObject)ConfirmSelectionsBtn).alpha = 0f;
		((GObject)ConfirmSelectionsBtn).touchable = false;
		((GObject)ChoiceList).touchable = false;
		for (int i = 0; i < ChoiceList.numItems; i++)
		{
			if (chosenIndex == i)
			{
				((GObject)((GComponent)ChoiceList).GetChildAt(i).asButton).alpha = 1f;
				continue;
			}
			((GObject)((GComponent)ChoiceList).GetChildAt(i).asButton).alpha = 0f;
			((GObject)((GComponent)((GComponent)ChoiceList).GetChildAt(i).asButton).GetChild("fxBack").asGraph).displayObject.Dispose();
		}
		for (int j = 0; j < animationList.Count; j++)
		{
			if ((Object)(object)animationList[j] != (Object)null)
			{
				animationList[j].SetActive(false);
			}
		}
		((GObject)EndIcon.ChooseText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText244") + ": " + level.Name;
		((GObject)titleBackup).visible = false;
		if (popupCardData != null && popupCardData.Count != 0)
		{
			Bonus bonus = popupCardData[chosenIndex];
			if (Shift.Legion.Common.Models.Item.ItemType(bonus.ItemId) == 9)
			{
				string text = string.Empty;
				List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, bonus.ItemId);
				foreach (Modifier item in list)
				{
					if (item.ModifierId == "Bonus")
					{
						text = ((List<string>)item.PayloadDictionary["Unlock"]).First();
						break;
					}
				}
				FGUIManager.Instance.BlueprintUpGradeInfo = new Tuple<string, string, int, Dictionary<string, string>>(text, bonus.ItemId, bonus.Qty, Shift.Legion.Common.Models.Item.GetItemBonus(GameManagers.Instance, text));
			}
			UI_StaticReward myChoice = UI_StaticReward.CreateInstance();
			((GObject)myChoice).alpha = 0f;
			((GObject)myChoice).SetPivot(0.5f, 0.5f, true);
			((GComponent)GRoot.inst).AddChild((GObject)(object)myChoice);
			((GComponent)this).AddChild((GObject)(object)myChoice);
			Vector2 val = ((GObject)((GComponent)ChoiceList).GetChildAt(chosenIndex).asButton).LocalToGlobal(Vector2.one / 2f);
			val = ((GObject)this).GlobalToLocal(val);
			((GObject)myChoice).SetXY(val.x, val.y);
			Vector2 aimPos = ((GObject)RewardAndChoose.choose).LocalToGlobal(Vector2.one / 2f);
			aimPos = ((GObject)this).GlobalToLocal(aimPos);
			if (Shift.Legion.Common.Models.Item.ItemType(bonus.ItemId) == 3)
			{
				FGUIManager.Instance.SetItemIconAndFrame(((GObject)myChoice.icon).asLoader, bonus.ItemId, textureList, "", frameVisible: false, 0.65f);
			}
			else
			{
				((GObject)myChoice.icon).asLoader.url = "ui://PublicResources/" + dropIconNameList[chosenIndex];
			}
			if (Shift.Legion.Common.Models.Item.ItemType(bonus.ItemId) == 8 || Shift.Legion.Common.Models.Item.ItemType(bonus.ItemId) == 10)
			{
				((GComponent)myChoice).GetController("Type").selectedIndex = 1;
			}
			((GObject)myChoice.title).text = $"+{bonus.Qty}";
			if (bonus.IsShining == 2 || bonus.Category == 2)
			{
				((GObject)((GComponent)myChoice).GetChild("fxBack").asGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)myChoice).GetChild("fxBack").asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
			}
			((GObject)((GComponent)ChoiceList).GetChildAt(chosenIndex).asButton).TweenFade(0f, 0.5f).SetEase((EaseType)5);
			((GObject)((GComponent)((GComponent)ChoiceList).GetChildAt(chosenIndex).asButton).GetChild("fxBack").asGraph).displayObject.Dispose();
			((GObject)myChoice).TweenFade(1f, 0.5f).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
			{
				//IL_0031: Unknown result type (might be due to invalid IL or missing references)
				//IL_005b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				//IL_0066: Expected O, but got Unknown
				ConfirmBattleBonus(level, ShowIntrinsicRewards);
				GTweener obj = ((GObject)myChoice).TweenMove(aimPos, 0.5f).SetEase((EaseType)26);
				object obj2 = _003C_003Ec._003C_003E9__98_2;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						UiAudioManager.Instance.PlaySoundEffect("ItemDrop");
					};
					_003C_003Ec._003C_003E9__98_2 = val2;
					obj2 = (object)val2;
				}
				obj.OnComplete((GTweenCallback)obj2);
			});
			((GObject)myChoice).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(bonus.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
			SharedMessenger.Broadcast("ON_BONUS_CARDS_CONFIRM", bonus);
			ThinkingDataHelper.Instance.MainlineCompletedTrack(popupCardData[0].ItemId, popupCardData[0].Qty, popupCardData[1].ItemId, popupCardData[1].Qty, popupCardData[2].ItemId, popupCardData[2].Qty, bonus.ItemId, bonus.Qty);
		}
		else
		{
			SharedMessenger.Broadcast<Bonus>("ON_BONUS_CARDS_CONFIRM", null);
			ConfirmBattleBonus(level, ShowIntrinsicRewards);
		}
	}

	private void SkipTransitions()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Remove(new EventCallback0(SkipTransitions));
		TransitionsTimeScale = 10f;
		ShowRewardAndChoose.timeScale = TransitionsTimeScale;
		RewardAndChoose.ShowPoints.timeScale = TransitionsTimeScale;
		RewardAndChoose.ShowIncome.timeScale = TransitionsTimeScale;
		RewardAndChoose.IncomeBtn.ShowIncome.timeScale = TransitionsTimeScale;
		RewardAndChoose.ShowTreasureHuntBossLevelBonus.timeScale = TransitionsTimeScale;
		RewardAndChoose.TreasureHuntBossLevelBox.DetectorDisappear.timeScale = TransitionsTimeScale;
		for (int i = 0; i < tweeners.Count; i++)
		{
			if (tweeners[i] != null)
			{
				tweeners[i].SetTimeScale(TransitionsTimeScale);
			}
		}
	}

	private void interruptTransiton()
	{
		for (int i = 0; i < tweeners.Count; i++)
		{
			if (tweeners[i] != null)
			{
				tweeners[i].Kill(true);
			}
		}
		if (ShowRewardAndChoose.playing)
		{
			ShowRewardAndChoose.Stop(true, true);
		}
		if (RewardAndChoose.MainReward.Grayed.playing)
		{
			RewardAndChoose.MainReward.Grayed.Stop(true, true);
		}
		for (int j = 0; j < RewardAndChoose.StaticRewards.numItems; j++)
		{
			GButton asButton = ((GComponent)RewardAndChoose.StaticRewards).GetChildAt(j).asButton;
			if (((GComponent)asButton).GetTransition("ShowSelf").playing)
			{
				((GComponent)asButton).GetTransition("ShowSelf").Stop();
			}
			((GObject)asButton).alpha = 1f;
			((GObject)asButton).SetScale(1f, 1f);
		}
		SetLevelExperienceBar();
		if (RewardAndChoose.PageController.selectedIndex == 0)
		{
			if (RewardAndChoose.ShowIncome.playing)
			{
				RewardAndChoose.ShowIncome.Stop(true, true);
			}
			if (RewardAndChoose.IncomeBtn.ShowIncome.playing)
			{
				RewardAndChoose.IncomeBtn.ShowIncome.Stop(true, true);
			}
			float num = (float)((GObject)RewardAndChoose.IncomeBtn.curIncome).data;
			((GObject)RewardAndChoose.IncomeBtn.curIncome).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(num.ToString()) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248");
		}
		else if (RewardAndChoose.ShowPoints.playing)
		{
			RewardAndChoose.ShowPoints.Stop(true, true);
		}
		((GObject)ReceiveBtn).touchable = true;
	}

	private void ShowIntrinsicRewards()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		((GObject)this).onClick.Add(new EventCallback0(SkipTransitions));
		for (int i = 0; i < RewardAndChoose.StaticRewards.numItems; i++)
		{
			GButton asButton = ((GComponent)RewardAndChoose.StaticRewards).GetChildAt(i).asButton;
			((GObject)asButton).alpha = 0f;
			((GObject)asButton).SetScale(0.25f, 0.25f);
		}
		ShowRewardAndChoose.Play((PlayCompleteCallback)delegate
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Expected O, but got Unknown
			float num = 0.33f;
			for (int j = 0; j < RewardAndChoose.StaticRewards.numItems; j++)
			{
				int index = j;
				GTweener val = ((GComponent)(object)this).SetTimeout(num / TransitionsTimeScale).OnComplete((GTweenCallback)delegate
				{
					Transition transition = ((GComponent)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(index).asButton).GetTransition("ShowSelf");
					transition.Play();
					transition.timeScale = TransitionsTimeScale;
				});
				val.SetTimeScale(TransitionsTimeScale);
				tweeners.Add(val);
				num += 0.42f;
			}
			GTweener val2 = ((GComponent)(object)this).SetTimeout(num / TransitionsTimeScale).OnComplete(new GTweenCallback(ShowExperienceGrowth));
			val2.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val2);
			if (level.ChapterId != "C1000" && level.ChapterId != "C10000" && level.ChapterId != "C10001" && level.ChapterId != "C1000" && level.ChapterId != "C10002")
			{
				missbleSfxDelay = GetMoneySfxPlayDelay();
			}
			else
			{
				missbleSfxDelay = 0f;
			}
			GTweener val3 = ((GComponent)(object)this).SetTimeout((num + missbleSfxDelay + 0.33f) / TransitionsTimeScale).OnComplete((GTweenCallback)delegate
			{
				//IL_0013: Unknown result type (might be due to invalid IL or missing references)
				//IL_001d: Expected O, but got Unknown
				RewardAndChoose.ShowIncome.Play((PlayCompleteCallback)delegate
				{
					//IL_0018: Unknown result type (might be due to invalid IL or missing references)
					//IL_0022: Expected O, but got Unknown
					RewardAndChoose.IncomeBtn.ShowIncome.Play((PlayCompleteCallback)delegate
					{
						//IL_0050: Unknown result type (might be due to invalid IL or missing references)
						//IL_005a: Expected O, but got Unknown
						//IL_008e: Unknown result type (might be due to invalid IL or missing references)
						//IL_0098: Expected O, but got Unknown
						float num2 = (float)((GObject)RewardAndChoose.IncomeBtn.nextIncome).data;
						float num3 = (float)((GObject)RewardAndChoose.IncomeBtn.curIncome).data;
						GTweener val4 = GTween.To(num2, num3, 0.8f).SetEase((EaseType)0).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
						{
							((GObject)RewardAndChoose.IncomeBtn.curIncome).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Mathf.Floor(tweener.value.x).ToString() ?? "") + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText248");
						});
						val4.SetTimeScale(TransitionsTimeScale);
						tweeners.Add(val4);
						GTweener val5 = ((GComponent)(object)this).SetTimeout(0.8f / TransitionsTimeScale).OnComplete((GTweenCallback)delegate
						{
							//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
							//IL_00b8: Expected O, but got Unknown
							SharedMessenger.Broadcast("ON_LEVEL_BONUS_SETTLEMENT_POPUP");
							Dictionary<string, object> dictionary = new Dictionary<string, object>
							{
								{
									"SortingOrder",
									((GObject)this).sortingOrder + 1
								},
								{ "BattleResult", battleResult },
								{ "BattleStats", battleStats }
							};
							if (QuickBattle)
							{
								dictionary.Add("ShowLookBack", true);
							}
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, dictionary);
							GTweener val6 = ((GObject)ReceiveBtn).TweenFade(1f, 0.42f).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
							{
								((GObject)ReceiveBtn).touchable = true;
							});
							val6.SetTimeScale(TransitionsTimeScale);
							tweeners.Add(val6);
						});
						val5.SetTimeScale(TransitionsTimeScale);
						tweeners.Add(val5);
					});
				});
			});
			val3.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val3);
		});
	}

	private void ConfirmBattleBonus(Level _level, Action callback = null, Action resultFalseAction = null)
	{
		ILRequestHelper<ConfirmBattleBonusResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().ConfirmBattleBonus(battleId, chosenIndex), delegate(ConfirmBattleBonusResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				resultFalseAction?.Invoke();
			}
			else
			{
				_finalBonuses = new List<Bonus>();
				if (response.Bonuses != null && response.Bonuses.Count > 0)
				{
					foreach (ModelsBonus bonuse in response.Bonuses)
					{
						_finalBonuses.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
					}
				}
				if (_level?.ChapterId == "C1000" || level?.ChapterId == "C10000" || level?.ChapterId == "C10001" || level?.ChapterId == "C1000" || level?.ChapterId == "C10002")
				{
					ClientBattleFieldLogic.UpdateSoldierStockWhenBattleEnd(GameManagers.Instance, redDeadStats);
				}
				GameManagers.Instance.UserArchiveManager.RemoveCurrentBattleId();
				callback?.Invoke();
				if (isOffensive)
				{
					GameManagers.Instance.Messenger.Broadcast("ATTACK_INSTANCE_CLAIMED_FINAL_PRIZE");
				}
				GameManagers.Instance.Messenger.Broadcast("LEVEL_BONUS_CLAIMED", _level);
			}
		}, 1f);
	}

	public void RenderIntrinsicRewards()
	{
		int num = 0;
		List<Bonus> bonusRecord = GameController.Contexts.gameState.battleProgressStats.bonusRecord;
		foreach (Bonus item in bonusRecord)
		{
			if (Shift.Legion.Common.Models.Item.ItemType(item.ItemId) != 22 && Shift.Legion.Common.Models.Item.ItemType(item.ItemId) != 23 && Shift.Legion.Common.Models.Item.ItemType(item.ItemId) != 24 && item.Qty > 0)
			{
				if (item.ItemId == "UserExp")
				{
					curLevelGetExp = item.Qty;
					userExpBtnIndex = num;
				}
				RewardAndChoose.StaticRewards.AddItemFromPool("ui://hda5vzklvv0u2q");
				((GObject)((GComponent)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(num).asButton).GetChild("title").asTextField).text = $"+{item.Qty}";
				LaodV_DropListItems(num, item);
				num++;
			}
		}
		if (RewardAndChoose.StaticRewards.numItems <= 3)
		{
			RewardAndChoose.StaticRewards.columnGap = 12;
		}
		else if (RewardAndChoose.StaticRewards.numItems > 3)
		{
			RewardAndChoose.StaticRewards.columnGap = -8;
		}
	}

	public void RenderIntrinsicOffensiveTotalRewards()
	{
		List<Bonus> list = ((clearStages >= stages) ? Bonus.MergeBonuses(_fixBonuses) : GameController.Contexts.gameState.battleProgressStats.bonusRecord);
		int num = 0;
		foreach (Bonus item in list)
		{
			if (item.Qty > 0)
			{
				if (item.ItemId == "UserExp")
				{
					curLevelGetExp = item.Qty;
					userExpBtnIndex = num;
				}
				RewardAndChoose.StaticRewards.AddItemFromPool("ui://hda5vzklvv0u2q");
				((GObject)((GComponent)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(num).asButton).GetChild("title").asTextField).text = $"+{item.Qty}";
				LaodV_DropListItems(num, item);
				num++;
			}
		}
		if (RewardAndChoose.StaticRewards.numItems <= 3)
		{
			RewardAndChoose.StaticRewards.columnGap = 12;
		}
		else if (RewardAndChoose.StaticRewards.numItems > 3)
		{
			RewardAndChoose.StaticRewards.columnGap = -8;
		}
	}

	private void PlayOffensiveInstanceZonesReward()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		((GObject)this).onClick.Add(new EventCallback0(SkipTransitions));
		RewardAndChoose.PageController.selectedIndex = 1;
		RewardAndChoose.SetControllerPageText();
		((GObject)RewardAndChoose.IncomeText).text = "";
		Bonus titleBonus = null;
		List<Bonus> lotteryBonuses = _lotteryBonuses;
		if (lotteryBonuses != null && lotteryBonuses.Count > 0)
		{
			titleBonus = _lotteryBonuses.First();
			((GObject)RewardAndChoose.MainReward.title).text = $"+{titleBonus.Qty}";
			FGUIManager.Instance.SetItemIconAndFrame(RewardAndChoose.MainReward.icon, titleBonus.ItemId, textureList, "", frameVisible: false, 0.65f);
			((GObject)RewardAndChoose.MainReward).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(titleBonus.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		((GObject)RewardAndChoose.IncomeText).text = string.Format("{0}:[color=#51ee31]{1}/{2}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText249"), clearStages, stages);
		RenderIntrinsicOffensiveTotalRewards();
		for (int num = 0; num < RewardAndChoose.StaticRewards.numItems; num++)
		{
			GButton asButton = ((GComponent)RewardAndChoose.StaticRewards).GetChildAt(num).asButton;
			((GObject)asButton).alpha = 0f;
			((GObject)asButton).SetScale(0.25f, 0.25f);
		}
		ShowRewardAndChoose.timeScale = TransitionsTimeScale;
		GTweenCallback val = default(GTweenCallback);
		GTweenCallback val7 = default(GTweenCallback);
		PlayCompleteCallback val10 = default(PlayCompleteCallback);
		GTweenCallback val13 = default(GTweenCallback);
		ShowRewardAndChoose.Play((PlayCompleteCallback)delegate
		{
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0059: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Expected O, but got Unknown
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Expected O, but got Unknown
			//IL_01cc: Expected O, but got Unknown
			if (clearStages < stages)
			{
				GTweener obj = ((GComponent)(object)this).SetTimeout(0.25f / TransitionsTimeScale);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						RewardAndChoose.MainReward.Grayed.Play();
						if (RewardAndChoose.MainReward.icon.component != null)
						{
							((GObject)RewardAndChoose.MainReward.icon.component).grayed = true;
						}
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				GTweener val4 = obj.OnComplete(obj2);
				val4.SetTimeScale(TransitionsTimeScale);
				tweeners.Add(val4);
			}
			float num2 = 0.33f;
			for (int num3 = 0; num3 < RewardAndChoose.StaticRewards.numItems; num3++)
			{
				int index = num3;
				GTweener val5 = ((GComponent)(object)this).SetTimeout(num2 / TransitionsTimeScale).OnComplete((GTweenCallback)delegate
				{
					Transition transition = ((GComponent)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(index).asButton).GetTransition("ShowSelf");
					transition.Play();
					transition.timeScale = TransitionsTimeScale;
				});
				val5.SetTimeScale(TransitionsTimeScale);
				tweeners.Add(val5);
				num2 += 0.42f;
			}
			GTweener val6 = ((GComponent)(object)this).SetTimeout(num2 / TransitionsTimeScale).OnComplete(new GTweenCallback(ShowExperienceGrowth));
			val6.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val6);
			GTweener obj3 = ((GComponent)(object)this).SetTimeout((num2 + missbleSfxDelay + 0.33f) / TransitionsTimeScale);
			GTweenCallback obj4 = val7;
			if (obj4 == null)
			{
				GTweenCallback val8 = delegate
				{
					//IL_0023: Unknown result type (might be due to invalid IL or missing references)
					//IL_0028: Unknown result type (might be due to invalid IL or missing references)
					//IL_002a: Expected O, but got Unknown
					//IL_002f: Expected O, but got Unknown
					Transition showPoints = RewardAndChoose.ShowPoints;
					PlayCompleteCallback obj5 = val10;
					if (obj5 == null)
					{
						PlayCompleteCallback val11 = delegate
						{
							//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
							//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
							//IL_00ce: Expected O, but got Unknown
							//IL_00d3: Expected O, but got Unknown
							Dictionary<string, object> dictionary = new Dictionary<string, object>
							{
								{
									"SortingOrder",
									((GObject)this).sortingOrder + 1
								},
								{ "BattleResult", battleResult },
								{ "BattleStats", battleStats }
							};
							if (QuickBattle)
							{
								dictionary.Add("ShowLookBack", true);
							}
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, dictionary);
							GTweener obj6 = ((GObject)ReceiveBtn).TweenFade(1f, 0.42f).SetEase((EaseType)5);
							GTweenCallback obj7 = val13;
							if (obj7 == null)
							{
								GTweenCallback val14 = delegate
								{
									((GObject)ReceiveBtn).touchable = true;
								};
								GTweenCallback val15 = val14;
								val13 = val14;
								obj7 = val15;
							}
							GTweener val16 = obj6.OnComplete(obj7);
							val16.SetTimeScale(TransitionsTimeScale);
							tweeners.Add(val16);
						};
						PlayCompleteCallback val12 = val11;
						val10 = val11;
						obj5 = val12;
					}
					showPoints.Play(obj5);
					RewardAndChoose.ShowPoints.timeScale = TransitionsTimeScale;
				};
				GTweenCallback val3 = val8;
				val7 = val8;
				obj4 = val3;
			}
			GTweener val9 = obj3.OnComplete(obj4);
			val9.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val9);
		});
		if (clearStages >= stages)
		{
			ThinkingDataHelper.Instance.AttackCompletedTrack(level.LevelId, level.Difficult, titleBonus?.ItemId, clearStages, stages);
		}
		else
		{
			ThinkingDataHelper.Instance.AttackFailedTrack(level.LevelId, level.Difficult, clearStages);
		}
	}

	private void PlayGetInstanceZonesReward()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		((GObject)this).onClick.Add(new EventCallback0(SkipTransitions));
		RewardAndChoose.PageController.selectedIndex = 2;
		RewardAndChoose.SetControllerPageText();
		((GObject)RewardAndChoose.IncomeText).text = "";
		int num = 0;
		if (level.FromUiParams != null && level.FromUiParams.TryGetValue("Activity", out var value) && value is Activity activity && activity.ContentPayload(GameManagers.Instance).TryGetValue(level.ChapterId, out var value2))
		{
			num = ((ChapterActivityPayload)value2).Score;
			string arg = Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, activity.ScoreItem);
			((GObject)RewardAndChoose.IncomeText).text = string.Format("{0}{1}：{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText78"), arg, num);
			GetScore = num;
			if (!string.IsNullOrEmpty(activity.ScoreItem))
			{
				RewardAndChoose.pointsIcon.url = "ui://PublicResources/" + UiHelper.GetIcon(activity.ScoreItem);
				Dictionary<string, object> extraScore = ((ChapterActivityPayload)value2).ExtraScore;
				if (extraScore != null && extraScore.Count > 0 && ActivityManager.Activities.TryGetValue(extraScore.First().Key, out var value3))
				{
					((GObject)RewardAndChoose.ExtraScoreGroup).visible = true;
					((GObject)RewardAndChoose.ExtraScoreText).text = $" [size=30][color=#d69149]&[/color][/size] {extraScore.First().Value}";
					RewardAndChoose.ExtraScoreIcon.url = "ui://PublicResources/" + UiHelper.GetIcon(value3.ScoreItem);
				}
			}
		}
		if (num <= 0)
		{
			((GObject)RewardAndChoose.IncomeText).visible = false;
			((GObject)RewardAndChoose.pointsIcon).visible = false;
			((GObject)RewardAndChoose.ExtraScoreGroup).visible = false;
		}
		else if (LegendItemDungeonUiHelper.LegendItemDungeonLevels.Count > 0 && LegendItemDungeonUiHelper.LegendItemDungeonLevels.ContainsKey("BOSS"))
		{
			string levelId = LegendItemDungeonUiHelper.LegendItemDungeonLevels["BOSS"].First().LevelId;
			if (level.LevelId == levelId)
			{
				((GObject)RewardAndChoose.IncomeText).visible = false;
				((GObject)RewardAndChoose.pointsIcon).visible = false;
				((GObject)RewardAndChoose.ExtraScoreGroup).visible = false;
			}
		}
		InstanceZonesRewardRender();
		bool playCommonSfx = TreasureHuntBossLevelBonusListInit();
		if (playCommonSfx)
		{
			for (int i = 0; i < RewardAndChoose.StaticRewards.numItems; i++)
			{
				GButton asButton = ((GComponent)RewardAndChoose.StaticRewards).GetChildAt(i).asButton;
				((GObject)asButton).alpha = 0f;
				((GObject)asButton).SetScale(0.25f, 0.25f);
			}
		}
		GTweenCallback val2 = default(GTweenCallback);
		PlayCompleteCallback val6 = default(PlayCompleteCallback);
		ShowRewardAndChoose.Play((PlayCompleteCallback)delegate
		{
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0108: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			float num2 = 0.33f;
			if (playCommonSfx)
			{
				for (int j = 0; j < RewardAndChoose.StaticRewards.numItems; j++)
				{
					int index = j;
					GTweener val = ((GComponent)(object)this).SetTimeout(num2 / TransitionsTimeScale).OnComplete((GTweenCallback)delegate
					{
						Transition transition = ((GComponent)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(index).asButton).GetTransition("ShowSelf");
						transition.Play();
						transition.timeScale = TransitionsTimeScale;
					});
					val.SetTimeScale(TransitionsTimeScale);
					tweeners.Add(val);
					num2 += 0.42f;
				}
			}
			ShowExperienceGrowthSfx(num2);
			GTweener obj = ((GComponent)(object)this).SetTimeout((num2 + missbleSfxDelay + 0.33f) / TransitionsTimeScale);
			GTweenCallback obj2 = val2;
			if (obj2 == null)
			{
				GTweenCallback val3 = delegate
				{
					//IL_0023: Unknown result type (might be due to invalid IL or missing references)
					//IL_0028: Unknown result type (might be due to invalid IL or missing references)
					//IL_002a: Expected O, but got Unknown
					//IL_002f: Expected O, but got Unknown
					Transition showPoints = RewardAndChoose.ShowPoints;
					PlayCompleteCallback obj3 = val6;
					if (obj3 == null)
					{
						PlayCompleteCallback val7 = delegate
						{
							Dictionary<string, object> dictionary = new Dictionary<string, object>
							{
								{
									"SortingOrder",
									((GObject)this).sortingOrder + 1
								},
								{ "BattleResult", battleResult },
								{ "BattleStats", battleStats }
							};
							if (QuickBattle)
							{
								dictionary.Add("ShowLookBack", true);
							}
							GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, dictionary);
							ShowReceiveBtn();
						};
						PlayCompleteCallback val8 = val7;
						val6 = val7;
						obj3 = val8;
					}
					showPoints.Play(obj3);
					RewardAndChoose.ShowPoints.timeScale = TransitionsTimeScale;
				};
				GTweenCallback val4 = val3;
				val2 = val3;
				obj2 = val4;
			}
			GTweener val5 = obj.OnComplete(obj2);
			val5.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val5);
		});
		ShowRewardAndChoose.timeScale = TransitionsTimeScale;
	}

	private void ShowExperienceGrowthSfx(float time)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		if (level.Chapter.Type != ChapterType.TreasureHunt || string.IsNullOrEmpty(LegendItemDungeonUiHelper.BossLevelId) || !(level.LevelId == LegendItemDungeonUiHelper.BossLevelId))
		{
			GTweener val = ((GComponent)(object)this).SetTimeout(time / TransitionsTimeScale).OnComplete(new GTweenCallback(ShowExperienceGrowth));
			val.SetTimeScale(TransitionsTimeScale);
			tweeners.Add(val);
		}
	}

	private void ShowReceiveBtn()
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		if (level.Chapter.Type == ChapterType.TreasureHunt && !string.IsNullOrEmpty(LegendItemDungeonUiHelper.BossLevelId) && level.LevelId == LegendItemDungeonUiHelper.BossLevelId)
		{
			((GObject)ReceiveBtn).touchable = false;
			((GObject)ReceiveBtn).alpha = 0f;
			return;
		}
		GTweener val = ((GObject)ReceiveBtn).TweenFade(1f, 0.42f / TransitionsTimeScale).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
		{
			((GObject)ReceiveBtn).touchable = true;
			int quickBattleType = GetQuickBattleType();
			if (QuickBattle && !isPortal && quickBattleType != 2)
			{
				RenderAgainBtn();
			}
		});
		val.SetTimeScale(TransitionsTimeScale);
		tweeners.Add(val);
	}

	public void InstanceZonesRewardRender()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>
		{
			{ "I40015", 0 },
			{ "I40016", 0 },
			{ "I40017", 0 },
			{ "I40018", 0 }
		};
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		int num = 0;
		foreach (KeyValuePair<string, List<Bonus>> fixBonuse in _fixBonuses)
		{
			if (!_capturedLevels.Contains(fixBonuse.Key))
			{
				continue;
			}
			foreach (Bonus item in fixBonuse.Value)
			{
				if (dictionary.ContainsKey(item.ItemId))
				{
					dictionary[item.ItemId] = item.Qty;
				}
				if (!dictionary2.ContainsKey(item.ItemId))
				{
					dictionary2.Add(item.ItemId, item.Qty);
				}
				else
				{
					dictionary2[item.ItemId] += item.Qty;
				}
				if (item.Qty > 0)
				{
					if (item.ItemId == "UserExp")
					{
						curLevelGetExp = item.Qty;
						userExpBtnIndex = num;
					}
					RewardAndChoose.StaticRewards.AddItemFromPool("ui://hda5vzklvv0u2q");
					((GObject)((GComponent)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(num).asButton).GetChild("title").asTextField).text = $"+{item.Qty}";
					LaodV_DropListItems(num, item);
					num++;
				}
			}
		}
		if (isDefensive)
		{
			ThinkingDataHelper.Instance.DefendCompletedTrack(level.ChapterId, level.LevelId.Last().ToString(), dictionary.Values.ToList());
		}
		if (level.Chapter.Type == ChapterType.TreasureHunt)
		{
			foreach (KeyValuePair<string, int> item2 in dictionary2)
			{
				ThinkingDataHelper.Instance.LegendItemLevelReward(level.LevelId, item2.Key, item2.Value);
			}
		}
		for (int i = 0; i < RewardAndChoose.StaticRewards.numItems; i++)
		{
			((GObject)((GComponent)RewardAndChoose.StaticRewards).GetChildAt(i).asButton).alpha = 0f;
		}
		if (RewardAndChoose.StaticRewards.numItems <= 3)
		{
			RewardAndChoose.StaticRewards.columnGap = 12;
		}
		else if (RewardAndChoose.StaticRewards.numItems > 3)
		{
			RewardAndChoose.StaticRewards.columnGap = -8;
		}
	}

	private void ListInit()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		popupCardData = _lotteryBonuses;
		cardIndex++;
		if (popupCardData != null && popupCardData.Count != 0)
		{
			((GObject)ChoiceList).visible = true;
			Transition maximize = EndIcon.maximize;
			object obj = _003C_003Ec._003C_003E9__111_0;
			if (obj == null)
			{
				PlayCompleteCallback val = delegate
				{
				};
				_003C_003Ec._003C_003E9__111_0 = val;
				obj = (object)val;
			}
			maximize.Play(1, 0f, 0f, 0f, (PlayCompleteCallback)obj);
			((GObject)EndIcon.ChooseText).visible = true;
			((GObject)EndIcon.chooseText).visible = true;
			ChoiceList.itemRenderer = new ListItemRenderer(RenderChoiceListItems);
			ChoiceList.numItems = popupCardData.Count;
		}
		else
		{
			((GObject)ChoiceList).visible = false;
			((GObject)ReceiveBtn).visible = true;
			((GObject)EndIcon.ChooseText).visible = false;
			((GObject)EndIcon.chooseText).visible = false;
		}
		for (int num = 0; num < ChoiceList.numItems; num++)
		{
			GButton button = ((GComponent)ChoiceList).GetChildAt(num).asButton;
			int index = num;
			((GObject)button).onClick.Add((EventCallback0)delegate
			{
				ChoiceListButton(button, index);
			});
		}
		ChoiceList.selectedIndex = -1;
		((GObject)ChoiceList).alpha = 0f;
		((GObject)ChoiceList).touchable = false;
	}

	private void RenderChoiceListItems(int index, GObject obj)
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected O, but got Unknown
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = obj.asButton;
		GLoader asLoader = ((GComponent)asButton).GetChild("icon").asLoader;
		GRichTextField asRichTextField = ((GComponent)asButton).GetChild("introduction").asRichTextField;
		GTextField asTextField = ((GComponent)asButton).GetChild("stockNum").asTextField;
		((GObject)asButton).name = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText250"), index);
		Bonus bonus = popupCardData[index];
		string itemId = bonus.ItemId;
		asLoader.fill = (FillType)1;
		asLoader.verticalAlign = (VertAlignType)0;
		if (bonus.IsShining == 2 || bonus.Category == 2)
		{
			((GObject)((GComponent)asButton).GetChild("commonGroup").asGroup).visible = false;
			((GObject)((GComponent)asButton).GetChild("rareGroup").asGroup).visible = true;
			((GObject)((GComponent)asButton).GetChild("sliverGroup").asGroup).visible = false;
			((GObject)((GComponent)asButton).GetChild("fxBack").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)asButton).GetChild("fxBack").asGraph, "activated_fx", new Vector3(125f, 125f, 125f));
		}
		else if (bonus.IsShining == 1)
		{
			((GObject)((GComponent)asButton).GetChild("commonGroup").asGroup).visible = false;
			((GObject)((GComponent)asButton).GetChild("rareGroup").asGroup).visible = false;
			((GObject)((GComponent)asButton).GetChild("sliverGroup").asGroup).visible = true;
		}
		else
		{
			((GObject)((GComponent)asButton).GetChild("commonGroup").asGroup).visible = true;
			((GObject)((GComponent)asButton).GetChild("rareGroup").asGroup).visible = false;
			((GObject)((GComponent)asButton).GetChild("sliverGroup").asGroup).visible = false;
		}
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 8)
		{
			asLoader.url = "ui://kt6rg65os0m4tbx";
			if (asLoader.component != null)
			{
				GButton asButton2 = ((GObject)asLoader.component).asButton;
				GObject iconCom = ((GComponent)asButton2).GetChild("icon");
				string iconPath = UiHelper.GetIconPath(itemId);
				AssetsManager.Instance.LoadAsset<Texture2D>(iconPath).Then((Action<Texture2D>)delegate(Texture2D asset)
				{
					//IL_001c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0026: Expected O, but got Unknown
					iconCom.asCom.GetChild("icon").asLoader.texture = new NTexture((Texture)(object)asset);
					textureList?.Add(iconPath);
				});
				iconCom.asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
				string text = "kuang_square_lv1";
				((GComponent)asButton2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + text;
				((GComponent)asButton2).GetChild("num").text = "";
				((GComponent)asButton2).GetChild("numNote").visible = false;
				((GComponent)asButton2).GetChild("title").text = "";
				((GComponent)asButton2).GetChild("title_Max").text = "";
			}
			animationList.Add(null);
			((GComponent)asButton).GetChild("numNote").asLoader.url = "ui://kt6rg65ovv0ue9";
		}
		else if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			asLoader.url = "ui://kt6rg65obunlt85";
			if (asLoader.component != null)
			{
				GButton asButton3 = ((GObject)asLoader.component).asButton;
				FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton3, itemId, textureList);
			}
			animationList.Add(null);
			((GComponent)asButton).GetChild("numNote").asLoader.url = "";
		}
		else if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 10)
		{
			((GObject)((GComponent)asButton).GetChild("content").asGroup).visible = false;
			((GObject)((GComponent)asButton).GetChild("soldierGroup").asGroup).visible = true;
			((GComponent)asButton).GetChild("curLevel").visible = true;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get("S" + bonus.ItemId.Substring(3));
			((GComponent)asButton).GetChild("soldierName").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
			((GComponent)asButton).GetChild("soldierName").text = soldier.Name ?? "";
			Object obj2 = Object.Instantiate(Resources.Load("SpineTest"));
			GameObject val = (GameObject)(object)((obj2 is GameObject) ? obj2 : null);
			SkeletonAnimation animation = val.GetComponent<SkeletonAnimation>();
			int potentialLevel = (soldier.PotentialLevel + 2) / 2;
			SpawnManager.Instance.LoadSoldierSpine(val, $"{soldier.Id}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if (!((GObject)this).isDisposed)
				{
					((SkeletonRenderer)animation).skeletonDataAsset = asset;
					((SkeletonRenderer)animation).initialSkinName = $"skin{potentialLevel}";
					((SkeletonRenderer)animation).Initialize(true);
					animation.AnimationState.AddAnimation(1, "idle", true, 0f);
				}
			});
			if (soldier.Id == "S001" || soldier.Id == "S002" || soldier.Id == "S003" || soldier.Id == "S004" || soldier.Id == "S035" || soldier.Id == "S038")
			{
				soldierScale = new Vector3(55f, 55f, 55f);
			}
			else
			{
				soldierScale = new Vector3(40f, 40f, 40f);
			}
			val.transform.localScale = soldierScale;
			val.transform.localPosition = -new Vector3(0f, 0f, 0f);
			val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			animationList.Add(val);
			GoWrapper val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			((GComponent)asButton).GetChild("soldier").asGraph.SetNativeObject((DisplayObject)(object)val2);
			((GComponent)asButton).GetChild("num").visible = false;
		}
		else
		{
			asLoader.url = "ui://kt6rg65ot1tzf9";
			if (asLoader.component != null)
			{
				GComponent component = asLoader.component;
				int num = ((Shift.Legion.Common.Models.Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId));
				num = ((num > 0) ? num : Shift.Legion.Common.Models.Item.Rarity(itemId));
				component.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(bonus.ItemId);
				component.GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, num);
			}
			animationList.Add(null);
			((GComponent)asButton).GetChild("numNote").asLoader.url = "";
		}
		dropIconNameList.Add(UiHelper.GetIconPath(bonus.ItemId));
		((GObject)((GComponent)asButton).GetChild("num").asTextField).text = $"{bonus.Qty}";
		asButton.title = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, bonus.ItemId);
		((GObject)asRichTextField).text = bonus.Desc(GameManagers.Instance);
		((GObject)asTextField).text = FGUIManager.Instance.GetStockString(itemId);
	}

	private void LaodV_DropListItems(int index, Bonus bonus)
	{
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = ((GComponent)RewardAndChoose.StaticRewards).GetChildAt(index).asButton;
		GLoader asLoader = ((GComponent)asButton).GetChild("icon").asLoader;
		asLoader.fill = (FillType)1;
		string itemId = bonus.ItemId;
		if (itemId == "UserExp")
		{
			FGUIManager.Instance.SetItemIconAndFrame(asLoader, itemId, textureList);
			if (GameManagers.Instance.ModifierManager.GetPercentFloatPayload("UserExpGain") > 0f)
			{
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = true;
				((GTextField)((GComponent)asButton).GetChild("title").asRichTextField).color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
				((GComponent)asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{
						"Title",
						LanguagesManager.GetDesc("CsharpCodeZhTcText109") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText142"), bonus.Qty)
					},
					{
						"Pos",
						(object)new Vector2(960f, 460f)
					}
				};
				((GComponent)asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
				curLevelGetExp = (float)bonus.Qty * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("UserExpGain"));
				((GComponent)asButton).GetChild("title").text = $"+{Convert.ToInt32(curLevelGetExp)}";
			}
			else
			{
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = false;
				((GTextField)((GComponent)asButton).GetChild("title").asRichTextField).color = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)253, (byte)225, byte.MaxValue));
			}
			((GObject)asLoader).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		else
		{
			if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
			{
				FGUIManager.Instance.SetItemIconAndFrame(asLoader, itemId, textureList, "", frameVisible: false, 0.65f);
			}
			else
			{
				asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(bonus.ItemId);
			}
			((GObject)asButton).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 8 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 10)
		{
			((GComponent)asButton).GetController("Type").selectedIndex = 1;
		}
		if (bonus.IsShining == 2 || bonus.Category == 2)
		{
			((GObject)((GComponent)asButton).GetChild("fxBack").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)asButton).GetChild("fxBack").asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
		}
	}

	private void ShowChoiceList()
	{
		_WaitLevelCompleted = FGUIManager.Instance.OpenIEnumerator(WaitLevelCompleted(level));
	}

	private IEnumerator WaitLevelCompleted(Level level)
	{
		while (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted(level.LevelId))
		{
			yield return null;
		}
		((GObject)ChoiceList).TweenFade(1f, 0.5f).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
		{
			((GObject)ChoiceList).touchable = true;
			SharedMessenger.Broadcast("ON_BONUS_CARDS_POPUP", popupCardData);
			if (popupCardData == null || popupCardData.Count == 0)
			{
				RewardAndChoose.StaticRewards.RemoveChildrenToPool();
				PageController.selectedIndex = 2;
				SetControllerPageText();
				((GObject)ReceiveBtn).alpha = 0f;
				((GObject)ReceiveBtn).touchable = false;
				InitHeadPortraitValue();
				((GObject)RewardAndChoose.experienceIncrement).alpha = 0f;
				PlayGetInstanceZonesReward();
			}
		});
	}

	private int GetQuickBattleType()
	{
		if (level.Chapter.Type == ChapterType.RepeatableInstanceOffensive)
		{
			return 2;
		}
		if (level.Chapter.Type == ChapterType.RepeatableInstanceDefensive)
		{
			return 1;
		}
		return 0;
	}

	private void RenderAgainBtn()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)this).isDisposed)
		{
			if (QuickPlayReplayService.MaxBattleCount <= 0)
			{
				((GTextField)againBtn.ticket).color = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)25, (byte)25, byte.MaxValue));
			}
			againBtn.icon.url = "";
			((GObject)againBtn.ticket).x = 96f;
			((GObject)againBtn.ticket).text = string.Format("{0} {1}", LanguagesManager.GetDesc("CsharpCodeZhTcText251"), QuickPlayReplayService.MaxBattleCount);
			((GObject)againBtn).visible = true;
			if (!showAgainBattleBtn)
			{
				((GObject)againBtn).touchable = false;
				((GObject)againBtn.bg).grayed = true;
				((GObject)againBtn.n10).grayed = true;
			}
		}
	}

	private void QuickBattleAgain()
	{
		if (QuickBattle)
		{
			if (showSoldiersNumTip)
			{
				string text = LanguagesManager.GetDesc("CsharpCodeZhTcText126") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText252") + "[/color]，" + Environment.NewLine + "[size=33](" + LanguagesManager.GetDesc("CsharpCodeZhTcText253") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText254") + ")[/size]";
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"Content",
						text ?? ""
					},
					{
						"Buttons",
						new Dictionary<string, Action> { 
						{
							"Confirm",
							delegate
							{
							}
						} }
					},
					{ "PageIndex", 4 },
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				});
			}
			else
			{
				QuickLevelClaimBonus();
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_QuickBattlePanel.Name, new Dictionary<string, object>
				{
					{ "CurLevel", level },
					{ "Auto", true },
					{
						"Type",
						GetQuickBattleType()
					}
				});
			}
		}
	}
}
