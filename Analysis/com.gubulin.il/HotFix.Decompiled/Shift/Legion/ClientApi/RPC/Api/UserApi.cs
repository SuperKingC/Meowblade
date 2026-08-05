using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using HotFix;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.ClientApi.RPC.Api;

public class UserApi : Api
{
	private readonly string _authServerUrl;

	private readonly Uri _baseAddress;

	private CookieContainer _cookieContainer;

	private static int MARK;

	private int mark;

	public UserApi(Dictionary<string, string> configs)
	{
		mark = MARK++;
		_authServerUrl = configs["AuthServerUrl"];
		_baseAddress = new Uri(_authServerUrl);
		_cookieContainer = new CookieContainer();
		SentrySdk.AddBreadcrumb($"[UserApi-{mark}]New UserApi");
	}

	public void ClearCookie()
	{
		_cookieContainer = new CookieContainer();
		RPCConnection.Token = string.Empty;
		SentrySdk.AddBreadcrumb($"[UserApi-{mark}]ClearCookie");
	}

	private async Task<HttpResponseMessage> SendRequest(string url, HttpContent content)
	{
		Uri uri = new Uri(url);
		SentrySdk.AddBreadcrumb($"[SendRequest][UserApi-{mark}]url={url}, RPCConnection.Token={RPCConnection.Token}, _cookieContainer.Count={_cookieContainer.Count}");
		if (!string.IsNullOrEmpty(RPCConnection.Token) && _cookieContainer.Count <= 0)
		{
			string _testText = WebUtility.UrlDecode(RPCConnection.Token);
			Cookie cookie = new Cookie("SESSID", _testText, "/", HotUpdateProcess.Instance.RegionModel.Zone.url.domain);
			_cookieContainer.Add(cookie);
			SentrySdk.AddBreadcrumb($"[SendRequest][UserApi-{mark}]Add Cookie {cookie.Name}={cookie.Value};Domain={cookie.Domain}");
		}
		using HttpClientHandler handler = new HttpClientHandler
		{
			CookieContainer = _cookieContainer
		};
		using HttpClient client = new HttpClient(handler)
		{
			BaseAddress = uri
		};
		client.DefaultRequestHeaders.Add("User-Agent", Network.UserAgentInfo);
		HttpResponseMessage result = await client.PostAsync(uri, content);
		foreach (object cookieObj in _cookieContainer.GetCookies(uri))
		{
			Cookie cookie2 = cookieObj as Cookie;
			SentrySdk.AddBreadcrumb($"[SendRequest][UserApi-{mark}]Response Cookie {cookie2?.Name}={cookie2?.Value};Domain={cookie2?.Domain}");
		}
		return result;
	}

