using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemDungeon;

public class UI_CameraMain : GComponent
{
	public GLoader Icon;

	public const string URL = "ui://2eraz3j9lkai9";

	public static string Name = "UI_CameraMain";

	public int curFloor;

	public int levelIndex;

	public int length;

	public string mapurl;

	public const float LevelWidth = 517.5f;

	public bool inMotion;

	public float leftLimitX;

	public float rightLimitX;

	public GobinAnimater gobin;

	public DetectorAnimator DetectorAnim;

	public UI_MapUiDialog MapUiDialog;

	public static string GetURL()
	{
		return "ui://2eraz3j9lkai9";
	}

	public static UI_CameraMain CreateInstance()
	{
		return (UI_CameraMain)(object)UIPackage.CreateObject("LegendItemDungeon", "CameraMain");
	}

	public static UI_CameraMain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CameraMain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9lkai9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
	}

	public void CameraInit(bool isInit = false)
	{
		if (curFloor == 0)
		{
			length = 2;
			mapurl = LegendItemDungeonUiHelper.GetCurFloorMapIconUrl("InitLevel");
			((GObject)MapUiDialog.Map.Lens).visible = false;
			Icon.fill = (FillType)5;
		}
		else if (curFloor == UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 1)
		{
			length = UI_LegendItemDungeonPanel.LegendItemDungeonLevels["BOSS"].Count + 1;
			mapurl = LegendItemDungeonUiHelper.GetCurFloorMapIconUrl("BOSS");
			((GObject)MapUiDialog.Map.Lens).visible = true;
			Icon.fill = (FillType)4;
		}
		else
		{
			length = UI_LegendItemDungeonPanel.LegendItemDungeonLevels.ToList()[curFloor].Value.Count + 1;
			mapurl = LegendItemDungeonUiHelper.GetCurFloorMapIconUrl("");
			((GObject)MapUiDialog.Map.Lens).visible = true;
			Icon.fill = (FillType)4;
		}
		Icon.url = mapurl;
		((GObject)Icon).width = (float)length * 517.5f;
		((GObject)this).x = (float)(-(length / 2 - 1)) * 517.5f;
		rightLimitX = 0f - (((GObject)Icon).width - ((GObject)((GObject)this).parent).width);
		leftLimitX = 0f;
		if (isInit)
		{
			((GObject)this).x = LegendItemDungeonUiHelper.SetLastLevelOffsetX(curFloor, leftLimitX, rightLimitX, ((GObject)this).x);
		}
		else
		{
			GameLocalDataManager.SetLastLegendExplorationLevelOffsetX(((GObject)this).x);
		}
	}

	public void CameraMoveHorizontal(EventContext context)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		if (UI_LegendItemDungeonPanel.curLevelCount >= LegendItemDungeonUiHelper.ScoreToBoss || inMotion)
		{
			return;
		}
		GobinState gobinState = (GobinState)((GObject)context.sender).data;
		if ((!(((GObject)this).x >= leftLimitX) || gobinState != GobinState.LeftShift) && (!(((GObject)this).x <= rightLimitX) || gobinState != GobinState.RightShift))
		{
			float offsetX = ((GObject)this).x + 517.5f * (float)gobinState;
			inMotion = true;
			MapUiDialog.Modle.selectedIndex = 1;
			gobin.ChangeState(gobinState);
			((GObject)this).TweenMoveX(offsetX, 0.5f).OnComplete((GTweenCallback)delegate
			{
				OnCameraMoveEnd();
				gobin.ChangeState(GobinState.Idle);
				GameLocalDataManager.SetLastLegendExplorationLevelOffsetX(offsetX);
			});
		}
	}

	public void CameraMoveHorizontal(int direction)
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		if (UI_LegendItemDungeonPanel.curLevelCount < LegendItemDungeonUiHelper.ScoreToBoss && !inMotion && (!(((GObject)this).x >= leftLimitX) || direction != 1) && (!(((GObject)this).x <= rightLimitX) || direction != -1))
		{
			float offsetX = ((GObject)this).x + 517.5f * (float)direction;
			inMotion = true;
			MapUiDialog.Modle.selectedIndex = 1;
			GobinState newState = ((direction == 1) ? GobinState.LeftShift : GobinState.RightShift);
			gobin.ChangeState(newState);
			((GObject)this).TweenMoveX(offsetX, 0.5f).OnComplete((GTweenCallback)delegate
			{
				OnCameraMoveEnd();
				gobin.ChangeState(GobinState.Idle);
				GameLocalDataManager.SetLastLegendExplorationLevelOffsetX(offsetX);
			});
		}
	}

	public void CameraMoveVertical(UpOrDown direction)
	{
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		if (inMotion)
		{
			return;
		}
		inMotion = true;
		MapUiDialog.Modle.selectedIndex = 1;
		if (direction == UpOrDown.Upward)
		{
			((GObject)MapUiDialog.Map.Curtain).y = ((GObject)MapUiDialog.Map.MapMain).y - ((GObject)MapUiDialog.Map.Curtain).height;
			((GObject)MapUiDialog.Map.Curtain).relations.ClearAll();
			((GObject)MapUiDialog.Map.Curtain).AddRelation((GObject)(object)MapUiDialog.Map.MapMain, (RelationType)11);
			GTweenCallback val = default(GTweenCallback);
			((GObject)MapUiDialog.Map.MapMain).TweenMoveY(((GObject)MapUiDialog.Map.MapMain).height, 0.5f).OnComplete((GTweenCallback)delegate
			{
				//IL_011f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0124: Unknown result type (might be due to invalid IL or missing references)
				//IL_0126: Expected O, but got Unknown
				//IL_012b: Expected O, but got Unknown
				((GObject)this).x = (0f - (((GObject)Icon).width - ((GObject)((GObject)this).parent).width)) / 2f;
				UpdateMapFloor(direction);
				((GObject)MapUiDialog.Map.Curtain).relations.ClearAll();
				((GObject)MapUiDialog.Map.MapMain).y = ((GObject)MapUiDialog.Map.Curtain).y - ((GObject)MapUiDialog.Map.MapMain).height;
				((GObject)MapUiDialog.Map.Curtain).AddRelation((GObject)(object)MapUiDialog.Map.MapMain, (RelationType)9);
				GTweener obj = ((GObject)MapUiDialog.Map.MapMain).TweenMoveY(0f, 0.5f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						OnCameraMoveEnd();
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
			});
		}
		else
		{
			if (direction != UpOrDown.Downward)
			{
				return;
			}
			((GObject)MapUiDialog.Map.Curtain).y = ((GObject)MapUiDialog.Map.MapMain).height;
			((GObject)MapUiDialog.Map.Curtain).relations.ClearAll();
			((GObject)MapUiDialog.Map.Curtain).AddRelation((GObject)(object)MapUiDialog.Map.MapMain, (RelationType)9);
			GTweenCallback val = default(GTweenCallback);
			((GObject)MapUiDialog.Map.MapMain).TweenMoveY(0f - ((GObject)MapUiDialog.Map.MapMain).height, 0.5f).OnComplete((GTweenCallback)delegate
			{
				//IL_011f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0124: Unknown result type (might be due to invalid IL or missing references)
				//IL_0126: Expected O, but got Unknown
				//IL_012b: Expected O, but got Unknown
				((GObject)this).x = (0f - (((GObject)Icon).width - ((GObject)((GObject)this).parent).width)) / 2f;
				UpdateMapFloor(direction);
				((GObject)MapUiDialog.Map.Curtain).relations.ClearAll();
				((GObject)MapUiDialog.Map.MapMain).y = ((GObject)MapUiDialog.Map.Curtain).y + ((GObject)MapUiDialog.Map.Curtain).height;
				((GObject)MapUiDialog.Map.Curtain).AddRelation((GObject)(object)MapUiDialog.Map.MapMain, (RelationType)11);
				GTweener obj = ((GObject)MapUiDialog.Map.MapMain).TweenMoveY(0f, 0.5f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						OnCameraMoveEnd();
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
			});
		}
	}

	private void OnCameraMoveEnd()
	{
		inMotion = false;
		MapUiDialog.Modle.selectedIndex = 0;
		if (curFloor == UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 1)
		{
			ShowDetector();
		}
	}

	public void StartExpedition(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		UpOrDown direction = (UpOrDown)((GObject)context.sender).data;
		if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.InPreparation)
		{
			ShowConfirmTip(direction);
		}
		else
		{
			CameraMoveVertical(direction);
		}
	}

	private void ShowConfirmTip(UpOrDown direction)
	{
		string text = "";
		List<string> soldiers = null;
		text = ((UI_LegendItemDungeonPanel.selectSoldierData.Count >= LegendItemDungeonUiHelper.MaxLegionSize) ? JudgSelectSoldiersNumEnough(out soldiers) : (LanguagesManager.GetDesc("CsharpCodeZhTcText330") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText331") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText332") + "?"));
		Action action = delegate
		{
			CameraMoveVertical(direction);
		};
		if (string.IsNullOrWhiteSpace(text))
		{
			LegendItemDungeonUiHelper.AssignSubLegion(action, UI_LegendItemDungeonPanel.selectSoldierData);
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				text ?? ""
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							LegendItemDungeonUiHelper.AssignSubLegion(action, UI_LegendItemDungeonPanel.selectSoldierData);
						}
					},
					{
						"Cancel",
						delegate
						{
							UI_LegendItemDungeonPanel.legendItemDungeonPanel.PlaySoldiersNotEnoughTransition(soldiers);
						}
					}
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)UI_LegendItemDungeonPanel.legendItemDungeonPanel).sortingOrder + 1
			}
		});
	}

	private string JudgSelectSoldiersNumEnough(out List<string> soldiers)
	{
		string result = "";
		soldiers = new List<string>();
		for (int i = 0; i < UI_LegendItemDungeonPanel.selectSoldierData.Count; i++)
		{
			string key = UI_LegendItemDungeonPanel.selectSoldierData[i].Key;
			if (GameManagers.Instance.StockController.GetStock(key) < LegendItemDungeonUiHelper.GetSoldierLimitNum(key))
			{
				result = LanguagesManager.GetDesc("CsharpCodeZhTcText333") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText331") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText332") + "?";
				soldiers.Add(key);
			}
		}
		return result;
	}

	private void MapUpOrDown(float initY, float afterY, RelationType initRelationType, RelationType afterRelationType, UpOrDown direction)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		((GObject)MapUiDialog.Map.Curtain).y = initY;
		((GObject)MapUiDialog.Map.Curtain).relations.ClearAll();
		((GObject)MapUiDialog.Map.Curtain).AddRelation((GObject)(object)MapUiDialog.Map.MapMain, initRelationType);
		GTweenCallback val = default(GTweenCallback);
		((GObject)MapUiDialog.Map.MapMain).TweenMoveY((float)direction * (0f - ((GObject)MapUiDialog.Map.MapMain).height), 0.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_00ee: Expected O, but got Unknown
			((GObject)this).x = (0f - (((GObject)Icon).width - ((GObject)((GObject)this).parent).width)) / 2f;
			((GObject)MapUiDialog.Map.Curtain).relations.ClearAll();
			((GObject)MapUiDialog.Map.MapMain).y = afterY;
			((GObject)MapUiDialog.Map.Curtain).AddRelation((GObject)(object)MapUiDialog.Map.MapMain, afterRelationType);
			GTweener obj = ((GObject)MapUiDialog.Map.MapMain).TweenMoveY(0f, 0.5f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					OnCameraMoveEnd();
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	public void UpdateMapFloor(UpOrDown direction)
	{
		UpdateCurFloorInfo(direction);
		UpdateMapComUi();
		SetMapWidth();
	}

	public void SetMapWidth()
	{
		CameraInit();
		if (curFloor != 0)
		{
			string key = UI_LegendItemDungeonPanel.LegendItemDungeonLevels.ToList()[curFloor].Key;
			if (curFloor == UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 1)
			{
				key = "BOSS";
			}
			UI_LegendItemDungeonPanel.legendItemDungeonPanel?.RenderMissionList(UI_LegendItemDungeonPanel.LegendItemDungeonLevels[key]);
		}
	}

	private void GetDetectorSignal()
	{
		((GObject)MapUiDialog.Detector.SignalText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText334") + 0.ToString("0.00") + LanguagesManager.GetDesc("CsharpCodeZhTcText335");
		ILRequestHelper<GetTreasureHuntBossInsuranceResponse>.Request((EventContext)null, (Func<Task<GetTreasureHuntBossInsuranceResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetTreasureHuntBossInsurance()), (Action<GetTreasureHuntBossInsuranceResponse>)delegate(GetTreasureHuntBossInsuranceResponse response)
		{
			if (response != null)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					((GObject)MapUiDialog.Detector.SignalText).text = LanguagesManager.GetDesc("CsharpCodeZhTcText334") + response.BossLootInsuranceProgressDisplay.ToString("0.00") + LanguagesManager.GetDesc("CsharpCodeZhTcText335");
					DetectorAnim.ChangeStrength(response.BossLootInsuranceProgressDisplay, response.BossLootHighLight != 0);
				}
			}
		});
	}

	private void ShowDetector()
	{
		MapUiDialog.Modle.selectedIndex = 2;
	}

	public void UpdateMapComUi()
	{
		UpdateMapComVisible();
		UpdateProgress();
		UpdateDownward();
		UpdateFloorInfo();
		DetectorAnim.UpdateState();
		((GObject)MapUiDialog.PresetFormationBtn).visible = UI_LegendItemDungeonPanel.explorationState != ExplorationState.InPreparation;
	}

	private void ItemDisplayRender(UI_ItemDisplay button, string iconName)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		button.Icon.url = "ui://PublicResources/" + iconName;
		((GObject)button.Icon).data = iconName;
		((GObject)button.Icon).onClick.Set(new EventCallback1(UI_LegendItemDungeonPanel.ItemTip));
	}

	private void FloorInfoDisplayRender(Level level, GList disPlayIconList)
	{
		if (level == null)
		{
			return;
		}
		for (int i = 0; i < disPlayIconList.numItems; i++)
		{
			UI_ItemDisplay uI_ItemDisplay = ((GComponent)disPlayIconList).GetChildAt(i) as UI_ItemDisplay;
			if (i < level.TitleBonus.Count)
			{
				((GObject)uI_ItemDisplay).visible = true;
				ItemDisplayRender(uI_ItemDisplay, level.TitleBonus[i]);
			}
			else
			{
				((GObject)uI_ItemDisplay).visible = false;
			}
		}
	}

	private void UpdateFloorInfo()
	{
		((GObject)MapUiDialog.FloorInfo.Title).text = LegendItemDungeonUiHelper.GetFloorName(curFloor) ?? "";
		if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.Completed || UI_LegendItemDungeonPanel.explorationState == ExplorationState.Finished || UI_LegendItemDungeonPanel.explorationState == ExplorationState.InPreparation || curFloor <= 0)
		{
			MapUiDialog.FloorInfo.TypeController.selectedIndex = 0;
			return;
		}
		MapUiDialog.FloorInfo.TypeController.selectedIndex = 1;
		Level dungeonLevelForUi = LegendItemDungeonUiHelper.GetDungeonLevelForUi(UI_LegendItemDungeonPanel.LegendItemDungeonLevels[LegendItemDungeonUiHelper.GetFloorKey(curFloor)].First());
		FloorInfoDisplayRender(dungeonLevelForUi, MapUiDialog.FloorInfo.display);
	}

	public void SetCurMapFloor(GobinAnimater spineAnimater, DetectorAnimator detector, UI_MapUiDialog mapUi)
	{
		curFloor = GetCurFloor();
		gobin = spineAnimater;
		DetectorAnim = detector;
		MapUiDialog = mapUi;
		MapUiDialog.Progress.TreasureMap.Icon.url = "";
		GetDetectorSignal();
		CameraInit(isInit: true);
		UpdateMapComUi();
		string key = LegendItemDungeonUiHelper.GetFloorKey(curFloor);
		if (curFloor == UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 1)
		{
			ShowDetector();
			key = "BOSS";
		}
		UI_LegendItemDungeonPanel.legendItemDungeonPanel?.RenderMissionList(UI_LegendItemDungeonPanel.LegendItemDungeonLevels[key]);
	}

	private int GetCurFloor()
	{
		int num = 0;
		if (UI_LegendItemDungeonPanel.explorationState != ExplorationState.InPreparation)
		{
			num = ((UI_LegendItemDungeonPanel.explorationState == ExplorationState.HasBegun) ? LegendItemDungeonUiHelper.GetLastFloorIndex(enable: false) : ((UI_LegendItemDungeonPanel.explorationState != ExplorationState.Completed) ? (UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 1) : LegendItemDungeonUiHelper.GetLastFloorIndex(enable: true)));
		}
		else
		{
			num = 0;
			LegendItemDungeonUiHelper.SaveCurFloor(GameLocalDataManager.GetLastDungeonBattleMinLevel());
			GameLocalDataManager.ReadyToResetDungeonBattleMinLevel();
		}
		return num;
	}

	private void UpdateCurFloorInfo(UpOrDown direction)
	{
		curFloor += (int)direction;
		if (direction == UpOrDown.Downward)
		{
			if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.InPreparation)
			{
				curFloor = LegendItemDungeonUiHelper.GetLastFloorIndex(enable: false);
				if (curFloor >= LegendItemDungeonUiHelper.MaxDifficult)
				{
					curFloor = LegendItemDungeonUiHelper.MaxDifficult - 1;
				}
				curFloor = Mathf.Max(curFloor, 1);
				UI_LegendItemDungeonPanel.explorationState = UI_LegendItemDungeonPanel.GetExplorationState(curFloor);
			}
			else if (UI_LegendItemDungeonPanel.curLevelCount >= LegendItemDungeonUiHelper.ScoreToBoss)
			{
				curFloor = UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 1;
				UI_LegendItemDungeonPanel.explorationState = UI_LegendItemDungeonPanel.GetExplorationState(curFloor);
			}
		}
		LegendItemDungeonUiHelper.SaveCurFloor(curFloor);
	}

	private void UpdateMapComVisible()
	{
		if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.InPreparation)
		{
			((GObject)MapUiDialog.Upward).visible = false;
			((GObject)MapUiDialog.Progress).visible = false;
			((GObject)MapUiDialog.Downward).visible = true;
			return;
		}
		if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.Completed || UI_LegendItemDungeonPanel.explorationState == ExplorationState.Finished)
		{
			((GObject)MapUiDialog.Upward).visible = false;
			((GObject)MapUiDialog.Downward).visible = false;
			((GObject)MapUiDialog.Progress).visible = true;
			return;
		}
		((GObject)MapUiDialog.Upward).visible = curFloor > 1;
		if (curFloor == UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 2)
		{
			((GObject)MapUiDialog.Downward).visible = UI_LegendItemDungeonPanel.curLevelCount >= LegendItemDungeonUiHelper.ScoreToBoss;
		}
		else
		{
			((GObject)MapUiDialog.Downward).visible = true;
		}
		((GObject)MapUiDialog.Progress).visible = true;
	}

	private void UpdateProgress()
	{
		((GObject)MapUiDialog.Progress.content).visible = true;
		if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.Finished)
		{
			MapUiDialog.Progress.Type.selectedIndex = 3;
			return;
		}
		if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.Completed)
		{
			MapUiDialog.Progress.Type.selectedIndex = 2;
			((GObject)MapUiDialog.Progress.content).visible = false;
			((GObject)MapUiDialog.Progress.contentBack).visible = false;
			Level dungeonLevelForUi = LegendItemDungeonUiHelper.GetDungeonLevelForUi(UI_LegendItemDungeonPanel.LegendItemDungeonLevels[LegendItemDungeonUiHelper.GetFloorKey(curFloor)].First());
			FloorInfoDisplayRender(dungeonLevelForUi, MapUiDialog.Progress.display);
			return;
		}
		if (UI_LegendItemDungeonPanel.curLevelCount >= LegendItemDungeonUiHelper.ScoreToBoss)
		{
			MapUiDialog.Progress.Type.selectedIndex = 1;
		}
		else
		{
			MapUiDialog.Progress.Type.selectedIndex = 0;
		}
		((GObject)MapUiDialog.Progress.content).text = $"{UI_LegendItemDungeonPanel.GetProgressTitle()} {UI_LegendItemDungeonPanel.curLevelCount}/{LegendItemDungeonUiHelper.ScoreToBoss}";
		if (string.IsNullOrWhiteSpace(MapUiDialog.Progress.TreasureMap.Icon.url))
		{
			string itemId = ((GObject)MapUiDialog.Progress.TreasureMap).data.ToString();
			FGUIManager.Instance.SetItemIconAndFrame(MapUiDialog.Progress.TreasureMap.Icon, itemId, UI_LegendItemDungeonPanel.textureList, "", frameVisible: false);
		}
	}

	public void UpdateDownward()
	{
		if (UI_LegendItemDungeonPanel.explorationState == ExplorationState.InPreparation)
		{
			if (UI_LegendItemDungeonPanel.selectSoldierData.Count <= 0)
			{
				MapUiDialog.Downward.Type.selectedIndex = 0;
				((GObject)MapUiDialog.Downward).touchable = false;
			}
			else
			{
				MapUiDialog.Downward.Type.selectedIndex = 1;
				((GObject)MapUiDialog.Downward).touchable = true;
			}
		}
		else if (UI_LegendItemDungeonPanel.curLevelCount >= LegendItemDungeonUiHelper.ScoreToBoss)
		{
			MapUiDialog.Downward.Type.selectedIndex = 4;
			((GObject)MapUiDialog.Downward).touchable = true;
			((GObject)MapUiDialog.Upward).visible = false;
		}
		else if (curFloor < LegendItemDungeonUiHelper.MaxDifficult)
		{
			MapUiDialog.Downward.Type.selectedIndex = 3;
			((GObject)MapUiDialog.Downward).touchable = true;
		}
		else
		{
			MapUiDialog.Downward.Type.selectedIndex = 2;
			((GObject)MapUiDialog.Downward).touchable = false;
		}
	}
}
