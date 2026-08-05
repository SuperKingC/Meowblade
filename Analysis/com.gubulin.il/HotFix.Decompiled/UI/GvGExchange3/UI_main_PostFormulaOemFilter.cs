using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GvGExchange3;

public class UI_main_PostFormulaOemFilter : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_PostFormulaOemFilter Filter;

	public UI_btn_Confirm Confirm;

	public const string URL = "ui://tt2iq07oj1h84h";

	public static string Name = "UI_main_PostFormulaOemFilter";

	private int _ampIdx;

	private Action<int> _updateSelectedFormula;

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h84h";
	}

	public static UI_main_PostFormulaOemFilter CreateInstance()
	{
		return (UI_main_PostFormulaOemFilter)(object)UIPackage.CreateObject("GvGExchange3", "main_PostFormulaOemFilter");
	}

	public static UI_main_PostFormulaOemFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_PostFormulaOemFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h84h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Filter = (UI_com_PostFormulaOemFilter)(object)((GComponent)this).GetChild("Filter");
		Confirm = (UI_btn_Confirm)(object)((GComponent)this).GetChild("Confirm");
	}

	public void BeforeDestroy()
	{
		Filter.OnDestroy();
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_updateSelectedFormula = (parameters.TryGetValue("OnSelectFormula", out var value) ? ((Action<int>)value) : null);
		UpdateConfirmBtnEnabled(btnEnabled: false);
		Filter.Init();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)Confirm).onClick.Set(new EventCallback0(OnConfirmClick));
		Filter.RegisterUiEventListeners();
		UI_com_PostFormulaOemFilter filter = Filter;
		filter.OnSelectAmplifier = (Action<int>)Delegate.Combine(filter.OnSelectAmplifier, new Action<int>(UpdateSelectedAmpIdx));
		UI_com_PostFormulaOemFilter filter2 = Filter;
		filter2.ChangeConfirmBtnEnabled = (Action<bool>)Delegate.Combine(filter2.ChangeConfirmBtnEnabled, new Action<bool>(UpdateConfirmBtnEnabled));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Confirm).onClick.Clear();
		Filter.UnregisterUiEventListeners();
		UI_com_PostFormulaOemFilter filter = Filter;
		filter.OnSelectAmplifier = (Action<int>)Delegate.Remove(filter.OnSelectAmplifier, new Action<int>(UpdateSelectedAmpIdx));
		UI_com_PostFormulaOemFilter filter2 = Filter;
		filter2.ChangeConfirmBtnEnabled = (Action<bool>)Delegate.Remove(filter2.ChangeConfirmBtnEnabled, new Action<bool>(UpdateConfirmBtnEnabled));
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void UpdateConfirmBtnEnabled(bool btnEnabled)
	{
		((GObject)Confirm).enabled = btnEnabled;
	}

	private void UpdateSelectedAmpIdx(int ampIdx)
	{
		_ampIdx = ampIdx;
	}

	private void OnConfirmClick()
	{
		_updateSelectedFormula?.Invoke(_ampIdx);
		End();
	}
}
