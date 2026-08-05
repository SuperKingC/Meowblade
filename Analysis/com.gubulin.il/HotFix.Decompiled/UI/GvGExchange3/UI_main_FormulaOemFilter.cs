using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;

namespace UI.GvGExchange3;

public class UI_main_FormulaOemFilter : GComponent, IUiController
{
	public GGraph Mask;

	public GImage n5;

	public UI_com_AmplifierFilter Filter;

	public UI_btn_ConfirmFilter Confirm;

	public UI_btn_Close Close;

	public GGroup n4;

	public const string URL = "ui://tt2iq07oj1h831";

	public static string Name = "UI_main_FormulaOemFilter";

	public const string FILTER = "FormulaOemFilter";

	public const string FILTER_CHANGE_ACTION = "FilterChangeAction";

	private FormulaOemMissionsFilter _filter;

	private Action<FormulaOemMissionsFilter> _onFilterChange = delegate
	{
	};

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h831";
	}

	public static UI_main_FormulaOemFilter CreateInstance()
	{
		return (UI_main_FormulaOemFilter)(object)UIPackage.CreateObject("GvGExchange3", "main_FormulaOemFilter");
	}

	public static UI_main_FormulaOemFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FormulaOemFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h831", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Filter = (UI_com_AmplifierFilter)(object)((GComponent)this).GetChild("Filter");
		Confirm = (UI_btn_ConfirmFilter)(object)((GComponent)this).GetChild("Confirm");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
		n4 = (GGroup)((GComponent)this).GetChild("n4");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		InitFilter(parameters);
		ReadFilterChangeAction(parameters);
		Filter.Init();
	}

	public void OnShow()
	{
		((GObject)this).visible = true;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Confirm).onClick.Set(new EventCallback0(OnConfirmClick));
		((GObject)Close).onClick.Set(new EventCallback0(OnCloseClick));
		Filter.RegisterUiEvent();
		UI_com_AmplifierFilter filter = Filter;
		filter.OnFilterChange = (Action)Delegate.Combine(filter.OnFilterChange, new Action(UpdateFormulaFilterModel));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Confirm).onClick.Clear();
		((GObject)Close).onClick.Clear();
		Filter.UnregisterUiEvent();
		UI_com_AmplifierFilter filter = Filter;
		filter.OnFilterChange = (Action)Delegate.Remove(filter.OnFilterChange, new Action(UpdateFormulaFilterModel));
	}

	private void OnCloseClick()
	{
		((GObject)this).visible = false;
	}

	private void InitFilter(Dictionary<string, object> parameters)
	{
		_filter = ReadParamTalentFromParameters<FormulaOemMissionsFilter>(parameters, "FormulaOemFilter");
	}

	private void ReadFilterChangeAction(Dictionary<string, object> parameters)
	{
		_onFilterChange = ReadParamTalentFromParameters<Action<FormulaOemMissionsFilter>>(parameters, "FilterChangeAction");
	}

	private static T ReadParamTalentFromParameters<T>(Dictionary<string, object> parameters, string paramKey)
	{
		object value;
		return parameters.TryGetValue(paramKey, out value) ? ((T)value) : default(T);
	}

	private void UpdateFormulaFilterModel()
	{
		_filter.Quality = Filter.SelectedQuality;
		_filter.Race = (int)Filter.SelectedRace;
		_filter.Soldier = Filter.SelectedSoldierId;
		_filter.Prop = Filter.SelectedModifier;
	}

	private void OnConfirmClick()
	{
		_onFilterChange?.Invoke(_filter);
		OnCloseClick();
	}
}
