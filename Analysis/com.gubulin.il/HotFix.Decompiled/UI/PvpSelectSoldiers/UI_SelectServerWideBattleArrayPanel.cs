using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Tips;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_SelectServerWideBattleArrayPanel : GComponent, IUiController
{
	private class SelectFormations
	{
		public Dictionary<string, SelectFormation> Data = new Dictionary<string, SelectFormation>();

		public void TakeOffLegendItem(string curSelectFormationArrayId, string soldierId, int slot)
		{
			Data[curSelectFormationArrayId].LegendItemIds[soldierId][slot] = 0L;
		}

		public void WearLegendItem(string curSelectFormationArrayId, string soldierId, int slot, long legendItemId)
		{
			string text = "";
			long value = Data[curSelectFormationArrayId].LegendItemIds[soldierId][slot];
			int index = 0;
			bool flag = false;
			Dictionary<string, List<long>> dictionary = new Dictionary<string, List<long>>();
			foreach (KeyValuePair<string, SelectFormation> datum in Data)
			{
				foreach (KeyValuePair<string, List<long>> legendItemId2 in datum.Value.LegendItemIds)
				{
					if (legendItemId2.Value.Contains(legendItemId))
					{
						text = legendItemId2.Key;
						dictionary = datum.Value.LegendItemIds;
						index = legendItemId2.Value.IndexOf(legendItemId);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			Data[curSelectFormationArrayId].LegendItemIds[soldierId][slot] = legendItemId;
			if (dictionary != null && dictionary.Count > 0 && !string.IsNullOrEmpty(text) && dictionary.ContainsKey(text))
			{
				dictionary[text][index] = value;
			}
		}

		public bool CheckValid(int defaultTeamCount)
		{
			bool flag = true;
			if (Data == null)
			{
				Data = new Dictionary<string, SelectFormation>();
				for (int i = 0; i < defaultTeamCount; i++)
				{
					Data.Add(i.ToString(), new SelectFormation(i));
				}
			}
			for (int j = 0; j < defaultTeamCount; j++)
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

		public void LoadFromConfig(WarOfRealmConfig config, int defaultTeamCount = 4)
		{
			Data = new Dictionary<string, SelectFormation>();
			if (config != null && config.FormationsId != null && config.FormationsId.Count > 0)
			{
				int num = 0;
				for (int i = 0; i < config.FormationsId.Count; i++)
				{
					SelectFormation selectFormation = new SelectFormation(i);
					selectFormation.FormationId = config.FormationsId[i];
					if (config.Units != null && config.Units.Count > i)
					{
						List<SoldierWithLegendItemId> list = config.Units[i];
						if (list.Count < 5)
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
								list[j].DataCheck();
								selectFormation.SoldiersId.Add(list[j].SoldierId);
								selectFormation.LegendItemIds.Add(list[j].SoldierId, list[j].LegendItemIds);
							}
						}
					}
					else
					{
						selectFormation.SoldiersId = null;
						selectFormation.LegendItemIds = null;
					}
					Data.Add(i.ToString(), selectFormation);
					num++;
				}
			}
			CheckValid(defaultTeamCount);
		}

		public WarOfRealmConfig SaveToConfig(int teamCount)
		{
			CheckValid(teamCount);
			List<SelectFormation> list = Data.Values.ToList();
			List<string> list2 = new List<string>();
			List<List<SoldierWithLegendItemId>> list3 = new List<List<SoldierWithLegendItemId>>();
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (num >= teamCount)
				{
					break;
				}
				list2.Add(list[i].FormationId);
				List<SoldierWithLegendItemId> list4 = new List<SoldierWithLegendItemId>();
				for (int j = 0; j < list[i].SoldiersId.Count; j++)
				{
					SoldierWithLegendItemId soldierWithLegendItemId = new SoldierWithLegendItemId();
					soldierWithLegendItemId.SoldierId = list[i].SoldiersId[j];
					List<long> list5 = new List<long>();
					if (!string.IsNullOrEmpty(soldierWithLegendItemId.SoldierId) && !(soldierWithLegendItemId.SoldierId == "Unlock") && !(soldierWithLegendItemId.SoldierId == "Lock"))
					{
						List<long> list6 = list[i].LegendItemIds[soldierWithLegendItemId.SoldierId];
						for (int k = 0; k < list6.Count; k++)
						{
							if (list6[k] > 0)
							{
								list5.Add(list6[k]);
							}
						}
					}
					soldierWithLegendItemId.LegendItemIds = list5;
					list4.Add(soldierWithLegendItemId);
				}
				list3.Add(list4);
				num++;
			}
			return new WarOfRealmConfig
			{
				FormationsId = list2,
				_Units = list3,
				_jsonUnits = JsonHelper.ToJson(list3)
			};
		}
	}

	private class SelectFormation
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

	public GGraph mask;

	public UI_SelectServerWideBattleArrayDialog Dialog;

	public Transition popup;

	public const string URL = "ui://82mo10n5bsmljdup";

	public static string Name = "UI_SelectServerWideBattleArrayPanel";

	public static UI_SelectServerWideBattleArrayPanel Instance;

	private Dictionary<string, SoldierWithLegendItemId> _soliderInfoCache = new Dictionary<string, SoldierWithLegendItemId>();

	private SelectFormations selectFormations = new SelectFormations();

	private int _teamCount = 5;

	public List<string> selectedSoldierId = new List<string>();

	private string curSelectFormationArrayId;

	private string curTouchArrayId;

	private float curTouchFormationBtnY;

	private int curTouchBtnIndex;

	private bool isMouseMoving = false;

	private List<Formation> unlockFormations = new List<Formation>();

	public static string GetURL()
	{
		return "ui://82mo10n5bsmljdup";
	}

	public static UI_SelectServerWideBattleArrayPanel CreateInstance()
	{
		return (UI_SelectServerWideBattleArrayPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SelectServerWideBattleArrayPanel");
	}

	public static UI_SelectServerWideBattleArrayPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectServerWideBattleArrayPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5bsmljdup", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_SelectServerWideBattleArrayDialog)(object)((GComponent)this).GetChild("Dialog");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void BeforeDestroy()
	{
		Instance = null;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_soliderInfoCache = new Dictionary<string, SoldierWithLegendItemId>();
		Instance = this;
		LoadLocal(parameters);
		GetAllUnlockFormations();
		ShowCurSelectFormation();
		RenderSoldiers();
		DisplaySeasonBuff();
		popup.Play();
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
		((GObject)mask).onClick.Add(new EventCallback0(OnCloseButtonClick));
		((GObject)Dialog.SoldiersSwitch).onClick.Add(new EventCallback0(ChangeSoldiersStatus));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(SyncRankFormationUnits));
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
		((GObject)mask).onClick.Remove(new EventCallback0(OnCloseButtonClick));
		((GObject)Dialog.SoldiersSwitch).onClick.Remove(new EventCallback0(ChangeSoldiersStatus));
		((GObject)Dialog.ConfirmBtn).onClick.Remove(new EventCallback0(SyncRankFormationUnits));
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", Dialog.FormationSketchMap.OnCampClose);
	}

	private void OnCloseButtonClick()
	{
		if (HasEmptySlotInFormation(selectFormations))
		{
			string desc = LanguagesManager.GetDesc("PeakBattleSelectArrayPanelTip1");
			UiHelper.ShowConfirmAndCancelDialog(desc, delegate
			{
				End();
			}, null);
		}
		else
		{
			End();
		}
	}

	private bool HasEmptySlotInFormation(SelectFormations formations)
	{
		if (formations?.Data == null)
		{
			return true;
		}
		List<KeyValuePair<string, SelectFormation>> list = formations.Data.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			List<string> soldiersId = list[i].Value.SoldiersId;
			if (soldiersId == null)
			{
				return true;
			}
			bool flag = false;
			for (int j = 0; j < soldiersId.Count; j++)
			{
				string text = soldiersId[j];
				if (!string.IsNullOrEmpty(text) && text != "Unlock" && text != "Lock")
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return true;
			}
		}
		return false;
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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		int teamCount = _teamCount;
		Dialog.Soliders.itemRenderer = new ListItemRenderer(RenderSoldierItem);
		Dialog.Soliders.numItems = teamCount;
	}

	private void RenderSoldierItem(int index, GObject obj)
	{
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		UI_BattleArray uI_BattleArray = obj as UI_BattleArray;
		SelectFormations selectFormations = this.selectFormations;
		List<KeyValuePair<string, SelectFormation>> list = selectFormations.Data.ToList();
		if (index > list.Count - 1)
		{
			((GObject)uI_BattleArray).enabled = false;
			return;
		}
		((GObject)uI_BattleArray.ArrayIndex).touchable = true;
		((GObject)uI_BattleArray.ArrayIndex.indexText).text = $"{index + 1}";
		uI_BattleArray.ArrayIndex.btnaddd.SetSelectedIndex((index == 0) ? 1 : 0);
		RenderSelectSoldiers(uI_BattleArray.enemy, list[index].Key);
		if (string.IsNullOrEmpty(list[index].Value.FormationId))
		{
			uI_BattleArray.formationIcon.url = "";
		}
		else
		{
			Formation formation = FormationManager.Formations[list[index].Value.FormationId];
			uI_BattleArray.formationIcon.url = "ui://PvpSelectSoldiers/" + formation.Icon;
		}
		GGraph selectFormation = uI_BattleArray.SelectFormation;
		((GObject)selectFormation).name = ((GObject)selectFormation).name + $"{index + 1}";
		((GObject)uI_BattleArray.CurFormation).onClick.Set(new EventCallback1(CurFormationClick));
		((GObject)uI_BattleArray.ArrayIndex).data = index;
		((GObject)uI_BattleArray.ArrayIndex).onClick.Set(new EventCallback1(UpdateCurSelectFormationArrayId));
		((GObject)uI_BattleArray.clearBtn).data = index;
		((GObject)uI_BattleArray.clearBtn).onClick.Set(new EventCallback1(ClearCurSelectFormationData));
		((GObject)uI_BattleArray).data = list[index].Key;
		((GObject)uI_BattleArray).onTouchBegin.Set(new EventCallback1(OnBlockTouchBegin));
		((GObject)uI_BattleArray).onTouchMove.Set(new EventCallback1(OnBlockTouchMove));
		((GObject)uI_BattleArray).onTouchEnd.Set(new EventCallback1(OnBlockTouchEnd));
	}

	private void UpdateCurSelectFormationArrayId(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		object data = val.data;
		if (data != null)
		{
			string text = data.ToString();
			curSelectFormationArrayId = text;
			ShowCurSelectFormation(curSelectFormationArrayId);
			DisplaySeasonBuff();
			for (int i = 0; i < Dialog.Soliders.numItems; i++)
			{
				GComponent asCom = ((GComponent)Dialog.Soliders).GetChildAt(i).asCom;
				GButton asButton = asCom.GetChild("ArrayIndex").asButton;
				((GComponent)asButton).GetController("btnaddd").selectedIndex = 0;
			}
			UI_ArrayIndex uI_ArrayIndex = ((GObject)context.sender) as UI_ArrayIndex;
			((GComponent)uI_ArrayIndex).GetController("btnaddd").selectedIndex = 1;
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
		SelectFormations selectFormations = this.selectFormations;
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
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
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
				Vector2 touchPos = ((GObject)UnityUiService.Instance.maskCover).GlobalToLocal(val2);
				Vector2 formationBtnGlobalPos = val.LocalToRoot(new Vector2(val.width / 2f - 20f, val.height / 2f + 20f), GRoot.inst);
				UI_PvpTeamMoveInfo.ShowMainUi(formationBtnGlobalPos, touchPos, curTouchBtnIndex + 1);
			}
		}
	}

	public void OnBlockTouchMove(EventContext context)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (Dialog.SoldiersStatus.selectedIndex == 1)
		{
			isMouseMoving = true;
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
			Vector2 touchPos = ((GObject)UnityUiService.Instance.maskCover).GlobalToLocal(val);
			UI_PvpTeamMoveInfo.ChangePosOnMoving(touchPos);
		}
	}

	public void OnBlockTouchEnd(EventContext context)
	{
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
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
				SelectFormations selectFormations = this.selectFormations;
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
				Vector2 formationBtnGlobalPos = ((GObject)uI_BattleArray2).LocalToRoot(new Vector2(((GObject)uI_BattleArray2).width / 2f - 20f, ((GObject)uI_BattleArray2).height / 2f + 20f), GRoot.inst);
				UI_PvpTeamMoveInfo.MainUiDisappear(formationBtnGlobalPos, null);
			}
			else
			{
				UI_PvpTeamMoveInfo.Disappear();
			}
		}
		else if (!touchTarget.name.Contains("ArrayIndex"))
		{
			UI_PvpTeamMoveInfo.Disappear();
		}
	}

	private void RenderSelectSoldiers(GList soldierGList, string arrayId)
	{
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		soldierGList.RemoveChildrenToPool();
		SelectFormations selectFormations = this.selectFormations;
		if (!selectFormations.Data.ContainsKey(arrayId))
		{
			return;
		}
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
		uI_enemyItem.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		uI_enemyItem.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		((GObject)uI_enemyItem.n47).visible = false;
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)uI_enemyItem.iconFrame).asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_enemyItem.SoulStoneLevel, soldier.PotentialLevel, null);
	}

	public void UpdateSoldierLegendItems(string soldierId, int slot, long legendItemId)
	{
		SelectFormations selectFormations = this.selectFormations;
		selectFormations.WearLegendItem(curSelectFormationArrayId, soldierId, slot, legendItemId);
		Dialog.FormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId, selectFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, selectFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
		SoldierWithLegendItemId soldierInfo = GetSoldierInfo(soldierId);
		soldierInfo.LegendItemIds[slot] = legendItemId;
	}

	public void UpdateOnTakeOffLegendItem(string soldierId, int slot)
	{
		SelectFormations selectFormations = this.selectFormations;
		selectFormations.TakeOffLegendItem(curSelectFormationArrayId, soldierId, slot);
		Dialog.FormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId, selectFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, selectFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
		SoldierWithLegendItemId soldierInfo = GetSoldierInfo(soldierId);
		soldierInfo.LegendItemIds[slot] = 0L;
	}

	private void ShowCurSelectFormation(string _arrayId = "")
	{
		SelectFormations selectFormations = this.selectFormations;
		curSelectFormationArrayId = (string.IsNullOrEmpty(_arrayId) ? selectFormations.Data.ToList().First().Key : _arrayId);
		Dialog.FormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId, selectFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, selectFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
		Dialog.n52.CurFormationInit(selectFormations.Data[curSelectFormationArrayId].FormationId);
	}

	public void UpdateSomeSoldierBtn(int _index, string _sid)
	{
		SelectFormations selectFormations = this.selectFormations;
		Dictionary<string, SelectFormation> data = selectFormations.Data;
		SelectFormation selectFormation = data[curSelectFormationArrayId.ToString()];
		List<string> soldiersId = selectFormation.SoldiersId;
		soldiersId[_index] = _sid;
		if (!selectFormation.LegendItemIds.ContainsKey(_sid))
		{
			List<long> legendItemIds = GetSoldierInfo(_sid).LegendItemIds;
			selectFormation.LegendItemIds.Add(_sid, legendItemIds);
		}
		RenderSelectSoldiers(((GComponent)((GComponent)Dialog.Soliders).GetChildAt(int.Parse(curSelectFormationArrayId)).asButton).GetChild("enemy").asList, curSelectFormationArrayId);
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
			SelectFormations selectFormations = this.selectFormations;
			RenderCurFormation(uI_CurFormation.MainFormation, selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId);
		}
		context.StopPropagation();
	}

	public void UpdateCurSelectFormation(string _fid)
	{
		SelectFormations selectFormations = this.selectFormations;
		if (selectFormations.Data.ContainsKey(curSelectFormationArrayId))
		{
			selectFormations.Data[curSelectFormationArrayId].FormationId = _fid;
			Dialog.FormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId].FormationId, selectFormations.Data[curSelectFormationArrayId].SoldiersId, selectedSoldierId, selectFormations.Data[curSelectFormationArrayId].LegendItemIds);
			if (!string.IsNullOrEmpty(_fid))
			{
				Formation formation = FormationManager.Formations[_fid];
				UI_BattleArray uI_BattleArray = ((GComponent)Dialog.Soliders).GetChildAt(int.Parse(curSelectFormationArrayId)).asButton as UI_BattleArray;
				uI_BattleArray.formationIcon.url = "ui://PvpSelectSoldiers/" + formation.Icon;
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
			_curFormationBtn.formationIcon.url = "ui://PvpSelectSoldiers/" + formation.Icon;
		}
	}

	private void SelectArrayFormation(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			SelectFormations selectFormations = this.selectFormations;
			if (selectFormations.Data.ContainsKey(curSelectFormationArrayId.ToString()))
			{
				selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId = text;
				Dialog.FormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId, selectFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, selectFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
			}
		}
	}

	private void LoadLocal(Dictionary<string, object> parameters)
	{
		if (parameters == null)
		{
			End();
			return;
		}
		_teamCount = RankDataHelper.CurrentWarOfRealmTeamCount;
		if (parameters.TryGetValue("FormationResponse", out var value) && value is GetWarOfRealmFormationResponse getWarOfRealmFormationResponse)
		{
			selectFormations.LoadFromConfig(getWarOfRealmFormationResponse.Formation, _teamCount);
		}
		else
		{
			selectFormations.CheckValid(_teamCount);
		}
		selectedSoldierId.Clear();
		CollectSelectedSoldierIds(selectFormations);
	}

	private void CollectSelectedSoldierIds(SelectFormations formations)
	{
		if (formations?.Data == null)
		{
			return;
		}
		foreach (KeyValuePair<string, SelectFormation> datum in formations.Data)
		{
			for (int i = 0; i < datum.Value.SoldiersId.Count; i++)
			{
				string text = datum.Value.SoldiersId[i];
				if (!string.IsNullOrEmpty(text) && text != "Lock" && text != "Unlock" && !selectedSoldierId.Contains(text))
				{
					selectedSoldierId.Add(text);
				}
			}
		}
	}

	private bool CheckWarOfRealmFormation(WarOfRealmConfig formation, out int errCode)
	{
		int teamCount = _teamCount;
		List<string> list = new List<string>();
		List<long> list2 = new List<long>();
		List<string> list3 = new List<string>();
		errCode = 0;
		if (formation.FormationsId.Count != teamCount)
		{
			errCode = 81311615;
			return false;
		}
		if (formation.Units.Count != teamCount)
		{
			errCode = 81311615;
			return false;
		}
		foreach (List<SoldierWithLegendItemId> unit in formation.Units)
		{
			if (unit.Count > 5)
			{
				errCode = 81311616;
				return false;
			}
			if (unit.Count == 0)
			{
				errCode = 81311616;
				return false;
			}
			foreach (SoldierWithLegendItemId item in unit)
			{
				if (item.SoldierId == string.Empty || item.SoldierId == "Unlock" || item.SoldierId == "Lock")
				{
					continue;
				}
				list3.Clear();
				if (list.IndexOf(item.SoldierId) >= 0)
				{
					errCode = 81311617;
					return false;
				}
				list.Add(item.SoldierId);
				if (item.LegendItemIds.Count > 2)
				{
					errCode = 81311618;
					return false;
				}
				foreach (long legendItemId in item.LegendItemIds)
				{
					if (list2.IndexOf(legendItemId) >= 0)
					{
						errCode = 81311620;
						return false;
					}
					list2.Add(legendItemId);
					LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(legendItemId);
					if (legendItemUi == null)
					{
						errCode = 81311621;
						return false;
					}
					if (list3.IndexOf(legendItemUi.LegendItemData.ItemId) >= 0)
					{
						errCode = 81311623;
						return false;
					}
					list3.Add(legendItemUi.LegendItemData.ItemId);
				}
			}
		}
		return true;
	}

	private void RefreshCurrentTab()
	{
		RenderSoldiers();
		ShowCurSelectFormation();
		DisplaySeasonBuff();
	}

	private void SyncRankFormationUnits()
	{
		SelectFormations selectFormations = this.selectFormations;
		int teamCount = _teamCount;
		WarOfRealmConfig _battleFormationUnitsConfig = selectFormations.SaveToConfig(teamCount);
		if (!CheckWarOfRealmFormation(_battleFormationUnitsConfig, out var errCode))
		{
			ILRequestHelper.ShowErrorCode(errCode);
			return;
		}
		List<List<string>> list = new List<List<string>>();
		for (int i = 0; i < _battleFormationUnitsConfig.Units.Count; i++)
		{
			List<string> list2 = new List<string>();
			for (int j = 0; j < _battleFormationUnitsConfig.Units[i].Count; j++)
			{
				list2.Add(_battleFormationUnitsConfig.Units[i][j].SoldierId);
			}
			list.Add(list2);
		}
		Action action = delegate
		{
			ILRequestHelper<SetWarOfRealmFormationResponse>.Request((EventContext)null, (Func<Task<SetWarOfRealmFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().SetWarOfRealmFormation(_battleFormationUnitsConfig)), (Action<SetWarOfRealmFormationResponse>)delegate(SetWarOfRealmFormationResponse response)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					GameManagers.Instance.UserArchiveManager.SetWarOfRealmFormationSaved(saved: true);
					if (response.Formation != null)
					{
						this.selectFormations.LoadFromConfig(response.Formation, _teamCount);
					}
					RefreshCurrentTab();
					"PeakBattleFirstTip2".ToLanguage().ToTip();
				}
			});
		};
		ShowPerhapsFailTip(list, teamCount, action);
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

	public SoldierWithLegendItemId GetSoldierInfo(string soldierId)
	{
		if (!_soliderInfoCache.ContainsKey(soldierId))
		{
			SoldierWithLegendItemId soldierWithLegendItemId = new SoldierWithLegendItemId
			{
				SoldierId = soldierId
			};
			soldierWithLegendItemId.DataCheck();
			_soliderInfoCache.Add(soldierId, soldierWithLegendItemId);
		}
		return _soliderInfoCache[soldierId];
	}

	private void DisplaySeasonBuff()
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		BuffConfig buffConfig = RankDataHelper.RankSeasonInfo?.BuffConfig;
		if (buffConfig == null)
		{
			((GObject)Dialog.SeasonBuffLabel).visible = false;
			return;
		}
		string text = null;
		if (!string.IsNullOrEmpty(buffConfig.NormalBuff))
		{
			text = buffConfig.NormalBuff;
		}
		if (string.IsNullOrEmpty(text))
		{
			((GObject)Dialog.SeasonBuffLabel).visible = false;
			return;
		}
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(text);
		if (gDEAbilityData == null)
		{
			((GObject)Dialog.SeasonBuffLabel).visible = false;
			return;
		}
		((GObject)Dialog.SeasonBuffLabel).visible = true;
		Dialog.SeasonBuffLabel.BuffIcon.icon.url = gDEAbilityData.Icon.ToPublicResourcesRgbIcon();
		Dialog.SeasonBuffLabel.BuffIcon.Type.selectedIndex = 0;
		string capturedBuffId = text;
		((GObject)Dialog.SeasonBuffLabel.BuffIcon).onClick.Set((EventCallback1)delegate(EventContext context)
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			context.StopPropagation();
			GDEAbilityData gDEAbilityData2 = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(capturedBuffId);
			if (gDEAbilityData2 != null)
			{
				Vector2 val = ((GObject)GRoot.inst).GlobalToLocal(context.inputEvent.position);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
				{
					{ "Pos", val },
					{ "Data", gDEAbilityData2 },
					{ "Limit", 1 },
					{ "State", true },
					{ "GList", null }
				});
			}
		});
	}
}
