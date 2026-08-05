using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.BattleLog;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGBattleRecord3;

public class UI_main_GvG3BattleRecordsPanel : GComponent, IUiController
{
	private enum IslandBigLogFilter
	{
		Oneself,
		MyCamp,
		All
	}

	private class PlayerLogFilter
	{
		public string ShipId { get; set; }

		public string ShipName { get; set; }

		public int ShipRace { get; set; }
	}

	public Controller Status;

	public Controller PageController;

	public Controller ShowTabList;

	public GGraph Mask;

	public GList TabListBack;

	public UI_com_GvG3BattleResultBonusDialog BattleResultBonus;

	public UI_com_GvG3BigRecordsDialog BigDialog;

	public UI_com_GvG3SmallRecordDialog SmallDialog;

	public GGroup BattleRecordPage;

	public GList TabListFront;

	public Transition ShowRecordDialog;

	public const string URL = "ui://b3fc6085stwv1e";

	public static string Name = "UI_main_GvG3BattleRecordsPanel";

	private string _processId;

	private bool _getFormRunningRecords;

	private bool _showTimeStamp;

	private List<BattleLog_Big> _originalBigLogs = new List<BattleLog_Big>();

	private List<BattleLog_Big> _filteredBigLogs = new List<BattleLog_Big>();

	private bool _islandLog;

	private int _currentCheckBigLogIndex;

	private int _islandId;

	private bool _reservePackageResOnClose;

	private List<PlayerLogFilter> _myShips;

	private int MyUserId => GameController.Contexts.gameState.user.value.UserId;

	private int MyCampId => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;

