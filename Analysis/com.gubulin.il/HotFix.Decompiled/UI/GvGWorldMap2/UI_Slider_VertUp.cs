using System;
using System.Collections;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GvGWorldMap2;

public class UI_Slider_VertUp : GComponent
{
	public GImage Back;

	public GImage Bar;

	public UI_SliderGrip Grip;

	public const string URL = "ui://hd2s9kukursm2o";

	public static string Name = "UI_Slider_VertUp";

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

	public Action OnLeave = delegate
	{
	};

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
			_Value = Math.Min(value, MaxCount);
			_Value = Math.Max(_Value, MinCount);
			_Percentage = (_Value - MinCount) / (MaxCount - MinCount);
			((GObject)Bar).height = _Percentage * BarHeight;
			int num = ((((GObject)Bar).pivotY != 1f) ? 1 : (-1));
			((GObject)Grip).y = ((GObject)Bar).y + (float)num * ((GObject)Bar).height;
			OnChange?.Invoke();
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
			Percentage = value;
			int num = ((((GObject)Bar).pivotY != 1f) ? 1 : (-1));
			((GObject)Grip).y = ((GObject)Bar).y + (float)num * ((GObject)Bar).height;
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
			_Percentage = value;
			_Percentage = Math.Min(value, 1f);
			_Percentage = Math.Max(_Percentage, 0f);
			_Value = (MaxCount - MinCount) * _Percentage + MinCount;
			((GObject)Bar).height = _Percentage * BarHeight;
			OnChange?.Invoke();
		}
	}

	public static string GetURL()
	{
		return "ui://hd2s9kukursm2o";
	}

	public static UI_Slider_VertUp CreateInstance()
	{
		return (UI_Slider_VertUp)(object)UIPackage.CreateObject("GvGWorldMap2", "Slider_VertUp");
	}

	public static UI_Slider_VertUp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Slider_VertUp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukursm2o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Grip = (UI_SliderGrip)(object)((GComponent)this).GetChild("Grip");
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
		((GObject)Grip).onTouchBegin.Set((EventCallback0)delegate
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(InitDrag());
		});
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
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(InitDrag());
		RegisterUiEventListeners();
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

	private void OnDrag(EventContext context)
	{
		float num = Math.Abs(((GObject)Grip).y - ((GObject)Bar).y) / BarHeight;
		if (Mathf.Abs(num - Percentage) > (float)Step + Mathf.Epsilon)
		{
			Percentage = num;
			OnChange?.Invoke();
		}
	}

	private void OnDragEnd(EventContext context)
	{
		float num = Math.Abs(((GObject)Grip).y - ((GObject)Bar).y) / BarHeight;
		if (Math.Abs(num - Percentage) > (float)Step + Mathf.Epsilon)
		{
			Percentage = num;
			OnLeave?.Invoke();
		}
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
