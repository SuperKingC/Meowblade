using System;
using System.Collections;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_com_SliderVertUp : GComponent
{
	public GImage Back;

	public GImage Bar;

	public UI_btn_SliderGrip Grip;

	public const string URL = "ui://hozu168rear78y";

	public static string Name = "UI_com_SliderVertUp";

	private bool IsDragging;

	private float MaxCount = 0f;

	private float MinCount = 0f;

	private float _Value = 0f;

	private int Step = 1;

	private Vector2 BarXY;

	private float BarHeight = 0f;

	private float _Percentage = 0f;

	public Action OnChange = delegate
	{
	};

	public Action OnDragValueChange = delegate
	{
	};

	public Action OnLeave = delegate
	{
	};

	private bool HasChange = false;

	private int OnChange_CallFrame;

	private Coroutine UpdateCoroutine;

	public float MaxValue => MaxCount;

	public float MinValue => MinCount;

	public float Value
	{
		get
		{
			float val = ((Step == 0) ? _Value : ((float)((int)Math.Ceiling((double)_Value / (double)Step) * Step)));
			val = Math.Min(val, MaxCount);
			return Math.Max(val, MinCount);
		}
		set
		{
			if (!IsDragging)
			{
				SetValue(value);
			}
		}
	}

	public float Percent
	{
		get
		{
			return Percentage;
		}
		set
		{
			if (!IsDragging)
			{
				int num = ((((GObject)Bar).pivotY != 1f) ? 1 : (-1));
				((GObject)Grip).y = ((GObject)Bar).y + (float)num * ((GObject)Bar).height;
				Percentage = value;
			}
		}
	}

	private float Percentage
	{
		get
		{
			return _Percentage;
		}
		set
		{
			SetPercentage(value);
		}
	}

	public static string GetURL()
	{
		return "ui://hozu168rear78y";
	}

	public static UI_com_SliderVertUp CreateInstance()
	{
		return (UI_com_SliderVertUp)(object)UIPackage.CreateObject("GvGBrawlFight", "com_SliderVertUp");
	}

	public static UI_com_SliderVertUp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SliderVertUp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rear78y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (GImage)((GComponent)this).GetChild("Back");
		Bar = (GImage)((GComponent)this).GetChild("Bar");
		Grip = (UI_btn_SliderGrip)(object)((GComponent)this).GetChild("Grip");
	}

	public void SwallowEvent()
	{
		OnChange_CallFrame = 0;
	}

	private void SetValue(float val)
	{
		_Value = Math.Min(val, MaxCount);
		_Value = Math.Max(_Value, MinCount);
		_Percentage = (_Value - MinCount) / (MaxCount - MinCount);
		((GObject)Bar).height = _Percentage * BarHeight;
		int num = ((((GObject)Bar).pivotY != 1f) ? 1 : (-1));
		((GObject)Grip).y = ((GObject)Bar).y + (float)num * ((GObject)Bar).height;
		OnChange_CallFrame = Time.frameCount;
	}

	private void SetPercentage(float val)
	{
		_Percentage = val;
		_Percentage = Math.Min(val, 1f);
		_Percentage = Math.Max(_Percentage, 0f);
		_Value = (MaxCount - MinCount) * _Percentage + MinCount;
		((GObject)Bar).height = _Percentage * BarHeight;
		OnChange_CallFrame = Time.frameCount;
	}

	public void Init(float min, float max, float value, int step = 0)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		Step = step;
		MinCount = min;
		MaxCount = max;
		BarXY = ((GObject)Bar).xy;
		BarHeight = ((GObject)Bar).height;
		Value = value;
		IsDragging = false;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(InitDrag());
		RegisterUiEventListeners();
		if (UpdateCoroutine == null)
		{
			UpdateCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdateEndOfFrame());
		}
	}

	private IEnumerator InitDrag()
	{
		((GComponent)this).EnsureBoundsCorrect();
		yield return null;
		((GObject)Grip).draggable = true;
		Vector2 globalPos = ((GObject)this).LocalToRoot(BarXY, GRoot.inst);
		if ((double)Math.Abs(((GObject)Bar).pivotY - 1f) < 0.01)
		{
			((GObject)Grip).dragBounds = Rect.MinMaxRect(globalPos.x, globalPos.y - BarHeight, globalPos.x, globalPos.y + ((GObject)Grip).height);
		}
		else if ((double)Math.Abs(((GObject)Bar).pivotY - 0f) < 0.01)
		{
			((GObject)Grip).dragBounds = Rect.MinMaxRect(globalPos.x, globalPos.y, globalPos.x, globalPos.y + BarHeight + ((GObject)Grip).height);
		}
		else
		{
			ILRuntimeDebug.LogError("UI_Slider_VertUp 的y轴锚点只能为0或者1");
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)Grip).onDragMove.Set(new EventCallback1(OnDrag));
		((GObject)Grip).onDragEnd.Set(new EventCallback1(OnDragEnd));
		((GObject)Grip).onTouchBegin.Set(new EventCallback1(OnDragBegin));
	}

	public override void Dispose()
	{
		if (UpdateCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(UpdateCoroutine);
		}
		((GComponent)this).Dispose();
	}

	private IEnumerator UpdateEndOfFrame()
	{
		while (true)
		{
			if (OnChange_CallFrame == Time.frameCount && !((GObject)this).isDisposed)
			{
				OnChange?.Invoke();
				if (IsDragging)
				{
					OnDragValueChange?.Invoke();
				}
			}
			yield return (object)new WaitForEndOfFrame();
		}
	}

	private void OnDragBegin(EventContext context)
	{
		IsDragging = true;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(InitDrag());
	}

	private void OnDrag(EventContext context)
	{
		float num = Math.Abs(((GObject)Grip).y - ((GObject)Bar).y) / BarHeight;
		if (Mathf.Abs(num - Percentage) > (float)Step + Mathf.Epsilon)
		{
			Percentage = num;
		}
	}

	private void OnDragEnd(EventContext context)
	{
		IsDragging = false;
		float num = Math.Abs(((GObject)Grip).y - ((GObject)Bar).y) / BarHeight;
		if (Math.Abs(num - Percentage) > (float)Step + Mathf.Epsilon)
		{
			Percentage = num;
		}
		OnLeave?.Invoke();
	}

	public void ToMax()
	{
		Value = MaxCount;
	}

	public void ToMin()
	{
		Value = MinCount;
	}
}
