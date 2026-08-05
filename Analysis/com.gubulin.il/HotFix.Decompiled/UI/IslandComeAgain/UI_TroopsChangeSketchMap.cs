using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_TroopsChangeSketchMap : GComponent
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

	public const string URL = "ui://k2sprg26fuww8w";

	public static string Name = "UI_TroopsChangeSketchMap";

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<ShipSummaryUnitInfo> _curSoldiers = new List<ShipSummaryUnitInfo>();

	private bool isOldInfo;

	public static string GetURL()
	{
		return "ui://k2sprg26fuww8w";
	}

	public static UI_TroopsChangeSketchMap CreateInstance()
	{
		return (UI_TroopsChangeSketchMap)(object)UIPackage.CreateObject("IslandComeAgain", "TroopsChangeSketchMap");
	}

	public static UI_TroopsChangeSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TroopsChangeSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26fuww8w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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

	public void SetOurFormations(List<ShipSummaryUnitInfo> _curSoldiers)
	{
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		for (int i = 0; i < ourFormations.Count; i++)
		{
			((GObject)ourFormations[i].n7).visible = false;
			((GObject)ourFormations[i].num).visible = false;
			if (i <= _curSoldiers.Count - 1)
			{
				ShipSummaryUnitInfo shipSummaryUnitInfo = _curSoldiers[i];
				if (!string.IsNullOrWhiteSpace(shipSummaryUnitInfo.SoldierId) && shipSummaryUnitInfo.SoldierId != "Unlock" && shipSummaryUnitInfo.SoldierId != "Lock")
				{
					ourFormations[i].Type.selectedIndex = 0;
					RenderSoldierItem(shipSummaryUnitInfo, ourFormations[i].Icon);
					((GObject)ourFormations[i].Icon).alpha = 1f;
					((GObject)ourFormations[i].n7).visible = true;
					((GObject)ourFormations[i].num).visible = true;
					((GObject)ourFormations[i].num).text = $"{shipSummaryUnitInfo.CurCnt}/{shipSummaryUnitInfo.Total}";
				}
				else
				{
					ourFormations[i].Type.selectedIndex = 0;
					ClearSoldierItem(ourFormations[i].Icon);
				}
			}
			else
			{
				((GObject)ourFormations[i]).data = i;
				ourFormations[i].Type.selectedIndex = 2;
			}
		}
	}

	private void RenderSoldierItem(ShipSummaryUnitInfo soldierInfo, UI_soliderItem btn)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierInfo.SoldierId);
		((GObject)btn.SoulStoneLevel).alpha = 1f;
		int num = (isOldInfo ? soldierInfo.PotentialLevel : soldier.PotentialLevel);
		int itemLevel = 0;
		if (num >= 9)
		{
			itemLevel = 6;
		}
		else if (num > 0)
		{
			itemLevel = (2 + num) / 2;
		}
		string iconPath = UiHelper.GetIconPath(soldier.Id, itemLevel);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = (isOldInfo ? soldierInfo.SoldierLevel.ToString() : soldier.Level.ToString());
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(num);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(num);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, num);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, num, soldier.PotentialProgress);
		((GObject)btn).touchable = false;
		btn.Type.selectedIndex = 0;
		RenderLegendItems(soldier, (GButton)(object)btn, (!isOldInfo) ? null : soldierInfo.EquippedItems?.ToList());
		((GObject)btn).touchable = false;
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

	private void RenderLegendItems(Soldier soldier, GButton button, List<int> oldSoldierLegendItems = null)
	{
		((GComponent)button).GetChild("LegendItems").visible = true;
		long[] array = new long[2];
		if (oldSoldierLegendItems != null)
		{
			for (int i = 0; i < oldSoldierLegendItems.Count; i++)
			{
				array[i] = oldSoldierLegendItems[i];
			}
		}
		else if (LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id))
		{
			array = LegendItemsHelper.SoldiersEquippedItems[soldier.Id];
		}
		for (int j = 0; j < 2; j++)
		{
			((GComponent)button).GetChild($"legendItem{j}").visible = false;
			((GComponent)button).GetChild($"legendItem{j}").scaleY = 0.35f;
			((GComponent)button).GetChild($"legendItem{j}").scaleX = 0.35f;
		}
		UI_LegendItemsBack uI_LegendItemsBack = ((GComponent)button).GetChild("LegendItemsBack") as UI_LegendItemsBack;
		int num = 0;
		int num2 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (num2 >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num2}").asButton;
			bool soldierItemSlotState = LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, k);
			long num3 = array[k];
			if (!soldierItemSlotState || num3 <= 0)
			{
				((GComponent)asButton).GetChild("Icon").asLoader.url = "";
				((GComponent)asButton).GetChild("FrameIcon").asLoader.url = "";
				continue;
			}
			((GObject)asButton).visible = true;
			num++;
			((GObject)button).touchable = true;
			((GObject)asButton).scaleY = 0.35f;
			((GObject)asButton).scaleX = 0.35f;
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num3), UiHelper.TextColorType.Light, null, 2);
			num2++;
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

	public void SetOurPos(string fid, List<ShipSummaryUnitInfo> _curSoldiers, bool isOld = false)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		isOldInfo = isOld;
		FormationsInit();
		this._curSoldiers = _curSoldiers;
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
		SetOurFormations(_curSoldiers);
		ShowOurIcons();
	}
}
