using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_UnlockPopup : GComponent, IUiController
{
	public GGraph back;

	public UI_Dialog ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9i0qy50";

	public static string Name = "UI_UnlockPopup";

	private List<string> textureList = new List<string>();

	private string itemId;

	private int _costValue;

	public static string GetURL()
	{
		return "ui://47lbpgx9i0qy50";
	}

	public static UI_UnlockPopup CreateInstance()
	{
		return (UI_UnlockPopup)(object)UIPackage.CreateObject("Tips", "UnlockPopup");
	}

	public static UI_UnlockPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9i0qy50", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_Dialog)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
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
		((GObject)this).sortingOrder = 1;
		GetInitData(parameters);
		MainUiRender();
	}

	public void OnShow()
	{
		showTip.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)ConfirmDialog.exitBtn).onClick.Add(new EventCallback0(End));
		((GObject)ConfirmDialog.RefreshCardBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)ConfirmDialog.exitBtn).onClick.Remove(new EventCallback0(End));
		((GObject)ConfirmDialog.RefreshCardBtn).onClick.Remove(new EventCallback0(End));
	}

	private void GetInitData(Dictionary<string, object> parameters)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		if (parameters != null && parameters.TryGetValue("Action", out var value))
		{
			Action action = value as Action;
			((GObject)ConfirmDialog.RefreshCardBtn).onClick.Add(new EventCallback0(action.Invoke));
		}
		else
		{
			End();
		}
		if (parameters != null && parameters.TryGetValue("ItemId", out var value2))
		{
			itemId = (string)value2;
		}
		else
		{
			End();
		}
		if (parameters != null && parameters.TryGetValue("CostNum", out var value3))
		{
			_costValue = (int)value3;
		}
		if (parameters != null && parameters.TryGetValue("CanUnlock", out var value4))
		{
			((GObject)ConfirmDialog.RefreshCardBtn).enabled = (bool)value4;
		}
		else
		{
			((GObject)ConfirmDialog.RefreshCardBtn).enabled = true;
		}
	}

	private void MainUiRender()
	{
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)ConfirmDialog.DialogMiddleContent.ConsumptionItem).GetChild("icon").asLoader, itemId, textureList);
		GComponent asCom = ((GComponent)ConfirmDialog.DialogMiddleContent.ConsumptionItem).GetChild("reqDesc").asCom;
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		string text = ((stock < _costValue) ? "#DC143C" : "#F6E2B2");
		string text2 = "#F6E2B2";
		GComponent asCom2 = asCom.GetChild("originPrice").asCom;
		((GObject)asCom2).SetSize(0f, 0f);
		((GObject)asCom2).visible = false;
		if (stock < _costValue)
		{
			((GObject)ConfirmDialog.RefreshCardBtn).enabled = false;
		}
		else
		{
			((GObject)ConfirmDialog.RefreshCardBtn).enabled = true;
		}
		int number = stock;
		GTextField asTextField = asCom.GetChild("curPrice").asTextField;
		((GObject)asTextField).text = $"[color={text}]{number.ShortNumberFormat()}[/color][color={text2}]/{_costValue}[/color]";
		((GObject)ConfirmDialog.DialogMiddleContent).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}
}
