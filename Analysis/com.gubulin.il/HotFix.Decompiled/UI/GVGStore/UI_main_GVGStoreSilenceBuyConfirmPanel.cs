using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace UI.GVGStore;

public class UI_main_GVGStoreSilenceBuyConfirmPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_SilenceBuyConfirmDialog Dialog;

	public Transition t0;

	public const string URL = "ui://fvc33k3gxwkg3f";

	public static string Name = "UI_main_GVGStoreSilenceBuyConfirmPanel";

	private ArchiveExtension_Formulas.ConfirmBuyStoreItem _storeItem;

	public static string GetURL()
	{
		return "ui://fvc33k3gxwkg3f";
	}

	public static UI_main_GVGStoreSilenceBuyConfirmPanel CreateInstance()
	{
		return (UI_main_GVGStoreSilenceBuyConfirmPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreSilenceBuyConfirmPanel");
	}

	public static UI_main_GVGStoreSilenceBuyConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreSilenceBuyConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gxwkg3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_SilenceBuyConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
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
				GameLocalDataManager.SetGvgStoreConfirmBuyItemDontShowAgainUntil(timeStamp);
			}
			GameManagers.Instance.UserArchiveManager.UseFormula(_storeItem.Formula, UpdateUi, 0, 0, _storeItem.ItemId, _storeItem.Index);
		});
		((GObject)Dialog.Cancel).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Exit).onClick.Set(new EventCallback0(End));
		static void UpdateUi()
		{
			SharedMessenger.Broadcast("UPDATE_GVG_STORE_ITEMS", arg1: false);
			End();
		}
	}

	public void UnregisterUiEventListeners()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_storeItem = (parameters.TryGetValue("StoreItem", out var value) ? (value as ArchiveExtension_Formulas.ConfirmBuyStoreItem) : null);
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
