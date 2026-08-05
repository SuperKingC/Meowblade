using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UserTrack;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Announcement;
using Shift.Legion.ClientApi.Protocol.Archive;
using Shift.Legion.ClientApi.Protocol.Friends;
using Shift.Legion.ClientApi.Protocol.Mailing;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.ClientApi.Sources.Protocol;
using Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.ClientLib.Services;

public class NetworkService : INetworkService, IService
{
	private class GuestBindParams
	{
		public string PreType;

		public string PreValue;

		public string BindType;

		public string BindValue;

		public string UserInfo;
	}

	private readonly Network _network;

	private bool _stop;

	public static string tokenPath = Application.persistentDataPath + "//playertoken";

	public static string AuthName;

	public static string AuthPwd;

	public static IdentityType AuthIdentityType;

	public static string AuthJsonUserInfo;

	private event EventHandler<LoginResponse> OnLoginCompleteHandler;

	private event EventHandler<object> OnLoginFailHandler;

	public bool IsStop()
	{
		return _stop;
	}

	public NetworkService(Dictionary<string, string> configs, string userAgent)
	{
		SentrySdk.AddBreadcrumb("New NetworkService");
		Network.UserAgentInfo = userAgent;
		_network = new Network(configs);
		tokenPath = Application.persistentDataPath + "//playertoken";
		_network.OnError += NetworkErrorHandler;
		_network.OnNeedRestart += OnNeedRestartHandler;
		_network.OnNeedReLogin += OnNeedReLoginHandler;
	}

	public void OnNeedRestartHandler(object sender, NeedRestartResponse response)
	{
		SharedMessenger.Broadcast("NEED_RESTART", response);
	}

	public void OnNeedReLoginHandler(object sender, NeedReLoginResponse response)
	{
		SharedMessenger.Broadcast("NEED_RE_LOGIN", response);
	}

	public void SaveToken(string token)
	{
		if (!File.Exists(tokenPath))
		{
			File.Create(tokenPath).Dispose();
		}
		StreamWriter streamWriter = new StreamWriter(tokenPath, append: false, Encoding.UTF8);
		try
		{
			streamWriter.Write(token);
			streamWriter.Close();
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("Save token error: " + ex.Message);
		}
	}

