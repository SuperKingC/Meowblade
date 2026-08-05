using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using UnityEngine;

namespace UI.MaskCover;

public class UI_MaskCover : GComponent, IUiController
{
	public GGraph fullScreenSfxBack;

	public GLoader maskLeft;

	public GLoader maskRight;

	public GLoader maskTop;

	public GLoader maskBottom;

	public GGraph cover;

	public GGraph mask;

	public GImage n8;

	public GMovieClip ClickEffect;

	public Transition ShowPanel;

	public const string URL = "ui://nhaflg39vb0c0";

	public static string Name = "UI_MaskCover";

	private Coroutine _showClickEffect;

	private const float InitRatio = 1.7777778f;

	public static string GetURL()
	{
		return "ui://nhaflg39vb0c0";
	}

	public static UI_MaskCover CreateInstance()
	{
		return (UI_MaskCover)(object)UIPackage.CreateObject("MaskCover", "MaskCover");
	}

	public static UI_MaskCover CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MaskCover).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nhaflg39vb0c0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		fullScreenSfxBack = (GGraph)((GComponent)this).GetChild("fullScreenSfxBack");
		maskLeft = (GLoader)((GComponent)this).GetChild("maskLeft");
		maskRight = (GLoader)((GComponent)this).GetChild("maskRight");
		maskTop = (GLoader)((GComponent)this).GetChild("maskTop");
		maskBottom = (GLoader)((GComponent)this).GetChild("maskBottom");
		cover = (GGraph)((GComponent)this).GetChild("cover");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		ClickEffect = (GMovieClip)((GComponent)this).GetChild("ClickEffect");
		ShowPanel = ((GComponent)this).GetTransition("ShowPanel");
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		ClickEffect.onPlayEnd.Clear();
		((GObject)GRoot.inst).onTouchBegin.Remove(new EventCallback1(OnTouchBegin));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GObject)this).sortingOrder = 4001;
		((GObject)mask).alpha = 0f;
		((GObject)n8).alpha = 0f;
		ClickEffect.onPlayEnd.Set(new EventCallback0(OnClickEffectPlayEnd));
		((GObject)GRoot.inst).onTouchBegin.Set(new EventCallback1(OnTouchBegin));
	}

	public void OnShow()
	{
		if ((Object)(object)FGUIManager.Instance != (Object)null)
		{
			FGUIManager.Instance.MaskCover = this;
		}
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		((GObject)this).Dispose();
	}

	public void ShowFullScreenSfx(string sfx, float time, int type = 0)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		((GObject)fullScreenSfxBack).SetXY(((GObject)this).width / 2f, ((GObject)this).height / 2f);
		FGUIManager.Instance.AddTextSpecialEffects(fullScreenSfxBack, sfx, new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureShining)
		{
			UiHelper.DestoryUiSfx(fullScreenSfxBack, treasureShining, time);
		});
		if (type == 0)
		{
			return;
		}
		GLoader missibleSfxBack = new GLoader();
		((GComponent)this).AddChild((GObject)(object)missibleSfxBack);
		((GObject)missibleSfxBack).SetSize(256f, 256f);
		((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		((GObject)missibleSfxBack).SetXY(((GObject)this).width / 2f, ((GObject)this).height / 2f);
		((GObject)missibleSfxBack).alpha = 1f;
		((GObject)missibleSfxBack).touchable = false;
		FGUIManager.Instance.SetItemIconAndFrame(missibleSfxBack, "I73000", null, "", frameVisible: false);
		Vector2 val = ((GObject)FGUIManager.Instance.MaincityUi.LegendItems).LocalToGlobal(Vector2.zero);
		Vector2 realPos = ((GObject)this).GlobalToLocal(val) + new Vector2(57f, 60f);
		GTweenCallback val2 = default(GTweenCallback);
		((GComponent)(object)this).SetTimeout(time).OnComplete((GTweenCallback)delegate
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0035: Expected O, but got Unknown
			GTweener obj = ((GObject)missibleSfxBack).TweenMove(realPos, 0.5f);
			GTweenCallback obj2 = val2;
			if (obj2 == null)
			{
				GTweenCallback val3 = delegate
				{
					((GObject)missibleSfxBack).Dispose();
					((GComponent)this).RemoveChild((GObject)(object)missibleSfxBack, true);
				};
				GTweenCallback val4 = val3;
				val2 = val3;
				obj2 = val4;
			}
			obj.OnComplete(obj2);
			((GObject)missibleSfxBack).TweenScale(new Vector2(0.25f, 0.25f), 0.5f);
			UiAudioManager.Instance.PlaySoundEffect("Missile");
		});
	}

	public void ShowScreenSfx(Vector2 startPos, float sfxSize = 60f, string sfx = "exp_missile_green", float delayTime = 1f)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = TransformLocalPos(startPos);
		((GObject)fullScreenSfxBack).SetXY(val.x, val.y);
		((GObject)fullScreenSfxBack).SetPivot(0.5f, 0.5f, true);
		FGUIManager.Instance.AddTextSpecialEffects(fullScreenSfxBack, sfx, new Vector3(sfxSize, sfxSize, sfxSize), "Default", 0.5f, delegate(GameObject fullSfxGameObject)
		{
			UiHelper.DestoryUiSfx(fullScreenSfxBack, fullSfxGameObject, delayTime);
		});
	}

	public void ShowGetBonusSfx(Vector2 startPos, Vector2 endPos, string sfx = "exp_missile_green", float delayTime = 0.5f)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		Vector2 realStartPos = TransformLocalPos(startPos);
		Vector2 realEndPos = TransformLocalPos(endPos);
		FGUIManager.Instance.AddTextSpecialEffects(fullScreenSfxBack, sfx, Vector3.zero, "Default", 0.5f, delegate
		{
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			if (!((GObject)fullScreenSfxBack).isDisposed && ((GObject)fullScreenSfxBack).displayObject != null && !((GObject)fullScreenSfxBack).displayObject.isDisposed)
			{
				((GObject)fullScreenSfxBack).SetXY(realStartPos.x, realStartPos.y);
				((GObject)fullScreenSfxBack).SetPivot(0.5f, 0.5f, true);
				((GObject)fullScreenSfxBack).TweenMove(realEndPos, delayTime);
			}
		});
		UiAudioManager.Instance.PlaySoundEffect("Missile");
	}

	private Vector2 TransformLocalPos(Vector2 localPos)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		return ((GObject)this).GlobalToLocal(localPos);
	}

	public void SetMaskVisible(bool value)
	{
		((GObject)maskLeft).visible = value;
		((GObject)maskRight).visible = value;
		((GObject)maskTop).visible = value;
		((GObject)maskBottom).visible = value;
	}

	private void SetMaskSize()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = num / 1.7777778f;
		if (num2 > 1f)
		{
			float num3 = (num2 * 1920f - 1920f) / 2f;
			int num4 = Mathf.CeilToInt(num3);
			((GObject)maskLeft).width = num4;
			((GObject)maskRight).width = num4;
		}
		else
		{
			float num5 = (1920f / (float)Screen.width * (float)Screen.height - 1080f) / 2f;
			int num6 = Mathf.CeilToInt(num5);
			((GObject)maskTop).height = num6;
			((GObject)maskBottom).height = num6;
		}
	}

	private static void OnTouchBegin(EventContext context)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		UI_MaskCover.OnTouchBegin(new Vector2(context.inputEvent.x, context.inputEvent.y));
	}

	public static void OnTouchBegin(Vector2 canvasPos)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (!(HotFix_Utils.GetMouseEffectSetting() != "on"))
		{
			UI_MaskCover maskCover = UnityUiService.Instance.maskCover;
			if (maskCover != null)
			{
				Vector2 pos = default(Vector2);
				((Vector2)(ref pos))._002Ector(canvasPos.x, canvasPos.y);
				TopUiCanvas.Instance.ClickEffect(pos);
			}
		}
	}

	public static void OnTouchBegin(GButton button)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = -((GObject)button).pivot * (((GObject)button).pivotAsAnchor ? 1f : 0f);
		Vector2 val2 = ((GObject)button).size * (0.5f * Vector2.one + val) + Random.insideUnitCircle * (((GObject)button).height * 0.5f);
		if (!((GObject)button).isDisposed && !((GObject)button).displayObject.isDisposed)
		{
			Vector2 canvasPos = ((GObject)button).LocalToGlobal(val2);
			OnTouchBegin(canvasPos);
		}
	}

	private void OnClick(EventContext context)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		UI_MaskCover maskCover = UnityUiService.Instance.maskCover;
		if (maskCover != null)
		{
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
			val = ((GObject)maskCover).GlobalToLocal(val);
			if (_showClickEffect != null)
			{
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_showClickEffect);
			}
			_showClickEffect = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ShowClickEffect(val));
		}
	}

	private IEnumerator ShowClickEffect(Vector2 logicScreenPos)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		int detectFrameCount = 5;
		int targetFrameRate = 30;
		float refWaitTime = (float)detectFrameCount / (float)targetFrameRate + 0.1f;
		float checkTime = Time.unscaledTime + refWaitTime;
		for (int i = 0; i < detectFrameCount; i++)
		{
			yield return null;
		}
		float endTime = Time.unscaledTime;
		if (endTime < checkTime)
		{
			((GObject)ClickEffect).SetXY(logicScreenPos.x, logicScreenPos.y);
			ClickEffect.frame = 0;
			ClickEffect.SetPlaySettings(0, 15, 1, 15);
			ClickEffect.playing = true;
			((GObject)ClickEffect).visible = true;
		}
		_showClickEffect = null;
	}

	private void OnClickEffectPlayEnd()
	{
		((GObject)ClickEffect).visible = false;
	}
}
