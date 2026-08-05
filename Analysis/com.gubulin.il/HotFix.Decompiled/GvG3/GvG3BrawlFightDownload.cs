using System;
using System.Collections;
using System.IO;
using Assets.Scripts.Managers;
using HotFix;
using Shift.Legion.Common.Services;
using UnityEngine;
using UnityEngine.Networking;

namespace GvG3;

public class GvG3BrawlFightDownload
{
	public static void DownloadRecord(string recordName, bool isReplay, Action<string> onComplete)
	{
		string value;
		string text = (HotUpdateProcess.Instance.Configs.TryGetValue("GvGMode3Log", out value) ? value : "https://skyisland.gubulin.com");
		string url = text + "/BrawlReplay/" + recordName;
		string text2 = Path.Combine(Application.persistentDataPath, "replays", recordName);
		if (File.Exists(text2))
		{
			onComplete(text2);
			return;
		}
		string tipText = (isReplay ? LanguagesManager.GetDesc("CsharpCodeZhTcText52") : LanguagesManager.GetDesc("BrawlEventStreamingLoadingTip"));
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(Download(url, text2, tipText, onComplete));
	}

	private static IEnumerator Download(string url, string localPath, string tipText, Action<string> onComplete)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(0f, tipText);
		UnityWebRequest request = UnityWebRequest.Get(url);
		request.timeout = 10;
		UnityWebRequestAsyncOperation operation = request.SendWebRequest();
		while (!((AsyncOperation)operation).isDone)
		{
			float barValue = request.downloadProgress * 35f + 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, tipText);
			yield return null;
		}
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(100f, tipText);
		yield return null;
		if (request.isNetworkError || request.isHttpError)
		{
			ILRuntimeDebug.LogError("[GvG3BrawlFightDownloadManager] Download failed -- " + url);
			onComplete(null);
		}
		else
		{
			File.WriteAllBytes(localPath, request.downloadHandler.data);
			onComplete(localPath);
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
	}
}
