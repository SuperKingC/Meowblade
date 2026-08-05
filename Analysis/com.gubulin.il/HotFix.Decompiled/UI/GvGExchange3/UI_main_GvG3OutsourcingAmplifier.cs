using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Services;

namespace UI.GvGExchange3;

public class UI_main_GvG3OutsourcingAmplifier : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_Amplifiers Content;

	public const string URL = "ui://tt2iq07odwxt7";

	public static string Name = "UI_main_GvG3OutsourcingAmplifier";

	private Action<int> _onSelect;

	private UI_btn_AmpFormula curChoosed = null;

	private int curChoosedAmpIdx = -1;

	private readonly List<int> _ampIdx = new List<int>(411);

	private readonly List<int> _matchAmps = new List<int>(411);

	private int _selectedAmpIdx;

	public static string GetURL()
	{
		return "ui://tt2iq07odwxt7";
	}

	public static UI_main_GvG3OutsourcingAmplifier CreateInstance()
	{
		return (UI_main_GvG3OutsourcingAmplifier)(object)UIPackage.CreateObject("GvGExchange3", "main_GvG3OutsourcingAmplifier");
	}

	public static UI_main_GvG3OutsourcingAmplifier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3OutsourcingAmplifier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxt7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Content = (UI_com_Amplifiers)(object)((GComponent)this).GetChild("Content");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		curChoosed = null;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters != null && parameters.TryGetValue("OnSelect", out var value))
		{
			_onSelect = (Action<int>)value;
		}
		Content.AmplifierList.SetVirtual();
		Content.AmplifierList.itemRenderer = new ListItemRenderer(RenderAmplifierSlot);
		LoadAllAmpsIdx();
		Content.IsEmpty.selectedIndex = 0;
		Content.Selected.selectedIndex = 0;
		Content.FilterDialog.Init();
		OnChangeFilter();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Content.Confirm).onClick.Set(new EventCallback0(SelectAmp));
		((GObject)Content.Close).onClick.Set(new EventCallback0(ClosePanel));
		Content.FilterDialog.RegisterUiEvent();
		UI_com_AmplifierFilter filterDialog = Content.FilterDialog;
		filterDialog.OnFilterChange = (Action)Delegate.Combine(filterDialog.OnFilterChange, new Action(OnChangeFilter));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Content.Confirm).onClick.Clear();
		((GObject)Content.Close).onClick.Clear();
		Content.FilterDialog.UnregisterUiEvent();
		UI_com_AmplifierFilter filterDialog = Content.FilterDialog;
		filterDialog.OnFilterChange = (Action)Delegate.Remove(filterDialog.OnFilterChange, new Action(OnChangeFilter));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void SelectAmp()
	{
		_onSelect?.Invoke(_selectedAmpIdx);
		End();
	}

	private void ClosePanel()
	{
		End();
	}

	private void LoadAllAmpsIdx()
	{
		foreach (KeyValuePair<string, string> item in OemMissionAmplifierConfigHelper.AmpFormulaConfig)
		{
			_ampIdx.Add(int.Parse(item.Key));
		}
		_matchAmps.AddRange(_ampIdx);
	}

	private void OnChangeFilter()
	{
		if (_ampIdx != null)
		{
			_matchAmps.Clear();
			_matchAmps.AddRange(AmpConfigHelper.FilterAmplifiers(_ampIdx, Content.FilterDialog.SelectedQuality, Content.FilterDialog.SelectedRace, Content.FilterDialog.SelectedSoldierId, Content.FilterDialog.SelectedModifier));
			Content.IsEmpty.selectedIndex = ((_ampIdx.Count != _matchAmps.Count) ? 1 : 0);
			Update();
		}
	}

	private void Update()
	{
		Content.AmplifierList.numItems = _matchAmps.Count;
	}

	private void RenderAmplifierSlot(int i, GObject obj)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		if (obj is UI_btn_AmpFormula uI_btn_AmpFormula)
		{
			int num = _matchAmps[i];
			RenderHelper_AmplifierIcon.RenderAmplifier(uI_btn_AmpFormula.Amp.AmplifierIcon, num);
			RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_btn_AmpFormula.Amp.AffectedRange, num);
			((GObject)uI_btn_AmpFormula).data = num;
			if (curChoosedAmpIdx == (int)((GObject)uI_btn_AmpFormula).data)
			{
				ChoosedAmpFormula(uI_btn_AmpFormula);
			}
			else
			{
				uI_btn_AmpFormula.button.selectedIndex = 0;
			}
			((GObject)uI_btn_AmpFormula).onClick.Set(new EventCallback1(OnClickItem));
		}
	}

	private void OnClickItem(EventContext context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		int idx = (_selectedAmpIdx = (int)((GObject)context.sender).data);
		Content.Selected.selectedIndex = 1;
		OemMissionAmplifier oemMissionAmplifier = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(_selectedAmpIdx);
		RenderHelper_AmplifierIcon.RenderAmplifier(Content.SelectedAmplifier.AmplifierIcon, idx);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(Content.SelectedAmplifier.AffectedRange, idx);
		List<KeyValuePair<string, float>> descList = oemMissionAmplifier.AmplifierModel.Desc.ToList();
		Content.PropList.itemRenderer = new ListItemRenderer(AmplifierPropRenderer);
		Content.PropList.numItems = descList.Count;
		Content.PropList.ResizeToFit(Content.PropList.numItems);
		((GObject)Content.AmpName).text = oemMissionAmplifier.AmplifierModel.Name;
		ChoosedAmpFormula((UI_btn_AmpFormula)(GObject)context.sender);
		void AmplifierPropRenderer(int index, GObject obj)
		{
			if (obj is UI_com_PropItemShort uI_com_PropItemShort)
			{
				KeyValuePair<string, float> keyValuePair = descList[index];
				if (keyValuePair.Key.Contains("{"))
				{
					((GObject)uI_com_PropItemShort.PropName).text = string.Format(keyValuePair.Key, keyValuePair.Value);
					((GObject)uI_com_PropItemShort.PropEffect).text = "";
				}
				else
				{
					((GObject)uI_com_PropItemShort.PropName).text = keyValuePair.Key;
					((GObject)uI_com_PropItemShort.PropEffect).text = $"{keyValuePair.Value}";
				}
			}
		}
	}

	private void ChoosedAmpFormula(UI_btn_AmpFormula slot)
	{
		if (slot == null || ((GObject)slot).isDisposed)
		{
			curChoosedAmpIdx = -1;
			curChoosed = null;
			return;
		}
		if (curChoosed != null)
		{
			curChoosed.button.selectedIndex = 0;
		}
		curChoosed = slot;
		curChoosed.button.selectedIndex = 1;
		curChoosedAmpIdx = (int)((GObject)slot).data;
	}
}
