using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Spine.Unity;
using UI.GvGChangeShipName;
using UI.GvGShipDetail;
using UI.GvGShipLaunch;
using UI.GvGShipPopup;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGShipOverview;

public class UI_GvGShipOverviewPanel : GComponent, IUiController
{
	private enum SlotType
	{
		Common,
		开局一艘飞空艇,
		空域主宰
	}

	public GLoader background;

	public GImage n96;

	public GButton BackBtn;

	public UI_Title Title;

	public UI_HelpBtn HelpBtn;

	public GTextField n114;

	public GImage FormationSoldierAmountBack;

	public GImage n101;

	public GTextField n102;

	public GTextField ShipCount;

	public GGroup CountGroup;

	public UI_ShipListComp ShipListComp;

	public UI_EditModeSwitchBtn EditModeSwitchBtn;

	public UI_ViewRangeBtn ViewRangeBtn;

	public UI_ViewRangePop ViewRangePop;

	public const string URL = "ui://7ymaonxtg2b40";

	public static string Name = "UI_GvGShipOverviewPanel";

	public const string DefaultFocus = "Focus";

	private GvGShipOverviewModel Data;

	private bool IsEditMode;

	private bool IsShipDetailPanelOpened;

	private Dictionary<int, Coroutine> CounterDict;

	private int DraggableShipCount;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private string WaitToOpenShipDetailShipId = null;

	private UICallbackParam<Action> OnClose;

	private List<GameObject> WorkersAnim_List;

	private int LastUpdateFrameCount;

	private const string GvG_Mode3_Ship_State_NotLaunched = "GvG_Mode3_Ship_State_NotLaunched";

	private const string GvGShipLaunchTip = "GvGShipLaunchTip";

	private Dictionary<string, object> _param;

	private C2S_BrawlEvent_GetInfo.Response _brawlEventInfo;

	private 深层共鸣TalentEffect 深层共鸣 = new 深层共鸣TalentEffect();

	private Dictionary<string, int> _canDestroyLut;

	public const string ReviewRangeOpenKey = "GvgViewRangeOpen";

	private bool _isBrawlEvent;

	public static string GetURL()
	{
		return "ui://7ymaonxtg2b40";
	}

	public static UI_GvGShipOverviewPanel CreateInstance()
	{
		return (UI_GvGShipOverviewPanel)(object)UIPackage.CreateObject("GvGShipOverview", "GvGShipOverviewPanel");
	}

