using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.Helpers;
using UI.GvGBattleRecord3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlBattleResult : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BrawlBattleResult BattleInofs;

	public Transition t0;

	public const string URL = "ui://hozu168rnq4c3k";

	public static string Name = "UI_main_BrawlBattleResult";

	private const string ON_CLAIMED_ACTION = "ON_CLAIMED_ACTION";

	private const string CLAIMED_INFOS = "CLAIMED_INFOS";

	private const string IZ_BEGIN_TIMESTAMP = "IZBeginTimestamp";

	private const string SETTLE_RESULT = "SETTLE_RESULT";

	private const string TODAY_FIRST = "TODAY_FIRST";

	private const string CHECK_BRAWL_CLAIMED_TIP = "CHECK_BRAWL_CLAIMED_TIP";

	private const string BRAWL_RESULT = "BrawlResult";

	private const string ISLAND_ICON_PREFIX = "Brawl_";

	private C2S_BrawlEvent_GetInfo.Response _eventInfo;

	private Action<int> _onClaimed;

	private List<IBrawlClaimedUiInfo> _claimedUiInfos;

	private int _curDay;

	private bool _isBattleResultAvilable;

	private bool _isTodayFirst;

	private List<RItem> _buffItems;

	private readonly Dictionary<BrawlSettleBonusUiType, string> _bonusUis = new Dictionary<BrawlSettleBonusUiType, string>
	{
		{
			BrawlSettleBonusUiType.SelfContribution,
			"SelfContribution"
		},
		{
			BrawlSettleBonusUiType.Self,
			"SelfBonus"
		},
		{
			BrawlSettleBonusUiType.SelfExtra,
			"SelfExtraBonus"
		},
		{
			BrawlSettleBonusUiType.Camp,
			"CampBonus"
		},
		{
			BrawlSettleBonusUiType.CampExtra,
			"CampExtraBonus"
		},
		{
			BrawlSettleBonusUiType.Final,
			"FinalBonus"
		}
	};

	public static string GetURL()
	{
		return "ui://hozu168rnq4c3k";
	}

	public static UI_main_BrawlBattleResult CreateInstance()
	{
		return (UI_main_BrawlBattleResult)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlBattleResult");
	}

	public static UI_main_BrawlBattleResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlBattleResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnq4c3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		BattleInofs = (UI_com_BrawlBattleResult)(object)((GComponent)this).GetChild("BattleInofs");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public static void OpenBrawlBattleResultPanel(C2S_BrawlEvent_GetInfo.Response claimedInfos, int beginTimestamp, Action<int> onClaimed, bool isFirst = false)
	{
		GetResultByDay(claimedInfos.MaxCanRecordInLeaderboard, delegate(BrawlEventSettleResult result)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
			{
				{ "ON_CLAIMED_ACTION", onClaimed },
				{ "CLAIMED_INFOS", claimedInfos },
				{ "IZBeginTimestamp", beginTimestamp },
				{ "SETTLE_RESULT", result },
				{ "TODAY_FIRST", isFirst }
			});
		});
	}

	private static List<IBrawlClaimedUiInfo> ConvertClaimedInfos(C2S_BrawlEvent_GetInfo.Response infos, int beginTimestamp)
	{
		DateTimeOffset begin = DateTimeHelper.Parse(beginTimestamp);
		IEnumerable<BrawlClaimedUiInfo> collection = infos.ClaimedInfos.Select((BrawlEventSettleClaimedInfo info) => new BrawlClaimedUiInfo(info, infos.MaxCanRecordInLeaderboard, begin));
		return new List<IBrawlClaimedUiInfo>(collection);
	}

	private static void GetResultByDay(int day, Action<BrawlEventSettleResult> onFinished)
	{
		BrawlEventSettleResult brawlEventSettleResult = TryGetResultFromUnityPrefs(day);
		if (brawlEventSettleResult != null)
		{
			onFinished?.Invoke(brawlEventSettleResult);
		}
		else
		{
			RequestSettleResult(day, onFinished);
		}
	}

	private static void RequestSettleResult(int day, Action<BrawlEventSettleResult> onFinished)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_GetResultByDay
		{
			Req = new C2S_BrawlEvent_GetResultByDay.Request
			{
				Day = day
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_GetResultByDay.Response response = (C2S_BrawlEvent_GetResultByDay.Response)contextResponse.Resp;
			if (response.ErrorCode == -9517)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				response.ErrorCode = 0;
				GvGMode3BrawlEvent_BaseInfo gvGMode3BrawlEvent_BaseInfo = WorldMapConfigHelper.Configs.TryGetBrawlEventByDay(day);
				int userId = GameController.Contexts.gameState.user.value.UserId;
				BrawlEventSettleResult obj = new BrawlEventSettleResult
				{
					Day = day,
					StepIdx = gvGMode3BrawlEvent_BaseInfo.StepIdx,
					UserId = userId
				};
				response.jsonResult = JsonHelper.ToJson(obj);
			}
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (string.IsNullOrEmpty(response.jsonResult))
				{
					throw new Exception($"[UI_main_BrawlBattleResult]:GetResultByDay day={day},jsonResult is null or empty");
				}
				SaveResultToUnityPrefs(day, response.jsonResult);
				BrawlEventSettleResult obj2 = JsonHelper.ToObject<BrawlEventSettleResult>(response.jsonResult);
				onFinished(obj2);
			}
		});
	}

	private static BrawlEventSettleResult TryGetResultFromUnityPrefs(int day)
	{
		string key = string.Format("{0}_{1}_Day{2}", "BrawlResult", Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId, day);
		string text = GameLocalDataManager.GetString(key);
		return string.IsNullOrEmpty(text) ? null : JsonHelper.ToObject<BrawlEventSettleResult>(text);
	}

	private static void SaveResultToUnityPrefs(int day, string json)
	{
		string key = string.Format("{0}_{1}_Day{2}", "BrawlResult", Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId, day);
		GameLocalDataManager.SetString(key, json);
	}

	private static void ClaimedBattleResult(int day, Action<int, int> onClaimed)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BrawlEvent_ClaimResultByDay
		{
			Req = new C2S_BrawlEvent_ClaimResultByDay.Request
			{
				Day = day
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BrawlEvent_ClaimResultByDay.Response response = (C2S_BrawlEvent_ClaimResultByDay.Response)contextResponse.Resp;
			if (response.ErrorCode == -9516)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				return;
			}
			onClaimed(day, response.ErrorCode);
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)BattleInofs.Close).onClick.Set(new EventCallback0(OnCloseClick));
		((GObject)BattleInofs.Calendar).onClick.Set(new EventCallback0(OpenCalendar));
		((GObject)BattleInofs.Claim).onClick.Set(new EventCallback0(ClaimedResult));
		((GObject)BattleInofs.CampRankDetail).onClick.Set(new EventCallback0(OpenCampRankInfos));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BattleInofs.Close).onClick.Clear();
		((GObject)BattleInofs.Calendar).onClick.Clear();
		((GObject)BattleInofs.Claim).onClick.Clear();
		((GObject)BattleInofs.CampRankDetail).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_onClaimed = (Action<int>)parameters["ON_CLAIMED_ACTION"];
		C2S_BrawlEvent_GetInfo.Response response = (C2S_BrawlEvent_GetInfo.Response)parameters["CLAIMED_INFOS"];
		int beginTimestamp = (int)parameters["IZBeginTimestamp"];
		_claimedUiInfos = ConvertClaimedInfos(response, beginTimestamp);
		_eventInfo = response;
		_isTodayFirst = (bool)parameters["TODAY_FIRST"];
		BrawlEventSettleResult result = (BrawlEventSettleResult)parameters["SETTLE_RESULT"];
		RenderDaySettleResult(result);
		C2S_BrawlEvent_GetInfo.Stage stage = response.GetStage();
		if (stage == C2S_BrawlEvent_GetInfo.Stage.WaitStart || stage == C2S_BrawlEvent_GetInfo.Stage.Fighting)
		{
			"BrawlBattleNotCompleteTip".ToShowLanguageTip();
		}
	}

	public void OnShow()
	{
		UpdateCalendarNote();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OpenCalendar()
	{
		UI_main_BrawlCalendar.OpenBrawlCalendarPanel(_claimedUiInfos, OnSelectDay, _curDay);
	}

	private void ClaimedResult()
	{
		ClaimedBattleResult(_curDay, OnClaimedResult);
	}

	private void OpenCampRankInfos()
	{
		UI_main_BrawlBattleRankInfo.ManuallyOpenBrawlBattleRankInfo(_curDay, ((GObject)BattleInofs.Calendar.Date).text);
	}

	private void OnCloseClick()
	{
		End();
	}

	private void OnClaimedResult(int day, int errorCode)
	{
		if (errorCode == 0)
		{
			_onClaimed?.Invoke(day);
			UpdateClaimedUiInfos(day);
			"CHECK_BRAWL_CLAIMED_TIP".ToShowLanguageTip();
		}
		else
		{
			_onClaimed?.Invoke(day);
		}
		foreach (BrawlEventSettleClaimedInfo claimedInfo in _eventInfo.ClaimedInfos)
		{
			if (claimedInfo.Day == day)
			{
				claimedInfo.IsClaimed = true;
			}
		}
		GameManagers.Instance.Messenger.Broadcast("BRAWL_EVENT_SIGN_UP_CHANGE", _eventInfo);
		End();
	}

	private void UpdateClaimedUiInfos(int day)
	{
		IBrawlClaimedUiInfo brawlClaimedUiInfo = _claimedUiInfos.Find((IBrawlClaimedUiInfo info) => info.DayIndex == day);
		if (brawlClaimedUiInfo != null)
		{
			brawlClaimedUiInfo.SetClaimed();
			UpdateCalendarNote();
		}
	}

	private void OnSelectDay(int day)
	{
		GetResultByDay(day, RenderDaySettleResult);
	}

	private void UpdateCalendarNote()
	{
		int pending = 0;
		((GObject)BattleInofs.Calendar.redPoint).visible = _claimedUiInfos.Any((IBrawlClaimedUiInfo info) => info.ClaimedStatus == pending);
	}

	private void RenderDaySettleResult(BrawlEventSettleResult result)
	{
		_curDay = result.Day;
		int num = UI_main_BrawlFightEnroll.WhatDayIsToday();
		_isBattleResultAvilable = num - 1 == _curDay;
		List<IBrawlSettleUiInfo> infos = ReadBrawlSettleUiInfos(result);
		_buffItems = TryGetBuffItems(infos);
		RenderSettleInfos(infos);
		bool flag = result.StepIdx >= 100;
		BattleInofs.IsFinal.SetSelectedIndex(flag ? 1 : 0);
		IBrawlClaimedUiInfo brawlClaimedUiInfo = _claimedUiInfos.Find((IBrawlClaimedUiInfo info) => info.DayIndex == _curDay);
		if (brawlClaimedUiInfo != null)
		{
			((GObject)BattleInofs.Calendar.Date).text = brawlClaimedUiInfo.Date;
			BattleInofs.Claimed.SetSelectedIndex(brawlClaimedUiInfo.ClaimedStatus);
		}
	}

	private static List<IBrawlSettleUiInfo> ReadBrawlSettleUiInfos(BrawlEventSettleResult result)
	{
		if (result.Infos == null)
		{
			return new List<IBrawlSettleUiInfo>();
		}
		List<IBrawlSettleUiInfo> source = new List<IBrawlSettleUiInfo>(result.Infos.Select((BrawlEventSettleInfo info) => new BrawlSettleUiInfo(info, result.StepIdx)));
		return (from info in source
			orderby info.UserRank == -1, info.UserRank
			select info).ToList();
	}

	private static List<RItem> TryGetBuffItems(List<IBrawlSettleUiInfo> infos)
	{
		List<RItem> list = new List<RItem>();
		int isBuff = 51;
		foreach (IBrawlSettleUiInfo info in infos)
		{
			if (info.Bonuses.TryGetValue(BrawlSettleBonusUiType.Final, out var value))
			{
				List<RItem> collection = value.Bonuses.Where((RItem bonus) => Item.ItemType(bonus.ItemId) == isBuff).ToList();
				list.AddRange(collection);
			}
		}
		return list;
	}

	private void RenderSettleInfos(List<IBrawlSettleUiInfo> infos)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		bool flag = infos.Count <= 0;
		BattleInofs.isEmpty.SetSelectedIndex(flag ? 1 : 0);
		if (!flag)
		{
			BattleInofs.BrawlEventSettleInfos.SetVirtual();
			BattleInofs.BrawlEventSettleInfos.itemRenderer = new ListItemRenderer(SettleInfoRenderer);
			BattleInofs.BrawlEventSettleInfos.numItems = infos.Count;
		}
		void SettleInfoRenderer(int index, GObject obj)
		{
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			if (!(obj is UI_com_BrawlEventSettleInfo uI_com_BrawlEventSettleInfo))
			{
				throw new Exception("[UI_main_BrawlBattleResult]:SettleInfoRenderer obj is not UI_com_BrawlEventSettleInfo");
			}
			IBrawlSettleUiInfo brawlSettleUiInfo = infos[index];
			uI_com_BrawlEventSettleInfo.IsFinal.SetSelectedIndex(brawlSettleUiInfo.Progress);
			RenderBrawlIslandInfo(uI_com_BrawlEventSettleInfo.Island, brawlSettleUiInfo.IslandInfo);
			RenderBrawlRankInfos(uI_com_BrawlEventSettleInfo, brawlSettleUiInfo.RankUiInfos);
			RenderBrawlBonuses(uI_com_BrawlEventSettleInfo, brawlSettleUiInfo.Bonuses);
			uI_com_BrawlEventSettleInfo.GotoIslandRecord.Status.SetSelectedIndex((!_isBattleResultAvilable) ? 1 : 0);
			((GObject)uI_com_BrawlEventSettleInfo.GotoIslandRecord).data = brawlSettleUiInfo.IslandId;
			((GObject)uI_com_BrawlEventSettleInfo.GotoIslandRecord).onClick.Set(new EventCallback1(OnGotoIslandRecordClick));
		}
	}

	private void RenderBrawlIslandInfo(UI_btn_BattleResultIsland btn, IBrawlIslandUiInfo info)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		btn.Mode.url = info.BrawlModeIcon;
		((GObject)btn.IslandName).text = info.IslandName;
		btn.islandicon.url = string.Format("ui://GvGBrawlFight/{0}{1}", "Brawl_", WorldMapConfigHelper.Configs.TryGetIsland(info.IslandId).Props.Type);
		((GObject)btn).data = info;
		((GObject)btn).onClick.Set(new EventCallback1(OpenIslandBonusPreview));
	}

	private void RenderBrawlRankInfos(UI_com_BrawlEventSettleInfo btn, Dictionary<BrawlRankType, IBrawlRankUiInfo> uiInfos)
	{
		foreach (KeyValuePair<BrawlRankType, IBrawlRankUiInfo> uiInfo in uiInfos)
		{
			switch (uiInfo.Key)
			{
			case BrawlRankType.User:
				RenderBrawlRankInfo(btn.UserScore, uiInfo.Value);
				break;
			case BrawlRankType.Camp:
				RenderBrawlRankInfo(btn.CampScore, uiInfo.Value);
				break;
			}
		}
	}

	private void RenderBrawlRankInfo(UI_btn_BattleScore btn, IBrawlRankUiInfo info)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		btn.HasScore.SetSelectedIndex(info.HasScore);
		if (info.HasScore != 0)
		{
			btn.ScoreType.SetSelectedIndex(info.Progress);
			btn.RankType.SetSelectedIndex(info.RankType);
			((GObject)btn.Score).text = info.RankScore.ShortNumberFormat();
			((GObject)btn.Ranking.Ranking).text = info.Rank.ToString();
			if (info.RankType == 1)
			{
				btn.Ranking.RankType.SetSelectedIndex(3);
			}
			else if (info.Rank > 3)
			{
				btn.Ranking.RankType.SetSelectedIndex(3);
			}
			else
			{
				btn.Ranking.RankType.SetSelectedIndex(info.Rank - 1);
			}
			int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			btn.CampIcon.CampId.SetSelectedIndex(obCampId);
			((UI_com_ShipSmallIcon)(object)btn.ShipRace).SetShipStyle(info.ShipRace, obCampId);
			((GObject)btn.Buff).visible = info.HasExtraScorePar;
			((GObject)btn.Buff).data = eFairyGUITipDir.Right;
			((GObject)btn.Buff).onClick.Set(new EventCallback1(info.DisplayBuffInfo));
		}
	}

	private void RenderBrawlBonuses(UI_com_BrawlEventSettleInfo btn, Dictionary<BrawlSettleBonusUiType, IBrawlBonusUiInfo> bonuses)
	{
		foreach (KeyValuePair<BrawlSettleBonusUiType, string> bonusUi in _bonusUis)
		{
			UI_btn_BonusWrapper uI_btn_BonusWrapper = ((UI_btn_BonusWrapper)(object)((GComponent)btn).GetChild(bonusUi.Value)) ?? throw new Exception("[UI_main_BrawlBattleResult]:RenderBrawlBonuses wrapper is not UI_btn_BonusWrapper");
			if (bonuses.TryGetValue(bonusUi.Key, out var value))
			{
				RenderBonusWrapper(uI_btn_BonusWrapper, value);
			}
			else
			{
				uI_btn_BonusWrapper.HasBonus.SetSelectedIndex(0);
			}
		}
	}

	private static void RenderBonusWrapper(UI_btn_BonusWrapper wrapper, IBrawlBonusUiInfo bonus)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		wrapper.HasBonus.SetSelectedIndex(1);
		((GObject)wrapper.Buff).visible = bonus.HasBuff;
		wrapper.RItems.itemRenderer = new ListItemRenderer(ItemRenderer);
		wrapper.RItems.numItems = bonus.Bonuses.Count;
		((GObject)wrapper.Buff).data = bonus;
		((GObject)wrapper.Buff).onClick.Set(new EventCallback1(DisplayBonusBuff));
		void ItemRenderer(int index, GObject obj)
		{
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			if (!(obj is UI_btn_BrawlBonus uI_btn_BrawlBonus))
			{
				throw new Exception("[UI_main_BrawlBattleResult]:RenderBonusWrapper.ItemRenderer obj is not UI_btn_BrawlBonus");
			}
			RItem rItem = bonus.Bonuses[index];
			GDEItemData itemConfig = GDMgr.Get<GDEItemData>(rItem.ItemId);
			bool flag = UI_com_buff.IsSpecialBuff(itemConfig);
			if (flag)
			{
				uI_btn_BrawlBonus.ItemIcon.url = "ui://GvGBrawlFight/com_buff";
				UI_com_buff uI_com_buff = (UI_com_buff)(object)uI_btn_BrawlBonus.ItemIcon.component;
				uI_com_buff.Render(itemConfig, rItem.cnt, UI_com_buff.ShowMode.UpArrow);
				((GObject)uI_btn_BrawlBonus.Num).text = $"LV +{rItem.cnt}";
			}
			else
			{
				FGUIManager.Instance.SetItemIconAndFrame(uI_btn_BrawlBonus.ItemIcon, rItem.ItemId);
				((GObject)uI_btn_BrawlBonus.Num).text = rItem.cnt.ToString();
			}
			uI_btn_BrawlBonus.SelfExecuting.SetSelectedIndex(flag ? 1 : 0);
			((GObject)uI_btn_BrawlBonus).data = rItem;
			((GObject)uI_btn_BrawlBonus).onClick.Set(new EventCallback1(DisplayItemTip));
		}
	}

	private static void DisplayBonusBuff(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		IBrawlBonusUiInfo brawlBonusUiInfo = (IBrawlBonusUiInfo)((GObject)context.sender).data;
		brawlBonusUiInfo.DisplayBuffInfo(context);
	}

	private static void DisplayItemTip(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		RItem rItem = (RItem)val.data;
		rItem.ItemId.DisplayItemTip(hideCheckBtn: true, new ItemTipParams
		{
			ItemCount = rItem.cnt,
			SkillPopupPos = new Vector2(960f, 665f)
		});
	}

	private void OnGotoIslandRecordClick(EventContext context)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (!_isBattleResultAvilable)
		{
			"BrawlEventResultNotAvailable".ToShowLanguageTip();
			return;
		}
		int num = (int)((GObject)context.sender).data;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandBattleRecordPanel.Name, new Dictionary<string, object> { { "IslandId", num } });
	}

	private static void OpenIslandBonusPreview(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		IBrawlIslandUiInfo brawlIslandUiInfo = (IBrawlIslandUiInfo)((GObject)context.sender).data;
		UI_main_BrawlIslandBonusPreview.OpenBrawlIslandBonusPreview(new BrawlPreviewBonusParams
		{
			MissionConfigId = brawlIslandUiInfo.MConfigId,
			IslandSubType = brawlIslandUiInfo.IslandSubType,
			MUID = brawlIslandUiInfo.MUID,
			IsFinal = brawlIslandUiInfo.IsFinal
		});
	}

	private void TryOpenBuffListPanel()
	{
		if (_isTodayFirst)
		{
			List<RItem> buffItems = _buffItems;
			if (buffItems != null && buffItems.Count > 0)
			{
				UnityUiService.Instance.OpenPanel(UI_main_BrawlBuffInfo.Name, new Dictionary<string, object> { { "LevelUpBuffs", _buffItems } });
			}
		}
	}
}
