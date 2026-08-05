using System;
using System.Collections;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.WeekActivityPass;

public class UI_com_CSlider : GComponent
{
	public GImage Back;

	public GImage Bar;

	public UI_btn_SliderGrip Grip;

	public const string URL = "ui://11dkggb8nk8f19";

	public static string Name = "UI_com_CSlider";

	private int MaxCount = 0;

	private int MinCount = 0;

	private int _Value = 0;

	private int Step = 1;

	private float Padding = 0f;

	private float BarWidth = 0f;

	private float _Percentage = 0f;

	public Action OnChange;

	public Action OnLeave;

	public int Value
	{
		get
		{
			int num = (int)Math.Ceiling((double)_Value / (double)Step) * Step;
			if (num < MinCount || _Value == MinCount)
			{
				num = MinCount;
			}
			if (MaxCount < num || _Value == MaxCount)
			{
				num = MaxCount;
			}
			return num;
		}
		set
		{
			if (value < MinCount)
			{
				value = MinCount;
			}
			if (MaxCount < value)
			{
				value = MaxCount;
			}
			_Value = value;
			_Percentage = (float)(value - MinCount) / (float)(MaxCount - MinCount);
			((GObject)Grip).x = _Percentage * BarWidth + Padding;
			((GObject)Bar).width = ((GObject)Grip).x;
			OnChange?.Invoke();
		}
	}

	public float Percentage
	{
		get
		{
			return _Percentage;
		}
		set
		{
			_Percentage = value;
			_Value = (int)((float)(MaxCount - MinCount) * _Percentage) + MinCount;
			((GObject)Grip).x = _Percentage * BarWidth + Padding;
			((GObject)Bar).width = ((GObject)Grip).x;
			OnChange?.Invoke();
		}
	}

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f19";
	}

	public static UI_com_CSlider CreateInstance()
	{
		return (UI_com_CSlider)(object)UIPackage.CreateObject("WeekActivityPass", "com_CSlider");
	}

	public static UI_com_CSlider CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CSlider).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f19", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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

	public void UnregisterUiEventListeners()
	{
		((GObject)Grip).onDragMove.Clear();
		((GObject)Grip).onDragEnd.Clear();
		((GObject)Grip).onTouchBegin.Clear();
	}

	public void Init(int min, int max, int value, int step = 1, float padding = 0f)
	{
		Padding = padding;
		Step = step;
		MinCount = min;
		MaxCount = max;
		((GComponent)this).EnsureBoundsCorrect();
		BarWidth = ((GObject)Back).width - 2f * Padding;
		Value = value;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(InitDrag());
	}

	private IEnumerator InitDrag()
	{
		if (!((GObject)Grip).draggable)
		{
			yield return null;
			((GObject)Grip).draggable = true;
		}
		((GComponent)this).EnsureBoundsCorrect();
		Vector2 globalPos = ((GObject)this).LocalToRoot(((GObject)Back).xy, GRoot.inst);
		((GObject)Grip).dragBounds = new Rect(globalPos.x + Padding, globalPos.y, BarWidth + ((GObject)Grip).width, 0f);
	}

	private void OnDrag(EventContext context)
	{
		((GObject)Bar).width = ((GObject)Grip).x;
		_Percentage = (((GObject)Grip).x - Padding) / BarWidth;
		if (_Percentage < 0f)
		{
			_Percentage = 0f;
		}
		if (_Percentage > 1f)
		{
			_Percentage = 1f;
		}
		_Value = (int)((float)(MaxCount - MinCount) * _Percentage) + MinCount;
		OnChange?.Invoke();
	}

	private void OnDragEnd(EventContext context)
	{
		((GObject)Bar).width = ((GObject)Grip).x;
		_Percentage = (((GObject)Grip).x - Padding) / BarWidth;
		if (_Percentage < 0f)
		{
			_Percentage = 0f;
		}
		if (_Percentage > 1f)
		{
			_Percentage = 1f;
		}
		_Value = (int)((float)(MaxCount - MinCount) * _Percentage) + MinCount;
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
