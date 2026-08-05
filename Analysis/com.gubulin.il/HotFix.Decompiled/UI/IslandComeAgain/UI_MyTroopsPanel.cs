using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using GvG2.Common.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_MyTroopsPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_MyTroopsDialog Dialog;

	public const string URL = "ui://k2sprg26in7b1a";

	public static string Name = "UI_MyTroopsPanel";

	private eShipSummaryState currentState;

	private int shipId;

	private WaitForSeconds perSecond;

	private Coroutine updateReplenishCountDown;

	public static string GetURL()
	{
		return "ui://k2sprg26in7b1a";
	}

	public static UI_MyTroopsPanel CreateInstance()
	{
		return (UI_MyTroopsPanel)(object)UIPackage.CreateObject("IslandComeAgain", "MyTroopsPanel");
	}

	public static UI_MyTroopsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyTroopsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_MyTroopsDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		if (updateReplenishCountDown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(updateReplenishCountDown);
		}
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MyTroops.Close", Mask);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("ShipEntityId", out var value))
		{
			shipId = (int)value;
		}
		SetCurrentPanelType(Singleton<GvGInstanceZone>.Instance.GetShipFillingUpRequest());
		ShowLegionPos();
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MyTroops.Close", Mask);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ReplenishBtn).onClick.Add(new EventCallback0(OpenReplenishTroopsPanel));
		((GObject)Dialog.ChangeTroopsBtn).onClick.Add(new EventCallback0(OpenChangeTroopsPanel));
		SharedMessenger.AddListener<string>("ISLAND_COME_AGAIN_UPDATE_FORMATION", UpdateCurrentLegionFormation);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnBattleEnd);
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Combine(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(SetCurrentPanelType));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.ReplenishBtn).onClick.Remove(new EventCallback0(OpenReplenishTroopsPanel));
		((GObject)Dialog.ChangeTroopsBtn).onClick.Remove(new EventCallback0(OpenChangeTroopsPanel));
		SharedMessenger.RemoveListener<string>("ISLAND_COME_AGAIN_UPDATE_FORMATION", UpdateCurrentLegionFormation);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnBattleEnd);
		S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent = (Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>)Delegate.Remove(S2C_ChangeShipSummaryStateShipFillingUp.OnPushEvent, new Action<S2C_ChangeShipSummaryStateShipFillingUp.Request>(SetCurrentPanelType));
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

	private void SetCurrentPanelType(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		currentState = (eShipSummaryState)(dataRequest?.ShipSummaryState ?? ((int)Singleton<GvGInstanceZone>.Instance.CurrentState));
		if (currentState == eShipSummaryState.InCampBaseShipFillingUp || currentState == eShipSummaryState.InCampBase || currentState == eShipSummaryState.InCampBaseShipFillUpFinish || currentState == eShipSummaryState.InCampBaseShipButDead)
		{
			Dialog.Type.selectedIndex = 0;
			((GObject)Dialog.FormationSketchMap).onClick.Clear();
			((GObject)Dialog.Formation).onClick.Clear();
			((GObject)Dialog.Formation.MainFormation).touchable = true;
		}
		else
		{
			Dialog.Type.selectedIndex = 1;
			((GObject)Dialog.FormationSketchMap).onClick.Set(new EventCallback0(ShowDisableTip));
			((GObject)Dialog.Formation).onClick.Set(new EventCallback0(ShowDisableTip));
			((GObject)Dialog.Formation.MainFormation).touchable = false;
		}
		Dialog.SetControllerPageText();
		if (currentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			ShowLegionPos();
		}
		bool flag = currentState == eShipSummaryState.InCampBaseShipFillingUp;
		if (flag && dataRequest != null)
		{
			int endFillUpTime = dataRequest.FillUpTimestamp.Values.OrderByDescending((int t) => t).ToArray()[0];
			int startFillUpTimestamp = dataRequest.StartFillUpTimestamp;
			perSecond = new WaitForSeconds(1f);
			updateReplenishCountDown = FGUIManager.Instance.OpenIEnumerator(UpdateFillUpTime(endFillUpTime, startFillUpTimestamp));
		}
		Dialog.ReplenishBtn.Type.selectedIndex = (flag ? 1 : 0);
	}

	private IEnumerator UpdateFillUpTime(int endFillUpTime, int startFillUpTime)
	{
		for (int remainingTime = endFillUpTime - startFillUpTime; remainingTime > 0; remainingTime = endFillUpTime - (int)GameController.Instance.GetServerTime())
		{
			((GObject)Dialog.ReplenishBtn.Countdown).text = UiHelper.ParseTime_Foo(remainingTime) ?? "";
			yield return perSecond;
		}
	}

	private void ShowDisableTip()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText316") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText317") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void ShowLegionPos()
	{
		Dialog.FormationSketchMap.SetOurPos(Singleton<GvGInstanceZone>.Instance.FormationId, Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo, Dialog.Type.selectedIndex);
		Dialog.Formation.CurFormationInit(Singleton<GvGInstanceZone>.Instance.FormationId, shipId);
	}

	private void UpdateCurrentLegionFormation(string formationId)
	{
		Dialog.FormationSketchMap.SetOurPos(formationId, Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo, Dialog.Type.selectedIndex);
	}

	private void OpenReplenishTroopsPanel()
	{
		string tip;
		if (currentState == eShipSummaryState.DuringFlight || currentState == eShipSummaryState.BackToCampBaseAndShipFillUp)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText312") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		else if (currentState == eShipSummaryState.Fighting)
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText314") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
		}
		else if (currentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			List<string> arg3 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText315") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg3, 1, arg3: false);
		}
		else if (!Singleton<GvGInstanceZone>.Instance.CanReplenish(out tip))
		{
			List<string> arg4 = new List<string> { tip };
			SharedMessenger.Broadcast("SHOW_TIPS", arg4, 1, arg3: false);
		}
		else if (currentState == eShipSummaryState.Stay_NotPeaceIsland || currentState == eShipSummaryState.Stay_PeaceIsland)
		{
			GoToMainIsland(eGotoIslandOperation.ReplenishLegionGroup);
		}
		else
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { 
			{
				"ReplenishData",
				Singleton<GvGInstanceZone>.Instance.GetShipFillingUpRequest()
			} };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ReplenishTroopsPanel.Name, parameters);
		}
	}

	private void OpenChangeTroopsPanel()
	{
		if (currentState == eShipSummaryState.DuringFlight || currentState == eShipSummaryState.BackToCampBaseAndShipFillUp)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText312") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		else if (currentState == eShipSummaryState.Fighting)
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText314") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
		}
		else if (currentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			List<string> arg3 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText315") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText313") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg3, 1, arg3: false);
		}
		else if (currentState == eShipSummaryState.Stay_NotPeaceIsland || currentState == eShipSummaryState.Stay_PeaceIsland)
		{
			GoToMainIsland(eGotoIslandOperation.ChangeLegionGroup);
		}
		else
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { 
			{
				"CurrentSoldiersInfo",
				Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo
			} };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChangeTroopsPanel.Name, parameters);
		}
	}

	private void GoToMainIsland(eGotoIslandOperation operation)
	{
		string myCampIslandId = GvGWorldMapController.Instance.GetMyCampIslandId();
		if (GvGWorldMapController.Instance.OnSelectRoute(myCampIslandId, operation))
		{
			End();
		}
	}
}
