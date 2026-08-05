using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GVGStore;

public class UI_main_GVGStoreSilenceConfilmPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_SilenceConfilmDialog Dialog;

	public Transition t0;

	public const string URL = "ui://fvc33k3gwzfo38";

	public static string Name = "UI_main_GVGStoreSilenceConfilmPanel";

	private bool _hasRareStoreItem;

	public static string GetURL()
	{
		return "ui://fvc33k3gwzfo38";
	}

	public static UI_main_GVGStoreSilenceConfilmPanel CreateInstance()
	{
		return (UI_main_GVGStoreSilenceConfilmPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreSilenceConfilmPanel");
	}

	public static UI_main_GVGStoreSilenceConfilmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreSilenceConfilmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gwzfo38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_SilenceConfilmDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Set((EventCallback0)delegate
		{
			if (Dialog.DoNotShowAgain.button.selectedIndex == 1)
			{
				int timeStamp = DateTimeHelper.GetTimeStamp(DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0));
				GameLocalDataManager.SetGvgStoreConfirmActivateDontShowAgainUntil(timeStamp);
			}
			if (_hasRareStoreItem)
			{
				Action value = delegate
				{
					End();
				};
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreRareStoreItemRefreshConfirmPanel.Name, new Dictionary<string, object> { { "OnClickConfirm", value } });
			}
			else
			{
				SharedMessenger.Broadcast("UPDATE_GVG_STORE_ITEMS", arg1: true);
				End();
			}
		});
		((GObject)Dialog.Cancel).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Exit).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_hasRareStoreItem = (bool)parameters["HasRareItem"];
		if (parameters.TryGetValue("ReplaceTitle", out var value))
		{
			((GObject)Dialog.n2).text = (string)value;
		}
		if (parameters.TryGetValue("ReplaceDes", out var value2))
		{
			((GObject)Dialog.n3).text = (string)value2;
		}
	}

	public void OnShow()
	{
		t0.Play();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
