using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.PublicResources;

namespace UI.GvGChat;

public class UI_com_Chat : GComponent
{
	public Controller Status;

	public Controller Type;

	public UI_com_ChatPages ChatPages;

	public UI_com_ChatPageBack n10;

	public GImage n11;

	public GImage n12;

	public GList Tabs;

	public GGroup n13;

	public Transition Appear;

	public Transition Disappear;

	public const string URL = "ui://e3rxkbaprb0jd";

	public static string Name = "UI_com_Chat";

	private readonly List<GvGMode3ChatRecord> _channelChatRecords = new List<GvGMode3ChatRecord>();

	private readonly HashSet<long> _recordIds = new HashSet<long>();

	private UI_main_GvG3Chat _mainUi;

	public static UI_com_Chat Instance { get; private set; }

	private int SelectChannelIndex => Tabs.selectedIndex;

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0jd";
	}

	public static UI_com_Chat CreateInstance()
	{
		return (UI_com_Chat)(object)UIPackage.CreateObject("GvGChat", "com_Chat");
	}

	public static UI_com_Chat CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Chat).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		ChatPages = (UI_com_ChatPages)(object)((GComponent)this).GetChild("ChatPages");
		n10 = (UI_com_ChatPageBack)(object)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		Tabs = (GList)((GComponent)this).GetChild("Tabs");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		Appear = ((GComponent)this).GetTransition("Appear");
		Disappear = ((GComponent)this).GetTransition("Disappear");
	}

	public void OnInit(UI_main_GvG3Chat mainUi)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		_mainUi = mainUi;
		ChatPages.Messages.SetVirtual();
		ChatPages.Messages.itemProvider = new ListItemProvider(GetChatRecordItemResource);
		ChatPages.Messages.itemRenderer = new ListItemRenderer(RenderChatRecordItem);
		((GComponent)ChatPages.Messages).scrollPane.onPullDownRelease.Add(new EventCallback0(GetMoreChannelMessages));
		Tabs.onClickItem.Add(new EventCallback0(OnTabsSelectIndexChange));
		Type.onChanged.Add(new EventCallback0(OnPageIndexChanged));
		GvG3MessageManager instance = Singleton<GvG3MessageManager>.Instance;
		instance.OnReceiveChannelMessagesAction = (Action<ReceiveChannelMessages>)Delegate.Combine(instance.OnReceiveChannelMessagesAction, new Action<ReceiveChannelMessages>(UpdateChatRecords));
		ChatPages.Input.OnInit();
		Instance = this;
		Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom(SetChannelPage);
	}

	public void OnDestroy()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		ChatPages.Input.OnDestroy();
		Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
		GvG3MessageManager instance = Singleton<GvG3MessageManager>.Instance;
		instance.OnReceiveChannelMessagesAction = (Action<ReceiveChannelMessages>)Delegate.Remove(instance.OnReceiveChannelMessagesAction, new Action<ReceiveChannelMessages>(UpdateChatRecords));
		Tabs.onClickItem.Remove(new EventCallback0(OnTabsSelectIndexChange));
		Type.onChanged.Remove(new EventCallback0(OnPageIndexChanged));
		((GComponent)ChatPages.Messages).scrollPane.onPullDownRelease.Remove(new EventCallback0(GetMoreChannelMessages));
		_mainUi = null;
		Instance = null;
	}

	public bool SendMessage(string msg, eChatChannel channel, Action onSent = null)
	{
		if (string.IsNullOrEmpty(msg))
		{
			throw new Exception("[UI_com_Chat] SendMessage 的 msg 参数不能为空");
		}
		Tabs.selectedIndex = (int)channel;
		OnTabsSelectIndexChange();
		return ChatPages.Input.SendMessage(msg, channel, onSent);
	}

	public bool SendRichTextMessage(eChatUserTemplateType type, List<object> parameters, eChatChannel channel, Action onSent = null)
	{
		string msg = GvGMode3MessageConfigHelper.GenerateUserRichText(type, parameters);
		return SendMessage(msg, channel, onSent);
	}

	private void OnTabsSelectIndexChange()
	{
		Type.selectedIndex = Tabs.selectedIndex;
	}

	private void SetChannelPage()
	{
		int lastSelectedChannel = Singleton<GvG3MessageManager>.Instance.GetLastSelectedChannel();
		Tabs.selectedIndex = lastSelectedChannel;
		OnTabsSelectIndexChange();
		GetLastChannelMessages();
		ChatPages.Input.OnPageChanged(SelectChannelIndex);
	}

	private void OnPageIndexChanged()
	{
		Singleton<GvG3MessageManager>.Instance.UpdateSelectedChannel(SelectChannelIndex);
		GetLastChannelMessages();
		ChatPages.Input.OnPageChanged(SelectChannelIndex);
	}

	private void OnClickLink(EventContext e)
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

	private void OnRedirectIsland()
	{
		_mainUi.Status.selectedIndex = 0;
	}

	private void RenderChannelChatRecords()
	{
		ChatPages.Messages.numItems = _channelChatRecords.Count;
	}

	private void RenderChatRecordItem(int index, GObject obj)
	{
		if (index < _channelChatRecords.Count)
		{
			GvGMode3ChatRecord gvGMode3ChatRecord = _channelChatRecords[index];
			if (gvGMode3ChatRecord.IsMe)
			{
				RenderMyChatRecord(gvGMode3ChatRecord, obj);
			}
			if (gvGMode3ChatRecord.IsUser)
			{
				RenderUserChatRecord(gvGMode3ChatRecord, obj);
			}
			if (gvGMode3ChatRecord.IsSystem)
			{
				RenderSystemRecord(gvGMode3ChatRecord, obj);
			}
		}
	}

	private string GetChatRecordItemResource(int index)
	{
		GvGMode3ChatRecord gvGMode3ChatRecord = _channelChatRecords[index];
		if (gvGMode3ChatRecord.IsMe)
		{
			return "ui://GvGChat/com_Message_My";
		}
		if (gvGMode3ChatRecord.IsUser)
		{
			return "ui://GvGChat/com_Message_User";
		}
		if (gvGMode3ChatRecord.IsSystem)
		{
			return "ui://GvGChat/com_Message_System";
		}
		return "ui://GvGChat/com_Message_System";
	}

	private void RenderMyChatRecord(GvGMode3ChatRecord record, GObject obj)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		if (record != null && obj is UI_com_Message_My uI_com_Message_My)
		{
			((GObject)uI_com_Message_My.Message).text = record.Message;
			((GObject)uI_com_Message_My.Time).text = DateTimeHelper.ParseMillisecondsTimeStamp(record.Timestamp).LocalDateTime.ToString("MM-dd HH:mm");
			uI_com_Message_My.Camp.selectedIndex = record.SenderCampId;
			uI_com_Message_My.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayChatRight>
			{
				CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
				UserId = record.SenderId,
				CampId = record.SenderCampId
			}, record.SenderId);
			((GObject)uI_com_Message_My.Message).onClickLink.Set(new EventCallback1(OnClickLink));
		}
	}

	private void RenderUserChatRecord(GvGMode3ChatRecord record, GObject obj)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		if (record != null && obj is UI_com_Message_User uI_com_Message_User)
		{
			((GObject)uI_com_Message_User.Message).text = record.Message;
			((GObject)uI_com_Message_User.Time).text = DateTimeHelper.ParseMillisecondsTimeStamp(record.Timestamp).LocalDateTime.ToString("MM-dd HH:mm");
			uI_com_Message_User.Camp.selectedIndex = record.SenderCampId;
			uI_com_Message_User.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayChatLeft>
			{
				CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
				UserId = record.SenderId,
				CampId = record.SenderCampId
			}, record.SenderId);
			((GObject)uI_com_Message_User.Message).onClickLink.Set(new EventCallback1(OnClickLink));
		}
	}

	private void RenderSystemRecord(GvGMode3ChatRecord record, GObject obj)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		if (record != null && obj is UI_com_Message_System uI_com_Message_System)
		{
			((GObject)uI_com_Message_System.Message).text = record.Message;
			((GObject)uI_com_Message_System.Time).text = DateTimeHelper.ParseMillisecondsTimeStamp(record.Timestamp).LocalDateTime.ToString("MM-dd HH:mm");
			((GObject)uI_com_Message_System.Message).onClickLink.Set(new EventCallback1(OnClickLink));
		}
	}

	private void GetLastChannelMessages()
	{
		Singleton<GvG3MessageManager>.Instance.GetChannelMessages(SelectChannelIndex, -1L);
	}

	private void GetMoreChannelMessages()
	{
		OnPullDownStart();
		if (_channelChatRecords.Count <= 0)
		{
			OnPullDownEnd();
			return;
		}
		((GObject)ChatPages.Messages).touchable = false;
		long id = _channelChatRecords[0].Id;
		Singleton<GvG3MessageManager>.Instance.GetChannelMessages(SelectChannelIndex, id, delegate
		{
			((GObject)ChatPages.Messages).touchable = true;
		});
	}

	private void OnPullDownStart()
	{
		ScrollPane scrollPane = ((GComponent)ChatPages.Messages).scrollPane;
		ScrollPaneHeader scrollPaneHeader = (ScrollPaneHeader)(object)scrollPane.header;
		scrollPaneHeader.SetRefreshStatus(1);
		scrollPane.LockHeader(50);
	}

	private void OnPullDownEnd()
	{
		ScrollPane scrollPane = ((GComponent)ChatPages.Messages).scrollPane;
		ScrollPaneHeader scrollPaneHeader = (ScrollPaneHeader)(object)scrollPane.header;
		scrollPaneHeader.SetRefreshStatus(0);
		scrollPane.LockHeader(0);
	}

	private void UpdateChatRecords(ReceiveChannelMessages receive)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GObject)ChatPages.Messages).touchable = true;
		try
		{
			if (!CanInsertRecords(receive))
			{
				return;
			}
			int num = InsertRecords(receive);
			RenderChannelChatRecords();
			if (receive.StartId.HasValue && receive.StartId.Value != -1)
			{
				ChatPages.Messages.ScrollToView(num, false);
				if (num > 0)
				{
					((GObject)ChatPages.Messages).touchable = false;
					Timers.inst.Add(0.2f, 1, (TimerCallback)delegate
					{
						OnPullDownEnd();
						((GObject)ChatPages.Messages).touchable = true;
					});
				}
				else
				{
					OnPullDownEnd();
				}
			}
			else
			{
				ChatPages.Messages.ScrollToView(_channelChatRecords.Count - 1);
			}
		}
		catch (Exception)
		{
		}
	}

	private bool CanInsertRecords(ReceiveChannelMessages receive)
	{
		int channel = (int)receive.Channel;
		if (channel == 2)
		{
			return true;
		}
		if (SelectChannelIndex == channel)
		{
			return true;
		}
		return false;
	}

	private int InsertRecords(ReceiveChannelMessages receive)
	{
		if (receive.StartId.HasValue && receive.StartId.Value == -1)
		{
			_channelChatRecords.Clear();
			_recordIds.Clear();
		}
		List<GvGMode3ChatRecord> list = new List<GvGMode3ChatRecord>();
		for (int num = receive.ChatRecords.Count - 1; num >= 0; num--)
		{
			GvGMode3ChatRecord gvGMode3ChatRecord = receive.ChatRecords[num];
			if (!_recordIds.Contains(gvGMode3ChatRecord.Id))
			{
				list.Add(gvGMode3ChatRecord);
				_recordIds.Add(gvGMode3ChatRecord.Id);
			}
		}
		list.Sort(RecordSort);
		long? startId = receive.StartId;
		long? num2 = startId;
		if (num2.HasValue)
		{
			long valueOrDefault = num2.GetValueOrDefault();
			if (valueOrDefault != -1)
			{
				_channelChatRecords.InsertRange(0, list);
				goto IL_010a;
			}
		}
		_channelChatRecords.AddRange(list);
		goto IL_010a;
		IL_010a:
		return list.Count;
	}

	private int RecordSort(GvGMode3ChatRecord a, GvGMode3ChatRecord b)
	{
		if (a.Id > b.Id)
		{
			return 1;
		}
		return (a.Id < b.Id) ? (-1) : 0;
	}
}
