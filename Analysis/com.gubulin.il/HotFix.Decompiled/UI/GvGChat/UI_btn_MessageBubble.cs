using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UnityEngine;

namespace UI.GvGChat;

public class UI_btn_MessageBubble : GButton
{
	public Controller Status;

	public GImage back;

	public UI_btn_DialogIcon DialogIcon;

	public UI_com_NewChannelMessage ChannelMessage;

	public UI_com_MessagePopUp Pop_Up;

	public Transition PopUp;

	public Transition PopUpClose;

	public Transition MessageReplace;

	public Transition MessageAppear;

	public Transition MessageDisappear;

	public const string URL = "ui://e3rxkbapyfd37";

	public static string Name = "UI_btn_MessageBubble";

	private UI_main_GvG3Chat _mainUi;

	private const string ChannelMessagePrefix = "             ";

	private const string MessageReplaceHook = "TextChange";

	private const int MessageMaxLength = 93;

	private GTweener _hideChannelMessage;

	private readonly WaitForSeconds _systemMessageDuration = new WaitForSeconds(5f);

	private readonly WaitForSeconds _systemMessageDisappear = new WaitForSeconds(0.5f);

	private bool _isSystemMessageShowing;

	private readonly Queue<GvGMode3ChatRecord> _systemMessageQueue = new Queue<GvGMode3ChatRecord>();

	private readonly WaitForSeconds _chatMessageDuration = new WaitForSeconds(5f);

	private readonly WaitForSeconds _chatMessageDisappear = new WaitForSeconds(0.5f);

	private const float ChatMessageInterval = 0.25f;

	private bool _isChatMessageShowing;

	private Coroutine ShowNextChatCoroutine;

	private long LastRecordId = -1L;

	private readonly Queue<GvGMode3ChatRecord> _chatMessageQueue = new Queue<GvGMode3ChatRecord>();

	private const string Truncate = "[^\\x00-\\xff]";

	private int LastSelectChannel => Singleton<GvG3MessageManager>.Instance.GetLastSelectedChannel();

	public static string GetURL()
	{
		return "ui://e3rxkbapyfd37";
	}

	public static UI_btn_MessageBubble CreateInstance()
	{
		return (UI_btn_MessageBubble)(object)UIPackage.CreateObject("GvGChat", "btn_MessageBubble");
	}

