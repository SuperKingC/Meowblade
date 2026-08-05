using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.PublicResources;

namespace UI.GvGWorldMap3;

public class UI_main_IslandPlayers : GComponent, IUiController
{
	public GGraph back;

	public UI_com_CampShipsInfoDialog Dialog;

	public const string URL = "ui://4eq8fgd2bqhp23";

	public static string Name = "UI_main_IslandPlayers";

	private Dictionary<int, List<GvGMode3IslandDetailInfo_PlayerInfos>> _playinfos_byCampId = new Dictionary<int, List<GvGMode3IslandDetailInfo_PlayerInfos>>();

	private List<GvGMode3IslandDetailInfo_PlayerInfos> _playinfos = new List<GvGMode3IslandDetailInfo_PlayerInfos>();

	private Dictionary<int, int> _score = new Dictionary<int, int>();

	private int _myUserId;

	private int _myCampId;

	private int _currentSelectCampId;

	private int _islandState;

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp23";
	}

	public static UI_main_IslandPlayers CreateInstance()
	{
		return (UI_main_IslandPlayers)(object)UIPackage.CreateObject("GvGWorldMap3", "main_IslandPlayers");
	}

	public static UI_main_IslandPlayers CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_IslandPlayers).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_CampShipsInfoDialog)(object)((GComponent)this).GetChild("Dialog");
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
		_playinfos = (parameters.TryGetValue("PlayerInfos", out var value) ? (value as List<GvGMode3IslandDetailInfo_PlayerInfos>) : new List<GvGMode3IslandDetailInfo_PlayerInfos>());
		Dictionary<int, HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.FlagShipStateModel>.KeyCollection keys = Singleton<WorldStateManager>.Instance.Data.FlagShips.Keys;
		_playinfos_byCampId = new Dictionary<int, List<GvGMode3IslandDetailInfo_PlayerInfos>>();
		foreach (int item in keys)
		{
			_playinfos_byCampId.Add(item, new List<GvGMode3IslandDetailInfo_PlayerInfos>());
		}
		foreach (GvGMode3IslandDetailInfo_PlayerInfos playinfo in _playinfos)
		{
			_playinfos_byCampId[playinfo.CampId].Add(playinfo);
		}
		_score = (parameters.TryGetValue("HoldingScore", out var value2) ? (value2 as Dictionary<int, int>) : new Dictionary<int, int>());
		_islandState = (parameters.TryGetValue("IslandState", out var value3) ? ((int)value3) : 0);
		if (_islandState == 2)
		{
			_islandState = 1;
		}
		_myUserId = GameController.Contexts.gameState.user.value.UserId;
		_myCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		RenderCampShipsInfoDialog();
	}

	public void OnShow()
	{
		SetCampSelected();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(ClosePanel));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(ClosePanel));
	}

	public void ClosePanel()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderCampShipsInfoDialog()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		_currentSelectCampId = 0;
		Dialog.CampList.RemoveChildrenToPool();
		foreach (KeyValuePair<int, List<GvGMode3IslandDetailInfo_PlayerInfos>> item in _playinfos_byCampId)
		{
			int key = item.Key;
			GObject val = Dialog.CampList.AddItemFromPool();
			if (key == _myCampId)
			{
				((GComponent)Dialog.CampList).SetChildIndex(val, 0);
				_currentSelectCampId = _myCampId;
			}
			CampListRenderer(item.Key, item.Value, (UI_com_CampShipsSlot)(object)val);
		}
	}

	private void CampListRenderer(int campId, List<GvGMode3IslandDetailInfo_PlayerInfos> playerInfos, UI_com_CampShipsSlot slot)
	{
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		slot.Fighting.selectedIndex = _islandState;
		((GObject)slot.ShipCount).text = $"{playerInfos.Count}";
		((GObject)slot.ShipsNumber).text = $"{playerInfos.Sum((GvGMode3IslandDetailInfo_PlayerInfos _p) => _p.ShipCount)}";
		slot.CampId.selectedIndex = campId;
		((GObject)slot.CampTitle).text = WorldMapConfigHelper.TryGetCampPrefabConfig(campId).CampName.ToLanguage() + LanguagesManager.GetDesc("CsharpCodeZhTcText309") + "：";
		((GObject)slot.Progress).text = $"{(float)(_score.TryGetValue(campId, out var value) ? value : 0) / 1000f * 100f:F1}%";
		slot.IsMyCamp.selectedIndex = ((campId == _myCampId) ? 1 : 0);
		((GObject)slot).data = campId;
		((GObject)slot.ToggleBtn).onClick.Set(new EventCallback1(SelectCamp));
		playerInfos.Sort(SortPlayerInfo);
		slot.ShipList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			UserRenderer(playerInfos[i], campId, (UI_com_CampPlayer)(object)o);
		};
		slot.ShipList.numItems = Mathf.Min(10, playerInfos.Count);
		slot.ShipList.ResizeToFit(10);
	}

	private int SortPlayerInfo(GvGMode3IslandDetailInfo_PlayerInfos a, GvGMode3IslandDetailInfo_PlayerInfos b)
	{
		if (a.UserId == _myUserId && b.UserId != _myUserId)
		{
			return -1;
		}
		if (b.UserId == _myUserId && a.UserId != _myUserId)
		{
			return 1;
		}
		return 0;
	}

	private void UserRenderer(GvGMode3IslandDetailInfo_PlayerInfos playerInfo, int campId, UI_com_CampPlayer slot)
	{
		((GObject)slot.ShipNumber).text = playerInfo.ShipCount.ToString();
		((GObject)slot).data = playerInfo;
		bool hideName = playerInfo.UserId == _myUserId;
		slot.IsMe.SetSelectedIndex(hideName ? 1 : 0);
		slot.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayCenter>
		{
			CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
			UserId = playerInfo.UserId,
			CampId = campId,
			OnProfileLoaded = delegate(UI_com_ProfileDisplayCenter profileUi)
			{
				profileUi.Style.SetSelectedIndex(hideName ? 1 : 0);
			}
		}, playerInfo.UserId);
	}

	private void SelectCamp(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)context.sender).parent is UI_com_CampShipsSlot uI_com_CampShipsSlot)
		{
			if (uI_com_CampShipsSlot.IsExpand.selectedIndex == 0)
			{
				_currentSelectCampId = (int)((GObject)uI_com_CampShipsSlot).data;
			}
			else
			{
				_currentSelectCampId = 0;
			}
			SetCampSelected();
		}
	}

	private void SetCampSelected()
	{
		for (int i = 0; i < Dialog.CampList.numItems; i++)
		{
			if (((GComponent)Dialog.CampList).GetChildAt(i) is UI_com_CampShipsSlot uI_com_CampShipsSlot)
			{
				uI_com_CampShipsSlot.IsExpand.selectedIndex = (((int)((GObject)uI_com_CampShipsSlot).data == _currentSelectCampId) ? 1 : 0);
				((GObject)uI_com_CampShipsSlot).height = ((uI_com_CampShipsSlot.IsExpand.selectedIndex == 0) ? ((GObject)uI_com_CampShipsSlot.TitleBack).height : ((GObject)uI_com_CampShipsSlot.ShipList).height);
			}
		}
	}
}
