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

public class UI_PeakBattleSelectArrayPanel : GComponent, IUiController
{
	private class SelectFormations
	{
		public Dictionary<string, SelectFormation> Data = new Dictionary<string, SelectFormation>();

		private Dictionary<string, SoldierWithLegendItemId> _soliderInfoCache = new Dictionary<string, SoldierWithLegendItemId>();

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

		public void LoadFromConfig(RankBattleTopTournamentConfig config, int defaultTeamCount = 3)
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
								string soldierId = list[j].SoldierId;
								if (!string.IsNullOrEmpty(soldierId) && soldierId != "Unlock" && soldierId != "Lock")
								{
									selectFormation.LegendItemIds.Add(soldierId, list[j].LegendItemIds);
								}
								selectFormation.SoldiersId.Add(soldierId);
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
			InitSoldierInfoCache();
		}

		private void InitSoldierInfoCache()
		{
			_soliderInfoCache.Clear();
			foreach (KeyValuePair<string, SelectFormation> datum in Data)
			{
				if (datum.Value.LegendItemIds == null)
				{
					continue;
				}
				foreach (KeyValuePair<string, List<long>> legendItemId in datum.Value.LegendItemIds)
				{
					string key = legendItemId.Key;
					if (!string.IsNullOrEmpty(key) && !(key == "Unlock") && !(key == "Lock") && !_soliderInfoCache.ContainsKey(key))
					{
						SoldierWithLegendItemId value = new SoldierWithLegendItemId
						{
							SoldierId = key,
							LegendItemIds = new List<long>(legendItemId.Value)
						};
						_soliderInfoCache[key] = value;
					}
				}
			}
		}

		public RankBattleTopTournamentConfig SaveToConfig(int teamCount)
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
				List<SoldierWithLegendItemId> list4 = new List<SoldierWithLegendItemId>();
				bool flag = true;
				for (int j = 0; j < list[i].SoldiersId.Count; j++)
				{
					SoldierWithLegendItemId soldierWithLegendItemId = new SoldierWithLegendItemId();
					string text = list[i].SoldiersId[j];
					soldierWithLegendItemId.SoldierId = ((string.IsNullOrEmpty(text) || text == "Unlock" || text == "Lock") ? string.Empty : text);
					if (soldierWithLegendItemId.SoldierId != null)
					{
						flag = false;
					}
					List<long> list5 = new List<long>();
					if (!string.IsNullOrEmpty(soldierWithLegendItemId.SoldierId) && soldierWithLegendItemId.SoldierId != "Unlock" && soldierWithLegendItemId.SoldierId != "Lock")
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
				if (flag)
				{
					list2.Add(string.Empty);
				}
				else
				{
					list2.Add(list[i].FormationId);
				}
				list3.Add(list4);
				num++;
			}
			return new RankBattleTopTournamentConfig
			{
				FormationsId = list2,
				_UnitsData = list3,
				_Units = JsonHelper.ToJson(list3)
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

	public GGraph Mask;

	public UI_SelectPeakBattleArrayDialog Dialog;

	public const string URL = "ui://82mo10n5x1jlddj";

	public static string Name = "UI_PeakBattleSelectArrayPanel";

	public static UI_PeakBattleSelectArrayPanel PeakBattleSelectArrayPanel;

	private int _currentTabType = 0;

	private SelectFormations dailySelectFormations = new SelectFormations();

	private SelectFormations weekendSelectFormations = new SelectFormations();

	private List<Formation> unlockFormations = new List<Formation>();

	private List<string> dailySelectedSoldierId = new List<string>();

	private List<string> weekendSelectedSoldierId = new List<string>();

	public List<string> selectedSoldierId;

	private string curSelectFormationArrayId;

	private int curSoldierIndex;

	private string curTouchArrayId;

	private float curTouchFormationBtnY;

	private int curTouchBtnIndex;

	private bool isMouseMoving = false;

	private SelectFormations CurrentFormations => (_currentTabType == 1) ? weekendSelectFormations : dailySelectFormations;

	private int ArrayNum => (_currentTabType == 1) ? 4 : 3;

	private bool IsWeekend => _currentTabType == 1;

	public static string GetURL()
	{
		return "ui://82mo10n5x1jlddj";
	}

	public static UI_PeakBattleSelectArrayPanel CreateInstance()
	{
		return (UI_PeakBattleSelectArrayPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PeakBattleSelectArrayPanel");
	}

	public static UI_PeakBattleSelectArrayPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PeakBattleSelectArrayPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jlddj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		InitTabs();
		GetAllUnlockFormations();
	}

	private void InitTabs()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		if (!RankDataHelper.IsServerWideBattle)
		{
			SwitchToTab(2);
			return;
		}
		((GObject)Dialog.DailyTab).onClick.Set((EventCallback0)delegate
		{
			SwitchToTab(0);
		});
		((GObject)Dialog.WeekendTab).onClick.Set((EventCallback0)delegate
		{
			SwitchToTab(1);
		});
		SwitchToTab(0);
	}

