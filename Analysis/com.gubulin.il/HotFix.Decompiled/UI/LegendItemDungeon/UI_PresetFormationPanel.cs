using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace UI.LegendItemDungeon;

public class UI_PresetFormationPanel : GComponent, IUiController
{
	private class SelectFormations
	{
		public Dictionary<string, SelectFormation> Data = new Dictionary<string, SelectFormation>();

		public bool CheckValid()
		{
			bool flag = true;
			if (Data == null)
			{
				Data = new Dictionary<string, SelectFormation>();
				for (int i = 0; i < 3; i++)
				{
					Data.Add(i.ToString(), new SelectFormation(i));
				}
			}
			for (int j = 0; j < 3; j++)
			{
				if (!Data.ContainsKey(j.ToString()))
				{
					Data.Add(j.ToString(), new SelectFormation(j));
				}
			}
			List<KeyValuePair<string, SelectFormation>> list = Data.ToList();
			for (int k = 0; k < list.Count; k++)
			{
				flag &= list[k].Value.CheckValid();
				for (int num = list[k].Value.SoldiersId.Count - 1; num >= 0; num--)
				{
					string text = list[k].Value.SoldiersId[num];
					if (string.IsNullOrEmpty(text) || text == "Unlock" || text == "Lock")
					{
						list[k].Value.SoldiersId[num] = "Unlock";
					}
				}
			}
			return flag;
		}
	}

	public class SelectFormation
	{
		public int ArrayId { get; set; }

		public List<string> SoldiersId { get; set; } = null;

		public Dictionary<string, List<long>> LegendItemIds { get; set; } = null;

		public string FormationId { get; set; } = string.Empty;

		public SelectFormation(int ArrayId)
		{
			this.ArrayId = ArrayId;
		}

		public void ClearData()
		{
			SoldiersId = null;
			FormationId = string.Empty;
			LegendItemIds = null;
			CheckValid();
		}

		public bool CheckValid()
		{
			if (SoldiersId == null)
			{
				SoldiersId = new List<string> { "", "", "", "", "" };
			}
			if (SoldiersId.Count > 5)
			{
				SoldiersId = SoldiersId.GetRange(0, 5);
			}
			if (LegendItemIds == null)
			{
				LegendItemIds = new Dictionary<string, List<long>>();
				for (int i = 0; i < 5; i++)
				{
					if (!LegendItemIds.ContainsKey(SoldiersId[i]))
					{
						LegendItemIds.Add(SoldiersId[i], new List<long>());
					}
				}
			}
			if (string.IsNullOrEmpty(FormationId))
			{
				FormationId = "FA01";
			}
			if (FormationId == string.Empty)
			{
				return false;
			}
			return true;
		}
	}

	public GGraph Mask;

	public UI_SelectPeakBattleArrayDialog Dialog;

	public const string URL = "ui://2eraz3j9ldt61w";

	public static string Name = "UI_PresetFormationPanel";

	public static UI_PresetFormationPanel PeakBattleSelectArrayPanel;

	private const int ArrayNum = 3;

	private List<Formation> unlockFormations = new List<Formation>();

	public List<string> selectedSoldierId = new List<string>();

	private SelectFormations selectFormations = new SelectFormations();

	private string curSelectFormationArrayId;

	private int curSoldierIndex;

	private bool IsUsingMode;

	private Level curLevel;

	private Dictionary<string, int> DungeonSoldiers;

	private Action<SelectFormation> OnUseFormationSuccess;

	private string curTouchArrayId;

	private float curTouchFormationBtnY;

	private int curTouchBtnIndex;

	private bool isMouseMoving = false;

	public static string GetURL()
	{
		return "ui://2eraz3j9ldt61w";
	}

	public static UI_PresetFormationPanel CreateInstance()
	{
		return (UI_PresetFormationPanel)(object)UIPackage.CreateObject("LegendItemDungeon", "PresetFormationPanel");
	}

