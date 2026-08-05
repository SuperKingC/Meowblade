using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.StellarKeyStore;

public class UI_main_StellarKeyCraftPopup : GComponent, IUiController
{
	public class CraftInfo
	{
		public string FormulaId;

		public KeyValuePair<string, int> Input;

		public KeyValuePair<string, int> Output;

		public UI_com_FormulaSlot Slot;

		public Vector2 OutputIconPos => ((GObject)Slot.OutputIcon).LocalToRoot(Vector2.zero, GRoot.inst);
	}

	public GGraph back;

	public UI_com_CraftDialog Dialog;

	public Transition t0;

	public const string URL = "ui://khops95lmclp1d";

	public static string Name = "UI_main_StellarKeyCraftPopup";

	private string[] FormulaIds;

	private UICallbackParam<Action<CraftInfo>> OnConfirmCraft;

	public static string GetURL()
	{
		return "ui://khops95lmclp1d";
	}

	public static UI_main_StellarKeyCraftPopup CreateInstance()
	{
		return (UI_main_StellarKeyCraftPopup)(object)UIPackage.CreateObject("StellarKeyStore", "main_StellarKeyCraftPopup");
	}

	public static UI_main_StellarKeyCraftPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_StellarKeyCraftPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95lmclp1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_CraftDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FormulaIds = GvG3StoreManager.StellarKeyStoreConfigData.FormulaIds;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		RenderFormulaList();
		OnConfirmCraft = (parameters.TryGetValue("OnConfirmCraft", out var value) ? ((UICallbackParam<Action<CraftInfo>>)value) : null);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
	}

	private void RenderFormulaList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.FormulaList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderFormulaItem(i, (UI_com_FormulaSlot)(object)o);
		};
		Dialog.FormulaList.numItems = FormulaIds.Length;
	}

	private void RenderFormulaItem(int i, UI_com_FormulaSlot slot)
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		string text = FormulaIds[i];
		GDEFormulaData gDEFormulaData = GDMgr.Get<GDEFormulaData>(text);
		if (gDEFormulaData == null)
		{
			ILRuntimeDebug.LogError("[UI_main_StellarKeyCraftPopup] 找不到 formulaId = " + text);
			return;
		}
		KeyValuePair<string, int> input = gDEFormulaData.Input.ToObject<Dictionary<string, int>>().First();
		FGUIManager.Instance.SetItemIconAndFrame(slot.InputIcon, input.Key, null, "", frameVisible: false);
		((GObject)slot.InputCount).text = $"{input.Value}";
		KeyValuePair<string, int> output = gDEFormulaData.Output.ToObject<Dictionary<string, int>>().First();
		FGUIManager.Instance.SetItemIconAndFrame(slot.OutputIcon, output.Key, null, "", frameVisible: false);
		((GObject)slot.OutputCount).text = $"{output.Value}";
		CraftInfo info = new CraftInfo
		{
			Slot = slot,
			FormulaId = text,
			Input = input,
			Output = output
		};
		((GObject)slot.ConfirmCraftBtn).onClick.Set((EventCallback0)delegate
		{
			OnConfirmCraft?.Callback?.Invoke(info);
		});
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}
}
