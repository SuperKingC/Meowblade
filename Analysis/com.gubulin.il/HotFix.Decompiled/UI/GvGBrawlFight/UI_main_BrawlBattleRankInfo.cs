using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.SystemMessageParser;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.Helpers;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_main_BrawlBattleRankInfo : GComponent, IUiController
{
	private class ResultByDay
	{
		public BrawlEventSettleResult Result { get; set; }

		public List<BrawlCampRankInfos> RankInfos { get; set; }

		public bool IsEmpty()
		{
			return Result == null || RankInfos == null;
		}
	}

	public GGraph Mask;

	public UI_com_BrawBattleRankInfo RankInfo;

	public const string URL = "ui://hozu168rfnok9k";

	public static string Name = "UI_main_BrawlBattleRankInfo";

	private const string BRAWL_RANK = "BRAWL_RANK";

	private const string BRAWL_RESULT = "BrawlResult";

	private const string RANK_INFO_DATE = "RANK_INFO_DATE";

	private const string ON_CLOSE_ACTION = "ON_CLOSE_ACTION";

	private string _curDate;

	private Action _onCloseAction;

	private List<BrawlCampRankInfos> _rankInfos;

	private string _cacheId;

	private readonly List<GameObject> _loadedIslands = new List<GameObject>();

	private readonly Dictionary<IslandProps.SizeType, float> _islandUiSize = new Dictionary<IslandProps.SizeType, float>
	{
		{
			IslandProps.SizeType.Large,
			10f
		},
		{
			IslandProps.SizeType.Medium,
			15f
		},
		{
			IslandProps.SizeType.Small,
			25f
		}
	};

	private readonly List<GGraph> _allIslandGraphs = new List<GGraph>();

	private float _topY;

	private float _bottomY;

	public static string GetURL()
	{
		return "ui://hozu168rfnok9k";
	}

	public static UI_main_BrawlBattleRankInfo CreateInstance()
	{
		return (UI_main_BrawlBattleRankInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "main_BrawlBattleRankInfo");
	}

	public static UI_main_BrawlBattleRankInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BrawlBattleRankInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rfnok9k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		RankInfo = (UI_com_BrawBattleRankInfo)(object)((GComponent)this).GetChild("RankInfo");
	}

	public static void AutoOpenBrawlBattleRankInfo(C2S_BrawlEvent_GetInfo.Response claimedInfos, int beginTimestamp, Action<int> onClaimed, bool isFirst = false)
	{
		GeRankInfoByDay(claimedInfos.MaxCanRecordInLeaderboard, delegate(ResultByDay result)
		{
			string value = $"{DateTimeHelper.Parse(beginTimestamp).AddDays(result.Result.Day).ToLocalTime(): MM/dd}";
			GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
			{
				{ "RANK_INFO_DATE", value },
				{ "BRAWL_RANK", result.RankInfos },
				{
					"ON_CLOSE_ACTION",
					OpenBattleResult()
				}
			});
		});
		Action OpenBattleResult()
		{
			return delegate
			{
				UI_main_BrawlBattleResult.OpenBrawlBattleResultPanel(claimedInfos, beginTimestamp, onClaimed, isFirst);
			};
		}
	}

	public static void ManuallyOpenBrawlBattleRankInfo(int day, string date)
	{
		GeRankInfoByDay(day, delegate(ResultByDay result)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
			{
				{ "RANK_INFO_DATE", date },
				{ "BRAWL_RANK", result.RankInfos }
			});
		});
	}

	private static void GeRankInfoByDay(int day, Action<ResultByDay> onFinished)
	{
		List<BrawlCampRankInfos> rankInfos = TryGetRankInfoFromUnityPrefs(day);
		BrawlEventSettleResult result = TryGetResultFromUnityPrefs(day);
		ResultByDay resultByDay = new ResultByDay
		{
			RankInfos = rankInfos,
			Result = result
		};
		if (!resultByDay.IsEmpty())
		{
			onFinished?.Invoke(resultByDay);
		}
		else
		{
			RequestRankInfos(day, onFinished);
		}
	}

	private static void RequestRankInfos(int day, Action<ResultByDay> onFinished)
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
				SaveRankInfoToUnityPrefs(day, response.RankInfos);
				onFinished?.Invoke(new ResultByDay
				{
					RankInfos = response.RankInfos,
					Result = JsonHelper.ToObject<BrawlEventSettleResult>(response.jsonResult)
				});
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

	private static List<BrawlCampRankInfos> TryGetRankInfoFromUnityPrefs(int day)
	{
		string key = string.Format("{0}_{1}_Day{2}", "BRAWL_RANK", Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId, day);
		string text = GameLocalDataManager.GetString(key);
		return string.IsNullOrEmpty(text) ? null : JsonHelper.ToObject<List<BrawlCampRankInfos>>(text);
	}

	private static void SaveRankInfoToUnityPrefs(int day, List<BrawlCampRankInfos> infos)
	{
		string key = string.Format("{0}_{1}_Day{2}", "BRAWL_RANK", Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId, day);
		GameLocalDataManager.SetString(key, JsonHelper.ToJson(infos));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)RankInfo.Close).onClick.Set(new EventCallback0(ClosePanel));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(ForceClose));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)RankInfo.Close).onClick.Clear();
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Remove(instance.OnRoomClose, new Action(ForceClose));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_cacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";
		_curDate = ((parameters != null && parameters.TryGetValue("RANK_INFO_DATE", out var value)) ? (value as string) : string.Empty);
		((GObject)RankInfo.Date).text = _curDate;
		_onCloseAction = ((parameters != null && parameters.TryGetValue("ON_CLOSE_ACTION", out var value2)) ? (value2 as Action) : null);
		_rankInfos = ((parameters != null && parameters.TryGetValue("BRAWL_RANK", out var value3)) ? (value3 as List<BrawlCampRankInfos>) : null);
		if (_rankInfos != null)
		{
			_rankInfos.Sort((BrawlCampRankInfos a, BrawlCampRankInfos b) => a.PlayerRankInfo.Rank - b.PlayerRankInfo.Rank);
			RenderCampRankInfos();
		}
	}

	public void OnShow()
	{
		RuneGComponentsMaskInit();
		AllRuneGComponentsUpdateVisible();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		foreach (GameObject loadedIsland in _loadedIslands)
		{
			Object.Destroy((Object)(object)loadedIsland);
		}
	}

	private void ClosePanel()
	{
		End();
		_onCloseAction?.Invoke();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private static void ForceClose()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void RenderCampRankInfos()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		RankInfo.RankInfos.itemRenderer = new ListItemRenderer(CampRankInfoRenderer);
		RankInfo.RankInfos.numItems = _rankInfos?.Count ?? 0;
	}

	private void CampRankInfoRenderer(int index, GObject obj)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		BrawlCampRankInfos campRankInfo;
		if (obj is UI_com_CampRankInfo uI_com_CampRankInfo)
		{
			campRankInfo = _rankInfos[index];
			RenderCampRank(uI_com_CampRankInfo.CampRank, campRankInfo.PlayerRankInfo.CampId, campRankInfo.PlayerRankInfo.Rank - 1);
			((GObject)uI_com_CampRankInfo.Energy).text = (campRankInfo.RankRewardsConfig.Normal.TryGetValue("CampEnergy", out var value) ? value : 0).ToString();
			((GObject)uI_com_CampRankInfo.IslandCnt).text = campRankInfo.PlayerRankInfo.RankData.ToString();
			uI_com_CampRankInfo.PlayerRankInfos.itemRenderer = new ListItemRenderer(ItemRenderer);
			uI_com_CampRankInfo.PlayerRankInfos.numItems = campRankInfo.PlayerRankInfo.RankDataDetail.Count;
		}
		void ItemRenderer(int itemIndex, GObject item)
		{
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			UI_com_CampRankPlayerInfo rankUi = item as UI_com_CampRankPlayerInfo;
			if (rankUi != null)
			{
				GvGMode3PlayerRankDataDetail gvGMode3PlayerRankDataDetail = campRankInfo.PlayerRankInfo.RankDataDetail[itemIndex];
				rankUi.IsMvp.SetSelectedIndex((itemIndex == 0) ? 1 : 0);
				List<int> islands = (string.IsNullOrEmpty(gvGMode3PlayerRankDataDetail.Other) ? new List<int>() : JsonHelper.ToObject<List<int>>(gvGMode3PlayerRankDataDetail.Other));
				bool flag = islands.Count > 0;
				rankUi.HasIsland.SetSelectedIndex(flag ? 1 : 0);
				if (flag)
				{
					int izId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
					rankUi.Islands.itemRenderer = (ListItemRenderer)delegate(int islandIndex, GObject islandObj)
					{
						//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
						//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
						//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
						//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
						//IL_0100: Expected O, but got Unknown
						//IL_012e: Unknown result type (might be due to invalid IL or missing references)
						//IL_0133: Unknown result type (might be due to invalid IL or missing references)
						if (islandObj is UI_com_BrawlIslandIcon uI_com_BrawlIslandIcon)
						{
							int islandId = islands[islandIndex];
							IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(islandId);
							string sprite = WorldMapConfigHelper.GetSprite(islandConfigData.Props, izId);
							GameObject val = GvGWorldMapController.Instance.InstantiateFromPrefab(sprite);
							_loadedIslands.Add(val);
							((GObject)uI_com_BrawlIslandIcon.IslandIcon).displayObject.Dispose();
							float value2;
							float num = (_islandUiSize.TryGetValue(islandConfigData.Props.GetSizeType(), out value2) ? value2 : 25f);
							val.transform.localScale = Vector3.op_Implicit(new Vector3(num, num, num));
							val.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
							GoWrapper val2 = new GoWrapper(val);
							((DisplayObject)val2).SetXY(0f, 0f);
							((DisplayObject)val2).pivot = Vector2.op_Implicit(new Vector2(((GObject)this).x, 0.5f));
							uI_com_BrawlIslandIcon.IslandIcon.SetNativeObject((DisplayObject)(object)val2);
							AllRuneGComponentsAdd(uI_com_BrawlIslandIcon.IslandIcon);
							RuneGComponentSetVisible(uI_com_BrawlIslandIcon.IslandIcon);
						}
					};
					rankUi.Islands.numItems = islands.Count;
				}
				((GObject)rankUi.Score).text = gvGMode3PlayerRankDataDetail.Value.ToString();
				int key = gvGMode3PlayerRankDataDetail.Key;
				GLoader userIconLoader = rankUi.Avatar.GetChild("HeadPortrait").asCom.GetChild("icon").asLoader;
				Controller campCtr = rankUi.Avatar.GetController("CampId");
				GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_cacheId, key, delegate(UserProfile profile)
				{
					if (!((GObject)rankUi).isDisposed)
					{
						((GObject)rankUi.PlayerName).text = profile.Name;
					}
				}, delegate(Sprite sprite)
				{
					//IL_001e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0028: Expected O, but got Unknown
					if (!((GObject)userIconLoader).isDisposed)
					{
						userIconLoader.texture = new NTexture((Texture)(object)sprite.texture);
						campCtr.SetSelectedIndex(campRankInfo.PlayerRankInfo.CampId);
					}
				}));
			}
		}
	}

	private static void RenderCampRank(UI_com_CampRank rankUi, int campId, int rank)
	{
		rankUi.Camp.SetSelectedIndex(campId);
		rankUi.Rank.SetSelectedIndex(rank);
	}

	private void RuneGComponentsMaskInit()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)RankInfo.RankInfos).EnsureBoundsCorrect();
		float y = ((GObject)RankInfo.RankInfos).LocalToRoot(Vector2.op_Implicit(Vector2.zero), GRoot.inst).y;
		_topY = y + 18f;
		_bottomY = _topY + ((GObject)RankInfo.RankInfos).height - 25f;
		((GComponent)RankInfo.RankInfos).scrollPane.onScroll.Set(new EventCallback0(AllRuneGComponentsUpdateVisible));
	}

	private void AllRuneGComponentsAdd(GGraph rune)
	{
		if (!_allIslandGraphs.Contains(rune))
		{
			_allIslandGraphs.Add(rune);
		}
	}

	private void AllRuneGComponentsUpdateVisible()
	{
		foreach (GGraph allIslandGraph in _allIslandGraphs)
		{
			RuneGComponentSetVisible(allIslandGraph);
		}
	}

	private void RuneGComponentSetVisible(GGraph islandGraph)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if (islandGraph != null)
		{
			Vector2 val = ((GObject)islandGraph).LocalToRoot(Vector2.op_Implicit(Vector2.zero), GRoot.inst);
			((GObject)islandGraph).visible = _topY <= val.y && _bottomY >= val.y;
		}
	}
}
