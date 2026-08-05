using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_IslandUserInfos : GComponent
{
	private enum UserEvent
	{
		PlayerCommand,
		ShareInfo
	}

	private class MessageCarousel
	{
		private readonly float _interval;

		public readonly GTextField TextField;

		private float MinX => 0f - ((GObject)TextField).width;

		private float MaxX => _interval + ((GObject)TextField).width;

		public MessageCarousel(GTextField textField, float interval)
		{
			TextField = textField;
			_interval = interval;
		}

		public void Move(float multiple)
		{
			if (((GObject)TextField).x <= MinX)
			{
				((GObject)TextField).x = MaxX;
				return;
			}
			GTextField textField = TextField;
			((GObject)textField).x = ((GObject)textField).x - 1f * multiple;
		}
	}

	public GList UserInfos;

	public const string URL = "ui://4eq8fgd2jxsods";

	public static string Name = "UI_com_IslandUserInfos";

	private readonly List<UserEvent> _userEvents = new List<UserEvent>();

	private IEvent_PlayerCommand _command;

	private IEvent_伟大航路 _event伟大航路;

	private MessageCarousel _firstMessage;

	private MessageCarousel _secondMessage;

	public static string GetURL()
	{
		return "ui://4eq8fgd2jxsods";
	}

	public static UI_com_IslandUserInfos CreateInstance()
	{
		return (UI_com_IslandUserInfos)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandUserInfos");
	}

	public static UI_com_IslandUserInfos CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandUserInfos).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2jxsods", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		UserInfos = (GList)((GComponent)this).GetChild("UserInfos");
	}

	public void OnClose()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		_command = null;
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdatePlayerCommand = (Action<IEvent_PlayerCommand>)Delegate.Remove(instance.UpdatePlayerCommand, new Action<IEvent_PlayerCommand>(UpdateCommand));
		if (Timers.inst.Exists(new TimerCallback(TimedUpdateCommand)))
		{
			Timers.inst.Remove(new TimerCallback(TimedUpdateCommand));
		}
		_firstMessage = null;
		_secondMessage = null;
		_event伟大航路 = null;
		GvG3EventMissionManager instance2 = Singleton<GvG3EventMissionManager>.Instance;
		instance2.Update伟大航路 = (Action<IEvent_伟大航路>)Delegate.Remove(instance2.Update伟大航路, new Action<IEvent_伟大航路>(UpdateShareInfo));
		_userEvents.Clear();
	}

	public void OnLoad()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		UserInfos.SetVirtual();
		UserInfos.itemProvider = new ListItemProvider(GetItemUrl);
		UserInfos.itemRenderer = new ListItemRenderer(RenderUserEvent);
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdatePlayerCommand = (Action<IEvent_PlayerCommand>)Delegate.Combine(instance.UpdatePlayerCommand, new Action<IEvent_PlayerCommand>(UpdateCommand));
		if (!Timers.inst.Exists(new TimerCallback(TimedUpdateCommand)))
		{
			Timers.inst.Add(0.03f, 0, new TimerCallback(TimedUpdateCommand));
		}
		GvG3EventMissionManager instance2 = Singleton<GvG3EventMissionManager>.Instance;
		instance2.Update伟大航路 = (Action<IEvent_伟大航路>)Delegate.Combine(instance2.Update伟大航路, new Action<IEvent_伟大航路>(UpdateShareInfo));
	}

	public void OnRender(IslandStateModel islandState)
	{
		UpdateCommand(islandState.PlayerCommand);
		UpdateShareInfo(islandState.Is伟大航路Shared ? islandState.Event_伟大航路 : null);
	}

	private string GetItemUrl(int index)
	{
		return _userEvents[index] switch
		{
			UserEvent.PlayerCommand => "ui://4eq8fgd2jxsodq", 
			UserEvent.ShareInfo => "ui://4eq8fgd2jxsodr", 
			_ => string.Empty, 
		};
	}

	private void RenderUserEvent(int index, GObject obj)
	{
		switch (_userEvents[index])
		{
		case UserEvent.PlayerCommand:
			RenderCommand(obj as UI_com_IslandCommand);
			break;
		case UserEvent.ShareInfo:
			RenderShareInfo(obj as UI_com_IslandShareInfo);
			break;
		}
	}

	private void UpdateEvents()
	{
		_userEvents.Sort();
		UserInfos.numItems = _userEvents.Count;
	}

	private void UpdateShareInfo(IEvent_伟大航路 event伟大航路)
	{
		_event伟大航路 = event伟大航路;
		if (_event伟大航路 != null)
		{
			if (!_userEvents.Contains(UserEvent.ShareInfo))
			{
				_userEvents.Add(UserEvent.ShareInfo);
			}
		}
		else if (_userEvents.Contains(UserEvent.ShareInfo))
		{
			_userEvents.Remove(UserEvent.ShareInfo);
		}
		UpdateEvents();
	}

	private void RenderShareInfo(UI_com_IslandShareInfo shareInfoUi)
	{
		shareInfoUi.Avatar.CampId.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", _event伟大航路.DiscoveredByUserId, delegate(UserProfile profile)
		{
			((GObject)shareInfoUi.UserName).text = profile.Name;
		}, delegate(Sprite sprite)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			shareInfoUi.Avatar.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
		}));
	}

	private void UpdateCommand(IEvent_PlayerCommand command)
	{
		_command = command;
		if (_command == null && _userEvents.Contains(UserEvent.PlayerCommand))
		{
			_userEvents.Remove(UserEvent.PlayerCommand);
		}
		if (_command != null && !_userEvents.Contains(UserEvent.PlayerCommand))
		{
			_userEvents.Add(UserEvent.PlayerCommand);
		}
		UpdateEvents();
	}

	private void RenderCommand(UI_com_IslandCommand commandUi)
	{
		commandUi.ProfileDisplay.RenderPlayerProfileGvG3(new PlayerProfileParams<UI_com_ProfileDisplayCommand>
		{
			CacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}",
			UserId = _command.UserId,
			CampId = _command.CampId
		}, _command.UserId);
		if (_firstMessage == null)
		{
			_firstMessage = new MessageCarousel(commandUi.Message.Text1, ((GObject)commandUi.Message).width);
		}
		if (_secondMessage == null)
		{
			_secondMessage = new MessageCarousel(commandUi.Message.Text2, ((GObject)commandUi.Message).width);
		}
		GTextField text = commandUi.Message.Text1;
		string text2 = (((GObject)commandUi.Message.Text2).text = _command.Msg);
		((GObject)text).text = text2;
		((GObject)_firstMessage.TextField).x = ((GObject)commandUi.Message).width;
		float num = ((GObject)commandUi.Message).width / 2f;
		((GObject)_secondMessage.TextField).x = ((GObject)_firstMessage.TextField).x + ((GObject)_firstMessage.TextField).width + num;
	}

	private void TimedUpdateCommand(object param)
	{
		if (!((GObject)this).isDisposed && _command != null && _firstMessage != null && _secondMessage != null)
		{
			_firstMessage.Move(3f);
			_secondMessage.Move(3f);
		}
	}
}
