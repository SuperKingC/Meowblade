using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.LegendItems;
using UI.Legion;
using UnityEngine;

namespace UI.LegendItemDungeon;

public class UI_PeakBattleSketchMap : GComponent
{
	private class SoldierLegendItemInfo
	{
		public int Slot { get; set; }

		public string SoldierId { get; set; }

		public long ItemId { get; set; }
	}

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

	public const string URL = "ui://2eraz3j9ldt61z";

	public static string Name = "UI_PeakBattleSketchMap";

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<string> _curSoldiers = new List<string>();

	private Dictionary<string, List<long>> _legendItemIds = new Dictionary<string, List<long>>();

	private List<string> _curSelectedSoldiers = new List<string>();

	private int _curSelectedIndex;

	private Dictionary<string, int> DungeonSoldiers;

	private string curTouchBlockSid;

	private bool isMouseMoving = false;

	private List<int> needShakeBtns = new List<int>();

	public static string GetURL()
	{
		return "ui://2eraz3j9ldt61z";
	}

	public static UI_PeakBattleSketchMap CreateInstance()
	{
		return (UI_PeakBattleSketchMap)(object)UIPackage.CreateObject("LegendItemDungeon", "PeakBattleSketchMap");
	}

	public static UI_PeakBattleSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PeakBattleSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9ldt61z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
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
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		needShakeBtns.Clear();
		for (int i = 0; i < ourFormations.Count; i++)
		{
			((GObject)ourFormations[i].Icon).grayed = false;
			((GObject)ourFormations[i].Icon).touchable = true;
			if (i <= _curSoldiers.Count - 1)
			{
				string text = _curSoldiers[i];
				if (!string.IsNullOrWhiteSpace(text) && text != "Unlock" && text != "Lock")
				{
					Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
					ourFormations[i].Type.selectedIndex = 0;
					num++;
					RenderSoldierItem(soldier, ourFormations[i].Icon);
					((GObject)ourFormations[i].Icon).alpha = 1f;
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
					((GObject)ourFormations[i].Icon).grayed = !DungeonSoldiers.ContainsKey(text);
				}
				else
				{
					if (string.IsNullOrEmpty(text) || text == "Lock")
					{
						((GObject)ourFormations[i].Icon).touchable = false;
					}
					needShakeBtns.Add(i);
					ourFormations[i].Type.selectedIndex = 0;
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
					ClearSoldierItem(ourFormations[i].Icon);
				}
				((GObject)ourFormations[i].Icon).data = i;
				((GObject)ourFormations[i].Icon).onClick.Set(new EventCallback1(OpenLegionPanel));
				((GObject)ourFormations[i].Icon).onTouchBegin.Set(new EventCallback1(OnBlockTouchBegin));
				((GObject)ourFormations[i].Icon).onTouchMove.Set(new EventCallback1(OnBlockTouchMove));
				((GObject)ourFormations[i].Icon).onTouchEnd.Set(new EventCallback1(OnBlockTouchEnd));
			}
			else
			{
				((GObject)ourFormations[i]).data = i;
				ourFormations[i].Type.selectedIndex = 1;
			}
		}
	}

	private void RenderSoldierItem(Soldier soldier, UI_soliderItem btn)
	{
		((GObject)btn.background).alpha = 1f;
		((GObject)btn.SoulStoneLevel).alpha = 1f;
		string iconPath = UiHelper.GetIconPath(soldier.Id);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = soldier.Level.ToString();
		int num = (soldier.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((DisplayObject)btn.iconFrame.image).material = null;
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		RenderLegendItems(soldier, (GButton)(object)btn, _legendItemIds?[soldier.Id]);
	}

	private void ClearSoldierItem(UI_soliderItem btn)
	{
		((GObject)btn.background).alpha = 0f;
		btn.icon.url = "";
		((GObject)btn.lv).text = "";
		btn.iconFrame.url = "";
		btn.lvFrame.url = "";
		((GObject)btn.SoulStoneLevel).alpha = 0f;
		((GComponent)btn).GetChild("LegendItems").visible = false;
	}

	private void RenderLegendItems(Soldier soldier, GButton button, List<long> legendItemIds)
	{
		((GComponent)button).GetChild("LegendItems").visible = true;
		for (int i = 0; i < 2; i++)
		{
			((GComponent)button).GetChild($"legendItem{i}").visible = true;
			((GComponent)button).GetChild($"legendItem{i}").scaleY = 0.35f;
			((GComponent)button).GetChild($"legendItem{i}").scaleX = 0.35f;
		}
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < legendItemIds.Count; j++)
		{
			if (num2 >= 2)
			{
				break;
			}
			long num3 = legendItemIds[j];
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num2}").asButton;
			if (!LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j))
			{
				((GObject)asButton).visible = false;
				((GComponent)asButton).GetChild("Icon").asLoader.url = "";
				((GComponent)asButton).GetChild("FrameIcon").asLoader.url = "";
				((GObject)asButton).data = null;
				continue;
			}
			((GObject)asButton).visible = true;
			if (num3 != 0)
			{
				num++;
			}
			((GObject)button).touchable = true;
			((GObject)asButton).scaleY = 0.35f;
			((GObject)asButton).scaleX = 0.35f;
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num3), UiHelper.TextColorType.Light, null, 2);
			if (num3 <= 0)
			{
				((GObject)asButton).visible = false;
				((GComponent)asButton).GetChild("Icon").asLoader.url = "";
				((GComponent)asButton).GetChild("FrameIcon").asLoader.url = "";
				((GObject)asButton).data = null;
			}
			((GObject)asButton).data = new SoldierLegendItemInfo
			{
				Slot = j,
				SoldierId = soldier.Id,
				ItemId = num3
			};
			num2++;
		}
		if (num == 0)
		{
			((GComponent)button).GetChild("LegendItems").visible = false;
		}
	}

	private void OpenLegendPanel(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GButton asButton = ((GObject)context.sender).asButton;
		if (((GObject)asButton).data != null && ((GObject)asButton).data is SoldierLegendItemInfo { Slot: >=0 } soldierLegendItemInfo)
		{
			if (soldierLegendItemInfo.ItemId <= 0)
			{
				UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.TopTopTournamentChoice, soldierLegendItemInfo.ItemId, soldierLegendItemInfo.SoldierId, soldierLegendItemInfo.Slot);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, null);
			}
			else
			{
				UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.TopTopTournamentChoice, soldierLegendItemInfo.ItemId, soldierLegendItemInfo.SoldierId, soldierLegendItemInfo.Slot);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, null);
			}
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

	public void SetOurPos(string fid, List<string> _curSoldiers, List<string> selectedSoldiers, Dictionary<string, List<long>> legendItemIds, Dictionary<string, int> _dungeonSoldiers)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		DungeonSoldiers = _dungeonSoldiers;
		FormationsInit();
		this._curSoldiers = _curSoldiers;
		_curSelectedSoldiers = selectedSoldiers;
		_legendItemIds = legendItemIds;
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
				ourVector2s[7]
			},
			{
				"8.3_0",
				ourVector2s[0]
			},
			{
				"8.3_-3.4",
				ourVector2s[5]
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
				ourVector2s[8]
			},
			{
				"1.5_0",
				ourVector2s[4]
			},
			{
				"1.5_-3.4",
				ourVector2s[6]
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
		foreach (string curSelectedSoldier in _curSelectedSoldiers)
		{
			if (DungeonSoldiers.ContainsKey(curSelectedSoldier))
			{
				list.Add(curSelectedSoldier);
			}
		}
		return list;
	}

	private void OpenLegionPanel(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		_curSelectedIndex = (int)((GObject)context.sender).data;
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Style", "8" },
			{ "IsLegendItemDungeon", true },
			{
				"PvpSoldiersFilter",
				GetSoldierFilter()
			},
			{ "OnlyUnlocked", 1 },
			{ "Spine", null }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	public void OnCampClose(EventContext eventContext, string soldierId, int chosenType)
	{
		if (chosenType == 8 && !(_curSoldiers[_curSelectedIndex] == soldierId))
		{
			if (string.IsNullOrEmpty(soldierId) || soldierId == "Lock" || soldierId == "Unlock")
			{
				string sid = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = soldierId;
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSomeSoldierBtn(_curSelectedIndex, soldierId);
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSelectedSoldierId(sid, isAdd: false);
			}
			else if (!_curSoldiers.Contains(soldierId))
			{
				string sid2 = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = soldierId;
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSomeSoldierBtn(_curSelectedIndex, soldierId);
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSelectedSoldierId(sid2, isAdd: false);
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSelectedSoldierId(soldierId, isAdd: true);
			}
			else
			{
				int index = _curSoldiers.IndexOf(soldierId);
				string text = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = soldierId;
				_curSoldiers[index] = text;
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSomeSoldierBtn(_curSelectedIndex, soldierId);
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSomeSoldierBtn(index, text);
			}
			_curSelectedSoldiers = UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.selectedSoldierId;
			if (!_legendItemIds.ContainsKey(soldierId))
			{
				_legendItemIds.Add(soldierId, new List<long> { 0L, 0L });
			}
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
			if (touchTarget.name.Contains("Icon"))
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
		if (touchTarget != null && touchTarget.name.Contains("Icon") && _curSelectedIndex != -1)
		{
			int num = (int)touchTarget.data;
			if (num <= _curSoldiers.Count - 1)
			{
				string text = _curSoldiers[num];
				string text2 = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = text;
				_curSoldiers[num] = text2;
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSomeSoldierBtn(_curSelectedIndex, text);
				UI_PresetFormationPanel.PeakBattleSelectArrayPanel?.UpdateSomeSoldierBtn(num, text2);
				GetMySoldiersCombatPower();
				SetOurFormations(_curSoldiers);
				ShowOurIcons();
			}
		}
	}

	private void GetMySoldiersCombatPower()
	{
		int num = 0;
		for (int i = 0; i < _curSoldiers.Count; i++)
		{
			if (!string.IsNullOrEmpty(_curSoldiers[i]) && !(_curSoldiers[i] == "Lock") && !(_curSoldiers[i] == "Unlock"))
			{
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(_curSoldiers[i]);
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
				num += soldier.CombatPower * soldierFormationNumber;
			}
		}
		((GObject)UI_PresetFormationPanel.PeakBattleSelectArrayPanel.Dialog.OurCombat).text = num.ToString();
	}

	public void PlayPosShake()
	{
		for (int i = 0; i < needShakeBtns.Count; i++)
		{
			ourFormations[needShakeBtns[i]].Breathe.Play();
		}
	}
}
