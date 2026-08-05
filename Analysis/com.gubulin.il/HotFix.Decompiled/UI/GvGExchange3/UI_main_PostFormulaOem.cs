using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_main_PostFormulaOem : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_PostFormulaOemMission Popup;

	public const string URL = "ui://tt2iq07oj1h84j";

	public static string Name = "UI_main_PostFormulaOem";

	private int? _ampIdx;

	private Action<int> _updateSelectedFormula;

	private readonly List<FormulaOemUiBonus> _bonusList = new List<FormulaOemUiBonus>(5)
	{
		new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Base
		},
		new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Make
		},
		new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Titan
		},
		new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Critical
		},
		new FormulaOemUiBonus
		{
			Type = FormulaOemBonusType.Immediate
		}
	};

	private OemMissionAmplifier OemMission => OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(_ampIdx.GetValueOrDefault());

	private List<FormulaOemUiBonus> LaterBonus => _bonusList.Take(4).ToList();

	public static string GetURL()
	{
		return "ui://tt2iq07oj1h84j";
	}

	public static UI_main_PostFormulaOem CreateInstance()
	{
		return (UI_main_PostFormulaOem)(object)UIPackage.CreateObject("GvGExchange3", "main_PostFormulaOem");
	}

	public static UI_main_PostFormulaOem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_PostFormulaOem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oj1h84j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Popup = (UI_com_PostFormulaOemMission)(object)((GComponent)this).GetChild("Popup");
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
		InitDelegate();
		InitChildComponents();
		ReadSelectAmpIdx(parameters);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		RegisterBtnEventListeners();
		Popup.OemCount.RegisterUiEventListeners();
	}

	private void RegisterBtnEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)Popup.Post).onClick.Set(new EventCallback0(OnPostClick));
		((GObject)Popup.SelectedFormula).onClick.Set(new EventCallback0(GoToSelectFormula));
		((GObject)Popup.Help).onClick.Set(new EventCallback1(OnHelpClick));
	}

	public void UnregisterUiEventListeners()
	{
		UnregisterBtnEventListeners();
		Popup.OemCount.UnregisterUiEventListeners();
	}

	private void UnregisterBtnEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Popup.Post).onClick.Clear();
		((GObject)Popup.SelectedFormula).onClick.Clear();
		((GObject)Popup.Help).onClick.Clear();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ReadSelectAmpIdx(Dictionary<string, object> parameters)
	{
		if (parameters != null && parameters.TryGetValue("SelectFormulaAmpIdx", out var value))
		{
			_updateSelectedFormula?.Invoke((int)value);
		}
	}

	private void InitChildComponents()
	{
		Popup.OemCount.Init();
		InitBonus();
		((GObject)Popup.MissionDuration).text = "24";
	}

	private void InitDelegate()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		_updateSelectedFormula = UpdateFormula;
		Popup.PostBonus.itemRenderer = new ListItemRenderer(RenderPostBonus);
	}

	private static void OnHelpClick(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_PostNewFormulaTip.Name, null);
	}

	private void UpdateFormula(int ampIdx)
	{
		_ampIdx = ampIdx;
		RenderSelectedFormula();
		UpdateBonus();
		Popup.OemCount.Update(OemMission.FormulaId);
	}

	private void RenderSelectedFormula()
	{
		if (_ampIdx.HasValue)
		{
			Popup.Selected.SetSelectedIndex(1);
			((UI_com_FormulaOem)(object)Popup.SelectedFormula.Formula).Render(_ampIdx.Value);
			Popup.SelectedFormula.FormulaName.Render(_ampIdx.Value, newLine: false);
		}
	}

	private void GoToSelectFormula()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_PostFormulaOemFilter.Name, new Dictionary<string, object> { { "OnSelectFormula", _updateSelectedFormula } });
	}

	private void InitBonus()
	{
		((GObject)Popup.ObtainImmediately).text = "----";
		RenderBonus();
	}

	private void UpdateBonus()
	{
		List<FormulaOemUiBonus> list = OemMission.AmplifierFormulaModel?.UiBonus;
		if (list != null && list.Any())
		{
			_bonusList.Clear();
			_bonusList.AddRange(list);
			((GObject)Popup.ObtainImmediately).text = Mathf.RoundToInt(_bonusList[_bonusList.Count - 1].Value).ToString();
			RenderBonus();
		}
	}

	private void RenderBonus()
	{
		Popup.PostBonus.numItems = LaterBonus.Count;
	}

	private void RenderPostBonus(int index, GObject obj)
	{
		if (!(obj is UI_com_PostFormulaOemBonus uI_com_PostFormulaOemBonus))
		{
			throw new Exception("UI_main_PostFormulaOem RenderPostBonus bonusUi is not UI_com_PostFormulaOemBonus");
		}
		FormulaOemUiBonus formulaOemUiBonus = LaterBonus[index];
		uI_com_PostFormulaOemBonus.BonusType.SetSelectedIndex(formulaOemUiBonus.BonusType);
		((GObject)uI_com_PostFormulaOemBonus.BonusValue).text = ((formulaOemUiBonus.Value <= 0f) ? "----" : Mathf.RoundToInt(formulaOemUiBonus.Value).ToString());
	}

	private void OnPostClick()
	{
		if (_ampIdx.HasValue)
		{
			Singleton<GvG3FlagshipReqManager>.Instance.PostFormulaOemMission(_ampIdx.Value, Popup.OemCount.UseCount, End);
		}
	}
}
