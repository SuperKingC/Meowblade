using System;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_ItemsCounter : GComponent
{
	public GTextField Title;

	public GImage compoundNumBack;

	public GTextInput compoundNum;

	public UI_increaseButton increaseBtn;

	public UI_reduceButton reduceBtn;

	public UI_MaxValueBtn MaxValueBtn;

	public GGroup n86;

	public const string URL = "ui://47lbpgx9e6o8tav";

	public static string Name = "UI_ItemsCounter";

	public int MaxValue = 99999;

	private int _Value = 1;

	public Action OnChange;

	public int Value
	{
		get
		{
			int num = _Value;
			if (MaxValue <= 0)
			{
				num = 1;
			}
			else if (num < 1)
			{
				num = 1;
			}
			else if (MaxValue < num)
			{
				num = MaxValue;
			}
			return num;
		}
		set
		{
			if (MaxValue <= 0)
			{
				value = 1;
			}
			else if (value < 1)
			{
				value = 1;
			}
			else if (MaxValue < value)
			{
				value = MaxValue;
			}
			_Value = value;
			((GObject)compoundNum).text = $"{value}";
			OnChange?.Invoke();
		}
	}

	public void SetButtonTitle()
	{
		((GObject)MaxValueBtn.title).text = LanguagesManager.GetDesc("Tips-ItemsCounter-MaxValueBtn-title");
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9e6o8tav";
	}

	public static UI_ItemsCounter CreateInstance()
	{
		return (UI_ItemsCounter)(object)UIPackage.CreateObject("Tips", "ItemsCounter");
	}

	public static UI_ItemsCounter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ItemsCounter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9e6o8tav", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://47lbpgx9e6o8tav".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		compoundNumBack = (GImage)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextInput)((GComponent)this).GetChild("compoundNum");
		increaseBtn = (UI_increaseButton)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduceButton)(object)((GComponent)this).GetChild("reduceBtn");
		MaxValueBtn = (UI_MaxValueBtn)(object)((GComponent)this).GetChild("MaxValueBtn");
		n86 = (GGroup)((GComponent)this).GetChild("n86");
	}

	public void Init(string title, int max = 1)
	{
		((GObject)Title).text = title;
		MaxValue = max;
		Value = 1;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		((GObject)increaseBtn).onClick.Add(new EventCallback0(IncreaseCompoundNum));
		((GObject)reduceBtn).onClick.Add(new EventCallback0(ReduceCompoundNum));
		((GObject)MaxValueBtn).onClick.Add(new EventCallback0(ToMax));
		compoundNum.onChanged.Add(new EventCallback0(OnInput));
		((GObject)compoundNum).onFocusOut.Add(new EventCallback0(OnFocusOut));
		((GObject)compoundNum).onFocusIn.Add(new EventCallback0(OnFocusIn));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)increaseBtn).onClick.Clear();
		((GObject)reduceBtn).onClick.Clear();
		((GObject)MaxValueBtn).onClick.Clear();
		compoundNum.onChanged.Clear();
		((GObject)compoundNum).onFocusOut.Clear();
		((GObject)compoundNum).onFocusIn.Clear();
	}

	private void IncreaseCompoundNum()
	{
		int value = Value + 1;
		Value = value;
	}

	private void ReduceCompoundNum()
	{
		int value = Value - 1;
		Value = value;
	}

	private void ToMax()
	{
		Value = MaxValue;
	}

	private void OnInput()
	{
		try
		{
			int value = Convert.ToInt32(((GObject)compoundNum).text);
			Value = value;
		}
		catch (Exception)
		{
		}
	}

	private void OnFocusIn()
	{
	}

	private void OnFocusOut()
	{
		try
		{
			if (((GObject)compoundNum).text == "")
			{
				Value = _Value;
				return;
			}
			int value = Convert.ToInt32(((GObject)compoundNum).text);
			Value = value;
		}
		catch (Exception)
		{
			Value = _Value;
		}
	}
}
