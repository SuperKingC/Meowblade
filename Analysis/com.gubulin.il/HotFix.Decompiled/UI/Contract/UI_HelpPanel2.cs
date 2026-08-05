using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_HelpPanel2 : GComponent, IUiController
{
	public GGraph Mask;

	public UI_HelpDialog2 Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://avplaivdt47atog";

	public static string Name = "UI_HelpPanel2";

	public const string PageIndex = "PageIndex";

	public static string GetURL()
	{
		return "ui://avplaivdt47atog";
	}

	public static UI_HelpPanel2 CreateInstance()
	{
		return (UI_HelpPanel2)(object)UIPackage.CreateObject("Contract", "HelpPanel2");
	}

	public static UI_HelpPanel2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpPanel2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdt47atog", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_HelpDialog2)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters.TryGetValue("PageIndex", out var value))
		{
			Dialog.Type.SetSelectedIndex((int)value);
		}
		else
		{
			Dialog.Type.SetSelectedIndex(0);
		}
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

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
