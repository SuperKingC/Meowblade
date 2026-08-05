using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.GvGChat;

namespace UI.GvGWorldMap3;

public class UI_btn_ShareIsland : GButton
{
	public Controller button;

	public Controller HasShareInfo;

	public GImage n3;

	public GTextField Countdown;

	public const string URL = "ui://4eq8fgd2v7j373";

	public static string Name = "UI_btn_ShareIsland";

	private IEvent_伟大航路 _event伟大航路;

	private int _islandId;

	public static string GetURL()
	{
		return "ui://4eq8fgd2v7j373";
	}

	public static UI_btn_ShareIsland CreateInstance()
	{
		return (UI_btn_ShareIsland)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_ShareIsland");
	}

	public static UI_btn_ShareIsland CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ShareIsland).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v7j373", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		HasShareInfo = ((GComponent)this).GetController("HasShareInfo");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
	}

	public void OnLoad()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClickShareIsland));
		if (!Timers.inst.Exists(new TimerCallback(TimedUpdateSharingTime)))
		{
			Timers.inst.Add(1f, 0, new TimerCallback(TimedUpdateSharingTime));
		}
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.Update伟大航路 = (Action<IEvent_伟大航路>)Delegate.Combine(instance.Update伟大航路, new Action<IEvent_伟大航路>(UpdateShareInfo));
	}

	public void OnClose()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.Update伟大航路 = (Action<IEvent_伟大航路>)Delegate.Remove(instance.Update伟大航路, new Action<IEvent_伟大航路>(UpdateShareInfo));
		if (Timers.inst.Exists(new TimerCallback(TimedUpdateSharingTime)))
		{
			Timers.inst.Remove(new TimerCallback(TimedUpdateSharingTime));
		}
		((GObject)this).onClick.Clear();
		_event伟大航路 = null;
	}

	public void OnRender(IslandStateModel islandState)
	{
		_islandId = islandState.IslandId;
		UpdateShareInfo(islandState.Is伟大航路Shared ? islandState.Event_伟大航路 : null);
	}

	private void UpdateShareInfo(IEvent_伟大航路 伟大航路)
	{
		_event伟大航路 = 伟大航路;
		HasShareInfo.SetSelectedIndex((_event伟大航路 != null) ? 1 : 0);
	}

	private void TimedUpdateSharingTime(object param)
	{
		if (!((GObject)this).isDisposed && _event伟大航路 != null)
		{
			int time = Math.Max(0, _event伟大航路.ExpireTimestamp - (int)GameController.Instance.GetServerTime());
			((GObject)Countdown).text = UiHelper.ParseTime(time);
		}
	}

	private void OnClickShareIsland()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_SharePopupPanel.Name, new Dictionary<string, object>
		{
			{ "IslandId", _islandId },
			{
				"OnConfirm",
				new UICallbackParam<Action<UI_main_SharePopupPanel.eShareType>>(OnConfirmShare)
			}
		});
		void OnConfirmShare(UI_main_SharePopupPanel.eShareType type)
		{
			switch (type)
			{
			case UI_main_SharePopupPanel.eShareType.NormalIsland:
				if (!UI_com_Chat.Instance.SendRichTextMessage(eChatUserTemplateType.Type1, new List<object> { _islandId }, eChatChannel.Camp))
				{
					"GvGChatCoolingDownTips".ToShowLanguageTip();
				}
				break;
			case UI_main_SharePopupPanel.eShareType.HiddenIsland:
				Singleton<WorldStateManager>.Instance.Share伟大航路DiscoveredIsland(_islandId);
				break;
			case UI_main_SharePopupPanel.eShareType.ExtraCollectingGroup:
				Singleton<WorldStateManager>.Instance.Share额外发现CollectingGroup(_islandId);
				break;
			}
		}
	}
}
