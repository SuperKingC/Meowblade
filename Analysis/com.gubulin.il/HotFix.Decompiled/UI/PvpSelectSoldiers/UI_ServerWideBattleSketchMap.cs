using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using UI.LegendItemInfo;
using UI.LegendItems;
using UI.Legion;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideBattleSketchMap : GComponent
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

	public const string URL = "ui://82mo10n5swk0jdv2";

	public static string Name = "UI_ServerWideBattleSketchMap";

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<string> _curSoldiers = new List<string>();

	private Dictionary<string, List<long>> _legendItemIds = new Dictionary<string, List<long>>();

	private List<string> _curSelectedSoldiers = new List<string>();

	private int _curSelectedIndex;

	private string curTouchBlockSid;

	private bool isMouseMoving = false;

	private List<int> needShakeBtns = new List<int>();

	public static string GetURL()
	{
		return "ui://82mo10n5swk0jdv2";
	}

	public static UI_ServerWideBattleSketchMap CreateInstance()
	{
		return (UI_ServerWideBattleSketchMap)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideBattleSketchMap");
	}

	public static UI_ServerWideBattleSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideBattleSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5swk0jdv2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		int num = 0;
		needShakeBtns.Clear();
		for (int i = 0; i < ourFormations.Count; i++)
		{
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
				}
				else
				{
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
		((GObject)btn.SoulStoneLevel).alpha = 1f;
		string iconPath = UiHelper.GetIconPath(soldier.Id);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = soldier.Level.ToString();
		int num = (soldier.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		((GObject)btn).touchable = true;
		btn.Type.selectedIndex = 2;
		RenderLegendItems(soldier, (GButton)(object)btn, _legendItemIds?[soldier.Id]);
	}

	private void ClearSoldierItem(UI_soliderItem btn)
	{
		btn.icon.url = "";
		((GObject)btn.lv).text = "";
		btn.iconFrame.url = "";
		btn.lvFrame.url = "";
		((GObject)btn.SoulStoneLevel).alpha = 0f;
		((GComponent)btn).GetChild("LegendItems").visible = false;
		((UI_LegendItemsBack)(object)((GComponent)btn).GetChild("LegendItemsBack")).SetType(0);
	}

	private void RenderLegendItems(Soldier soldier, GButton button, List<long> legendItemIds)
	{
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		((GComponent)button).GetChild("LegendItems").visible = true;
		for (int i = 0; i < 2; i++)
		{
			((GComponent)button).GetChild($"legendItem{i}").visible = true;
			((GComponent)button).GetChild($"legendItem{i}").scaleY = 0.35f;
			((GComponent)button).GetChild($"legendItem{i}").scaleX = 0.35f;
		}
		UI_LegendItemsBack uI_LegendItemsBack = ((GComponent)button).GetChild("LegendItemsBack") as UI_LegendItemsBack;
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < legendItemIds.Count; j++)
		{
			if (num2 >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num2}").asButton;
			bool soldierItemSlotState = LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j);
			long num3 = legendItemIds[j];
			if (!soldierItemSlotState)
			{
				((GObject)asButton).visible = false;
				((GComponent)asButton).GetChild("Icon").asLoader.url = "";
				((GComponent)asButton).GetChild("FrameIcon").asLoader.url = "";
				((GObject)asButton).data = null;
				((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendPanel));
				continue;
			}
			((GObject)asButton).visible = true;
			num++;
			((GObject)asButton).scaleY = 0.35f;
			((GObject)asButton).scaleX = 0.35f;
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num3), UiHelper.TextColorType.Light, null, 2);
			if (num3 <= 0)
			{
				((GComponent)asButton).GetController("TypeController").selectedIndex = 3;
				((GComponent)asButton).GetChild("Icon").asLoader.url = "";
				((GComponent)asButton).GetChild("FrameIcon").asLoader.url = "";
			}
			((GObject)asButton).data = new SoldierLegendItemInfo
			{
				Slot = j,
				SoldierId = soldier.Id,
				ItemId = num3
			};
			((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendPanel));
			num2++;
		}
		if (num == 0)
		{
			((GComponent)button).GetChild("LegendItems").visible = false;
			uI_LegendItemsBack?.SetType(0);
		}
		else
		{
			uI_LegendItemsBack?.SetType(num);
		}
	}

	private void OpenLegendPanel(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GButton asButton = ((GObject)context.sender).asButton;
		if (((GObject)asButton).data == null)
		{
			return;
		}
		SoldierLegendItemInfo itemInfo = ((GObject)asButton).data as SoldierLegendItemInfo;
		if (itemInfo != null && itemInfo.Slot >= 0)
		{
			if (itemInfo.ItemId <= 0)
			{
				OpenLegendItemsPanelFoo();
				return;
			}
			LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(itemInfo.ItemId);
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(legendItemUi, itemInfo.SoldierId, itemInfo.Slot, 7);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, new Dictionary<string, object> { 
			{
				"ChangeAction",
				new Action(OpenLegendItemsPanelBar)
			} });
		}
		static void ActionBar()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, null);
		}
		static void ActionFoo()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, null);
		}
		void OpenLegendItemsPanelBar()
		{
			UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.TopTopTournamentChoice, itemInfo.ItemId, itemInfo.SoldierId, itemInfo.Slot);
			LegendItemsHelper.OpenLegendItemBlueprintListPanel(ActionBar);
		}
		void OpenLegendItemsPanelFoo()
		{
			UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.TopTopTournamentChoice, itemInfo.ItemId, itemInfo.SoldierId, itemInfo.Slot);
			LegendItemsHelper.OpenLegendItemBlueprintListPanel(ActionFoo);
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

	public void SetOurPos(string fid, List<string> _curSoldiers, List<string> selectedSoldiers, Dictionary<string, List<long>> legendItemIds)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
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
			{ "Style", "6" },
			{
				"PvpSoldiersFilter",
				GetSoldierFilter()
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	public void OnCampClose(EventContext eventContext, string soldierId, int chosenType)
	{
		if (chosenType != 6 || _curSoldiers[_curSelectedIndex] == soldierId)
		{
			return;
		}
		if (string.IsNullOrEmpty(soldierId) || soldierId == "Lock" || soldierId == "Unlock")
		{
			string sid = _curSoldiers[_curSelectedIndex];
			_curSoldiers[_curSelectedIndex] = soldierId;
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSomeSoldierBtn(_curSelectedIndex, soldierId);
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSelectedSoldierId(sid, isAdd: false);
		}
		else if (!_curSoldiers.Contains(soldierId))
		{
			string sid2 = _curSoldiers[_curSelectedIndex];
			_curSoldiers[_curSelectedIndex] = soldierId;
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSomeSoldierBtn(_curSelectedIndex, soldierId);
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSelectedSoldierId(sid2, isAdd: false);
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSelectedSoldierId(soldierId, isAdd: true);
		}
		else
		{
			int index = _curSoldiers.IndexOf(soldierId);
			string text = _curSoldiers[_curSelectedIndex];
			_curSoldiers[_curSelectedIndex] = soldierId;
			_curSoldiers[index] = text;
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSomeSoldierBtn(_curSelectedIndex, soldierId);
			UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSomeSoldierBtn(index, text);
		}
		_curSelectedSoldiers = UI_SelectServerWideBattleArrayPanel.Instance?.selectedSoldierId;
		if (!_legendItemIds.ContainsKey(soldierId))
		{
			List<long> value = new List<long> { 0L, 0L };
			if (UI_SelectServerWideBattleArrayPanel.Instance != null)
			{
				SoldierWithLegendItemId soldierInfo = UI_SelectServerWideBattleArrayPanel.Instance.GetSoldierInfo(soldierId);
				value = soldierInfo.LegendItemIds;
			}
			_legendItemIds.Add(soldierId, value);
		}
		GetMySoldiersCombatPower();
		SetOurFormations(_curSoldiers);
		ShowOurIcons();
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
		if (touchTarget != null && touchTarget.gameObjectName == "soliderItem" && _curSelectedIndex != -1)
		{
			int num = (int)touchTarget.data;
			if (num <= _curSoldiers.Count - 1)
			{
				string text = _curSoldiers[num];
				string text2 = _curSoldiers[_curSelectedIndex];
				_curSoldiers[_curSelectedIndex] = text;
				_curSoldiers[num] = text2;
				UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSomeSoldierBtn(_curSelectedIndex, text);
				UI_SelectServerWideBattleArrayPanel.Instance?.UpdateSomeSoldierBtn(num, text2);
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
			string text = _curSoldiers[i];
			if (string.IsNullOrEmpty(text) || text == "Lock" || text == "Unlock")
			{
				continue;
			}
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
			List<LegendItem> list = new List<LegendItem>();
			if (_legendItemIds.TryGetValue(text, out var value))
			{
				foreach (long item in value)
				{
					LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(item);
					if (legendItemUi != null)
					{
						LegendItem legendItemData = legendItemUi.LegendItemData;
						if (legendItemData != null)
						{
							list.Add(legendItemData);
						}
					}
				}
			}
			num += soldier.GetCombatPowerWithLegendItems(list) * soldierFormationNumber;
		}
		if (UI_SelectServerWideBattleArrayPanel.Instance != null)
		{
			((GObject)UI_SelectServerWideBattleArrayPanel.Instance.Dialog.OurCombat).text = num.ToString();
		}
	}

	public void PlayPosShake()
	{
		for (int i = 0; i < needShakeBtns.Count; i++)
		{
			ourFormations[needShakeBtns[i]].Breathe.Play();
		}
	}
}
