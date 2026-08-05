using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_main_GvG3PostOEMMission : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_PostMyOEMMission PopUp;

	public Transition t0;

	public const string URL = "ui://tt2iq07onhzv16";

	public static string Name = "UI_main_GvG3PostOEMMission";

	private int _ampIdx;

	private bool _extraBonus;

	private OemMissionAmplifier _ampFormula;

	private List<KeyValuePair<string, int>> _consumeList = new List<KeyValuePair<string, int>>();

	private bool _isInvalid;

	private Action<int> _onSelect = delegate(int ampIdx)
	{
		SharedMessenger.Broadcast("ON_GVG3_AMP_FORMULAR_SELECTED", ampIdx);
	};

	public static string GetURL()
	{
		return "ui://tt2iq07onhzv16";
	}

	public static UI_main_GvG3PostOEMMission CreateInstance()
	{
		return (UI_main_GvG3PostOEMMission)(object)UIPackage.CreateObject("GvGExchange3", "main_GvG3PostOEMMission");
	}

	public static UI_main_GvG3PostOEMMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3PostOEMMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzv16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_PostMyOEMMission)(object)((GComponent)this).GetChild("PopUp");
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
		_isInvalid = false;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		TryReadSelectAmpIdx(parameters);
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.Post).onClick.Set(new EventCallback0(PostNewMission));
		((GObject)PopUp.Add).onClick.Set(new EventCallback0(UseExtraBonus));
		((GObject)PopUp.SelectedAmplifier).onClick.Set(new EventCallback0(OpenAllAmpFormulas));
		((GObject)PopUp.Help).onClick.Set(new EventCallback1(OnHelpClick));
		SharedMessenger.AddListener<int>("ON_GVG3_AMP_FORMULAR_SELECTED", ShowSelectedAmplifier);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.Post).onClick.Clear();
		((GObject)PopUp.Add).onClick.Clear();
		((GObject)PopUp.SelectedAmplifier).onClick.Clear();
		((GObject)PopUp.Help).onClick.Clear();
		SharedMessenger.RemoveListener<int>("ON_GVG3_AMP_FORMULAR_SELECTED", ShowSelectedAmplifier);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnHelpClick(EventContext context)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip((GObject)(object)PopUp.Help, eFairyGUITipDir.Left, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "GVGmode3_TIPS_1".ToLanguage();
		});
	}

	private void TryReadSelectAmpIdx(Dictionary<string, object> parameters)
	{
		if (parameters != null && parameters.TryGetValue("SelectFormulaAmpIdx", out var ampIdx))
		{
			Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
			{
				((GObject)PopUp.MissionDuration).text = "24";
				ShowSelectedAmplifier((int)ampIdx);
			});
		}
		else
		{
			Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(Renderer);
		}
	}

	private void Renderer()
	{
		PopUp.Selected.selectedIndex = 1;
		((GObject)PopUp.Post).enabled = false;
		((GObject)PopUp.MissionDuration).text = "24";
	}

	private void PostNewMission()
	{
		if (_isInvalid)
		{
			ILRequestHelper.ShowErrorCode(-9004);
			return;
		}
		Singleton<GvG3FlagshipReqManager>.Instance.PostSelfOemMission(_ampIdx, _extraBonus);
		End();
	}

	private void ShowSelectedAmplifier(int ampIdx)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		_ampIdx = ampIdx;
		((GObject)PopUp.Post).enabled = true;
		PopUp.Selected.selectedIndex = 0;
		PopUp.SelectedAmplifier.Selected.selectedIndex = 1;
		UI_com_AmplifierSlot amplifier = PopUp.SelectedAmplifier.Amplifier;
		RenderHelper_AmplifierIcon.RenderAmplifier(amplifier.AmplifierIcon, _ampIdx);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(amplifier.AffectedRange, _ampIdx);
		_ampFormula = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(_ampIdx);
		if (_ampFormula.Cost != null)
		{
			int baseCostValue = _ampFormula.Cost.BaseCostValue;
			((GObject)PopUp.Consumed).text = baseCostValue.ToString();
			int stock = GameManagers.Instance.StockController.GetStock("Gem");
			if (stock < baseCostValue)
			{
				PopUp.Consumed.color = Color.red;
			}
			FGUIManager.Instance.SetItemIconAndFrame(PopUp.Icon, _ampFormula.Cost.Base.ToList()[0].Key, null, "", frameVisible: false);
		}
		_consumeList = new List<KeyValuePair<string, int>>(_ampFormula.AmplifierFormulaModel.Input_Dict);
		RendererFormulaConsume();
	}

	private void RendererFormulaConsume()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		PopUp.ConsumedItems.itemRenderer = new ListItemRenderer(FormulaConsumeItem);
		PopUp.ConsumedItems.numItems = _consumeList.Count;
	}

	private void FormulaConsumeItem(int index, GObject obj)
	{
		if (obj is UI_com_ConsumedItem uI_com_ConsumedItem)
		{
			KeyValuePair<string, int> keyValuePair = _consumeList[index];
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_ConsumedItem.Icon, keyValuePair.Key, null, "", frameVisible: false);
			string key = keyValuePair.Key;
			int value = keyValuePair.Value;
			uI_com_ConsumedItem.Icon.InitMaterialIntroductionBtn(key);
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(key, includingGSStock: true);
			if (itemCount < value)
			{
				_isInvalid = true;
				uI_com_ConsumedItem.color.selectedIndex = 1;
			}
			else
			{
				uI_com_ConsumedItem.color.selectedIndex = 0;
			}
			((GObject)uI_com_ConsumedItem.Num).text = keyValuePair.Value.ToString();
		}
	}

	private void OpenAllAmpFormulas()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3OutsourcingAmplifier.Name, new Dictionary<string, object> { { "OnSelect", _onSelect } });
	}

	private void UseExtraBonus()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (_ampFormula != null)
		{
			_extraBonus = !_extraBonus;
			int num = ((_ampFormula.Cost != null) ? (_extraBonus ? (_ampFormula.Cost.ExtraCostValue + _ampFormula.Cost.BaseCostValue) : _ampFormula.Cost.BaseCostValue) : 0);
			((GObject)PopUp.Consumed).text = num.ToString();
			int stock = GameManagers.Instance.StockController.GetStock("Gem");
			if (stock < num)
			{
				PopUp.Consumed.color = Color.red;
			}
		}
	}
}
