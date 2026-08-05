using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace UI.Battle;

public class UI_FullscreenEffectStage : GComponent
{
	public Controller SeasonBuffShow;

	public UI_FullScreenEffectSimple EffectSimple;

	public UI_FullScreenEffectDetail EffectDetail;

	public UI_SeasonBuffSimple SeasonBuffSimple;

	public UI_SeasonBuffDetail SeasonBuffDetail;

	public UI_EffectIcon EffectIcon;

	public UI_SeasonBuffEffectIcon SeasonBuffEffectIcon;

	public GGraph Mask;

	public Transition ShowEffect;

	public Transition ShowSeasonBuffEffect;

	public const string URL = "ui://twlbabicol04m7";

	public static string Name = "UI_FullscreenEffectStage";

	private readonly List<string> _effects = new List<string> { "WarFever_fullscreen1", "WarFever_fullscreen2", "WarFever_fullscreen3", "WarFever_fullscreen4", "WarFever_fullscreen5" };

	private string _currentEffectName;

	private Vector2 _moveStartPos;

	private Vector2 _moveEndPos;

	private LongPressGesture _longPressGesture;

	private bool _earlyStop;

	private const string SEASON_BUFF_PREFIX = "AB_fullscreen_";

	private readonly List<string> _seasonBuffEffects = new List<string>
	{
		"AB_fullscreen_PVPS1rule001", "AB_fullscreen_PVPS1rule002", "AB_fullscreen_PVPS1rule003", "AB_fullscreen_PVPS1rule004", "AB_fullscreen_PVPS1rule005", "AB_fullscreen_PVPS1rule006", "AB_fullscreen_PVPS1rule007", "AB_fullscreen_PVPS1rule008", "AB_fullscreen_PVPS1rule009", "AB_fullscreen_PVPS1rule010",
		"AB_fullscreen_PVPS1rule011", "AB_fullscreen_PVPS1rule012"
	};

	private string _currentSeasonBuffName;

	private LongPressGesture _seasonBuffLongPressGesture;

	private bool _seasonBuffEarlyStop;

	private Vector3 _seasonBuffDetailInitPos;

	private Vector3 _seasonBuffIconStartPos;

	private GTweener _seasonBuffIconMoveTweener;

	public static string GetURL()
	{
		return "ui://twlbabicol04m7";
	}

	public static UI_FullscreenEffectStage CreateInstance()
	{
		return (UI_FullscreenEffectStage)(object)UIPackage.CreateObject("Battle", "FullscreenEffectStage");
	}

