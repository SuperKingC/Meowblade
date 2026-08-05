using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGExpeditionHall;

public class UI_com_SignedRoomInfo : GComponent
{
	public Controller SignInPeriodState;

	public Controller ReadyState;

	public Controller IsEnoughUser;

	public Controller IsRoomStarted;

	public Controller Camp;

	public GTextField n122;

	public GTextField n123;

	public GImage n126;

	public GTextField UserCount;

	public GButton n129;

	public GImage n127;

	public GLoader CampIcon;

	public GTextField CampName;

	public GGroup n155;

	public GImage n134;

	public GImage n152;

	public GTextField n135;

	public GTextField n99;

	public GTextField n100;

	public GTextField n12;

	public UI_com_TipBubble TipBubble;

	public GImage n132;

	public GTextField CountDown;

	public GGroup Counter;

	public GGroup CountingGroup;

	public GImage n163;

	public GList MessageList;

	public GGroup MessageGroup;

	public GImage n161;

	public UI_dec_light01 n160;

	public GImage n159;

	public GMovieClip n162;

	public GImage n153;

	public GRichTextField n154;

	public UI_btn_SettlementInfo SettlementInfoBtn;

	public UI_com_SettlementBubble SettlementBubble;

	public GGroup SettlementGroup;

	public GGroup main;

	public const string URL = "ui://k19peou7u2yw1h";

	public static string Name = "UI_com_SignedRoomInfo";

	public bool IsInit = false;

	private readonly List<GvGMode3ChatRecord> _channelChatRecords = new List<GvGMode3ChatRecord>();

	private readonly HashSet<long> _recordIds = new HashSet<long>();

	public static string GetURL()
	{
		return "ui://k19peou7u2yw1h";
	}

	public static UI_com_SignedRoomInfo CreateInstance()
	{
		return (UI_com_SignedRoomInfo)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SignedRoomInfo");
	}

