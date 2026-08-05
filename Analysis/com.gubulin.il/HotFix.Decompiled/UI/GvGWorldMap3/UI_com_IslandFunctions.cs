using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace UI.GvGWorldMap3;

public class UI_com_IslandFunctions : GComponent
{
	public Controller Type;

	public Controller ShowRemainCount;

	public UI_btn_RepeatedAttack RepeatedAttack;

	public UI_btn_Operation_Goto_Large Goto;

	public UI_btn_OperationSP OtherOperation;

	public GButton Help;

	public const string URL = "ui://4eq8fgd2jxsodn";

	public static string Name = "UI_com_IslandFunctions";

	private eIslandUiAction _uiAction;

	private int _islandId;

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsodn";
	}

	public static UI_com_IslandFunctions CreateInstance()
	{
		return (UI_com_IslandFunctions)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandFunctions");
	}

	public static UI_com_IslandFunctions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandFunctions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsodn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		ShowRemainCount = ((GComponent)this).GetController("ShowRemainCount");
		RepeatedAttack = (UI_btn_RepeatedAttack)(object)((GComponent)this).GetChild("RepeatedAttack");
		Goto = (UI_btn_Operation_Goto_Large)(object)((GComponent)this).GetChild("Goto");
		OtherOperation = (UI_btn_OperationSP)(object)((GComponent)this).GetChild("OtherOperation");
		Help = (GButton)((GComponent)this).GetChild("Help");
	}

	public void OnRender(IslandStateModel islandState)
	{
		string shipIdStaySomeIsland = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipIdStaySomeIsland(islandState.IslandId);
		List<IslandUiAction> islandActions = islandState.IslandValidUiActions(shipIdStaySomeIsland);
		_uiAction = islandActions[0].UiAction;
		_islandId = islandState.IslandId;
		ClearOperations();
		bool isAttack;
		if (islandActions.Count > 0)
		{
			Type.selectedIndex = ((islandActions.Count > 1) ? 1 : 0);
			isAttack = SetOtherOperation();
			SetGotoBtn();
			SetRepeatedAttackVisible();
		}
		void ClearOperations()
		{
			((GObject)Goto).onClick.Clear();
			((GObject)OtherOperation).onClick.Clear();
			OtherOperation.State.SetSelectedIndex(0);
			((GObject)RepeatedAttack).onClick.Clear();
		}
		void OnClickWatching(EventContext context)
		{
			if (islandState.DetailInfo.Pid != -1 && islandState.DetailInfo.ExternalSocketPort != -1)
			{
				GvGWorldMapController.Instance.EnterIsland(islandState.DetailInfo.Pid, islandState.DetailInfo.ExternalSocketPort, islandState.IslandId);
			}
		}
		static void OnRepeatedAttackClick()
		{
			UI_com_IslandCardLoader.OnClickRepeatedAttack?.Invoke();
		}
		static void OperationExecute(EventContext context)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			string value = ((GObject)context.sender).data.ToString();
			SharedMessenger.Broadcast("ON_ISLAND_ACTION_EXECUTE", (int)(eIslandAction)Enum.Parse(typeof(eIslandAction), value));
		}
		void SetGotoBtn()
		{
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			if (islandActions.Count > 1)
			{
				IslandUiAction islandUiAction = islandActions[1];
				if (islandUiAction.UiAction == eIslandUiAction.Watching)
				{
					Goto.Type.selectedIndex = 1;
					((GObject)Goto).onClick.Set(new EventCallback1(OnClickWatching));
				}
				else
				{
					Goto.Type.selectedIndex = 0;
					((GObject)Goto).data = islandUiAction.ActionType;
					((GObject)Goto).onClick.Set(new EventCallback1(OperationExecute));
				}
				((GObject)Goto).enabled = islandUiAction.ActionEnabled;
			}
		}
		bool SetOtherOperation()
		{
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			IslandUiAction islandUiAction = islandActions[0];
			((GObject)OtherOperation).data = islandUiAction.ActionType;
			((GObject)OtherOperation).onClick.Set(new EventCallback1(OperationExecute));
			((GObject)OtherOperation).enabled = islandUiAction.ActionEnabled;
			OtherOperation.Type.selectedIndex = (int)islandUiAction.UiAction;
			((GObject)Help).onClick.Set(new EventCallback1(OnClickRebellionHelp));
			RefreshRemainCount();
			if (!(islandUiAction.ActionType == "Attack"))
			{
				return false;
			}
			bool flag = IslandStateModelExtension.IslandAttackActionCheck();
			OtherOperation.State.SetSelectedIndex((!flag) ? 1 : 0);
			return true;
		}
		void SetRepeatedAttackVisible()
		{
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			bool flag = Define.IsGvGAutomationOpen();
			bool flag2 = Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o代理作战_LimitTime > -1;
			bool flag3 = islandState.IsBossIsland();
			bool flag4 = WorldMapConfigHelper.Configs.TryGetIsland(islandState.IslandId).Props.Type == eIslandType.Moon;
			((GObject)RepeatedAttack).visible = isAttack && flag2 && (flag3 || flag4) && flag;
			RepeatedAttack.State.SetSelectedIndex(OtherOperation.State.selectedIndex);
			((GObject)RepeatedAttack).enabled = ((GObject)OtherOperation).enabled;
			((GObject)RepeatedAttack).onClick.Add(new EventCallback0(OnRepeatedAttackClick));
		}
	}

	private void RefreshRemainCount()
	{
		DailySuppressBonusModel dailySuppressBonusModel = Singleton<WorldStateManager>.Instance.Data.DailySuppressBonusModel;
		string zone = WorldMapConfigHelper.Configs.TryGetIsland(_islandId).Props.GDEData.Zone;
		DailySuppressBonusTimesPerZone zoneData = dailySuppressBonusModel.GetZoneData(zone);
		bool flag = dailySuppressBonusModel.ShouldShowRemainCount(zone);
		flag &= _uiAction == eIslandUiAction.SuppressRebellion;
		ShowRemainCount.SetSelectedIndex(flag ? 1 : 0);
		int remainCount = zoneData.GetRemainCount();
		int remainCount2 = dailySuppressBonusModel.GetRemainCount();
		((GObject)OtherOperation.remainCount).text = $"{remainCount}/{zoneData.DailySuppressBonusTimesLimit}";
		((GObject)OtherOperation.remainCountTotal).text = $"{remainCount2}/{dailySuppressBonusModel.GetDailyLimit()}";
		OtherOperation.ShowRemainCount.SetSelectedIndex(flag ? 1 : 0);
		bool flag2 = remainCount2 <= 0;
		bool flag3 = remainCount <= 0;
		OtherOperation.ColorCurrent.SetSelectedIndex(flag3 ? 1 : 0);
		OtherOperation.ColorTotal.SetSelectedIndex(flag2 ? 1 : 0);
	}

	private void OnClickRebellionHelp(EventContext context)
	{
		context.StopPropagation();
		UnityUiService.Instance.OpenPanel(UI_main_SuppressBonusLimitPanel.Name, new Dictionary<string, object> { 
		{
			"OnValueChange",
			new Action(RefreshRemainCount)
		} });
	}
}
