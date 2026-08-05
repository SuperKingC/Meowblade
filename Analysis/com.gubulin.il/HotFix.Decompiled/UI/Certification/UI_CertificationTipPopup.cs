using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.Common.Services;

namespace UI.Certification;

public class UI_CertificationTipPopup : GComponent, IUiController
{
	public GGraph Mask;

	public UI_CertificationDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://56q48tcqm13tj";

	public static string Name = "UI_CertificationTipPopup";

	public static string GetURL()
	{
		return "ui://56q48tcqm13tj";
	}

	public static UI_CertificationTipPopup CreateInstance()
	{
		return (UI_CertificationTipPopup)(object)UIPackage.CreateObject("Certification", "CertificationTipPopup");
	}

	public static UI_CertificationTipPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationTipPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_CertificationDialog)(object)((GComponent)this).GetChild("Dialog");
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
		if (GameController.FSM == "2")
		{
			((GObject)Dialog.experience).visible = false;
		}
		if (parameters == null)
		{
			End();
			return;
		}
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Type", out var value))
		{
			int selectedIndex = (int)value;
			Dialog.Type.selectedIndex = selectedIndex;
			if (parameters.TryGetValue("Text", out var value2))
			{
				((GObject)Dialog.content).text = value2.ToString();
			}
			if (Dialog.Type.selectedIndex == 0 || Dialog.Type.selectedIndex == 1)
			{
				Dialog.SetControllerPageText();
			}
		}
		else
		{
			End();
		}
	}

	public void OnShow()
	{
		if (Dialog.Type.selectedIndex == 2)
		{
			if (GameController.Configs.TryGetValue("CustomerServiceOnline", out var value) && value == "1")
			{
				((GObject)Dialog.CustomerServiceBtn).visible = true;
			}
			else
			{
				((GObject)Dialog.CustomerServiceBtn).visible = false;
			}
		}
		ShowDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		((GObject)Dialog.experience).onClick.Add(new EventCallback0(ContinueExperience));
		((GObject)Dialog.certification).onClick.Add(new EventCallback0(GoToCertification));
		((GObject)Dialog.CustomerServiceBtn).data = "实名认证界面";
		((GObject)Dialog.CustomerServiceBtn).onClick.Add(new EventCallback1(UiHelper.CustomerServiceOnlineClickLink));
		((GObject)Dialog.exitBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)Dialog.experience).onClick.Remove(new EventCallback0(ContinueExperience));
		((GObject)Dialog.certification).onClick.Remove(new EventCallback0(GoToCertification));
		((GObject)Dialog.CustomerServiceBtn).onClick.Remove(new EventCallback1(UiHelper.CustomerServiceOnlineClickLink));
		((GObject)Dialog.exitBtn).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void GoToCertification()
	{
		int num = 0;
		int todayPlayTime = CertificationHelper.GetTodayPlayTime();
		if (todayPlayTime >= 3600)
		{
			num = 1;
		}
		Dictionary<string, object> parameters = new Dictionary<string, object> { { "Type", num } };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationMainPanel.Name, parameters);
		End();
	}

	private void ContinueExperience()
	{
		End();
	}

	private void QuitGame()
	{
		End();
		HotFix_Utils.Restart();
	}
}
