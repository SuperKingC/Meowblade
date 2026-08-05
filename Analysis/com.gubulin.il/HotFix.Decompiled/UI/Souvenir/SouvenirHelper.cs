using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.UI;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace UI.Souvenir;

public static class SouvenirHelper
{
	public readonly struct SouvenirLineTextParseHandler
	{
		private readonly Action<string> _renderer;

		private readonly ISouvenirLineText _lineText;

		public SouvenirLineTextParseHandler(Action<string> renderer, ISouvenirLineText lineText)
		{
			_renderer = renderer;
			_lineText = lineText;
		}

		public void InvokeCallback(string nickName)
		{
			ISouvenirLineText lineText = _lineText;
			string obj = ((lineText != null) ? lineText.ParseLineText(nickName) : null);
			_renderer?.Invoke(obj);
			RemoveProcessingLineText(_lineText);
		}
	}

	private const string _PATTERN = "\\{UserId:(\\d+)\\}";

	private static readonly Dictionary<string, Souvenir> _cache = new Dictionary<string, Souvenir>();

	private static readonly HashSet<ISouvenirLineText> _processingLineTexts = new HashSet<ISouvenirLineText>();

	public static Souvenir GetSouvenirCache(string itemId)
	{
		if (!_cache.TryGetValue(itemId, out var value))
		{
			value = GenerateSouvenir(itemId);
			_cache[itemId] = value;
		}
		return value;
	}

