using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace UI.GvGOnIsland3;

public class UI_com_VictoryPopup : GComponent, IUiController
{
	public GGraph n4;

	public UI_com_VictoryPopupDialog Popup;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrs0diq7b";

	public static string Name = "UI_com_VictoryPopup";

	public const string WinCamp = "WinCamp";

	public const string WinUser = "WinUser";

	public const string ParentUi = "ParentUi";

	private UI_main_GvGIslandBrawlFight _parentUi;

	public static string GetURL()
	{
		return "ui://ebc4ciwrs0diq7b";
	}

	public static UI_com_VictoryPopup CreateInstance()
	{
		return (UI_com_VictoryPopup)(object)UIPackage.CreateObject("GvGOnIsland3", "com_VictoryPopup");
	}

	public static UI_com_VictoryPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_VictoryPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrs0diq7b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		Popup = (UI_com_VictoryPopupDialog)(object)((GComponent)this).GetChild("Popup");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Popup.ReplayBtn).onClick.Set(new EventCallback0(OnClickReplay));
		((GObject)Popup.ExitBtn).onClick.Set(new EventCallback0(OnClickExit));
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Combine(instance.OnRoomClose, new Action(ForceClose));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Popup.ReplayBtn).onClick.Clear();
		((GObject)Popup.ExitBtn).onClick.Clear();
		GvGMode3RoomManager instance = Singleton<GvGMode3RoomManager>.Instance;
		instance.OnRoomClose = (Action)Delegate.Remove(instance.OnRoomClose, new Action(ForceClose));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		object value;
		int num = (parameters.TryGetValue("WinCamp", out value) ? ((int)value) : 0);
		object value2;
		int userId = (parameters.TryGetValue("WinUser", out value2) ? ((int)value2) : 0);
		_parentUi = (UI_main_GvGIslandBrawlFight)parameters["ParentUi"];
		if (_parentUi.IsCampFight)
		{
			Popup.Type.SetSelectedIndex(1);
			UI_com_Camp uI_com_Camp = (UI_com_Camp)(object)Popup.Player.component;
			uI_com_Camp.CampId.SetSelectedIndex(num);
			((GObject)Popup.namePlayer).text = UI_main_GvGIslandBrawlFight.GetCampName(num);
			return;
		}
		Popup.Type.SetSelectedIndex(0);
		UI_com_Avatar avatar = (UI_com_Avatar)(object)Popup.Player.component;
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", userId, delegate(UserProfile profile)
		{
			((GObject)Popup.namePlayer).text = FGUIManager.Instance.TruncateTextLength(profile.Name, 14, string.Empty);
		}, delegate(Sprite sprite)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			avatar.HeadPortrait.icon.texture = new NTexture(sprite);
		}));
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}

	private void OnClickReplay()
	{
		End();
		_parentUi.OnClickJumpToSecond(0);
	}

	private void OnClickExit()
	{
		End();
		_parentUi.End();
	}

	private void ForceClose()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
