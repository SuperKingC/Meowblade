using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_MyTroopsSketchMap : GComponent
{
	private struct SlotData
	{
		public int SlotIndex;

		public long LegendItemInstanceId;
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

	public const string URL = "ui://u6x0b1gnfdar4";

	public static string Name = "UI_MyTroopsSketchMap";

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<GvGMode3UnitInfo> CurrentUnitInfo;

	private List<string> _curSoldiers = new List<string>();

	private UI_ArmyPage _armyPage;

	public static string GetURL()
	{
		return "ui://u6x0b1gnfdar4";
	}

	public static UI_MyTroopsSketchMap CreateInstance()
	{
		return (UI_MyTroopsSketchMap)(object)UIPackage.CreateObject("GvGShipDetail", "MyTroopsSketchMap");
	}

	public static UI_MyTroopsSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyTroopsSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnfdar4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
	}

	public void SetOurPos(string fid, List<GvGMode3UnitInfo> currentUnitInfo, UI_ArmyPage armyPage)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		FormationsInit();
		_armyPage = armyPage;
		CurrentUnitInfo = currentUnitInfo;
		_curSoldiers = currentUnitInfo.Select((GvGMode3UnitInfo soldierInfo) => soldierInfo.SoldierId).Take(5).ToList();
		if (string.IsNullOrWhiteSpace(fid))
		{
			for (int num = 0; num < ourFormations.Count; num++)
			{
				ourFormations[num].Type.selectedIndex = 1;
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
		for (int num2 = 0; num2 < 5; num2++)
		{
			if (formation.SlotPosition.ContainsKey(num2))
			{
				string key = $"{formation.SlotPosition[num2].x}_{formation.SlotPosition[num2].y}";
				if (dictionary.ContainsKey(key))
				{
					((GObject)ourFormations[num2]).xy = dictionary[key];
					dictionary.Remove(key);
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		foreach (KeyValuePair<string, Vector2> item in dictionary)
		{
			list.Add(item.Value);
		}
		for (int num3 = 5; num3 < ourFormations.Count; num3++)
		{
			((GObject)ourFormations[num3]).xy = list[num3 - 5];
		}
		SetOurFormations(_curSoldiers);
	}

	public void UpdateSoldiers(List<GvGMode3UnitInfo> currentUnitInfo)
	{
		List<string> list = currentUnitInfo.Select((GvGMode3UnitInfo soldierInfo) => soldierInfo.SoldierId).Take(5).ToList();
		if (!(SoldierListToString(list) == SoldierListToString(_curSoldiers)))
		{
			CurrentUnitInfo = currentUnitInfo;
			_curSoldiers = list;
			SetOurFormations(_curSoldiers);
		}
	}

	public List<UI_SoldierFormation> GetAllSlots()
	{
		FormationsInit();
		List<UI_SoldierFormation> list = new List<UI_SoldierFormation>();
		foreach (UI_SoldierFormation ourFormation in ourFormations)
		{
			list.Add(ourFormation);
		}
		return list;
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

	private void SetOurFormations(List<string> _curSoldiers)
	{
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		for (int i = 0; i < ourFormations.Count; i++)
		{
			if (i <= _curSoldiers.Count - 1)
			{
				string text = _curSoldiers[i];
				GvGMode3UnitInfo gvGMode3UnitInfo = CurrentUnitInfo[i];
				if (UnitInfoHelper.CheckIsValidSoldier(text))
				{
					((GObject)ourFormations[i].Icon).alpha = 1f;
					((GObject)ourFormations[i].n7).visible = true;
					((GObject)ourFormations[i].num).visible = true;
					((GObject)ourFormations[i].num).text = $"[color={UnitInfoHelper.GetSoldierNumTextColor(gvGMode3UnitInfo)}]{gvGMode3UnitInfo.CurCnt}[/color]/{gvGMode3UnitInfo.Total}";
					RenderSoldierItem(gvGMode3UnitInfo, ourFormations[i].Icon);
					ourFormations[i].Type.selectedIndex = 0;
				}
				else
				{
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
					ClearSoldierItem(ourFormations[i].Icon);
					ourFormations[i].Type.selectedIndex = 1;
				}
				((GObject)ourFormations[i].Icon).data = text;
			}
			else
			{
				((GObject)ourFormations[i].n7).visible = false;
				((GObject)ourFormations[i].num).visible = false;
				((GObject)ourFormations[i]).data = "";
				ourFormations[i].Type.selectedIndex = 2;
			}
		}
		ShowOurIcons();
	}

	private void RenderSoldierItem(GvGMode3UnitInfo unitInfo, UI_soliderItem btn)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(unitInfo.SoldierId);
		((GObject)btn.SoulStoneLevel).alpha = 1f;
		string iconPath = UiHelper.GetIconPath(unitInfo.SoldierId);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = unitInfo.SoldierLevel.ToString();
		int num = (unitInfo.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(unitInfo.PotentialLevel);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		string text = $"kuang_round 3_lv{num}";
		btn.lvFrame.url = "ui://PublicResources/" + text;
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, unitInfo.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, unitInfo.PotentialLevel, soldier.PotentialProgress);
		btn.Type.selectedIndex = 0;
		RenderLegendItems(unitInfo, (GButton)(object)btn);
	}

	private void ClearSoldierItem(UI_soliderItem btn)
	{
		btn.icon.url = "";
		((GObject)btn.lv).text = "";
		btn.iconFrame.url = "";
		btn.lvFrame.url = "";
		((GObject)btn.SoulStoneLevel).alpha = 0f;
		((GComponent)btn).GetChild("LegendItems").visible = false;
		((UI_LegendItemsBack)(object)((GComponent)btn).GetChild("LegendItemsBack")).Type.selectedIndex = 0;
	}

	private void RenderLegendItems(GvGMode3UnitInfo unitInfo, GButton button)
	{
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		GObject child = ((GComponent)button).GetChild("LegendItems");
		child.visible = true;
		((GComponent)button).GetController("Type").SetSelectedIndex(2);
		int[] array = unitInfo.EquippedItems ?? new int[2];
		for (int i = 0; i < 2; i++)
		{
			GObject child2 = ((GComponent)button).GetChild($"legendItem{i}");
			child2.visible = false;
			child2.scaleY = 0.35f;
			child2.scaleX = 0.35f;
		}
		UI_LegendItemsBack uI_LegendItemsBack = ((GComponent)button).GetChild("LegendItemsBack") as UI_LegendItemsBack;
		int num = 0;
		bool canFillUpUnits = _armyPage.CanFillUpUnits;
		for (int j = 0; j < array.Length && j < 2; j++)
		{
			GButton asButton = ((GComponent)button).GetChild($"legendItem{j}").asButton;
			GLoader asLoader = ((GComponent)asButton).GetChild("Icon").asLoader;
			bool soldierItemSlotState = LegendItemsHelper.GetSoldierItemSlotState(unitInfo.SoldierId, j);
			long num2 = array[j];
			if (!soldierItemSlotState || (!canFillUpUnits && num2 <= 0))
			{
				asLoader.url = "";
				((GComponent)asButton).GetChild("FrameIcon").asLoader.url = "";
				continue;
			}
			((GObject)asButton).visible = true;
			((GObject)asButton).alpha = ((num2 <= 0) ? 0f : 1f);
			num++;
			((GObject)asButton).scaleY = 0.35f;
			((GObject)asButton).scaleX = 0.35f;
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num2), UiHelper.TextColorType.Light, null, 2);
			((GObject)asButton).data = unitInfo;
			((GObject)asLoader).data = new SlotData
			{
				SlotIndex = j,
				LegendItemInstanceId = num2
			};
			((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendItemDialog));
		}
		if (num == 0)
		{
			((GComponent)button).GetChild("LegendItems").visible = false;
			if (uI_LegendItemsBack != null)
			{
				uI_LegendItemsBack.Type.selectedIndex = 0;
			}
		}
		else if (uI_LegendItemsBack != null)
		{
			uI_LegendItemsBack.Type.selectedIndex = num;
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

	private string SoldierListToString(List<string> list)
	{
		string text = "";
		foreach (string item in list)
		{
			text = text + item + ",";
		}
		return text;
	}

	private void OpenLegendItemDialog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		if (((GObject)val).data is GvGMode3UnitInfo gvGMode3UnitInfo)
		{
			SlotData slotData = (SlotData)((GComponent)val).GetChild("Icon").data;
			gvGMode3UnitInfo.ShowLegendItemInfo(_armyPage.StateData.EntityId, slotData.LegendItemInstanceId, _armyPage.CanFillUpUnits, slotData.SlotIndex);
		}
	}
}