	public static UI_FullscreenEffectStage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FullscreenEffectStage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicol04m7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SeasonBuffShow = ((GComponent)this).GetController("SeasonBuffShow");
		EffectSimple = (UI_FullScreenEffectSimple)(object)((GComponent)this).GetChild("EffectSimple");
		EffectDetail = (UI_FullScreenEffectDetail)(object)((GComponent)this).GetChild("EffectDetail");
		SeasonBuffSimple = (UI_SeasonBuffSimple)(object)((GComponent)this).GetChild("SeasonBuffSimple");
		SeasonBuffDetail = (UI_SeasonBuffDetail)(object)((GComponent)this).GetChild("SeasonBuffDetail");
		EffectIcon = (UI_EffectIcon)(object)((GComponent)this).GetChild("EffectIcon");
		SeasonBuffEffectIcon = (UI_SeasonBuffEffectIcon)(object)((GComponent)this).GetChild("SeasonBuffEffectIcon");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		ShowEffect = ((GComponent)this).GetTransition("ShowEffect");
		ShowSeasonBuffEffect = ((GComponent)this).GetTransition("ShowSeasonBuffEffect");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		SharedMessenger.AddListener<string>("ON_FULL_SCREEN_EFFECT_SHOW", Render);
		SharedMessenger.AddListener<Dictionary<string, object>>("ON_PVP_RESULT_ANIM", ResetFullscreenEffectStage);
		((GObject)EffectSimple).onClick.Set(new EventCallback0(OnEffectSimpleClick));
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<string>("ON_FULL_SCREEN_EFFECT_SHOW", Render);
		SharedMessenger.RemoveListener<Dictionary<string, object>>("ON_PVP_RESULT_ANIM", ResetFullscreenEffectStage);
		((GObject)EffectSimple).onClick.Clear();
		if (_longPressGesture != null)
		{
			_longPressGesture.onAction.Clear();
			_longPressGesture.onEnd.Clear();
		}
	}

	private void ResetFullscreenEffectStage(Dictionary<string, object> arg1)
	{
		if (!string.IsNullOrEmpty(_currentEffectName))
		{
			_currentEffectName = string.Empty;
			_earlyStop = true;
			EffectSimple.Appear.PlayReverse();
		}
	}

	private void Render(string effectName)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		bool isFirst;
		string effectIcon;
		if (!string.IsNullOrEmpty(effectName) && _effects.Contains(effectName) && !string.Equals(_currentEffectName, effectName))
		{
			_earlyStop = false;
			isFirst = string.IsNullOrEmpty(_currentEffectName);
			_currentEffectName = effectName;
			if (_longPressGesture == null)
			{
				_longPressGesture = new LongPressGesture((GObject)(object)EffectSimple)
				{
					once = true,
					trigger = 0f
				};
				_longPressGesture.onAction.Add(new EventCallback0(ShowEffectDetail));
				_longPressGesture.onEnd.Add(new EventCallback0(CloseEffectDetail));
			}
			effectIcon = "ui://Battle/WarFever_fullscreen";
			string text = (effectName + "_Name_Detail").ToLanguage();
			string text2 = (effectName + "_Desc").ToLanguage();
			EffectIcon.Icon.url = effectIcon;
			EffectDetail.Icon.url = effectIcon;
			((GObject)EffectDetail.EffectText).text = text2;
			((GObject)EffectDetail.EffectNameLevel).text = text;
			if (isFirst)
			{
				RefreshEffectSimpleInfo();
			}
			if (_moveStartPos == default(Vector2) || _moveEndPos == default(Vector2))
			{
				_moveStartPos = ((GObject)EffectDetail.Icon).LocalToRoot(Vector2.zero, GRoot.inst);
				_moveEndPos = ((GObject)EffectSimple.Icon).LocalToRoot(Vector2.zero, GRoot.inst);
			}
			((GObject)EffectIcon).SetXY(_moveStartPos.x, _moveStartPos.y);
			if (ShowEffect.playing)
			{
				ShowEffect.Stop(true, true);
			}
			EffectDetail.Show.SetSelectedIndex(0);
			ShowEffect.SetHook("EffectDisappearStart", new TransitionHook(MoveEffectIcon));
			ShowEffect.SetHook("EffectDisappearEnd", new TransitionHook(EffectSimpleAppear));
			ShowEffect.Play();
			if (!isFirst)
			{
				EffectSimple.LevelUp.SetHook("Refresh", new TransitionHook(RefreshEffectSimpleInfo));
				EffectSimple.LevelUp.Play();
			}
		}
		void EffectSimpleAppear()
		{
			if (isFirst && !_earlyStop)
			{
				EffectSimple.Appear.Play();
			}
		}
		void MoveEffectIcon()
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			((GObject)EffectIcon).TweenMove(_moveEndPos, 0.4f);
		}
		void RefreshEffectSimpleInfo()
		{
			string text3 = (effectName + "_Name_Simple").ToLanguage();
			EffectSimple.Icon.url = effectIcon;
			((GObject)EffectSimple.EffectNameLevel).text = text3;
		}
	}

	private void OnEffectSimpleClick()
	{
		FGUIManager.Instance.OpenIEnumerator(EffectDetail());
		IEnumerator EffectDetail()
		{
			LongPressGesture longPressGesture = _longPressGesture;
			if (longPressGesture != null)
			{
				longPressGesture.onAction.Call();
			}
			yield return null;
			LongPressGesture longPressGesture2 = _longPressGesture;
			if (longPressGesture2 != null)
			{
				longPressGesture2.onEnd.Call();
			}
		}
	}

	private void ShowEffectDetail()
	{
		if (!ShowEffect.playing && !string.IsNullOrEmpty(_currentEffectName))
		{
			EffectDetail.Show.SetSelectedIndex(1);
		}
	}

	private void CloseEffectDetail()
	{
		EffectDetail.Show.SetSelectedIndex(0);
	}

	public void InitSeasonBuff()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		SeasonBuffShow.selectedIndex = 0;
		((GObject)SeasonBuffSimple).alpha = 0f;
		((GObject)SeasonBuffDetail).alpha = 0f;
		_seasonBuffDetailInitPos = ((GObject)SeasonBuffDetail).position;
		_seasonBuffIconStartPos = Vector2.op_Implicit(((GObject)SeasonBuffDetail.BuffIcon).TransformPoint(Vector2.zero, (GObject)(object)this));
		if (_seasonBuffLongPressGesture == null)
		{
			_seasonBuffLongPressGesture = new LongPressGesture((GObject)(object)SeasonBuffSimple)
			{
				once = true,
				trigger = 0f
			};
			_seasonBuffLongPressGesture.onAction.Add(new EventCallback0(ShowSeasonBuffDetail));
			_seasonBuffLongPressGesture.onEnd.Add(new EventCallback0(CloseSeasonBuffDetail));
		}
	}

	public void RegisterSeasonBuffUiEventListeners()
	{
		SharedMessenger.AddListener<string>("ON_FULL_SCREEN_EFFECT_SHOW", RenderSeasonBuff);
		SharedMessenger.AddListener<int>("ON_PVP_REPLAY_NEXT_WAVE", ResetSeasonBuffEffectStage);
	}

	public void UnregisterSeasonBuffUiEventListeners()
	{
		SharedMessenger.RemoveListener<string>("ON_FULL_SCREEN_EFFECT_SHOW", RenderSeasonBuff);
		SharedMessenger.RemoveListener<int>("ON_PVP_REPLAY_NEXT_WAVE", ResetSeasonBuffEffectStage);
		if (_seasonBuffLongPressGesture != null)
		{
			_seasonBuffLongPressGesture.onAction.Clear();
			_seasonBuffLongPressGesture.onEnd.Clear();
		}
	}

	private void ResetSeasonBuffEffectStage(int legionIndex)
	{
		if (!string.IsNullOrEmpty(_currentSeasonBuffName))
		{
			_currentSeasonBuffName = string.Empty;
			_seasonBuffEarlyStop = true;
			SeasonBuffSimple.Appear.PlayReverse();
			SeasonBuffShow.selectedIndex = 0;
			GTweener seasonBuffIconMoveTweener = _seasonBuffIconMoveTweener;
			if (seasonBuffIconMoveTweener != null)
			{
				seasonBuffIconMoveTweener.Kill(false);
			}
			_seasonBuffIconMoveTweener = null;
			SeasonBuffEffectIcon.Move.Stop();
		}
	}

	private void RenderSeasonBuff(string effectName)
	{
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		if (string.IsNullOrEmpty(effectName) || !_seasonBuffEffects.Contains(effectName) || !string.IsNullOrEmpty(_currentSeasonBuffName))
		{
			return;
		}
		string key = effectName.Substring("AB_fullscreen_".Length);
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(key);
		Vector2 seasonBuffIconEndPos;
		if (gDEAbilityData != null)
		{
			_seasonBuffEarlyStop = false;
			_currentSeasonBuffName = effectName;
			string url = gDEAbilityData.Icon.ToPublicResourcesRgbIcon();
			string name = gDEAbilityData.Name;
			string description = gDEAbilityData.Description;
			SeasonBuffSimple.Icon.url = url;
			((GObject)SeasonBuffSimple.EffectNameLevel).text = name;
			SeasonBuffDetail.BuffIcon.icon.url = url;
			((GObject)SeasonBuffDetail.EffectNameLevel).text = name;
			((GObject)SeasonBuffDetail.EffectText).text = description;
			SeasonBuffEffectIcon.n2.icon.url = url;
			seasonBuffIconEndPos = ((GObject)SeasonBuffSimple.Icon).TransformPoint(Vector2.zero, (GObject)(object)this);
			if (ShowSeasonBuffEffect.playing)
			{
				ShowSeasonBuffEffect.Stop(true, true);
			}
			SeasonBuffEffectIcon.Move.Stop();
			GTweener seasonBuffIconMoveTweener = _seasonBuffIconMoveTweener;
			if (seasonBuffIconMoveTweener != null)
			{
				seasonBuffIconMoveTweener.Kill(false);
			}
			_seasonBuffIconMoveTweener = null;
			((GObject)SeasonBuffEffectIcon).SetXY(_seasonBuffIconStartPos.x, _seasonBuffIconStartPos.y);
			((GObject)SeasonBuffEffectIcon).alpha = 0f;
			((GObject)SeasonBuffEffectIcon).scaleX = 1f;
			((GObject)SeasonBuffEffectIcon).scaleY = 1f;
			SeasonBuffDetail.Show.SetSelectedIndex(0);
			SeasonBuffShow.selectedIndex = 1;
			((GObject)SeasonBuffSimple).alpha = 0f;
			((GObject)SeasonBuffDetail).alpha = 0f;
			((GObject)SeasonBuffDetail).position = _seasonBuffDetailInitPos;
			((GObject)SeasonBuffDetail.BuffIcon).visible = true;
			ShowSeasonBuffEffect.SetHook("EffectDisappearStart", new TransitionHook(MoveSeasonBuffIcon));
			ShowSeasonBuffEffect.SetHook("EffectDisappearEnd", new TransitionHook(SeasonBuffSimpleAppear));
			ShowSeasonBuffEffect.Play();
		}
		void MoveSeasonBuffIcon()
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			((GObject)SeasonBuffDetail.BuffIcon).visible = false;
			_seasonBuffIconMoveTweener = ((GObject)SeasonBuffEffectIcon).TweenMove(seasonBuffIconEndPos, 0.4f);
		}
		void SeasonBuffSimpleAppear()
		{
			if (!_seasonBuffEarlyStop)
			{
				SeasonBuffSimple.Appear.Play();
			}
		}
	}

	private void ShowSeasonBuffDetail()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrEmpty(_currentSeasonBuffName))
		{
			((GObject)SeasonBuffDetail.BuffIcon).visible = true;
			((GObject)SeasonBuffDetail).position = _seasonBuffDetailInitPos;
			SeasonBuffDetail.Appear.Play();
			SeasonBuffDetail.Appear.Stop(true, false);
		}
	}

	private void CloseSeasonBuffDetail()
	{
		SeasonBuffDetail.Appear.PlayReverse();
		SeasonBuffDetail.Appear.Stop(true, false);
	}
}