	public static void RenderSouvenirLineText(this ISouvenirLineText lineText, Action<string> onLoaded = null)
	{
		string processedText = lineText.GetProcessedText();
		if (!string.IsNullOrEmpty(processedText))
		{
			onLoaded?.Invoke(processedText);
			return;
		}
		if (lineText.UserIds.Count <= 0)
		{
			lineText.SetProcessedText(lineText.OriginalText);
			onLoaded?.Invoke(lineText.GetProcessedText());
			return;
		}
		int num = lineText.UserIds[0];
		GameLocalDataManager.UserLocalData userData;
		if (num == GameController.Contexts.gameState.user.value.UserId)
		{
			lineText.SetProcessedText(GameController.Contexts.gameState.user.value.Nickname);
			onLoaded?.Invoke(lineText.GetProcessedText());
		}
		else if (TryGetUserNickName(num, out userData))
		{
			lineText.SetProcessedText(userData.NickName);
			onLoaded?.Invoke(lineText.GetProcessedText());
		}
		else if (!_processingLineTexts.Contains(lineText))
		{
			SouvenirLineTextParseHandler handler = new SouvenirLineTextParseHandler(onLoaded, lineText);
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetUserNickName(num, handler));
			_processingLineTexts.Add(lineText);
		}
	}

	private static bool TryGetUserNickName(int userId, out GameLocalDataManager.UserLocalData userData)
	{
		GameLocalDataManager.UserLocalData userLocalData = (userData = GameLocalDataManager.GetSomeUserLocalData(userId));
		if (userLocalData == null)
		{
			return false;
		}
		int num = (int)GameController.Instance.GetServerTime();
		if (num >= (int)userLocalData.ModifiedDate || string.IsNullOrWhiteSpace(userLocalData.NickName))
		{
			return false;
		}
		return true;
	}

	public static void RemoveProcessingLineText(ISouvenirLineText lineText)
	{
		_processingLineTexts.Remove(lineText);
	}

	private static IEnumerator GetUserNickName(int userId, SouvenirLineTextParseHandler handler, int textLength = 14)
	{
		yield return EnsurePvPAvatarExist(userId);
		GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
		if (userLocalData != null && !string.IsNullOrEmpty(userLocalData.NickName))
		{
			string name = FGUIManager.Instance.TruncateTextLength(userLocalData.NickName, textLength);
			handler.InvokeCallback(name);
		}
		else
		{
			handler.InvokeCallback(string.Empty);
		}
	}

	private static IEnumerator EnsurePvPAvatarExist(int userId)
	{
		string png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
		string png_big_path = UiHelper.GetUserBigAvatarLocalPath(userId.ToString());
		string _NickName = RankDataHelper.UserId_Obfuscating(userId);
		string avatar_url = UiHelper.GetUserAvatarHttpsUrl(userId);
		string profile_url = UiHelper.GetUserProfileHttpsUrl(userId);
		string big_avatar_url = UiHelper.GetUserBigAvatarHttpsUrl(userId);
		UnityWebRequest uwr_profile = UnityWebRequest.Get(profile_url);
		uwr_profile.timeout = 3;
		yield return uwr_profile.SendWebRequest();
		if (uwr_profile.isNetworkError || uwr_profile.isHttpError)
		{
			File.WriteAllBytes(png_path, new byte[0]);
			File.WriteAllBytes(png_big_path, new byte[0]);
			GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
			{
				UserId = userId,
				NickName = _NickName,
				ModifiedDate = GameController.Instance.GetServerTime() + 1
			}, userId: userId);
			yield return null;
			yield break;
		}
		UserProfile userProfile = uwr_profile.downloadHandler.data.Deserialize<UserProfile>();
		if (userProfile != null)
		{
			_NickName = userProfile.Name;
			GameLocalDataManager.SetUserMedalData(userId, userProfile.Medals);
		}
		UnityWebRequest uwr_big_avatar = UnityWebRequest.Get(big_avatar_url);
		uwr_big_avatar.timeout = 3;
		yield return uwr_big_avatar.SendWebRequest();
		UnityWebRequest uwr_avatar = UnityWebRequest.Get(avatar_url);
		uwr_avatar.timeout = 3;
		yield return uwr_avatar.SendWebRequest();
		if (uwr_avatar.isNetworkError || uwr_avatar.isHttpError || uwr_big_avatar.isHttpError || uwr_big_avatar.isNetworkError)
		{
			File.WriteAllBytes(png_path, new byte[0]);
			File.WriteAllBytes(png_big_path, new byte[0]);
			GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
			{
				UserId = userId,
				NickName = _NickName,
				ModifiedDate = GameController.Instance.GetServerTime() + 1
			}, userId: userId);
			yield return null;
			yield break;
		}
		UserProfileAvatar userProfile_avatar = null;
		UserProfileAvatar userProfile_big_avatar = null;
		if (uwr_avatar.isDone && uwr_avatar.downloadHandler.data != null)
		{
			userProfile_avatar = uwr_avatar.downloadHandler.data.Deserialize<UserProfileAvatar>();
		}
		if (uwr_big_avatar.isDone && uwr_big_avatar.downloadHandler.data != null)
		{
			userProfile_big_avatar = uwr_big_avatar.downloadHandler.data.Deserialize<UserProfileAvatar>();
		}
		if (userId > 0 && userProfile_avatar?.AvatarData != null && userProfile_avatar.AvatarData.Length != 0)
		{
			File.WriteAllBytes(png_path, userProfile_avatar.AvatarData);
		}
		else
		{
			File.WriteAllBytes(png_path, new byte[0]);
		}
		if (userId > 0 && userProfile_big_avatar?.AvatarData != null && userProfile_big_avatar.AvatarData.Length != 0)
		{
			File.WriteAllBytes(png_big_path, userProfile_big_avatar.AvatarData);
		}
		else
		{
			File.WriteAllBytes(png_big_path, new byte[0]);
		}
		GameLocalDataManager.SetSomeUserLocalData(_userLocalData: new GameLocalDataManager.UserLocalData
		{
			UserId = userId,
			NickName = _NickName,
			ModifiedDate = UiHelper.GetUserAvatarExpireSeconds(userId)
		}, userId: userId);
		yield return uwr_avatar.downloadHandler;
	}

	private static Souvenir GenerateSouvenir(string itemId)
	{
		Souvenir souvenir = new Souvenir();
		string postScript = GDMgr.Get<GDEItemData>(itemId).PostScript;
		List<string> source = JsonHelper.ToObject<List<string>>(postScript);
		IEnumerable<SouvenirPostScriptLine> collection = source.Select(ParsePostScriptLine);
		souvenir.LineTexts.AddRange(collection);
		return souvenir;
	}

	private static SouvenirPostScriptLine ParsePostScriptLine(string line)
	{
		SouvenirPostScriptLine souvenirPostScriptLine = new SouvenirPostScriptLine(line);
		MatchCollection matchCollection = Regex.Matches(line, "\\{UserId:(\\d+)\\}");
		if (matchCollection.Count > 0)
		{
			souvenirPostScriptLine.Type = PostScriptLineType.UserName;
			souvenirPostScriptLine.UserIds = new List<int>();
			foreach (Match item2 in matchCollection)
			{
				if (item2.Groups.Count > 1)
				{
					int item = int.Parse(item2.Groups[1].Value);
					if (!souvenirPostScriptLine.UserIds.Contains(item))
					{
						souvenirPostScriptLine.UserIds.Add(item);
					}
				}
			}
		}
		else
		{
			souvenirPostScriptLine.Type = PostScriptLineType.PlainText;
			souvenirPostScriptLine.SetProcessedText(line);
		}
		return souvenirPostScriptLine;
	}

	private static string ParseLineText(this ISouvenirLineText lineText, string nickName)
	{
		string text = string.Empty;
		MatchCollection matchCollection = Regex.Matches(lineText.OriginalText, "\\{UserId:(\\d+)\\}");
		if (matchCollection.Count > 0)
		{
			foreach (Match item in matchCollection)
			{
				if (item.Groups.Count <= 1)
				{
					continue;
				}
				text = lineText.OriginalText.Replace(item.Value, nickName);
				break;
			}
		}
		lineText.SetProcessedText(text);
		return text;
	}
}