	private void SwitchToTab(int tabType)
	{
		_currentTabType = tabType;
		Dialog.TabType.selectedIndex = tabType;
		((GButton)Dialog.DailyTab).selected = tabType == 0;
		((GButton)Dialog.WeekendTab).selected = tabType == 1;
		selectedSoldierId = ((tabType == 1) ? weekendSelectedSoldierId : dailySelectedSoldierId);
		RefreshCurrentTab();
	}

	private void RefreshCurrentTab()
	{
		RenderSoldiers();
		ShowCurSelectFormation();
		DisplayInTopTournamentText();
		DisplaySeasonBuff();
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(OnCloseButtonClick));
		((GObject)Dialog.SoldiersSwitch).onClick.Add(new EventCallback0(ChangeSoldiersStatus));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(SyncRankFormationUnits));
		((GObject)Dialog.exitBtn).onClick.Add(new EventCallback0(OnCloseButtonClick));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(OnCloseButtonClick));
		((GObject)Dialog.SoldiersSwitch).onClick.Remove(new EventCallback0(ChangeSoldiersStatus));
		((GObject)Dialog.ConfirmBtn).onClick.Remove(new EventCallback0(SyncRankFormationUnits));
		((GObject)Dialog.exitBtn).onClick.Remove(new EventCallback0(OnCloseButtonClick));
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", Dialog.FormationSketchMap.OnCampClose);
	}

	private void OnCloseButtonClick()
	{
		bool flag = HasEmptySlotInFormation(dailySelectFormations);
		bool flag2 = false;
		if (RankDataHelper.IsServerWideBattle)
		{
			flag2 = HasEmptySlotInFormation(weekendSelectFormations);
		}
		if (flag || flag2)
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

	private bool HasEmptySlotInFormation(SelectFormations formations, bool allowLastTeamEmpty = false)
	{
		if (formations?.Data == null)
		{
			return true;
		}
		List<KeyValuePair<string, SelectFormation>> list = formations.Data.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			if (allowLastTeamEmpty && i == list.Count - 1)
			{
				continue;
			}
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
		int arrayNum = ArrayNum;
		Dialog.Soliders.itemRenderer = new ListItemRenderer(RenderSoldierItem);
		Dialog.Soliders.numItems = arrayNum;
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
		SelectFormations currentFormations = CurrentFormations;
		List<KeyValuePair<string, SelectFormation>> list = currentFormations.Data.ToList();
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
		SelectFormations currentFormations = CurrentFormations;
		List<string> soldiersId = currentFormations.Data[text].SoldiersId;
		for (int num2 = selectedSoldierId.Count - 1; num2 >= 0; num2--)
		{
			if (soldiersId.Contains(selectedSoldierId[num2]))
			{
				selectedSoldierId.RemoveAt(num2);
			}
		}
		currentFormations.Data[text].ClearData();
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
				SelectFormations currentFormations = CurrentFormations;
				UI_BattleArray uI_BattleArray = touchTarget.parent as UI_BattleArray;
				float y = ((GObject)uI_BattleArray).y;
				string text = ((GObject)uI_BattleArray).data.ToString();
				int childIndex = ((GComponent)Dialog.Soliders).GetChildIndex((GObject)(object)uI_BattleArray);
				string formationId = currentFormations.Data[text].FormationId;
				List<string> soldiersId = currentFormations.Data[text].SoldiersId;
				Dictionary<string, List<long>> legendItemIds = currentFormations.Data[text].LegendItemIds;
				UI_BattleArray uI_BattleArray2 = ((GComponent)Dialog.Soliders).GetChildAt(curTouchBtnIndex) as UI_BattleArray;
				((GObject)uI_BattleArray2).y = y;
				((GObject)uI_BattleArray2).data = text;
				((GObject)uI_BattleArray2.ArrayIndex).data = childIndex;
				((GObject)uI_BattleArray2.clearBtn).data = childIndex;
				((GObject)uI_BattleArray2.ArrayIndex.indexText).text = $"{childIndex + 1}";
				GGraph selectFormation = uI_BattleArray2.SelectFormation;
				((GObject)selectFormation).name = ((GObject)selectFormation).name + $"{childIndex + 1}";
				((GComponent)Dialog.Soliders).SetChildIndex((GObject)(object)uI_BattleArray2, childIndex);
				currentFormations.Data[text].FormationId = currentFormations.Data[curTouchArrayId].FormationId;
				currentFormations.Data[text].SoldiersId = currentFormations.Data[curTouchArrayId].SoldiersId;
				currentFormations.Data[text].LegendItemIds = currentFormations.Data[curTouchArrayId].LegendItemIds;
				((GObject)uI_BattleArray).y = curTouchFormationBtnY;
				((GObject)uI_BattleArray).data = curTouchArrayId;
				((GObject)uI_BattleArray.ArrayIndex).data = curTouchBtnIndex;
				((GObject)uI_BattleArray.clearBtn).data = curTouchBtnIndex;
				((GObject)uI_BattleArray.ArrayIndex.indexText).text = $"{curTouchBtnIndex + 1}";
				GGraph selectFormation2 = uI_BattleArray.SelectFormation;
				((GObject)selectFormation2).name = ((GObject)selectFormation2).name + $"{curTouchBtnIndex + 1}";
				((GComponent)Dialog.Soliders).SetChildIndex((GObject)(object)uI_BattleArray, curTouchBtnIndex);
				currentFormations.Data[curTouchArrayId].FormationId = formationId;
				currentFormations.Data[curTouchArrayId].SoldiersId = soldiersId;
				currentFormations.Data[curTouchArrayId].LegendItemIds = legendItemIds;
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
		SelectFormations currentFormations = CurrentFormations;
		if (!currentFormations.Data.ContainsKey(arrayId))
		{
			return;
		}
		for (int i = 0; i < currentFormations.Data[arrayId].SoldiersId.Count; i++)
		{
			string text = currentFormations.Data[arrayId].SoldiersId[i];
			if (!string.IsNullOrEmpty(text) && text != "Unlock" && text != "Lock")
			{
				string soldierId = currentFormations.Data[arrayId].SoldiersId[i];
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
		SelectFormations currentFormations = CurrentFormations;
		currentFormations.WearLegendItem(curSelectFormationArrayId, soldierId, slot, legendItemId);
		Dialog.FormationSketchMap.SetOurPos(currentFormations.Data[curSelectFormationArrayId.ToString()].FormationId, currentFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, currentFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
		SoldierWithLegendItemId soldierInfo = currentFormations.GetSoldierInfo(soldierId);
		soldierInfo.LegendItemIds[slot] = legendItemId;
	}

	public void UpdateOnTakeOffLegendItem(string soldierId, int slot)
	{
		SelectFormations currentFormations = CurrentFormations;
		currentFormations.TakeOffLegendItem(curSelectFormationArrayId, soldierId, slot);
		Dialog.FormationSketchMap.SetOurPos(currentFormations.Data[curSelectFormationArrayId.ToString()].FormationId, currentFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, currentFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
		SoldierWithLegendItemId soldierInfo = currentFormations.GetSoldierInfo(soldierId);
		soldierInfo.LegendItemIds[slot] = 0L;
	}

	private void ShowCurSelectFormation(string _arrayId = "")
	{
		SelectFormations currentFormations = CurrentFormations;
		curSelectFormationArrayId = (string.IsNullOrEmpty(_arrayId) ? currentFormations.Data.ToList().First().Key : _arrayId);
		Dialog.FormationSketchMap.SetOurPos(currentFormations.Data[curSelectFormationArrayId.ToString()].FormationId, currentFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, currentFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
		Dialog.n52.CurFormationInit(currentFormations.Data[curSelectFormationArrayId].FormationId);
	}

	public void UpdateSomeSoldierBtn(int _index, string _sid)
	{
		SelectFormations currentFormations = CurrentFormations;
		Dictionary<string, SelectFormation> data = currentFormations.Data;
		SelectFormation selectFormation = data[curSelectFormationArrayId.ToString()];
		List<string> soldiersId = selectFormation.SoldiersId;
		soldiersId[_index] = _sid;
		if (!selectFormation.LegendItemIds.ContainsKey(_sid))
		{
			List<long> legendItemIds = currentFormations.GetSoldierInfo(_sid).LegendItemIds;
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
			SelectFormations currentFormations = CurrentFormations;
			RenderCurFormation(uI_CurFormation.MainFormation, currentFormations.Data[curSelectFormationArrayId.ToString()].FormationId);
		}
		context.StopPropagation();
	}

	public void UpdateCurSelectFormation(string _fid)
	{
		SelectFormations currentFormations = CurrentFormations;
		if (currentFormations.Data.ContainsKey(curSelectFormationArrayId))
		{
			currentFormations.Data[curSelectFormationArrayId].FormationId = _fid;
			Dialog.FormationSketchMap.SetOurPos(currentFormations.Data[curSelectFormationArrayId].FormationId, currentFormations.Data[curSelectFormationArrayId].SoldiersId, selectedSoldierId, currentFormations.Data[curSelectFormationArrayId].LegendItemIds);
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
			SelectFormations currentFormations = CurrentFormations;
			if (currentFormations.Data.ContainsKey(curSelectFormationArrayId.ToString()))
			{
				currentFormations.Data[curSelectFormationArrayId.ToString()].FormationId = text;
				Dialog.FormationSketchMap.SetOurPos(currentFormations.Data[curSelectFormationArrayId.ToString()].FormationId, currentFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId, currentFormations.Data[curSelectFormationArrayId.ToString()].LegendItemIds);
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
		if (parameters.TryGetValue("FormationResponse", out var value) && value is GetPvPTopTournamentFormationResponse getPvPTopTournamentFormationResponse)
		{
			dailySelectFormations.LoadFromConfig(getPvPTopTournamentFormationResponse.CurFormation);
			weekendSelectFormations.LoadFromConfig(getPvPTopTournamentFormationResponse.WeekendFormation, 4);
		}
		else
		{
			dailySelectFormations.CheckValid(3);
			weekendSelectFormations.CheckValid(4);
		}
		dailySelectedSoldierId.Clear();
		CollectSelectedSoldierIds(dailySelectFormations, dailySelectedSoldierId);
		weekendSelectedSoldierId.Clear();
		CollectSelectedSoldierIds(weekendSelectFormations, weekendSelectedSoldierId);
		selectedSoldierId = dailySelectedSoldierId;
	}

	private void CollectSelectedSoldierIds(SelectFormations formations, List<string> targetList = null)
	{
		if (formations?.Data == null)
		{
			return;
		}
		List<string> list = targetList ?? selectedSoldierId;
		foreach (KeyValuePair<string, SelectFormation> datum in formations.Data)
		{
			for (int i = 0; i < datum.Value.SoldiersId.Count; i++)
			{
				string text = datum.Value.SoldiersId[i];
				if (!string.IsNullOrEmpty(text) && text != "Lock" && text != "Unlock" && !list.Contains(text))
				{
					list.Add(text);
				}
			}
		}
	}

	private bool CheckPvPTopTournamentFormation(RankBattleTopTournamentConfig formation, out int errCode)
	{
		int arrayNum = ArrayNum;
		List<string> list = new List<string>();
		List<long> list2 = new List<long>();
		List<string> list3 = new List<string>();
		errCode = 0;
		if (formation.FormationsId.Count != arrayNum)
		{
			errCode = 80000100;
			return false;
		}
		if (formation.Units.Count != arrayNum)
		{
			errCode = 80000101;
			return false;
		}
		foreach (List<SoldierWithLegendItemId> unit in formation.Units)
		{
			if (unit.Count > 5)
			{
				errCode = 80000102;
				return false;
			}
			if (unit.Count == 0)
			{
				errCode = 80000108;
				return false;
			}
			foreach (SoldierWithLegendItemId item in unit)
			{
				if (string.IsNullOrEmpty(item.SoldierId) || item.SoldierId == "Unlock" || item.SoldierId == "Lock")
				{
					continue;
				}
				list3.Clear();
				if (list.IndexOf(item.SoldierId) >= 0)
				{
					errCode = 80000103;
					return false;
				}
				list.Add(item.SoldierId);
				if (item.LegendItemIds.Count > 2)
				{
					errCode = 80000107;
					return false;
				}
				foreach (long legendItemId in item.LegendItemIds)
				{
					if (list2.IndexOf(legendItemId) >= 0)
					{
						errCode = 80000104;
						return false;
					}
					list2.Add(legendItemId);
					LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(legendItemId);
					if (legendItemUi == null)
					{
						errCode = 80000105;
						return false;
					}
					if (list3.IndexOf(legendItemUi.LegendItemData.ItemId) >= 0)
					{
						errCode = 80000106;
						return false;
					}
					list3.Add(legendItemUi.LegendItemData.ItemId);
				}
			}
		}
		return true;
	}

	private void SyncRankFormationUnits()
	{
		SelectFormations currentFormations = CurrentFormations;
		bool isWeekend = IsWeekend;
		int arrayNum = ArrayNum;
		RankBattleTopTournamentConfig _battleFormationUnitsConfig = currentFormations.SaveToConfig(arrayNum);
		if (!CheckPvPTopTournamentFormation(_battleFormationUnitsConfig, out var errCode))
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
			ILRequestHelper<SetPvPTopTournamentFormationResponse>.Request((EventContext)null, (Func<Task<SetPvPTopTournamentFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().SetPvPTopTournamentFormation(_battleFormationUnitsConfig, isWeekend)), (Action<SetPvPTopTournamentFormationResponse>)delegate(SetPvPTopTournamentFormationResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					if (!isWeekend)
					{
						dailySelectFormations.LoadFromConfig(response.CurFormation);
					}
					else
					{
						weekendSelectFormations.LoadFromConfig(response.WeekendFormation, 4);
					}
					RefreshCurrentTab();
					"PeakBattleFirstTip2".ToLanguage().ToTip();
				}
			});
		};
		ShowPerhapsFailTip(list, arrayNum, action, isWeekend);
	}

	private void ShowPerhapsFailTip(List<List<string>> unitsId, int myLegionSize, Action action, bool allowLastTeamEmpty = false)
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
				}
			}
			if (allowLastTeamEmpty && i == myLegionSize - 1)
			{
				if (num == 0 || num == unitsId[i].Count)
				{
					num = 0;
					continue;
				}
				flag2 = true;
				if (!needShakeArrayBtnIndex.Contains(i))
				{
					needShakeArrayBtnIndex.Add(i);
				}
				num = 0;
				continue;
			}
			if (num > 0)
			{
				flag2 = true;
				if (!needShakeArrayBtnIndex.Contains(i))
				{
					needShakeArrayBtnIndex.Add(i);
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
		return CurrentFormations.GetSoldierInfo(soldierId);
	}

	private void DisplayInTopTournamentText()
	{
		Dialog.IsInTopTournament.SetSelectedIndex(RankDataHelper.IsInTopTournament ? 1 : 0);
	}

	private void DisplaySeasonBuff()
	{
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		if (!RankDataHelper.IsServerWideBattle)
		{
			((GObject)Dialog.SeasonBuffLabel).visible = false;
			return;
		}
		BuffConfig buffConfig = RankDataHelper.RankSeasonInfo?.BuffConfig;
		if (buffConfig == null)
		{
			((GObject)Dialog.SeasonBuffLabel).visible = false;
			return;
		}
		string text = null;
		bool isWeekend = IsWeekend;
		if (isWeekend && buffConfig.WeekendBuff != null && buffConfig.WeekendBuff.Count > 0)
		{
			int result = 0;
			if (!string.IsNullOrEmpty(curSelectFormationArrayId))
			{
				int.TryParse(curSelectFormationArrayId, out result);
			}
			result = Mathf.Clamp(result, 0, buffConfig.WeekendBuff.Count - 1);
			text = buffConfig.WeekendBuff[result];
		}
		else if (!isWeekend && !string.IsNullOrEmpty(buffConfig.WeekDayBuff))
		{
			text = buffConfig.WeekDayBuff;
		}
		else if (!string.IsNullOrEmpty(buffConfig.NormalBuff))
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
