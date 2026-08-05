using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;

public class GvG3UserProfileRequestHelper
{
	private const int _ITEMS_TO_REMOVE = 5;

	private readonly Queue<PendingProfile> _pendingProfiles = new Queue<PendingProfile>();

	private bool _isWaitingForResponse;

	private readonly WaitForSeconds _delayRequest = new WaitForSeconds(0.1f);

	private readonly Action<List<GvGMode3ProfileModel>> _onProfileRequestSuccess;

	public GvG3UserProfileRequestHelper(Action<List<GvGMode3ProfileModel>> onProfileRequestSuccess)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		_onProfileRequestSuccess = onProfileRequestSuccess;
	}

	private void InvokeActions(List<GvGMode3ProfileModel> profiles)
	{
		if (profiles != null && profiles.Any())
		{
			_onProfileRequestSuccess?.Invoke(profiles);
		}
	}

	private IEnumerator GetUserProfile()
	{
		if (_pendingProfiles.Count > 0)
		{
			_isWaitingForResponse = true;
			yield return _delayRequest;
			RequestProfileData();
			yield return null;
		}
	}

	private void RequestProfileData()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetUserProfileDatas
		{
			Req = new C2S_GetUserProfileDatas.Request
			{
				UserIds = GetUserIds()
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetUserProfileDatas.Response response = (C2S_GetUserProfileDatas.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			InvokeActions(response.Models);
			bool continueGet = TryStopWaiting();
			TryContinueGetUserProfile(continueGet);
		});
	}

	private bool TryStopWaiting()
	{
		if (_pendingProfiles.Count <= 0)
		{
			_isWaitingForResponse = false;
		}
		return _isWaitingForResponse;
	}

	private void TryContinueGetUserProfile(bool continueGet)
	{
		if (continueGet)
		{
			FGUIManager.Instance.OpenIEnumerator(GetUserProfile());
		}
	}

	private List<int> GetUserIds()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < 5; i++)
		{
			if (_pendingProfiles.Count <= 0)
			{
				break;
			}
			list.Add(_pendingProfiles.Dequeue().UserId);
		}
		return list;
	}

	public void GetProfileData(int userId)
	{
		AddPendingUserId(userId);
		TryStartGetUserProfileCoroutine();
	}

	private void AddPendingUserId(int userId)
	{
		if (!_pendingProfiles.Any((PendingProfile p) => p.UserId == userId))
		{
			_pendingProfiles.Enqueue(new PendingProfile(userId));
		}
	}

	private void TryStartGetUserProfileCoroutine()
	{
		if (!_isWaitingForResponse)
		{
			FGUIManager.Instance.OpenIEnumerator(GetUserProfile());
		}
	}
}