	public async Task<GetOaidCertTextResult> GetOaidCertTextOperation(long timestamp)
	{
		Random rd = new Random();
		int _randomInt = rd.Next(0, (int)timestamp);
		string _key = $"deviceUniqueIdentifier={SystemInfo.deviceUniqueIdentifier}&RandomInt={_randomInt}&Timestamp={timestamp}&Key=wU3dWX2E1rbPJrUM";
		FormUrlEncodedContent content = new FormUrlEncodedContent(new KeyValuePair<string, string>[4]
		{
			new KeyValuePair<string, string>("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier),
			new KeyValuePair<string, string>("RandomInt", _randomInt.ToString()),
			new KeyValuePair<string, string>("Timestamp", timestamp.ToString()),
			new KeyValuePair<string, string>("Key", HotFix_Utils.CreateMD5(_key))
		});
		string _url = _baseAddress?.ToString() + "GetOAIDKey";
		HttpResponseMessage result = await SendRequest(_url, content);
		result.EnsureSuccessStatusCode();
		string response = await result.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(response))
		{
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000009));
		}
		Dictionary<string, object> ResultUserCredentials = JsonHelper.ToObject<Dictionary<string, object>>(response);
		if (ResultUserCredentials.TryGetValue("ErrorCode", out var code) && ResultUserCredentials.TryGetValue("Key", out var keyValue))
		{
			return new GetOaidCertTextResult
			{
				ErrorCode = int.Parse(code.ToString()),
				Key = keyValue.ToString()
			};
		}
		if (ResultUserCredentials.TryGetValue("ErrorCode", out var codeValue))
		{
			return new GetOaidCertTextResult
			{
				ErrorCode = int.Parse(codeValue.ToString()),
				Key = ""
			};
		}
		return new GetOaidCertTextResult
		{
			ErrorCode = -1
		};
	}

	public async Task<CredentialsOperationResult> CredentialsOperation(string TypeStr, UserLoginCredentialsOperation op, int UserId)
	{
		if (op == UserLoginCredentialsOperation.GetUserIdsInfo)
		{
			return new CredentialsOperationResult
			{
				ErrorCode = -1
			};
		}
		UserLoginCredentialsResult RetVal = new UserLoginCredentialsResult
		{
			ErrorCode = -1,
			CurrentUserId = -1,
			Infos = new List<UserLoginCredentialsProto>()
		};
		HttpResponseMessage result = await SendRequest(content: new FormUrlEncodedContent(new KeyValuePair<string, string>[3]
		{
			new KeyValuePair<string, string>("TypeStr", TypeStr),
			new KeyValuePair<string, string>("Op", op.ToString()),
			new KeyValuePair<string, string>("OpUserId", UserId.ToString())
		}), url: _baseAddress?.ToString() + "CredentialsOperation");
		result.EnsureSuccessStatusCode();
		string response = await result.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(response))
		{
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000008));
		}
		Dictionary<string, object> ResultUserCredentials = JsonHelper.ToObject<Dictionary<string, object>>(response);
		if (ResultUserCredentials.TryGetValue("ErrorCode", out var code))
		{
			return new CredentialsOperationResult
			{
				ErrorCode = int.Parse(code.ToString())
			};
		}
		return new CredentialsOperationResult
		{
			ErrorCode = -1
		};
	}

	public async Task<UserLoginCredentialsResult> GetCredentialsOperation(string TypeStr, int UserId)
	{
		UserLoginCredentialsResult RetVal = new UserLoginCredentialsResult
		{
			ErrorCode = -1,
			CurrentUserId = UserId,
			Infos = new List<UserLoginCredentialsProto>()
		};
		HttpResponseMessage result = await SendRequest(content: new FormUrlEncodedContent(new KeyValuePair<string, string>[3]
		{
			new KeyValuePair<string, string>("TypeStr", TypeStr),
			new KeyValuePair<string, string>("Op", UserLoginCredentialsOperation.GetUserIdsInfo.ToString()),
			new KeyValuePair<string, string>("UserId", UserId.ToString())
		}), url: _baseAddress?.ToString() + "CredentialsOperation");
		result.EnsureSuccessStatusCode();
		string response = await result.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(response))
		{
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000011));
		}
		Dictionary<string, object> ResultUserCredentials = JsonHelper.ToObject<Dictionary<string, object>>(response);
		if (ResultUserCredentials.TryGetValue("ErrorCode", out var code))
		{
			RetVal.ErrorCode = int.Parse(code.ToString());
		}
		if (ResultUserCredentials.TryGetValue("Infos", out var Infos))
		{
			RetVal.Infos = JsonHelper.ToObject<List<UserLoginCredentialsProto>>(Infos.ToString());
		}
		return RetVal;
	}

	public async Task<string> GetWechatUserInfo(string code)
	{
		FormUrlEncodedContent content = new FormUrlEncodedContent(new KeyValuePair<string, string>[1]
		{
			new KeyValuePair<string, string>("code", code)
		});
		try
		{
			HttpResponseMessage result = await SendRequest(_baseAddress?.ToString() + "GetWechatUserInfo", content);
			result.EnsureSuccessStatusCode();
			string response = await result.Content.ReadAsStringAsync();
			if (string.IsNullOrEmpty(response))
			{
				throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000008));
			}
			Dictionary<string, string> ResultWechatUserInfo = JsonHelper.ToObject<Dictionary<string, string>>(response);
			ResultWechatUserInfo.TryGetValue("ErrorCode", out var errorCode);
			ResultWechatUserInfo.TryGetValue("UserInfo", out var userInfo);
			if (errorCode != null && 0.ToString().Equals(errorCode) && userInfo != null)
			{
				return userInfo;
			}
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000008));
		}
		catch (Exception ex)
		{
			Exception e = ex;
			ILRuntimeDebug.LogError(e.Message);
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000008));
		}
	}

	public async Task<string> GetWechatQRCodeSignature(string nonceStr, string timestamp)
	{
		try
		{
			HttpResponseMessage result = await SendRequest($"{_baseAddress}GetWechatQRCodeSignature?noncestr={nonceStr}&timestamp={timestamp}", new StringContent(""));
			result.EnsureSuccessStatusCode();
			string response = await result.Content.ReadAsStringAsync();
			if (string.IsNullOrEmpty(response))
			{
				throw new AuthenticationException("No Response. " + LanguagesManager.GetJsonErrorMessage(82000008));
			}
			Dictionary<string, string> WechatQRCodeSignatureInfo = JsonHelper.ToObject<Dictionary<string, string>>(response);
			WechatQRCodeSignatureInfo.TryGetValue("ErrorCode", out var errorCode);
			if (errorCode != null && 0.ToString().Equals(errorCode) && WechatQRCodeSignatureInfo.TryGetValue("Signature", out var signature))
			{
				return signature;
			}
			if (WechatQRCodeSignatureInfo.TryGetValue("ErrorMsg", out var errorMsg) && !string.IsNullOrEmpty(errorMsg))
			{
				throw new AuthenticationException(errorMsg);
			}
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000008));
		}
		catch (Exception ex)
		{
			Exception e = ex;
			ILRuntimeDebug.LogError("GetWechatQRCodeSignature Failed: " + e.Message);
			throw new AuthenticationException(e.Message);
		}
	}

	public async Task<UserLoginCredentialsResult> GetUserCredentialsAsync(string TypeStr, string Value, string zone)
	{
		UserLoginCredentialsResult RetVal = new UserLoginCredentialsResult
		{
			ErrorCode = -1,
			CurrentUserId = -1,
			Infos = new List<UserLoginCredentialsProto>()
		};
		HttpResponseMessage result = await SendRequest(content: new FormUrlEncodedContent(new KeyValuePair<string, string>[3]
		{
			new KeyValuePair<string, string>("TypeStr", TypeStr),
			new KeyValuePair<string, string>("Value", Value),
			new KeyValuePair<string, string>("Zone", zone)
		}), url: _baseAddress?.ToString() + "GetUserCredentials");
		if (result == null)
		{
			ILRuntimeDebug.LogError("GetUserCredentialsAsync result is null");
		}
		result.EnsureSuccessStatusCode();
		string response = await result.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(response))
		{
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000008));
		}
		Dictionary<string, object> ResultUserCredentials = JsonHelper.ToObject<Dictionary<string, object>>(response);
		ResultUserCredentials.TryGetValue("ErrorCode", out var code);
		ResultUserCredentials.TryGetValue("CurrentUserId", out var _id);
		if (ResultUserCredentials.TryGetValue("Zone", out var serverZone) && !string.IsNullOrEmpty(serverZone.ToString()) && serverZone.ToString().Equals(HotUpdateProcess.ZoneKey))
		{
			GameLocalDataManager.SetZonePrefer(serverZone.ToString());
		}
		if (code != null)
		{
			if (code.ToString() == 1001.ToString())
			{
				RetVal.ErrorCode = 1001;
				RetVal.CurrentUserId = int.Parse(_id.ToString());
			}
			else if (code.ToString() == 1003.ToString())
			{
				RetVal.ErrorCode = 1003;
			}
		}
		foreach (UserLoginCredentialsProto info in RetVal.Infos)
		{
			string logstr = "";
			logstr += $"UserId={info.UserId} UserLevel={info.UserLevel} NickName={info.NickName} ";
			logstr = (string.IsNullOrEmpty(info.Gem) ? (logstr + "Gem = null ") : (logstr + $"GemValue = {info.GemValue.Stock} "));
			logstr = (string.IsNullOrEmpty(info.MTG) ? (logstr + "MTG = null ") : (logstr + $"MTGValue = {info.MTGValue.Stock} "));
			if (!string.IsNullOrEmpty(info.ManPower))
			{
				_ = logstr + $"ManPowerValue = {info.ManPowerValue.Stock} ";
			}
			else
			{
				_ = logstr + "ManPower = null ";
			}
		}
		SharedMessenger.Broadcast("GET_CREDENTIALS", RetVal.Infos);
		return RetVal;
	}

	public async Task<UserTokenInfo> AuthenticateAsync(string account, string password, int identityType = 1, int UserId = -1)
	{
		bool isNewUser = false;
		HttpResponseMessage result = await SendRequest(content: new FormUrlEncodedContent(new KeyValuePair<string, string>[3]
		{
			new KeyValuePair<string, string>("account", account),
			new KeyValuePair<string, string>("password", password),
			new KeyValuePair<string, string>("identityType", identityType.ToString())
		}), url: _baseAddress?.ToString() + "authenticate?UserId=" + UserId);
		result.EnsureSuccessStatusCode();
		string response = await result.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(response) || response == "0")
		{
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000010));
		}
		if (response == "2")
		{
			isNewUser = true;
		}
		else if (response != "1")
		{
			throw new AuthenticationException(response);
		}
		CookieCollection cookies = _cookieContainer.GetCookies(_baseAddress);
		string token = cookies["SESSID"]?.Value;
		return new UserTokenInfo
		{
			Token = token,
			IsNewUser = isNewUser
		};
	}

	public async Task<string> GuestBindByThirdParty(string bindData)
	{
		StringContent content = new StringContent(bindData);
		content.Headers.ContentType.MediaType = "application/json";
		HttpResponseMessage result = await SendRequest(_baseAddress?.ToString() + "GuestBindByThirdParty", content);
		result.EnsureSuccessStatusCode();
		string response = await result.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(response) || response == "0")
		{
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000010));
		}
		return response;
	}

	public async Task<UserTokenInfo> AuthenticateByPlatformAsync(string data, string platformType, int UserId, string channelCode)
	{
		bool isNewUser = false;
		StringContent content = new StringContent(data);
		content.Headers.ContentType.MediaType = "application/json";
		HttpResponseMessage result = await SendRequest(_baseAddress?.ToString() + "AuthenticateBy" + platformType + "?UserId=" + UserId + "&ChannelCode=" + channelCode, content);
		result.EnsureSuccessStatusCode();
		string response = await result.Content.ReadAsStringAsync();
		if (string.IsNullOrEmpty(response) || response == "0")
		{
			throw new AuthenticationException(LanguagesManager.GetJsonErrorMessage(82000010));
		}
		if (response == "2")
		{
			isNewUser = true;
		}
		else if (response != "1")
		{
			throw new AuthenticationException(LanguagesManager.GetAuthenticateMessage(response));
		}
		CookieCollection cookies = _cookieContainer.GetCookies(_baseAddress);
		string token = cookies["SESSID"]?.Value;
		return new UserTokenInfo
		{
			Token = token,
			IsNewUser = isNewUser
		};
	}

	public Task<LoginResponse> Login(string token)
	{
		RPCConnection.Token = token;
		TaskCompletionSource<LoginResponse> tcs = new TaskCompletionSource<LoginResponse>();
		RPCConnection.QueueRequest(new LoginRequest(), delegate(RPCContext context)
		{
			try
			{
				LoginResponse result = context.Payload.As<LoginResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<PreCheckResponse> PreCheck()
	{
		TaskCompletionSource<PreCheckResponse> tcs = new TaskCompletionSource<PreCheckResponse>();
		RPCConnection.QueueRequest(new PreCheckRequest(), delegate(RPCContext context)
		{
			try
			{
				PreCheckResponse result = context.Payload.As<PreCheckResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<GetServerStatusResponse> GetServerStatus()
	{
		TaskCompletionSource<GetServerStatusResponse> tcs = new TaskCompletionSource<GetServerStatusResponse>();
		RPCConnection.QueueRequest(new GetServerStatusRequest(), delegate(RPCContext context)
		{
			try
			{
				tcs.SetResult(context.Payload.As<GetServerStatusResponse>());
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<VerifyIdentityTapTapResponse> VerifyIdentityTapTap(string token)
	{
		TaskCompletionSource<VerifyIdentityTapTapResponse> tcs = new TaskCompletionSource<VerifyIdentityTapTapResponse>();
		RPCConnection.QueueRequest(new VerifyIdentityTapTapRequest
		{
			token = token
		}, delegate(RPCContext context)
		{
			try
			{
				VerifyIdentityTapTapResponse result = context.Payload.As<VerifyIdentityTapTapResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<VerifyIdentityTapTapV4Response> VerifyIdentityTapTapV4()
	{
		TaskCompletionSource<VerifyIdentityTapTapV4Response> tcs = new TaskCompletionSource<VerifyIdentityTapTapV4Response>();
		RPCConnection.QueueRequest(new VerifyIdentityTapTapV4Request(), delegate(RPCContext context)
		{
			try
			{
				VerifyIdentityTapTapV4Response result = context.Payload.As<VerifyIdentityTapTapV4Response>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<VerifyIdentityBilibiliResponse> VerifyIdentityBiliBili(string accessKey)
	{
		TaskCompletionSource<VerifyIdentityBilibiliResponse> tcs = new TaskCompletionSource<VerifyIdentityBilibiliResponse>();
		RPCConnection.QueueRequest(new VerifyIdentityBilibiliRequest
		{
			AccessKey = accessKey
		}, delegate(RPCContext context)
		{
			try
			{
				VerifyIdentityBilibiliResponse result = context.Payload.As<VerifyIdentityBilibiliResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<VerifyIdentityXipuResponse> VerifyIdentityXipu()
	{
		TaskCompletionSource<VerifyIdentityXipuResponse> tcs = new TaskCompletionSource<VerifyIdentityXipuResponse>();
		RPCConnection.QueueRequest(new VerifyIdentityXipuRequest(), delegate(RPCContext context)
		{
			try
			{
				VerifyIdentityXipuResponse result = context.Payload.As<VerifyIdentityXipuResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<VerifyIdentityResponse> VerifyIdentity(string idNo, string name)
	{
		TaskCompletionSource<VerifyIdentityResponse> tcs = new TaskCompletionSource<VerifyIdentityResponse>();
		RPCConnection.QueueRequest(new VerifyIdentityRequest
		{
			IdNumber = idNo,
			Name = name
		}, delegate(RPCContext context)
		{
			try
			{
				tcs.SetResult(context.Payload.As<VerifyIdentityResponse>());
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<bool> GetTelVerifyCode(string telNo)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		RPCConnection.QueueRequest(new TelVerifyCodeRequest
		{
			TelNo = telNo
		}, delegate
		{
			try
			{
				tcs.SetResult(result: true);
			}
			catch (Exception)
			{
				tcs.SetResult(result: false);
			}
		});
		return tcs.Task;
	}

	public Task<UserDeviceInfoResponse> SubmitDeviceInfo(DeviceInfo info)
	{
		TaskCompletionSource<UserDeviceInfoResponse> tcs = new TaskCompletionSource<UserDeviceInfoResponse>();
		RPCConnection.QueueRequest(new UserDeviceInfoRequest
		{
			Info = info
		}, delegate(RPCContext context)
		{
			try
			{
				UserDeviceInfoResponse result = context.Payload.As<UserDeviceInfoResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<DeviceIdentifierResponse> SubmitDeviceIdentifier(string deviceIdentifier, string idfa)
	{
		TaskCompletionSource<DeviceIdentifierResponse> tcs = new TaskCompletionSource<DeviceIdentifierResponse>();
		RPCConnection.QueueRequest(new DeviceIdentifierRequest
		{
			DeviceIdentifier = deviceIdentifier,
			IDFA = idfa
		}, delegate(RPCContext context)
		{
			try
			{
				DeviceIdentifierResponse result = context.Payload.As<DeviceIdentifierResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task SubmitDeviceLog(string deviceIdentifier, GameEvent gameEvent, Dictionary<string, string> content = null)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		RPCConnection.QueueRequest(new DeviceLogRequest
		{
			Event = (int)gameEvent,
			DeviceIdentifier = deviceIdentifier,
			Content = content
		}, delegate
		{
			try
			{
				tcs.SetResult(result: true);
			}
			catch (Exception)
			{
				tcs.SetResult(result: false);
			}
		});
		return tcs.Task;
	}

	public Task<SyncTimeResponse> SyncTimeFromServer()
	{
		TaskCompletionSource<SyncTimeResponse> tcs = new TaskCompletionSource<SyncTimeResponse>();
		RPCConnection.QueueRequest(new SyncTimeRequest(), delegate(RPCContext context)
		{
			try
			{
				SyncTimeResponse result = context.Payload.As<SyncTimeResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}
}
