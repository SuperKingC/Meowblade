using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace UI.GvGLoading;

public class UI_main_GvGLoading2Panel : GComponent, IUiController
{
	public enum eLoadingType
	{
		Enter,
		Exit
	}

	public GGraph back;

	public GGraph BGSpineLoader;

	public GGraph ShipSpineLoader;

	public GGraph FGSpineLoader;

	public const string URL = "ui://wvi1oqrwl8w00";

	public static string Name = "UI_main_GvGLoading2Panel";

	private const string BG_INSTANCE = "BG_INSTANCE";

	private const string SHIP_INSTANCE = "SHIP_INSTANCE";

	private const string FG_INSTANCE = "FG_INSTANCE";

	private const string FBG_ANIM_FILE = "QiFei_JiaZai";

	private static ShipAnimCacheManager ShipAnimCacheManager;

	private UICallbackParam<Action> OnShowCallback;

	private Action LoadCompleteRenderFunc;

	private eRace CurShipRace;

	private TrackEntry LoadingTrack;

	private float LoadingSingleLoopDuration;

	public static string GetURL()
	{
		return "ui://wvi1oqrwl8w00";
	}

	public static UI_main_GvGLoading2Panel CreateInstance()
	{
		return (UI_main_GvGLoading2Panel)(object)UIPackage.CreateObject("GvGLoading", "main_GvGLoading2Panel");
	}

