using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_main_FillUpConfirm : GComponent, IUiController
{
	public GGraph back;

	public UI_com_FillUpConfirm Dialog;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2k85c6a";

	public static string Name = "UI_main_FillUpConfirm";

	private Action _leaveAction;

	private Action _fillUpAction;

	public static string GetURL()
	{
		return "ui://4eq8fgd2k85c6a";
	}

	public static UI_main_FillUpConfirm CreateInstance()
	{
		return (UI_main_FillUpConfirm)(object)UIPackage.CreateObject("GvGWorldMap3", "main_FillUpConfirm");
	}

	public static UI_main_FillUpConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FillUpConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2k85c6a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_FillUpConfirm)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_leaveAction = (parameters.TryGetValue("LeaveAction", out var value) ? (value as Action) : null);
		_fillUpAction = (parameters.TryGetValue("FillUpAction", out var value2) ? (value2 as Action) : null);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Leave).onClick.Set(new EventCallback0(LeaveClickEvent));
		((GObject)Dialog.FillUp).onClick.Set(new EventCallback0(FillUpClickEvent));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.Leave).onClick.Clear();
		((GObject)Dialog.FillUp).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void LeaveClickEvent()
	{
		_leaveAction?.Invoke();
		End();
	}

	private void FillUpClickEvent()
	{
		_fillUpAction?.Invoke();
		End();
	}
}
