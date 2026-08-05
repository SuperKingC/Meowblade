using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace UI.GvG3SplitBluePrint;

public class UI_main_BlueprintToBeSplit : GComponent, IUiController
{
	public Controller Type;

	public GGraph Mask;

	public UI_com_BlueprintLoader Blueprint;

	public const string URL = "ui://7uylntmmju1u3";

	public static string Name = "UI_main_BlueprintToBeSplit";

	private BlueprintToBeSplitParams _params;

	private Blueprint _blueprint;

	private UI_com_InfoDialog _infoDialog;

	private Action<string> _enqueue => _params.EnqueueAction;

	private Action<string> _dequeue => _params.DequeueAction;

	public static string GetURL()
	{
		return "ui://7uylntmmju1u3";
	}

	public static UI_main_BlueprintToBeSplit CreateInstance()
	{
		return (UI_main_BlueprintToBeSplit)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "main_BlueprintToBeSplit");
	}

	public static UI_main_BlueprintToBeSplit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BlueprintToBeSplit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmju1u3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Blueprint = (UI_com_BlueprintLoader)(object)((GComponent)this).GetChild("Blueprint");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		SetPanelSizeAndXy();
		ReadParameters(parameters);
		RenderBlueprint();
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
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)Blueprint.Enqueue).onClick.Set(new EventCallback0(Enqueue));
		((GObject)Blueprint.Dequeue).onClick.Set(new EventCallback0(Dequeue));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Blueprint.Enqueue).onClick.Clear();
		((GObject)Blueprint.Dequeue).onClick.Clear();
		_infoDialog?.UnregisterUiEventListeners();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void SetPanelSizeAndXy()
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
	}

	private void ReadParameters(Dictionary<string, object> parameters)
	{
		_params = (parameters.TryGetValue("BlueprintToBeSplitParams", out var value) ? ((BlueprintToBeSplitParams)value) : null);
		_blueprint = _params?.Blueprint;
	}

	public void RenderBlueprint()
	{
		Type.SetSelectedIndex((int)_params.DialogType);
		Blueprint.State.SetSelectedIndex((int)_params.OperationMode);
		((GObject)Blueprint.Enqueue).enabled = _params.OperationEnabled;
		((GObject)Blueprint.Dequeue).enabled = _params.OperationEnabled;
		bool isLocked = GameManagers.Instance.BpLockManager.GetIsLocked(_blueprint);
		((GObject)Blueprint.Enqueue).grayed = isLocked;
		_infoDialog = (UI_com_InfoDialog)(object)Blueprint.Loader.component;
		_infoDialog?.Init(_blueprint, this);
	}

	private void Enqueue()
	{
		if (GameManagers.Instance.BpLockManager.GetIsLocked(_blueprint))
		{
			_infoDialog?.ShakeLock();
			"BlueprintLockedTip".ToLanguage().ToTip();
		}
		else
		{
			_enqueue?.Invoke(_blueprint?.Id);
			End();
		}
	}

	private void Dequeue()
	{
		_dequeue?.Invoke(_blueprint?.Id);
		End();
	}

	public void DequeueCallback()
	{
		_dequeue?.Invoke(_blueprint?.Id);
		RenderBlueprint();
	}
}
