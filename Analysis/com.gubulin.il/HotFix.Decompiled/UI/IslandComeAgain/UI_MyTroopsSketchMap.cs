using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Rank.Helpers;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_MyTroopsSketchMap : GComponent
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

	public const string URL = "ui://k2sprg26in7b1d";

	public static string Name = "UI_MyTroopsSketchMap";

	private const int maxFormationCount = 5;

	private const int MaxFormationsNum = 9;

	private const int LegendItemsLimit = 2;

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private List<string> _curSoldiers = new List<string>();

	private int _curSelectedIndex;

	private int myTroopsDialogType;

	private string curTouchBlockSid;

	private bool isMouseMoving = false;

	public static string GetURL()
	{
		return "ui://k2sprg26in7b1d";
	}

	public static UI_MyTroopsSketchMap CreateInstance()
	{
		return (UI_MyTroopsSketchMap)(object)UIPackage.CreateObject("IslandComeAgain", "MyTroopsSketchMap");
	}

	public static UI_MyTroopsSketchMap CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyTroopsSketchMap).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		for (int i = 0; i < ourFormations.Count; i++)
		{
			if (i <= _curSoldiers.Count - 1)
			{
				string text = _curSoldiers[i];
				ShipSummaryUnitInfo shipSummaryUnitInfo = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo[i];
				if (!string.IsNullOrWhiteSpace(text) && text != "Unlock" && text != "Lock")
				{
					Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
					ourFormations[i].Type.selectedIndex = 0;
					RenderSoldierItem(soldier, ourFormations[i].Icon);
					((GObject)ourFormations[i].Icon).alpha = 1f;
					((GObject)ourFormations[i].n7).visible = true;
					((GObject)ourFormations[i].num).visible = true;
					((GObject)ourFormations[i].num).text = $"{shipSummaryUnitInfo.CurCnt}/{shipSummaryUnitInfo.Total}";
				}
				else
				{
					ourFormations[i].Type.selectedIndex = 0;
					((GObject)ourFormations[i].n7).visible = false;
					((GObject)ourFormations[i].num).visible = false;
					ClearSoldierItem(ourFormations[i].Icon);
				}
				((GObject)ourFormations[i].Icon).data = i;
				((GObject)ourFormations[i].Icon).onTouchBegin.Set(new EventCallback1(OnBlockTouchBegin));
				((GObject)ourFormations[i].Icon).onTouchMove.Set(new EventCallback1(OnBlockTouchMove));
				((GObject)ourFormations[i].Icon).onTouchEnd.Set(new EventCallback1(OnBlockTouchEnd));
			}
			else
			{
				((GObject)ourFormations[i].n7).visible = false;
				((GObject)ourFormations[i].num).visible = false;
				((GObject)ourFormations[i]).data = i;
				ourFormations[i].Type.selectedIndex = ((myTroopsDialogType != 1) ? 1 : 2);
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
		((GObject)btn).touchable = false;
		btn.Type.selectedIndex = 0;
		RenderLegendItems(soldier, (GButton)(object)btn);
		((GObject)btn).touchable = myTroopsDialogType == 0;
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

	private void RenderLegendItems(Soldier soldier, GButton button)
	{
		((GComponent)button).GetChild("LegendItems").visible = true;
		long[] array = ((LegendItemsHelper.SoldiersEquippedItems == null || !LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id)) ? new long[2] : LegendItemsHelper.SoldiersEquippedItems[soldier.Id]);
		for (int i = 0; i < 2; i++)
		{
			((GComponent)button).GetChild($"legendItem{i}").visible = false;
			((GComponent)button).GetChild($"legendItem{i}").scaleY = 0.35f;
			((GComponent)button).GetChild($"legendItem{i}").scaleX = 0.35f;
		}
		UI_LegendItemsBack uI_LegendItemsBack = ((GComponent)button).GetChild("LegendItemsBack") as UI_LegendItemsBack;
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (num2 >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num2}").asButton;
			bool soldierItemSlotState = LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j);
			long num3 = array[j];
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

	public void SetOurPos(string fid, List<ShipSummaryUnitInfo> CurrentUnitInfo, int panelType)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		FormationsInit();
		_curSoldiers = CurrentUnitInfo.Select((ShipSummaryUnitInfo soldierInfo) => soldierInfo.SoldierId).ToList();
		myTroopsDialogType = panelType;
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
		if (touchTarget == null || !touchTarget.name.Contains("Icon") || _curSelectedIndex == -1)
		{
			return;
		}
		int num = (int)touchTarget.data;
		if (num > _curSoldiers.Count - 1)
		{
			return;
		}
		string value = _curSoldiers[num];
		string value2 = _curSoldiers[_curSelectedIndex];
		_curSoldiers[_curSelectedIndex] = value;
		_curSoldiers[num] = value2;
		Singleton<GvGInstanceZone>.Instance.CurrentSoldiers = new List<string>(_curSoldiers);
		List<ShipSummaryUnitInfo> source = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Clone();
		List<ShipSummaryUnitInfo> list = new List<ShipSummaryUnitInfo>();
		int i;
		for (i = 0; i < _curSoldiers.Count; i++)
		{
			ShipSummaryUnitInfo shipSummaryUnitInfo = source.FirstOrDefault((ShipSummaryUnitInfo t) => t.SoldierId == _curSoldiers[i]);
			if (shipSummaryUnitInfo != null)
			{
				list.Add(shipSummaryUnitInfo);
			}
		}
		Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo = list;
		GameLocalDataManager.SaveIslandComeAgainSoldiers(_curSoldiers);
		SetOurFormations(_curSoldiers);
		ShowOurIcons();
	}
}
