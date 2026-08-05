using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.EnemyIntroduction;
using UI.LegendItemInfo;
using UI.Legion;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_EnemyStandardFormationSketchMap : GComponent
{
	public UI_PvpFormationBack Background;

	public UI_SoldierFormation OurFormation0;

	public UI_SoldierFormation OurFormation1;

	public UI_SoldierFormation OurFormation2;

	public UI_SoldierFormation OurFormation3;

	public UI_SoldierFormation OurFormation4;

	public UI_SoldierFormation OurFormation5;

	public UI_SoldierFormation OurFormation6;

	public UI_SoldierFormation OurFormation7;

	public UI_SoldierFormation OurFormation8;

	public UI_SoldierIconOnTouch DraggingIcon;

	public const string URL = "ui://82mo10n5gwv06f";

	public static string Name = "UI_EnemyStandardFormationSketchMap";

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<string> _curSoldiers = new List<string>();

	private List<SoldierDetail> _soldiersDetail = null;

	private List<string> _curSelectedSoldiers = new List<string>();

	private List<GameEntityData> _units;

	private List<int> _unitsTotal;

	public Dictionary<string, List<RankSoldierEquipmentsInfo>> _soldierEquipments = new Dictionary<string, List<RankSoldierEquipmentsInfo>>();

	private int _curSelectedIndex;

	private string curTouchBlockSid;

	private bool isMouseMoving = false;

	public static string GetURL()
	{
		return "ui://82mo10n5gwv06f";
	}

	public static UI_EnemyStandardFormationSketchMap CreateInstance()
	{
		return (UI_EnemyStandardFormationSketchMap)(object)UIPackage.CreateObject("PvpSelectSoldiers", "EnemyStandardFormationSketchMap");
	}

	public static UI_EnemyStandardFormationSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyStandardFormationSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gwv06f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		Background = (UI_PvpFormationBack)(object)((GComponent)this).GetChild("Background");
		OurFormation0 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation0");
		OurFormation1 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation1");
		OurFormation2 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation2");
		OurFormation3 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation3");
		OurFormation4 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation4");
		OurFormation5 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation5");
		OurFormation6 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation6");
		OurFormation7 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation7");
		OurFormation8 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation8");
		DraggingIcon = (UI_SoldierIconOnTouch)(object)((GComponent)this).GetChild("DraggingIcon");
	}

	private void FormationsInit()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		if (ourFormations.Count >= 9)
		{
			return;
		}
		ourFormations.Clear();
		float num = 0.05f;
		for (int i = 0; i < 9; i++)
		{
			UI_SoldierFormation _redBtn = (UI_SoldierFormation)(object)((GComponent)this).GetChild($"OurFormation{i}");
			ourVector2s.Add(((GObject)_redBtn).xy);
			ourFormations.Add(_redBtn);
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				((GObject)_redBtn).TweenFade(1f, 0.1f);
			});
			num += 0.05f;
		}
	}

	public void SetOurFormations(List<string> _curSoldiers)
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		((GObject)this).touchable = true;
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		bool flag = _units != null && _units.Count > 0;
		int count = _curSoldiers.Count;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			if (i <= count - 1)
			{
				string text = _curSoldiers[i];
				if (!string.IsNullOrWhiteSpace(text) && text != "Unlock" && text != "Lock")
				{
					Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
					ourFormations[i].Type.selectedIndex = 0;
					int num2 = (flag ? _unitsTotal[i] : GameManagers.Instance.StockController.GetStock(text));
					int level = (flag ? _units[i].Level : GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text));
					int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, level);
					int potentialLevel = (flag ? _units[i].PotentialLevel : GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(text));
					num++;
					ourFormations[i].num.color = ((num2 < soldierFormationNumber) ? Color.red : Color.white);
					ourFormations[i].num.strokeColor = ((num2 < soldierFormationNumber) ? Color.white : Color.gray);
					((GObject)ourFormations[i].num).text = $"{num2}/{soldierFormationNumber}";
					RenderSoldierItem(text, level, potentialLevel, ourFormations[i].Icon);
					((GObject)ourFormations[i].Icon).visible = true;
					((GObject)ourFormations[i].n7).visible = true;
					((GObject)ourFormations[i].num).visible = true;
					if (_soldiersDetail != null)
					{
						SoldierDetail soldierDetail = _soldiersDetail[i];
						((GObject)ourFormations[i].Icon).onClick.Set((EventCallback0)delegate
						{
							OpenSoldierDetail(soldierDetail);
						});
					}
				}
				else
				{
					ourFormations[i].Type.selectedIndex = 0;
					((GObject)ourFormations[i].Icon).visible = false;
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
				}
				((GObject)ourFormations[i]).data = i;
			}
			else
			{
				((GObject)ourFormations[i]).data = i;
				ourFormations[i].Type.selectedIndex = 1;
			}
		}
	}

	private void OpenSoldierDetail(SoldierDetail soldierDetail)
	{
		string soldierId = soldierDetail.SoldierId;
		string text = soldierDetail.SoldierId;
		string text2 = GDMgr.Get<GDESoldierData>(text)?.ParentSoldierId;
		if (!string.IsNullOrEmpty(text2))
		{
			text = text2;
		}
		FakeSoldier value = new FakeSoldier(text, soldierDetail.Level, soldierDetail.EvoLevel, soldierDetail.PotentialLevel);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
		{
			{ "SoldierId", soldierId },
			{ "FakeSoldierData", value },
			{ "Num", soldierDetail.Num },
			{ "CombatPower", soldierDetail.CombatPower },
			{ "ATK", soldierDetail.Atk },
			{ "DEF", soldierDetail.Def },
			{ "HP", soldierDetail.Hp },
			{ "LegendItemBrief", soldierDetail.LegendItems }
		});
	}

	private void RenderSoldierItem(string soldierId, int level, int potentialLevel, UI_soliderItem btn)
	{
		((GObject)btn).touchable = true;
		string iconPath = UiHelper.GetIconPath(soldierId, PotentialToItemLevel(potentialLevel));
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = level.ToString();
		int num = (potentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(potentialLevel);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(potentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, potentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, potentialLevel, null);
		RenderLegendItems(soldierId, (GButton)(object)btn);
	}

	private static int PotentialToItemLevel(int potentialLevel)
	{
		int soldierMaxEvoLevel = GameManagers.Instance.UserArchiveManager.GetSoldierMaxEvoLevel();
		int num = (potentialLevel + 2) / 2;
		if (potentialLevel == 9)
		{
			num = 6;
		}
		if (num < 1)
		{
			num = 1;
		}
		else if (num > soldierMaxEvoLevel)
		{
			num = soldierMaxEvoLevel;
		}
		return num;
	}

	private void RenderLegendItems(string soldierId, GButton button)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		if (_soldierEquipments == null || !_soldierEquipments.ContainsKey(soldierId))
		{
			return;
		}
		List<RankSoldierEquipmentsInfo> list = _soldierEquipments[soldierId];
		bool flag = false;
		if (list == null || list.Count <= 0)
		{
			flag = false;
		}
		else
		{
			for (int i = 0; i < 2; i++)
			{
				((GComponent)button).GetChild($"legendItem{i}").visible = false;
				((GComponent)button).GetChild($"legendItem{i}").scaleY = 0.35f;
				((GComponent)button).GetChild($"legendItem{i}").scaleX = 0.35f;
			}
			int num = 0;
			for (int j = 0; j < list.Count; j++)
			{
				if (num >= 2)
				{
					break;
				}
				GButton asButton = ((GComponent)button).GetChild($"legendItem{num}").asButton;
				((GObject)asButton).visible = true;
				((GObject)asButton).scaleY = 0.35f;
				((GObject)asButton).scaleX = 0.35f;
				UiHelper.RenderRankLegendItem(asButton, list[j], UiHelper.TextColorType.Light, null, 2);
				((GObject)asButton).data = list[j];
				((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendPanel));
				num++;
			}
			for (int k = 0; k < 2; k++)
			{
				GButton asButton2 = ((GComponent)button).GetChild($"legendItem{k}").asButton;
				if (((GObject)asButton2).visible)
				{
					break;
				}
				if (k == 1)
				{
					flag = true;
				}
			}
		}
		((GComponent)button).GetChild("LegendItems").visible = !flag;
	}

	private void OpenLegendPanel(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		RankSoldierEquipmentsInfo rankSoldierEquipmentsInfo = (RankSoldierEquipmentsInfo)((GObject)context.sender).data;
		if (rankSoldierEquipmentsInfo.ItemBrief != null)
		{
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(null, "", -1, 3, null, rankSoldierEquipmentsInfo.ItemBrief);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
		}
	}

	private void ShowOurIcons()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		float delay = 0.05f;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			UI_SoldierFormation uI_SoldierFormation = ourFormations[i];
			((GObject)uI_SoldierFormation.Icon).alpha = 0f;
		}
		((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			for (int j = 0; j < ourFormations.Count; j++)
			{
				UI_SoldierFormation _btn = ourFormations[j];
				((GComponent)(object)this).SetTimeout(delay).OnComplete((GTweenCallback)delegate
				{
					_btn.ShowInfo.Play();
				});
				delay += 0.05f;
			}
		});
	}

	public void SetOurPos(string fid, List<string> _curSoldiers, List<string> selectedSoldiers, List<GameEntityData> _units = null, List<int> _unitsTotal = null, Dictionary<string, List<RankSoldierEquipmentsInfo>> _soldierEquipments = null, List<SoldierDetail> soldiersDetail = null)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		FormationsInit();
		this._units = _units;
		this._curSoldiers = _curSoldiers;
		this._unitsTotal = _unitsTotal;
		_curSelectedSoldiers = selectedSoldiers;
		this._soldierEquipments = _soldierEquipments;
		_soldiersDetail = soldiersDetail;
		if (string.IsNullOrWhiteSpace(fid))
		{
			for (int i = 0; i < ourFormations.Count; i++)
			{
				ourFormations[i].Type.selectedIndex = 1;
			}
			return;
		}
		Formation formation = FormationManager.Formations[fid];
		Dictionary<string, Vector2> dictionary = new Dictionary<string, Vector2>
		{
			{
				"8.3_3.4",
				ourVector2s[8]
			},
			{
				"8.3_0",
				ourVector2s[4]
			},
			{
				"8.3_-3.4",
				ourVector2s[6]
			},
			{
				"4.9_3.4",
				ourVector2s[1]
			},
			{
				"4.9_0",
				ourVector2s[3]
			},
			{
				"4.9_-3.4",
				ourVector2s[2]
			},
			{
				"1.5_3.4",
				ourVector2s[7]
			},
			{
				"1.5_0",
				ourVector2s[0]
			},
			{
				"1.5_-3.4",
				ourVector2s[5]
			}
		};
		for (int j = 0; j < 5; j++)
		{
			if (formation.SlotPosition.ContainsKey(j))
			{
				string key = $"{formation.SlotPosition[j].x}_{formation.SlotPosition[j].y}";
				if (dictionary.ContainsKey(key))
				{
					((GObject)ourFormations[j]).xy = dictionary[key];
					dictionary.Remove(key);
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		foreach (KeyValuePair<string, Vector2> item in dictionary)
		{
			list.Add(item.Value);
		}
		for (int k = 5; k < ourFormations.Count; k++)
		{
			((GObject)ourFormations[k]).xy = list[k - 5];
		}
		GetMySoldiersCombatPower();
		SetOurFormations(_curSoldiers);
		ShowOurIcons();
	}

	private List<string> GetSoldierFilter()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < _curSoldiers.Count; i++)
		{
			list.Add(_curSoldiers[i]);
		}
		for (int j = 0; j < _curSelectedSoldiers.Count; j++)
		{
			list2.Add(_curSelectedSoldiers[j]);
		}
		for (int num = list2.Count - 1; num >= 0; num--)
		{
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (list2[num] == list[num2])
				{
					list2.RemoveAt(num);
					list.RemoveAt(num2);
					break;
				}
			}
		}
		return list2;
	}

	private void OpenLegionPanel(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		_curSelectedIndex = (int)((GObject)context.sender).data;
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Style", "7" },
			{
				"PvpSoldiersFilter",
				GetSoldierFilter()
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	public void OnCampClose(EventContext eventContext, string soldierId, int chosenType)
	{
		if (chosenType == 7 && !(_curSoldiers[_curSelectedIndex] == soldierId))
		{
			if (string.IsNullOrEmpty(soldierId) || soldierId == "Lock" || soldierId == "Unlock")
			{
				string sid = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = soldierId;
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSomeEnemyBtn(_curSelectedIndex, soldierId);
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSelectedEnemySoldierId(sid, isAdd: false);
			}
			else if (!_curSoldiers.Contains(soldierId))
			{
				string sid2 = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = soldierId;
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSomeEnemyBtn(_curSelectedIndex, soldierId);
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSelectedEnemySoldierId(sid2, isAdd: false);
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSelectedEnemySoldierId(soldierId, isAdd: true);
			}
			else
			{
				int index = _curSoldiers.IndexOf(soldierId);
				string text = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = soldierId;
				_curSoldiers[index] = text;
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSomeEnemyBtn(_curSelectedIndex, soldierId);
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSomeEnemyBtn(index, text);
			}
			_curSelectedSoldiers = UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.selectedEnemySoldierId;
			GetMySoldiersCombatPower();
			SetOurFormations(_curSoldiers);
			ShowOurIcons();
		}
	}

	private void SoldierIconFade()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		((GObject)DraggingIcon).alpha = 0f;
		((GObject)DraggingIcon).xy = new Vector2(10000f, 10000f);
	}

	private void SoldierIconInit(Vector2 posVector2)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		string iconPath = UiHelper.GetIconPath(curTouchBlockSid);
		if (!string.IsNullOrWhiteSpace(iconPath))
		{
			((GObject)((GComponent)DraggingIcon).GetChild("SoulStoneLevel").asCom).alpha = 1f;
			((GComponent)DraggingIcon).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(curTouchBlockSid);
			((GObject)DraggingIcon).xy = posVector2;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(curTouchBlockSid);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)DraggingIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)DraggingIcon).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)DraggingIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
		}
	}

	public void OnBlockTouchBegin(EventContext context)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		isMouseMoving = false;
		_curSelectedIndex = -1;
		curTouchBlockSid = "";
		_curSelectedIndex = (int)((GObject)context.sender).data;
		string text = _curSoldiers[_curSelectedIndex];
		if (!string.IsNullOrEmpty(text) && !(text == "Lock") && !(text == "Unlock"))
		{
			GObject touchTarget = GRoot.inst.touchTarget;
			if (touchTarget.name.Contains("OurFormation"))
			{
				curTouchBlockSid = text;
				SoldierIconInit(((GObject)touchTarget.parent).xy);
			}
		}
	}

	public void OnBlockTouchMove(EventContext context)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		isMouseMoving = true;
		if (_curSelectedIndex != -1)
		{
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
			val = ((GObject)this).GlobalToLocal(val);
			((GObject)DraggingIcon).xy = val;
			((GObject)DraggingIcon).alpha = 1f;
		}
	}

	public void OnBlockTouchEnd(EventContext context)
	{
		SoldierIconFade();
		GObject touchTarget = GRoot.inst.touchTarget;
		if (!isMouseMoving)
		{
			return;
		}
		isMouseMoving = false;
		if (touchTarget != null && touchTarget.name.Contains("OurFormation") && _curSelectedIndex != -1)
		{
			int num = (int)touchTarget.data;
			if (num <= _curSoldiers.Count - 1)
			{
				string text = _curSoldiers[num];
				string text2 = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = text;
				_curSoldiers[num] = text2;
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSomeEnemyBtn(_curSelectedIndex, text);
				UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel?.UpdateSomeEnemyBtn(num, text2);
				GetMySoldiersCombatPower();
				SetOurFormations(_curSoldiers);
				ShowOurIcons();
			}
		}
	}

	private void GetMySoldiersCombatPower()
	{
		int num = 0;
		bool flag = _units != null && _units.Count > 0;
		int count = _curSoldiers.Count;
		for (int i = 0; i < count; i++)
		{
			string text = _curSoldiers[i];
			if (!string.IsNullOrEmpty(text) && !(text == "Lock") && !(text == "Unlock"))
			{
				if (flag)
				{
					num += _units[i].CombatPower * _unitsTotal[i];
					continue;
				}
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldier.Level);
				num += soldier.CombatPower * soldierFormationNumber;
			}
		}
		((GObject)UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel.EnemyCombat).text = num.ToString();
	}

	public void AllDisappear()
	{
		for (int i = 0; i < ourFormations.Count; i++)
		{
			ourFormations[i].Disappear.Play();
		}
	}
}
