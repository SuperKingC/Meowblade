using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.Contract;
using UI.InstanceZones;
using UI.LegendItemDungeon;
using UI.Legion;
using UI.RecruitingCamp;
using UI.Restart;
using UI.Tips;
using UI.UpGrade;
using UnityEngine;

namespace UI.GameEndPanels;

public class UI_GameEndPanelFail : GComponent, IUiController
{
	public Controller PageController;

	public GGraph BlackGround;

	public UI_FailBackGround Light;

	public GImage DropBackground;

	public GGraph n109;

	public GRichTextField IncomeText;

	public GList GoodsList;

	public UI_GoToCamp GoToCamp;

	public UI_GoToLegion GoToLegion;

	public UI_GoToContract GoToContract;

	public GTextField tip;

	public GGroup Choose;

	public GGraph FailSfx;

	public GImage n108;

	public GGroup FailureGroup;

	public GGraph chooseText;

	public GRichTextField ChooseText;

	public GGroup ChooseGroup;

	public GButton YesButton;

	public UI_restartBtn restart;

	public Transition V_Rotate;

	public const string URL = "ui://hda5vzklj0l8k";

	public static string Name = "UI_GameEndPanelFail";

	private GComponent MainUi;

	private GButton button;

	private GRichTextField text;

	private GList list;

	private GGroup group;

	private int battleResult = 1;

	private object battleStats;

	private string uiTitleAnimName = "ui_title_lightray_rotate";

