using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace UI.GvGWorldMap3;

public class UI_main_SuppressBonusLimitPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_SuppressBonusLimitDialog Dialog;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2mutrqb6sf8";

	public static string Name = "UI_main_SuppressBonusLimitPanel";

	public const string OnValueChangeCallbackKey = "OnValueChange";

	private Action _callback;

	public static string GetURL()
	{
		return "ui://4eq8fgd2mutrqb6sf8";
	}

	public static UI_main_SuppressBonusLimitPanel CreateInstance()
	{
		return (UI_main_SuppressBonusLimitPanel)(object)UIPackage.CreateObject("GvGWorldMap3", "main_SuppressBonusLimitPanel");
	}

	public static UI_main_SuppressBonusLimitPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SuppressBonusLimitPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mutrqb6sf8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_SuppressBonusLimitDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Dialog.DoNotShowAgain).onClick.Set(new EventCallback0(OnClickDoNotShowAgain));
		((GObject)Dialog.Exit).onClick.Set(new EventCallback0(End));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.DoNotShowAgain).onClick.Clear();
		((GObject)Dialog.Exit).onClick.Clear();
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters.TryGetValue("OnValueChange", out var value))
		{
			_callback = (Action)value;
		}
		bool selected = GameLocalDataManager.GetBool("ShowSuppressBonusLimit");
		((GButton)Dialog.DoNotShowAgain).selected = selected;
		string desc = LanguagesManager.GetDesc("OperationRebellionLimitTip");
		int dailyLimit = Singleton<WorldStateManager>.Instance.Data.DailySuppressBonusModel.GetDailyLimit();
		int value2 = DailySuppressBonusModel.LimitConfig.First().Value;
		((GObject)Dialog.n3).text = string.Format(desc, dailyLimit, value2);
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

	private void OnClickDoNotShowAgain()
	{
		GameLocalDataManager.SetBool("ShowSuppressBonusLimit", ((GButton)Dialog.DoNotShowAgain).selected);
		_callback?.Invoke();
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