	public static UI_main_GvGLoading2Panel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGLoading2Panel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://wvi1oqrwl8w00", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		BGSpineLoader = (GGraph)((GComponent)this).GetChild("BGSpineLoader");
		ShipSpineLoader = (GGraph)((GComponent)this).GetChild("ShipSpineLoader");
		FGSpineLoader = (GGraph)((GComponent)this).GetChild("FGSpineLoader");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters == null || !parameters.TryGetValue("Type", out var value))
		{
			ILRuntimeDebug.LogError("[UI_main_GvGLoading2Panel] 缺少Type参数");
			return;
		}
		if (parameters.TryGetValue("OnShow", out var value2))
		{
			OnShowCallback = (UICallbackParam<Action>)value2;
		}
		CurShipRace = eRace.哥布林;
		if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships.Count != 0)
		{
			CurShipRace = (eRace)Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships[0].PermanentData.ShipRace;
		}
		if ((eLoadingType)value == eLoadingType.Enter)
		{
			RenderEnterAnim_Loading();
			LoadCompleteRenderFunc = RenderEnterAnim_LoadComplete;
		}
		else
		{
			RenderExitAnim_Loading();
			LoadCompleteRenderFunc = RenderExitAnim_LoadComplete;
		}
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(LoadingTimeOutCoroutine((eLoadingType)value));
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener("CLOSE_GVGLOADING_UI", OnLoadComplete);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener("CLOSE_GVGLOADING_UI", OnLoadComplete);
	}

	public void Destroy()
	{
		UnbindAnimFromLoader(BGSpineLoader);
		UnbindAnimFromLoader(ShipSpineLoader);
		UnbindAnimFromLoader(FGSpineLoader);
	}

	private void OnLoadComplete()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		float num = LoadingSingleLoopDuration - LoadingTrack.TrackTime % LoadingSingleLoopDuration;
		Timers.inst.Add(num, 1, (TimerCallback)delegate
		{
			LoadCompleteRenderFunc();
		});
	}

	private void RenderEnterAnim_Loading()
	{
		LoadAnim(CurShipRace, RenderBG, RenderShip, RenderFG);
		void RenderBG(SkeletonAnimation animation)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			BindAnimToLoader(BGSpineLoader, ((Component)animation).gameObject);
			((Component)animation).transform.localScale = Vector3.one * 100f;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			LoadingTrack = animation.AnimationState.SetAnimation(0, "QiFei_FeiXing_Xia", true);
			LoadingSingleLoopDuration = ((SkeletonRenderer)animation).Skeleton.Data.FindAnimation("QiFei_FeiXing_Xia").Duration;
			OnShowCallback?.Callback?.Invoke();
		}
		void RenderFG(SkeletonAnimation animation)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			BindAnimToLoader(FGSpineLoader, ((Component)animation).gameObject);
			((Component)animation).transform.localScale = Vector3.one * 100f;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "QiFei_FeiXing_Shang", true);
		}
		void RenderShip(SkeletonAnimation animation)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			BindAnimToLoader(ShipSpineLoader, ((Component)animation).gameObject);
			((Component)animation).transform.localScale = Vector3.one * 100f;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "QiFei_FeiXing", true);
		}
	}

	private void RenderEnterAnim_LoadComplete()
	{
		LoadAnim(CurShipRace, RenderBG, RenderShip, RenderFG);
		static void RenderBG(SkeletonAnimation animation)
		{
			string text = "QiFei_FeiChu_Xia";
			TrackEntry val = animation.AnimationState.SetAnimation(0, text, false);
			val.MixDuration = 0.15f;
		}
		void RenderFG(SkeletonAnimation animation)
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			string text = "QiFei_FeiChu_Shang";
			TrackEntry val = animation.AnimationState.SetAnimation(0, text, false);
			val.MixDuration = 0.15f;
			float duration = ((SkeletonRenderer)animation).Skeleton.Data.FindAnimation(text).Duration;
			Timers.inst.Add(duration, 1, (TimerCallback)delegate
			{
				End();
			});
		}
		static void RenderShip(SkeletonAnimation animation)
		{
			string text = "QiFei_FeiChu";
			TrackEntry val = animation.AnimationState.SetAnimation(0, text, false);
			val.MixDuration = 0.15f;
		}
	}

	private void RenderExitAnim_Loading()
	{
		LoadAnim(CurShipRace, RenderBG, RenderShip, RenderFG);
		void RenderBG(SkeletonAnimation animation)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			BindAnimToLoader(BGSpineLoader, ((Component)animation).gameObject);
			((Component)animation).transform.localScale = Vector3.one * 100f;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			LoadingTrack = animation.AnimationState.SetAnimation(0, "LuoXia_FeiXing_Xia", true);
			LoadingSingleLoopDuration = ((SkeletonRenderer)animation).Skeleton.Data.FindAnimation("LuoXia_FeiXing_Xia").Duration;
			Timers.inst.Add(LoadingSingleLoopDuration, 1, (TimerCallback)delegate
			{
				OnShowCallback?.Callback?.Invoke();
			});
		}
		void RenderFG(SkeletonAnimation animation)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			BindAnimToLoader(FGSpineLoader, ((Component)animation).gameObject);
			((Component)animation).transform.localScale = Vector3.one * 100f;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "LuoXia_FeiXing_Shang", true);
		}
		void RenderShip(SkeletonAnimation animation)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			BindAnimToLoader(ShipSpineLoader, ((Component)animation).gameObject);
			((Component)animation).transform.localScale = Vector3.one * 100f;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "LuoXia_FeiXing", true);
		}
	}

	private void RenderExitAnim_LoadComplete()
	{
		LoadAnim(CurShipRace, RenderBG, RenderShip, RenderFG);
		void RenderBG(SkeletonAnimation animation)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			string text = "LuoXia_FeiChu_Xia";
			TrackEntry val = animation.AnimationState.SetAnimation(0, text, false);
			float duration = ((SkeletonRenderer)animation).Skeleton.Data.FindAnimation(text).Duration;
			Timers.inst.Add(duration, 1, (TimerCallback)delegate
			{
				End();
			});
		}
		static void RenderFG(SkeletonAnimation animation)
		{
			string text = "LuoXia_FeiChu_Shang";
			TrackEntry val = animation.AnimationState.SetAnimation(0, text, false);
		}
		static void RenderShip(SkeletonAnimation animation)
		{
			string text = "LuoXia_FeiChu";
			TrackEntry val = animation.AnimationState.SetAnimation(0, text, false);
		}
	}

	public static void PreLoadAnim(eRace shipRace = eRace.哥布林)
	{
		if (ShipAnimCacheManager == null)
		{
			LoadAnim(shipRace, delegate(SkeletonAnimation animation)
			{
				((Object)animation).name = "GvGLoadingBG";
				((Component)animation).gameObject.SetActive(false);
			}, delegate(SkeletonAnimation animation)
			{
				((Object)animation).name = "GvGLoadingShip";
				((Component)animation).gameObject.SetActive(false);
			}, delegate(SkeletonAnimation animation)
			{
				((Object)animation).name = "GvGLoadingFG";
				((Component)animation).gameObject.SetActive(false);
			});
		}
	}

	public static void Open(eLoadingType type, Action onShow)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
		{
			{ "Type", type },
			{
				"OnShow",
				new UICallbackParam<Action>(onShow)
			}
		});
	}

	private static void LoadAnim(eRace shipRace = eRace.哥布林, Action<SkeletonAnimation> onLoadBG = null, Action<SkeletonAnimation> onLoadShip = null, Action<SkeletonAnimation> onLoadFG = null)
	{
		if (ShipAnimCacheManager == null)
		{
			ShipAnimCacheManager = new ShipAnimCacheManager();
		}
		ShipAnimCacheManager.GetCache("BG_INSTANCE", "QiFei_JiaZai", onLoadBG, isMask: false, onLoadBG);
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType((int)shipRace);
		ShipAnimCacheManager.GetCache("SHIP_INSTANCE", byShipRaceType.DefaultSkinId, onLoadShip, isMask: false, isSimpleSpine: false, onLoadShip);
		ShipAnimCacheManager.GetCache("FG_INSTANCE", "QiFei_JiaZai", onLoadFG, isMask: false, onLoadFG);
	}

	private void BindAnimToLoader(GGraph spineLoader, GameObject animGameObject)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		animGameObject.SetActive(true);
		GoWrapper val = new GoWrapper(animGameObject)
		{
			supportStencil = true
		};
		spineLoader.SetNativeObject((DisplayObject)(object)val);
		((GObject)spineLoader).data = val;
	}

	private void UnbindAnimFromLoader(GGraph spineLoader)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GoWrapper val = (GoWrapper)((GObject)spineLoader).data;
		val.wrapTarget.SetActive(false);
		val.wrapTarget = null;
	}

	private IEnumerator LoadingTimeOutCoroutine(eLoadingType type)
	{
		yield return (object)new WaitForSeconds(120f);
		if (!((GObject)this).isDisposed)
		{
			ILRuntimeDebug.LogError($"[UI_main_GvGLoading2Panel] {type} time out for 2 min");
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		Singleton<GvGMode3RoomManager>.Instance.StopwatchStop();
	}

	public void BeforeDestroy()
	{
	}

	public void OnShow()
	{
	}
}
