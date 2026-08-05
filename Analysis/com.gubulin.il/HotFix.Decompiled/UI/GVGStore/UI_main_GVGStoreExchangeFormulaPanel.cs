using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace UI.GVGStore;

public class UI_main_GVGStoreExchangeFormulaPanel : GComponent, IUiController
{
	private class FormulaItemInfo
	{
		public int ItemIndex { get; set; }

		public int FormulaIndex { get; set; }
	}

	public GGraph Mask;

	public UI_com_ExchangeFormulasDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://fvc33k3gjsiib";

	public static string Name = "UI_main_GVGStoreExchangeFormulaPanel";

	private readonly List<string> _constMaterials = ConfigDataManager.ItemsByType[ItemType.GvGStoreStone];

	private readonly List<Formula> _freeFormulas = new List<Formula>(2);

	private int _selectInputIndex;

	private int _selectOutputIndex;

	private List<Formula> _limitedFormulas = new List<Formula>();

	private Coroutine _updateCountDownCoroutine;

	private readonly WaitForSeconds _waitOneSecond = new WaitForSeconds(1f);

	public static string GetURL()
	{
		return "ui://fvc33k3gjsiib";
	}

	public static UI_main_GVGStoreExchangeFormulaPanel CreateInstance()
	{
		return (UI_main_GVGStoreExchangeFormulaPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreExchangeFormulaPanel");
	}

	public static UI_main_GVGStoreExchangeFormulaPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreExchangeFormulaPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gjsiib", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_ExchangeFormulasDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
		if (_updateCountDownCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_updateCountDownCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_limitedFormulas = (parameters.TryGetValue("LimitedFormulas", out var value) ? (value as List<Formula>) : new List<Formula>());
		_freeFormulas.AddRange(ArchiveExtension_Formulas.GetFreeFormula());
		UpdateDialog();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.Close).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.Close).onClick.Remove(new EventCallback0(End));
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void UpdateDialog()
	{
		RenderMaterials();
		RenderFreeFormulas();
		RenderLimitedFormulas();
	}

