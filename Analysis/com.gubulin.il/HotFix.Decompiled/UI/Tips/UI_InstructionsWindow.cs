using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_InstructionsWindow : GComponent, IUiController
{
	public GGraph mask;

	public UI_InstructionsDialog InstructionsDialog;

	public Transition showDialog;

	public const string URL = "ui://47lbpgx9neyg16";

	public static string Name = "UI_InstructionsWindow";

	public List<string> TipList = new List<string>();

	public static string GetURL()
	{
		return "ui://47lbpgx9neyg16";
	}

	public static UI_InstructionsWindow CreateInstance()
	{
		return (UI_InstructionsWindow)(object)UIPackage.CreateObject("Tips", "InstructionsWindow");
	}

	public static UI_InstructionsWindow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InstructionsWindow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9neyg16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		InstructionsDialog = (UI_InstructionsDialog)(object)((GComponent)this).GetChild("InstructionsDialog");
		showDialog = ((GComponent)this).GetTransition("showDialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (!parameters.ContainsKey("TipText"))
		{
			Debug.LogWarning((object)"未包含文本提示");
			End();
		}
		else
		{
			TipList.Clear();
			TipList = (List<string>)parameters["TipText"];
			SetTipText();
			if (parameters.ContainsKey("Order"))
			{
				((GObject)this).sortingOrder = (int)parameters["Order"];
			}
			else
			{
				((GObject)this).sortingOrder = 1;
			}
			if (parameters.ContainsKey("ShowMask"))
			{
				((GObject)mask).visible = (bool)parameters["ShowMask"];
				((GObject)mask).touchable = (bool)parameters["ShowMask"];
			}
			else
			{
				((GObject)mask).visible = true;
				((GObject)mask).touchable = true;
			}
		}
		showDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(MaskClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(MaskClick));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void MaskClick()
	{
		End();
	}

	private void SetTipText()
	{
		if (TipList.Count == 0)
		{
			return;
		}
		((GObject)InstructionsDialog.instructions).text = "";
		for (int i = 0; i < TipList.Count; i++)
		{
			if (i < TipList.Count - 1)
			{
				GTextField instructions = InstructionsDialog.instructions;
				((GObject)instructions).text = ((GObject)instructions).text + TipList[i] + Environment.NewLine;
			}
			else
			{
				GTextField instructions2 = InstructionsDialog.instructions;
				((GObject)instructions2).text = ((GObject)instructions2).text + TipList[i];
			}
		}
	}
}
