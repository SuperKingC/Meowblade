using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvG3SplitBluePrint;

public class UI_main_DisplaySplitEffect : GComponent, IUiController
{
	public UI_dec_light02 n3;

	public GImage Light;

	public GMovieClip n4;

	public GGroup n5;

	public Transition Split;

	public const string URL = "ui://7uylntmmnuv12";

	public static string Name = "UI_main_DisplaySplitEffect";

	private const string _HOOK_CLAIM = "Claim";

	private const string _HOOK_END = "End";

	private const string _TRANSITION = "t0";

	private const int _CLAIM_EFFECT_COUNT = 10;

	private Action _onPlayComplete;

	private Action _onStartSplit;

	private Vector2 _endPos;

	private Vector2 _startPointPos;

	private Vector2 StartPointPos
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			if (_startPointPos == default(Vector2))
			{
				_startPointPos = ((GObject)Light).LocalToRoot(Vector2.zero, GRoot.inst);
			}
			return _startPointPos;
		}
	}

	public static string GetURL()
	{
		return "ui://7uylntmmnuv12";
	}

	public static UI_main_DisplaySplitEffect CreateInstance()
	{
		return (UI_main_DisplaySplitEffect)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "main_DisplaySplitEffect");
	}

	public static UI_main_DisplaySplitEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_DisplaySplitEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmnuv12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (UI_dec_light02)(object)((GComponent)this).GetChild("n3");
		Light = (GImage)((GComponent)this).GetChild("Light");
		n4 = (GMovieClip)((GComponent)this).GetChild("n4");
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		Split = ((GComponent)this).GetTransition("Split");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_onPlayComplete = (parameters.TryGetValue("OnComplete", out var value) ? ((Action)value) : null);
		_onStartSplit = (parameters.TryGetValue("OnStartSplit", out var value2) ? ((Action)value2) : null);
		_endPos = (Vector2)(parameters.TryGetValue("EndPos", out var value3) ? ((Vector2)value3) : Vector2.zero);
	}

	public void OnShow()
	{
		PlaySplitTransition();
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void PlaySplitTransition()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		Split.SetHook("Claim", new TransitionHook(PlayClaimingEffect));
		Split.SetHook("End", new TransitionHook(InvokeComplete));
		Split.Play();
		_onStartSplit?.Invoke();
	}

	private void InvokeComplete()
	{
		_onPlayComplete?.Invoke();
	}

	private void PlayClaimingEffect()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		List<IRewardClaimingEffect> list = CreateClaimingEffects();
		foreach (IRewardClaimingEffect item in list)
		{
			float duration = Random.Range(0f, 0.5f);
			IRewardClaimingEffect effectLocal = item;
			((GComponent)(object)this).SetTimeout(duration).OnComplete((GTweenCallback)delegate
			{
				CreateEffectPlayer(effectLocal);
			});
		}
		((GComponent)(object)this).SetTimeout(1f).OnComplete(new GTweenCallback(End));
	}

	private void CreateEffectPlayer(IRewardClaimingEffect effect)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		new RewardClaimingEffectPlayer(effect, _endPos, 0.25f).Play();
	}

	private List<IRewardClaimingEffect> CreateClaimingEffects()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		List<IRewardClaimingEffect> list = new List<IRewardClaimingEffect>();
		for (int i = 0; i < 10; i++)
		{
			UI_com_Effect01 uI_com_Effect = UI_com_Effect01.CreateInstance_ILRuntime();
			((GComponent)this).AddChild((GObject)(object)uI_com_Effect);
			((GObject)uI_com_Effect).SetXY(StartPointPos.x, StartPointPos.y);
			RewardClaimingEffect rewardClaimingEffect = new RewardClaimingEffect((GComponent)(object)uI_com_Effect, "t0");
			list.Add(rewardClaimingEffect);
		}
		return list;
	}
}
