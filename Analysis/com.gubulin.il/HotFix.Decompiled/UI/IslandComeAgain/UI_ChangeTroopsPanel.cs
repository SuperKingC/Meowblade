using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using GvG2.Common.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using UI.Legion;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_ChangeTroopsPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_ChangeTroopsDialog Dialog;

	public const string URL = "ui://k2sprg26in7b2x";

	public static string Name = "UI_ChangeTroopsPanel";

	private List<ShipSummaryUnitInfo> oldUnitInfo = new List<ShipSummaryUnitInfo>();

	private List<string> newSoldiers = new List<string>();

	public static string GetURL()
	{
		return "ui://k2sprg26in7b2x";
	}

	public static UI_ChangeTroopsPanel CreateInstance()
	{
		return (UI_ChangeTroopsPanel)(object)UIPackage.CreateObject("IslandComeAgain", "ChangeTroopsPanel");
	}

	public static UI_ChangeTroopsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChangeTroopsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_ChangeTroopsDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("CurrentSoldiersInfo", out var value))
		{
			oldUnitInfo = (List<ShipSummaryUnitInfo>)value;
		}
		RenderOldSoldiers();
		SetCurrentDialogType();
		NewSoldiersListInit();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.CloseBtn).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(ConfirmEvent));
		SharedMessenger.AddListener<List<string>>("UPDATE_ISLAND_COME_AGAIN_SOLDIERS", RenderNewSoldiers);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnBattleEnd);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.CloseBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(ConfirmEvent));
		SharedMessenger.RemoveListener<List<string>>("UPDATE_ISLAND_COME_AGAIN_SOLDIERS", RenderNewSoldiers);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnBattleEnd);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnBattleEnd(string uiName)
	{
		if (string.Equals(uiName, UI_IslandComeAgainBattleResultPanel.Name))
		{
			End();
		}
	}

	private void RenderOldSoldiers()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.OldSoldiers.itemRenderer = new ListItemRenderer(RenderOldSoldierItem);
		Dialog.OldSoldiers.numItems = oldUnitInfo.Count;
	}

	private void RenderOldSoldierItem(int index, GObject obj)
	{
		if (obj is UI_TroopsItem uI_TroopsItem)
		{
			uI_TroopsItem.Type.selectedIndex = 1;
			ShipSummaryUnitInfo shipSummaryUnitInfo = oldUnitInfo[index];
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(shipSummaryUnitInfo.PotentialLevel);
			int curCnt = shipSummaryUnitInfo.CurCnt;
			int total = shipSummaryUnitInfo.Total;
			uI_TroopsItem.IconLoader.IconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(shipSummaryUnitInfo.SoldierId);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_TroopsItem.SoulStoneLevel, shipSummaryUnitInfo.PotentialLevel, new List<int>());
			uI_TroopsItem.FrameLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(uI_TroopsItem.FrameLoader, shipSummaryUnitInfo.PotentialLevel);
			((GObject)uI_TroopsItem.Amount_t).text = $"[color={Singleton<GvGInstanceZone>.Instance.GetReplenishSoldierNumTextColor(curCnt, total)}]{curCnt}[/color]/{total}";
		}
	}

	private void SetCurrentDialogType()
	{
		Dialog.Type.selectedIndex = ((newSoldiers.Count > 0) ? 1 : 0);
		if (Dialog.Type.selectedIndex == 1)
		{
			((GObject)Dialog.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText294") + " " + UiHelper.ParseTime_Foo(GetExpectedFillUpTime() - (int)GameController.Instance.GetServerTime());
		}
	}

	private int GetExpectedFillUpTime()
	{
		List<ShipSummaryUnitInfo> list = oldUnitInfo;
		List<ShipSummaryUnitInfo> list2 = new List<ShipSummaryUnitInfo>();
		foreach (string newSoldier in newSoldiers)
		{
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(newSoldier);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(newSoldier, soldierLevel);
			int stock = GameManagers.Instance.StockController.GetStock(newSoldier);
			int num = Mathf.Min(stock, soldierFormationNumber * 5);
			ShipSummaryUnitInfo item = new ShipSummaryUnitInfo
			{
				SoldierId = newSoldier,
				Total = num,
				CurCnt = num
			};
			list2.Add(item);
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		int num2 = (int)GameController.Instance.GetServerTime();
		for (int i = 0; i < list.Count; i++)
		{
			int num3 = 0;
			num3 = ((!(list[i].SoldierId != list2[i].SoldierId)) ? (list2[i].Total - list[i].CurCnt) : list2[i].Total);
			int stock2 = GameManagers.Instance.StockController.GetStock(list2[i].SoldierId);
			int total = list2[i].Total;
			float num4 = (float)total * 0.04f;
			int num5 = Mathf.Min(stock2, num3);
			if (list[i].SoldierId != list2[i].SoldierId)
			{
				list2[i].CurCnt = num3;
			}
			else
			{
				list2[i].CurCnt = list[i].CurCnt + num3;
			}
			dictionary.Add(list2[i].SoldierId, num5);
			int num6 = Mathf.FloorToInt((float)num5 / num4);
			if (num6 > 25)
			{
				num6 = 25;
			}
			dictionary2.Add(list2[i].SoldierId, num2 + num6);
		}
		return dictionary2.Values.OrderByDescending((int t) => t).ToList()[0];
	}

	private void RenderNewSoldierItem(int index, GObject obj)
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		if (obj is UI_TroopsItem uI_TroopsItem)
		{
			uI_TroopsItem.Type.selectedIndex = 1;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(newSoldiers[index]);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
			int stock = GameManagers.Instance.StockController.GetStock(soldier.Id);
			int num = soldierFormationNumber * 5;
			uI_TroopsItem.IconLoader.IconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_TroopsItem.SoulStoneLevel, soldier.PotentialLevel, new List<int>());
			uI_TroopsItem.FrameLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(uI_TroopsItem.FrameLoader, soldier.PotentialLevel);
			((GObject)uI_TroopsItem.Amount_t).text = $"[color={Singleton<GvGInstanceZone>.Instance.GetReplenishSoldierNumTextColor(stock, num)}]{stock}[/color]/{num}";
			((GObject)uI_TroopsItem).onClick.Set(new EventCallback0(OpenLegionPanel));
		}
	}

	private void NewSoldiersListInit()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Dialog.NewSoldiers.onClickItem.Set(new EventCallback0(OpenLegionPanel));
	}

	private void RenderNewSoldiers(List<string> _newSoldiers)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		newSoldiers = _newSoldiers;
		Dialog.NewSoldiers.itemRenderer = new ListItemRenderer(RenderNewSoldierItem);
		Dialog.NewSoldiers.numItems = newSoldiers.Count;
		SetCurrentDialogType();
	}

	private void OpenLegionPanel()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Style", "10" },
			{ "Spine", null },
			{ "IslandComeAgainSelectSoldiers", newSoldiers },
			{ "OnlyUnlocked", 1 }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	private void ConfirmEvent()
	{
		ILRequestHelper<GvGMode2ShipFillUpResponse>.Request((EventContext)null, (Func<Task<GvGMode2ShipFillUpResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode2ShipFillUp(newSoldiers, Singleton<GvGInstanceZone>.Instance.FormationId, Singleton<GvGInstanceZone>.Instance.ShipId)), (Action<GvGMode2ShipFillUpResponse>)delegate(GvGMode2ShipFillUpResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				End();
				List<string> changeSoldiers = newSoldiers.Where((string t) => !Singleton<GvGInstanceZone>.Instance.CurrentSoldiers.Contains(t)).ToList();
				Singleton<GvGInstanceZone>.Instance.CurrentSoldiers = newSoldiers;
				Singleton<GvGInstanceZone>.Instance.CurrentState = eShipSummaryState.InCampBaseShipFillingUp;
				GvGWorldMapController.Instance.UpdateMySummaryState(2);
				Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo = GetNewSoldiersInfo(changeSoldiers);
				GameLocalDataManager.SaveIslandComeAgainSoldiers(newSoldiers);
				Dictionary<string, object> parameters = new Dictionary<string, object> { 
				{
					"ReplenishData",
					Singleton<GvGInstanceZone>.Instance.GetShipFillingUpRequest()
				} };
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ReplenishTroopsPanel.Name, parameters);
			}
		});
	}

	private List<ShipSummaryUnitInfo> GetNewSoldiersInfo(List<string> changeSoldiers)
	{
		List<ShipSummaryUnitInfo> list = new List<ShipSummaryUnitInfo>();
		List<string> list2 = oldUnitInfo.Select((ShipSummaryUnitInfo soldierInfo) => soldierInfo.SoldierId).ToList();
		foreach (string newSoldier in newSoldiers)
		{
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(newSoldier);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(newSoldier, soldierLevel);
			int num = GameManagers.Instance.StockController.GetStock(newSoldier);
			if (changeSoldiers.Contains(newSoldier))
			{
				num = 0;
			}
			else if (list2.Contains(newSoldier))
			{
				num = oldUnitInfo[list2.IndexOf(newSoldier)].CurCnt;
			}
			int curCnt = Mathf.Min(num, soldierFormationNumber * 5);
			long[] soldierEquippedItems = GameManagers.Instance.SoldierEquipmentManager.GetSoldierEquippedItems(newSoldier);
			List<int> list3 = new List<int>();
			for (int num2 = 0; num2 < soldierEquippedItems.Length; num2++)
			{
				list3.Add((int)soldierEquippedItems[num2]);
			}
			ShipSummaryUnitInfo item = new ShipSummaryUnitInfo
			{
				SoldierId = newSoldier,
				PotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(newSoldier),
				PerTeamMemberCnt = soldierFormationNumber,
				Total = soldierFormationNumber * 5,
				CurCnt = curCnt,
				EquippedItems = list3.ToArray(),
				SoldierLevel = soldierLevel
			};
			list.Add(item);
		}
		return list;
	}
}
