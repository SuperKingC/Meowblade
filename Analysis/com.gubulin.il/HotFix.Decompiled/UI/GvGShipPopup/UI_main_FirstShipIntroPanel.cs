using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Spine.Unity;
using UI.GvGChangeShipName;
using UnityEngine;

namespace UI.GvGShipPopup;

public class UI_main_FirstShipIntroPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_com_FirstShipIntroDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://pwrbvhpvazac6o";

	public static string Name = "UI_main_FirstShipIntroPanel";

	private UICallbackParam<Action<string>> OnDestroyShipCallback;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private GvGMode3ShipModel CurShip;

	private string ShipId;

	private bool HasEnterIZ;

	public static string GetURL()
	{
		return "ui://pwrbvhpvazac6o";
	}

	public static UI_main_FirstShipIntroPanel CreateInstance()
	{
		return (UI_main_FirstShipIntroPanel)(object)UIPackage.CreateObject("GvGShipPopup", "main_FirstShipIntroPanel");
	}

	public static UI_main_FirstShipIntroPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FirstShipIntroPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvazac6o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_FirstShipIntroDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ShipId = (parameters.TryGetValue("ShipId", out var value) ? value.ToString() : null);
		OnDestroyShipCallback = (parameters.TryGetValue("OnDestroyShip", out var value2) ? ((UICallbackParam<Action<string>>)value2) : null);
		if (ShipId == null)
		{
			ILRuntimeDebug.LogError("[UI_main_FirstShipIntroPanel] ShipId is null");
			End();
			return;
		}
		if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord == null || Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships == null || Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships.Count == 0)
		{
			ILRuntimeDebug.LogError("[UI_main_FirstShipIntroPanel] ObserverRecord 不存在或者没有飞空艇");
			End();
			return;
		}
		CurShip = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(ShipId);
		if (CurShip == null)
		{
			ILRuntimeDebug.LogError("[UI_main_FirstShipIntroPanel] ObserverRecord 中没找到飞空艇 ShipId=" + ShipId);
			End();
			return;
		}
		HasEnterIZ = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ;
		((GObject)Dialog.ShipName).text = CurShip.PermanentData.ShipName.ToRealShipName();
		InitShipAnimation();
		Dialog.HasEnterIZ.selectedIndex = (HasEnterIZ ? 1 : 0);
	}

	private void InitShipAnimation()
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		int num = 0;
		if (CurShip.PermanentData.IsJoinIZ && Singleton<GvGMode3RoomManager>.Instance.IsConnecting)
		{
			num = CurShip.TemporaryData.ShipSkinId;
		}
		else
		{
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(CurShip.PermanentData.ShipRace);
			num = byShipRaceType.DefaultSkinId;
		}
		ShipAnimCacheManager = new ShipAnimCacheManager();
		GameObject cache = ShipAnimCacheManager.GetCache("", num, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "dengdai", true);
		});
		cache.transform.localScale = new Vector3(60f, 60f, 60f);
		GoWrapper val = new GoWrapper(cache);
		val.supportStencil = true;
		Dialog.SpineLoader.SetNativeObject((DisplayObject)(object)val);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.DestroyShipBtn).onClick.Set(new EventCallback0(OnOpenDestroyShipPopup));
		((GObject)Dialog.ChangeNameBtn).onClick.Set(new EventCallback0(OnOpenChangeShipNamePanel));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.DestroyShipBtn).onClick.Clear();
		((GObject)Dialog.ChangeNameBtn).onClick.Clear();
	}

	private void OnOpenDestroyShipPopup()
	{
		if (HasEnterIZ)
		{
			"GvGFirstShipIntroTips".ToShowLanguageTip();
		}
		else
		{
			Singleton<GvGMode3RoomManager>.Instance.CheckShipIsNotInsurance(CurShip.ShipId, DisplayWarning);
		}
		void DisplayWarning()
		{
			HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("GvGShipDestroyWarning".ToLanguage(), CurShip.PermanentData.ShipName.ToRealShipName()).ToConfirmPopup(delegate
			{
				OnConfimDestroyShip();
			}, null, (AlignType)1, 44);
		}
	}

	private void OnConfimDestroyShip()
	{
		Singleton<GvGMode3RoomManager>.Instance.DestroyShip(ShipId, delegate
		{
			OnDestroyShipCallback?.Callback?.Invoke(ShipId);
			End();
		});
	}

	private void OnOpenChangeShipNamePanel()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "ShipId", CurShip.ShipId },
			{
				"OnConfirm",
				new UICallbackParam<Action<string>>(OnConfirmChangeName)
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGChangeShipNamePanel.Name, parameters);
	}

	private void OnConfirmChangeName(string newName)
	{
		((GObject)Dialog.ShipName).text = CurShip.PermanentData.ShipName.ToRealShipName();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
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
