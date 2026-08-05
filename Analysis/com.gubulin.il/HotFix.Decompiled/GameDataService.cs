using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.Archive;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

public class GameDataService : MonoBehaviour, IGameDataService, IService
{
	private bool _loaded;

	public static GameDataService Instance;

	public string EnvStr;

	private void Awake()
	{
		Instance = this;
	}

	public void StartLoadGameData()
	{
		if (_loaded)
		{
			CommandFactory.CreateGameDataLoadedCommand(null);
			return;
		}
		try
		{
			GameController.Contexts.gameState.isGameDataLoaded = true;
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex);
		}
	}

	public void LoadGameDataSucess(byte[] hadnler)
	{
		GameController.Contexts.gameState.isGameDataLoaded = true;
	}

	public bool LoadGameData(byte[] data, bool encrypted = false)
	{
		if (_loaded)
		{
			return true;
		}
		bool result;
		try
		{
			result = true;
			_loaded = true;
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex);
			result = false;
		}
		return result;
	}

	public async void StartLoadUserArchive(int userId)
	{
		TaskCompletionSource<DownloadArchiveResponse> tcs = new TaskCompletionSource<DownloadArchiveResponse>();
		ILRequestHelper<DownloadArchiveResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().DownloadArchive(), delegate(DownloadArchiveResponse x)
		{
			tcs.SetResult(x);
		}, 2f);
		DownloadArchiveResponse response = await tcs.Task;
		EnvStr = response.EnvStr;
		Dictionary<string, Shift.Legion.Common.Models.UserData> dict = new Dictionary<string, Shift.Legion.Common.Models.UserData>();
		string ErrorKey = string.Empty;
		foreach (Shift.Legion.ClientApi.Protocol.Archive.UserData data in response.Data)
		{
			if (!dict.ContainsKey(data.Key))
			{
				dict.Add(data.Key, new Shift.Legion.Common.Models.UserData
				{
					UserId = userId,
					Key = data.Key,
					Type = data.Type,
					Data = data.Data,
					Version = data.Version
				});
			}
			else
			{
				ErrorKey = ErrorKey + data.Key + " , ";
			}
		}
		if (response.CommonSettings != null)
		{
			foreach (Shift.Legion.ClientApi.Protocol.Archive.UserData data2 in response.CommonSettings)
			{
				if (!dict.ContainsKey(data2.Key))
				{
					dict.Add(data2.Key, new Shift.Legion.Common.Models.UserData
					{
						UserId = userId,
						Key = data2.Key,
						Type = data2.Type,
						Data = data2.Data,
						Version = data2.Version
					});
				}
				else
				{
					ErrorKey = ErrorKey + data2.Key + " , ";
				}
			}
		}
		if (!string.IsNullOrEmpty(ErrorKey))
		{
			ILRuntimeDebug.LogError($"u{userId} ErrorKey = {ErrorKey}  已经存在了！");
		}
		CommandFactory.CreateGameUserDataLoadedCommand(userId, dict);
		GameController.Contexts.Service<INetworkService>().GetAnnouncements();
		int _cur_logintime = (int)GameController.Instance.GetServerTime();
		string _last_logintime = GameLocalDataManager.GetString("CurLoginTime");
		GameLocalDataManager.SetString("LastLoginTime", _last_logintime);
		GameLocalDataManager.SetString("CurLoginTime", $"{_cur_logintime}");
	}

	public void Init()
	{
	}

	public void Destroy()
	{
	}

	public void AddEventsListener()
	{
	}

	public void RemoveEventsListener()
	{
	}
}