	public static UI_GvGShipOverviewPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGShipOverviewPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtg2b40", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n96 = (GImage)((GComponent)this).GetChild("n96");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		HelpBtn = (UI_HelpBtn)(object)((GComponent)this).GetChild("HelpBtn");
		n114 = (GTextField)((GComponent)this).GetChild("n114");
		string id = "ui://7ymaonxtg2b40".Replace("ui://", "") + "-" + ((GObject)n114).id;
		((GObject)n114).text = LanguagesManager.GetDesc(id);
		FormationSoldierAmountBack = (GImage)((GComponent)this).GetChild("FormationSoldierAmountBack");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		n102 = (GTextField)((GComponent)this).GetChild("n102");
		string id2 = "ui://7ymaonxtg2b40".Replace("ui://", "") + "-" + ((GObject)n102).id;
		((GObject)n102).text = LanguagesManager.GetDesc(id2);
		ShipCount = (GTextField)((GComponent)this).GetChild("ShipCount");
		CountGroup = (GGroup)((GComponent)this).GetChild("CountGroup");
		ShipListComp = (UI_ShipListComp)(object)((GComponent)this).GetChild("ShipListComp");
		EditModeSwitchBtn = (UI_EditModeSwitchBtn)(object)((GComponent)this).GetChild("EditModeSwitchBtn");
		ViewRangeBtn = (UI_ViewRangeBtn)(object)((GComponent)this).GetChild("ViewRangeBtn");
		ViewRangePop = (UI_ViewRangePop)(object)((GComponent)this).GetChild("ViewRangePop");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		_param = parameters;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("GoToShipId", out var value))
		{
			WaitToOpenShipDetailShipId = (string)value;
		}
		if (parameters.TryGetValue("OnClose", out var value2))
		{
			OnClose = (UICallbackParam<Action>)value2;
		}
		Data = new GvGShipOverviewModel();
		IsEditMode = false;
		IsShipDetailPanelOpened = false;
		CounterDict = new Dictionary<int, Coroutine>();
		ShipAnimCacheManager = new ShipAnimCacheManager();
		WorkersAnim_List = new List<GameObject>();
		InitViewRange();
		Data.GetData(OnDataPrepaired);
		InitBrawlEvent();
	}

	private void OnDataPrepaired()
	{
		Update();
		foreach (GvGShipDetailModel ship in Data.Ships)
		{
			if (ship.ShipBuildState == eShipBuildState.PendingAcceptance)
			{
				OnOpenAcceptShipPanel();
				break;
			}
		}
		if (_param.TryGetValue("Focus", out var value))
		{
			int num = (int)value;
			ShipListComp.ShipList.ScrollToView(num, true, true);
		}
		Timers.inst.StartCoroutine(CheckForRedirectToDetailPanel());
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(OnExitPanel));
		((GObject)HelpBtn).onClick.Set(new EventCallback1(OnOpenHelpPanel));
		((GObject)EditModeSwitchBtn).onClick.Set(new EventCallback1(OnChangeEditMode));
		SharedMessenger.AddListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		((GObject)EditModeSwitchBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string>("ON_GVG3_SHIP_LAUNCH", OnShipLaunched);
	}

	private void OnOpenChangeShipNamePanel(int index)
	{
		GvGShipDetailModel ship = Data.Ships[index];
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "ShipId", ship.ShipId },
			{
				"OnConfirm",
				new UICallbackParam<Action<string>>(delegate(string newName)
				{
					OnConfirmChangeName(ship, newName);
				})
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGChangeShipNamePanel.Name, parameters);
	}

	private void OnLaunchShip(GvGShipDetailModel detailModel)
	{
		detailModel.GetLaunchableIsland(OpenLaunchPanel);
		static void OpenLaunchPanel(GvGShipDetailModel shipDetailModel)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvGShipLaunch.Name, new Dictionary<string, object> { { "ShipDetail", shipDetailModel } });
		}
	}

	private void OnOpenShipDetailPanel(int index, UI_ShipItem item)
	{
		if (!IsShipDetailPanelOpened && item.ShipStatus.selectedIndex != 0)
		{
			GvGShipDetailModel gvGShipDetailModel = Data.Ships[index];
			if (gvGShipDetailModel.IsJoinIZ && (!gvGShipDetailModel.HasStateModel || !gvGShipDetailModel.ShipState.IsSoulGuideCoolingDown))
			{
				IsShipDetailPanelOpened = true;
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGShipDetailPanel.Name, new Dictionary<string, object>
				{
					{
						"GvGShipDetailModelData",
						Data.Ships[index]
					},
					{
						"OnClose",
						new UICallbackParam<Action>(OnCloseShipDetailPanel)
					}
				});
			}
		}
	}

	private void OnCloseShipDetailPanel()
	{
		Data.GetData(Update);
		IsShipDetailPanelOpened = false;
	}

	private void OnConfirmChangeName(GvGShipDetailModel ship, string newName)
	{
		ship.RefreshName();
		Update();
	}

	private void OnClearShipData()
	{
		Data.GetData(Update);
	}

	private void OnOpenBuildShipPanel(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuildShipPanel.Name, new Dictionary<string, object>
		{
			{ "BuildableShipType", Data.BuildableShipType },
			{
				"OnBuildStarted",
				new UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>(delegate
				{
					Data.SetData(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord);
					LastUpdateFrameCount = -1;
					Update();
				})
			}
		});
	}

	private void OnOpenRebuildShipPanel(int shipRace, ShipStateModel shipState)
	{
		string shipId = shipState.ShipId;
		Singleton<GvGMode3RoomManager>.Instance.CheckShipIsNotInsurance(shipId, OpenRebuildShipPanel);
		void OpenRebuildShipPanel()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_RebuildShipPanel.Name, new Dictionary<string, object>
			{
				{ "ShipId", shipId },
				{ "ShipRace", shipRace },
				{ "BuildableShipType", Data.BuildableShipType },
				{
					"OnBuildStarted",
					new UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>(delegate(UI_main_BuildConfirmPanel.BuildParam buildParam)
					{
						Data.SetData(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord);
						Data.Ships.Find((GvGShipDetailModel ship) => ship.ShipId == shipId)?.SetRebuildingSkinId((int)buildParam.ShipRace);
						IsEditMode = false;
						((GButton)EditModeSwitchBtn).selected = false;
						LastUpdateFrameCount = -1;
						Update();
					})
				},
				{
					"OnClearShipData",
					new UICallbackParam<Action>(OnClearShipData)
				}
			});
		}
	}

	private void OnOpenAcceptShipPanel()
	{
		if (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_main_AcceptShipPanel.Name))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_AcceptShipPanel.Name, new Dictionary<string, object> { 
			{
				"OnAccept",
				new UICallbackParam<Action<string>>(OnAcceptShipFinished)
			} });
		}
	}

	private void OnBuildFinished(int index)
	{
		Update();
		OnOpenAcceptShipPanel();
	}

	private void OnConfirmAcceptShip(GvGShipDetailModel shipData)
	{
		OnOpenAcceptShipPanel();
	}

	private void OnAcceptShipFinished(string shipId)
	{
		Data.SetData(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord);
		LastUpdateFrameCount = -1;
		Update();
	}

	private void OnChangeEditMode(EventContext context)
	{
		IsEditMode = ((GButton)EditModeSwitchBtn).selected;
		if (IsEditMode)
		{
			SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetCanDestroyStatusAllMyShip
			{
				Req = new C2S_GetCanDestroyStatusAllMyShip.Request
				{
					Non = 0
				}
			}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
			{
				C2S_GetCanDestroyStatusAllMyShip.Response response = (C2S_GetCanDestroyStatusAllMyShip.Response)contextResponse.Resp;
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
					IsEditMode = false;
					Update();
				}
				else
				{
					_canDestroyLut = new Dictionary<string, int>();
					if (response.CanDestroyStatus != null)
					{
						foreach (ShipCanDestroyStatus item in response.CanDestroyStatus)
						{
							if (item != null && !string.IsNullOrEmpty(item.ShipId))
							{
								_canDestroyLut[item.ShipId] = item.ErrorCode;
							}
						}
					}
					Update();
				}
			});
		}
		else
		{
			Update();
		}
	}

	private void OnMoveShip(int index, int dir)
	{
		Singleton<GvGMode3RoomManager>.Instance.ChangeShipOrder(index, dir, delegate
		{
			Data.SetData(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord);
			LastUpdateFrameCount = -1;
			Update();
		});
	}

	private void OnOpenDestroyShipPopup(int index)
	{
		string shipId = Data.Ships[index].ShipId;
		if (CheckIsBrawlEventEnrolled(shipId))
		{
			"GvG3ShipDestroyWarning_BrawlFighting".ToShowLanguageTip();
		}
		else
		{
			Singleton<GvGMode3RoomManager>.Instance.CheckShipIsNotInsurance(shipId, DisplayWarning);
		}
		void DisplayWarning()
		{
			HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("GvGShipDestroyWarning".ToLanguage(), Data.Ships[index].ShipName).ToConfirmPopup(delegate
			{
				OnConfimDestroyShip(index);
			}, null, (AlignType)1, 44);
		}
	}

	private void OnConfimDestroyShip(int index)
	{
		GvGShipDetailModel gvGShipDetailModel = Data.Ships[index];
		string shipId = gvGShipDetailModel.ShipId;
		Singleton<GvGMode3RoomManager>.Instance.DestroyShip(shipId, delegate
		{
			LastUpdateFrameCount = -1;
			ShipAnimCacheManager.ReleaseCache(shipId);
			Data.SetData(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord);
			Update();
		});
	}

	private void OnOpenHelpPanel(EventContext context)
	{
		"GvG3HelpButtonClick".ToShowLanguageTip();
	}

	private void OnShipLaunched(string shipId)
	{
		if (!IsEditMode)
		{
			Update();
		}
	}

	private bool ShowLaunchTip(Action endAction)
	{
		if (!Data.Ships.Any((GvGShipDetailModel ship) => ship.ShipNeedLaunch))
		{
			return false;
		}
		"GvGShipLaunchTip".ToLanguage().ToConfirmPopup(delegate
		{
		}, endAction, (AlignType)0);
		return true;
	}

	private void ReorderShipList()
	{
		Data.Ships.Sort(GvGShipOverviewModel.ShipCompare);
		DraggableShipCount = 0;
		foreach (GvGShipDetailModel ship in Data.Ships)
		{
			if (ship.ShipBuildState == eShipBuildState.Normal)
			{
				DraggableShipCount++;
			}
		}
	}

	private void Update()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		if (Time.frameCount != LastUpdateFrameCount)
		{
			LastUpdateFrameCount = Time.frameCount;
			ReorderShipList();
			((GObject)ShipCount).text = $"{Data.Ships.Count}/{Data.MaxAvailableShipCount}";
			ShipListComp.ShipList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				ClearSpine(i, (UI_ShipItem)(object)o);
			};
			ShipListComp.ShipList.numItems = Data.MaxShipSlotCount;
			ShipListComp.ShipList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				ShipItemRenderer(i, (UI_ShipItem)(object)o);
			};
			ShipListComp.ShipList.numItems = Data.MaxShipSlotCount;
		}
	}

	private void ClearSpine(int index, UI_ShipItem item)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		if (((GObject)item.SpineLoader).data != null)
		{
			GoWrapper val = (GoWrapper)((GObject)item.SpineLoader).data;
			if ((Object)(object)val.wrapTarget != (Object)null)
			{
				val.wrapTarget.SetActive(false);
				val.wrapTarget = null;
			}
		}
	}

	private void ShipItemRenderer(int index, UI_ShipItem item)
	{
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_092d: Expected O, but got Unknown
		//IL_0a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a66: Expected O, but got Unknown
		//IL_0a7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a88: Expected O, but got Unknown
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Expected O, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Expected O, but got Unknown
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Expected O, but got Unknown
		int num = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
		item.IsEditing.selectedIndex = (IsEditMode ? 1 : 0);
		if (index < Data.Ships.Count)
		{
			GvGShipDetailModel dataShip = Data.Ships[index];
			((GObject)item.ShipName).text = dataShip.ShipName;
			item.Race.RaceIcon.url = ((eRace)dataShip.ShipType).ToRaceIconUrl();
			item.State.selectedIndex = (int)dataShip.ShipBuildState;
			item.SetShipStatus(dataShip);
			dataShip.SetOnChange(Update);
			if (item.ShipStatus.selectedIndex == 0)
			{
				((GObject)item.LiftoffBtn).visible = dataShip.ShipNeedLaunch;
			}
			UpdateSlotWorkerAnim(item.WorkerSpine1, "skin_shipworker", "shipbuilding_2", 0.25f, -1f);
			UpdateSlotWorkerAnim(item.WorkerSpine2, "skin_shipworker", "shipbuilding_1", 0.21f, 1f);
			UpdateSlotWorkerAnim(item.WorkerSpine3, "skin_shipworker", "shipbuilding_3", 0.18f, -1f);
			if (!IsEditMode)
			{
				if (dataShip.UIShipState != eUIShipState.NotLaunched)
				{
					ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetMyShip(dataShip.ShipId);
					((GObject)item.FoodInfo.Info).text = $"{shipStateModel.FoodOnboardCount}/{num}";
					((GObject)item.ShipStatusInfo.Info).text = WorldMapConfigHelper.Configs.TryGetIsland(shipStateModel.StayIslandId).Name ?? "";
				}
				else
				{
					((GObject)item.FoodInfo.Info).text = $"{dataShip.FoodOnboardCount}/{num}";
					((GObject)item.ShipStatusInfo.Info).text = "GvG_Mode3_Ship_State_NotLaunched".ToLanguage();
				}
				((GObject)item.WorkersInfo.Info).text = $"{dataShip.WorkersOnboardCount}/{dataShip.WorkersOnboardCountLimit}";
				((GObject)item.SoldiersInfo.Info).text = $"{dataShip.CurSoldiersCount}/{dataShip.TotalSoldiersCount}";
				UpdateCountDown(index, item.BuildTimeInfo.Info, dataShip.TargetBuildCompleteTime, dataShip.ShipBuildState == eShipBuildState.Building || dataShip.ShipBuildState == eShipBuildState.Rebuilding || dataShip.ShipBuildState == eShipBuildState.PendingAcceptance);
				((GObject)item.ChangeNameBtn).onClick.Set((EventCallback0)delegate
				{
					OnOpenChangeShipNamePanel(index);
				});
				((GObject)item.ShipDetailBtn).onClick.Set((EventCallback0)delegate
				{
					OnOpenShipDetailPanel(index, item);
				});
				((GObject)item.AcceptBtn).onClick.Set((EventCallback0)delegate
				{
					OnConfirmAcceptShip(dataShip);
				});
				((GObject)item.LiftoffBtn).onClick.Set((EventCallback0)delegate
				{
					OnLaunchShip(dataShip);
				});
			}
			else
			{
				((GObject)item.Index).text = $"{index + 1}";
				if (DraggableShipCount == 1 && index == 0)
				{
					item.DraggablePos.selectedIndex = 0;
				}
				else if (index == 0)
				{
					item.DraggablePos.selectedIndex = 1;
				}
				else if (index < DraggableShipCount - 1)
				{
					item.DraggablePos.selectedIndex = 2;
				}
				else
				{
					item.DraggablePos.selectedIndex = 3;
				}
				bool isBrawlFighting = CheckIsBrawlEventEnrolled(dataShip.ShipId);
				if (isBrawlFighting)
				{
					item.CanRemove.SetSelectedIndex(2);
				}
				else if (dataShip.CanRemove())
				{
					item.CanRemove.selectedIndex = 1;
				}
				else
				{
					item.CanRemove.selectedIndex = 0;
					item.CantRemoveTip.Type.selectedIndex = (int)dataShip.CannotRemoveType();
				}
				((GObject)item.ToLeft).onClick.Set((EventCallback0)delegate
				{
					OnMoveShip(index, -1);
				});
				((GObject)item.ToRight).onClick.Set((EventCallback0)delegate
				{
					OnMoveShip(index, 1);
				});
				((GObject)item.DeletBtn).onClick.Set((EventCallback0)delegate
				{
					OnOpenDestroyShipPopup(index);
				});
				bool canRebuild = dataShip.CanRebuild() && Data.ShipsHasAvailableCount;
				canRebuild &= !isBrawlFighting;
				if (canRebuild)
				{
					item.CanRebuild.selectedIndex = 1;
				}
				else if (dataShip.HasStateModel && dataShip.ShipState.IsSoulGuideCoolingDown)
				{
					item.CanRebuild.selectedIndex = 2;
				}
				else
				{
					item.CanRebuild.selectedIndex = 0;
				}
				((GObject)item.Rebuild).onClick.Set((EventCallback0)delegate
				{
					if (canRebuild)
					{
						OnOpenRebuildShipPanel(dataShip.ShipType, dataShip.ShipState);
					}
					else if (isBrawlFighting)
					{
						"GvG3_RebuildShip_IsBrawlFighting_Tip".ToShowLanguageTip();
					}
					else if (dataShip.IsJoinIZ)
					{
						"GvG3_RebuildShip_CanNot_Tip".ToShowLanguageTip();
					}
					else if (!Data.ShipsHasAvailableCount)
					{
						"GvG3_RebuildShip_Has_No_Available_Count".ToShowLanguageTip();
					}
					else
					{
						"GvG3_RebuildShip_IsNotJoinIz_Tip".ToShowLanguageTip();
					}
				});
			}
			string animationName = "dengdai";
			if (dataShip.ShipBuildState == eShipBuildState.Building || dataShip.ShipBuildState == eShipBuildState.Rebuilding || dataShip.ShipBuildState == eShipBuildState.PendingAcceptance)
			{
				animationName = "jianzaozhong";
			}
			UpdateShipSkin(item.SpineLoader, dataShip, animationName);
		}
		else if (index < Data.MaxAvailableShipCount)
		{
			item.BuildShipBtn.Type.selectedIndex = 0;
			item.State.SetSelectedIndex(4);
			((GObject)item.BuildShipBtn).onClick.Set(new EventCallback1(OnOpenBuildShipPanel));
		}
		else if (index < Data.MaxShipSlotCount)
		{
			item.State.SetSelectedIndex(5);
			if (!Data.HasEnterIz)
			{
				item.LockBtn.State.selectedIndex = 0;
			}
			else if (Singleton<GvGMode3RoomManager>.Instance.IsConnecting)
			{
				if (Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress < 5)
				{
					item.LockBtn.State.selectedIndex = 1;
				}
				else
				{
					item.LockBtn.State.selectedIndex = 2;
				}
			}
		}
		if (index < Data.MaxAvailableShipCount)
		{
			SlotType slotType = GetSlotType(index);
			item.BuildShipBtn.Type.SetSelectedIndex((int)slotType);
			item.shipBuildType.SetSelectedIndex((int)slotType);
			((GObject)item.tipBtn1).onClick.Set(new EventCallback1(OnClickTipBtn1));
			((GObject)item.tipBtn2).onClick.Set(new EventCallback1(OnClickTipBtn2));
		}
	}

	private SlotType GetSlotType(int slotIndex)
	{
		int maxAvailableShipCount = Data.MaxAvailableShipCount;
		bool flag = Singleton<GvGOuterTechManager>.Instance.IsAvailable && "I67603".IsActive();
		if (Singleton<GvGTalentsManager>.Instance.GetCurSpecialTalentLevelWith深层共鸣(-1, 深层共鸣) >= 4)
		{
			if (slotIndex == maxAvailableShipCount - 1)
			{
				return SlotType.空域主宰;
			}
			if (flag && slotIndex == maxAvailableShipCount - 2)
			{
				return SlotType.开局一艘飞空艇;
			}
		}
		else if (flag && slotIndex == maxAvailableShipCount - 1)
		{
			return SlotType.开局一艘飞空艇;
		}
		return SlotType.Common;
	}

	private void UpdateShipSkin(GGraph spineLoader, GvGShipDetailModel detail, string animationName = "dengdai")
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		GameObject cache = ShipAnimCacheManager.GetCache(detail.ShipId, detail.ShipSkinId, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, animationName, true);
		}, isMask: true, isSimpleSpine: false, delegate(SkeletonAnimation animation)
		{
			animation.AnimationState.SetAnimation(0, animationName, true);
		});
		cache.transform.localScale = new Vector3(50f, 50f, 50f);
		cache.SetActive(true);
		if (((GObject)spineLoader).data == null)
		{
			GoWrapper val = new GoWrapper(cache)
			{
				supportStencil = true
			};
			spineLoader.SetNativeObject((DisplayObject)(object)val);
			((GObject)spineLoader).data = val;
		}
		else
		{
			((GoWrapper)((GObject)spineLoader).data).wrapTarget = cache;
		}
	}

	private void UpdateSlotWorkerAnim(GGraph spineLoader, string skin, string anim, float scale, float dir)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		if (((GObject)spineLoader).data == null)
		{
			GameObject val = UiHelper.LoadSpine_AB("Goblinworker_001", 100f * scale, delegate(SkeletonAnimation animation)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, skin);
				animation.AnimationState.SetAnimation(0, anim, true);
			});
			Vector3 localScale = val.transform.localScale;
			localScale.x *= dir;
			val.transform.localScale = localScale;
			GoWrapper val2 = new GoWrapper(val);
			val2.supportStencil = true;
			spineLoader.SetNativeObject((DisplayObject)(object)val2);
			((GObject)spineLoader).data = val2;
			WorkersAnim_List.Add(val);
		}
	}

	private void UpdateCountDown(int index, GTextField textField, int targetTimeStamp, bool isActive)
	{
		if (CounterDict.TryGetValue(index, out var value))
		{
			CounterDict.Remove(index);
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(value);
		}
		if (isActive)
		{
			if (targetTimeStamp > (int)GameController.Instance.GetServerTime())
			{
				value = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateCountDownCoroutine(index, textField, targetTimeStamp));
				CounterDict.Add(index, value);
			}
			else
			{
				OnBuildFinished(index);
			}
		}
	}

	private IEnumerator UpdateCountDownCoroutine(int index, GTextField textField, int targetTimeStamp)
	{
		while (true)
		{
			int timeLeft = targetTimeStamp - (int)GameController.Instance.GetServerTime();
			if (timeLeft <= 0)
			{
				break;
			}
			((GObject)textField).text = UiHelper.ParseTime(timeLeft) ?? "";
			yield return (object)new WaitForSeconds(1f);
		}
		((GObject)textField).text = UiHelper.ParseTime(0) ?? "";
		yield return (object)new WaitForSeconds(1f);
		OnBuildFinished(index);
	}

	private IEnumerator CheckForRedirectToDetailPanel()
	{
		yield return null;
		if (WaitToOpenShipDetailShipId != null)
		{
			int targetIndex = ((!(WaitToOpenShipDetailShipId == "")) ? Data.Ships.FindIndex((GvGShipDetailModel ship) => ship.ShipId == WaitToOpenShipDetailShipId) : 0);
			OnOpenShipDetailPanel(targetIndex, null);
		}
	}

	private void OnExitPanel()
	{
		if (!ShowLaunchTip(End))
		{
			End();
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		foreach (Coroutine value in CounterDict.Values)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(value);
		}
		foreach (GameObject workersAnim_ in WorkersAnim_List)
		{
			if ((Object)(object)workersAnim_ != (Object)null)
			{
				Object.Destroy((Object)(object)workersAnim_);
			}
		}
		Data.Release();
	}

	public void Destroy()
	{
		ShipAnimCacheManager.ClearCache();
		OnClose?.Callback?.Invoke();
	}

	private void InitViewRange()
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)ViewRangePop).visible = false;
		int selectedIndex = (GetViewRangeLocalConfig() ? 1 : 0);
		ViewRangeBtn.open.selectedIndex = selectedIndex;
		ViewRangePop.ShowViewRange.selectedIndex = selectedIndex;
		((GObject)ViewRangeBtn).onClick.Set((EventCallback0)delegate
		{
			((GObject)ViewRangePop).visible = true;
		});
		((GObject)ViewRangePop.Mask).onClick.Set((EventCallback0)delegate
		{
			((GObject)ViewRangePop).visible = false;
		});
		ViewRangePop.ViewRangeSwitchBtn.button.onChanged.Set((EventCallback0)delegate
		{
			int selectedIndex2 = ViewRangePop.ViewRangeSwitchBtn.button.selectedIndex;
			bool value = selectedIndex2 != 0;
			ViewRangeBtn.open.selectedIndex = selectedIndex2;
			ViewRangePop.ShowViewRange.selectedIndex = selectedIndex2;
			GameLocalDataManager.SetBool("GvgViewRangeOpen", value);
		});
	}

	public static bool GetViewRangeLocalConfig()
	{
		if (!GameLocalDataManager.HasKey("GvgViewRangeOpen"))
		{
			GameLocalDataManager.SetBool("GvgViewRangeOpen", value: true);
		}
		return GameLocalDataManager.GetBool("GvgViewRangeOpen");
	}

	private void InitBrawlEvent()
	{
		_isBrawlEvent = WorldMapConfigHelper.Configs.IsBrawlEvent();
	}

	private bool CheckIsBrawlEventEnrolled(string shipId)
	{
		if (!_isBrawlEvent)
		{
			return false;
		}
		if (_canDestroyLut == null || !_canDestroyLut.ContainsKey(shipId))
		{
			return false;
		}
		int num = _canDestroyLut[shipId];
		return num == -9526;
	}

	private void OnClickTipBtn1(EventContext context)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		EventDispatcher sender = context.sender;
		FairyGUITip.ShowTip((GObject)(object)((sender is GObject) ? sender : null), eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "ShipOverviewPanelTip1".ToLanguage();
		});
	}

	private void OnClickTipBtn2(EventContext context)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		EventDispatcher sender = context.sender;
		FairyGUITip.ShowTip((GObject)(object)((sender is GObject) ? sender : null), eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "ShipOverviewPanelTip2".ToLanguage();
		});
	}
}
