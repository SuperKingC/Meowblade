using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_main_OpertionRebellionLimitPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_SilenceBuyConfirmDialog Dialog;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2iwfbqb6sez";

	public static string Name = "UI_main_OpertionRebellionLimitPanel";

	public const string ConfirmCallback = "ConfirmCallback";

	private Action _confirmCallback;

	public static string GetURL()
	{
		return "ui://4eq8fgd2iwfbqb6sez";
	}

	public static UI_main_OpertionRebellionLimitPanel CreateInstance()
	{
		return (UI_main_OpertionRebellionLimitPanel)(object)UIPackage.CreateObject("GvGWorldMap3", "main_OpertionRebellionLimitPanel");
	}

	public static UI_main_OpertionRebellionLimitPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_OpertionRebellionLimitPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2iwfbqb6sez", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Set(new EventCallback0(OnClickConfirm));
		((GObject)Dialog.back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Cancel).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Exit).onClick.Set(new EventCallback0(End));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.Confirm).onClick.Clear();
		((GObject)Dialog.back).onClick.Clear();
		((GObject)Dialog.Cancel).onClick.Clear();
		((GObject)Dialog.Exit).onClick.Clear();
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_confirmCallback = (Action)parameters["ConfirmCallback"];
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

	private void OnClickConfirm()
	{
		if (Dialog.DoNotShowAgain.button.selectedIndex == 1)
		{
			int timeStamp = DateTimeHelper.GetTimeStamp(DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0));
			GameLocalDataManager.SetInt("TipKey_GvgRebellionConfirmOperation", timeStamp);
		}
		_confirmCallback?.Invoke();
		End();
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
