using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvG3LandOfEternalNight;
using UI.GvG3MainStorylineQuest;
using UI.GvGWorldMap3;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3FlagShipMissionsManager : Singleton<GvG3FlagShipMissionsManager>
{
	private GvG3FlagShipMissionsUiModel _model;

	public Action<C2S_GetFinalProgressRank.Response> RenderEternalNightRank = delegate
	{
	};

	public Action<List<FinalProgressBossDamageInfo>> RenderBossDamage = delegate
	{
	};

	public Action OnCampProgressChange = delegate
	{
	};

	public Action OnFinalProgressInfoChange = delegate
	{
	};

	public Action<CampEnergyDetails> RenderCampEnergyDetails = delegate
	{
	};

	public Action<CampRankReward> RenderCampMainProgressRankReward = delegate
	{
	};

	public Action<CampMainMissionUiModel> RenderMainMissions = delegate
	{
	};

	public Action<int> RenderJumpEnergyByAutoGetCampEnergy = delegate
	{
	};

	public Action<List<CampSideMissionsUiModel>> RenderSideMissions = delegate
	{
	};

	public Action<CampProgressRedDot> RenderPage = delegate
	{
	};

	public Action<bool> UpdateMainUiMissionRedDot = delegate
	{
	};

	private Coroutine _updateFinalProgressInfo;

	private Coroutine _Coroutine_AutoGetCampEnergy;

	private readonly WaitForSeconds _perSeconds = new WaitForSeconds(60f);

	private bool _finalProgressInfoRefreshing;

	private readonly string _openEternalNightTransitionPlayHistoryKey = $"EternalNightTransitionPlay_Step1_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}__{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{GameController.Contexts.gameState.user.value.UserId}";

	private readonly string _bossEternalNightTransitionPlayHistoryKey = $"EternalNightTransitionPlay_Step2_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}__{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{GameController.Contexts.gameState.user.value.UserId}";

	private const byte MaxProgress = 5;

	private bool WorldClosed => Singleton<GvGMode3RoomManager>.Instance.IsRoomClosed;

	public bool IsWaitEternalNight => _model.CurProgress == 5;

	public bool IsWaitEternalNightProgress => _model.CheckCampProgress == 5 || (_model.CheckCampProgress == 6 && !EternalNightOpen);

	public bool IsEternalNight => Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress == 6;

	public bool IsEternalNightProgress => _model.CheckCampProgress == 6;

	public bool HasSettlement => Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement;

	public C2S_GetFinalProgressInfo.Response FinalProgressInfo => _model.FinalProgressInfo;

	public BindableProperty<string> FinalBossIcon => _model.FinalBossIcon;

	public CampMainMissionUiModel EternalNightMainMission => _model.GetMainMission(isCurrent: true);

	public bool EternalNightOpen => PlayerPrefs.HasKey(_openEternalNightTransitionPlayHistoryKey) && PlayerPrefs.GetInt(_openEternalNightTransitionPlayHistoryKey) > 0;

	public bool EternalNightBossAppear => PlayerPrefs.HasKey(_bossEternalNightTransitionPlayHistoryKey) && PlayerPrefs.GetInt(_bossEternalNightTransitionPlayHistoryKey) > 0;

	public void Init()
	{
		_model = new GvG3FlagShipMissionsUiModel();
		RefreshFinalProgressInfo();
	}

	public void RegisterSocketEvents()
	{
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(UpdateCampProgress));
		S2C_SyncFinalProgressInfo.OnPushEvent = (Action<S2C_SyncFinalProgressInfo.Request>)Delegate.Combine(S2C_SyncFinalProgressInfo.OnPushEvent, new Action<S2C_SyncFinalProgressInfo.Request>(SyncFinalProgressInfo));
		S2C_GetFinalProgressBossDamageTodayTop3.OnPushEvent = (Action<S2C_GetFinalProgressBossDamageTodayTop3.Request>)Delegate.Combine(S2C_GetFinalProgressBossDamageTodayTop3.OnPushEvent, new Action<S2C_GetFinalProgressBossDamageTodayTop3.Request>(SyncFinalProgressBossDamageTodayTop3));
		SharedMessenger.AddListener<string>("CLOSE_UI", StopAutoGetCampEnergy);
	}

	public void UnregisterSocketEvents()
	{
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(UpdateCampProgress));
		S2C_SyncFinalProgressInfo.OnPushEvent = (Action<S2C_SyncFinalProgressInfo.Request>)Delegate.Remove(S2C_SyncFinalProgressInfo.OnPushEvent, new Action<S2C_SyncFinalProgressInfo.Request>(SyncFinalProgressInfo));
		S2C_GetFinalProgressBossDamageTodayTop3.OnPushEvent = (Action<S2C_GetFinalProgressBossDamageTodayTop3.Request>)Delegate.Remove(S2C_GetFinalProgressBossDamageTodayTop3.OnPushEvent, new Action<S2C_GetFinalProgressBossDamageTodayTop3.Request>(SyncFinalProgressBossDamageTodayTop3));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", StopAutoGetCampEnergy);
	}

	public void ClearData()
	{
		if (_updateFinalProgressInfo != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateFinalProgressInfo);
			_updateFinalProgressInfo = null;
		}
		StopAutoGetCampEnergy(UI_main_FlagShipMissions.Name);
		_finalProgressInfoRefreshing = false;
		_model = null;
	}

	public void UpdateModelCurProgress()
	{
		if (_model != null)
		{
			_model.CheckCampProgress = _model.CurProgress;
		}
	}

	private void UpdateCampProgress()
	{
		RefreshFinalProgressInfo();
		OnCampProgressChange?.Invoke();
	}

	private void SyncFinalProgressInfo(S2C_SyncFinalProgressInfo.Request request)
	{
		if (request.ErrorCode < 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
			return;
		}
		if (Singleton<WorldStateManager>.Instance.Data.ProgressData == null)
		{
			Singleton<WorldStateManager>.Instance.Data.ProgressData = new CampProgressData();
		}
		Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress = request.Progress;
		Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep = request.Step;
		Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement = request.HasSettlement;
		Singleton<WorldStateManager>.Instance.Data.ProgressData.SettlementTimestamp = request.SettlementTimestamp;
		GetFinalProgressInfo();
	}

	public void UpdateSelfShadowStoneCount(int stoneCount)
	{
		_model.UpdateSelfShadowStoneCount(stoneCount);
	}

	public ItemAbility ChangeCampBuffLevel(int changeCampBuffLevel)
	{
		ItemAbility itemAbility = null;
		List<List<string>> playerBuffQueue = Singleton<WorldStateManager>.Instance.Data.ProgressData.PlayerBuffQueue;
		Dictionary<List<string>, int> dictionary = new Dictionary<List<string>, int>();
		foreach (List<string> item in playerBuffQueue)
		{
			dictionary.Add(item.ToList(), 0);
		}
		int count = playerBuffQueue.Count;
		for (int i = 0; i < changeCampBuffLevel; i++)
		{
			int num = i;
			if (num >= count)
			{
				num = i % count;
			}
			List<string> list = playerBuffQueue[num];
			if (!dictionary.ContainsKey(list))
			{
				dictionary.Add(list, 1);
			}
			else
			{
				dictionary[list]++;
			}
			if (i == changeCampBuffLevel - 1)
			{
				itemAbility = new ItemAbility
				{
					AbilityId = list[0]
				};
				itemAbility.SetLevel(dictionary[list]);
			}
		}
		return itemAbility;
	}

	public void SubmitShadowEnergy(Action<int> onFinished = null, Dictionary<string, int> submitBonus = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SubmitShadowEnergy
		{
			Req = new C2S_SubmitShadowEnergy.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_SubmitShadowEnergy.Response response = (C2S_SubmitShadowEnergy.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				FinalProgressInfo.CampShadowEnergy = response.CampShadowEnergy;
				SyncGsStock();
				onFinished?.Invoke((int)response.CampShadowEnergy);
			}
		});
		void SyncGsStock()
		{
			StockChangeRecord[] stockChangeRecords = (submitBonus?.ToStockChangeRecords(StockInContext.AutoFill))?.Where((StockChangeRecord record) => !StorehouseHelper.IsGvGItem(record.ItemId)).ToArray();
			GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
		}
	}

	public void GetFinalProgressRank()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetFinalProgressRank
		{
			Req = new C2S_GetFinalProgressRank.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetFinalProgressRank.Response response = (C2S_GetFinalProgressRank.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				RenderEternalNightRank?.Invoke(response);
			}
		});
	}

	public void GetFinalProgressInfo(bool showWaitingUi = true)
	{
		if (WorldClosed || WorldMapConfigHelper.Configs.IsBrawlEvent() || _finalProgressInfoRefreshing)
		{
			return;
		}
		_finalProgressInfoRefreshing = true;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetFinalProgressInfo
		{
			Req = new C2S_GetFinalProgressInfo.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetFinalProgressInfo.Response response = (C2S_GetFinalProgressInfo.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				_finalProgressInfoRefreshing = false;
			}
			else
			{
				_model.UpdateFinalProgressInfo(response);
				OnFinalProgressInfoChange?.Invoke();
				_finalProgressInfoRefreshing = false;
			}
		});
	}

	public void GetFinalProgressInfoOnSubmitStone()
	{
		if (WorldClosed || WorldMapConfigHelper.Configs.IsBrawlEvent())
		{
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetFinalProgressInfo
		{
			Req = new C2S_GetFinalProgressInfo.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetFinalProgressInfo.Response response = (C2S_GetFinalProgressInfo.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_model.UpdateFinalProgressInfo(response);
				OnFinalProgressInfoChange?.Invoke();
			}
		});
	}

	private void RefreshFinalProgressInfo()
	{
		if (IsEternalNight && _updateFinalProgressInfo == null)
		{
			_updateFinalProgressInfo = FGUIManager.Instance.OpenIEnumerator(UpdateFinalProgressInfo());
		}
	}

	private IEnumerator UpdateFinalProgressInfo()
	{
		while (!WorldClosed)
		{
			GetFinalProgressInfo(showWaitingUi: false);
			yield return _perSeconds;
		}
	}

	public void GetFinalProgressBossDamageTodayTop3()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetFinalProgressBossDamageTodayTop3
		{
			Req = new C2S_GetFinalProgressBossDamageTodayTop3.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetFinalProgressBossDamageTodayTop3.Response response = (C2S_GetFinalProgressBossDamageTodayTop3.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				RenderBossDamage?.Invoke(response.TodayTop3);
			}
		});
	}

	private void SyncFinalProgressBossDamageTodayTop3(S2C_GetFinalProgressBossDamageTodayTop3.Request request)
	{
		RenderBossDamage?.Invoke(request.TodayTop3);
	}

	public GvG3FlagShipMissionModel GetEternalNightMission()
	{
		return _model.GetEternalNightMission(FinalProgressInfo.CurMissionConfgiId);
	}

	public void GetCampInfo(Action<C2S_GetCampInfo.Response> onFinished = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetCampInfo
		{
			Req = new C2S_GetCampInfo.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetCampInfo.Response response = (C2S_GetCampInfo.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			onFinished?.Invoke(response);
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		});
	}

	private void StopAutoGetCampEnergy(string uiName)
	{
		if (!(uiName != UI_main_FlagShipMissions.Name) && _Coroutine_AutoGetCampEnergy != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_AutoGetCampEnergy);
			_Coroutine_AutoGetCampEnergy = null;
		}
	}

	public void GetCampEnergy()
	{
		StopAutoGetCampEnergy(UI_main_FlagShipMissions.Name);
		_Coroutine_AutoGetCampEnergy = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(AutoGetCampEnergy());
	}

	private IEnumerator AutoGetCampEnergy()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetCampEnergy
		{
			Req = new C2S_GetCampEnergy.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetCampEnergy.Response response = (C2S_GetCampEnergy.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			_model.SyncCampEnergyDetails(response);
			RenderCampEnergyDetails?.Invoke(_model.CampEnergyDetails);
			Singleton<GvG3FlagShipMissionsManager>.Instance.RenderJumpEnergyByAutoGetCampEnergy?.Invoke(_model.CampEnergyDetails.CampEnergy);
		});
		yield return (object)new WaitForSeconds(5f);
		_Coroutine_AutoGetCampEnergy = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(AutoGetCampEnergy());
	}

	public void GetMissions(int progress = 0, bool currentProgress = false, Action onFinished = null)
	{
		if (currentProgress)
		{
			_model.CheckCurrentProgress();
		}
		else
		{
			_model.ChangeCampProgress(progress);
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetMissions
		{
			Req = new C2S_GetMissions.Request
			{
				Progress = _model.CheckCampProgress
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetMissions.Response response = (C2S_GetMissions.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				RenderCampMainProgressRankReward?.Invoke(new CampRankReward(_model.CheckCampProgress, response.MainProgress ?? new List<CampMainProgress>(), response.SelfClaimCampRankReward));
				_model.SyncMissionsStatus(response.MissionStateRecordWithProgress);
				RenderMainMissions?.Invoke(_model.GetMainMission());
				RenderSideMissions?.Invoke(_model.GetSideMissions());
				CampProgressRedDot campProgressRedDot = new CampProgressRedDot(_model.CheckCampProgress, response.MissionCanClaim, response.RankCanClaim);
				RenderPage?.Invoke(campProgressRedDot);
				UpdateMainUiMissionRedDot?.Invoke(campProgressRedDot.HasMainRedDot());
				onFinished?.Invoke();
			}
		});
	}

	public void ClaimMission(int mUid)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimMission
		{
			Req = new C2S_ClaimMission.Request
			{
				MUIDs = new List<int> { mUid }
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimMission.Response response = (C2S_ClaimMission.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			GetMissions();
		});
	}

	public void ClaimMainMissionRankReward()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimMainMissionRankReward
		{
			Req = new C2S_ClaimMainMissionRankReward.Request
			{
				Progress = _model.CheckCampProgress
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimMainMissionRankReward.Response response = (C2S_ClaimMainMissionRankReward.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			GetMissions();
		});
	}

	public void TryPlayEternalNightUiTransitions(bool inform = false)
	{
		if (!IsEternalNight || HasSettlement)
		{
			return;
		}
		int campStep = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep;
		List<eEternalNightTransition> list = new List<eEternalNightTransition>(2);
		if (campStep == 1 && !EternalNightOpen)
		{
			list.Add(eEternalNightTransition.Open);
			PlayerPrefs.SetInt(_openEternalNightTransitionPlayHistoryKey, 1);
		}
		if (campStep == 2 && !EternalNightBossAppear)
		{
			list.Add(eEternalNightTransition.Boss);
			PlayerPrefs.SetInt(_bossEternalNightTransitionPlayHistoryKey, 1);
			PlayerPrefs.SetInt(_openEternalNightTransitionPlayHistoryKey, 1);
		}
		if (list.Count > 0)
		{
			if (inform)
			{
				SharedMessenger.Broadcast("ON_GVG3_ETERNALNIGHT_TRANSITION_PLAYED");
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LandOfEternalNight.Name, new Dictionary<string, object> { { "TransitionType", list } });
		}
	}

	public void TryShowProgressSettlementPanel()
	{
		int campProgress = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress;
		if (campProgress <= 5 && campProgress > 1)
		{
			int num = campProgress - 1;
			string text = $"ProgressSettlement_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{GameController.Contexts.gameState.user.value.UserId}_{num}";
			if (!PlayerPrefs.HasKey(text) || PlayerPrefs.GetInt(text) <= 0)
			{
				PlayerPrefs.SetInt(text, 1);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ProgressSettlement.Name, new Dictionary<string, object>());
			}
		}
	}
}
