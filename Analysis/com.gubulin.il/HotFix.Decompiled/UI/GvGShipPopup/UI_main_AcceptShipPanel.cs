using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UnityEngine;

namespace UI.GvGShipPopup;

public class UI_main_AcceptShipPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_AcceptShipDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://pwrbvhpvnbpu41";

	public static string Name = "UI_main_AcceptShipPanel";

	private UICallbackParam<Action<string>> OnAcceptCallback;

	private List<GvGShipDetailModel> Ships;

	private HashSet<string> WaitToAcceptShips;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private GoWrapper SpineGoWrapper;

	private int CurAcceptCount;

	private GvGShipDetailModel CurTargetShip;

	private SkeletonAnimation CurAnimation;

	private bool UseObserverData = false;

	private bool IsFGAnimStarted = false;

	public static string GetURL()
	{
		return "ui://pwrbvhpvnbpu41";
	}

	public static UI_main_AcceptShipPanel CreateInstance()
	{
		return (UI_main_AcceptShipPanel)(object)UIPackage.CreateObject("GvGShipPopup", "main_AcceptShipPanel");
	}

	public static UI_main_AcceptShipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_AcceptShipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvnbpu41", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_AcceptShipDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		OnAcceptCallback = (parameters.TryGetValue("OnAccept", out var value) ? ((UICallbackParam<Action<string>>)value) : null);
		if (parameters.TryGetValue("Ships", out var value2))
		{
			Ships = (List<GvGShipDetailModel>)value2;
		}
		else
		{
			UseObserverData = true;
		}
		WaitToAcceptShips = new HashSet<string>();
		ShipAnimCacheManager = new ShipAnimCacheManager();
		SpineGoWrapper = new GoWrapper();
		Dialog.Content.SpineLoader.SetNativeObject((DisplayObject)(object)SpineGoWrapper);
		InitFGAnimation();
		InitFG2Animation();
		((GObject)Dialog.ConfirmAcceptBtn).visible = false;
		((GObject)Dialog.ConfirmAcceptBtn).touchable = false;
		CurAcceptCount = 0;
		RefreshData();
		Update();
		UpdateAcceptCount();
		Timers.inst.Add(0.5f, 0, new TimerCallback(UpdateAcceptCount));
	}

	private void InitFGAnimation()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		GameObject cache = ShipAnimCacheManager.GetCache("FG", "AcceptShipPanel", delegate(SkeletonAnimation animation)
		{
			if (!((GObject)this).isDisposed)
			{
				string text = "huishou";
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
				animation.AnimationState.AddAnimation(0, text, true, 0f);
			}
		});
		GoWrapper nativeObject = new GoWrapper(cache)
		{
			supportStencil = true
		};
		Dialog.Content.FGSpineLoader.SetNativeObject((DisplayObject)(object)nativeObject);
	}

	private void InitFG2Animation()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		GameObject cache = ShipAnimCacheManager.GetCache("FG2", "AcceptShipPanel");
		GoWrapper nativeObject = new GoWrapper(cache)
		{
			supportStencil = true
		};
		Dialog.Content.FGSpineLoader2.SetNativeObject((DisplayObject)(object)nativeObject);
	}

	private void RefreshData()
	{
		if (UseObserverData)
		{
			Ships = new List<GvGShipDetailModel>();
			foreach (GvGMode3ShipModel ship in Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships)
			{
				GvGShipDetailModel gvGShipDetailModel = new GvGShipDetailModel();
				gvGShipDetailModel.SetRecordData(ship);
				Ships.Add(gvGShipDetailModel);
			}
		}
		CurTargetShip = Ships.Find((GvGShipDetailModel item) => item.ShipBuildState == eShipBuildState.PendingAcceptance);
	}

	private void Update()
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		((GObject)Dialog.ConfirmAcceptBtn).visible = false;
		((GObject)Dialog.ConfirmAcceptBtn).touchable = false;
		UpdateRandomText();
		RenderHelper_RaceTypeIcon.RenderShipRaceType((GComponent)(object)Dialog.Content.ShipRace, (eRace)CurTargetShip.ShipType);
		if ((Object)(object)SpineGoWrapper.wrapTarget != (Object)null)
		{
			SpineGoWrapper.wrapTarget.SetActive(false);
		}
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(CurTargetShip.ShipType);
		SpineGoWrapper.wrapTarget = ShipAnimCacheManager.GetCache("", byShipRaceType.DefaultSkinId, delegate(SkeletonAnimation animation)
		{
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			CurAnimation = animation;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)CurAnimation, "skin1");
			animation.AnimationState.SetAnimation(0, "dengdai", true);
			((Component)animation).transform.localScale = new Vector3(75f, 75f, 75f);
		}, isMask: true);
		SpineGoWrapper.wrapTarget.SetActive(true);
		Dialog.Content.ShowShip.Play((PlayCompleteCallback)delegate
		{
			((GObject)Dialog.ConfirmAcceptBtn).visible = true;
			((GObject)Dialog.ConfirmAcceptBtn).touchable = true;
			if (!IsFGAnimStarted)
			{
				IsFGAnimStarted = true;
				ShipAnimCacheManager.GetCache("FG2", "AcceptShipPanel", null, isMask: false, delegate(SkeletonAnimation animation)
				{
					if (!((GObject)this).isDisposed)
					{
						string text = "piaodai_start";
						SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
						animation.AnimationState.AddAnimation(1, text, false, 0f);
						float duration = ((SkeletonRenderer)animation).Skeleton.Data.FindAnimation(text).Duration;
						animation.AnimationState.AddAnimation(1, "piaodai_circulate", true, duration);
					}
				});
			}
		});
	}

	private void UpdateAcceptCount(object param = null)
	{
		if (UseObserverData)
		{
			foreach (GvGMode3ShipModel ship in Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships)
			{
				eShipBuildState shipBuildState = (eShipBuildState)ship.PermanentData.ShipBuildState;
				if ((shipBuildState == eShipBuildState.Building || shipBuildState == eShipBuildState.Rebuilding) && ship.PermanentData.TargetBuildCompleteTime <= (int)GameController.Instance.GetServerTime())
				{
					WaitToAcceptShips.Add(ship.ShipId);
				}
			}
		}
		else
		{
			foreach (GvGShipDetailModel ship2 in Ships)
			{
				if (ship2.ShipBuildState == eShipBuildState.PendingAcceptance)
				{
					WaitToAcceptShips.Add(ship2.ShipId);
				}
			}
		}
		((GObject)Dialog.Count).text = $"{CurAcceptCount}/{WaitToAcceptShips.Count}";
	}

	private void UpdateRandomText()
	{
		List<string> list = "GVGSHIP_ACCEPT_TEXT_LANG".ToConfiguration<List<string>>();
		string langKey = ListExtensions.Random<string>(list);
		((GObject)Dialog.AcceptText).text = langKey.ToLanguage();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.ConfirmAcceptBtn).onClick.Set(new EventCallback1(OnAccept));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ConfirmAcceptBtn).onClick.Clear();
	}

	private void OnAccept(EventContext context)
	{
		((GObject)Dialog.ConfirmAcceptBtn).visible = false;
		((GObject)Dialog.ConfirmAcceptBtn).touchable = false;
		string shipId = CurTargetShip.ShipId;
		Singleton<GvGMode3RoomManager>.Instance.AcceptShip(shipId, delegate
		{
			CurAcceptCount++;
			RefreshData();
			UpdateAcceptCount();
			if (CurAcceptCount < WaitToAcceptShips.Count)
			{
				Update();
			}
			else
			{
				End();
			}
			OnAcceptCallback?.Callback?.Invoke(shipId);
		});
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
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		ShipAnimCacheManager?.ClearCache();
		Timers.inst.Remove(new TimerCallback(UpdateAcceptCount));
	}

	public void Destroy()
	{
	}
}
