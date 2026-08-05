using System;
using System.Collections;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.GvGAmplifierForge;

public class UI_com_03 : GComponent
{
	public GImage Back;

	public GGraph Bar;

	public UI_btn_05 Grip;

	public const string URL = "ui://fpjheycbslenv4gr";

	public static string Name = "UI_com_03";

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
			UpdateValue(value);
			((GObject)Bar).width = ((GObject)Grip).x;
			OnChange?.Invoke();
		}
	}

	public float Percentage => _Percentage;

	public static string GetURL()
	{
		return "ui://fpjheycbslenv4gr";
	}

	public static UI_com_03 CreateInstance()
	{
		return (UI_com_03)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_03");
	}

	public static UI_com_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbslenv4gr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Bar = (GGraph)((GComponent)this).GetChild("Bar");
		Grip = (UI_btn_05)(object)((GComponent)this).GetChild("Grip");
	}

	private void UpdateValue(int value)
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
		((GObject)Grip).x = ((GObject)Bar).x + _Percentage * BarWidth + Padding;
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
		Vector2 globalPos = ((GObject)this).LocalToRoot(((GObject)Bar).xy, GRoot.inst);
		Vector2 iconY = ((GObject)this).LocalToRoot(((GObject)Grip).xy, GRoot.inst);
		((GObject)Grip).dragBounds = new Rect(globalPos.x + Padding, iconY.y, BarWidth + ((GObject)Grip).width, 0f);
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
		Value = (int)((float)(MaxCount - MinCount) * _Percentage) + MinCount;
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
		Value = (int)((float)(MaxCount - MinCount) * _Percentage) + MinCount;
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
