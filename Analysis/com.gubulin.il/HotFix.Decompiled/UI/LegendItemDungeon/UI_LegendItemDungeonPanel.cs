using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Client.Sources.Extensions;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.LegendItemsDraw;
using UI.Legion;
using UI.SoldierCultivate;
using UnityEngine;

namespace UI.LegendItemDungeon;

public class UI_LegendItemDungeonPanel : GComponent, IUiController, IAnyLoadingPanelStatusListener
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__66_0;

		public static Func<Task<GetTreasureHuntBattlePresetFormationResponse>> _003C_003E9__76_0;

		public static Action<GetTreasureHuntBattlePresetFormationResponse> _003C_003E9__76_1;

		internal void _003CMakeWar_003Eb__66_0()
		{
		}

		internal Task<GetTreasureHuntBattlePresetFormationResponse> _003COpenPresetFormationPanel_003Eb__76_0()
		{
			return GameController.Contexts.Service<INetworkService>().GetTreasureHuntBattlePresetFormation();
		}

		internal void _003COpenPresetFormationPanel_003Eb__76_1(GetTreasureHuntBattlePresetFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				return;
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PresetFormationPanel.Name, new Dictionary<string, object> { { "PresetFormationData", response.CurFormation } });
		}
	}

	public GGraph blackMask;

	public GLoader background;

	public UI_Title titleCom;

	public GButton backBtn;

	public GImage n5;

	public GImage n48;

	public GImage n49;

	public GImage n50;

	public GGroup LeftBack;

	public GGraph Graph1;

	public GImage n51;

	public GGroup RightBack;

	public UI_MapUiDialog MapCom;

	public GImage n52;

	public GTextField RemainingTime;

	public GTextField tip1;

	public GList Soldiers;

	public GTextField tip2;

	public GTextField num;

	public GList ExpeditionBonus;

	public UI_LevelCardPanel LevelCardPanel;

	public GTextField n45;

	public GTextField tip;

	public const string URL = "ui://2eraz3j9b9iz0";

	public static string Name = "UI_LegendItemDungeonPanel";

	public static UI_LegendItemDungeonPanel legendItemDungeonPanel;

	public static List<KeyValuePair<string, int>> selectSoldierData = new List<KeyValuePair<string, int>>();

	public static Dictionary<string, List<TreasureHuntLevelInfo>> LegendItemDungeonLevels = new Dictionary<string, List<TreasureHuntLevelInfo>>();

	public static int curLevelCount;

	public static ExplorationState explorationState;

	private GameStateEntity _gameStateEntity;

	private string drawLegendItemId;

	private SwipeGesture gesture;

	private Coroutine timeCoroutine;

	private const int LevelBtnBonusCounts = 2;

	private int curSelectedTimeLimitLevelIndex;

	private List<UI_LevelButton> levelBtns = new List<UI_LevelButton>();

	private string completedLevelId;

	private string openUiOnReturnValue;

	public static List<string> textureList = new List<string>();

	private List<string> skeletonList = new List<string>();

	private UI_HelpPanel HelpPanel;

	public Activity curActivity;

	public static string GetProgressTitle()
	{
		return LanguagesManager.GetDesc("LegendItemDungeon-Progress-content");
	}

	public static string GetURL()
	{
		return "ui://2eraz3j9b9iz0";
	}

	public static UI_LegendItemDungeonPanel CreateInstance()
	{
		return (UI_LegendItemDungeonPanel)(object)UIPackage.CreateObject("LegendItemDungeon", "LegendItemDungeonPanel");
	}

	public static UI_LegendItemDungeonPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemDungeonPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9b9iz0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		blackMask = (GGraph)((GComponent)this).GetChild("blackMask");
		background = (GLoader)((GComponent)this).GetChild("background");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		LeftBack = (GGroup)((GComponent)this).GetChild("LeftBack");
		Graph1 = (GGraph)((GComponent)this).GetChild("Graph1");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		RightBack = (GGroup)((GComponent)this).GetChild("RightBack");
		MapCom = (UI_MapUiDialog)(object)((GComponent)this).GetChild("MapCom");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		RemainingTime = (GTextField)((GComponent)this).GetChild("RemainingTime");
		string id = "ui://2eraz3j9b9iz0".Replace("ui://", "") + "-" + ((GObject)RemainingTime).id;
		((GObject)RemainingTime).text = LanguagesManager.GetDesc(id);
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id2 = "ui://2eraz3j9b9iz0".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id2);
		Soldiers = (GList)((GComponent)this).GetChild("Soldiers");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id3 = "ui://2eraz3j9b9iz0".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id3);
		num = (GTextField)((GComponent)this).GetChild("num");
		string id4 = "ui://2eraz3j9b9iz0".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id4);
		ExpeditionBonus = (GList)((GComponent)this).GetChild("ExpeditionBonus");
		LevelCardPanel = (UI_LevelCardPanel)(object)((GComponent)this).GetChild("LevelCardPanel");
		n45 = (GTextField)((GComponent)this).GetChild("n45");
		string id5 = "ui://2eraz3j9b9iz0".Replace("ui://", "") + "-" + ((GObject)n45).id;
		((GObject)n45).text = LanguagesManager.GetDesc(id5);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id6 = "ui://2eraz3j9b9iz0".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id6);
	}

	private void DataInit()
	{
		legendItemDungeonPanel = this;
		explorationState = GetExplorationState();
		if (explorationState == ExplorationState.InPreparation)
		{
			selectSoldierData.Clear();
			for (int i = 0; i < LegendItemDungeonUiHelper.CurSoldiers.Count; i++)
			{
				KeyValuePair<string, int> keyValuePair = LegendItemDungeonUiHelper.CurSoldiers[i];
				string key = keyValuePair.Key ?? "";
				selectSoldierData.Add(new KeyValuePair<string, int>(key, keyValuePair.Value));
			}
		}
		else
		{
			selectSoldierData = LegendItemDungeonUiHelper.CurSoldiers;
		}
		LegendItemDungeonLevels = LegendItemDungeonUiHelper.LegendItemDungeonLevels;
		curLevelCount = LegendItemDungeonUiHelper.CurFinishedLevelNum;
	}

	public static ExplorationState GetExplorationState(int curFloorIndex = 0)
	{
		if (LegendItemDungeonUiHelper.CurSoldiers.Count <= 0 && LegendItemDungeonUiHelper.CurFinishedLevelNum <= 0)
		{
			return ExplorationState.InPreparation;
		}
		if (LegendItemDungeonUiHelper.CurFinishedLevelNum < LegendItemDungeonUiHelper.ScoreToBoss)
		{
			return ExplorationState.HasBegun;
		}
		string levelId = LegendItemDungeonUiHelper.LegendItemDungeonLevels["BOSS"].First().LevelId;
		if (LegendItemDungeonUiHelper.LegendItemDungeonLevelStatus[levelId] == 2)
		{
			return ExplorationState.Finished;
		}
		int num = ((curFloorIndex == 0) ? LegendItemDungeonUiHelper.GetLastFloorIndex(enable: false) : curFloorIndex);
		if (num != LegendItemDungeonUiHelper.LegendItemDungeonLevels.Count - 1)
		{
			return ExplorationState.HasBegun;
		}
		return ExplorationState.Completed;
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)blackMask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GObject)this).sortingOrder = 1;
		if (parameters != null && parameters.TryGetValue("OpenUiOnReturn", out var value))
		{
			openUiOnReturnValue = (string)value;
		}
		DataInit();
		MapComInit();
		ExpeditionBonusRender();
		SoldiersRender();
		RenderDrawLegendItem();
		SetBuildingName();
		((GObject)MapCom.DrawLegendItem).grayed = !VersionManager.LegendItemDrawSwitch;
		((GObject)MapCom.DrawLegendItem).touchable = VersionManager.LegendItemDrawSwitch;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyLoadingPanelStatusListener(this);
		((GObject)backBtn).onClick.Add(new EventCallback0(GoBack));
		((GObject)MapCom.LeftShift).data = GobinState.LeftShift;
		((GObject)MapCom.LeftShift).onClick.Add(new EventCallback1(MapCom.Map.MapMain.CameraMoveHorizontal));
		((GObject)MapCom.RightShift).data = GobinState.RightShift;
		((GObject)MapCom.RightShift).onClick.Add(new EventCallback1(MapCom.Map.MapMain.CameraMoveHorizontal));
		((GObject)MapCom.Upward).data = UpOrDown.Upward;
		((GObject)MapCom.Upward).onClick.Add(new EventCallback1(MapCom.Map.MapMain.StartExpedition));
		((GObject)MapCom.Downward).data = UpOrDown.Downward;
		((GObject)MapCom.Downward).onClick.Add(new EventCallback1(MapCom.Map.MapMain.StartExpedition));
		((GObject)MapCom.Progress).onClick.Add(new EventCallback0(ShowHelpPanel));
		((GObject)LevelCardPanel.Mask).onClick.Add(new EventCallback0(CloseLevelCard));
		((GObject)MapCom.DrawLegendItem).onClick.Add(new EventCallback0(OpenDrawPanel));
		((GObject)MapCom.PresetFormationBtn).onClick.Add(new EventCallback0(OpenPresetFormationPanel));
		gesture = new SwipeGesture((GObject)(object)MapCom);
		gesture.onAction.Add(new EventCallback1(OnGestureAction));
		gesture.onMove.Add(new EventCallback1(OnGestureMove));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		_gameStateEntity.RemoveAnyLoadingPanelStatusListener(this);
		((GObject)backBtn).onClick.Remove(new EventCallback0(GoBack));
		((GObject)MapCom.LeftShift).onClick.Remove(new EventCallback1(MapCom.Map.MapMain.CameraMoveHorizontal));
		((GObject)MapCom.RightShift).onClick.Remove(new EventCallback1(MapCom.Map.MapMain.CameraMoveHorizontal));
		((GObject)MapCom.Upward).onClick.Remove(new EventCallback1(MapCom.Map.MapMain.StartExpedition));
		((GObject)MapCom.Downward).onClick.Remove(new EventCallback1(MapCom.Map.MapMain.StartExpedition));
		((GObject)MapCom.Progress).onClick.Remove(new EventCallback0(ShowHelpPanel));
		((GObject)LevelCardPanel.Mask).onClick.Remove(new EventCallback0(CloseLevelCard));
		((GObject)MapCom.DrawLegendItem).onClick.Remove(new EventCallback0(OpenDrawPanel));
		((GObject)MapCom.PresetFormationBtn).onClick.Remove(new EventCallback0(OpenPresetFormationPanel));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void BeforeDestroy()
	{
		if (timeCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(timeCoroutine);
		}
		legendItemDungeonPanel = null;
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
		timeCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RefreshTimeLimitRemaining());
	}

	private void GoBack()
	{
		if (!string.IsNullOrWhiteSpace(openUiOnReturnValue))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(openUiOnReturnValue, null);
		}
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		textureList.Clear();
		for (int j = 0; j < skeletonList.Count; j++)
		{
			SpawnManager.Instance.UnloadAnimation(skeletonList[j], isMask: true);
		}
	}

	private void OpenLegionPanel(EventContext context)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (explorationState == ExplorationState.InPreparation)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Style", "5" },
				{ "Spine", null }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
			return;
		}
		string value = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrWhiteSpace(value))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SoldierCultivate.Name, new Dictionary<string, object>
			{
				{ "soldierId", value },
				{ "soldierPanel", null },
				{
					"UnlockSoldierList",
					UiHelper.GetUnlockSoldierList()
				}
			});
		}
	}

	private void MapComInit()
	{
		GobinAnimater gobinAnimater = new GobinAnimater();
		DetectorAnimator detectorAnimator = new DetectorAnimator();
		gobinAnimater.GobinInit(MapCom.Map.SpineBack, skeletonList);
		detectorAnimator.Init(MapCom.Detector.SpineBack, skeletonList);
		MapCom.Map.MapMain.SetCurMapFloor(gobinAnimater, detectorAnimator, MapCom);
	}

	public void SoldiersRender()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		if (explorationState == ExplorationState.Finished)
		{
			Soldiers.numItems = 0;
			((GObject)Soldiers).visible = false;
			((GObject)tip).visible = true;
			((GObject)num).text = $"({0}/{LegendItemDungeonUiHelper.MaxLegionSize}):";
		}
		else
		{
			((GObject)Soldiers).visible = true;
			((GObject)tip).visible = false;
			((GObject)num).text = $"({selectSoldierData.Count}/{LegendItemDungeonUiHelper.MaxLegionSize}):";
			Soldiers.itemRenderer = new ListItemRenderer(SoldierItemRender);
			Soldiers.numItems = LegendItemDungeonUiHelper.MaxLegionSize;
		}
	}

	public void PlaySoldiersNotEnoughTransition(List<string> notEnoughSoldiers)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		if (explorationState == ExplorationState.Finished || notEnoughSoldiers == null || notEnoughSoldiers.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < Soldiers.numItems; i++)
		{
			UI_Soldier button = ((GComponent)Soldiers).GetChildAt(i) as UI_Soldier;
			if (button != null && !((GObject)button).isDisposed && ((GObject)button).data != null && notEnoughSoldiers.Contains(((GObject)button).data.ToString()))
			{
				button.State.selectedIndex = 1;
				button.breath.Play((PlayCompleteCallback)delegate
				{
					button.State.selectedIndex = 0;
				});
			}
		}
	}

	private void SoldierItemRender(int index, GObject obj)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		UI_Soldier uI_Soldier = obj as UI_Soldier;
		((GObject)uI_Soldier).onClick.Set(new EventCallback1(OpenLegionPanel));
		string text = "";
		if (index >= selectSoldierData.Count)
		{
			uI_Soldier.Type.selectedIndex = 0;
			text = "kuang_square_avatar_wood";
			uI_Soldier.iconFrame.url = "ui://PublicResources/" + text;
			((GObject)uI_Soldier).data = "";
			return;
		}
		KeyValuePair<string, int> keyValuePair = selectSoldierData[index];
		Soldier soldier = new Soldier(keyValuePair.Key);
		uI_Soldier.Type.selectedIndex = 1;
		text = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		uI_Soldier.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		((GObject)uI_Soldier.lv).text = soldier.Level.ToString();
		((GComponent)uI_Soldier).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_Soldier.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		int soldierLimitNum = LegendItemDungeonUiHelper.GetSoldierLimitNum(soldier.Id);
		int stock = GameManagers.Instance.StockController.GetStock(soldier.Id);
		bool flag = false;
		flag = ((LegendItemDungeonUiHelper.CurSoldiers != null && LegendItemDungeonUiHelper.CurSoldiers.Count >= 1) ? (stock >= Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, GameManagers.Instance.UserArchiveManager.GetSoldierLevel(soldier.Id))) : (stock >= soldierLimitNum));
		((GObject)uI_Soldier.num2).text = $"{keyValuePair.Value}/{soldierLimitNum}";
		((GTextField)uI_Soldier.num2).color = Color32.op_Implicit(flag ? new Color32(byte.MaxValue, (byte)242, (byte)211, byte.MaxValue) : new Color32(byte.MaxValue, (byte)33, (byte)33, byte.MaxValue));
		uI_Soldier.iconFrame.url = "ui://PublicResources/" + text;
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)uI_Soldier).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
		((GObject)uI_Soldier).data = soldier.Id;
	}

	private void RenderDrawLegendItem()
	{
		drawLegendItemId = ((GObject)MapCom.DrawLegendItem.Icon).data.ToString();
		((GObject)MapCom.DrawLegendItem.num).text = $"x{GameManagers.Instance.StockController.GetStock(drawLegendItemId)}";
		FGUIManager.Instance.SetItemIconAndFrame(MapCom.DrawLegendItem.Icon.Icon, drawLegendItemId, textureList, "", frameVisible: false);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (!string.IsNullOrWhiteSpace(drawLegendItemId) && itemId == drawLegendItemId)
		{
			((GObject)MapCom.DrawLegendItem.num).text = $"x{GameManagers.Instance.StockController.GetStock(drawLegendItemId)}";
		}
	}

	private void OnGestureAction(EventContext context)
	{
	}

	private void OnGestureMove(EventContext context)
	{
		if (gesture.delta.x <= 0f)
		{
			MapCom.Map.MapMain.CameraMoveHorizontal(-1);
		}
		else
		{
			MapCom.Map.MapMain.CameraMoveHorizontal(1);
		}
	}

	private void ShowHelpPanel()
	{
		if (MapCom.Progress.Type.selectedIndex != 3 && (MapCom.Progress.Type.selectedIndex == 0 || MapCom.Progress.Type.selectedIndex == 1))
		{
			string itemId = ((GObject)MapCom.Progress.TreasureMap).data.ToString();
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	private void CloseHelpPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)HelpPanel.Mask).onClick.Remove(new EventCallback0(CloseHelpPanel));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)HelpPanel, true);
	}

	public void RenderMissionList(List<TreasureHuntLevelInfo> levels)
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		for (int num = levelBtns.Count - 1; num >= 0; num--)
		{
			((GComponent)MapCom.Map.MapMain).RemoveChild((GObject)(object)levelBtns[num], true);
		}
		levelBtns.Clear();
		if (levels == null)
		{
			return;
		}
		for (int i = 0; i < levels.Count; i++)
		{
			TreasureHuntLevelInfo treasureHuntLevelInfo = levels[i];
			UI_LevelButton uI_LevelButton = UI_LevelButton.CreateInstance();
			levelBtns.Add(uI_LevelButton);
			((GObject)uI_LevelButton).data = treasureHuntLevelInfo;
			((GComponent)MapCom.Map.MapMain).AddChild((GObject)(object)uI_LevelButton);
			((GObject)uI_LevelButton).SetXY(((float)i + 1f) * 517.5f, ((GObject)MapCom.Map.MapMain).height / 2f - 40f);
			switch (LegendItemDungeonUiHelper.LegendItemDungeonLevelStatus[treasureHuntLevelInfo.LevelId])
			{
			case 2:
				uI_LevelButton.GrayedController.selectedIndex = 1;
				break;
			case 1:
				uI_LevelButton.GrayedController.selectedIndex = 2;
				break;
			default:
				uI_LevelButton.GrayedController.selectedIndex = 0;
				break;
			}
			((GObject)uI_LevelButton).onClick.Set(new EventCallback1(LevelBtnCliclEvent));
		}
		((GObject)LevelCardPanel).sortingOrder = 10000;
		curSelectedTimeLimitLevelIndex = -1;
	}

	private void LevelBtnCliclEvent(EventContext context)
	{
		UI_LevelButton uI_LevelButton = (UI_LevelButton)(object)context.sender;
		if (uI_LevelButton.GrayedController.selectedIndex == 1)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText329") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		curSelectedTimeLimitLevelIndex = levelBtns.IndexOf(uI_LevelButton);
		if (curSelectedTimeLimitLevelIndex >= 0 && curSelectedTimeLimitLevelIndex <= levelBtns.Count - 1)
		{
			UpdateLevelBtnsSelectedStatus();
			TreasureHuntLevelInfo treasureHuntLevelInfo = (TreasureHuntLevelInfo)((GObject)uI_LevelButton).data;
			Level dungeonLevelForUi = LegendItemDungeonUiHelper.GetDungeonLevelForUi(treasureHuntLevelInfo);
			RenderTimeLevelCard(dungeonLevelForUi);
			RenderLevelEnemy(dungeonLevelForUi);
			SetLevelCardXy();
			((GObject)LevelCardPanel).visible = true;
		}
	}

	private void UpdateLevelBtnsSelectedStatus()
	{
	}

	private void RenderLevelEnemy(Level level)
	{
		List<string> list = new List<string>();
		list.Add(level.EnemyTemplate.Enemy1);
		list.Add(level.EnemyTemplate.Enemy2);
		list.Add(level.EnemyTemplate.Enemy3);
		list.Add(level.EnemyTemplate.Enemy4);
		list.Add(level.EnemyTemplate.Enemy5);
		LevelCardPanel.Dailog.enemy.numItems = 5;
		for (int i = 0; i < LevelCardPanel.Dailog.enemy.numItems; i++)
		{
			RenderEnemyIcon(((GComponent)LevelCardPanel.Dailog.enemy).GetChildAt(i), list[i]);
		}
	}

	private void RenderEnemyIcon(GObject obj, string soldierId)
	{
		GButton asButton = obj.asButton;
		string skin = GameManagers.Instance.SoldierManager.Get(soldierId).Data.Skin;
		string s = skin.Replace("skin", "");
		int num = int.Parse(s);
		if (num < 1)
		{
			num = 1;
		}
		((GComponent)asButton).GetChild("icon").asCom.GetChild("icon").asLoader.url = UiHelper.GetSoldierSummonIcon(soldierId, num);
	}

	private void RenderTimeLevelCard(Level level)
	{
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		for (int i = 0; i < 4; i++)
		{
			((GComponent)LevelCardPanel.Dailog).GetChild($"reward{i}").visible = false;
		}
		if (level != null)
		{
			int num = 0;
			foreach (KeyValuePair<string, string> item in level.BonusDesc)
			{
				int num2 = num;
				((GComponent)LevelCardPanel.Dailog).GetChild($"reward{num2}").visible = true;
				if (item.Key == "UserExp")
				{
					FGUIManager.Instance.SetItemIconAndFrame(((GComponent)LevelCardPanel.Dailog).GetChild($"rewardIcon{num2}").asLoader, item.Key, textureList);
				}
				else
				{
					((GComponent)LevelCardPanel.Dailog).GetChild($"rewardIcon{num2}").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(item.Key);
				}
				((GComponent)LevelCardPanel.Dailog).GetChild($"rewardNum{num}").text = item.Value;
				num++;
				((GComponent)LevelCardPanel.Dailog).GetChild($"rewardIcon{num2}").onClick.Set((EventCallback0)delegate
				{
					UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
					FGUIManager.Instance.ItemTip(item.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
			}
			((GComponent)LevelCardPanel.Dailog).GetChild("missionName").text = level.Name ?? "";
		}
		GButton asButton = ((GComponent)LevelCardPanel.Dailog).GetChild("assembledBtn").asButton;
		((GObject)((GObject)asButton).asButton).onClick.Set((EventCallback0)delegate
		{
			EnterLevel(level);
		});
	}

	private void EnterLevel(Level level)
	{
		LegendItemDungeonUiHelper.CurLevelId = level.LevelId;
		CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
		{
			{ "LevelId", level.LevelId },
			{ "LevelInst", level },
			{ "Asset", "Prefabs/BattleField" },
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{ "WorldMapBtnVisible", false },
			{ "OpenUiOnReturn", level.FromUi },
			{ "UiParamsOnReturn", level.FromUiParams }
		}));
		ScriptApi.CreateTimer(1f, delegate
		{
			End();
		});
	}

	private bool MakeWar(GButton btn, ChapterActivityPayload contentPayload, int levelIndex)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		EventListener onClick = ((GObject)((GComponent)LevelCardPanel.Dailog).GetChild("assembledBtn").asButton).onClick;
		object obj = _003C_003Ec._003C_003E9__66_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
			};
			_003C_003Ec._003C_003E9__66_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
		curActivity.CheckStatus(GameManagers.Instance, out var _, sendEvent: true);
		if (curActivity.CheckOverPeriod(GameManagers.Instance) || (curActivity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled && curActivity.GetStatus(GameManagers.Instance) != ActivityStatus.Settlement))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText274") }, 1, arg3: false);
			End();
			return false;
		}
		if (levelIndex >= contentPayload.Levels(GameManagers.Instance).Count)
		{
			Debug.LogError((object)"副本活动数据错误");
			((GObject)btn).onClick.Set((EventCallback0)delegate
			{
				MakeWar(btn, contentPayload, levelIndex);
			});
			return false;
		}
		if (contentPayload?.Chapter == null)
		{
			((GObject)btn).onClick.Set((EventCallback0)delegate
			{
				MakeWar(btn, contentPayload, levelIndex);
			});
			return false;
		}
		string ticketItem = curActivity.TicketItem;
		if (GameManagers.Instance.StockController.GetStock(ticketItem) < contentPayload.Tickets)
		{
			string nameById = SchemaIndexHelper.GetNameById(GameManagers.Instance, ticketItem);
			List<string> arg = new List<string> { nameById + LanguagesManager.GetDesc("CsharpCodeZhTcText284") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			((GObject)btn).onClick.Set((EventCallback0)delegate
			{
				MakeWar(btn, contentPayload, levelIndex);
			});
			return false;
		}
		if (contentPayload.Play(GameManagers.Instance, levelIndex))
		{
			ScriptApi.CreateTimer(2f, End);
			return true;
		}
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText275") }, 1, arg3: false);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			MakeWar(btn, contentPayload, levelIndex);
		});
		return false;
	}

	private void CloseLevelCard()
	{
		curSelectedTimeLimitLevelIndex = -1;
		((GObject)LevelCardPanel).visible = false;
		UpdateLevelBtnsSelectedStatus();
	}

	private int GetCurLegionCombat(List<List<string>> filters)
	{
		List<Soldier> unlockSoldierList = UiHelper.GetUnlockSoldierList();
		UiHelper.FiltrateSoldiersByRace(filters, unlockSoldierList);
		int num = 0;
		for (int i = 0; i < 5 && i <= unlockSoldierList.Count - 1; i++)
		{
			num += unlockSoldierList[i].CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(unlockSoldierList[i].Id, unlockSoldierList[i].Level);
		}
		return num;
	}

	private void SetLevelCardXy()
	{
		((GObject)LevelCardPanel.Dailog).x = ((GObject)MapCom).x + ((GObject)MapCom).width / 2f - 260f;
		((GObject)LevelCardPanel.Dailog).y = 521f;
	}

	private void ItemDisplayLargeRender(int index)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		GButton asButton = ((GComponent)ExpeditionBonus).GetChildAt(index).asButton;
		string name = ((GObject)asButton).name;
		GLoader asLoader = ((GComponent)asButton).GetChild("Icon").asLoader;
		int number = (LegendItemDungeonUiHelper.BonusStats.ContainsKey(name) ? LegendItemDungeonUiHelper.BonusStats[name] : 0);
		((GComponent)asButton).GetChild("Num").text = "x" + number.ShortNumberFormat();
		FGUIManager.Instance.SetItemIconAndFrame(asLoader, name, textureList, "", frameVisible: false);
		((GObject)asLoader).data = name;
		((GObject)asLoader).onClick.Set(new EventCallback1(ItemTip));
	}

	private void ExpeditionBonusRender()
	{
		for (int i = 0; i < ExpeditionBonus.numItems; i++)
		{
			ItemDisplayLargeRender(i);
		}
	}

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			((GObject)RemainingTime).text = LegendItemDungeonUiHelper.GetCountDownTimeText();
			yield return (object)new WaitForSeconds(60f);
		}
	}

	public static void ItemTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		FGUIManager.Instance.ItemTip(itemId, ((GObject)legendItemDungeonPanel).sortingOrder);
	}

	private void SetBuildingName()
	{
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText828");
	}

	private void OpenDrawPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsDrawPanel.Name, null);
	}

	private void OpenPresetFormationPanel()
	{
		ILRequestHelper<GetTreasureHuntBattlePresetFormationResponse>.Request((EventContext)null, (Func<Task<GetTreasureHuntBattlePresetFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetTreasureHuntBattlePresetFormation()), (Action<GetTreasureHuntBattlePresetFormationResponse>)delegate(GetTreasureHuntBattlePresetFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PresetFormationPanel.Name, new Dictionary<string, object> { { "PresetFormationData", response.CurFormation } });
			}
		});
	}

	public void OnAnyLoadingPanelStatus(GameStateEntity entity, LoadingPanelStatus value)
	{
		switch (value)
		{
		case LoadingPanelStatus.Opening:
			UnityUiService.Instance.SetEdgeMaskVisible(UnityUiService.Instance.edgeMaskPanel.ratio <= 1f);
			break;
		case LoadingPanelStatus.Closed:
		case LoadingPanelStatus.Showing:
		case LoadingPanelStatus.Closing:
			break;
		default:
			throw new ArgumentOutOfRangeException("value", value, null);
		}
	}
}
