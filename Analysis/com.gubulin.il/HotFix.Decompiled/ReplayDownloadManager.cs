using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using HotFix;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

public static class ReplayDownloadManager
{
	private static string ResultFilename = Interface_Battle.ResultFilename;

	private const string ReplayTypeRecent = "RecentReplays";

	private const string ReplayTypeLevel = "LevelReplays";

	private const string DownloadFolder = "replays";

	public static string GetBattleReplayBasePath(string battleId, string filename)
	{
		return Path.Combine(Application.persistentDataPath, "replays", battleId, filename);
	}

	private static string GetBattleReplayZipBasePath(string battleId)
	{
		return Path.Combine(Application.persistentDataPath, "replays", battleId);
	}

	public static void DownloadReplay(string battleId, string filename, Action<bool> callback)
	{
		if (!GameController.Configs.TryGetValue("BattleReplayDownloadUrl", out var value))
		{
			value = GameController.Configs["BattleReplayServerUrl"];
		}
		string battleReplayBasePath = GetBattleReplayBasePath(battleId, filename);
		string fullName = Directory.GetParent(battleReplayBasePath).FullName;
		if (!Directory.Exists(fullName))
		{
			Directory.CreateDirectory(fullName);
		}
		if (File.Exists(battleReplayBasePath))
		{
			callback?.Invoke(obj: true);
		}
		else
		{
			DownloadReplaySegment(value, battleId, filename, battleReplayBasePath, callback);
		}
	}

	public static void GetGvGBattleRecordResultData(string battleId, string filename, Action<bool> callback)
	{
		if (!GameController.Configs.TryGetValue("BattleReplayDownloadUrl", out var value))
		{
			value = GameController.Configs["BattleReplayServerUrl"];
		}
		string battleReplayBasePath = GetBattleReplayBasePath(battleId, filename);
		string fullName = Directory.GetParent(battleReplayBasePath).FullName;
		if (!Directory.Exists(fullName))
		{
			Directory.CreateDirectory(fullName);
		}
		if (File.Exists(battleReplayBasePath))
		{
			callback?.Invoke(obj: true);
		}
		else
		{
			DownloadReplaySegment(value, battleId, filename, battleReplayBasePath, callback);
		}
	}

	public static void DownloadReplay(string battleId, int totalSegments, int index, Action<bool> callback)
	{
		if (!GameController.Configs.TryGetValue("BattleReplayDownloadUrl", out var value))
		{
			value = GameController.Configs["BattleReplayServerUrl"];
		}
		List<string> list = new List<string> { ResultFilename };
		for (int i = 0; i < totalSegments; i++)
		{
			list.Add(i.ToString());
		}
		string battleReplayBasePath = GetBattleReplayBasePath(battleId, list[index]);
		string fullName = Directory.GetParent(battleReplayBasePath).FullName;
		if (!Directory.Exists(fullName))
		{
			Directory.CreateDirectory(fullName);
		}
		if (File.Exists(battleReplayBasePath))
		{
			callback?.Invoke(obj: true);
		}
		else
		{
			DownloadReplaySegment(value, battleId, list[index], battleReplayBasePath, callback);
		}
	}

	public static Dictionary<Team, BattleResultStats> LoadBattleResultFromCache(string battleId)
	{
		string battleReplayBasePath = GetBattleReplayBasePath(battleId, ResultFilename);
		byte[] data = File.ReadAllBytes(battleReplayBasePath);
		GetBattleResultResponse response = data.As<GetBattleResultResponse>();
		return BattleFieldService.GetBattleResultStats(response);
	}

