using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.GvGShipDetail;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_main_IslandOutput : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static TimerCallback _003C_003E9__38_4;

		public static TimerCallback _003C_003E9__38_5;

		internal void _003COnConfirmToMine_003Eb__38_4(object p)
		{
			"GvG3StartCollectingTip".ToShowLanguageTip();
		}

		internal void _003COnConfirmToMine_003Eb__38_5(object p)
		{
			"GvG3CancelCollectingTip".ToShowLanguageTip();
		}
	}

	public GGraph back;

	public UI_com_IslandOutput Dialog;

	public const string URL = "ui://4eq8fgd2o8el2x";

	public static string Name = "UI_main_IslandOutput";

	public const string IslandDetail = "IslandDetail";

	private ShipStateModel _stateData;

	private int _islandId;

	private List<GvGMode3IslandOutputModel> _resource = new List<GvGMode3IslandOutputModel>();

	private HashSet<string> ChangedSelectedMinerals;

	private Coroutine _updateLimitedTimestamp;

	private bool IsShowCurSelected = false;

	private int StorehouseLimit = -1;

	private GvGMode3IslandDetailInfo _islandDetailInfo;

	private bool IsSelectedMineralChanged => ChangedSelectedMinerals.Count > 0;

	public static string GetURL()
	{
		return "ui://4eq8fgd2o8el2x";
	}

	public static UI_main_IslandOutput CreateInstance()
	{
		return (UI_main_IslandOutput)(object)UIPackage.CreateObject("GvGWorldMap3", "main_IslandOutput");
	}

	public static UI_main_IslandOutput CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandOutput).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2o8el2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_IslandOutput)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		if (_updateLimitedTimestamp != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateLimitedTimestamp);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_resource = (parameters.TryGetValue("Output", out var value) ? (value as List<GvGMode3IslandOutputModel>) : new List<GvGMode3IslandOutputModel>());
		_resource?.Sort(GvGMode3IslandOutputModel.CompareTo);
		Dialog.State.selectedIndex = (parameters.TryGetValue("DialogType", out var value2) ? ((int)value2) : 0);
		_islandId = (parameters.TryGetValue("IslandId", out var value3) ? ((int)value3) : 0);
		object value4;
		string shipId = (parameters.TryGetValue("CurrentShipId", out value4) ? value4.ToString() : string.Empty);
		_islandDetailInfo = (GvGMode3IslandDetailInfo)parameters["IslandDetail"];
		((GObject)Dialog.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(_islandId).Name;
		_stateData = Singleton<WorldStateManager>.Instance.TryGetMyShip(shipId);
		ChangedSelectedMinerals = new HashSet<string>();
		IsShowCurSelected = false;
		StorehouseLimit = -1;
		Singleton<GvGStoreHouseManager>.Instance.GetRealtimeStockLimit(delegate(C2S_GetRealTimeStorehouseLimitParModel.Response res)
		{
			if (!((GObject)this).isDisposed)
			{
				StorehouseLimit = res.StorehouseLimit;
				if (Dialog.State.selectedIndex == 1)
				{
					if (_stateData.State == eShipState.Collecting && _stateData.StayIslandId == _islandId)
					{
						IsShowCurSelected = true;
						Singleton<GvGShipUiInfoManager>.Instance.SyncShipCollectingDetailInfo(_stateData.EntityId, delegate
						{
							if (!((GObject)this).isDisposed)
							{
								RenderResourceList();
							}
						});
					}
					else
					{
						RenderResourceList();
						SetAllResourceSelected();
					}
				}
				else
				{
					RenderResourceList();
				}
			}
		});
	}

	public void OnShow()
	{
		_updateLimitedTimestamp = FGUIManager.Instance.OpenIEnumerator(UpdateLimitedTimestamp());
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(OnClickClosePanel));
		((GObject)Dialog.exitButton).onClick.Add(new EventCallback0(OnClickClosePanel));
		((GButton)Dialog.SelectAll).onChanged.Set(new EventCallback0(OnClickSelectAll));
		((GObject)Dialog.SaveCollectConfig).onClick.Set(new EventCallback1(OnClickSaveCollectConfig));
		((GObject)Dialog.descSelect).onClickLink.Set(new EventCallback1(UI_WorkerPage.ShowMiningPriorityDescTip));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.exitButton).onClick.Clear();
		((GButton)Dialog.SelectAll).onChanged.Clear();
		((GObject)Dialog.SaveCollectConfig).onClick.Clear();
		((GObject)Dialog.descSelect).onClickLink.Clear();
	}

	private void ClosePanel()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderResourceList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.Output.itemRenderer = new ListItemRenderer(RenderResourceItem);
		Dialog.Output.numItems = _resource.Count;
	}

	private void SetAllResourceSelected()
	{
		((GButton)Dialog.SelectAll).selected = true;
		OnClickSelectAll();
	}

	private bool IsAllSelected()
	{
		for (int i = 0; i < Dialog.Output.numItems; i++)
		{
			if (((GComponent)Dialog.Output).GetChildAt(i) is UI_com_Output { IsSelected: false })
			{
				return false;
			}
		}
		return true;
	}

	private void RenderResourceItem(int index, GObject obj)
	{
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		UI_com_Output btn = obj as UI_com_Output;
		if (btn != null)
		{
			GvGMode3IslandOutputModel itemModel = _resource[index];
			((GObject)btn.ItemName).text = itemModel.ItemName;
			((GObject)btn.RemainingNumber).text = itemModel.RemainingStock.ToString();
			btn.Icon.Source.selectedIndex = 0;
			((GObject)btn.Output).text = itemModel.ExpectedOutput ?? "";
			((GObject)btn.n13).text = string.Format("/{0}{1}", (int)(GDMgr.Get<GDEProductData>(itemModel.ProductId).Time / 60f), "CsharpCodeZhTcText304".ToLanguage());
			int num = (_islandDetailInfo.CurrentCollectingItemStock?.Find((RItem x) => x.ItemId == itemModel.ItemId))?.cnt ?? Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemModel.ItemId);
			((GObject)btn.GvGStoreHouseStock).text = num.ToString();
			btn.Type.selectedIndex = Dialog.State.selectedIndex;
			FGUIManager.Instance.SetItemIconAndFrame(btn.Icon.Icon, itemModel.ItemId);
			((GObject)btn).onClick.Set((EventCallback0)delegate
			{
				OnClickResourceItem(btn);
			});
			((GObject)btn.ExtraInfo).touchable = btn.Type.selectedIndex == 0;
			((GObject)btn.ExtraInfo).data = itemModel;
			((GObject)btn.ExtraInfo).onClick.Set(new EventCallback1(DisplayResourceSourceInfo));
			((GObject)btn).data = itemModel;
			if (StorehouseLimit > 0)
			{
				btn.StockType.selectedIndex = ((num >= StorehouseLimit) ? 1 : 0);
			}
			if (IsShowCurSelected)
			{
				MiningState miningStateForModelId = _stateData.GetMiningStateForModelId(itemModel.ModelId);
				btn.state.SetSelectedIndex((int)miningStateForModelId);
				btn.InitState = btn.state.selectedIndex;
			}
			if (itemModel.HasExtraInfo)
			{
				btn.HasExtraInfo.selectedIndex = 1;
				RenderExtraInfo(btn.ExtraInfo, itemModel);
			}
			else
			{
				btn.HasExtraInfo.selectedIndex = 0;
			}
		}
	}

	private void RenderExtraInfo(UI_com_SpecialRecource extraInfo, GvGMode3IslandOutputModel itemModel)
	{
		if (itemModel.Type == eIslandOutputModel.Extra)
		{
			if (itemModel.IsShared)
			{
				extraInfo.InfoType.selectedIndex = 1;
				UI_com_ShipAvatarSmall avatar = extraInfo.Icon.component as UI_com_ShipAvatarSmall;
				avatar.CampId.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
				GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", itemModel.ShareUserId, null, delegate(Sprite sprite)
				{
					//IL_0017: Unknown result type (might be due to invalid IL or missing references)
					//IL_0021: Expected O, but got Unknown
					avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
				}));
			}
			else
			{
				extraInfo.InfoType.selectedIndex = 0;
			}
			((GObject)extraInfo.CountDown).text = UiHelper.ParseTime(itemModel.RemainingTime);
		}
		else if (itemModel.Type == eIslandOutputModel.Hidden)
		{
			extraInfo.InfoType.selectedIndex = 2;
		}
		else if (itemModel.Type == eIslandOutputModel.Mission)
		{
			extraInfo.InfoType.selectedIndex = 3;
		}
	}

	private void OnClickResourceItem(UI_com_Output btn)
	{
		switch (btn.Type.selectedIndex)
		{
		case 1:
		{
			int nextBtnState = GetNextBtnState(btn.state.selectedIndex);
			ChangeSelected(btn, nextBtnState);
			((GButton)Dialog.SelectAll).selected = IsAllSelected();
			break;
		}
		case 0:
			ItemTip(btn);
			break;
		}
	}

	private void ChangeSelected(UI_com_Output btn, int nextIndex)
	{
		GvGMode3IslandOutputModel gvGMode3IslandOutputModel = (GvGMode3IslandOutputModel)((GObject)btn).data;
		btn.state.SetSelectedIndex(nextIndex);
		if (!btn.IsStateChange())
		{
			ChangedSelectedMinerals.Remove(gvGMode3IslandOutputModel.ItemId);
		}
		else
		{
			ChangedSelectedMinerals.Add(gvGMode3IslandOutputModel.ItemId);
		}
	}

	private void ItemTip(UI_com_Output btn)
	{
		string itemId = ((GvGMode3IslandOutputModel)((GObject)btn).data).ItemId;
		FGUIManager.Instance.ItemTip(itemId, 1, noCheckBtn: true);
	}

	public static int GetNextBtnState(int current)
	{
		return (current + 1) % 3;
	}

	private void DisplayResourceSourceInfo(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		UI_com_Output uI_com_Output = (UI_com_Output)(object)((GObject)context.sender).parent;
		if (uI_com_Output.Type.selectedIndex != 1)
		{
			GvGMode3IslandOutputModel itemModel = (GvGMode3IslandOutputModel)((GObject)uI_com_Output).data;
			FairyGUITip.ShowTip((GObject)(object)uI_com_Output.ExtraInfo, eFairyGUITipDir.Up, delegate(UI_com_SourceInfo popup)
			{
				popup.Init(itemModel);
			});
		}
	}

	public void OnClickClosePanel()
	{
		if (IsSelectedMineralChanged)
		{
			"GvG3CollectingChangeTip".ToLanguage().ToConfirmPopup(ConfirmAction, CancelAction, (AlignType)0);
		}
		else
		{
			ClosePanel();
		}
		void CancelAction()
		{
			ClosePanel();
		}
		void ConfirmAction()
		{
			OnConfirmToMine();
		}
	}

	private void OnClickSaveCollectConfig(EventContext context)
	{
		if (IsSelectedMineralChanged)
		{
			OnConfirmToMine();
			return;
		}
		ClosePanel();
		GoToShipDetailMiningPage();
	}

	private void OnConfirmToMine()
	{
		List<string> selectedResources = GetSelectedResources();
		if (selectedResources.Count > 0)
		{
			if (_islandId != _stateData.StayIslandId)
			{
				GvGWorldMapController.Instance.IslandActionManager.IslandAction(eIslandAction.Collect, _islandId, _stateData.EntityId, selectedResources, OnSuccessWhenTargetIsNotStayIsland);
			}
			else if (_stateData.State == eShipState.Collecting)
			{
				Singleton<WorldStateManager>.Instance.ChangeShipCollectingInfo(_stateData.EntityId, selectedResources, OnSuccessWhenTargetIsStayIsland);
			}
			else if (_stateData.State == eShipState.Stay)
			{
				GvGWorldMapController.Instance.IslandActionManager.IslandAction(eIslandAction.Collect, _islandId, _stateData.EntityId, selectedResources, OnSuccessWhenTargetIsStayIsland);
			}
		}
		else
		{
			"GvG3CollectingStopTip".ToLanguage().ToConfirmPopup(OnEmptySelectionConfirm, null, (AlignType)0);
		}
		void OnCancelSuccess()
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			ClosePanel();
			SharedMessenger.Broadcast("ON_GVG3_ISLAND_ACTION_SUCCESS", 3);
			Timers inst = Timers.inst;
			object obj = _003C_003Ec._003C_003E9__38_5;
			if (obj == null)
			{
				TimerCallback val = delegate
				{
					"GvG3CancelCollectingTip".ToShowLanguageTip();
				};
				_003C_003Ec._003C_003E9__38_5 = val;
				obj = (object)val;
			}
			inst.Add(0.2f, 1, (TimerCallback)obj);
		}
		void OnEmptySelectionConfirm()
		{
			C2S_IslandAction.Request req = new C2S_IslandAction.Request
			{
				ShipId = _stateData.ShipId,
				StartId = _stateData.StayIslandId,
				EndId = _stateData.StayIslandId,
				ActionEnum = eIslandAction.GoTo,
				ActionData = string.Empty,
				NextActionEnum = eIslandAction.FakeAction,
				NextActionData = string.Empty
			};
			Singleton<WorldStateManager>.Instance.SendIslandAction(req);
			OnCancelSuccess();
		}
		void OnSuccessWhenTargetIsNotStayIsland()
		{
			ClosePanel();
			SharedMessenger.Broadcast("ON_GVG3_ISLAND_ACTION_SUCCESS", 3);
		}
		void OnSuccessWhenTargetIsStayIsland()
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			ClosePanel();
			SharedMessenger.Broadcast("ON_GVG3_ISLAND_ACTION_SUCCESS", 3);
			GoToShipDetailMiningPage();
			Timers inst = Timers.inst;
			object obj = _003C_003Ec._003C_003E9__38_4;
			if (obj == null)
			{
				TimerCallback val = delegate
				{
					"GvG3StartCollectingTip".ToShowLanguageTip();
				};
				_003C_003Ec._003C_003E9__38_4 = val;
				obj = (object)val;
			}
			inst.Add(0.7f, 1, (TimerCallback)obj);
		}
	}

	private List<string> GetSelectedResources()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < Dialog.Output.numItems; i++)
		{
			UI_com_Output uI_com_Output = (UI_com_Output)(object)((GComponent)Dialog.Output).GetChildAt(i);
			if (uI_com_Output.IsSelected && ((GObject)uI_com_Output).data is GvGMode3IslandOutputModel gvGMode3IslandOutputModel)
			{
				int prior = ((uI_com_Output.state.selectedIndex == 2) ? 1 : 0);
				list.Add(gvGMode3IslandOutputModel.GetMiningConfigStr(prior));
			}
		}
		return list;
	}

	private void GoToShipDetailMiningPage()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Timers.inst.Add(0.3f, 1, (TimerCallback)delegate
		{
			GvGMode3ShipModel myShipData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(_stateData.ShipId);
			GvGShipDetailModel gvGShipDetailModel = new GvGShipDetailModel();
			gvGShipDetailModel.SetRecordData(myShipData);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGShipDetailPanel.Name, new Dictionary<string, object>
			{
				{ "GvGShipDetailModelData", gvGShipDetailModel },
				{ "OnClose", null },
				{ "ShowPageIndex", 3 }
			});
		});
	}

	private void OnClickSelectAll()
	{
		GList output = Dialog.Output;
		bool selected = ((GButton)Dialog.SelectAll).selected;
		int nextIndex = (selected ? 1 : 0);
		GObject[] children = ((GComponent)output).GetChildren();
		foreach (GObject val in children)
		{
			if (val is UI_com_Output uI_com_Output && uI_com_Output.IsSelected != selected)
			{
				ChangeSelected(uI_com_Output, nextIndex);
			}
		}
	}

	private IEnumerator UpdateLimitedTimestamp()
	{
		while (true)
		{
			for (int i = 0; i < Dialog.Output.numItems; i++)
			{
				UI_com_Output btn = ((GComponent)Dialog.Output).GetChildAt(i) as UI_com_Output;
				GvGMode3IslandOutputModel itemModel = ((GObject)(btn?)).data as GvGMode3IslandOutputModel;
				if (itemModel != null && itemModel.Type == eIslandOutputModel.Extra)
				{
					((GObject)btn.ExtraInfo.CountDown).text = UiHelper.ParseTime(itemModel.RemainingTime);
					yield return null;
				}
			}
			yield return (object)new WaitForSeconds(1f);
		}
	}
}
