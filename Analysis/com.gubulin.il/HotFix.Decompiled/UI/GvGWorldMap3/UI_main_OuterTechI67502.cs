using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations.Static;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.GvGWorldMap3;

public class UI_main_OuterTechI67502 : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_OuterTechI67502Popup Popup;

	public const string URL = "ui://4eq8fgd2e8d4s9i";

	public static string Name = "UI_main_OuterTechI67502";

	private Action _onClickConfirm;

	private Action _onClickCancel;

	private string _jumpCost;

	private bool Today努力加餐饭NoTip => ((GButton)Popup.努力加餐饭Tip).selected;

	public static string GetURL()
	{
		return "ui://4eq8fgd2e8d4s9i";
	}

	public static UI_main_OuterTechI67502 CreateInstance()
	{
		return (UI_main_OuterTechI67502)(object)UIPackage.CreateObject("GvGWorldMap3", "main_OuterTechI67502");
	}

	public static UI_main_OuterTechI67502 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_OuterTechI67502).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2e8d4s9i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Popup = (UI_com_OuterTechI67502Popup)(object)((GComponent)this).GetChild("Popup");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_onClickConfirm = (parameters.TryGetValue("ConfirmAction", out var value) ? ((Action)value) : null);
		_onClickCancel = (parameters.TryGetValue("CancelAction", out var value2) ? ((Action)value2) : null);
		_jumpCost = (parameters.TryGetValue("JumpCost", out var value3) ? value3.ToString() : null);
	}

	public void OnShow()
	{
		Render();
	}

	private void Render()
	{
		((GButton)Popup.努力加餐饭Tip).selected = true;
		OuterTechHelper.努力加餐饭Config config = OuterTechHelper.Get_努力加餐饭Config();
		DisplayAvailableCount();
		DisplayCostInfo();
		void DisplayAvailableCount()
		{
			int maxUseTimes = config.MaxUseTimes;
			int o努力加餐饭_LimitTime = Singleton<WorldStateManager>.Instance.Data.OuterTechModel.o努力加餐饭_LimitTime;
			string arg = ((o努力加餐饭_LimitTime > 0) ? "#aef224" : "#ff1a1a");
			((GObject)Popup.AvailableCount).text = $"[color={arg}]{o努力加餐饭_LimitTime}/[/color]{maxUseTimes}";
		}
		void DisplayCostInfo()
		{
			((GObject)Popup.CostTip).text = "GvG3努力加餐饭CostTip".ToLanguage().Format(new object[1] { Item.Name(GameManagers.Instance, config.CosumeItemId) });
			Popup.CostIcon.url = UiHelper.GetIcon(config.CosumeItemId).ToPublicResourceIcon();
			((GObject)Popup.CostCount).text = _jumpCost;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Popup.Confirm).onClick.Set(new EventCallback0(OnClickConfirm));
		((GObject)Popup.Cancel).onClick.Set(new EventCallback0(OnClickCancel));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Popup.Confirm).onClick.Clear();
		((GObject)Popup.Cancel).onClick.Clear();
	}

	private void OnClickConfirm()
	{
		if (Today努力加餐饭NoTip)
		{
			JumpUseOuterTechTip.RecordCheckJumpUseOuterTech();
		}
		_onClickConfirm?.Invoke();
		End();
	}

	private void OnClickCancel()
	{
		_onClickCancel?.Invoke();
		End();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
