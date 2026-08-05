using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Certification;

public class UI_CertificationWarningPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_CertificationWarningDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://56q48tcqjbid7";

	public static string Name = "UI_CertificationWarningPanel";

	public static string GetURL()
	{
		return "ui://56q48tcqjbid7";
	}

	public static UI_CertificationWarningPanel CreateInstance()
	{
		return (UI_CertificationWarningPanel)(object)UIPackage.CreateObject("Certification", "CertificationWarningPanel");
	}

	public static UI_CertificationWarningPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationWarningPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_CertificationWarningDialog)(object)((GComponent)this).GetChild("Dialog");
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
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 998;
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.confirmBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.confirmBtn).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		Application.Quit();
	}
}