	public static IEnumerator DownloadReplayZip(string battleId, Action<bool> callback = null, Action<float> onProgress = null)
	{
		if (!GameController.Configs.TryGetValue("BattleReplayDownloadUrl", out var baseUrl))
		{
			baseUrl = GameController.Configs["BattleReplayServerUrl"];
		}
		string path = GetBattleReplayZipBasePath(battleId);
		if (Directory.Exists(path))
		{
			onProgress?.Invoke(1f);
			callback?.Invoke(obj: true);
			yield break;
		}
		string url = baseUrl + battleId + ".zip";
		float firstSegmentProgress = 0.7f;
		UnityWebRequest uwr = UnityWebRequest.Get(url);
		uwr.SendWebRequest();
		while (uwr.downloadProgress < 1f)
		{
			onProgress?.Invoke(uwr.downloadProgress * firstSegmentProgress);
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				callback?.Invoke(obj: false);
				uwr.Dispose();
				yield break;
			}
			yield return null;
		}
		if ((int)uwr.result != 1)
		{
			callback?.Invoke(obj: false);
			uwr.Dispose();
			yield break;
		}
		DownloadHandler downloadHandler = uwr.downloadHandler;
		int downloadedBytes = ((downloadHandler == null) ? ((int?)null) : downloadHandler.data?.Length).GetValueOrDefault();
		if (downloadedBytes == 0)
		{
			callback?.Invoke(obj: false);
			uwr.Dispose();
			yield break;
		}
		DownloadHandler downloadHandler2 = uwr.downloadHandler;
		byte[] data = ((downloadHandler2 != null) ? downloadHandler2.data : null);
		if (data == null || data.Length < 4 || data[0] != 80 || data[1] != 75)
		{
			ILRuntimeDebug.LogError($"[ReplayDownload] 下载内容非有效ZIP(PK魔数校验失败), url={url}, dataLen={downloadedBytes}");
			callback?.Invoke(obj: false);
			uwr.Dispose();
			yield break;
		}
		onProgress?.Invoke(firstSegmentProgress);
		try
		{
			if (Directory.Exists(path))
			{
				onProgress?.Invoke(1f);
				callback?.Invoke(obj: true);
				uwr.Dispose();
				yield break;
			}
			Directory.CreateDirectory(path);
			File.WriteAllBytes(path + "ReplayData.zip", uwr.downloadHandler.data);
			uwr.Dispose();
		}
		catch (Exception ex)
		{
			if (ex != null)
			{
				ILRuntimeDebug.LogError(ex.ToString());
			}
			callback?.Invoke(obj: false);
			uwr.Dispose();
			yield break;
		}
		yield return ReplayZipDecompression(path, path, callback, delegate(float progess)
		{
			onProgress?.Invoke(progess * (1f - firstSegmentProgress) + firstSegmentProgress);
		});
	}

	private static IEnumerator AsyncUnReplayZip(string path, string parentDirectory, Action<float> onProgress = null)
	{
		CoroutineWithData cd_unzip = new CoroutineWithData(target: ZipHelper.AsyncUnZip(path + "ReplayData.zip", parentDirectory, onProgress), owner: (MonoBehaviour)(object)FGUIManager.Instance);
		yield return cd_unzip.Coroutine;
		bool result = (bool)cd_unzip.Result;
		yield return result;
	}

	private static IEnumerator ReplayZipDecompression(string path, string parentDirectory, Action<bool> callback = null, Action<float> onProgress = null)
	{
		CoroutineWithData cd_copyasset = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, AsyncUnReplayZip(path, parentDirectory, onProgress));
		yield return cd_copyasset.Coroutine;
		onProgress?.Invoke(1f);
		if (!(bool)cd_copyasset.Result)
		{
			callback?.Invoke(obj: false);
		}
		else
		{
			callback?.Invoke(obj: true);
		}
	}

	public static void DownloadReplaySegment(string baseUrl, string battleId, string filename, string destPath, Action<bool> callback)
	{
		string url = baseUrl + battleId + "/" + filename;
		try
		{
			BattleUnityRequestHelper.Instance.Get(url, 0).Then((Action<UnityWebRequest>)delegate(UnityWebRequest uwr)
			{
				try
				{
					if (filename != ResultFilename)
					{
						Interface_Battle.BattleReplay_MessagePackSerializer_Deserialize(uwr.downloadHandler.data, true);
					}
					File.WriteAllBytes(destPath, uwr.downloadHandler.data);
					uwr.Dispose();
					callback?.Invoke(obj: true);
				}
				catch (Exception arg2)
				{
					ILRuntimeDebug.LogError($"[ReplayDownload] 分段处理异常, url={url}: {arg2}");
					callback?.Invoke(obj: false);
				}
			}).Catch((Action<Exception>)delegate(Exception ex)
			{
				ILRuntimeDebug.LogError($"[ReplayDownload] 分段下载失败, url={url}: {ex}");
				callback?.Invoke(obj: false);
			});
		}
		catch (Exception arg)
		{
			ILRuntimeDebug.LogError($"[ReplayDownload] 分段发起请求异常, url={url}: {arg}");
			callback?.Invoke(obj: false);
		}
	}

	public static void ClearReplays(string battleId)
	{
		string path = Path.Combine(Application.persistentDataPath, "replays", battleId);
		if (Directory.Exists(path))
		{
			Directory.Delete(path, recursive: true);
		}
	}

	private static void ClearInvalidReplays()
	{
		HashSet<string> validReplayIds = GetValidReplayIds("RecentReplays");
		validReplayIds.UnionWith(GetValidReplayIds("LevelReplays"));
		string text = Path.Combine(Application.persistentDataPath, "replays");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string[] directories = Directory.GetDirectories(text);
		string[] array = directories;
		foreach (string text2 in array)
		{
			if (!validReplayIds.Contains(text2))
			{
				Directory.Delete(Path.Combine(text, text2), recursive: true);
			}
		}
	}

	public static void OnRecentReplaysResponse(GetRecentReplaysResponse response)
	{
		if (response == null)
		{
			return;
		}
		List<string> list = new List<string>();
		if (response.Replays != null)
		{
			foreach (LevelBattleReplay replay in response.Replays)
			{
				list.Add(replay.BattleId);
			}
		}
		PlayerPrefs.SetString("RecentReplays", JsonHelper.ToJson(list));
		PlayerPrefs.Save();
		ClearInvalidReplays();
	}

	public static void OnLevelReplaysResponse(GetLevelReplaysResponse response)
	{
		if (response == null)
		{
			return;
		}
		List<string> list = new List<string>();
		if (response.Replays != null)
		{
			foreach (LevelBattleReplay replay in response.Replays)
			{
				list.Add(replay.BattleId);
			}
		}
		PlayerPrefs.SetString("LevelReplays", JsonHelper.ToJson(list));
		PlayerPrefs.Save();
		ClearInvalidReplays();
	}

	private static HashSet<string> GetValidReplayIds(string type)
	{
		try
		{
			List<string> list = JsonHelper.ToObject<List<string>>(PlayerPrefs.GetString(type));
			if (list == null)
			{
				return new HashSet<string>();
			}
			HashSet<string> hashSet = new HashSet<string>();
			foreach (string item in list)
			{
				hashSet.Add(item);
			}
			return hashSet;
		}
		catch
		{
			return new HashSet<string>();
		}
	}
}
