using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_ExclamationMarkPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_ExclamationMarkDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://47lbpgx9fq9e38";

	public static string Name = "UI_ExclamationMarkPanel";

	public static string GetURL()
	{
		return "ui://47lbpgx9fq9e38";
	}

	public static UI_ExclamationMarkPanel CreateInstance()
	{
		return (UI_ExclamationMarkPanel)(object)UIPackage.CreateObject("Tips", "ExclamationMarkPanel");
	}

	public static UI_ExclamationMarkPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExclamationMarkPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9fq9e38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_ExclamationMarkDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 200;
		if (parameters.TryGetValue("Width", out var value))
		{
			((GObject)Dialog).width = (float)value;
		}
		if (parameters.TryGetValue("Title", out var value2))
		{
			((GObject)Dialog.title).text = value2.ToString();
		}
		if (parameters.TryGetValue("Content1", out var value3))
		{
			((GObject)Dialog.content1).text = value3.ToString();
		}
		if (parameters.TryGetValue("Content2", out var value4))
		{
			((GObject)Dialog.content2).text = value4.ToString();
		}
		if (parameters.TryGetValue("Pos", out var value5))
		{
			((GObject)Dialog).xy = (Vector2)value5;
		}
	}

	public void OnShow()
	{
		ShowDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