	public static UI_PresetFormationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PresetFormationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9ldt61w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_SelectPeakBattleArrayDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		PeakBattleSelectArrayPanel = null;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		PeakBattleSelectArrayPanel = this;
		LoadLocal(parameters);
		GetAllUnlockFormations();
		RenderSoldiers();
		ShowCurSelectFormation();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.SoldiersSwitch).onClick.Add(new EventCallback0(ChangeSoldiersStatus));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(SyncRankFormationUnits_And_StartRankBattle));
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", Dialog.FormationSketchMap.OnCampClose);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.SoldiersSwitch).onClick.Remove(new EventCallback0(ChangeSoldiersStatus));
		((GObject)Dialog.ConfirmBtn).onClick.Remove(new EventCallback0(SyncRankFormationUnits_And_StartRankBattle));
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", Dialog.FormationSketchMap.OnCampClose);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ChangeSoldiersStatus()
	{
		if (Dialog.SoldiersSwitch.Status.selectedIndex == 0)
		{
			Dialog.SoldiersSwitch.Status.selectedIndex = 1;
		}
		else
		{
			Dialog.SoldiersSwitch.Status.selectedIndex = 0;
		}
		Dialog.SoldiersStatus.selectedIndex = Dialog.SoldiersSwitch.Status.selectedIndex;
	}

	private void RenderSoldiers()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.Soliders.itemRenderer = new ListItemRenderer(RenderSoldierItem);
		Dialog.Soliders.numItems = 3;
		if (Dialog.Soliders.numItems >= 1)
		{
			GComponent asCom = ((GComponent)Dialog.Soliders).GetChildAt(0).asCom;
			GButton asButton = asCom.GetChild("ArrayIndex").asButton;
			((GComponent)asButton).GetController("btnaddd").selectedIndex = 1;
		}
	}

	private void RenderSoldierItem(int index, GObject obj)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		UI_BattleArray uI_BattleArray = obj as UI_BattleArray;
		List<KeyValuePair<string, SelectFormation>> list = selectFormations.Data.ToList();
		if (index > list.Count - 1)
		{
			((GObject)uI_BattleArray).enabled = false;
			return;
		}
		((GObject)uI_BattleArray.ArrayIndex).touchable = true;
		((GObject)uI_BattleArray.ArrayIndex.indexText).text = $"{index + 1}";
		RenderSelectSoldiers(uI_BattleArray.enemy, list[index].Key);
		if (string.IsNullOrEmpty(list[index].Value.FormationId))
		{
			uI_BattleArray.formationIcon.url = "";
		}
		else
		{
			Formation formation = FormationManager.Formations[list[index].Value.FormationId];
			uI_BattleArray.formationIcon.url = "ui://LegendItemDungeon/" + formation.Icon;
		}
		GGraph selectFormation = uI_BattleArray.SelectFormation;
		((GObject)selectFormation).name = ((GObject)selectFormation).name + $"{index + 1}";
		((GObject)uI_BattleArray.CurFormation).onClick.Set(new EventCallback1(CurFormationClick));
		((GObject)uI_BattleArray.ArrayIndex).data = index;
		((GObject)uI_BattleArray.ArrayIndex).onClick.Set(new EventCallback1(UpdateCurSelectFormationArrayId));
		((GObject)uI_BattleArray.clearBtn).data = index;
		((GObject)uI_BattleArray.clearBtn).onClick.Set(new EventCallback1(ClearCurSelectFormationData));
		((GObject)uI_BattleArray.UseBtn).onClick.Set((EventCallback0)delegate
		{
			OnUseFormation(index.ToString());
		});
		((GObject)uI_BattleArray).data = list[index].Key;
	}

	private void UpdateCurSelectFormationArrayId(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		object data = val.data;
		if (data != null)
		{
			string text = data.ToString();
			curSelectFormationArrayId = text;
			ShowCurSelectFormation(curSelectFormationArrayId);
			GComponent asCom = ((GComponent)Dialog.Soliders).GetChildAt(0).asCom;
			GComponent asCom2 = ((GComponent)Dialog.Soliders).GetChildAt(1).asCom;
			GComponent asCom3 = ((GComponent)Dialog.Soliders).GetChildAt(2).asCom;
			GButton asButton = asCom.GetChild("ArrayIndex").asButton;
			GButton asButton2 = asCom2.GetChild("ArrayIndex").asButton;
			GButton asButton3 = asCom3.GetChild("ArrayIndex").asButton;
			Controller controller = ((GComponent)asButton).GetController("btnaddd");
			Controller controller2 = ((GComponent)asButton2).GetController("btnaddd");
			int num = (((GComponent)asButton3).GetController("btnaddd").selectedIndex = 0);
			int selectedIndex = (controller2.selectedIndex = num);
			controller.selectedIndex = selectedIndex;
			UI_MyArrayIndex uI_MyArrayIndex = ((GObject)context.sender) as UI_MyArrayIndex;
			((GComponent)uI_MyArrayIndex).GetController("btnaddd").selectedIndex = 1;
		}
	}

	private void ClearCurSelectFormationData(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		object data = val.data;
		if (data == null)
		{
			return;
		}
		int num = (int)data;
		string text = data.ToString();
		List<string> soldiersId = selectFormations.Data[text].SoldiersId;
		for (int num2 = selectedSoldierId.Count - 1; num2 >= 0; num2--)
		{
			if (soldiersId.Contains(selectedSoldierId[num2]))
			{
				selectedSoldierId.RemoveAt(num2);
			}
		}
		selectFormations.Data[text].ClearData();
		RenderSoldierItem(num, ((GComponent)Dialog.Soliders).GetChildAt(num));
		ShowCurSelectFormation(text);
	}

	private void OnUseFormation(string arrayId)
	{
		if (curLevel == null)
		{
			return;
		}
		SelectFormation curSelected = selectFormations.Data[arrayId];
		Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(curLevel);
		string formationContext = ((levelActivity == null) ? curLevel.FormationContext : levelActivity.FormationTag);
		string subFormationContext = curLevel.BattleMode.ToString();
		List<string> presetSoldiers = new List<string>(curSelected.SoldiersId);
		for (int i = 0; i < presetSoldiers.Count; i++)
		{
			if (!DungeonSoldiers.ContainsKey(presetSoldiers[i]))
			{
				presetSoldiers[i] = "Unlock";
			}
		}
		ActionResult actionResult = GameManagers.Instance.FormationManager.SetCurrentFormation(formationContext, subFormationContext, curSelected.FormationId);
		if (!actionResult.Result)
		{
			ILRequestHelper.ShowMessage(actionResult.ErrorMessage);
			return;
		}
		ILRequestHelper<ChangeFormationResponse>.Request((EventContext)null, (Func<Task<ChangeFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().ChangeFormation(-1L, formationContext, subFormationContext, curSelected.FormationId)), (Action<ChangeFormationResponse>)delegate(ChangeFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Dictionary<string, Dictionary<string, string>> value = GameController.Contexts.config.currentFormation.value;
				if (!value.TryGetValue(formationContext, out var value2))
				{
					value2 = new Dictionary<string, string>();
					value.Add(formationContext, value2);
				}
				string key = subFormationContext;
				if (value2.ContainsKey(key))
				{
					value2[key] = curSelected.FormationId;
				}
				else
				{
					value2.Add(key, curSelected.FormationId);
				}
				GameController.Contexts.config.ReplaceCurrentFormation(value);
				ActionResult actionResult2 = GameManagers.Instance.FormationUnitsManager.ChangeFormationUnit(formationContext, subFormationContext, presetSoldiers);
				if (!actionResult2.Result)
				{
					ILRequestHelper.ShowMessage(actionResult2.ErrorMessage);
				}
				else
				{
					OnUseFormationSuccess?.Invoke(curSelected);
				}
			}
		});
		End();
	}

	public void OnBlockTouchBegin(EventContext context)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		if (Dialog.SoldiersStatus.selectedIndex == 1 && !isMouseMoving)
		{
			curTouchArrayId = "";
			curTouchFormationBtnY = 0f;
			GObject touchTarget = GRoot.inst.touchTarget;
			if (touchTarget.name.Contains("SelectFormation"))
			{
				GObject val = (GObject)context.sender;
				curTouchArrayId = val.data.ToString();
				curTouchFormationBtnY = ((GObject)touchTarget.parent).y;
				curTouchBtnIndex = ((GComponent)Dialog.Soliders).GetChildIndex(val);
				Vector2 val2 = default(Vector2);
				((Vector2)(ref val2))._002Ector(context.inputEvent.x, context.inputEvent.y);
				Vector2 val3 = ((GObject)UnityUiService.Instance.maskCover).GlobalToLocal(val2);
				Vector2 val4 = val.LocalToRoot(new Vector2(val.width / 2f - 20f, val.height / 2f + 20f), GRoot.inst);
			}
		}
	}

	public void OnBlockTouchMove(EventContext context)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (Dialog.SoldiersStatus.selectedIndex == 1)
		{
			isMouseMoving = true;
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
			Vector2 val2 = ((GObject)UnityUiService.Instance.maskCover).GlobalToLocal(val);
		}
	}

	public void OnBlockTouchEnd(EventContext context)
	{
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		if (Dialog.SoldiersStatus.selectedIndex != 1)
		{
			return;
		}
		GObject touchTarget = GRoot.inst.touchTarget;
		if (isMouseMoving)
		{
			isMouseMoving = false;
			if (touchTarget != null && touchTarget.name.Contains("SelectFormation") && !string.IsNullOrWhiteSpace(curTouchArrayId))
			{
				UI_BattleArray uI_BattleArray = touchTarget.parent as UI_BattleArray;
				float y = ((GObject)uI_BattleArray).y;
				string text = ((GObject)uI_BattleArray).data.ToString();
				int childIndex = ((GComponent)Dialog.Soliders).GetChildIndex((GObject)(object)uI_BattleArray);
				string formationId = selectFormations.Data[text].FormationId;
				List<string> soldiersId = selectFormations.Data[text].SoldiersId;
				Dictionary<string, List<long>> legendItemIds = selectFormations.Data[text].LegendItemIds;
				UI_BattleArray uI_BattleArray2 = ((GComponent)Dialog.Soliders).GetChildAt(curTouchBtnIndex) as UI_BattleArray;
				((GObject)uI_BattleArray2).y = y;
				((GObject)uI_BattleArray2).data = text;
				((GObject)uI_BattleArray2.ArrayIndex).data = childIndex;
				((GObject)uI_BattleArray2.clearBtn).data = childIndex;
				((GObject)uI_BattleArray2.ArrayIndex.indexText).text = $"{childIndex + 1}";
				GGraph selectFormation = uI_BattleArray2.SelectFormation;
				((GObject)selectFormation).name = ((GObject)selectFormation).name + $"{childIndex + 1}";
				((GComponent)Dialog.Soliders).SetChildIndex((GObject)(object)uI_BattleArray2, childIndex);
				selectFormations.Data[text].FormationId = selectFormations.Data[curTouchArrayId].FormationId;
				selectFormations.Data[text].SoldiersId = selectFormations.Data[curTouchArrayId].SoldiersId;
				selectFormations.Data[text].LegendItemIds = selectFormations.Data[curTouchArrayId].LegendItemIds;
				((GObject)uI_BattleArray).y = curTouchFormationBtnY;
				((GObject)uI_BattleArray).data = curTouchArrayId;
				((GObject)uI_BattleArray.ArrayIndex).data = curTouchBtnIndex;
				((GObject)uI_BattleArray.clearBtn).data = curTouchBtnIndex;
				((GObject)uI_BattleArray.ArrayIndex.indexText).text = $"{curTouchBtnIndex + 1}";
				GGraph selectFormation2 = uI_BattleArray.SelectFormation;
				((GObject)selectFormation2).name = ((GObject)selectFormation2).name + $"{curTouchBtnIndex + 1}";
				((GComponent)Dialog.Soliders).SetChildIndex((GObject)(object)uI_BattleArray, curTouchBtnIndex);
				selectFormations.Data[curTouchArrayId].FormationId = formationId;
				selectFormations.Data[curTouchArrayId].SoldiersId = soldiersId;
				selectFormations.Data[curTouchArrayId].LegendItemIds = legendItemIds;
				((GObject)uI_BattleArray2.ArrayIndex).onClick.Call();
				ShowCurSelectFormation(text);
				Vector2 val = ((GObject)uI_BattleArray2).LocalToRoot(new Vector2(((GObject)uI_BattleArray2).width / 2f - 20f, ((GObject)uI_BattleArray2).height / 2f + 20f), GRoot.inst);
			}
		}
		else if (touchTarget.name.Contains("ArrayIndex"))
		{
		}
	}

	private void RenderSelectSoldiers(GList soldierGList, string arrayId)
	{
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		soldierGList.RemoveChildrenToPool();
		for (int i = 0; i < selectFormations.Data[arrayId].SoldiersId.Count; i++)
		{
			string text = selectFormations.Data[arrayId].SoldiersId[i];
			if (!string.IsNullOrEmpty(text) && text != "Unlock" && text != "Lock")
			{
				string soldierId = selectFormations.Data[arrayId].SoldiersId[i];
				GObject obj = soldierGList.AddItemFromPool();
				RenderSelectSoldierItem(i, obj, soldierId);
			}
		}
	}

	private void RenderSelectSoldierItem(int index, GObject obj, string soldierId)
	{
		UI_enemyItem uI_enemyItem = obj as UI_enemyItem;
		string iconPath = UiHelper.GetIconPath(soldierId);
		uI_enemyItem.icon.url = "ui://PublicResources/" + iconPath;
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		((GObject)uI_enemyItem.lv).text = $"{soldier.Level}";
		int num = (soldier.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		uI_enemyItem.iconFrame.material = null;
		uI_enemyItem.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		uI_enemyItem.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		((GObject)uI_enemyItem.n47).visible = false;
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)uI_enemyItem.iconFrame).asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_enemyItem.SoulStoneLevel, soldier.PotentialLevel, null);
		((GObject)uI_enemyItem).grayed = !DungeonSoldiers.ContainsKey(soldierId);
	}

	private void ShowCurSelectFormation(string _arrayId = "")
	{
		curSelectFormationArrayId = (string.IsNullOrEmpty(_arrayId) ? selectFormations.Data.ToList().First().Key : _arrayId);
		SelectFormation selectFormation = selectFormations.Data[curSelectFormationArrayId];
		Dialog.FormationSketchMap.SetOurPos(selectFormation.FormationId, selectFormation.SoldiersId, selectedSoldierId, selectFormation.LegendItemIds, DungeonSoldiers);
		Dialog.n52.CurFormationInit(selectFormation.FormationId);
	}

	public void UpdateSomeSoldierBtn(int _index, string _sid)
	{
		Dictionary<string, SelectFormation> data = selectFormations.Data;
		SelectFormation selectFormation = data[curSelectFormationArrayId.ToString()];
		List<string> soldiersId = selectFormation.SoldiersId;
		soldiersId[_index] = _sid;
		List<long> list = new List<long> { 0L, 0L };
		if (LegendItemsHelper.SoldiersEquippedItems.ContainsKey(_sid))
		{
			long[] array = LegendItemsHelper.SoldiersEquippedItems[_sid];
			for (int i = 0; i < array.Length; i++)
			{
				list[i] = array[i];
			}
		}
		if (!selectFormation.LegendItemIds.ContainsKey(_sid))
		{
			selectFormation.LegendItemIds.Add(_sid, list);
		}
		else
		{
			selectFormation.LegendItemIds[_sid] = list;
		}
		RenderSelectSoldiers(((GComponent)((GComponent)Dialog.Soliders).GetChildAt(int.Parse(curSelectFormationArrayId)).asButton).GetChild("enemy").asList, curSelectFormationArrayId);
	}

	public void UpdateSomeSoldierLegendItems()
	{
	}

	public void UpdateSelectedSoldierId(string _sid, bool isAdd)
	{
		if (isAdd)
		{
			if (!selectedSoldierId.Contains(_sid))
			{
				selectedSoldierId.Add(_sid);
			}
		}
		else if (selectedSoldierId.Contains(_sid))
		{
			selectedSoldierId.Remove(_sid);
		}
	}

	private void CurFormationClick(EventContext context)
	{
		UI_CurFormation uI_CurFormation = (UI_CurFormation)(object)context.sender;
		if (uI_CurFormation.Status.selectedIndex == 0)
		{
			uI_CurFormation.Status.selectedIndex = 1;
			RenderUnlockFormations(uI_CurFormation);
		}
		else if (uI_CurFormation.Status.selectedIndex == 1)
		{
			uI_CurFormation.Status.selectedIndex = 0;
			RenderCurFormation(uI_CurFormation.MainFormation, selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId);
		}
		context.StopPropagation();
	}

	public void UpdateCurSelectFormation(string _fid)
	{
		if (selectFormations.Data.ContainsKey(curSelectFormationArrayId))
		{
			selectFormations.Data[curSelectFormationArrayId].FormationId = _fid;
			Dialog.FormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId].FormationId, selectFormations.Data[curSelectFormationArrayId].SoldiersId, selectedSoldierId, selectFormations.Data[curSelectFormationArrayId].LegendItemIds, DungeonSoldiers);
			if (!string.IsNullOrEmpty(_fid))
			{
				Formation formation = FormationManager.Formations[_fid];
				UI_BattleArray uI_BattleArray = ((GComponent)Dialog.Soliders).GetChildAt(int.Parse(curSelectFormationArrayId)).asButton as UI_BattleArray;
				uI_BattleArray.formationIcon.url = "ui://LegendItemDungeon/" + formation.Icon;
			}
		}
	}

	private void GetAllUnlockFormations()
	{
		Dictionary<string, GDEFormationData> unlockedFormations = GameManagers.Instance.FormationManager.GetUnlockedFormations();
		List<string> unlockFormationsId = new List<string>();
		foreach (KeyValuePair<string, GDEFormationData> item in unlockedFormations)
		{
			unlockFormationsId.Add(item.Value.Key);
		}
		List<Formation> source = FormationManager.PlayerUsableFormations.Values.ToList();
		unlockFormations.Clear();
		unlockFormations.AddRange(source.OrderByDescending((Formation formation) => unlockFormationsId.Contains(formation.Id)));
		for (int num = unlockFormations.Count - 1; num >= 0; num--)
		{
			if (!unlockFormationsId.Contains(unlockFormations[num].Id))
			{
				unlockFormations.RemoveAt(num);
			}
		}
		Dialog.n52.GetAllUnlockFormations(unlockFormations);
	}

	private void RenderUnlockFormations(UI_CurFormation _curFormation)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		_curFormation.Formations.itemRenderer = new ListItemRenderer(RenderFormation);
		_curFormation.Formations.numItems = unlockFormations.Count;
	}

	private void RenderFormation(int index, GObject obj)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		UI_FormationBtn uI_FormationBtn = obj as UI_FormationBtn;
		RenderCurFormation(uI_FormationBtn, unlockFormations[index].Id);
		((GObject)uI_FormationBtn).data = unlockFormations[index].Id;
		((GObject)uI_FormationBtn).onClick.Set(new EventCallback1(SelectArrayFormation));
	}

	private void RenderCurFormation(UI_FormationBtn _curFormationBtn, string _formationId)
	{
		if (string.IsNullOrEmpty(_formationId))
		{
			((GObject)_curFormationBtn.name).text = "";
			_curFormationBtn.formationIcon.url = "";
		}
		else
		{
			Formation formation = FormationManager.Formations[_formationId];
			((GObject)_curFormationBtn.name).text = formation.Name;
			_curFormationBtn.formationIcon.url = "ui://LegendItemDungeon//" + formation.Icon;
		}
	}

	private void SelectArrayFormation(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrEmpty(text) && selectFormations.Data.ContainsKey(curSelectFormationArrayId.ToString()))
		{
			selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId = text;
			Dialog.FormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId, selectFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, selectFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds, DungeonSoldiers);
		}
	}

	private TreasureHuntBattleFormationConfig SaveLocal()
	{
		int num = 3;
		bool flag = selectFormations.CheckValid();
		List<SelectFormation> list = selectFormations.Data.Values.ToList();
		List<string> list2 = new List<string>();
		List<List<string>> list3 = new List<List<string>>();
		int num2 = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (num2 >= num)
			{
				break;
			}
			list2.Add(list[i].FormationId);
			List<string> list4 = new List<string>();
			for (int j = 0; j < list[i].SoldiersId.Count; j++)
			{
				list4.Add(list[i].SoldiersId[j]);
			}
			list3.Add(list4);
			num2++;
		}
		return new TreasureHuntBattleFormationConfig
		{
			FormationsId = list2,
			Units = list3,
			_jsonUnits = JsonHelper.ToJson(list3)
		};
	}

	private void LoadLocal(Dictionary<string, object> parameters)
	{
		if (parameters != null)
		{
			if (parameters.TryGetValue("IsUsingMode", out var value))
			{
				IsUsingMode = (bool)value;
				if (IsUsingMode)
				{
					Dialog.SoldiersStatus.selectedIndex = 2;
				}
			}
			if (parameters.TryGetValue("Level", out var value2))
			{
				curLevel = (Level)value2;
			}
			if (parameters.TryGetValue("Callbacks", out var value3))
			{
				Dictionary<string, Action<SelectFormation>> dictionary = (Dictionary<string, Action<SelectFormation>>)value3;
				if (dictionary.TryGetValue("OnUseFormationSuccess", out var value4))
				{
					OnUseFormationSuccess = value4;
				}
			}
		}
		TreasureHuntBattleFormationConfig treasureHuntBattleFormationConfig = null;
		if (parameters.TryGetValue("PresetFormationData", out var value5))
		{
			treasureHuntBattleFormationConfig = value5 as TreasureHuntBattleFormationConfig;
		}
		DungeonSoldiers = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> curSoldier in LegendItemDungeonUiHelper.CurSoldiers)
		{
			DungeonSoldiers.Add(curSoldier.Key, curSoldier.Value);
		}
		selectFormations.Data = null;
		int num = 3;
		int num2 = 0;
		if (treasureHuntBattleFormationConfig != null)
		{
			selectFormations.Data = new Dictionary<string, SelectFormation>();
			for (int i = 0; i < treasureHuntBattleFormationConfig.FormationsId.Count; i++)
			{
				if (num2 >= num)
				{
					break;
				}
				SelectFormation selectFormation = new SelectFormation(i);
				selectFormation.FormationId = treasureHuntBattleFormationConfig.FormationsId[i];
				if (treasureHuntBattleFormationConfig.Units.Count > i)
				{
					List<string> list = treasureHuntBattleFormationConfig.Units[i];
					if (list.Count <= 0)
					{
						selectFormation.SoldiersId = null;
						selectFormation.LegendItemIds = null;
					}
					else
					{
						selectFormation.SoldiersId = new List<string>();
						selectFormation.LegendItemIds = new Dictionary<string, List<long>>();
						for (int j = 0; j < 5; j++)
						{
							if (j > list.Count - 1)
							{
								selectFormation.SoldiersId.Add("Unlock");
								continue;
							}
							string text = list[j];
							List<long> list2 = new List<long>();
							if (LegendItemsHelper.SoldiersEquippedItems.ContainsKey(text))
							{
								long[] array = LegendItemsHelper.SoldiersEquippedItems[text];
								for (int k = 0; k < array.Length; k++)
								{
									list2.Add(array[k]);
								}
							}
							if (string.IsNullOrEmpty(text))
							{
								text = "Unlock";
							}
							selectFormation.SoldiersId.Add(text);
							if (!selectFormation.LegendItemIds.ContainsKey(text))
							{
								selectFormation.LegendItemIds.Add(text, list2);
							}
						}
					}
				}
				else
				{
					selectFormation.SoldiersId = null;
					selectFormation.LegendItemIds = null;
				}
				selectFormations.Data.Add(i.ToString(), selectFormation);
				num2++;
			}
		}
		selectFormations.CheckValid();
		foreach (KeyValuePair<string, SelectFormation> datum in selectFormations.Data)
		{
			for (int l = 0; l < datum.Value.SoldiersId.Count; l++)
			{
				string text2 = datum.Value.SoldiersId[l];
				if (!string.IsNullOrEmpty(text2) && text2 != "Lock" && text2 != "Unlock")
				{
					selectedSoldierId.Add(text2);
				}
			}
		}
	}

	private void SyncRankFormationUnits_And_StartRankBattle()
	{
		TreasureHuntBattleFormationConfig _battleFormationUnitsConfig = SaveLocal();
		if (!CheckTreasureHuntBattlePresetFormation(_battleFormationUnitsConfig, out var errCode))
		{
			ILRequestHelper.ShowErrorCode(errCode);
			return;
		}
		ILRequestHelper<SetTreasureHuntBattlePresetFormationResponse>.Request((EventContext)null, (Func<Task<SetTreasureHuntBattlePresetFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().SetTreasureHuntBattlePresetFormation(_battleFormationUnitsConfig)), (Action<SetTreasureHuntBattlePresetFormationResponse>)delegate(SetTreasureHuntBattlePresetFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { " " + LanguagesManager.GetDesc("CsharpCodeZhTcText336") + " " }, 1000, arg3: false);
			}
		});
	}

	private bool CheckTreasureHuntBattlePresetFormation(TreasureHuntBattleFormationConfig formation, out int errCode)
	{
		if (formation == null)
		{
			errCode = 24001001;
			return false;
		}
		List<string> list = new List<string>();
		errCode = 0;
		if (formation.FormationsId.Count != 3)
		{
			errCode = 24001002;
			return false;
		}
		if (formation.Units.Count != 3)
		{
			errCode = 24001003;
			return false;
		}
		foreach (List<string> unit in formation.Units)
		{
			if (unit.Count > 5)
			{
				errCode = 24001004;
				return false;
			}
			if (unit.Count == 0)
			{
				errCode = 24001005;
				return false;
			}
			for (int i = 0; i < unit.Count; i++)
			{
				string text = unit[i];
				if (text == string.Empty || text == "Unlock" || text == "Lock")
				{
					list.Add(text);
					continue;
				}
				if (list.IndexOf(text) >= 0)
				{
					errCode = 24001006;
					return false;
				}
				list.Add(text);
			}
		}
		return true;
	}

	private void ShowPerhapsFailTip(List<List<string>> unitsId, int myLegionSize, Action action)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		List<int> needShakeArrayBtnIndex = new List<int>();
		int num2 = ((unitsId.Count >= myLegionSize) ? myLegionSize : unitsId.Count);
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < unitsId[i].Count; j++)
			{
				string text = unitsId[i][j];
				if (string.IsNullOrEmpty(text) || text == "Unlock" || text == "Lock")
				{
					num++;
					flag2 = true;
					if (!needShakeArrayBtnIndex.Contains(i))
					{
						needShakeArrayBtnIndex.Add(i);
					}
				}
			}
			if (num >= unitsId[i].Count)
			{
				flag = true;
				if (!needShakeArrayBtnIndex.Contains(i))
				{
					needShakeArrayBtnIndex.Add(i);
				}
			}
			num = 0;
		}
		if (!flag && !flag2)
		{
			action();
			return;
		}
		Action action2 = delegate
		{
			Dialog.FormationSketchMap.PlayPosShake();
			for (int k = 0; k < needShakeArrayBtnIndex.Count; k++)
			{
				((GComponent)((GComponent)Dialog.Soliders).GetChildAt(needShakeArrayBtnIndex[k]).asButton).GetTransition("Shake").Play();
			}
		};
		if (flag)
		{
			UiHelper.ShowConfirmDialog(LanguagesManager.GetDesc("CsharpCodeZhTcText337") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText127") + "[/color]", action2);
		}
		else
		{
			UiHelper.ShowConfirmDialog(LanguagesManager.GetDesc("CsharpCodeZhTcText337") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText127") + "[/color]", action2);
		}
	}
}