	public static UI_com_SignedRoomInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SignedRoomInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7u2yw1h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected O, but got Unknown
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SignInPeriodState = ((GComponent)this).GetController("SignInPeriodState");
		ReadyState = ((GComponent)this).GetController("ReadyState");
		IsEnoughUser = ((GComponent)this).GetController("IsEnoughUser");
		IsRoomStarted = ((GComponent)this).GetController("IsRoomStarted");
		Camp = ((GComponent)this).GetController("Camp");
		n122 = (GTextField)((GComponent)this).GetChild("n122");
		string id = "ui://k19peou7u2yw1h".Replace("ui://", "") + "-" + ((GObject)n122).id;
		((GObject)n122).text = LanguagesManager.GetDesc(id);
		n123 = (GTextField)((GComponent)this).GetChild("n123");
		string id2 = "ui://k19peou7u2yw1h".Replace("ui://", "") + "-" + ((GObject)n123).id;
		((GObject)n123).text = LanguagesManager.GetDesc(id2);
		n126 = (GImage)((GComponent)this).GetChild("n126");
		UserCount = (GTextField)((GComponent)this).GetChild("UserCount");
		n129 = (GButton)((GComponent)this).GetChild("n129");
		n127 = (GImage)((GComponent)this).GetChild("n127");
		CampIcon = (GLoader)((GComponent)this).GetChild("CampIcon");
		CampName = (GTextField)((GComponent)this).GetChild("CampName");
		n155 = (GGroup)((GComponent)this).GetChild("n155");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n135 = (GTextField)((GComponent)this).GetChild("n135");
		string id3 = "ui://k19peou7u2yw1h".Replace("ui://", "") + "-" + ((GObject)n135).id;
		((GObject)n135).text = LanguagesManager.GetDesc(id3);
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id4 = "ui://k19peou7u2yw1h".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id4);
		n100 = (GTextField)((GComponent)this).GetChild("n100");
		string id5 = "ui://k19peou7u2yw1h".Replace("ui://", "") + "-" + ((GObject)n100).id;
		((GObject)n100).text = LanguagesManager.GetDesc(id5);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id6 = "ui://k19peou7u2yw1h".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id6);
		TipBubble = (UI_com_TipBubble)(object)((GComponent)this).GetChild("TipBubble");
		n132 = (GImage)((GComponent)this).GetChild("n132");
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		Counter = (GGroup)((GComponent)this).GetChild("Counter");
		CountingGroup = (GGroup)((GComponent)this).GetChild("CountingGroup");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		MessageList = (GList)((GComponent)this).GetChild("MessageList");
		MessageGroup = (GGroup)((GComponent)this).GetChild("MessageGroup");
		n161 = (GImage)((GComponent)this).GetChild("n161");
		n160 = (UI_dec_light01)(object)((GComponent)this).GetChild("n160");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n162 = (GMovieClip)((GComponent)this).GetChild("n162");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n154 = (GRichTextField)((GComponent)this).GetChild("n154");
		string id7 = "ui://k19peou7u2yw1h".Replace("ui://", "") + "-" + ((GObject)n154).id;
		((GObject)n154).text = LanguagesManager.GetDesc(id7);
		SettlementInfoBtn = (UI_btn_SettlementInfo)(object)((GComponent)this).GetChild("SettlementInfoBtn");
		SettlementBubble = (UI_com_SettlementBubble)(object)((GComponent)this).GetChild("SettlementBubble");
		SettlementGroup = (GGroup)((GComponent)this).GetChild("SettlementGroup");
		main = (GGroup)((GComponent)this).GetChild("main");
	}

	public void InitSystemMessage()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		if (!IsInit)
		{
			IsInit = true;
			MessageList.SetVirtual();
			MessageList.itemProvider = new ListItemProvider(GetChatRecordItemResource);
			MessageList.itemRenderer = new ListItemRenderer(RenderChatRecordItem);
			((GComponent)MessageList).scrollPane.onPullUpRelease.Set(new EventCallback0(GetMoreChannelMessages));
			GvG3MessageManager instance = Singleton<GvG3MessageManager>.Instance;
			instance.OnReceiveChannelMessagesAction = (Action<ReceiveChannelMessages>)Delegate.Combine(instance.OnReceiveChannelMessagesAction, new Action<ReceiveChannelMessages>(UpdateChatRecords));
			Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom(null, delegate
			{
				Singleton<GvG3MessageManager>.Instance.GetChannelMessages(2, -1L);
			});
		}
	}

	public void OnDestroy()
	{
		if (IsInit)
		{
			IsInit = false;
			_channelChatRecords.Clear();
			_recordIds.Clear();
			MessageList.numItems = 0;
			Singleton<GvGMode3RoomManager>.Instance.TryDelayDisconnectRoom();
			GvG3MessageManager instance = Singleton<GvG3MessageManager>.Instance;
			instance.OnReceiveChannelMessagesAction = (Action<ReceiveChannelMessages>)Delegate.Remove(instance.OnReceiveChannelMessagesAction, new Action<ReceiveChannelMessages>(UpdateChatRecords));
			((GComponent)MessageList).scrollPane.onPullUpRelease.Clear();
		}
	}

	private void GetMoreChannelMessages()
	{
		OnPullUpStart();
		if (_channelChatRecords.Count <= 0)
		{
			OnPullUpEnd();
			return;
		}
		long id = _channelChatRecords[0].Id;
		Singleton<GvG3MessageManager>.Instance.GetChannelMessages(2, id);
	}

	private void UpdateChatRecords(ReceiveChannelMessages receive)
	{
		try
		{
			InsertRecords(receive);
			Update();
			if (receive.StartId.HasValue && receive.StartId.Value != -1)
			{
				OnPullUpEnd();
				MessageList.ScrollToView(_channelChatRecords.Count - 1);
			}
			else
			{
				MessageList.ScrollToView(0);
			}
		}
		catch (Exception)
		{
		}
	}

	private void InsertRecords(ReceiveChannelMessages receive)
	{
		List<GvGMode3ChatRecord> list = new List<GvGMode3ChatRecord>();
		foreach (GvGMode3ChatRecord chatRecord in receive.ChatRecords)
		{
			if (!_recordIds.Contains(chatRecord.Id))
			{
				list.Insert(0, chatRecord);
				_recordIds.Add(chatRecord.Id);
			}
		}
		long? startId = receive.StartId;
		long? num = startId;
		if (!num.HasValue)
		{
			_channelChatRecords.InsertRange(0, list);
		}
		else
		{
			_channelChatRecords.AddRange(list);
		}
	}

	private void Update()
	{
		MessageList.numItems = _channelChatRecords.Count;
		((GObject)n163).visible = _channelChatRecords.Count <= 0;
	}

	private string GetChatRecordItemResource(int index)
	{
		GvGMode3ChatRecord gvGMode3ChatRecord = _channelChatRecords[index];
		if (gvGMode3ChatRecord.IsSystem)
		{
			return "ui://GvGExpeditionHall/com_Message_System";
		}
		return "ui://GvGExpeditionHall/com_Message_System";
	}

	private void RenderChatRecordItem(int index, GObject obj)
	{
		if (index < _channelChatRecords.Count)
		{
			GvGMode3ChatRecord gvGMode3ChatRecord = _channelChatRecords[index];
			if (gvGMode3ChatRecord.IsSystem)
			{
				RenderSystemRecord(gvGMode3ChatRecord, (UI_com_Message_System)(object)obj);
			}
		}
	}

	private void RenderSystemRecord(GvGMode3ChatRecord record, UI_com_Message_System slot)
	{
		if (record != null)
		{
			((GObject)slot.Message).text = record.Message;
			((GObject)slot.Time).text = DateTimeHelper.ParseMillisecondsTimeStamp(record.Timestamp).LocalDateTime.ToString("MM-dd HH:mm");
		}
	}

	private void OnPullUpStart()
	{
		ScrollPane scrollPane = ((GComponent)MessageList).scrollPane;
		ScrollPaneHeader scrollPaneHeader = (ScrollPaneHeader)(object)scrollPane.footer;
		scrollPaneHeader.SetRefreshStatus(2);
		scrollPane.LockHeader(50);
	}

	private void OnPullUpEnd()
	{
		ScrollPane scrollPane = ((GComponent)MessageList).scrollPane;
		ScrollPaneHeader scrollPaneHeader = (ScrollPaneHeader)(object)scrollPane.footer;
		scrollPaneHeader.SetRefreshStatus(0);
		scrollPane.LockHeader(0);
	}
}
