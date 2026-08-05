using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_main_ShowEfficiencyBuff : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_ExclamationMarkDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://4eq8fgd2bbvd4x";

	public static string Name = "UI_main_ShowEfficiencyBuff";

	public static string GetURL()
	{
		return "ui://4eq8fgd2bbvd4x";
	}

	public static UI_main_ShowEfficiencyBuff CreateInstance()
	{
		return (UI_main_ShowEfficiencyBuff)(object)UIPackage.CreateObject("GvGWorldMap3", "main_ShowEfficiencyBuff");
	}

	public static UI_main_ShowEfficiencyBuff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ShowEfficiencyBuff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bbvd4x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_com_ExclamationMarkDialog)(object)((GComponent)this).GetChild("Dialog");
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
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Width", out var value))
		{
			((GObject)Dialog).width = (float)value;
		}
		if (parameters.TryGetValue("Text", out var value2))
		{
			((GObject)Dialog.title).text = value2.ToString();
		}
		if (parameters.TryGetValue("Pos", out var value3))
		{
			((GObject)Dialog).xy = (Vector2)value3;
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
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
