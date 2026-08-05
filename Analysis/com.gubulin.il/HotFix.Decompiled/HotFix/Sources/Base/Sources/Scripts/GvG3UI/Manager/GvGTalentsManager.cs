using System;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.OuterTech;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvGTalentsManager : Singleton<GvGTalentsManager>
{
	private readonly Dictionary<int, GvGTalentUiModel> _talents = new Dictionary<int, GvGTalentUiModel>(100);

	private readonly Dictionary<int, List<GDEGvGTalentConfigData>> _specialTalents = new Dictionary<int, List<GDEGvGTalentConfigData>>();

	private readonly List<int> _specialTalentIdx = new List<int>(5);

	private int _nextAvailableResetTime;

	private Action _onResetTalentsFinished = delegate
	{
	};

	public int NextAvailableResetTime => _nextAvailableResetTime;

	public Dictionary<int, List<GDEGvGTalentConfigData>> SpecialTalents => _specialTalents;

	public int GetEffectiveTalentsNum()
	{
		int num = 0;
		foreach (KeyValuePair<int, GvGTalentUiModel> talent in _talents)
		{
			if (talent.Key != 0 && talent.Value.Effective)
			{
				num++;
			}
		}
		return (_talents.Count > 0) ? num : 0;
	}

	public void Destroy()
	{
		UnregisterUiEventListeners();
		ClearCache();
	}

	private void RegisterUiEventListeners()
	{
		S2C_ActivateTalent_ResetResult.OnPushEvent = (Action<S2C_ActivateTalent_ResetResult.Request>)Delegate.Combine(S2C_ActivateTalent_ResetResult.OnPushEvent, new Action<S2C_ActivateTalent_ResetResult.Request>(OnPushTalentsReset));
		S2C_ResetTalentFinish.OnPushEvent = (Action<S2C_ResetTalentFinish.Request>)Delegate.Combine(S2C_ResetTalentFinish.OnPushEvent, new Action<S2C_ResetTalentFinish.Request>(OnPushResetTalentFinish));
	}

	private void UnregisterUiEventListeners()
	{
		S2C_ActivateTalent_ResetResult.OnPushEvent = (Action<S2C_ActivateTalent_ResetResult.Request>)Delegate.Remove(S2C_ActivateTalent_ResetResult.OnPushEvent, new Action<S2C_ActivateTalent_ResetResult.Request>(OnPushTalentsReset));
		S2C_ResetTalentFinish.OnPushEvent = (Action<S2C_ResetTalentFinish.Request>)Delegate.Remove(S2C_ResetTalentFinish.OnPushEvent, new Action<S2C_ResetTalentFinish.Request>(OnPushResetTalentFinish));
	}

	private void TalentsInit(C2S_GetActiveTalents.Response response, bool isFirst = true)
	{
		ClearCache();
		SpecialTalentsInit();
		_nextAvailableResetTime = response.NextAvailableResetTime;
		_talents.Add(0, new GvGTalentUiModel(null)
		{
			Effective = true
		});
		if (response.ActiveTalents != null)
		{
			Singleton<WorldStateManager>.Instance.Data.Talents?.UpdateActiveTalents(response.ActiveTalents);
			for (int i = 0; i < response.ActiveTalents.Count; i++)
			{
				GDEGvGTalentConfigData gDEGvGTalentConfigData = GvGTalentConfigHelper.GeTalentConfigData(response.ActiveTalents[i]);
				if (gDEGvGTalentConfigData != null)
				{
					_talents.Add(response.ActiveTalents[i], new GvGTalentUiModel(gDEGvGTalentConfigData)
					{
						Effective = true
					});
				}
			}
		}
		UpdateActiveSpecialTalents(response.ActiveSpecialTalents);
		if (isFirst)
		{
			RegisterUiEventListeners();
		}
		RefreshSpecialIslandHideState();
	}

	private static void RefreshSpecialIslandHideState()
	{
		foreach (int specialSuppressIslandId in WorldMapConfigHelper.Configs.SpecialSuppressIslandIds)
		{
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(specialSuppressIslandId);
			islandStateModel.OnHideStateChange?.Invoke(islandStateModel.IsVisible);
		}
	}

	private void TalentsReset(S2C_ActivateTalent_ResetResult.Request request)
	{
		ClearCache();
		_talents.Add(0, new GvGTalentUiModel(null)
		{
			Effective = true
		});
		_nextAvailableResetTime = request.NextAvailableResetTime;
		RefreshSpecialIslandHideState();
		Dictionary<string, int> curValueChanges = request.StorehouseCurValueChanges ?? new Dictionary<string, int>();
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithCurValueChanges(curValueChanges);
		if (request.GsItems == null)
		{
			return;
		}
		foreach (RItem gsItem in request.GsItems)
		{
			GameManagers.Instance.StockController.SetStock(gsItem.ItemId, gsItem.cnt, (StockInContext)request.StockInContext);
		}
	}

	private void TalentsUpdate(int talentIdx, C2S_ActivateTalent.Response response)
	{
		_nextAvailableResetTime = response.NextAvailableResetTime;
		UpdateActiveSpecialTalents(response.ActiveSpecialTalent);
		GeTalentUiModel(talentIdx).Effective = true;
		Dictionary<string, int> curValueChanges = response.StorehouseCurValueChanges ?? new Dictionary<string, int>();
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouseWithCurValueChanges(curValueChanges);
		if (talentIdx == 841)
		{
			RefreshSpecialIslandHideState();
		}
	}

	private void UpdateActiveSpecialTalents(List<int> newActiveSpecialTalents)
	{
		if (newActiveSpecialTalents == null)
		{
			return;
		}
		_specialTalentIdx.Clear();
		foreach (int newActiveSpecialTalent in newActiveSpecialTalents)
		{
			_specialTalentIdx.Add(newActiveSpecialTalent);
		}
	}

	private void SpecialTalentsInit()
	{
		if (_specialTalents.Count <= 0)
		{
			_specialTalents.Add(-1, GvGTalentConfigHelper.GetTypeSpecialTalentConfigData(-1));
			_specialTalents.Add(-2, GvGTalentConfigHelper.GetTypeSpecialTalentConfigData(-2));
			_specialTalents.Add(-4, GvGTalentConfigHelper.GetTypeSpecialTalentConfigData(-4));
			_specialTalents.Add(-8, GvGTalentConfigHelper.GetTypeSpecialTalentConfigData(-8));
		}
	}

	public bool SpecialTalentEffective(int idx)
	{
		return _specialTalentIdx.Contains(idx);
	}

	public List<GDEGvGTalentConfigData> GetCurrentEffectiveSpecialTalents()
	{
		List<GDEGvGTalentConfigData> list = new List<GDEGvGTalentConfigData>();
		for (int i = 0; i < _specialTalentIdx.Count; i++)
		{
			list.Add(GvGTalentConfigHelper.GeTalentConfigData(_specialTalentIdx[i]));
		}
		return list;
	}

	public int GetCurSpecialTalentLevel(int type, int currentCount = -1)
	{
		int num = 0;
		if (!_specialTalents.TryGetValue(type, out var value))
		{
			return num;
		}
		if (currentCount < 0)
		{
			currentCount = GetCurrentSpecialTalentCount(type);
		}
		value.Sort((GDEGvGTalentConfigData a, GDEGvGTalentConfigData b) => int.Parse(a.ParentTalent).CompareTo(int.Parse(b.ParentTalent)));
		foreach (GDEGvGTalentConfigData item in value)
		{
			int num2 = int.Parse(item.ParentTalent);
			if (num2 > currentCount)
			{
				break;
			}
			num++;
		}
		return num;
	}

	public int GetCurSpecialTalentLevelWith深层共鸣(int type, 深层共鸣TalentEffect effect)
	{
		int num = 0;
		if (!_specialTalents.TryGetValue(type, out var value))
		{
			return num;
		}
		int currentSpecialTalentCount = GetCurrentSpecialTalentCount(type);
		value.Sort((GDEGvGTalentConfigData a, GDEGvGTalentConfigData b) => int.Parse(a.ParentTalent).CompareTo(int.Parse(b.ParentTalent)));
		foreach (GDEGvGTalentConfigData item in value)
		{
			int num2 = int.Parse(item.ParentTalent);
			if (num2 - effect.深层共鸣Value > currentSpecialTalentCount)
			{
				break;
			}
			num++;
		}
		return num;
	}

	public int GetNextSpecialCount(int type, int currentCount = -1, int 深层共鸣EffectValue = 0)
	{
		if (!_specialTalents.TryGetValue(type, out var value))
		{
			return 0;
		}
		if (currentCount < 0)
		{
			currentCount = GetCurrentSpecialTalentCount(type);
		}
		value.Sort((GDEGvGTalentConfigData a, GDEGvGTalentConfigData b) => int.Parse(a.ParentTalent).CompareTo(int.Parse(b.ParentTalent)));
		int num = 0;
		foreach (GDEGvGTalentConfigData item in value)
		{
			int num2 = int.Parse(item.ParentTalent) - 深层共鸣EffectValue;
			if (num2 <= currentCount)
			{
				continue;
			}
			num = num2;
			break;
		}
		return (num <= 0) ? currentCount : num;
	}

	public int GetCurrentSpecialTalentCount(int type)
	{
		int num = 0;
		int num2 = Mathf.Abs(type);
		foreach (GvGTalentUiModel value in _talents.Values)
		{
			if (value.Idx != 0)
			{
				int type2 = value.Type;
				if ((num2 & type2) == num2 && value.Effective)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetActivateNextTalentConsumePoints()
	{
		int talentsNum = GetEffectiveTalentsNum() + 1;
		return GvGTalentConfigHelper.GetTalentPointConsume(talentsNum);
	}

	public int GetResetTalentsReturnPoints()
	{
		int effectiveTalentsNum = GetEffectiveTalentsNum();
		return GvGTalentConfigHelper.GetResetTalentsReturnPoints(effectiveTalentsNum);
	}

	public void ClearCache()
	{
		_talents.Clear();
		_specialTalents.Clear();
		_specialTalentIdx.Clear();
		_nextAvailableResetTime = 0;
	}

	public GvGTalentUiModel GeTalentUiModel(int idx)
	{
		if (_talents.TryGetValue(idx, out var value))
		{
			return value;
		}
		GDEGvGTalentConfigData gDEGvGTalentConfigData = GvGTalentConfigHelper.GeTalentConfigData(idx);
		if (gDEGvGTalentConfigData == null)
		{
			return null;
		}
		_talents.Add(idx, new GvGTalentUiModel(gDEGvGTalentConfigData));
		return _talents[idx];
	}

	public string GetTalentUrl(int idx)
	{
		return GeTalentUiModel(idx).Icon.ToPublicResourcesRgbIcon();
	}

	public string GetTalentName(int idx)
	{
		return GeTalentUiModel(idx).Name;
	}

	public void GetActiveTalents(Action onFinished = null, bool isFirst = true)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetActiveTalents
		{
			Req = new C2S_GetActiveTalents.Request
			{
				NonStr = string.Empty
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetActiveTalents.Response response = (C2S_GetActiveTalents.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				TalentsInit(response, isFirst);
				onFinished?.Invoke();
			}
		});
	}

	public void ActivateTalent(int idx, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ActivateTalent
		{
			Req = new C2S_ActivateTalent.Request
			{
				TalentIdx = idx
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ActivateTalent.Response response = (C2S_ActivateTalent.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.Data.Talents?.UpdateActiveTalent(idx);
				OuterTechModel techState = OuterTechHelper.GetTechState();
				techState.o邪魔外道_LimitTime = response.LeftOuterTechTimes;
				TalentsUpdate(idx, response);
				onFinished?.Invoke();
				SharedMessenger.Broadcast("GVG3_TALENT_ACTIVATED", idx);
			}
		});
	}

	public void ResetTalents(bool useOuterTech = false, Action onFinished = null)
	{
		_onResetTalentsFinished = onFinished;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ActivateTalent
		{
			Req = new C2S_ActivateTalent.Request
			{
				TalentIdx = -1,
				UseOuterTech = useOuterTech
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ActivateTalent.Response response = (C2S_ActivateTalent.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				_onResetTalentsFinished = null;
			}
			else
			{
				Singleton<WorldStateManager>.Instance.Data.Talents?.ClearActiveTalents();
				if (useOuterTech)
				{
					Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o魔的第八天_LimitTime--;
				}
			}
		});
	}

	private void OnPushTalentsReset(S2C_ActivateTalent_ResetResult.Request request)
	{
		if (request.ErrorCode != 0)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
			_onResetTalentsFinished = null;
		}
		else
		{
			TalentsReset(request);
			_onResetTalentsFinished?.Invoke();
			_onResetTalentsFinished = null;
		}
	}

	private void OnPushResetTalentFinish(S2C_ResetTalentFinish.Request request)
	{
		if (request.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
	}
}
