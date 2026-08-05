using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Legion;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_StandardFormationSketchMap : GComponent
{
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

	public const string URL = "ui://0i520nzmtlapo7v";

	public static string Name = "UI_StandardFormationSketchMap";

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<string> CurSoldiers = new List<string>();

	private List<string> SeletedSoldierFilter = new List<string>();

	private int _curSelectedIndex;

	private Action<int> OnCombatPowerChange;

	private bool isGvGSelectSoldiers;

	private string curTouchBlockSid;

	private bool isMouseMoving = false;

	private List<int> needShakeBtns = new List<int>();

	public static string GetURL()
	{
		return "ui://0i520nzmtlapo7v";
	}

	public static UI_StandardFormationSketchMap CreateInstance()
	{
		return (UI_StandardFormationSketchMap)(object)UIPackage.CreateObject("LordOfDreams", "StandardFormationSketchMap");
	}

	public static UI_StandardFormationSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StandardFormationSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtlapo7v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnCampClose);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnCampClose);
	}

	public void SetOurPos(string fid, List<string> _curSoldiers, List<string> selectedSoldiersFilter = null, Action<int> onCombatPowerChange = null, bool isSelectSoldiers = false)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		OnCombatPowerChange = onCombatPowerChange;
		FormationsInit();
		isGvGSelectSoldiers = isSelectSoldiers;
		CurSoldiers = _curSoldiers;
		SeletedSoldierFilter = selectedSoldiersFilter;
		if (SeletedSoldierFilter == null)
		{
			SeletedSoldierFilter = CurSoldiers.GetRange(0, CurSoldiers.Count);
		}
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
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
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
					int stock = GameManagers.Instance.StockController.GetStock(text);
					int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text);
					int num2 = (isGvGSelectSoldiers ? (Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel) * 5) : Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel));
					num++;
					bool flag = stock < num2;
					ourFormations[i].num.color = (flag ? Color.red : Color.white);
					ourFormations[i].num.strokeColor = (flag ? Color.white : Color.gray);
					((GObject)ourFormations[i].num).text = $"{stock}/{num2}";
					if (flag)
					{
						needShakeBtns.Add(i);
					}
					RenderSoldierItem(soldier, ourFormations[i].Icon);
					((GObject)ourFormations[i].Icon).visible = true;
					((GObject)ourFormations[i].n7).visible = true;
					((GObject)ourFormations[i].num).visible = true;
				}
				else
				{
					needShakeBtns.Add(i);
					ourFormations[i].Type.selectedIndex = 0;
					((GObject)ourFormations[i].Icon).visible = false;
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
				}
				((GObject)ourFormations[i]).data = i;
				((GObject)ourFormations[i]).onClick.Set(new EventCallback1(OpenLegionPanel));
				((GObject)ourFormations[i]).onTouchBegin.Set(new EventCallback1(OnBlockTouchBegin));
				((GObject)ourFormations[i]).onTouchMove.Set(new EventCallback1(OnBlockTouchMove));
				((GObject)ourFormations[i]).onTouchEnd.Set(new EventCallback1(OnBlockTouchEnd));
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
		string iconPath = UiHelper.GetIconPath(soldier.Id);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = soldier.Level.ToString();
		int num = (soldier.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		RenderLegendItems(soldier, (GButton)(object)btn);
	}

	private void RenderLegendItems(Soldier soldier, GButton button)
	{
		if (LegendItemsHelper.SoldiersEquippedItems == null || !LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id))
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			((GComponent)button).GetChild($"legendItem{i}").visible = false;
			((GComponent)button).GetChild($"legendItem{i}").scaleY = 0.35f;
			((GComponent)button).GetChild($"legendItem{i}").scaleX = 0.35f;
		}
		int num = 0;
		for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldier.Id].Length; j++)
		{
			if (num >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num}").asButton;
			if (!LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j))
			{
				((GObject)asButton).visible = false;
				((GObject)asButton).scaleY = 0f;
				continue;
			}
			long num2 = LegendItemsHelper.SoldiersEquippedItems[soldier.Id][j];
			((GObject)asButton).visible = true;
			if (num2 == 0)
			{
				((GObject)asButton).scaleY = 0f;
				((GObject)asButton).visible = false;
				continue;
			}
			((GObject)asButton).scaleY = 0.35f;
			((GObject)asButton).scaleX = 0.35f;
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num2), UiHelper.TextColorType.Light, null, 2);
			num++;
		}
		bool flag = false;
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
		((GComponent)button).GetChild("LegendItems").visible = !flag;
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

	private List<string> GetSoldierFilter()
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < CurSoldiers.Count; i++)
		{
			list.Add(CurSoldiers[i]);
		}
		for (int j = 0; j < SeletedSoldierFilter.Count; j++)
		{
			list2.Add(SeletedSoldierFilter[j]);
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
		if (chosenType == 6 && !(CurSoldiers[_curSelectedIndex] == soldierId))
		{
			if (string.IsNullOrEmpty(soldierId) || soldierId == "Lock" || soldierId == "Unlock")
			{
				string sid = CurSoldiers[_curSelectedIndex];
				CurSoldiers[_curSelectedIndex] = soldierId;
				UpdateSelectedSoldierId(sid, isAdd: false);
			}
			else if (!CurSoldiers.Contains(soldierId))
			{
				string sid2 = CurSoldiers[_curSelectedIndex];
				CurSoldiers[_curSelectedIndex] = soldierId;
				UpdateSelectedSoldierId(sid2, isAdd: false);
				UpdateSelectedSoldierId(soldierId, isAdd: true);
			}
			else
			{
				int index = CurSoldiers.IndexOf(soldierId);
				string value = CurSoldiers[_curSelectedIndex];
				CurSoldiers[_curSelectedIndex] = soldierId;
				CurSoldiers[index] = value;
			}
			GetMySoldiersCombatPower();
			SetOurFormations(CurSoldiers);
			ShowOurIcons();
		}
	}

	public void UpdateSelectedSoldierId(string _sid, bool isAdd)
	{
		if (isAdd)
		{
			if (!SeletedSoldierFilter.Contains(_sid))
			{
				SeletedSoldierFilter.Add(_sid);
			}
		}
		else if (SeletedSoldierFilter.Contains(_sid))
		{
			SeletedSoldierFilter.Remove(_sid);
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
		string text = CurSoldiers[_curSelectedIndex];
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
			if (num <= CurSoldiers.Count - 1)
			{
				string value = CurSoldiers[num];
				string value2 = CurSoldiers[_curSelectedIndex];
				CurSoldiers[_curSelectedIndex] = value;
				CurSoldiers[num] = value2;
				GetMySoldiersCombatPower();
				SetOurFormations(CurSoldiers);
				ShowOurIcons();
			}
		}
	}

	private void GetMySoldiersCombatPower()
	{
		int num = 0;
		for (int i = 0; i < CurSoldiers.Count; i++)
		{
			if (!string.IsNullOrEmpty(CurSoldiers[i]) && !(CurSoldiers[i] == "Lock") && !(CurSoldiers[i] == "Unlock"))
			{
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(CurSoldiers[i]);
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
				num += soldier.CombatPower * soldierFormationNumber;
			}
		}
		OnCombatPowerChange?.Invoke(num);
	}

	public void PlayPosShake()
	{
		for (int i = 0; i < needShakeBtns.Count; i++)
		{
			ourFormations[needShakeBtns[i]].Breathe.Play();
		}
	}

	public void AllDisappear()
	{
		for (int i = 0; i < ourFormations.Count; i++)
		{
			ourFormations[i].Disappear.Play();
		}
	}
}