	public static UI_btn_MessageBubble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MessageBubble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbapyfd37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		DialogIcon = (UI_btn_DialogIcon)(object)((GComponent)this).GetChild("DialogIcon");
		ChannelMessage = (UI_com_NewChannelMessage)(object)((GComponent)this).GetChild("ChannelMessage");
		Pop_Up = (UI_com_MessagePopUp)(object)((GComponent)this).GetChild("Pop-Up");
		PopUp = ((GComponent)this).GetTransition("PopUp");
		PopUpClose = ((GComponent)this).GetTransition("PopUpClose");
		MessageReplace = ((GComponent)this).GetTransition("MessageReplace");
		MessageAppear = ((GComponent)this).GetTransition("MessageAppear");
		MessageDisappear = ((GComponent)this).GetTransition("MessageDisappear");
	}

	public void OnInit(UI_main_GvG3Chat mainUi)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)Pop_Up).visible = false;
		_mainUi = mainUi;
		MessageAppear.invalidateBatchingEveryFrame = true;
		UpdateMessageBarStatus();
		((GObject)Pop_Up).onClick.Add(new EventCallback1(PopUpStopPropagation));
		((GObject)Pop_Up.Message).onClickLink.Add(new EventCallback1(OnLinkClick));
		((GObject)Pop_Up.Close).onClick.Add(new EventCallback1(CloseSystemMessage));
		((GObject)DialogIcon).onClick.Add(new EventCallback0(OnClickIcon));
		GvG3MessageManager instance = Singleton<GvG3MessageManager>.Instance;
		instance.OnReceivePushMessagesAction = (Action<ReceiveChannelMessages>)Delegate.Combine(instance.OnReceivePushMessagesAction, new Action<ReceiveChannelMessages>(ShowNewMessage));
	}

	public void OnDestroy()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		GvG3MessageManager instance = Singleton<GvG3MessageManager>.Instance;
		instance.OnReceivePushMessagesAction = (Action<ReceiveChannelMessages>)Delegate.Remove(instance.OnReceivePushMessagesAction, new Action<ReceiveChannelMessages>(ShowNewMessage));
		((GObject)Pop_Up.Message).onClickLink.Remove(new EventCallback1(OnLinkClick));
		((GObject)Pop_Up.Close).onClick.Remove(new EventCallback1(CloseSystemMessage));
		((GObject)Pop_Up).onClick.Remove(new EventCallback1(PopUpStopPropagation));
		((GObject)DialogIcon).onClick.Remove(new EventCallback0(OnClickIcon));
		_mainUi = null;
	}

	private void ShowNewMessage(ReceiveChannelMessages messages)
	{
		if (messages.Channel == eChatUiChannel.System)
		{
			ReceiveSystemMessage(messages.ChatRecords);
		}
		else
		{
			ReceiveChatMessage(messages);
		}
	}

	private void ReceiveSystemMessage(List<GvGMode3ChatRecord> records)
	{
		records = records.Where((GvGMode3ChatRecord record) => record.PopUp).ToList();
		if (records.Count <= 0)
		{
			return;
		}
		foreach (GvGMode3ChatRecord record in records)
		{
			_systemMessageQueue.Enqueue(record);
		}
		if (!_isSystemMessageShowing)
		{
			FGUIManager.Instance.OpenIEnumerator(ShowNextSystemMessage());
		}
	}

	private void ShowSystemMessage(string message)
	{
		if (PopUp.playing)
		{
			PopUp.Stop();
		}
		((GObject)Pop_Up).visible = true;
		((GObject)Pop_Up.Message).text = message;
		PopUp.Play();
	}

	private void CloseSystemMessage(EventContext context)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		if (context != null)
		{
			context.StopPropagation();
		}
		PopUpClose.Play((PlayCompleteCallback)delegate
		{
			((GObject)Pop_Up).visible = false;
		});
		_isSystemMessageShowing = false;
		FGUIManager.Instance.OpenIEnumerator(ShowNextSystemMessage());
	}

	private IEnumerator ShowNextSystemMessage()
	{
		if (!((GObject)this).isDisposed && _systemMessageQueue.Count > 0)
		{
			_isSystemMessageShowing = true;
			GvGMode3ChatRecord nextMessage = _systemMessageQueue.Dequeue();
			ShowSystemMessage(nextMessage.Message);
			yield return _systemMessageDuration;
			CloseSystemMessage(null);
			yield return _systemMessageDisappear;
			_isSystemMessageShowing = false;
			FGUIManager.Instance.OpenIEnumerator(ShowNextSystemMessage());
		}
	}

	private void OnLinkClick(EventContext e)
	{
		if (e != null)
		{
			int num = int.Parse(e.data.ToString());
			if (num > 0)
			{
				Singleton<GvG3MessageManager>.Instance.RedirectIsland(num, OnRedirectIsland);
			}
		}
	}

	private void PopUpStopPropagation(EventContext context)
	{
		context.StopPropagation();
	}

	private void OnClickIcon()
	{
		if (_mainUi.Status.selectedIndex == 0)
		{
			_mainUi.Status.selectedIndex = 1;
		}
	}

	private void OnRedirectIsland()
	{
		_mainUi.Status.selectedIndex = 0;
	}

	private void ReceiveChatMessage(ReceiveChannelMessages records)
	{
		if (records.ChatRecords.Count <= 0)
		{
			return;
		}
		int channel = (int)records.Channel;
		if (LastSelectChannel != channel)
		{
			return;
		}
		GvGMode3ChatRecord gvGMode3ChatRecord = records.ChatRecords[records.ChatRecords.Count - 1];
		if (LastRecordId < gvGMode3ChatRecord.Id)
		{
			LastRecordId = gvGMode3ChatRecord.Id;
			gvGMode3ChatRecord.ChatChannelIndex = (int)records.Channel;
			_chatMessageQueue.Enqueue(gvGMode3ChatRecord);
			if (ShowNextChatCoroutine != null)
			{
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(ShowNextChatCoroutine);
			}
			ShowNextChatCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowNextChatMessage());
		}
	}

	private IEnumerator ShowNextChatMessage()
	{
		if (((GObject)this).isDisposed || _chatMessageQueue.Count <= 0)
		{
			yield break;
		}
		_isChatMessageShowing = true;
		bool showAppearAnim = Status.selectedIndex == 0;
		UpdateMessageBarStatus();
		GvGMode3ChatRecord nextMessage = _chatMessageQueue.Dequeue();
		if (showAppearAnim)
		{
			GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", nextMessage.SenderId, delegate(UserProfile profile)
			{
				SetMessageContent(profile, nextMessage);
			}));
		}
		else
		{
			UpdateChatMessage(nextMessage);
		}
		yield return _chatMessageDuration;
		yield return _chatMessageDisappear;
		_isChatMessageShowing = _chatMessageQueue.Count > 0;
		UpdateMessageBarStatus();
	}

	private void UpdateChatMessage(GvGMode3ChatRecord record)
	{
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", record.SenderId, delegate(UserProfile profile)
		{
			ShowChatMessageText(profile, record);
		}));
	}

	private void ShowChatMessageText(UserProfile profile, GvGMode3ChatRecord record)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		MessageReplace.SetHook("TextChange", (TransitionHook)delegate
		{
			SetMessageContent(profile, record);
		});
		MessageReplace.Play();
	}

	private void SetMessageContent(UserProfile profile, GvGMode3ChatRecord record)
	{
		ChannelMessage.LastMessage.ChannelIcon.Channel.selectedIndex = record.ChatChannelIndex;
		string message = "             " + profile?.Name + "：" + record.Message;
		((GObject)ChannelMessage.LastMessage.Message).text = TruncateAndAddEllipsis(message);
	}

	private void UpdateMessageBarStatus()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		if (!_isChatMessageShowing)
		{
			_hideChannelMessage = ((GComponent)(object)this).SetTimeout(5f).OnComplete((GTweenCallback)delegate
			{
				Status.selectedIndex = 0;
				_hideChannelMessage = null;
			});
			return;
		}
		if (_hideChannelMessage != null)
		{
			_hideChannelMessage.Kill(false);
			_hideChannelMessage = null;
		}
		Status.selectedIndex = 1;
	}

	private string TruncateAndAddEllipsis(string message)
	{
		if (Regex.Replace(message, "[^\\x00-\\xff]", "aa").Length <= 93)
		{
			return message;
		}
		while (Regex.Replace(message, "[^\\x00-\\xff]", "aa").Length > 93)
		{
			message = message.Substring(0, message.Length - 1);
		}
		return message + "...";
	}
}
