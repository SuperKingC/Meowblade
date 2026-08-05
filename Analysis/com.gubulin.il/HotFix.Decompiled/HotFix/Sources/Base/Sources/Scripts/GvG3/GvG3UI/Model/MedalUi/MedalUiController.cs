using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.MedalUi;

public class MedalUiController
{
	private MedalUiData _data;

	public MedalSummary Summary => _data.Summary;

	public List<GvG3MedalSimplifiedModel> SimplifiedMedals => _data.GetSimplifiedMedals();

	public bool ChangeMedalDisplay(string medalId, Action<GvGMedalRecord> onFinish)
	{
		int errorCode;
		bool flag = _data.ChangeMedalDisplay(medalId, out errorCode);
		if (flag)
		{
			onFinish?.Invoke(_data.GetGMedalRecord(medalId));
		}
		else
		{
			ILRequestHelper.ShowErrorCode(errorCode);
		}
		return flag;
	}

	public void ChangeMedals(Action<List<GvGMedalRecord>> renderUi)
	{
		List<GvG3MedalChange> needChangeMedalId = _data.GetNeedChangeMedalId();
		ChangeMedal(needChangeMedalId, OnFinished);
		void OnFinished()
		{
			renderUi?.Invoke(_data.UiMedals);
			SharedMessenger.Broadcast("USER_PROFILE_CHANGE");
		}
	}

	public void GetMedalRecords(Action<List<GvGMedalRecord>> onFinish)
	{
		ILRequestHelper<GetGvGMedalRecordResponse>.Request((EventContext)null, (Func<Task<GetGvGMedalRecordResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGvGMedalRecord()), (Action<GetGvGMedalRecordResponse>)delegate(GetGvGMedalRecordResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<GvGMedalRecord> records = (string.IsNullOrEmpty(response.JsonGvGMedalRecord) ? new List<GvGMedalRecord>() : JsonHelper.ToObject<List<GvGMedalRecord>>(response.JsonGvGMedalRecord));
				_data = new MedalUiData(records);
				onFinish?.Invoke(_data.UiMedals);
			}
		});
	}

	public void GetMedalRank(string medalId, Action<GvGMedalRecord> onFinish)
	{
		GvGMedalRecord gMedalRecord = _data.GetGMedalRecord(medalId);
		if (!gMedalRecord.Activated)
		{
			"GvG3NotActiveMedalTip".ToShowLanguageTip();
			return;
		}
		ILRequestHelper<GetGvGMedalRankResponse>.Request((EventContext)null, (Func<Task<GetGvGMedalRankResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGvGMedalRank(medalId)), (Action<GetGvGMedalRankResponse>)delegate(GetGvGMedalRankResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_data.UpdateMedalRank(medalId, response.DisplayRank);
				onFinish?.Invoke(_data.GetGMedalRecord(medalId));
			}
		});
	}

	private void ChangeMedal(List<GvG3MedalChange> changeMedals, Action onFinish)
	{
		Dictionary<string, bool> changes = new Dictionary<string, bool>();
		foreach (GvG3MedalChange changeMedal in changeMedals)
		{
			changes.Add(changeMedal.MedalId, changeMedal.Display);
		}
		ILRequestHelper<ProfileChangeMedalResponse>.Request((EventContext)null, (Func<Task<ProfileChangeMedalResponse>>)(() => GameController.Contexts.Service<INetworkService>().ProfileChangeMedal(JsonHelper.ToJson(changes))), (Action<ProfileChangeMedalResponse>)delegate(ProfileChangeMedalResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_data.UpdateMedalsDisplay(changeMedals);
				onFinish?.Invoke();
			}
		});
	}
}
