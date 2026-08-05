using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_main_SharePopupPanel : GComponent, IUiController
{
	public enum eShareType
	{
		NormalIsland,
		HiddenIsland,
		ExtraCollectingGroup
	}

	public GGraph back;

	public UI_com_SharePopupDialog Dialog;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2614qf5";

	public static string Name = "UI_main_SharePopupPanel";

	private int IslandId;

	private UICallbackParam<Action<eShareType>> OnConfirm;

	private bool IsCheckerChecked
	{
		get
		{
			return ((GButton)Dialog.ShareInfoChecker.CheckBox).selected;
		}
		set
		{
			((GButton)Dialog.ShareInfoChecker.CheckBox).selected = value;
		}
	}

	private bool IsShowChecker => Dialog.IsShowChecker.selectedIndex == 1;

	private bool IsShareHiddenIsland => Dialog.ShareInfoChecker.ShareType.selectedIndex == 0;

	private bool IsShareCollectingGroup => Dialog.ShareInfoChecker.ShareType.selectedIndex == 2;

	public static string GetURL()
	{
		return "ui://4eq8fgd2614qf5";
	}

	public static UI_main_SharePopupPanel CreateInstance()
	{
		return (UI_main_SharePopupPanel)(object)UIPackage.CreateObject("GvGWorldMap3", "main_SharePopupPanel");
	}

	public static UI_main_SharePopupPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SharePopupPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2614qf5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_SharePopupDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		IslandId = (parameters.TryGetValue("IslandId", out var value) ? ((int)value) : (-1));
		OnConfirm = (parameters.TryGetValue("OnConfirm", out var value2) ? (value2 as UICallbackParam<Action<eShareType>>) : null);
		Render();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Set(new EventCallback0(OnClickConfirmBtn));
		((GObject)Dialog.ShareInfoChecker.CheckBox).onClick.Set(new EventCallback1(OnChangeCheckBox));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.ConfirmBtn).onClick.Clear();
		((GObject)Dialog.ShareInfoChecker.CheckBox).onClick.Clear();
	}

	private void Render()
	{
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(IslandId);
		IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(IslandId);
		bool isHiddenIsland = islandConfigData.IsHiddenIsland;
		bool flag = islandStateModel.Is伟大航路Active && !islandStateModel.Is伟大航路Shared;
		bool can额外发现Share = islandStateModel.can额外发现Share;
		((GObject)Dialog.Message).text = string.Format(((GObject)Dialog.Message).text, islandConfigData.Name);
		IsCheckerChecked = flag || can额外发现Share;
		Dialog.IsShowChecker.selectedIndex = ((IsCheckerChecked || isHiddenIsland) ? 1 : 0);
		if (isHiddenIsland)
		{
			if (flag)
			{
				Dialog.ShareInfoChecker.ShareType.selectedIndex = 0;
				int num = (int)"IslandShareContribution".ToConfiguration<float>();
				((GObject)Dialog.ShareInfoChecker.ContributionPoint).text = $"+{num}";
				return;
			}
			Dialog.ShareInfoChecker.ShareType.selectedIndex = 1;
			string cacheVersion = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";
			int discoveredByUserId = islandStateModel.Event_伟大航路.DiscoveredByUserId;
			int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			UI_com_ShipAvatarSmall avatarCom = Dialog.ShareInfoChecker.SharedByUserAvatar;
			avatarCom.CampId.selectedIndex = obCampId;
			GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(cacheVersion, discoveredByUserId, delegate(UserProfile profile)
			{
				((GObject)Dialog.ShareInfoChecker.SharedByUserName).text = profile.Name;
			}, delegate(Sprite sprite)
			{
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Expected O, but got Unknown
				avatarCom.HeadPortrait.icon.texture = new NTexture((Texture)(object)sprite.texture);
			}));
		}
		else if (can额外发现Share)
		{
			Dialog.ShareInfoChecker.ShareType.selectedIndex = 2;
			int num2 = (int)"CollectingGroupShareContribution".ToConfiguration<float>();
			((GObject)Dialog.ShareInfoChecker.ContributionPoint).text = $"+{num2}";
		}
	}

	private void OnChangeCheckBox(EventContext context)
	{
		if (IsShowChecker && IsShareHiddenIsland)
		{
			((GObject)Dialog.ConfirmBtn).enabled = IsCheckerChecked;
		}
		else
		{
			((GObject)Dialog.ConfirmBtn).enabled = true;
		}
	}

	private void OnClickConfirmBtn()
	{
		eShareType obj = eShareType.NormalIsland;
		if (IsShowChecker && IsCheckerChecked)
		{
			if (IsShareHiddenIsland)
			{
				obj = eShareType.HiddenIsland;
			}
			else if (IsShareCollectingGroup)
			{
				obj = eShareType.ExtraCollectingGroup;
			}
		}
		End();
		OnConfirm?.Callback?.Invoke(obj);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
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
}