	private void NetworkErrorHandler(object sender, NetworkError error)
	{
		NetworkErrorTypes type = error.Type;
		NetworkErrorTypes networkErrorTypes = type;
		if (networkErrorTypes == NetworkErrorTypes.ERROR_INVALID_TOKEN)
		{
			this.OnLoginFailHandler?.Invoke(this, LanguagesManager.GetDesc("CsharpCodeZhTcText804") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText805"));
		}
		else
		{
			SharedMessenger.Broadcast("NETWORK_ERROR", error.Exception);
		}
	}

	public void AddLoginCompleteHandler(EventHandler<LoginResponse> handler)
	{
		OnLoginCompleteHandler += handler;
	}

	public void RemoveLoginCompleteHandler(EventHandler<LoginResponse> handler)
	{
		OnLoginCompleteHandler -= handler;
	}

	public void AddLoginFailHandler(EventHandler<object> handler)
	{
		OnLoginFailHandler += handler;
	}

	public void RemoveLoginFailHandler(EventHandler<object> handler)
	{
		OnLoginFailHandler -= handler;
	}

	public void SetToken(string token)
	{
		_network.SetToken(token);
	}

	public string GetToken()
	{
		if (!File.Exists(tokenPath))
		{
			File.Create(tokenPath).Dispose();
		}
		StreamReader streamReader = new StreamReader(tokenPath, Encoding.UTF8);
		try
		{
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			return result;
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("Get token error: " + ex.Message);
			return "";
		}
	}

	public Task<UserDeviceInfoResponse> SubmitDeviceInfo(DeviceInfo info)
	{
		return _network.UserApi.SubmitDeviceInfo(info);
	}

	public Task SubmitDeviceIdentifier(string deviceIdentifier, string idfa)
	{
		return _network.UserApi.SubmitDeviceIdentifier(deviceIdentifier, idfa);
	}

	public Task SubmitDeviceLog(GameEvent gameEvent, string deviceIdentifier, Dictionary<string, string> content = null)
	{
		return _network.UserApi.SubmitDeviceLog(SystemInfo.deviceUniqueIdentifier, gameEvent, content);
	}

	public void Update()
	{
		if (!_stop)
		{
			_network.Update();
		}
	}

	public void Stop()
	{
		_stop = true;
	}

	public void Resume()
	{
		_stop = false;
	}

	public RPCConnection.WaitingGamePacket[] GetWaitingGamePackets()
	{
		return _network.GetWaitingGamePackets();
	}

	public async Task<GetOaidCertTextResult> GetOaidCertTextOperation(long timestamp)
	{
		return await _network.UserApi.GetOaidCertTextOperation(timestamp);
	}

	public async Task<UserLoginCredentialsResult> GetUserCredentialsAsync(string TypeStr, string Value, string zone)
	{
		return await _network.UserApi.GetUserCredentialsAsync(TypeStr, Value, zone);
	}

	public async Task<CredentialsOperationResult> UserCredentialsOperation(string typeStr, UserLoginCredentialsOperation op, int userId)
	{
		return await _network.UserApi.CredentialsOperation(typeStr, op, userId);
	}

	public async Task<UserLoginCredentialsResult> GetUserCredentialsOperation(string typeStr, int userId)
	{
		return await _network.UserApi.GetCredentialsOperation(typeStr, userId);
	}

	public async Task Authenticate(string name, string pwd, IdentityType identityType = IdentityType.Nickname)
	{
		try
		{
			string TypeStr = (UiHelper.LoginTypeStr = UserLoginCredentialsType.Telephone.ToString());
			string zone = HotUpdateProcess.ZoneKey;
			if (string.IsNullOrEmpty(zone))
			{
				zone = "";
			}
			UserTokenInfo userTokenInfo = await AuthenticateAsync(name, pwd, identityType, (await _network.UserApi.GetUserCredentialsAsync(TypeStr, name, zone)).CurrentUserId);
			LoginResponse loginResponse = await Login(userTokenInfo.Token);
			if (loginResponse?.User == null)
			{
				return;
			}
			GameLocalDataManager.SetZonePrefer(HotUpdateProcess.ZoneKey);
			GameLocalDataManager.SetLanguagePrefer(HotUpdateProcess.LanguageKey);
			GameLocalDataManager.MarkChosenLanguagePrefer(hasChosen: true);
			UserTrackHelper.Instance?.SetUserId(loginResponse.User.UserId);
			EventManager.SetUserId(loginResponse.User.UserId.ToString());
			if (userTokenInfo.IsNewUser)
			{
				SharedMessenger.Broadcast("NEW_USER_REGISTERED", loginResponse.User);
				int firstInstallAndRegistMark = GameLocalDataManager.GetFirstInstallAndRegistMark();
				GameLocalDataManager.MarkFirstInstallAndRegist(GameLocalDataManager.FirstInstallAndRegistFlag.Regist);
				if (firstInstallAndRegistMark == 1)
				{
					UserTrackHelper.Instance.TrackEvent(UserTrackEvent.TrackUserFirstInstallAndRegist);
				}
				if (HotUpdateProcess.ChannelCode == "bilibili")
				{
					((BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK]).CreateRole();
				}
				if (HotUpdateProcess.ChannelCode == "xipu")
				{
					((XiPuSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.XiPuSDK]).CreateRole();
				}
			}
		}
		catch (AuthenticationException ex)
		{
			AuthenticationException authenticationException = ex;
			ILRequestHelper.ShowMessage(authenticationException.Message);
			SharedMessenger.Broadcast<string>("LOGIN_FAIL", null);
		}
		catch (Exception ex2)
		{
			Exception exception = ex2;
			ILRuntimeDebug.LogError("Authenticate" + exception.Message);
			WebException webException = default(WebException);
			int num;
			if (exception.InnerException != null)
			{
				Exception innerException = exception.InnerException;
				webException = innerException as WebException;
				num = ((webException != null) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", webException.Message);
			}
			else
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText707") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText806"));
			}
		}
	}

	public async Task<UserTokenInfo> AuthenticateAsync(string name, string pwd, IdentityType identityType = IdentityType.Nickname, int userId = -1)
	{
		AuthName = name;
		AuthPwd = pwd;
		AuthIdentityType = identityType;
		return await _network.UserApi.AuthenticateAsync(name, pwd, (int)identityType, userId);
	}

	public async Task AuthenticateByPlatform(string jsonUserInfo, string platformType, string channelCode)
	{
		try
		{
			GetCredentialTypeAndValue(jsonUserInfo, platformType, out var typeString, out var credentialVal);
			if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString() && typeString != UserLoginCredentialsType.Guest.ToString())
			{
				await GuestBindByThirdParty(jsonUserInfo, typeString, credentialVal);
				return;
			}
			UiHelper.LoginTypeStr = typeString;
			string zone = HotUpdateProcess.ZoneKey;
			zone = (string.IsNullOrEmpty(zone) ? "" : zone);
			UserLoginCredentialsResult result = await _network.UserApi.GetUserCredentialsAsync(typeString, credentialVal, zone);
			if (channelCode == "bilibili" && result.CurrentUserId == -1)
			{
				"目前无法注册新账号".ToConfirmPopup(delegate
				{
					GameController.Quit();
				}, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
				return;
			}
			UserTokenInfo userTokenInfo = await AuthenticateByPlatformAsync(jsonUserInfo, platformType, result.CurrentUserId, channelCode);
			LoginResponse loginResponse = await Login(userTokenInfo.Token);
			UserTrackHelper.Instance?.SetUserId(loginResponse.User.UserId);
			EventManager.SetUserId(loginResponse.User.UserId.ToString());
			if (userTokenInfo.IsNewUser && loginResponse?.User != null)
			{
				SharedMessenger.Broadcast("NEW_USER_REGISTERED", loginResponse.User);
				int firstInstallAndRegistMark = GameLocalDataManager.GetFirstInstallAndRegistMark();
				GameLocalDataManager.MarkFirstInstallAndRegist(GameLocalDataManager.FirstInstallAndRegistFlag.Regist);
				if (firstInstallAndRegistMark == 1)
				{
					UserTrackHelper.Instance.TrackEvent(UserTrackEvent.TrackUserFirstInstallAndRegist);
					SharedMessenger.Broadcast("NEW_USER_INSTALL", loginResponse.User);
				}
				if (HotUpdateProcess.ChannelCode == "bilibili")
				{
					((BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK]).CreateRole();
				}
				if (HotUpdateProcess.ChannelCode == "xipu")
				{
					((XiPuSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.XiPuSDK]).CreateRole();
				}
			}
			SharedMessenger.Broadcast("USER_LOGIN", loginResponse.User.UserId.ToString());
		}
		catch (AuthenticationException ex)
		{
			AuthenticationException authenticationException = ex;
			ILRequestHelper.ShowMessage(authenticationException.Message);
			SharedMessenger.Broadcast<string>("LOGIN_FAIL", null);
		}
		catch (Exception ex2)
		{
			Exception exception = ex2;
			WebException webException = default(WebException);
			int num;
			if (exception.InnerException != null)
			{
				Exception innerException = exception.InnerException;
				webException = innerException as WebException;
				num = ((webException != null) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", webException.Message);
			}
			else
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText707") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText806"));
			}
		}
	}

	public async Task<UserTokenInfo> AuthenticateByPlatformAsync(string jsonUserInfo, string platformType, int userId, string channelCode)
	{
		AuthJsonUserInfo = jsonUserInfo;
		return await _network.UserApi.AuthenticateByPlatformAsync(jsonUserInfo, platformType, userId, channelCode);
	}

	public void GetCredentialTypeAndValue(string jsonUserInfo, string platformType, out string typeString, out string credentialVal)
	{
		typeString = string.Empty;
		credentialVal = string.Empty;
		if (platformType == "Wechat")
		{
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
			typeString = UserLoginCredentialsType.OpenId.ToString();
			return;
		}
		if (platformType == "Apple")
		{
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["user"].ToString();
			typeString = UserLoginCredentialsType.AppleId.ToString();
			return;
		}
		if (platformType == SDKManager.eSDKName.YYTX.ToString())
		{
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["UserId"].ToString();
			typeString = UserLoginCredentialsType.YYTX.ToString();
			return;
		}
		switch (platformType)
		{
		case "TapTap":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
			typeString = UserLoginCredentialsType.TapTap.ToString();
			break;
		case "TapTapIntl":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
			typeString = UserLoginCredentialsType.TapTapIntl.ToString();
			break;
		case "Google":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["GoogleId"].ToString();
			typeString = UserLoginCredentialsType.Google.ToString();
			break;
		case "AppleOriginal":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["user"].ToString();
			typeString = UserLoginCredentialsType.AppleId.ToString();
			break;
		case "Facebook":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["UserId"].ToString();
			typeString = UserLoginCredentialsType.Facebook.ToString();
			break;
		case "Guest":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["GuestId"].ToString();
			typeString = UserLoginCredentialsType.Guest.ToString();
			break;
		case "QQ":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
			typeString = UserLoginCredentialsType.QQ.ToString();
			break;
		case "BiliBili":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["UId"].ToString();
			typeString = UserLoginCredentialsType.BiliBili.ToString();
			break;
		case "Xipu":
			credentialVal = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["OpenId"].ToString();
			typeString = UserLoginCredentialsType.Xipu.ToString();
			break;
		}
	}

	public string GetCredentialValueByTypeStr(string jsonUserInfo, string typeStr)
	{
		string result = string.Empty;
		if (typeStr == UserLoginCredentialsType.OpenId.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.AppleId.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["user"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.YYTX.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["UserId"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.TapTap.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.TapTapIntl.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.Google.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["GoogleId"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.Facebook.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["UserId"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.Guest.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["GuestId"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.Steam.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["SteamId"].ToString();
		}
		else if (typeStr == UserLoginCredentialsType.QQ.ToString())
		{
			result = JsonHelper.ToObject<Dictionary<string, object>>(jsonUserInfo)["openid"].ToString();
		}
		return result;
	}

	public async Task WechatLoginByCode(string code, string channelCode)
	{
		try
		{
			await AuthenticateByPlatform(await _network.UserApi.GetWechatUserInfo(code), "Wechat", channelCode);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			ILRuntimeDebug.LogError(e.Message);
		}
	}

	public async Task<string> GetWechatQRCodeSignature(string nonceStr, string timestamp)
	{
		string result = null;
		try
		{
			result = await _network.UserApi.GetWechatQRCodeSignature(nonceStr, timestamp);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			ILRuntimeDebug.LogError(e.Message);
		}
		return result;
	}

	public async Task GuestBindByThirdParty(string jsonUserInfo, string bindType, string credentialVal)
	{
		try
		{
			GameLocalDataManager.GuestInfo guestUserInfo = GameLocalDataManager.GetGuestInfo();
			GuestBindParams bindInfo = new GuestBindParams
			{
				PreType = UserLoginCredentialsType.Guest.ToString(),
				PreValue = guestUserInfo.GuestUserId,
				BindType = bindType,
				BindValue = credentialVal,
				UserInfo = jsonUserInfo
			};
			string jsonBindInfo = JsonHelper.ToJson(bindInfo);
			if (await _network.UserApi.GuestBindByThirdParty(jsonBindInfo) == "绑定成功")
			{
				GameLocalDataManager.ClearGuestId();
				UiHelper.LoginTypeStr = bindType;
				ThinkingDataHelper.Instance.SetLoginType(bindType);
				SharedMessenger.Broadcast("GUEST_USER_BIND_SUCCESS", bindType, jsonUserInfo);
			}
			else
			{
				SharedMessenger.Broadcast("GUEST_USER_BIND_FAILED", bindType, LanguagesManager.GetDesc("CsharpCodeZhTcText707") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText806"));
			}
		}
		catch (AuthenticationException ex)
		{
			AuthenticationException authenticationException = ex;
			ILRequestHelper.ShowMessage(authenticationException.Message);
			SharedMessenger.Broadcast("GUEST_USER_BIND_FAILED", bindType, authenticationException.Message);
		}
		catch (Exception ex2)
		{
			Exception exception = ex2;
			WebException webException = default(WebException);
			int num;
			if (exception.InnerException != null)
			{
				Exception innerException = exception.InnerException;
				webException = innerException as WebException;
				num = ((webException != null) ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			if (num != 0)
			{
				SharedMessenger.Broadcast("GUEST_USER_BIND_FAILED", bindType, webException.Message);
			}
			else
			{
				SharedMessenger.Broadcast("GUEST_USER_BIND_FAILED", bindType, LanguagesManager.GetDesc("CsharpCodeZhTcText707") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText806"));
			}
		}
	}

	public async Task<LoginResponse> Login(string token)
	{
		if (!string.IsNullOrEmpty(token))
		{
			SaveToken(token);
			LoginResponse response = await _network.UserApi.Login(token);
			if (response.User == null)
			{
				SentrySdk.AddBreadcrumb("Login Failed, token=" + token);
				SaveToken(string.Empty);
				this.OnLoginFailHandler?.Invoke(this, LanguagesManager.GetDesc("CsharpCodeZhTcText804") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText805"));
			}
			else
			{
				SentrySdk.AddBreadcrumb("Login Success, token=" + token);
				this.OnLoginCompleteHandler?.Invoke(this, response);
			}
			return response;
		}
		return null;
	}

	public Task<PreCheckResponse> PreCheck()
	{
		return _network.UserApi.PreCheck();
	}

	public void ClearCookie()
	{
		_network.UserApi.ClearCookie();
	}

	public void Logout()
	{
		SaveToken(string.Empty);
		SharedMessenger.Broadcast("LOGOUT");
	}

	public Task<EnterGameResponse> EnterGame()
	{
		return _network.UserActionApi.EnterGame();
	}

	public Task<GetServerStatusResponse> GetServerStatus()
	{
		return _network.UserApi.GetServerStatus();
	}

	public async Task GetAnnouncements()
	{
		AnnouncementListResponse announcements = await _network.AnnouncementApi.GetAnnouncementList();
		if (announcements == null || announcements.List.Count <= 0)
		{
			return;
		}
		List<Shift.Legion.Common.Models.Announcement> announcementList = new List<Shift.Legion.Common.Models.Announcement>();
		foreach (Shift.Legion.ClientApi.Protocol.Announcement.Announcement announcementApiModel in announcements.List)
		{
			announcementList.Add(new Shift.Legion.Common.Models.Announcement
			{
				Id = announcementApiModel.Id,
				Content = announcementApiModel.Content,
				Type = announcementApiModel.Type,
				From = announcementApiModel.From
			});
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			for (int i = 0; i < announcementList.Count; i++)
			{
				Shift.Legion.Common.Models.Announcement announcementApiModel2 = announcementList[i];
				Dictionary<string, AnnouncementMultiLanguageContent> announcementMultiLanguageContent = JsonHelper.ToObject<Dictionary<string, AnnouncementMultiLanguageContent>>(announcementApiModel2.Content);
				if (announcementMultiLanguageContent.TryGetValue(HotUpdateProcess.LanguageKey, out var translatedAnnouncement))
				{
					announcementList[i].Content = translatedAnnouncement.Content;
				}
				translatedAnnouncement = null;
			}
		}
		SharedMessenger.Broadcast("ANNOUNCEMENT_RECEIVED", announcementList);
	}

	public Task<PullDataResponse> PullData()
	{
		return _network.CommonApi.PullData();
	}

	public Task<MailListResponse> GetMails()
	{
		return _network.MailApi.GetMailListAsync();
	}

	public Task<bool> MarkMailAsRead(int mailId)
	{
		return _network.MailApi.MarkAsReadAsync(mailId);
	}

	public Task<bool> MarkAllMailsAsRead()
	{
		return _network.MailApi.MarkAllAsReadAsync();
	}

	public Task<bool> DeleteMail(int mailId)
	{
		return _network.MailApi.DeleteMailAsync(mailId);
	}

	public Task<bool> DeleteAllMails()
	{
		return _network.MailApi.DeleteAllAsync();
	}

	public Task<MailOperateResponse> ClaimMailPayload(int mailId)
	{
		return _network.MailApi.ClaimMailPayloadsAsync(mailId);
	}

	public Task<MailOperateResponse> ClaimAllMailsPayload()
	{
		return _network.MailApi.ClaimAllPayloadsAsync();
	}

	public Task<DownloadArchiveResponse> DownloadArchive()
	{
		return _network.UserActionApi.DownloadArchive();
	}

	public Task<GvGGetSelfShipCountResponse> GvGGetSelfShipCount(string _IZId)
	{
		return _network.UserActionApi.GvGGetSelfShipCount(_IZId);
	}

	public Task<GvGClaimUserCampMissionResponse> GvGClaimUserCampMission(string _IZId, string campId, string missionId)
	{
		return _network.UserActionApi.GvGClaimUserCampMission(_IZId, campId, missionId);
	}

	public Task<GvGRoomOperationResponse> GvGRoomOperation(string op)
	{
		return _network.UserActionApi.GvGRoomOperation(op);
	}

	public Task<GvGRoomOperationDisabledResponse> GvGRoomOperationDisabled()
	{
		return _network.UserActionApi.GvGRoomOperationDisabled();
	}

	public Task<GvGMode3RoomOperationDiabledResponse> GvGMode3RoomOperationDisabled()
	{
		return _network.UserActionApi.GvGMode3RoomOperationDisabled();
	}

	public Task<GvGMode2SyncBattleConfigResponse> GvGMode2SyncBattleConfig(List<string> soldiers, string formationId, string shipId)
	{
		return _network.UserActionApi.GvGMode2SyncBattleConfig(soldiers, formationId, shipId);
	}

	public Task<GvGMode2CreateShipSummaryResponse> GvGMode2CreateShipSummary(List<string> soldiers, string formationId)
	{
		return _network.UserActionApi.GvGMode2CreateShipSummary(soldiers, formationId);
	}

	public Task<GvGMode2ShipFillUpResponse> GvGMode2ShipFillUp(List<string> soldiers, string formationId, string shipId)
	{
		return _network.UserActionApi.GvGMode2ShipFillUp(soldiers, formationId, shipId);
	}

	public Task<GvGMode2GetBattleRecordsResponse> GvGMode2GetBattleRecords(int IZId, int summaryId)
	{
		return _network.UserActionApi.GvGMode2GetBattleRecords(IZId, summaryId);
	}

	public Task<GvGMode2GetUserIZBattleSummaryResponse> GvGMode2GetUserIZBattleSummary(int[] IZIds)
	{
		return _network.UserActionApi.GvGMode2GetUserIZBattleSummary(IZIds);
	}

	public Task<GetWeeklyActivityResponse> GetWeeklyActivity()
	{
		return _network.UserActionApi.GetWeeklyActivity();
	}

	public Task<DrawSpinWeeklyResponse> DrawSpinWeekly(int drawRepeat)
	{
		return _network.UserActionApi.DrawSpinWeekly(drawRepeat);
	}

	public Task<ExchangeSpinWeeklyResponse> ExchangeSpinWeekly(int index, int repeat)
	{
		return _network.UserActionApi.ExchangeSpinWeekly(index, repeat);
	}

	public Task<ClaimSpinWeeklyLotteryResponse> ClaimSpinWeeklyLottery(int day, bool free)
	{
		return _network.UserActionApi.ClaimSpinWeeklyLottery(day, free);
	}

	public Task<GvGGetIZInfosResponse> GvGGetIZInfos(bool needCustomizeTables)
	{
		return _network.UserActionApi.GvGGetIZInfos(needCustomizeTables);
	}

	public Task<GvGWorldBossRecordRanking2Response> GvGWorldBossRecordRanking2(string _IZId, string _WBId, string key)
	{
		return _network.UserActionApi.GvGWorldBossRecordRanking2(_IZId, _WBId, key);
	}

	public Task<GvGWorldBossRecordRankingResponse> GvGWorldBossRecordRanking(string _IZId, string _WBId, string key)
	{
		return _network.UserActionApi.GvGWorldBossRecordRanking(_IZId, _WBId, key);
	}

	public Task<GvGGetWorldBossInfoResponse> GvGGetWorldBossInfo(eGvGProcessType type)
	{
		return _network.UserActionApi.GvGGetWorldBossInfo(type);
	}

	public Task<GvGGetShipRecordsResponse> GvGGetShipRecords(string _IZConfigId, string _IZId, int _Idx)
	{
		return _network.UserActionApi.GvGGetShipRecords(_IZConfigId, _IZId, _Idx);
	}

	public Task<GvGWorldBossGetBattleResultListResponse> GvGWorldBossGetBattleResultList()
	{
		return _network.UserActionApi.GvGWorldBossGetBattleResultList();
	}

	public Task<GvGWorldBossStartBattleResponse> GvGWorldBossStartBattle(string wbId, string formationId, List<string> soldierIds, string _IZId)
	{
		return _network.UserActionApi.GvGWorldBossStartBattle(wbId, formationId, soldierIds, _IZId);
	}

	public Task<GvGGetWorldBossKeyInfoResponse> GvGGetWorldBossKeyInfo(string _IZId)
	{
		return _network.UserActionApi.GvGGetWorldBossKeyInfo(_IZId);
	}

	public Task<SetAsNewGuideModeResponse> SetAsNewGuideMode()
	{
		return _network.UserActionApi.SetAsNewGuideMode();
	}

	public Task<GetMissionOf7Foreign.Response> GetMissionOf7ForeignRequest()
	{
		return _network.UserActionApi.GetMissionOf7ForeignRequest();
	}

	public Task<ClaimMissionOf7Foreign.Response> ClaimMissionOf7Foreign(int score, bool isAdvance)
	{
		return _network.UserActionApi.ClaimMissionOf7Foreign(score, isAdvance);
	}

	public Task<GetCreateAccountDay.Response> GetCreateAccountDay()
	{
		return _network.UserActionApi.GetCreateAccountDay();
	}

	public Task<PlayStoryResponse> PlayStory(long tick, string storyId)
	{
		return _network.UserActionApi.PlayStory(tick, storyId);
	}

	public Task<TriggerStoryResponse> TriggerStory(long tick, string storyKey)
	{
		return _network.UserActionApi.TriggerStory(tick, storyKey);
	}

	public Task<SkipCurrentStoryResponse> SkipCurrentStory(long tick, string uiName)
	{
		return _network.UserActionApi.SkipCurrentStory(tick, uiName);
	}

	public Task<ChangeCampProduceConfigResponse> ChangeCampProduceConfig(long tick, Dictionary<int, string> config)
	{
		return _network.UserActionApi.ChangeCampProduceConfig(tick, config);
	}

	public Task<ChangeWorkshopProduceConfigResponse> ChangeWorkshopProduceConfig(long tick, string buildingType, Dictionary<int, int> workers, Dictionary<int, List<string>> products)
	{
		return _network.UserActionApi.ChangeWorkshopProduceConfig(tick, buildingType, workers, products);
	}

	public Task<ChangeStrongholdProduceConfigResponse> ChangeStrongholdProduceConfig(long tick, string strongholdId, string soldierId)
	{
		return _network.UserActionApi.ChangeStrongholdProduceConfig(tick, strongholdId, soldierId);
	}

	public Task<ChangeFormationResponse> ChangeFormation(long tick, string ctx, string mode, string formationId)
	{
		return _network.UserActionApi.ChangeFormation(tick, ctx, mode, formationId);
	}

	public Task<ChangeFormationUnitResponse> ChangeFormationUnit(long tick, string ctx, string mode, int portalId, string unitId)
	{
		return _network.UserActionApi.ChangeFormationUnit(tick, ctx, mode, portalId, unitId);
	}

	public Task<SyncFormationUnitsResponse> SyncFormationUnits(long tick, string ctx, string mode, List<string> unitsId)
	{
		return _network.UserActionApi.SyncFormationUnits(tick, ctx, mode, unitsId);
	}

	public Task<SyncRankFormationUnitsResponse> SyncRankFormationUnits(long tick, List<string> formationsId, List<List<string>> unitsId)
	{
		return _network.UserActionApi.SyncRankFormationUnits(tick, formationsId, unitsId);
	}

	public Task<SetFormationUnitsOfRankResponse> SetFormationUnitsOfRank(int rank, List<string> formationsId, List<List<string>> unitsId)
	{
		return _network.UserActionApi.SetFormationUnitsOfRank(rank, formationsId, unitsId);
	}

	public Task<UpgradeBuildingResponse> UpgradeBuilding(long tick, string buildingType, int workers, List<Shift.Legion.ClientApi.Protocol.Archive.UserData> data)
	{
		return _network.UserActionApi.UpgradeBuilding(tick, buildingType, workers, data);
	}

	public Task<FinishUpgradeBuildingResponse> FinishUpgradeBuilding(long tick, string buildingType)
	{
		return _network.UserActionApi.FinishUpgradeBuilding(tick, buildingType);
	}

	public Task<GetFormationInfoResponse> GetFormationInfo(long tick, string levelId)
	{
		return _network.UserActionApi.GetFormationInfo(tick, levelId);
	}

	public Task<CheckCanQuickBattleResponse> CheckCanQuickBattle(long tick, string levelId)
	{
		return _network.UserActionApi.CheckCanQuickBattle(tick, levelId);
	}

	public Task<StartBattleResponse> StartBattle(long tick, string levelId, string formationId, string[] soldierIds, int[] nums, bool quickBattle)
	{
		return _network.UserActionApi.StartBattle(tick, levelId, formationId, soldierIds, nums, quickBattle);
	}

	public Task<DownloadBattleReplayResponse> DownloadBattleReplay(string battleId, int replayIndex)
	{
		return _network.UserActionApi.DownloadBattleReplay(battleId, replayIndex);
	}

	public Task<SubmitBattleOperationResponse> SubmitBattleOperation(string battleId, int subLevelIndex, string formationId, string[] units)
	{
		return _network.UserActionApi.SubmitBattleOperation(-1L, battleId, subLevelIndex, formationId, units);
	}

	public Task<RetreatResponse> Retreat(string battleId)
	{
		return _network.UserActionApi.Retreat(-1L, battleId);
	}

	public Task<GetBattleResultResponse> GetBattleResult(long tick, string battleId, string currentLevelId)
	{
		return _network.UserActionApi.GetBattleResult(tick, battleId, currentLevelId);
	}

	public Task<GetBattleBonusResponse> GetBattleBonus(string battleId, string currentLevelId)
	{
		return _network.UserActionApi.GetBattleBonus(battleId, currentLevelId);
	}

	public Task<ConfirmBattleBonusResponse> ConfirmBattleBonus(string battleId, int selectIndex)
	{
		return _network.UserActionApi.ConfirmBattleBonus(battleId, selectIndex);
	}

	public Task<GetLevelReplaysResponse> GetLevelReplays(string levelId, bool random, string battleid)
	{
		return _network.UserActionApi.GetLevelReplays(levelId, random, battleid);
	}

	public Task<RevokeBattleResponse> RevokeBattle(string battleId)
	{
		return _network.UserActionApi.RevokeBattle(battleId);
	}

	public Task<GetRecentReplaysResponse> GetRecentReplays()
	{
		return _network.UserActionApi.GetRecentReplays();
	}

	public Task<CheckBattleFailedProcessResponse> CheckBattleFailedProcess(long tick, string battleId, string subLevelId)
	{
		return _network.UserActionApi.CheckBattleFailedProcess(tick, battleId, subLevelId);
	}

	public Task<UnlockRegionResponse> UnlockRegion(long tick, string regionId)
	{
		return _network.UserActionApi.UnlockRegion(tick, regionId);
	}

	public Task<UpdateSoldierMythResponse> UpdateSoldierMyth(string soldierId, int level)
	{
		return _network.UserActionApi.UpdateSoldierMyth(soldierId, level);
	}

	public Task<UpdateGVGStoreLimitedFormulasResponse> GetGVGStoreLimitedFormulas()
	{
		return _network.UserActionApi.GetGVGStoreLimitedFormulas();
	}

	public Task<UseGVGStoreFormulaResponse> UseGVGStoreFormula(string formulaId, int inputIndex = 0, int outputIndex = 0, int storeItemIndex = 0)
	{
		return _network.UserActionApi.UseGVGStoreFormula(formulaId, inputIndex, outputIndex, storeItemIndex);
	}

	public Task<GetGvGStoreroomStockLimitResponse> GetGvGStoreroomStockLimit(bool isLevelUp = false)
	{
		return _network.UserActionApi.GetGvGStoreroomStockLimit(isLevelUp);
	}

	public Task<GetGvGStoreItemsResponse> GetGvGStoreItems(bool manual = false)
	{
		return _network.UserActionApi.GetGvGStoreItems(manual);
	}

	public Task<GetGvGStoreInfoResponse> GetGvGStoreInfo()
	{
		return _network.UserActionApi.GetGvGStoreInfo();
	}

	public Task<GetGvGStoreGuaranteedItemsResponse> GetGvGStoreGuaranteedItems()
	{
		return _network.UserActionApi.GetGvGStoreGuaranteedItems();
	}

	public Task<ExchangeGvGStoreGuaranteedTicketResponse> ExchangeGvGStoreGuaranteedTicket()
	{
		return _network.UserActionApi.ExchangeGvGStoreGuaranteedTicket();
	}

	public Task<OpenSoldierMythResponse> OpenSoldierMyth(string soldierId)
	{
		return _network.UserActionApi.OpenSoldierMyth(soldierId);
	}

	public Task<CheckLegendItemSlotResponse> CheckLegendItemSlot(List<string> soldierId)
	{
		return _network.UserActionApi.CheckLegendItemSlot(soldierId);
	}

	public Task<UnlockFormationResponse> UnlockFormation(long tick, string formationId)
	{
		return _network.UserActionApi.UnlockFormation(tick, formationId);
	}

	public Task<StartRankBattleResponse> StartRankBattle(long tick, int targetRank, long rankDataTimestamp, bool isQuick = false)
	{
		return _network.UserActionApi.StartRankBattle(tick, targetRank, rankDataTimestamp, isQuick);
	}

	public Task<GetRankBattleResultResponse> GetRankBattleResult(long tick, string battleId)
	{
		return _network.UserActionApi.GetRankBattleResult(tick, battleId);
	}

	public Task<GetPvPScoreRankListResponse> GetScoreRank()
	{
		return _network.UserActionApi.GetScoreRank();
	}

	public Task<GetOAIDCertPemResponse> GetOAIDCertPem()
	{
		return _network.UserActionApi.GetOAIDCertPem();
	}

	public Task<GetAllSoldiersCombatPowerResponse> GetAllSoldiersCombatPower(long tick)
	{
		return _network.UserActionApi.GetAllSoldiersCombatPower(tick);
	}

	public Task<GetPvPRankBattleRecordsResponse> GetRankBattleRecords(int cutoffat, int offset)
	{
		return _network.UserActionApi.GetRankBattleRecords(cutoffat, offset);
	}

	public Task<InformWatchingReplayResponse> InformWatchingReplay(string battleId)
	{
		return _network.UserActionApi.InformWatchingReplay(battleId);
	}

	public Task<GetGvGMedalRecordResponse> GetGvGMedalRecord()
	{
		return _network.UserActionApi.GetGvGMedalRecord();
	}

	public Task<GetGvGMedalRankResponse> GetGvGMedalRank(string medalId)
	{
		return _network.UserActionApi.GetGvGMedalRank(medalId);
	}

	public Task<ProfileChangeMedalResponse> ProfileChangeMedal(string changeContext)
	{
		return _network.UserActionApi.ProfileChangeMedal(changeContext);
	}

	public Task<LegendItemBlueprintGetResponse> LegendItemBlueprintGet()
	{
		return _network.UserActionApi.LegendItemBlueprintGet();
	}

	public Task<LockLegendItemBlueprintResponse> SetLockLegendItemBlueprint(string bpId, bool isLocked)
	{
		return _network.UserActionApi.SetLockLegendItemBlueprint(bpId, isLocked);
	}

	public Task<SplitBlueprintResponse> SplitBlueprint(string bpId)
	{
		return _network.UserActionApi.SplitBlueprint(bpId);
	}

	public Task<LegendItemEvolvedByBlueprintResponse> LegendItemEvolvedByBlueprint(string bluePrintId, string mainId, List<string> randomIds, List<string> anyIds, List<RItem> universalLegendItem)
	{
		return _network.UserActionApi.LegendItemEvolvedByBlueprint(bluePrintId, mainId, randomIds, anyIds, universalLegendItem);
	}

	public Task<InformWatchingPvPRankReplayResponse> InformWatchingPvPRankReplay(string battleId)
	{
		return _network.UserActionApi.InformWatchingPvPRankReplay(battleId);
	}

	public Task<InformWatchingStoryMainReplayResponse> InformWatchingStoryMainReplay(string battleId)
	{
		return _network.UserActionApi.InformWatchingStoryMainReplay(battleId);
	}

	public Task<NewbieGACHAResponse> UpdateNewbieGACHAProgress(string activityId, int nextProgress, int select)
	{
		return _network.UserActionApi.UpdateNewbieGACHAProgress(activityId, nextProgress, select);
	}

	public Task<ProfileChangeNicknameResponse> GetProfileChangeNickname(string Nickname)
	{
		return _network.UserActionApi.GetProfileChangeNickname(Nickname);
	}

	public Task<GetBBSKeyResponse> GetBBSKey()
	{
		return _network.UserActionApi.GetBBSKey();
	}

	public Task<DrawOuterTechResponse> DrawOuterTech(string ActivityId)
	{
		return _network.UserActionApi.DrawOuterTech(ActivityId);
	}

	public Task<ExchangeOuterTechResponse> ExchangeOuterTech(string ActivityId, string ItemId)
	{
		return _network.UserActionApi.ExchangeOuterTech(ActivityId, ItemId);
	}

	public Task<GetOuterTechGiftResponse> GetOuterTechGift(string ActivityId)
	{
		return _network.UserActionApi.GetOuterTechGift(ActivityId);
	}

	public Task<GetOuterTechSpeedPlanResponse> GetOuterTechSpeedPlan()
	{
		return _network.UserActionApi.GetOuterTechSpeedPlan();
	}

	public Task<ClaimOuterTechSpeedPlanResponse> ClaimOuterTechSpeedPlan()
	{
		return _network.UserActionApi.ClaimOuterTechSpeedPlan();
	}

	public Task<GetDecorativeObjectsResponse> GetDecorativeObjects(int type)
	{
		return _network.UserActionApi.GetDecorativeObjects(type);
	}

	public Task<UseDecorativeObjectsResponse> GetUseDecorativeObjects(int type, string itemid)
	{
		return _network.UserActionApi.GetUseDecorativeObjects(type, itemid);
	}

	public Task<ProfileChangeAvatarResponse> ProfileChangeAvatar(byte[] newAvatarData132, byte[] newAvatarData450)
	{
		return _network.UserActionApi.ProfileChangeAvatar(newAvatarData132, newAvatarData450);
	}

	public Task<PvPRankAddAttackBuffResponse> AddRankAttackBuff(int addBuffCnt)
	{
		return _network.UserActionApi.AddRankAttackBuff(addBuffCnt);
	}

	public Task<GetSimplePvPRankListResponse> GetSimplePvPRank(long tick)
	{
		return _network.UserActionApi.GetSimplePvPRank(tick);
	}

	public Task<GetPVPRankSeasonInfoResponse> GetPVPRankSeasonInfo(long tick)
	{
		return _network.UserActionApi.GetPVPRankSeasonInfo(tick);
	}

	public Task<GetPvPRankLastTurnLast10SelfRankRecordResponse> GetPvPRankLastTurnLast10SelfRankRecord(int seasonId, int turnId)
	{
		return _network.UserActionApi.GetPvPRankLastTurnLast10SelfRankRecord(seasonId, turnId);
	}

	public Task<GetUserProfileUrlResponse> GetUserProfileUrl()
	{
		return _network.UserActionApi.GetUserProfileUrl();
	}

	public Task<GetPvPTopTournamentRankResponse> GetPvPTopTournamentRankInfo()
	{
		return _network.UserActionApi.GetPvPTopTournamentRankInfo();
	}

	public Task<GetPvPRankLastTurnResultResponse> GetPvPRankLastTurnResult(int seasonId, int turnId)
	{
		return _network.UserActionApi.GetPvPRankLastTurnResult(seasonId, turnId);
	}

	public Task<GetPvPTopTournamentRecordSinglePlayerResponse> GetPvPTopTournamentRecordSinglePlayer(int day, int userId)
	{
		return _network.UserActionApi.GetPvPTopTournamentRecordSinglePlayer(day, userId);
	}

	public Task<GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse> GetPvPRankLastTurnLastDaySinglePlayerRecordResult(int userId)
	{
		return _network.UserActionApi.GetPvPRankLastTurnLastDaySinglePlayerRecordResult(userId);
	}

	public Task<GetPvPTopTournamentReplayResponse> GetPvPTopTournamentReplay(string battle)
	{
		return _network.UserActionApi.GetPvPTopTournamentReplay(battle);
	}

	public Task<GetPvPRankLastTurnLastDayDetailsResultResponse> GetPvPRankLastTurnLastDayDetailsResult(string battle)
	{
		return _network.UserActionApi.GetPvPRankLastTurnLastDayDetailsResult(battle);
	}

	public Task<GetPvPTopTournamentPlayersInfoResponse> GetPvPTopTournamentPlayersInfo()
	{
		return _network.UserActionApi.GetPvPTopTournamentPlayersInfo();
	}

	public Task<GetPvPTopTournamentRecordResponse> GetPvPTopTournamentRecord(int day)
	{
		return _network.UserActionApi.GetPvPTopTournamentRecord(day);
	}

	public Task<GetPvPRankLastTurnLastDayResultResponse> GetPvPRankLastTurnLastDayResult()
	{
		return _network.UserActionApi.GetPvPRankLastTurnLastDayResult();
	}

	public Task<ClaimPvPRankScoreResponse> ClaimPvPRankScore(long tick)
	{
		return _network.UserActionApi.ClaimPvPRankScore(tick);
	}

	public Task<GetDynamicLimitedTimeTotalRechargeItemsResponse> GetDynamicLimitedTimeTotalRechargeItems(long tick)
	{
		return _network.UserActionApi.GetDynamicLimitedTimeTotalRechargeItems(tick);
	}

	public Task<ClaimDynamicActivityLTTRResponse> ClaimDynamicActivityLTTR(string activityId, int RMB_Level)
	{
		return _network.UserActionApi.ClaimDynamicActivityLTTR(activityId, RMB_Level);
	}

	public Task<GetDynamicDiscountActivityItemsResponse> GetDynamicDiscountActivityItems(long tick)
	{
		return _network.UserActionApi.GetDynamicDiscountActivityItems(tick);
	}

	public Task<GetDynamicSigninActivityItemsResponse> GetDynamicSigninActivityData(long tick)
	{
		return _network.UserActionApi.GetDynamicSigninActivityData(tick);
	}

	public Task<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse> GetDynamicStarKeyStoreExchangeBonusWithKey(string ItemId, string ActivityId)
	{
		return _network.UserActionApi.GetDynamicStarKeyStoreExchangeBonusWithKey(ItemId, ActivityId);
	}

	public Task<GetDynamicStarKeyStoreExchangeKeyResponse> GetDynamicStarKeyStoreExchangeKey(string FormulaId)
	{
		return _network.UserActionApi.GetDynamicStarKeyStoreExchangeKey(FormulaId);
	}

	public Task<GetDynamicStarKeyStoreIsNewPeriodResponse> GetDynamicStarKeyStoreIsNewPeriod()
	{
		return _network.UserActionApi.GetDynamicStarKeyStoreIsNewPeriod();
	}

	public Task<GetDynamicStarKeyStoreResponse> GetDynamicStarKeyStore()
	{
		return _network.UserActionApi.GetDynamicStarKeyStore();
	}

	public Task<GetDynamicCardPoolResponse> GetDynamicCardPool(long tick)
	{
		return _network.UserActionApi.GetDynamicCardPool(tick);
	}

	public Task<GetDynamicCardPoolActivityResponse> GetDynamicCardPoolActivities(long tick)
	{
		return _network.UserActionApi.GetDynamicCardPoolActivities(tick);
	}

	public Task<GetStoreContentConfigResponse> GetStoreContentConfig()
	{
		return _network.UserActionApi.GetStoreContentConfig();
	}

	public Task<GetDynamicWorldBossResponse> GetDynamicWorldBoss(long tick)
	{
		return _network.UserActionApi.GetDynamicWorldBoss(tick);
	}

	public Task<GetDynamicIslandComeAgainResponse> GetDynamicIslandComeAgain(long tick)
	{
		return _network.UserActionApi.GetDynamicIslandComeAgain(tick);
	}

	public Task<GetRecallPlayerDynamicActivityResponse> GetRecallPlayerDynamicActivity()
	{
		return _network.UserActionApi.GetRecallPlayerDynamicActivity();
	}

	public Task<ClaimRecallPlayerResponse> ClaimRecallPlayer(string InviteCode)
	{
		return _network.UserActionApi.ClaimRecallPlayer(InviteCode);
	}

	public Task<GetDynamicIslandComeAgainRewardResponse> GetDynamicIslandComeAgainReward(long tick, int prizePoolId, int prizePoolIndex)
	{
		return _network.UserActionApi.GetDynamicIslandComeAgainReward(tick, prizePoolId, prizePoolIndex);
	}

	public Task<ClaimIslandComeAgainDailyMissionBonusResponse> ClaimIslandComeAgainDailyMissionBonus(int missionId)
	{
		return _network.UserActionApi.ClaimIslandComeAgainDailyMissionBonus(missionId);
	}

	public Task<GetNeutralInstanceResponse> GetNeutralDungeonActivity(long tick, string activityId)
	{
		return _network.UserActionApi.GetNeutralDungeonActivity(tick, activityId);
	}

	public Task<GetNeutralInstanceAdInfoResponse> GetNeutralDungeonActivityAdInfo(long tick)
	{
		return _network.UserActionApi.GetNeutralDungeonActivityAdInfo(tick);
	}

	public Task<NoviceRechargeResponse> GetNoviceRechargeProgress(long tick, string activityId)
	{
		return _network.UserActionApi.GetNoviceRechargeProgress(tick, activityId);
	}

	public Task<NoviceRechargeBonusClaimResponse> ClaimNoviceRechargeBonus(long tick, string activityId, string score)
	{
		return _network.UserActionApi.ClaimNoviceRechargeBonus(tick, activityId, score);
	}

	public Task<GetTreasureHouseRechargeInfoResponse> GetTreasureHouseRechargeInfo(long tick, string activityId)
	{
		return _network.UserActionApi.GetTreasureHouseRechargeInfo(tick, activityId);
	}

	public Task<TreasureHouseBonusClaimResponse> TreasureHouseBonusClaim(long tick, string activityId, int score)
	{
		return _network.UserActionApi.TreasureHouseBonusClaim(tick, activityId, score);
	}

	public Task<GetDynamicSecretTreasuryResponse> GetDynamicSecretTreasury()
	{
		return _network.UserActionApi.GetDynamicSecretTreasury();
	}

	public Task<ClaimDynamicSecretTreasuryResponse> ClaimDynamicSecretTreasury(int level)
	{
		return _network.UserActionApi.ClaimDynamicSecretTreasury(level);
	}

	public Task<ActivateStoryResponse> ActivateStory(long tick, string storyId, bool playZBossExtraScene = false)
	{
		return _network.UserActionApi.ActivateStory(tick, storyId, playZBossExtraScene);
	}

	public Task<DynamicIslandComeAgainExchangeResponse> DynamicIslandComeAgainExchange(long tick)
	{
		return _network.UserActionApi.DynamicIslandComeAgainExchange(tick);
	}

	public Task<PVPRankSeasonChooseZoneResponse> PVPRankSeasonChooseZone(long tick, int bigZoneId)
	{
		return _network.UserActionApi.PVPRankSeasonChooseZone(tick, bigZoneId);
	}

	public Task<GetPvPTopTournamentFormationResponse> GetPvPTopTournamentFormation()
	{
		return _network.UserActionApi.GetPvPTopTournamentFormation();
	}

	public Task<GetTreasureHuntBattlePresetFormationResponse> GetTreasureHuntBattlePresetFormation()
	{
		return _network.UserActionApi.GetTreasureHuntBattlePresetFormation();
	}

	public Task<SetPvPTopTournamentFormationResponse> SetPvPTopTournamentFormation(RankBattleTopTournamentConfig formation, bool Weekend)
	{
		return _network.UserActionApi.SetPvPTopTournamentFormation(formation, Weekend);
	}

	public Task<SetTreasureHuntBattlePresetFormationResponse> SetTreasureHuntBattlePresetFormation(TreasureHuntBattleFormationConfig formation)
	{
		return _network.UserActionApi.SetTreasureHuntBattlePresetFormation(formation);
	}

	public Task<PvPRankAddDefenseBuffResponse> AddDefenseBuff(int addTime)
	{
		return _network.UserActionApi.AddDefenseBuff(addTime);
	}

	public Task<PvPRankClearCdResponse> ClearRankCd(int addTime)
	{
		return _network.UserActionApi.ClearRankCd(addTime);
	}

	public Task<GetCurrentPvPRankGameResponse> GetCurrentPvPRankGameInfo()
	{
		return _network.UserActionApi.GetCurrentPvPRankGameInfo();
	}

	public Task<GetRankListResponse> GetRankList()
	{
		return _network.UserActionApi.GetRankList();
	}

	public Task<GetDetailRankInfoResponse> GetDetailRankInfo(long tick, int rank, long rankDataTimestamp)
	{
		return _network.UserActionApi.GetDetailRankInfo(tick, rank, rankDataTimestamp);
	}

	public Task<GetSelfRankResponse> GetSelfRank(long tick)
	{
		return _network.UserActionApi.GetSelfRank(tick);
	}

	public Task<UseItemResponse> UseItem(long tick, string itemId, int qty, object context)
	{
		return _network.UserActionApi.UseItem(tick, itemId, qty, context);
	}

	public Task<UpgradeItemResponse> UpgradeItem(long tick, string itemId)
	{
		return _network.UserActionApi.UpgradeItem(tick, itemId);
	}

	public Task<PiecesCompositeResponse> PiecesComposite(long tick, string itemId, int qty)
	{
		return _network.UserActionApi.PiecesComposite(tick, itemId, qty);
	}

	public Task<SoulStoneMaxCompositeToResponse> SoulStoneMaxCompositeTo(long tick, string soldierId, int targetPotentialLevel)
	{
		return _network.UserActionApi.SoulStoneMaxCompositeTo(tick, soldierId, targetPotentialLevel);
	}

	public Task<SoldierEvoluteResponse> SoldierEvolute(long tick, string soldierId)
	{
		return _network.UserActionApi.SoldierEvolute(tick, soldierId);
	}

	public Task<SoldierPotentialBreakthroughResponse> SoldierPotentialBreakthrough(long tick, string soldierId)
	{
		return _network.UserActionApi.SoldierPotentialBreakthrough(tick, soldierId);
	}

	public Task<SoldierAddPotentialProgressResponse> SoldierAddPotentialProgress(long tick, string soldierId, int position, int num)
	{
		return _network.UserActionApi.SoldierAddPotentialProgress(tick, soldierId, position, num);
	}

	public Task<DrawCardResponse> DrawCard(string activityId, string drawOption, int costOption)
	{
		return _network.UserActionApi.DrawCard(activityId, drawOption, costOption);
	}

	public Task<DrawDynamicCardPoolResponse> DrawCardFromDynamicPool(string activityId, string drawOption, int costOption = -1)
	{
		return _network.UserActionApi.DrawCardFromDynamicPool(activityId, drawOption, costOption);
	}

	public Task<GetDrawCardCntResponse> GetDrawCardCnt(string activityId, string drawOption)
	{
		return _network.UserActionApi.GetDrawCardCnt(activityId, drawOption);
	}

	public Task<PendingLotteryResultClaimResponse> ClaimPendingLottery(List<int> chosenList)
	{
		return _network.UserActionApi.ClaimPendingLottery(chosenList);
	}

	public Task<ClaimVerifyIdentityBonusResponse> ClaimVerifyIdentityBonus()
	{
		return _network.UserActionApi.ClaimVerifyIdentityBonus();
	}

	public Task<MainLevelRetreatResponse> MainLevelRetreat(string battleId)
	{
		return _network.UserActionApi.MainLevelRetreat(battleId);
	}

	public Task<MissionClaimResponse> MissionClaim(string missionId)
	{
		return _network.UserActionApi.MissionClaim(missionId);
	}

	public Task<ActivityClaimResponse> ActivityClaim(string activityId)
	{
		return _network.UserActionApi.ActivityClaim(activityId);
	}

	public Task<ClaimDynamicCardPoolBonusResponse> DynamicActivityClaim(string activityId)
	{
		return _network.UserActionApi.DynamicActivityClaim(activityId);
	}

	public Task<ActivityResetResponse> ActivityReset(string activityId)
	{
		return _network.UserActionApi.ActivityReset(activityId);
	}

	public Task<ActivityReviewResponse> ActivitiesReview(List<string> activityIds)
	{
		return _network.UserActionApi.ActivitiesReview(activityIds);
	}

	public Task<CheckActivitiesOverPeriodResponse> CheckActivitiesOverPeriod(List<string> activityIds = null, List<ActivityType> activityTypes = null)
	{
		List<int> list = null;
		if (activityTypes != null)
		{
			list = new List<int>();
			list.AddRange(activityTypes.Select((ActivityType activityType) => (int)activityType));
		}
		return _network.UserActionApi.CheckActivitiesOverPeriod(activityIds, list);
	}

	public Task<CheckActivitiesAutoFillResponse> CheckActivitiesAutoFill(string activityId = null)
	{
		return _network.UserActionApi.CheckActivitiesAutoFill(activityId);
	}

	public Task<AchievementClaimResponse> AchievementClaim(string achievementId)
	{
		return _network.UserActionApi.AchievementClaim(achievementId);
	}

	public Task<SignInClaimResponse> SignInClaim(string activityId, int dayTarget = 0)
	{
		return _network.UserActionApi.SignInClaim(activityId, dayTarget);
	}

	public Task<LeaseholdDailyBonusClaimResponse> ClaimLeaseholdDailyBonus(string leaseholdItemId)
	{
		return _network.UserActionApi.ClaimLeaseholdDailyBonus(leaseholdItemId);
	}

	public Task<GetStoreActivityItemsResponse> GetStoreActivityItems(string activityId, string pageName)
	{
		return _network.UserActionApi.GetStoreActivityItems(activityId, pageName);
	}

	public Task<GetShadowDemonActivityResponse> GetShadowDemonActivity(string activityId)
	{
		return _network.UserActionApi.GetShadowDemonActivity(activityId);
	}

	public Task<GetMissionActivityStoreItemsResponse> GetMissionActivityStoreItems(string activityId, string pageName)
	{
		return _network.UserActionApi.GetMissionActivityStoreItems(activityId, pageName);
	}

	public Task<UpgradeTechnologyResponse> UpgradeTechnology(long tick, string techId)
	{
		return _network.UserActionApi.UpgradeTechnology(tick, techId);
	}

	public Task<ResetTechnologyResponse> ResetTechnology(long tick)
	{
		return _network.UserActionApi.ResetTechnology(tick);
	}

	public Task<SyncProduceResponse> SyncProduce(long tick, bool getAllProduceStates = false)
	{
		return _network.UserActionApi.SyncProduce(tick, getAllProduceStates);
	}

	public Task<SyncGvGProduceResponse> SyncGvGProduce(long tick, bool getAllProduceStates = false)
	{
		return _network.UserActionApi.SyncGvGProduce(tick, getAllProduceStates);
	}

	public Task<GetCollectingInfoResponse> GetCollectingInfo()
	{
		return _network.UserActionApi.GetCollectingInfo();
	}

	public Task<SyncStockResponse> SyncStock(long tick, bool syncAllStock = false, List<string> itemIds = null)
	{
		return _network.UserActionApi.SyncStock(tick, syncAllStock, itemIds);
	}

	public Task<SyncWeeklyMissionScoreResponse> SyncWeeklyMissionScore()
	{
		return _network.UserActionApi.SyncWeeklyMissionScore();
	}

	public Task<GetOfflineYieldBonusResponse> GetOfflineYieldBonuses()
	{
		return _network.UserActionApi.GetOfflineYieldBonuses();
	}

	public Task<PlaceOrderResponse> PlaceOrder(string storeItemId, string paymentType, int priceIndex = -1, int quantity = 1, string payParams = "")
	{
		return _network.StoreApi.PlaceOrder(storeItemId, paymentType, priceIndex, quantity, payParams);
	}

	public Task<VerifyIdentityTapTapResponse> VerifyIdentityTapTap(string token)
	{
		return _network.UserApi.VerifyIdentityTapTap(token);
	}

	public Task<VerifyIdentityTapTapV4Response> VerifyIdentityTapTapV4()
	{
		return _network.UserApi.VerifyIdentityTapTapV4();
	}

	public Task<VerifyIdentityBilibiliResponse> VerifyIdentityBiliBili(string accessKey)
	{
		return _network.UserApi.VerifyIdentityBiliBili(accessKey);
	}

	public Task<VerifyIdentityXipuResponse> VerifyIdentityXipu()
	{
		return _network.UserApi.VerifyIdentityXipu();
	}

	public Task<VerifyIdentityResponse> VerifyIdentity(string idNo, string name)
	{
		return _network.UserApi.VerifyIdentity(idNo, name);
	}

	public Task<bool> GetTelVerifyCode(string telNo)
	{
		return _network.UserApi.GetTelVerifyCode(telNo);
	}

	public Task<CheckOrderResponse> CheckOrder(string orderId, string transactionId, string orderMsg = "")
	{
		return _network.StoreApi.CheckOrder(orderId, transactionId, orderMsg);
	}

	public Task<SyncPendingReceiptsResponse> SyncPendingReceipts(string productId, string receipt)
	{
		return _network.StoreApi.SyncPendingReceipts(productId, receipt);
	}

	public Task<SyncTimeResponse> SyncTimeFromServer()
	{
		return _network.UserApi.SyncTimeFromServer();
	}

	public Task<ServerInfoResponse> ServerInfo()
	{
		return _network.CommonApi.ServerInfo();
	}

	public Task<GetRecycleProductsResponse> GetRecycleProducts(int userId)
	{
		return _network.UserActionApi.GetRecycleProducts(userId);
	}

	public Task<RecycleExportToResponse> RecycleExportTo(int userId)
	{
		return _network.UserActionApi.RecycleExportTo(userId);
	}

	public Task<GetFriendsCanExportRecycleResponse> GetFriendsCanExportRecycle()
	{
		return _network.UserActionApi.GetFriendsCanExportRecycle();
	}

	public Task<GetRecycleStatsResponse> GetRecycleStats(int userId)
	{
		return _network.UserActionApi.GetRecycleStats(userId);
	}

	public Task<SwitchRecycleMultiplayerEnableResponse> SwitchRecycleMultiplayerEnable(bool enable)
	{
		return _network.UserActionApi.SwitchRecycleMultiplayerEnable(enable);
	}

	public Task<GetSelfRecycleStatsResponse> GetSelfRecycleStats()
	{
		return _network.UserActionApi.GetSelfRecycleStats();
	}

	public Task<GetRecycleRebateResponse> GetRecycleRebate()
	{
		return _network.UserActionApi.GetRecycleRebate();
	}

	public Task<ClaimRecycleRebateResponse> ClaimRecycleRebate(int qty)
	{
		return _network.UserActionApi.ClaimRecycleRebate(qty);
	}

	public Task<GetTotalRecycleExportRequestResponse> GetTotalRecycleExportRequest()
	{
		return _network.UserActionApi.GetTotalRecycleExportRequest();
	}

	public Task<GiftRedeemPreviewResponse> GiftRedeemPreview(string redeemCode)
	{
		return _network.UserActionApi.GiftRedeemPreview(redeemCode);
	}

	public Task<GiftRedeemClaimResponse> GiftRedeemClaim(string redeemCode)
	{
		return _network.UserActionApi.GiftRedeemClaim(redeemCode);
	}

	public Task<SetInvitedFromResponse> SetInvitedFrom(string invitingCode)
	{
		return _network.UserActionApi.SetInvitedFrom(invitingCode);
	}

	public Task<ActivateInvitedWorkerResponse> ActivateInvitedWorker(int workerUserId)
	{
		return _network.UserActionApi.ActivateInvitedWorker(workerUserId);
	}

	public Task<ReviewInvitedWorkersResponse> ReviewInvitedWorkers()
	{
		return _network.UserActionApi.ReviewInvitedWorkers();
	}

	public Task<AssignInvitedWorkerResponse> AssignInvitedWorker(int slotIndex, int workerUserId, string buildingType, int workbenchIndex)
	{
		return _network.UserActionApi.AssignInvitedWorker(slotIndex, workerUserId, buildingType, workbenchIndex);
	}

	public Task<ChangeInvitingSlotsConfigResponse> ChangeInvitingSlotsConfig(Dictionary<int, Tuple<int, string, int>> invitingSlotsConfig)
	{
		return _network.UserActionApi.ChangeInvitingSlotsConfig(invitingSlotsConfig);
	}

	public Task<GetInvitedWorkersResponse> GetInvitedWorkers()
	{
		return _network.UserActionApi.GetInvitedWorkers();
	}

	public Task<AddFriendResponse> AddFriend(int friendId)
	{
		return _network.UserActionApi.AddFriend(friendId);
	}

	public Task<DeleteFriendResponse> DeleteFriend(int friendId)
	{
		return _network.UserActionApi.DeleteFriend(friendId);
	}

	public Task<GetFriendsResponse> GetFriends(bool getNew)
	{
		return _network.UserActionApi.GetFriends(getNew);
	}

	public Task<SendChatResponse> SendFriendsChat(int friendId, string contents)
	{
		return _network.UserActionApi.SendFriendsChat(friendId, contents);
	}

	public Task<ReadMessageResponse> ReadFriendsChat(int friendId)
	{
		return _network.UserActionApi.ReadFriendsChat(friendId);
	}

	public Task<GetUnreadMessageResponse> GetUnreadFriendsChat()
	{
		return _network.UserActionApi.GetUnreadFriendsChat();
	}

	public Task<GetFriendsApplyInfoResponse> GetFriendsApplyInfo()
	{
		return _network.UserActionApi.GetFriendsApplyInfo();
	}

	public Task<SendFriendsApplyResponse> SendFriendsApply(string invitingCode)
	{
		return _network.UserActionApi.SendFriendsApply(invitingCode);
	}

	public Task<ModifyFriendsApplyResponse> ModifyFriendsApply(int requestId, bool isAgree)
	{
		return _network.UserActionApi.ModifyFriendsApply(requestId, isAgree);
	}

	public Task<BattlePassActivityClaimResponse> BattlePassActivityClaim(string activity, string level)
	{
		return _network.UserActionApi.BattlePassActivityClaim(activity, level);
	}

	public Task<BindMobileResponse> BindMobile(string mobile)
	{
		return _network.UserActionApi.BindMobile(mobile);
	}

	public Task<BindMobileVerifyResponse> BindMobileVerify(string mobile, string code)
	{
		return _network.UserActionApi.BindMobileVerify(mobile, code);
	}

	public Task<ResetArchiveResponse> ResetArchive()
	{
		return _network.UserActionApi.ResetArchive();
	}

	public Task<ConfirmResetArchiveResponse> ConfirmResetArchive(string token)
	{
		return _network.UserActionApi.ConfirmResetArchive(token);
	}

	public Task<LegendItemAllResponse> LegendItemAll()
	{
		return _network.UserActionApi.LegendItemAll();
	}

	public Task<SelfSelectionBluePrintResponse> SelfSelectionBluePrintUse(string itemId, string mainItemPool, string fxPool, string setAliasPool)
	{
		return _network.UserActionApi.SelfSelectionBluePrintUse(itemId, mainItemPool, fxPool, setAliasPool);
	}

	public Task<SpecialSelectionBluePrintConfigResponse> GetSpecialSelectionBluePrintConfig()
	{
		return _network.UserActionApi.GetSpecialSelectionBluePrintConfig();
	}

	public Task<SpecialSelectionBluePrintResponse> SpecialSelectionBluePrintUse(int sbpIndex, string mainItemPool, string fxPool, string setAliasPool)
	{
		return _network.UserActionApi.SpecialSelectionBluePrintUse(sbpIndex, mainItemPool, fxPool, setAliasPool);
	}

	public Task<SoldierEquippedItemsAllResponse> SoldierEquippedItemsAll()
	{
		return _network.UserActionApi.SoldierEquippedItemsAll();
	}

	public Task<SoldierWearLegendItemResponse> SoldierWearLegendItem(string soldierId, int slotId, long instanceId)
	{
		return _network.UserActionApi.SoldierWearLegendItem(soldierId, slotId, instanceId);
	}

	public Task<SoldierTakeOffLegendItemResponse> SoldierTakeOffLegendItem(string soldierId, int slotId)
	{
		return _network.UserActionApi.SoldierTakeOffLegendItem(soldierId, slotId);
	}

	public Task<SoldierItemSlotAllResponse> SoldierItemSlotAll()
	{
		return _network.UserActionApi.SoldierItemSlotAll();
	}

	public Task<SoldierItemSlotUnlockResponse> SoldierItemSlotUnlock(string soldierId, int slotId)
	{
		return _network.UserActionApi.SoldierItemSlotUnlock(soldierId, slotId);
	}

	public Task<LegendItemEnhancementEnhanceResponse> EnhanceLegendItem(long enhanceTargetId, List<long> foodIds)
	{
		return _network.UserActionApi.EnhanceLegendItem(enhanceTargetId, foodIds);
	}

	public Task<LegendItemLockResponse> LegendItemLock(long instanceId, bool lockStatus)
	{
		return _network.UserActionApi.LegendItemLock(instanceId, lockStatus);
	}

	public Task<LegendItemEnhancementSwitchFxResponse> LegendItemEnhancementSwitchFx(long instanceId, int fxIndex)
	{
		return _network.UserActionApi.LegendItemEnhancementSwitchFx(instanceId, fxIndex);
	}

	public Task<LegendItemEnhancementSwapMainResponse> LegendItemEnhancementSwapMain(long instanceId, long swapInstanceId)
	{
		return _network.UserActionApi.LegendItemEnhancementSwapMain(instanceId, swapInstanceId);
	}

	public Task<LegendItemEnhancementSwitchMainResponse> LegendItemEnhancementSwitchMain(long instanceId, string entryId)
	{
		return _network.UserActionApi.LegendItemEnhancementSwitchMain(instanceId, entryId);
	}

	public Task<LegendItemChangePropertyResponse> LegendItemChangeProperty(long instanceId, int entryType, int entryIndex, int costIndex = -1)
	{
		return _network.UserActionApi.LegendItemChangeProperty(instanceId, entryType, entryIndex, costIndex);
	}

	public Task<LegendItemConfirmChangePropertyResponse> LegendItemConfirmChangeProperty(long instanceId, int entryType, int entryIndex, bool confirm)
	{
		return _network.UserActionApi.LegendItemConfirmChangeProperty(instanceId, entryType, entryIndex, confirm);
	}

	public Task<LegendItemReforgeResponse> LegendItemReforge(long instanceId, List<int> subEntryIndexList, int costIndex = -1, int lockCostIndex = -1)
	{
		return _network.UserActionApi.LegendItemReforge(instanceId, subEntryIndexList, costIndex, lockCostIndex);
	}

	public Task<LegendItemConfirmReforgeResponse> LegendItemConfirmReforge(long instanceId, bool confirm)
	{
		return _network.UserActionApi.LegendItemConfirmReforge(instanceId, confirm);
	}

	public Task<AssignSoldierToTreasureHuntActivityResponse> AssignSoldierToTreasureHuntActivity(List<KeyValuePair<string, int>> soldiers)
	{
		return _network.UserActionApi.AssignSoldierToTreasureHuntActivity(soldiers);
	}

	public Task<GetTreasureHuntActivityProgressResponse> GetTreasureHuntActivityProgress()
	{
		return _network.UserActionApi.GetTreasureHuntActivityProgress();
	}

	public Task<GetTreasureHuntBossInsuranceResponse> GetTreasureHuntBossInsurance()
	{
		return _network.UserActionApi.GetTreasureHuntBossInsurance();
	}

	public Task<GetLegendItemLotteryActivityProgressesResponse> GetLegendItemLotteryActivityProgresses()
	{
		return _network.UserActionApi.GetLegendItemLotteryActivityProgresses();
	}

	public Task<CheckUnshipOrdersResponse> CheckUnshipOrders()
	{
		return _network.UserActionApi.CheckUnshipOrders();
	}

	public Task<CheckUnshipOrders_IOS_Response> CheckUnshipOrders_IOS()
	{
		return _network.UserActionApi.CheckUnshipOrders_IOS();
	}

	public Task<CheckUnshipOrders_Intl_Response> CheckUnshipOrders_Intl()
	{
		return _network.UserActionApi.CheckUnshipOrders_Intl();
	}

	public Task<GetLevelEnemyTemplateResponse> GetLevelEnemyTemplate(string levelId, string activityId = null)
	{
		return _network.UserActionApi.GetLevelEnemyTemplate(levelId, activityId);
	}

	public Task<CheckMissionStatusResponse> CheckMissionStatus(string mid, int status)
	{
		return _network.UserActionApi.CheckMissionStatus(mid, status);
	}

	public Task<CheckReviewPointResponse> CheckReviewPoint()
	{
		return _network.UserActionApi.CheckReviewPoint();
	}

	public Task<StatsTapTapReviewResponse> StatsTapTapReview(string openid, string name)
	{
		return _network.UserActionApi.StatsTapTapReview(openid, name);
	}

	public Task<StatsReviewResponse> StatsReview(string channel, int action)
	{
		return _network.UserActionApi.StatsReview(channel, action);
	}

	public Task<StatsAppStoreReviewResponse> StatsAppStoreReview(string channel, int action)
	{
		return _network.UserActionApi.StatsAppStoreReview(channel, action);
	}

	public Task<GvGMode3AcceptShipResponse> GvGMode3AcceptShip(string shipId)
	{
		return _network.UserActionApi.GvGMode3AcceptShip(shipId);
	}

	public Task<GvGMode3BuildShipResponse> GvGMode3BuildShip(string shipRace, int workers, bool fastBuild)
	{
		return _network.UserActionApi.GvGMode3BuildShip(shipRace, workers, fastBuild);
	}

	public Task<GvGMode3DestroyShipResponse> GvGMode3DestroyShip(string shipId)
	{
		return _network.UserActionApi.GvGMode3DestroyShip(shipId);
	}

	public Task<GvGMode3ShipChangeOrderResponse> GvGMode3ShipChangeOrder(Dictionary<int, string> order)
	{
		return _network.UserActionApi.GvGMode3ShipChangeOrder(order);
	}

	public Task<GetGvGMode3DescriptionsResponse> GetGvGMode3Descriptions()
	{
		return _network.UserActionApi.GetGvGMode3Descriptions();
	}

	public Task<GetGvGMode3ProcessByIZConfigIdResponse> GetGvGMode3ProcessByIZConfigId(string IZConfigId)
	{
		return _network.UserActionApi.GetGvGMode3ProcessByIZConfigId(IZConfigId);
	}

	public Task<GvGMode3ChangeShipConfigResponse> GvGMode3ChangeShipConfig(string ShipId, int changeShipConfigAction, string json)
	{
		return _network.UserActionApi.GvGMode3ChangeShipConfig(ShipId, changeShipConfigAction, json);
	}

	public Task<GvGMode3ClaimSettlementResponse> GvGMode3ClaimSettlement(int _IZId, List<int> _RewardType)
	{
		return _network.UserActionApi.GvGMode3ClaimSettlement(_IZId, _RewardType);
	}

	public Task<GvGMode3CloseBattlePassResponse> GvGMode3CloseBattlePass(int izId)
	{
		return _network.UserActionApi.GvGMode3CloseBattlePass(izId);
	}

	public Task<GvGMode3ClaimBattlePassBonusResponse> GvGMode3ClaimBattlePassBonus(int izId, string activityId, string node)
	{
		return _network.UserActionApi.GvGMode3ClaimBattlePassBonus(izId, activityId, node);
	}

	public Task<GvGMode3GetBattlePassDataResponse> GvGMode3GetBattlePassData(int izId)
	{
		return _network.UserActionApi.GvGMode3GetBattlePassData(izId);
	}

	public Task<GvGMode3CloseLastIZResponse> GvGMode3CloseLastIZ(int _IZId)
	{
		return _network.UserActionApi.GvGMode3CloseLastIZ(_IZId);
	}

	public Task<GvGMode3GetIZSettlementRecordResponse> GvGMode3GetIZSettlementRecord(int _IZId)
	{
		return _network.UserActionApi.GvGMode3GetIZSettlementRecord(_IZId);
	}

	public Task<GvGMode3JoinShipToRoomResponse> GvGMode3JoinShipToRoom(string IZConfigId, int IZId, List<string> ShipIds)
	{
		return _network.UserActionApi.GvGMode3JoinShipToRoom(IZConfigId, IZId, ShipIds);
	}

	public Task<GvGMode3ShipGetRecordResponse> GvGMode3ShipGetRecord()
	{
		return _network.UserActionApi.GvGMode3ShipGetRecord();
	}

	public Task<GvGMode3SignUpActionResponse> GvGMode3SignUpAction(int CampId, int IZId, string IZConfigId, string SignUpAction)
	{
		return _network.UserActionApi.GvGMode3SignUpAction(CampId, IZId, IZConfigId, SignUpAction);
	}

	public Task<GvGMode3LoadDefaultFormationResponse> GvGMode3LoadDefaultFormation(int shipRace)
	{
		return _network.UserActionApi.GvGMode3LoadDefaultFormation(shipRace);
	}

	public Task<SyncDailyMissionScoreResponse> SyncDailyMissionScore()
	{
		return _network.UserActionApi.SyncDailyMissionScore();
	}

	public Task<MoonBattlePassActivityClaimResponse> MoonBattlePassActivityClaim(string actId, string node)
	{
		return _network.UserActionApi.MoonBattlePassActivityClaim(actId, node);
	}

	public Task<WarOfRealmClaimResponse> ClaimWarOfRealm(int score)
	{
		return _network.UserActionApi.ClaimWarOfRealm(score);
	}

	public Task<WarOfRealmGetInfoResponse> GetWarOfRealmInfo()
	{
		return _network.UserActionApi.GetWarOfRealmInfo();
	}

	public Task<GetRecallWelfareResponse> GetRecallWelfare()
	{
		return _network.UserActionApi.GetRecallWelfare();
	}

	public Task<DrawRecallWelfareResponse> DrawRecallWelfare(List<int> index)
	{
		return _network.UserActionApi.DrawRecallWelfare(index);
	}

	public Task<ExchangeRecallWelfareResponse> ExchangeRecallWelfare()
	{
		return _network.UserActionApi.ExchangeRecallWelfare();
	}

	public Task<ClaimRecallWelfareBonusResponse> ClaimRecallWelfareBonus(string missionId)
	{
		return _network.UserActionApi.ClaimRecallWelfareBonus(missionId);
	}

	public Task<GetWarOfRealmFormationResponse> GetWarOfRealmFormation()
	{
		return _network.UserActionApi.GetWarOfRealmFormation();
	}

	public Task<SetWarOfRealmFormationResponse> SetWarOfRealmFormation(WarOfRealmConfig formation)
	{
		return _network.UserActionApi.SetWarOfRealmFormation(formation);
	}

	public Task<WarOfRealmClaimMissionBonusResponse> ClaimWarOfRealmMissionBonus(int score)
	{
		return _network.UserActionApi.ClaimWarOfRealmMissionBonus(score);
	}

	public Task<WarOfRealmClaimRankBonusResponse> ClaimWarOfRealmRankBonus(string activityId)
	{
		return _network.UserActionApi.ClaimWarOfRealmRankBonus(activityId);
	}

	public Task<WarOfRealmGetStageRecordResponse> GetWarOfRealmStageRecord(string activityId, int stageStatus)
	{
		return _network.UserActionApi.GetWarOfRealmStageRecord(activityId, stageStatus);
	}

	public Task<WarOfRealmGetWarBattleRecordResponse> GetWarOfRealmWarBattleRecord(int stageStatus, int userId)
	{
		return _network.UserActionApi.GetWarOfRealmWarBattleRecord(stageStatus, userId);
	}

	public Task<WarOfRealmLotteryResponse> LotteryWarOfRealm(int stageStatus, int groupIdx, List<WarLottery> lotteries)
	{
		return _network.UserActionApi.LotteryWarOfRealm(stageStatus, groupIdx, lotteries);
	}

	public Task<WarOfRealmSettlementResponse> SettlementWarOfRealm(string activityId, int stageStatus)
	{
		return _network.UserActionApi.SettlementWarOfRealm(activityId, stageStatus);
	}

	public Task<WarOfRealmGetStageBattleRecordResponse> GetWarOfRealmStageBattleRecord(int groupId, int stageStatus)
	{
		return _network.UserActionApi.GetWarOfRealmStageBattleRecord(groupId, stageStatus);
	}

	public Task<WarOfRealmReplayResponse> WarOfRealmReplay(string battleId)
	{
		return _network.UserActionApi.WarOfRealmReplay(battleId);
	}

	public Task<WarOfRealmGetScoreHistoryResponse> WarOfRealmScoreHistory()
	{
		return _network.UserActionApi.WarOfRealmGetScoreHistory();
	}

	public Task<GetAccessoryInfoResponse> GetAccessoryInfo()
	{
		return _network.UserActionApi.GetAccessoryInfo();
	}

	public Task<EquipAccessoryResponse> EquipAccessory(string itemId, int type)
	{
		return _network.UserActionApi.EquipAccessory(itemId, type);
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
