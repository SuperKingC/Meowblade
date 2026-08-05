using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.BattleLog;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UnityEngine;

namespace UI.GvGBattleRecord3;

public class UI_main_GvG3IslandEventRanking : GComponent, IUiController
{
	public GGraph back;

	public UI_com_RandomEventRanking PopUp;

	public const string URL = "ui://b3fc6085phuh3q";

	public static string Name = "UI_main_GvG3IslandEventRanking";

	public const string RandomEvent = "RandomEvent";

	private eGvGMode3CampMissionSubType _subType;

	private string _processId;

	private List<IslandLogBrief> _islandLogBriefs = new List<IslandLogBrief>();

	private List<IslandLogBrief> _currentIslandLogBriefs = new List<IslandLogBrief>();

	private int _islandId;

	private bool _isBossBattle;

	private int _winnerCampId;

	private bool OnlyMyCamp => ((GButton)PopUp.CampSelect).selected;

	private int MyUserId => GameController.Contexts.gameState.user.value.UserId;

	private int MyCampId => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;

	public static string GetURL()
	{
		return "ui://b3fc6085phuh3q";
	}

	public static UI_main_GvG3IslandEventRanking CreateInstance()
	{
		return (UI_main_GvG3IslandEventRanking)(object)UIPackage.CreateObject("GvGBattleRecord3", "main_GvG3IslandEventRanking");
	}

