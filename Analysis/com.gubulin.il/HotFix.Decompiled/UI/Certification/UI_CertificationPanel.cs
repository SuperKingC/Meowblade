using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UI.Tips;

namespace UI.Certification;

public class UI_CertificationPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_CertificationTipDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://56q48tcqjbid4";

	public static string Name = "UI_CertificationPanel";

	public static string GetURL()
	{
		return "ui://56q48tcqjbid4";
	}

	public static UI_CertificationPanel CreateInstance()
	{
		return (UI_CertificationPanel)(object)UIPackage.CreateObject("Certification", "CertificationPanel");
	}

	public static UI_CertificationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_CertificationTipDialog)(object)((GComponent)this).GetChild("Dialog");
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
		((GObject)Dialog.goToCertificationBtn).onClick.Add(new EventCallback0(GoToCertificationEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.goToCertificationBtn).onClick.Remove(new EventCallback0(GoToCertificationEvent));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void GoToCertificationEvent()
	{
		UI_TakeItems.TakeItemsPanel?.End();
		End();
	}
}