	private int _curSelectedShipRace => _myShips[BigDialog.FilrerShip.Menu.selectedIndex].ShipRace;

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1e";
	}

	public static UI_main_GvG3BattleRecordsPanel CreateInstance()
	{
		return (UI_main_GvG3BattleRecordsPanel)(object)UIPackage.CreateObject("GvGBattleRecord3", "main_GvG3BattleRecordsPanel");
	}

	public static UI_main_GvG3BattleRecordsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3BattleRecordsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		PageController = ((GComponent)this).GetController("PageController");
		ShowTabList = ((GComponent)this).GetController("ShowTabList");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		TabListBack = (GList)((GComponent)this).GetChild("TabListBack");
		BattleResultBonus = (UI_com_GvG3BattleResultBonusDialog)(object)((GComponent)this).GetChild("BattleResultBonus");
		BigDialog = (UI_com_GvG3BigRecordsDialog)(object)((GComponent)this).GetChild("BigDialog");
		SmallDialog = (UI_com_GvG3SmallRecordDialog)(object)((GComponent)this).GetChild("SmallDialog");
		BattleRecordPage = (GGroup)((GComponent)this).GetChild("BattleRecordPage");
		TabListFront = (GList)((GComponent)this).GetChild("TabListFront");
		ShowRecordDialog = ((GComponent)this).GetTransition("ShowRecordDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_processId = (parameters.TryGetValue("ProcessId", out var value) ? value.ToString() : string.Empty);
		_islandLog = parameters.TryGetValue("IslandLog", out var value2) && (bool)value2;
		_islandId = (parameters.TryGetValue("IslandId", out var value3) ? ((int)value3) : 0);
		_reservePackageResOnClose = parameters.TryGetValue("ReservePackageResOnClose", out var value4) && (bool)value4;
		_getFormRunningRecords = parameters.TryGetValue("GetFormRunningResource", out var value5) && (bool)value5;
		if (parameters.TryGetValue("ShowTimeStamp", out var value6))
		{
			_showTimeStamp = (bool)value6;
		}
		else
		{
			_showTimeStamp = true;
		}
		BigDialog.BigRecords.SetVirtual();
		if (_islandLog)
		{
			InitIslandLog();
			return;
		}
		BattleResultBonus.Init();
		InitMyLog();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		BigDialog.BigRecords.onClickItem.Add(new EventCallback1(CheckSmallLogs));
		((GComponent)BigDialog.BigRecords).scrollPane.onPullUpRelease.Add(new EventCallback0(OnPullUpRefresh));
		((GComponent)BigDialog.BigRecords).scrollPane.onPullDownRelease.Add(new EventCallback0(OnPullDownRefresh));
		BattleResultBonus.RegisterUiEventListeners();
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		BigDialog.BigRecords.onClickItem.Remove(new EventCallback1(CheckSmallLogs));
		((GComponent)BigDialog.BigRecords).scrollPane.onPullUpRelease.Remove(new EventCallback0(OnPullUpRefresh));
		((GComponent)BigDialog.BigRecords).scrollPane.onPullDownRelease.Remove(new EventCallback0(OnPullDownRefresh));
		BattleResultBonus.UnregisterUiEventListeners();
	}

	private void RenderBigLogs()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		BigDialog.BigRecords.itemRenderer = new ListItemRenderer(RenderBigLogItem);
		BigDialog.BigRecords.numItems = _filteredBigLogs.Count;
	}

	private void RenderBigLogItem(int index, GObject obj)
	{
		if (!(obj is UI_btn_BattleRecordBig uI_btn_BattleRecordBig))
		{
			return;
		}
		BattleLog_Big battleLog_Big = _filteredBigLogs[index];
		((GObject)uI_btn_BattleRecordBig.Time).text = battleLog_Big.TimeStampText;
		((GObject)uI_btn_BattleRecordBig.Time).visible = _showTimeStamp;
		((GObject)uI_btn_BattleRecordBig.IslandName).text = battleLog_Big.IslandName;
		uI_btn_BattleRecordBig.Camp.selectedIndex = battleLog_Big.IslandOriginalCampId;
		uI_btn_BattleRecordBig.HasBoss.selectedIndex = (battleLog_Big.HasBoss ? 1 : 0);
		if (battleLog_Big.HasBoss)
		{
			uI_btn_BattleRecordBig.BossIcon.Icon.url = battleLog_Big.BlueInfo.NpcIcon();
			((GObject)uI_btn_BattleRecordBig.TotalDamageValue).text = battleLog_Big.BossHp;
		}
		else
		{
			((GObject)uI_btn_BattleRecordBig.Kill).text = battleLog_Big.Kill.ToString();
		}
		((GObject)uI_btn_BattleRecordBig.Loss).text = battleLog_Big.Loss.ToString();
		((GObject)uI_btn_BattleRecordBig.ShipIconLeft).visible = false;
		((GObject)uI_btn_BattleRecordBig.ShipIconRight).visible = false;
		uI_btn_BattleRecordBig.Camp.selectedIndex = battleLog_Big.IslandOriginalCampId;
		if (!_islandLog)
		{
			((GObject)uI_btn_BattleRecordBig.ShipIconLeft).visible = true;
			((UI_com_ShipSmallIcon)(object)uI_btn_BattleRecordBig.ShipIconLeft).SetShipStyle(battleLog_Big.RedInfo.ShipRace, battleLog_Big.RedInfo.CampId);
			if (!battleLog_Big.BlueInfo.IsNpc)
			{
				((GObject)uI_btn_BattleRecordBig.ShipIconRight).visible = true;
				((UI_com_ShipSmallIcon)(object)uI_btn_BattleRecordBig.ShipIconRight).SetShipStyle(battleLog_Big.BlueInfo.ShipRace, battleLog_Big.BlueInfo.CampId);
			}
		}
		bool showMyShipName = !_islandLog && battleLog_Big.RedInfo.UserId == MyUserId;
		SetUserIconAndName(uI_btn_BattleRecordBig.RedProfile, battleLog_Big.RedInfo, "", showMyShipName);
		SetUserIconAndName(uI_btn_BattleRecordBig.BlueProfile, battleLog_Big.BlueInfo, battleLog_Big.IslandName);
	}

	private void SetUserIconAndName(UI_com_ProfileDisplay profileDisplay, BattleLogShipInfo user, string isLandName = "", bool showMyShipName = false)
	{
		profileDisplay.IsMe.selectedIndex = ((user.UserId == MyUserId && _islandLog) ? 1 : 0);
		UI_com_ProfileDisplayRecordCenter profileUi = (UI_com_ProfileDisplayRecordCenter)(object)profileDisplay.ProfileDisplay;
		profileUi.Avatar.CampId.SetSelectedIndex(user.CampId);
		if (user.IsNpc)
		{
			profileUi.Avatar.HeadPortrait.Type.SetSelectedIndex(1);
			((GObject)profileUi.PlayerName).text = user.NpcName(isLandName);
			profileUi.Avatar.HeadPortrait.icon.url = user.NpcIcon();
			return;
		}
		profileUi.Avatar.HeadPortrait.Type.SetSelectedIndex(0);
		((GComponent)(object)profileUi).RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayRecordCenter>
		{
			CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
			UserId = user.UserId,
			CampId = user.CampId,
			OnProfileLoaded = delegate
			{
				profileUi.Style.SetSelectedIndex((((GComponent)profileUi.Medals).numChildren <= 0) ? 1 : 0);
				if (showMyShipName)
				{
					((GObject)profileUi.PlayerName).text = user.MyShipName;
				}
			}
		}, user.UserId);
	}

	private void CheckSmallLogs(EventContext context)
	{
		_currentCheckBigLogIndex = BigDialog.BigRecords.selectedIndex;
		RenderSmallLogs();
	}

	private void RenderSmallLogs()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		Status.selectedIndex = 1;
		SmallDialog.SmallRecords.SetVirtual();
		SmallDialog.SmallRecords.itemRenderer = new ListItemRenderer(RenderSmallLogItem);
		SmallDialog.SmallRecords.numItems = _filteredBigLogs[_currentCheckBigLogIndex].SmallLogs.Count;
	}

	private void RenderSmallLogItem(int index, GObject obj)
	{
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		UI_com_BattleRecordSmall btn = obj as UI_com_BattleRecordSmall;
		if (btn == null)
		{
			return;
		}
		BattleLog_Big battleLog_Big = _filteredBigLogs[_currentCheckBigLogIndex];
		BattleLog_Small battleLog_Small = battleLog_Big.SmallLogs[index];
		((GObject)btn.ShipIconLeft).visible = true;
		((GObject)btn.ShipIconRight).visible = !battleLog_Big.BlueInfo.IsNpc;
		((UI_com_ShipSmallIcon)(object)btn.ShipIconLeft).SetShipStyle(battleLog_Big.RedInfo.ShipRace, battleLog_Big.RedInfo.CampId);
		if (!battleLog_Big.BlueInfo.IsNpc)
		{
			((UI_com_ShipSmallIcon)(object)btn.ShipIconRight).SetShipStyle(battleLog_Big.BlueInfo.ShipRace, battleLog_Big.BlueInfo.CampId);
		}
		btn.MyAvatar.CampId.selectedIndex = battleLog_Big.RedInfo.CampId;
		btn.EnemyAvatar.CampId.selectedIndex = battleLog_Big.BlueInfo.CampId;
		btn.Status.selectedIndex = (battleLog_Small.Win ? 1 : 0);
		btn.AttackAndDefense.selectedIndex = ((!battleLog_Small.Offensive) ? 1 : 0);
		if (battleLog_Big.BlueInfo.IsNpc)
		{
			btn.EnemyAvatar.HeadPortrait.icon.url = battleLog_Big.BlueInfo.NpcIcon();
			btn.EnemyAvatar.HeadPortrait.Type.selectedIndex = 1;
		}
		else
		{
			btn.EnemyAvatar.HeadPortrait.Type.selectedIndex = 0;
			GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", battleLog_Big.BlueInfo.UserId, null, delegate(Sprite sprite)
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0026: Expected O, but got Unknown
				btn.EnemyAvatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}));
		}
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", battleLog_Big.RedInfo.UserId, null, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			btn.MyAvatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
		if (Define.GvGMode3UnderTesting)
		{
			GTextField gvG3TestBattleId = btn.GvG3TestBattleId;
			((GObject)gvG3TestBattleId).text = ((GObject)gvG3TestBattleId).text + "(" + battleLog_Small.BattleId.Substring(0, 4) + ")";
		}
		((GObject)btn.Play).data = index;
		((GObject)btn.Play).onClick.Set(new EventCallback1(CheckSmallLogDetail));
	}

	private void CheckSmallLogDetail(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)context.sender).data;
		BattleLog_Big battleLog_Big = _filteredBigLogs[_currentCheckBigLogIndex];
		BattleLog_Small battleLog_Small = battleLog_Big.SmallLogs[index];
		BattleLogShipInfo redInfo = ((battleLog_Small.RedAlias == eBattleLogShipAlias.A) ? battleLog_Big.ShipInfoA : battleLog_Big.ShipInfoB);
		BattleLogShipInfo blueInfo = ((battleLog_Small.RedAlias == eBattleLogShipAlias.A) ? battleLog_Big.ShipInfoB : battleLog_Big.ShipInfoA);
		string text = (_islandLog ? _processId : battleLog_Big.ProcessId);
		Singleton<GvGMode3BattleRecordsManager>.Instance.PlayBattleRecord(battleLog_Small.BattleId, battleLog_Small.ProcessId, redInfo, blueInfo, battleLog_Big.HasBoss);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, _reservePackageResOnClose);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	private void InitIslandLog()
	{
		ShowTabList.selectedIndex = 0;
		PageController.selectedIndex = 1;
		if (_getFormRunningRecords)
		{
			Singleton<GvGMode3BattleRecordsManager>.Instance.GetIslandRunningBattleLog(_islandId, OnGetIslandLogsComplete);
		}
		else
		{
			Singleton<GvGMode3BattleRecordsManager>.Instance.GetIslandBigBattleLog(_processId, OnGetIslandLogsComplete);
		}
	}

	private void OnGetIslandLogsComplete(List<BattleLog_Big> bigLogs)
	{
		if (((GObject)BigDialog).isDisposed)
		{
			return;
		}
		_originalBigLogs = bigLogs.Clone();
		foreach (BattleLog_Big originalBigLog in _originalBigLogs)
		{
			originalBigLog.DataInit(MyCampId);
		}
		InitIslandLogFilter();
		BigDialog.Type.selectedIndex = 0;
		((GObject)BigDialog.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(_islandId).Name;
		ChangeShowIslandLog(IslandBigLogFilter.Oneself);
		RenderBigLogs();
	}

	private void InitIslandLogFilter()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		((GButton)BigDialog.FilrerIsland).selected = false;
		BigDialog.FilrerIsland.CurrentSelected.IconController.SetSelectedIndex(0);
		BigDialog.FilrerIsland.CurrentSelected.Camp.SetSelectedIndex(MyCampId);
		BigDialog.FilrerIsland.Menu.itemRenderer = new ListItemRenderer(RenderIslandLogFilterItem);
		BigDialog.FilrerIsland.Menu.numItems = 3;
	}

	private void RenderIslandLogFilterItem(int index, GObject obj)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		if (obj is UI_com_RecordsFilter2 uI_com_RecordsFilter)
		{
			uI_com_RecordsFilter.IconController.SetSelectedIndex(index);
			if (index == 1)
			{
				uI_com_RecordsFilter.Camp.SetSelectedIndex(MyCampId);
			}
			((GObject)uI_com_RecordsFilter).data = index;
			((GObject)uI_com_RecordsFilter).onClick.Set(new EventCallback1(ResetIslandLogFilter));
		}
	}

	private void ResetIslandLogFilter(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		int num = (int)data;
		BigDialog.FilrerIsland.CurrentSelected.IconController.SetSelectedIndex(num);
		if (num == 1)
		{
			BigDialog.FilrerIsland.CurrentSelected.Camp.SetSelectedIndex(MyCampId);
		}
		ChangeShowIslandLog((IslandBigLogFilter)num);
		RenderBigLogs();
	}

	private void ChangeShowIslandLog(IslandBigLogFilter newFilter)
	{
		switch (newFilter)
		{
		case IslandBigLogFilter.All:
			_filteredBigLogs = _originalBigLogs;
			break;
		case IslandBigLogFilter.Oneself:
			_filteredBigLogs = _originalBigLogs.Where((BattleLog_Big log) => log.ShipInfoA.UserId == MyUserId || log.ShipInfoB.UserId == MyUserId).ToList();
			break;
		case IslandBigLogFilter.MyCamp:
			_filteredBigLogs = _originalBigLogs.Where((BattleLog_Big log) => log.ShipInfoA.CampId == MyCampId || log.ShipInfoB.CampId == MyCampId).ToList();
			break;
		default:
			throw new ArgumentOutOfRangeException("newFilter", newFilter, null);
		}
	}

	private void InitMyLog()
	{
		ShowTabList.selectedIndex = 1;
		PageController.selectedIndex = 0;
		((GObject)BigDialog.BigRecords).touchable = false;
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetPlayerBattleLog_New(-1, delegate
		{
			if (!((GObject)this).isDisposed)
			{
				BigDialog.Type.selectedIndex = 1;
				InitMyLogFilter();
			}
		});
	}

	private void InitMyLogFilter()
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		SentrySdk.AddBreadcrumb($"[UI_main_GvG3BattleRecordsPanel] InitMyLogFilter Ships is null={Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships == null}");
		_myShips = new List<PlayerLogFilter>
		{
			new PlayerLogFilter
			{
				ShipId = string.Empty,
				ShipName = $"GvGMode3_IslandBattleLog_{IslandBigLogFilter.All}".ToLanguage(),
				ShipRace = -2
			}
		};
		foreach (GvGMode3ShipModel ship in Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships)
		{
			_myShips.Add(new PlayerLogFilter
			{
				ShipId = ship.ShipId,
				ShipName = ship.PermanentData.ShipName.ToRealShipName(),
				ShipRace = ship.PermanentData.ShipRace
			});
			SentrySdk.AddBreadcrumb($"[UI_main_GvG3BattleRecordsPanel] InitMyLogFilter PermanentData is null={ship.PermanentData == null}");
			if (ship.PermanentData != null)
			{
				SentrySdk.AddBreadcrumb($"[UI_main_GvG3BattleRecordsPanel] InitMyLogFilter ShipName is null={ship.PermanentData.ShipName == null}");
			}
		}
		BigDialog.FilrerShip.Menu.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderMyLogFilterItem(i, (UI_com_RecordsFilter)(object)o);
		};
		BigDialog.FilrerShip.Menu.numItems = _myShips.Count;
		BigDialog.FilrerShip.Menu.ResizeToFit(_myShips.Count);
		BigDialog.FilrerShip.Menu.onClickItem.Set(new EventCallback0(OnChangeMyLogFilter));
		BigDialog.FilrerShip.Menu.selectedIndex = 0;
		OnChangeMyLogFilter();
	}

	private void OnChangeMyLogFilter()
	{
		int selectedIndex = BigDialog.FilrerShip.Menu.selectedIndex;
		PlayerLogFilter playerLogFilter = _myShips[selectedIndex];
		if (playerLogFilter.ShipRace == -2)
		{
			((GObject)BigDialog.FilrerShip.CurrentSelected.AllDesc).text = playerLogFilter.ShipName;
			BigDialog.FilrerShip.CurrentSelected.IsAll.selectedIndex = 1;
		}
		else
		{
			((GObject)BigDialog.FilrerShip.CurrentSelected.Desc).text = playerLogFilter.ShipName;
			BigDialog.FilrerShip.CurrentSelected.IsAll.selectedIndex = 0;
			((UI_com_ShipSmallIcon)(object)BigDialog.FilrerShip.CurrentSelected.ShipIcon).SetShipStyle(playerLogFilter.ShipRace, MyCampId);
		}
		UpdateMyLog();
	}

	private void RenderMyLogFilterItem(int index, UI_com_RecordsFilter btn)
	{
		PlayerLogFilter playerLogFilter = _myShips[index];
		((GObject)btn.Desc).text = playerLogFilter.ShipName;
		bool flag = playerLogFilter.ShipRace == -2;
		btn.IsAll.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			((GObject)btn.AllDesc).text = playerLogFilter.ShipName;
			return;
		}
		((GObject)btn.Desc).text = playerLogFilter.ShipName;
		((UI_com_ShipSmallIcon)(object)btn.ShipIcon).SetShipStyle(playerLogFilter.ShipRace, MyCampId);
	}

	private void OnPullDownRefresh()
	{
		if (_islandLog || _myShips == null)
		{
			return;
		}
		ScrollPane recordsScrollPane = ((GComponent)BigDialog.BigRecords).scrollPane;
		ScrollPaneHeader header = (ScrollPaneHeader)(object)recordsScrollPane.header;
		header.SetRefreshStatus(2);
		recordsScrollPane.LockHeader(50);
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetPlayerBattleLog_New(_curSelectedShipRace, delegate
		{
			if (!((GObject)this).isDisposed)
			{
				UpdateMyLog();
				OnPullDownEnd();
			}
		});
		void OnPullDownEnd()
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
			{
				if (!((GObject)this).isDisposed)
				{
					header.SetRefreshStatus(0);
					recordsScrollPane.LockHeader(0);
				}
			});
		}
	}

	private void OnPullUpRefresh()
	{
		if (_islandLog || _myShips == null)
		{
			return;
		}
		ScrollPane recordsScrollPane = ((GComponent)BigDialog.BigRecords).scrollPane;
		ScrollPaneHeader footer = (ScrollPaneHeader)(object)recordsScrollPane.footer;
		footer.SetRefreshStatus(2);
		recordsScrollPane.LockFooter(30);
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetPlayerBattleLog_Early(_curSelectedShipRace, delegate
		{
			if (!((GObject)this).isDisposed)
			{
				UpdateMyLog();
				OnPullUpEnd();
			}
		});
		void OnPullUpEnd()
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
			{
				footer.SetRefreshStatus(0);
				recordsScrollPane.LockFooter(0);
			});
		}
	}

	private void UpdateMyLog()
	{
		_filteredBigLogs = Singleton<GvGMode3BattleRecordsManager>.Instance.GetMyLogFiltered(_curSelectedShipRace);
		RenderBigLogs();
		((GObject)BigDialog.BigRecords).touchable = true;
	}
}