	public static UI_main_GvG3IslandEventRanking CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3IslandEventRanking).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085phuh3q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		PopUp = (UI_com_RandomEventRanking)(object)((GComponent)this).GetChild("PopUp");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_processId = (parameters.TryGetValue("ProcessId", out var value) ? value.ToString() : string.Empty);
		_islandId = (parameters.TryGetValue("IslandId", out var value2) ? ((int)value2) : 0);
		_isBossBattle = parameters.TryGetValue("IsBossBattle", out var value3) && (bool)value3;
		_winnerCampId = (parameters.TryGetValue("WinnerCampId", out var value4) ? ((int)value4) : 0);
		object value5;
		string text = (parameters.TryGetValue("RandomEvent", out value5) ? value5.ToString() : string.Empty);
		int selectedIndex = 0;
		_subType = eGvGMode3CampMissionSubType.None;
		if (_isBossBattle)
		{
			selectedIndex = 1;
		}
		if (!string.IsNullOrEmpty(text))
		{
			GvGMode3EventMissionConfigModel gvGMode3EventMissionConfigModel = GvG3FlagShipMissionsConfigHelper.EventMissionConfig(text);
			_subType = gvGMode3EventMissionConfigModel.SubType;
			if (gvGMode3EventMissionConfigModel.SubType == eGvGMode3CampMissionSubType.RE_NPCEvent)
			{
				selectedIndex = 2;
			}
			else if (gvGMode3EventMissionConfigModel.SubType == eGvGMode3CampMissionSubType.RE_BossEvent)
			{
				selectedIndex = 3;
			}
		}
		PopUp.BattleType.SetSelectedIndex(selectedIndex);
		Singleton<GvGMode3BattleRecordsManager>.Instance.GetIslandLogBrief(_processId, RenderMainUi);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GButton)PopUp.CampSelect).onChanged.Add(new EventCallback0(UpdateLogBrief));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((GObject)back).onClick.Clear();
		((GButton)PopUp.CampSelect).onChanged.Remove(new EventCallback0(UpdateLogBrief));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderMainUi(List<IslandLogBrief> logBriefs)
	{
		if (logBriefs != null)
		{
			_islandLogBriefs = logBriefs.Clone();
			RenderMyRanking();
			UpdateLogBrief();
		}
	}

	private void UpdateLogBrief()
	{
		List<IslandLogBrief> list = new List<IslandLogBrief>();
		list = ((!OnlyMyCamp) ? _islandLogBriefs.Clone() : _islandLogBriefs.Where((IslandLogBrief log) => log.CampId == MyCampId).ToList());
		list.Sort((IslandLogBrief a, IslandLogBrief b) => GetRERankByType(a) - GetRERankByType(b));
		RenderUserRankingDataList(list);
	}

	private void RenderUserRankingDataList(List<IslandLogBrief> logBriefs)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		_currentIslandLogBriefs = logBriefs;
		PopUp.UserRankingData.SetVirtual();
		PopUp.UserRankingData.itemRenderer = new ListItemRenderer(RenderUserRankingItem);
		PopUp.UserRankingData.numItems = _currentIslandLogBriefs.Count;
	}

	private int GetRERankByType(IslandLogBrief logBrief)
	{
		if (_subType == eGvGMode3CampMissionSubType.RE_NPCEvent)
		{
			return logBrief.RENPCEventRank;
		}
		if (_subType == eGvGMode3CampMissionSubType.RE_BossEvent)
		{
			return logBrief.REBossEventRank;
		}
		return logBrief.RERank;
	}

	private void RenderUserRankingItem(int index, GObject obj)
	{
		UI_btn_RandomEventRanking btn = obj as UI_btn_RandomEventRanking;
		if (btn != null)
		{
			IslandLogBrief islandLogBrief = _currentIslandLogBriefs[index];
			int num = GetRERankByType(islandLogBrief) + 1;
			if (num <= 3)
			{
				btn.Rank.selectedIndex = num - 1;
			}
			else
			{
				btn.Rank.selectedIndex = 3;
			}
			((GObject)btn.Ranking).text = num.ToString();
			if (_subType == eGvGMode3CampMissionSubType.RE_NPCEvent)
			{
				((GObject)btn.RankData).text = islandLogBrief.MaxREKill.ToString();
			}
			else if (_subType == eGvGMode3CampMissionSubType.RE_BossEvent)
			{
				((GObject)btn.RankData).text = islandLogBrief.MaxREBossDamage.ShortNumberFormat();
			}
			else
			{
				((GObject)btn.RankData).text = (_isBossBattle ? islandLogBrief.REBossDamage.ShortNumberFormat() : Mathf.RoundToInt(islandLogBrief.TotalRESCore).ShortNumberFormat());
			}
			btn.UserIcon.CampId.selectedIndex = islandLogBrief.CampId;
			btn.Winner.selectedIndex = ((_winnerCampId == islandLogBrief.CampId) ? 1 : 0);
			GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", islandLogBrief.UserId, delegate(UserProfile profile)
			{
				((GObject)btn.UserName).text = profile.Name;
			}, delegate(Sprite sprite)
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0026: Expected O, but got Unknown
				btn.UserIcon.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}));
		}
	}

	private void RenderMyRanking()
	{
		IslandLogBrief islandLogBrief = _islandLogBriefs.FirstOrDefault((IslandLogBrief log) => log.UserId == MyUserId);
		if (islandLogBrief == null)
		{
			PopUp.Type.selectedIndex = 1;
			return;
		}
		PopUp.Type.selectedIndex = 0;
		UI_btn_MyEventRank btn = PopUp.MyRankingData;
		int num = GetRERankByType(islandLogBrief) + 1;
		if (num <= 3)
		{
			btn.Rank.selectedIndex = num - 1;
		}
		else
		{
			btn.Rank.selectedIndex = 3;
		}
		((GObject)btn.Ranking).text = num.ToString();
		if (_subType == eGvGMode3CampMissionSubType.RE_NPCEvent)
		{
			((GObject)btn.RankData).text = islandLogBrief.MaxREKill.ToString();
		}
		else if (_subType == eGvGMode3CampMissionSubType.RE_BossEvent)
		{
			((GObject)btn.RankData).text = islandLogBrief.MaxREBossDamage.ShortNumberFormat();
		}
		else
		{
			((GObject)btn.RankData).text = (_isBossBattle ? islandLogBrief.REBossDamage.ShortNumberFormat() : Mathf.RoundToInt(islandLogBrief.TotalRESCore).ShortNumberFormat());
		}
		btn.UserIcon.CampId.selectedIndex = islandLogBrief.CampId;
		btn.Winner.selectedIndex = ((_winnerCampId == islandLogBrief.CampId) ? 1 : 0);
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", islandLogBrief.UserId, delegate(UserProfile profile)
		{
			((GObject)btn.UserName).text = profile.Name;
		}, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			btn.UserIcon.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
	}
}