	private string[] choiceName = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText237"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText238"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText239"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText240")
	};

	private List<string> textureList = new List<string>();

	private Level level;

	private int freeCount;

	private Dictionary<string, int> backInTimeCost = new Dictionary<string, int>();

	private string battleId;

	private bool canBackInTime;

	private bool QuickBattle;

	public static string GetURL()
	{
		return "ui://hda5vzklj0l8k";
	}

	public static UI_GameEndPanelFail CreateInstance()
	{
		return (UI_GameEndPanelFail)(object)UIPackage.CreateObject("GameEndPanels", "GameEndPanelFail");
	}

	public static UI_GameEndPanelFail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GameEndPanelFail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklj0l8k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
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
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		BlackGround = (GGraph)((GComponent)this).GetChild("BlackGround");
		Light = (UI_FailBackGround)(object)((GComponent)this).GetChild("Light");
		DropBackground = (GImage)((GComponent)this).GetChild("DropBackground");
		n109 = (GGraph)((GComponent)this).GetChild("n109");
		IncomeText = (GRichTextField)((GComponent)this).GetChild("IncomeText");
		string id = "ui://hda5vzklj0l8k".Replace("ui://", "") + "-" + ((GObject)IncomeText).id;
		((GObject)IncomeText).text = LanguagesManager.GetDesc(id);
		GoodsList = (GList)((GComponent)this).GetChild("GoodsList");
		GoToCamp = (UI_GoToCamp)(object)((GComponent)this).GetChild("GoToCamp");
		GoToLegion = (UI_GoToLegion)(object)((GComponent)this).GetChild("GoToLegion");
		GoToContract = (UI_GoToContract)(object)((GComponent)this).GetChild("GoToContract");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://hda5vzklj0l8k".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		Choose = (GGroup)((GComponent)this).GetChild("Choose");
		FailSfx = (GGraph)((GComponent)this).GetChild("FailSfx");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		FailureGroup = (GGroup)((GComponent)this).GetChild("FailureGroup");
		chooseText = (GGraph)((GComponent)this).GetChild("chooseText");
		ChooseText = (GRichTextField)((GComponent)this).GetChild("ChooseText");
		ChooseGroup = (GGroup)((GComponent)this).GetChild("ChooseGroup");
		YesButton = (GButton)((GComponent)this).GetChild("YesButton");
		restart = (UI_restartBtn)(object)((GComponent)this).GetChild("restart");
		V_Rotate = ((GComponent)this).GetTransition("V_Rotate");
	}

	[HideInInspector]
	private async void YesButtonEvent(EventContext context)
	{
		((GObject)YesButton).touchable = false;
		if (FGUIManager.Instance.DamageMeter != null)
		{
			FGUIManager.Instance.DamageMeter.End();
		}
		if (QuickBattle)
		{
			GObject ui = GameController.Contexts.Service<IUiService>().GetShowingUi(UI_InstanceZonesPanel.Name);
			if (ui != null)
			{
				UI_InstanceZonesPanel instanceZones = (UI_InstanceZonesPanel)(object)ui;
				instanceZones.SetQuickBattlePanelBackVisible(_visible: false);
				instanceZones.UpdateTimeLimitInstanceZones();
			}
			End();
			string currentLevelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			Level currentLevel = (string.IsNullOrEmpty(currentLevelId) ? null : GameManagers.Instance.ChapterManager.GetLevelInstance(currentLevelId));
			GameController.Contexts.Service<IBattleFieldService>().Level = currentLevel;
			return;
		}
		string battleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		CheckBattleFailedProcessResponse response = await GameController.Contexts.Service<INetworkService>().CheckBattleFailedProcess(-1L, battleId, level.LevelId);
		if (response == null)
		{
		}
		if (!response.Result)
		{
			ExitLevel();
			return;
		}
		Dictionary<string, int> reinforcements = response.ReinforcementBonus;
		if (reinforcements != null && reinforcements.Count > 0)
		{
			((GObject)this).alpha = 0f;
			OverflowTip(reinforcements);
		}
		else
		{
			ExitLevel();
		}
	}

	private async void ExitLevel()
	{
		if (level.LevelId == LegendItemDungeonUiHelper.CurLevelId)
		{
			LegendItemDungeonUiHelper.GetTreasureHuntActivityProgress(await GameController.Contexts.Service<INetworkService>().GetTreasureHuntActivityProgress());
		}
		End();
		if (ChapterManager.Chapters.TryGetValue(level.ChapterId, out var chapter) && chapter.Type == ChapterType.StoryMain)
		{
			GameController.Contexts.Service<IBattleFieldService>().INTERNAL_RESET(showStrategyReminder: true);
			return;
		}
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{ "OpenUiOnReturn", level.FromUi },
			{ "UiParamsOnReturn", level.FromUiParams }
		}));
	}

	private void GetReinforcementBonus(Dictionary<string, int> _bonus)
	{
		foreach (KeyValuePair<string, int> _bonu in _bonus)
		{
			Bonus.Get(_bonu.Key, _bonu.Value).Claim(GameManagers.Instance);
		}
		ExitLevel();
	}

	private void OverflowTip(Dictionary<string, int> _bonus)
	{
		if (_bonus == null || _bonus.Count < 1)
		{
			ExitLevel();
			return;
		}
		List<string> chapterLevelProgress = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001");
		if (chapterLevelProgress != null && chapterLevelProgress.Contains("P120"))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText241") + "……" + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText242") + "！" }, 999, arg3: false);
			GetReinforcementBonus(_bonus);
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeZhTcText243") + "，" + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText242") + "！"
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							GetReinforcementBonus(_bonus);
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

	private void RenderListItems(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		asButton.title = choiceName[index];
	}

	private void ListEvent(GButton but)
	{
	}

	private void ListInit()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		GoodsList.itemRenderer = new ListItemRenderer(RenderListItems);
		GoodsList.numItems = 4;
		for (int i = 0; i < GoodsList.numItems; i++)
		{
			GButton button = ((GComponent)GoodsList).GetChildAt(i).asButton;
			((GObject)button).onClick.Add((EventCallback0)delegate
			{
				ListEvent(button);
			});
		}
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
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		((GObject)YesButton).onClick.Add(new EventCallback1(YesButtonEvent));
		((GObject)GoToCamp).onClick.Add(new EventCallback0(OpenCamp));
		((GObject)GoToContract).onClick.Add(new EventCallback0(OpenContract));
		((GObject)GoToLegion).onClick.Add(new EventCallback0(OpenLegion));
		((GObject)restart).onClick.Add(new EventCallback1(OpenRestartDialog));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		((GObject)YesButton).onClick.Remove(new EventCallback1(YesButtonEvent));
		((GObject)GoToCamp).onClick.Remove(new EventCallback0(OpenCamp));
		((GObject)GoToContract).onClick.Remove(new EventCallback0(OpenContract));
		((GObject)GoToLegion).onClick.Remove(new EventCallback0(OpenLegion));
		((GObject)restart).onClick.Remove(new EventCallback1(OpenRestartDialog));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UiHelper.LoadSpine_AB(FailSfx, uiTitleAnimName, 100f, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_lose", true);
		});
		level = GameController.Contexts.Service<IBattleFieldService>().Level;
		PageController.selectedIndex = 0;
		if (parameters.TryGetValue("result", out var value))
		{
			battleResult = (int)value;
		}
		if (parameters.TryGetValue("stats", out var value2))
		{
			battleStats = value2;
		}
		if (parameters.TryGetValue("CanBackInTime", out var value3))
		{
			canBackInTime = (bool)value3;
			if (canBackInTime)
			{
				if (parameters.TryGetValue("FreeCount", out var value4))
				{
					freeCount = (int)value4;
				}
				if (parameters.TryGetValue("Cost", out var value5))
				{
					backInTimeCost = (Dictionary<string, int>)value5;
				}
			}
		}
		if (parameters.TryGetValue("BattleId", out var value6))
		{
			battleId = value6.ToString();
		}
		if (parameters.TryGetValue("QuickBattle", out var value7))
		{
			QuickBattle = (bool)value7;
		}
		((GObject)ChooseText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText244") + ": " + level?.Name;
		ListInit();
		GetTreasureHuntBattleResult();
		((GObject)tip).visible = UiHelper.ShowCombatPowerTip(level.ChapterId);
		if (QuickBattle && (level.Chapter.Type == ChapterType.RepeatableInstance || level.Chapter.Type == ChapterType.RepeatableInstanceOffensive || level.Chapter.Type == ChapterType.RepeatableInstanceDefensive || level.Chapter.Type == ChapterType.RepeatableInstancePortal))
		{
			((GObject)BlackGround).alpha = 0f;
		}
	}

	private void OpenRestartDialog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, object> parameters = (Dictionary<string, object>)((GObject)context.sender).data;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_RestartPanel.Name, parameters);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("Battle.ConfirmFailureBtn", YesButton);
		UiAudioManager.Instance.PlayBackgroundSound("BattleFail");
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
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Battle.ConfirmFailureBtn", YesButton);
		SpawnManager.Instance.UnloadAnimation(uiTitleAnimName);
	}

	private void GetTreasureHuntBattleResult()
	{
		if (level != null && level.Chapter.Type == ChapterType.TreasureHunt && canBackInTime)
		{
			((GObject)restart).visible = true;
			Action value = delegate
			{
				((GObject)YesButton).onClick.Call();
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

	private void OpenCamp()
	{
		if (level.ChapterId == "C1000" || level.ChapterId == "C10000" || level.ChapterId == "C10001" || level.ChapterId == "C1000" || level.ChapterId == "C10002")
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText108") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 120, arg3: false);
			return;
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("10");
		if (buildingByType.Status == BuildingStatus.Banned)
		{
			List<string> arg2 = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText22")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 120, arg3: false);
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = "";
		if (buildingByType.Status == BuildingStatus.Ready)
		{
			dictionary.Add("Parent", this);
			dictionary.Add("Building", buildingByType);
			text = UI_UpGradePanel.Name;
		}
		else if (buildingByType.Level == 0)
		{
			dictionary.Add("Building", buildingByType);
			dictionary.Add("Parent", this);
			text = UI_UpGradePanel.Name;
		}
		else
		{
			text = UI_RecruitingCamp.Name;
		}
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{ "OpenUiOnReturn", text },
			{ "UiParamsOnReturn", dictionary }
		}));
	}

	private void OpenLegion()
	{
		if (level.ChapterId == "C1000" || level.ChapterId == "C10000" || level.ChapterId == "C10001" || level.ChapterId == "C1000" || level.ChapterId == "C10002")
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText108") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 120, arg3: false);
			return;
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Style", "Self");
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{
				"OpenUiOnReturn",
				UI_LegionPanel.Name
			},
			{ "UiParamsOnReturn", dictionary }
		}));
	}

	private void OpenContract()
	{
		if (level.ChapterId == "C1000" || level.ChapterId == "C10000" || level.ChapterId == "C10001" || level.ChapterId == "C1000" || level.ChapterId == "C10002")
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText108") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 120, arg3: false);
			return;
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Parent", this);
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{
					"OpenUiOnReturn",
					UI_ContractPanel.Name
				},
				{ "UiParamsOnReturn", dictionary }
			}));
		}
		else
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 120, arg3: false);
		}
	}

	private void End()
	{
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
