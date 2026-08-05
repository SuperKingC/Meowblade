using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Helper.ClickSimulator;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace UI.MilitaryAFKAssistant;

public class UI_main_PvpRankAFKAssistant : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static TweenCallback _003C_003E9__27_2;

		public static Action<Exception> _003C_003E9__28_1;

		internal void _003CEnd_003Eb__27_2()
		{
			UnityUiService.Instance.ClosePanel(Name);
		}

		internal void _003CLoadSpine_003Eb__28_1(Exception e)
		{
			ILRuntimeDebug.LogError(e.Message);
		}
	}

	public Controller onGoing;

	public GGraph mask;

	public GGraph clickMask;

	public UI_com_08 workingBar;

	public GGraph SpineWrapper;

	public GLoader SpineClickMask;

	public const string URL = "ui://8x5gc8j2msbrv4vk";

	public static string Name = "UI_main_PvpRankAFKAssistant";

	public bool IsQuitting;

	private Coroutine _autoBattle;

	private PvpRankClickStep _runningStep;

	private Tweener _closeTween;

	private SkeletonAnimation _goblinPlayingGameAnimation;

	private SkeletonAnimation goblinPlayingGameAnimation
	{
		get
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			if ((Object)(object)_goblinPlayingGameAnimation == (Object)null)
			{
				GameObject val = Object.Instantiate<GameObject>(Resources.Load<GameObject>("SpineTest"));
				_goblinPlayingGameAnimation = val.GetComponent<SkeletonAnimation>();
				val.transform.localScale = new Vector3(100f, 100f, 100f);
				val.transform.localPosition = -new Vector3(0f, 0f, 0f);
				val.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
				GoWrapper val2 = new GoWrapper(val);
				((DisplayObject)val2).SetXY(0f, 0f);
				((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
				((DisplayObject)val2).scaleX = 1f;
				((DisplayObject)val2).scaleY = 1f;
				SpineWrapper.SetNativeObject((DisplayObject)(object)val2);
			}
			return _goblinPlayingGameAnimation;
		}
	}

	public static string GetURL()
	{
		return "ui://8x5gc8j2msbrv4vk";
	}

	public static UI_main_PvpRankAFKAssistant CreateInstance()
	{
		return (UI_main_PvpRankAFKAssistant)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "main_PvpRankAFKAssistant");
	}

	public static UI_main_PvpRankAFKAssistant CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_PvpRankAFKAssistant).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2msbrv4vk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		onGoing = ((GComponent)this).GetController("onGoing");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		clickMask = (GGraph)((GComponent)this).GetChild("clickMask");
		workingBar = (UI_com_08)(object)((GComponent)this).GetChild("workingBar");
		SpineWrapper = (GGraph)((GComponent)this).GetChild("SpineWrapper");
		SpineClickMask = (GLoader)((GComponent)this).GetChild("SpineClickMask");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)SpineClickMask).onClick.Set(new EventCallback0(OnClickStop));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)SpineClickMask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)mask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		_runningStep = new PvpRankClickStep(this);
		ClickSimulatorScript clickSimulatorScript = new ClickSimulatorScript();
		clickSimulatorScript.CurrentStep = _runningStep;
		onGoing.SetSelectedIndex(1);
		workingBar.Status.SetSelectedIndex(0);
		_autoBattle = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(clickSimulatorScript.Run());
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

	private void OnClickStop()
	{
		if (!IsQuitting)
		{
			string desc = LanguagesManager.GetDesc("DoubleConfirmClosePvpClickAssistant");
			desc.ToConfirmPopup(StartQuitProcess, null, (AlignType)1);
		}
	}

	private void StartQuitProcess()
	{
		IsQuitting = true;
		workingBar.Status.SetSelectedIndex(1);
		_runningStep.TryEndDirectly();
	}

	public void End()
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		IsQuitting = true;
		if (_closeTween != null)
		{
			return;
		}
		if (_autoBattle != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_autoBattle);
		}
		float alpha = 1f;
		_closeTween = (Tweener)(object)TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => alpha), (DOSetter<float>)delegate(float x)
		{
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			alpha = x;
			((GObject)this).alpha = alpha;
			SkeletonAnimation obj2 = _goblinPlayingGameAnimation;
			if (obj2 != null)
			{
				Skeleton skeleton = ((SkeletonRenderer)obj2).skeleton;
				if (skeleton != null)
				{
					SkeletonExtensions.SetColor(skeleton, new Color(1f, 1f, 1f, alpha));
				}
			}
		}, 0f, 0.2f), (Ease)1);
		Tweener closeTween = _closeTween;
		object obj = _003C_003Ec._003C_003E9__27_2;
		if (obj == null)
		{
			TweenCallback val = delegate
			{
				UnityUiService.Instance.ClosePanel(Name);
			};
			_003C_003Ec._003C_003E9__27_2 = val;
			obj = (object)val;
		}
		TweenSettingsExtensions.OnComplete<Tweener>(closeTween, (TweenCallback)obj);
	}

	public void LoadSpine()
	{
		string model = "GoblinPlayGame";
		SpawnManager.Instance.LoadAnimation(model).Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				((SkeletonRenderer)goblinPlayingGameAnimation).skeletonDataAsset = asset;
				((SkeletonRenderer)goblinPlayingGameAnimation).Initialize(true);
				SpineHelper.SetSkin((ISkeletonAnimation)(object)goblinPlayingGameAnimation, "skin1");
				goblinPlayingGameAnimation.AnimationState.AddAnimation(0, "appear", false, 0f);
				goblinPlayingGameAnimation.AnimationState.AddAnimation(0, "idle", true, 0f);
				goblinPlayingGameAnimation.timeScale = 1f;
				goblinPlayingGameAnimation.loop = true;
			}
		}).Catch((Action<Exception>)delegate(Exception e)
		{
			ILRuntimeDebug.LogError(e.Message);
		});
	}
}