	private void RenderMaterials()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.Materials.itemRenderer = new ListItemRenderer(RenderMaterial);
		Dialog.Materials.numItems = _constMaterials.Count;
	}

	private void RenderMaterial(int index, GObject obj)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		if (obj is UI_com_Material1 uI_com_Material)
		{
			string itemId = _constMaterials[index];
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_Material.Icon, itemId, null, "", frameVisible: false);
			((GObject)uI_com_Material.Num).text = GameManagers.Instance.StockController.GetStock(itemId).ToString();
			((GObject)uI_com_Material).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, 1);
			});
		}
	}

	private static int FreeFormulaInputLength(Formula formula)
	{
		return JsonHelper.ToObject<List<Dictionary<string, int>>>(formula.Input).Count;
	}

	private static int FreeFormulaOutputLength(Formula formula)
	{
		return JsonHelper.ToObject<List<Dictionary<string, int>>>(formula.Output).Count;
	}

	private void RenderFreeFormulas()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.FreeFormulas.itemRenderer = new ListItemRenderer(RenderFreeFormula);
		Dialog.FreeFormulas.numItems = _freeFormulas.Count;
	}

	private void RenderFreeFormula(int index, GObject obj)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		if (!(obj is UI_com_FormulaFreeExchange uI_com_FormulaFreeExchange))
		{
			return;
		}
		Formula formula = _freeFormulas[index];
		uI_com_FormulaFreeExchange.Init(index, ChangeOtherExchangeUiState);
		uI_com_FormulaFreeExchange.Input.Type.selectedIndex = 0;
		RenderFreeFormulaItems(formula.GetInputList(0), uI_com_FormulaFreeExchange.Input.Input);
		uI_com_FormulaFreeExchange.Input.Formulas.RemoveChildrenToPool();
		int num = FreeFormulaInputLength(formula);
		for (int i = 0; i < num; i++)
		{
			if (uI_com_FormulaFreeExchange.Input.Formulas.AddItemFromPool() is UI_com_FormulaFreeExchangeInputItems uI_com_FormulaFreeExchangeInputItems)
			{
				RenderFreeFormulaItems(formula.GetInputList(i), uI_com_FormulaFreeExchangeInputItems.Items);
				((GObject)uI_com_FormulaFreeExchangeInputItems).data = new FormulaItemInfo
				{
					ItemIndex = i,
					FormulaIndex = index
				};
				((GObject)uI_com_FormulaFreeExchangeInputItems).onClick.Set(new EventCallback1(SelectFreeFormulaInput));
			}
		}
		uI_com_FormulaFreeExchange.Input.Formulas.ResizeToFit(num);
		uI_com_FormulaFreeExchange.Output.Type.selectedIndex = 0;
		RenderFreeFormulaItems(formula.GetOutputList(0), uI_com_FormulaFreeExchange.Output.Input);
		uI_com_FormulaFreeExchange.Output.Formulas.RemoveChildrenToPool();
		int num2 = FreeFormulaOutputLength(formula);
		for (int j = 0; j < num2; j++)
		{
			if (uI_com_FormulaFreeExchange.Output.Formulas.AddItemFromPool() is UI_com_FormulaFreeExchangeInputItems uI_com_FormulaFreeExchangeInputItems2)
			{
				RenderFreeFormulaItems(formula.GetOutputList(j), uI_com_FormulaFreeExchangeInputItems2.Items);
				((GObject)uI_com_FormulaFreeExchangeInputItems2).data = new FormulaItemInfo
				{
					ItemIndex = j,
					FormulaIndex = index
				};
				((GObject)uI_com_FormulaFreeExchangeInputItems2).onClick.Set(new EventCallback1(SelectFreeFormulaOutput));
			}
		}
		uI_com_FormulaFreeExchange.Output.Formulas.ResizeToFit(num2);
		((GObject)uI_com_FormulaFreeExchange.Exchange).enabled = formula.CanUse(_selectInputIndex) && FreeExchangeFormulaIllegal(formula);
		((GObject)uI_com_FormulaFreeExchange.Exchange).data = formula.FormulaId;
		((GObject)uI_com_FormulaFreeExchange.Exchange).onClick.Set(new EventCallback1(UseFreeFormula));
	}

	private void ChangeOtherExchangeUiState(int index)
	{
		for (int i = 0; i < ((GComponent)Dialog.FreeFormulas).numChildren; i++)
		{
			if (i != index && ((GComponent)Dialog.FreeFormulas).GetChildAt(i) is UI_com_FormulaFreeExchange uI_com_FormulaFreeExchange)
			{
				uI_com_FormulaFreeExchange.Collapse();
			}
		}
	}

	private bool FreeExchangeFormulaIllegal(Formula freeFormula)
	{
		string text = freeFormula.GetInputList(_selectInputIndex)?[0];
		string text2 = freeFormula.GetOutputList(_selectOutputIndex)?[0];
		return text != text2;
	}

	private static void RenderFreeFormulaItems(List<string> items, GList list)
	{
		list.RemoveChildrenToPool();
		for (int i = 0; i < items.Count; i++)
		{
			if (list.AddItemFromPool() is UI_com_Material0 uI_com_Material)
			{
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Material.Icon, items[i], null, "", frameVisible: false);
			}
		}
		list.ResizeToFit(items.Count);
	}

	private void SelectFreeFormulaInput(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		if (((GObject)context.sender).data is FormulaItemInfo formulaItemInfo && ((GComponent)Dialog.FreeFormulas).GetChildAt(formulaItemInfo.FormulaIndex) is UI_com_FormulaFreeExchange uI_com_FormulaFreeExchange)
		{
			_selectInputIndex = formulaItemInfo.ItemIndex;
			Formula formula = _freeFormulas[formulaItemInfo.FormulaIndex];
			RenderFreeFormulaItems(formula.GetInputList(_selectInputIndex), uI_com_FormulaFreeExchange.Input.Input);
			uI_com_FormulaFreeExchange.Input.Type.selectedIndex = 0;
			((GObject)uI_com_FormulaFreeExchange.Exchange).enabled = formula.CanUse(_selectInputIndex) && FreeExchangeFormulaIllegal(formula);
		}
	}

	private void SelectFreeFormulaOutput(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		if (((GObject)context.sender).data is FormulaItemInfo formulaItemInfo && ((GComponent)Dialog.FreeFormulas).GetChildAt(formulaItemInfo.FormulaIndex) is UI_com_FormulaFreeExchange uI_com_FormulaFreeExchange)
		{
			_selectOutputIndex = formulaItemInfo.ItemIndex;
			Formula formula = _freeFormulas[formulaItemInfo.FormulaIndex];
			RenderFreeFormulaItems(formula.GetOutputList(_selectOutputIndex), uI_com_FormulaFreeExchange.Output.Input);
			uI_com_FormulaFreeExchange.Output.Type.selectedIndex = 0;
			((GObject)uI_com_FormulaFreeExchange.Exchange).enabled = formula.CanUse(_selectInputIndex) && FreeExchangeFormulaIllegal(formula);
		}
	}

	private void UseFreeFormula(EventContext context)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		string formulaId = ((GObject)context.sender).data.ToString();
		Formula freeFormula = _freeFormulas.Find((Formula f) => f.FormulaId == formulaId);
		if (freeFormula != null)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreExchangeConfirmPanel.Name, new Dictionary<string, object>
			{
				{
					"InputData",
					freeFormula.GetInputList(_selectInputIndex)
				},
				{
					"OutputData",
					freeFormula.GetOutputList(_selectOutputIndex)
				},
				{
					"ConfirmExchange",
					CreateConfirmAction()
				}
			});
		}
		Action CreateConfirmAction()
		{
			return delegate
			{
				GameManagers.Instance.UserArchiveManager.UseFormula(freeFormula, UpdateUi, _selectInputIndex, _selectOutputIndex);
			};
		}
		void UpdateExchangeEnabled()
		{
			int num = _freeFormulas.IndexOf(freeFormula);
			for (int i = 0; i < ((GComponent)Dialog.FreeFormulas).numChildren; i++)
			{
				if (i == num && ((GComponent)Dialog.FreeFormulas).GetChildAt(i) is UI_com_FormulaFreeExchange uI_com_FormulaFreeExchange)
				{
					((GObject)uI_com_FormulaFreeExchange.Exchange).enabled = freeFormula.CanUse(_selectInputIndex) && FreeExchangeFormulaIllegal(freeFormula);
				}
			}
		}
		void UpdateUi()
		{
			RenderMaterials();
			UpdateExchangeEnabled();
		}
	}

	private void RenderLimitedFormulas()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.LimitedFormulas.itemRenderer = new ListItemRenderer(RenderLimitedFormula);
		Dialog.LimitedFormulas.numItems = _limitedFormulas.Count;
		if (_updateCountDownCoroutine == null)
		{
			_updateCountDownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCountDown());
		}
	}

	private IEnumerator UpdateCountDown()
	{
		string tipText = LanguagesManager.GetDesc("GvGLimitedFormulasRefreshCountDown");
		while (true)
		{
			((GObject)Dialog.UpdateTime).text = tipText.Format(new object[1] { GetRefreshCountDown() ?? "" });
			yield return _waitOneSecond;
		}
	}

	private static string GetRefreshCountDown()
	{
		int num = ArchiveExtension_Formulas.LimitedFormulaRefreshTimestamp - (int)GameController.Instance.GetServerTime();
		return (num > 86400) ? string.Format("{0}{1}", num / 86400, "Time_Day".ToLanguage()) : UiHelper.ParseTime(num);
	}

	private void RenderLimitedFormula(int index, GObject obj)
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		if (!(obj is UI_com_FormulaLimitedExchange uI_com_FormulaLimitedExchange))
		{
			return;
		}
		Formula formula = _limitedFormulas[index];
		uI_com_FormulaLimitedExchange.Input.RemoveChildrenToPool();
		List<string> inputList = formula.GetInputList();
		for (int i = 0; i < inputList.Count; i++)
		{
			if (uI_com_FormulaLimitedExchange.Input.AddItemFromPool() is UI_com_Material0 uI_com_Material)
			{
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Material.Icon, inputList[i], null, "", frameVisible: false);
			}
		}
		uI_com_FormulaLimitedExchange.Output.RemoveChildrenToPool();
		List<string> outputList = formula.GetOutputList();
		for (int j = 0; j < outputList.Count; j++)
		{
			if (uI_com_FormulaLimitedExchange.Output.AddItemFromPool() is UI_com_Material0 uI_com_Material2)
			{
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Material2.Icon, outputList[j], null, "", frameVisible: false);
			}
		}
		((GObject)uI_com_FormulaLimitedExchange.Exchange).enabled = formula.CanUse();
		((GObject)uI_com_FormulaLimitedExchange.Exchange).data = index;
		((GObject)uI_com_FormulaLimitedExchange.Exchange).onClick.Set(new EventCallback1(UseLimitedFormula));
	}

	private void UseLimitedFormula(EventContext eventContext)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)eventContext.sender).data;
		Formula formula = _limitedFormulas[index];
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreExchangeConfirmPanel.Name, new Dictionary<string, object>
		{
			{
				"InputData",
				formula.GetInputList()
			},
			{
				"OutputData",
				formula.GetOutputList()
			},
			{
				"ConfirmExchange",
				Action()
			}
		});
		Action Action()
		{
			return delegate
			{
				GameManagers.Instance.UserArchiveManager.UseFormula(formula, UpdateUi);
			};
		}
		void UpdateUi()
		{
			RenderMaterials();
			RenderLimitedFormulas();
		}
	}
}
