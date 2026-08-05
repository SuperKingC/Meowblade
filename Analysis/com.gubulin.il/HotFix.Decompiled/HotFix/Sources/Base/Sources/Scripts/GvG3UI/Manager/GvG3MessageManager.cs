using System;
using System.Collections.Generic;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.GvGChat;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3MessageManager : Singleton<GvG3MessageManager>
{
	private readonly string _selectedChatChannelKey = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_" + $"{GameController.Contexts.gameState.user.value.UserId}_SelectedChatChannel";

	public Action<ReceiveChannelMessages> OnReceiveChannelMessagesAction = null;

	public Action<ReceiveChannelMessages> OnReceivePushMessagesAction = null;

	private GvGMode3ObserverRecord _observerRecord => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;

	public void UpdateSelectedChannel(int channelIndex)
	{
		if (channelIndex <= 1)
		{
			PlayerPrefs.SetInt(_selectedChatChannelKey, channelIndex);
		}
	}

	public int GetLastSelectedChannel()
	{
		int result = 1;
		if (!PlayerPrefs.HasKey(_selectedChatChannelKey))
		{
			return result;
		}
		return PlayerPrefs.GetInt(_selectedChatChannelKey);
	}

	public override void InitInstance()
	{
		GvGMode3MessageConfigHelper.PreLoad();
		S2C_BroadcastChatChannelMessages.OnPushEvent = (Action<S2C_BroadcastChatChannelMessages.Request>)Delegate.Combine(S2C_BroadcastChatChannelMessages.OnPushEvent, new Action<S2C_BroadcastChatChannelMessages.Request>(OnReceiveChannelMessages));
		S2C_BroadcastSystemMessages.OnPushEvent = (Action<S2C_BroadcastSystemMessages.Request>)Delegate.Combine(S2C_BroadcastSystemMessages.OnPushEvent, new Action<S2C_BroadcastSystemMessages.Request>(OnReceiveSystemMessages));
	}

	public void ClearCache()
	{
	}

	public void Destroy()
	{
		S2C_BroadcastChatChannelMessages.OnPushEvent = (Action<S2C_BroadcastChatChannelMessages.Request>)Delegate.Remove(S2C_BroadcastChatChannelMessages.OnPushEvent, new Action<S2C_BroadcastChatChannelMessages.Request>(OnReceiveChannelMessages));
		S2C_BroadcastSystemMessages.OnPushEvent = (Action<S2C_BroadcastSystemMessages.Request>)Delegate.Remove(S2C_BroadcastSystemMessages.OnPushEvent, new Action<S2C_BroadcastSystemMessages.Request>(OnReceiveSystemMessages));
	}

	private void UpdateChatRemainingCount(eChatChannel channel)
	{
		switch (channel)
		{
		case eChatChannel.Camp:
			_observerRecord.CampChatRemainingCount = Mathf.Max(0, _observerRecord.CampChatRemainingCount - 1);
			break;
		case eChatChannel.World:
			_observerRecord.WorldChatFreeRemainingCount = Mathf.Max(0, _observerRecord.WorldChatFreeRemainingCount - 1);
			_observerRecord.WorldChatRemainingCount = Mathf.Max(0, _observerRecord.WorldChatRemainingCount - 1);
			break;
		}
	}

	public void SendMessage(string messageText, eChatChannel channel, Action onSend = null)
	{
		bool buyExtraSending = (channel == eChatChannel.World && _observerRecord.WorldChatFreeRemainingCount <= 0) || (channel == eChatChannel.Camp && _observerRecord.CampChatRemainingCount <= 0);
		Action action = delegate
		{
			SendChatChannelMessage(messageText, channel, buyExtraSending, onSend);
		};
		if (buyExtraSending)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3ChatSendCost.Name, new Dictionary<string, object> { { "ConfirmCost", action } });
		}
		else
		{
			action();
		}
	}

	private void SendChatChannelMessage(string messageText, eChatChannel channel, bool buyExtraSending, Action onSend = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SendChatChannelMessage
		{
			Req = new C2S_SendChatChannelMessage.Request
			{
				StrMessage = messageText,
				IsTemplateText = messageText.StartsWith("##%%"),
				BuyExtraSending = buyExtraSending,
				ChatChannelEnum = channel
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_SendChatChannelMessage.Response response = (C2S_SendChatChannelMessage.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				UpdateChatRemainingCount(response.ChatChannelEnum);
				onSend?.Invoke();
			}
		});
	}

	public void OnReceiveChannelMessages(S2C_BroadcastChatChannelMessages.Request request)
	{
		if (request != null)
		{
			ParseRecords(ref request.RecordList, eChatThemeType.Dark);
			ReceiveChannelMessages obj = new ReceiveChannelMessages
			{
				Channel = (eChatUiChannel)request.ChatChannelEnum,
				ChatRecords = request.RecordList,
				IsPush = true
			};
			OnReceiveChannelMessagesAction?.Invoke(obj);
			OnReceivePushMessagesAction?.Invoke(obj);
		}
	}

	public void OnReceiveSystemMessages(S2C_BroadcastSystemMessages.Request request)
	{
		if (request != null)
		{
			List<GvGMode3ChatRecord> records = request.RecordList;
			List<GvGMode3ChatRecord> records2 = request.RecordList.Clone();
			ParseRecords(ref records);
			ParseRecords(ref records2, eChatThemeType.Dark);
			OnReceiveChannelMessagesAction?.Invoke(new ReceiveChannelMessages
			{
				Channel = eChatUiChannel.System,
				ChatRecords = records2,
				IsPush = true
			});
			OnReceivePushMessagesAction?.Invoke(new ReceiveChannelMessages
			{
				Channel = eChatUiChannel.System,
				ChatRecords = records,
				IsPush = true
			});
		}
	}

	public void GetChannelMessages(int channelIndex, long startId = -1L, Action onFailed = null)
	{
		if (channelIndex == 2)
		{
			GetSystemMessages(startId);
			return;
		}
		eChatChannel chatChannel = (eChatChannel)channelIndex;
		GetChatMessages(chatChannel, startId, onFailed);
	}

	private void GetSystemMessages(long startId = -1L)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetSystemMessages
		{
			Req = new C2S_GetSystemMessages.Request
			{
				StartId = startId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetSystemMessages.Response response = (C2S_GetSystemMessages.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ParseRecords(ref response.RecordList, eChatThemeType.Dark);
				OnReceiveChannelMessagesAction?.Invoke(new ReceiveChannelMessages
				{
					StartId = startId,
					Channel = eChatUiChannel.System,
					ChatRecords = response.RecordList
				});
			}
		});
	}

	private void GetChatMessages(eChatChannel chatChannel, long startId = -1L, Action onFailed = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetChatChannelMessages
		{
			Req = new C2S_GetChatChannelMessages.Request
			{
				StartId = startId,
				ChatChannelEnum = chatChannel
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetChatChannelMessages.Response response = (C2S_GetChatChannelMessages.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFailed?.Invoke();
			}
			else
			{
				ParseRecords(ref response.RecordList, eChatThemeType.Dark);
				OnReceiveChannelMessagesAction?.Invoke(new ReceiveChannelMessages
				{
					StartId = startId,
					Channel = (eChatUiChannel)response.ChatChannelEnum,
					ChatRecords = response.RecordList
				});
			}
		});
	}

	public void RedirectIsland(int islandId, Action onConfirm)
	{
		Action value = delegate
		{
			if (GvG3IslandController.IsInstanceCreated)
			{
				SharedMessenger.Broadcast("ON_ClOSE_UI_main_GvGOnIsland3", new UICallbackParam<Action>(delegate
				{
					GvGWorldMapController.Instance.FocusIslandById(islandId);
					onConfirm?.Invoke();
				}));
			}
			else if (GvGWorldMapController.IsInstanceCreated)
			{
				GvGWorldMapController.Instance.FocusIslandById(islandId);
				onConfirm?.Invoke();
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3ChatRedirectIsland.Name, new Dictionary<string, object>
		{
			{ "ConfirmAction", value },
			{
				"IslandName",
				WorldMapConfigHelper.Configs.TryGetIsland(islandId).Name
			}
		});
	}

	private void ParseRecords(ref List<GvGMode3ChatRecord> records, eChatThemeType textType = eChatThemeType.Light)
	{
		if (records == null)
		{
			records = new List<GvGMode3ChatRecord>();
			return;
		}
		for (int num = records.Count - 1; num >= 0; num--)
		{
			if (!records[num].ParseMessage(textType))
			{
				records.RemoveAt(num);
			}
		}
	}
}
