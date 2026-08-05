using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

namespace UI.GvGShipPopup;

public class UI_main_BuildShipPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<SkeletonAnimation> _003C_003E9__19_0;

		public static ListItemRenderer _003C_003E9__24_0;

		internal void _003CUpdateShipSkin_003Eb__19_0(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "tuzhi", true);
		}

		internal void _003COnChangeTab_003Eb__24_0(int i, GObject o)
		{
			((UI_RaceTypeBig)(object)o).State.selectedIndex = 1;
		}
	}

	public GGraph back;

	public UI_BuildShipDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://pwrbvhpvoktw2z";

	public static string Name = "UI_main_BuildShipPanel";

	private Dictionary<int, int> BuildableShipType;

	private UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>> OnBuildStartedCallback;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private GoWrapper SpineGoWrapper;

	private bool IsShowingRaceListEffect = true;

	private eRace SelectedShipRace
	{
		get
		{
			if (Dialog.RaceList.selectedIndex == -1)
			{
				return eRace.Invalid;
			}
			UI_RaceTypeBig uI_RaceTypeBig = (UI_RaceTypeBig)(object)((GComponent)Dialog.RaceList).GetChildAt(Dialog.RaceList.selectedIndex);
			return uI_RaceTypeBig.icon.url.IconUrlToRace();
		}
	}

	public static string GetURL()
	{
		return "ui://pwrbvhpvoktw2z";
	}

	public static UI_main_BuildShipPanel CreateInstance()
	{
		return (UI_main_BuildShipPanel)(object)UIPackage.CreateObject("GvGShipPopup", "main_BuildShipPanel");
	}

	public static UI_main_BuildShipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BuildShipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvoktw2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_BuildShipDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		BuildableShipType = (parameters.TryGetValue("BuildableShipType", out var value) ? ((Dictionary<int, int>)value) : null);
		OnBuildStartedCallback = (parameters.TryGetValue("OnBuildStarted", out var value2) ? ((UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>)value2) : null);
		IsShowingRaceListEffect = true;
		ShipAnimCacheManager = new ShipAnimCacheManager();
		SpineGoWrapper = new GoWrapper();
		Dialog.SpineLoader.SetNativeObject((DisplayObject)(object)SpineGoWrapper);
		Dialog.RaceList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RaceTabRenderer((UI_RaceTypeBig)(object)o);
		};
		Dialog.RaceList.numItems = Dialog.RaceList.numItems;
		CheckForAnyRace();
		OnChangeTab();
	}

	private void CheckForAnyRace()
	{
		if ("I67506".IsActive())
		{
			return;
		}
		for (int num = ((GComponent)Dialog.RaceList).numChildren - 1; num >= 0; num--)
		{
			UI_RaceTypeBig uI_RaceTypeBig = (UI_RaceTypeBig)(object)((GComponent)Dialog.RaceList).GetChildAt(num);
			if (eRace.全种族 == uI_RaceTypeBig.icon.url.IconUrlToRace())
			{
				((GComponent)Dialog.RaceList).RemoveChildAt(num);
				break;
			}
		}
	}

	private void RaceTabRenderer(UI_RaceTypeBig item)
	{
		int key = (int)item.icon.url.IconUrlToRace();
		BuildableShipType.TryGetValue(key, out var value);
		bool flag = value == 0;
		item.IsNotAvailable.selectedIndex = (flag ? 1 : 0);
		item.State.selectedIndex = (flag ? 1 : 0);
	}

	private void UpdateShipSkin(int type)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(type);
		if ((Object)(object)SpineGoWrapper.wrapTarget != (Object)null)
		{
			SpineGoWrapper.wrapTarget.SetActive(false);
		}
		SpineGoWrapper.wrapTarget = ShipAnimCacheManager.GetCache(type.ToString(), byShipRaceType.DefaultSkinId, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "tuzhi", true);
		});
		SpineGoWrapper.wrapTarget.SetActive(true);
		SpineGoWrapper.wrapTarget.transform.localScale = new Vector3(80f, 80f, 80f);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBuildBtn).onClick.Set(new EventCallback1(OnOpenBuildConfirmPanel));
		((GObject)Dialog.CloseBtn).onClick.Set(new EventCallback0(End));
		Dialog.RaceList.onClickItem.Set(new EventCallback0(OnChangeTab));
		((GObject)back).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ConfirmBuildBtn).onClick.Clear();
		((GObject)Dialog.CloseBtn).onClick.Clear();
		Dialog.RaceList.onClickItem.Clear();
		((GObject)back).onClick.Clear();
	}

	private void OnOpenBuildConfirmPanel(EventContext context)
	{
		int selectedShipRace = (int)SelectedShipRace;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuildConfirmPanel.Name, new Dictionary<string, object>
		{
			{
				"BuildType",
				eShipBuildType.Building
			},
			{ "ShipType", selectedShipRace },
			{
				"OnConfirm",
				new UICallbackParam<Action<UI_main_BuildConfirmPanel.BuildParam>>(OnConfirmBuild)
			}
		});
	}

	private void OnConfirmBuild(UI_main_BuildConfirmPanel.BuildParam buildParam)
	{
		Singleton<GvGMode3RoomManager>.Instance.BuildShip(buildParam.ShipRace, buildParam.CurWorkerCount, buildParam.FastBuild, delegate
		{
			OnBuildStartedCallback?.Callback?.Invoke(buildParam);
			End();
		});
	}

	private void OnChangeTab()
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		eRace selectedShipRace = SelectedShipRace;
		int num = (int)selectedShipRace;
		BuildableShipType.TryGetValue(num, out var value);
		if (selectedShipRace == eRace.Invalid)
		{
			value = 0;
		}
		Dialog.IsNotAvailable.selectedIndex = ((value == 0) ? 1 : 0);
		((GObject)Dialog.AvailableCount).text = $"{value}/{1}";
		if (selectedShipRace == eRace.Invalid)
		{
			((DisplayObject)SpineGoWrapper).visible = false;
			Dialog.State.selectedIndex = 0;
			return;
		}
		((DisplayObject)SpineGoWrapper).visible = true;
		Dialog.State.selectedIndex = 1;
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(num);
		((GObject)Dialog.RaceName.Title).text = byShipRaceType.DefaultName;
		Dialog.ShipRaceInfo.RaceIcon.url = selectedShipRace.ToRaceIconUrl();
		((GObject)Dialog.ShipRaceInfo.Info).text = byShipRaceType.RaceInfo_LangId.ToLanguage();
		UpdateShipSkin(num);
		if (!IsShowingRaceListEffect)
		{
			return;
		}
		IsShowingRaceListEffect = false;
		GList raceList = Dialog.RaceList;
		object obj = _003C_003Ec._003C_003E9__24_0;
		if (obj == null)
		{
			ListItemRenderer val = delegate(int i, GObject o)
			{
				((UI_RaceTypeBig)(object)o).State.selectedIndex = 1;
			};
			_003C_003Ec._003C_003E9__24_0 = val;
			obj = (object)val;
		}
		raceList.itemRenderer = (ListItemRenderer)obj;
		Dialog.RaceList.numItems = Dialog.RaceList.numItems;
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnDestroy()
	{
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		ShipAnimCacheManager?.ClearCache();
	}

	public void Destroy()
	{
	}
}
