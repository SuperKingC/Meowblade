using System;
using System.Collections;
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
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Rank.Helpers;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_ReplenishTroopsPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_ReplenishTroopsDialog Dialog;

	public const string URL = "ui://k2sprg26in7b39";

	public static string Name = "UI_ReplenishTroopsPanel";

	private WaitForSeconds perSecond;

	private Coroutine playReplenishCoroutine;

	private eShipSummaryState currentState;

	private List<ShipSummaryUnitInfo> currentUnitInfo = new List<ShipSummaryUnitInfo>();

	private Dictionary<string, int> fillUpTimestamp = new Dictionary<string, int>();

	private int startFillUpTimestamp;

	private List<ShipSummaryUnitInfo> oldGroupInfo = new List<ShipSummaryUnitInfo>();

	private Dictionary<string, int> stockInfoBeforeFillUp = new Dictionary<string, int>();

	public static string GetURL()
	{
		return "ui://k2sprg26in7b39";
	}

	public static UI_ReplenishTroopsPanel CreateInstance()
	{
		return (UI_ReplenishTroopsPanel)(object)UIPackage.CreateObject("IslandComeAgain", "ReplenishTroopsPanel");
	}

	public static UI_ReplenishTroopsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReplenishTroopsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_ReplenishTroopsDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		if (playReplenishCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(playReplenishCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("ReplenishData", out var value))
		{
			S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest = value as S2C_ChangeShipSummaryStateShipFillingUp.Request;
			UpdateDialogInfoOnStateChange(dataRequest);
		}
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
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(StartReplenish));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnBattleEnd);
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Combine(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(UpdateDialogInfoOnStateChange));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.CloseBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(StartReplenish));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnBattleEnd);
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Remove(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(UpdateDialogInfoOnStateChange));
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

	private void SetDialogType()
	{
		Dialog.Type.selectedIndex = ((currentState == eShipSummaryState.InCampBaseShipFillingUp) ? 1 : 0);
		if (Dialog.Type.selectedIndex == 0)
		{
			int num = GetExpectedFillUpTime() - (int)GameController.Instance.GetServerTime();
			if (num > 0)
			{
				((GObject)Dialog.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText294") + " " + UiHelper.ParseTime_Foo(num);
			}
			else
			{
				((GObject)Dialog.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText294") + " ----";
			}
		}
	}

	private int GetExpectedFillUpTime()
	{
		List<ShipSummaryUnitInfo> list = currentUnitInfo;
		List<ShipSummaryUnitInfo> list2 = new List<ShipSummaryUnitInfo>();
		foreach (ShipSummaryUnitInfo item2 in list)
		{
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(item2.SoldierId);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(item2.SoldierId, soldierLevel);
			int stock = GameManagers.Instance.StockController.GetStock(item2.SoldierId);
			int curCnt = Mathf.Min(stock, soldierFormationNumber * 5);
			ShipSummaryUnitInfo item = new ShipSummaryUnitInfo
			{
				SoldierId = item2.SoldierId,
				Total = soldierFormationNumber * 5,
				CurCnt = curCnt
			};
			list2.Add(item);
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		int num = (int)GameController.Instance.GetServerTime();
		for (int i = 0; i < list.Count; i++)
		{
			int num2 = 0;
			num2 = ((!(list[i].SoldierId != list2[i].SoldierId)) ? (list2[i].Total - list[i].CurCnt) : list2[i].Total);
			int stock2 = GameManagers.Instance.StockController.GetStock(list2[i].SoldierId);
			int total = list2[i].Total;
			float num3 = (float)total * 0.04f;
			int num4 = Mathf.Min(stock2, num2);
			if (list[i].SoldierId != list2[i].SoldierId)
			{
				list2[i].CurCnt = num2;
			}
			else
			{
				list2[i].CurCnt = list[i].CurCnt + num2;
			}
			dictionary.Add(list2[i].SoldierId, num4);
			int num5 = Mathf.FloorToInt((float)num4 / num3);
			if (num5 > 25)
			{
				num5 = 25;
			}
			dictionary2.Add(list2[i].SoldierId, num + num5);
		}
		return dictionary2.Values.OrderByDescending((int t) => t).ToList()[0];
	}

	private void RenderDialogInfo()
	{
		RenderOldSoldiers();
		RenderStockList();
	}

	private void RenderOldSoldiers()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		int count = currentUnitInfo.Count;
		Dialog.OldSoldiers.itemRenderer = new ListItemRenderer(RenderOldSoldierItem);
		Dialog.OldSoldiers.numItems = count;
	}

	private void RenderOldSoldierItem(int index, GObject obj)
	{
		if (obj is UI_TroopsItem uI_TroopsItem)
		{
			uI_TroopsItem.Type.selectedIndex = 1;
			ShipSummaryUnitInfo shipSummaryUnitInfo = currentUnitInfo[index];
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

	private void RenderStockList()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		int numItems = ((stockInfoBeforeFillUp.Count <= 0) ? currentUnitInfo.Count : stockInfoBeforeFillUp.Count);
		Dialog.Stock.itemRenderer = new ListItemRenderer(RenderStockItem);
		Dialog.Stock.numItems = numItems;
	}

	private void RenderStockItem(int index, GObject obj)
	{
		if (obj is UI_SoldierStock uI_SoldierStock)
		{
			ShipSummaryUnitInfo shipSummaryUnitInfo = currentUnitInfo[index];
			string soldierId = shipSummaryUnitInfo.SoldierId;
			int num = ((stockInfoBeforeFillUp.Count <= 0) ? GameManagers.Instance.StockController.GetStock(soldierId) : GetStockInfoBeforeFillUp(soldierId));
			string replenishSoldierStockTextColor = Singleton<GvGInstanceZone>.Instance.GetReplenishSoldierStockTextColor(num, shipSummaryUnitInfo.CurCnt, shipSummaryUnitInfo.Total);
			((GObject)uI_SoldierStock.Amount_t).text = $"[color={replenishSoldierStockTextColor}]{num}[/color]";
		}
	}

	private int GetStockInfoBeforeFillUp(string soldierId)
	{
		int value;
		return stockInfoBeforeFillUp.TryGetValue(soldierId, out value) ? value : GameManagers.Instance.StockController.GetStock(soldierId);
	}

	private void SimulativeReplenish()
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		if (fillUpTimestamp.Count > 0 && oldGroupInfo.Count > 0 && stockInfoBeforeFillUp.Count > 0)
		{
			int fillUpTime = fillUpTimestamp.Values.OrderByDescending((int t) => t).ToArray()[0];
			perSecond = new WaitForSeconds(1f);
			if (playReplenishCoroutine == null)
			{
				playReplenishCoroutine = FGUIManager.Instance.OpenIEnumerator(PlayReplenish(fillUpTime));
			}
		}
	}

	private IEnumerator PlayReplenish(int fillUpTime)
	{
		for (int currentTime = startFillUpTimestamp; currentTime < fillUpTime; currentTime = (int)GameController.Instance.GetServerTime())
		{
			int remainingTime = fillUpTime - currentTime;
			for (int i = 0; i < currentUnitInfo.Count; i++)
			{
				ShipSummaryUnitInfo soldierInfo = currentUnitInfo[i];
				if (!fillUpTimestamp.ContainsKey(soldierInfo.SoldierId))
				{
					continue;
				}
				int finishTime = fillUpTimestamp[soldierInfo.SoldierId];
				if (finishTime <= currentTime)
				{
					continue;
				}
				UI_TroopsItem oldItem = ((GComponent)Dialog.OldSoldiers).GetChildAt(i) as UI_TroopsItem;
				if (oldItem == null)
				{
					continue;
				}
				UI_SoldierStock stockItem = ((GComponent)Dialog.Stock).GetChildAt(i) as UI_SoldierStock;
				if (stockItem == null)
				{
					continue;
				}
				int initCnt;
				int realReplenishCnt = GetRealReplenishCnt(soldierInfo, out initCnt);
				int realReplenishTime = finishTime - startFillUpTimestamp;
				int curTime = currentTime - startFillUpTimestamp;
				int realCnt = Mathf.Max(0, Mathf.CeilToInt((float)curTime / (float)realReplenishTime * (float)realReplenishCnt));
				int realStock = GetStockInfoBeforeFillUp(soldierInfo.SoldierId) - realCnt;
				int curCnt = initCnt + realCnt;
				if (((GObject)oldItem.Amount_t).data != null)
				{
					int startValue = (int)((GObject)oldItem.Amount_t).data;
					GTween.To((float)startValue, (float)curCnt, 0.8f).SetEase((EaseType)19).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
					{
						if (currentState == eShipSummaryState.InCampBaseShipFillingUp)
						{
							int num = (int)tweener.value.x;
							((GObject)oldItem.Amount_t).text = $"[color={Singleton<GvGInstanceZone>.Instance.GetReplenishSoldierNumTextColor(num, soldierInfo.Total)}]{num}[/color]/{soldierInfo.Total}";
						}
					});
				}
				else
				{
					((GObject)oldItem.Amount_t).text = $"[color={Singleton<GvGInstanceZone>.Instance.GetReplenishSoldierNumTextColor(curCnt, soldierInfo.Total)}]{curCnt}[/color]/{soldierInfo.Total}";
				}
				((GObject)oldItem.Amount_t).data = curCnt;
				if (((GObject)stockItem.Amount_t).data != null)
				{
					int startValue2 = (int)((GObject)stockItem.Amount_t).data;
					GTween.To((float)startValue2, (float)realStock, 0.8f).SetEase((EaseType)19).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
					{
						if (currentState == eShipSummaryState.InCampBaseShipFillingUp)
						{
							int num = (int)tweener.value.x;
							((GObject)stockItem.Amount_t).text = $"[color={Singleton<GvGInstanceZone>.Instance.GetReplenishSoldierStockTextColor(num, realCnt, soldierInfo.Total)}]{num}[/color]";
						}
					});
				}
				else
				{
					((GObject)stockItem.Amount_t).text = $"[color={Singleton<GvGInstanceZone>.Instance.GetReplenishSoldierStockTextColor(realStock, realCnt, soldierInfo.Total)}]{realStock}[/color]";
				}
				((GObject)stockItem.Amount_t).data = realStock;
				yield return null;
			}
			((GObject)Dialog.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText318") + " " + UiHelper.ParseTime_Foo(remainingTime);
			yield return perSecond;
		}
	}

	private int GetRealReplenishCnt(ShipSummaryUnitInfo newSoldier, out int initCnt)
	{
		bool flag = false;
		int num = 0;
		initCnt = 0;
		for (int i = 0; i < oldGroupInfo.Count; i++)
		{
			if (string.Equals(oldGroupInfo[i].SoldierId, newSoldier.SoldierId))
			{
				flag = true;
				num = newSoldier.CurCnt - oldGroupInfo[i].CurCnt;
				initCnt = oldGroupInfo[i].CurCnt;
				break;
			}
		}
		return (!flag) ? newSoldier.Total : num;
	}

	private void UpdateDialogInfoOnStateChange(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		oldGroupInfo.Clear();
		fillUpTimestamp.Clear();
		stockInfoBeforeFillUp.Clear();
		currentState = (eShipSummaryState)dataRequest.ShipSummaryState;
		currentUnitInfo = dataRequest.FillUpSoldiers;
		if (currentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			fillUpTimestamp = new Dictionary<string, int>(dataRequest.FillUpTimestamp);
			startFillUpTimestamp = dataRequest.StartFillUpTimestamp;
			oldGroupInfo = dataRequest.StartFillUpSoldiers.Clone();
			stockInfoBeforeFillUp = new Dictionary<string, int>(dataRequest.StockInfoBeforeFillUp);
		}
		SetDialogType();
		RenderDialogInfo();
		SimulativeReplenish();
	}

	private void StartReplenish()
	{
		ILRequestHelper<GvGMode2ShipFillUpResponse>.Request((EventContext)null, (Func<Task<GvGMode2ShipFillUpResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode2ShipFillUp(Singleton<GvGInstanceZone>.Instance.CurrentSoldiers, Singleton<GvGInstanceZone>.Instance.FormationId, Singleton<GvGInstanceZone>.Instance.ShipId)), (Action<GvGMode2ShipFillUpResponse>)delegate(GvGMode2ShipFillUpResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Dialog.Type.selectedIndex = 1;
				Singleton<GvGInstanceZone>.Instance.CurrentState = eShipSummaryState.InCampBaseShipFillingUp;
				GvGWorldMapController.Instance.UpdateMySummaryState(2);
			}
		});
	}
}
