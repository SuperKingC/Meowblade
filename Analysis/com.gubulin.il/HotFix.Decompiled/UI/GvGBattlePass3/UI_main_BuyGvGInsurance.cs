using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;

namespace UI.GvGBattlePass3;

public class UI_main_BuyGvGInsurance : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BuyGvGinsurance Dialog;

	public const string URL = "ui://bfjg32hujljf6j";

	public static string Name = "UI_main_BuyGvGInsurance";

	private const string UI_CONTROLLER_NAME = "State";

	private const string BUY_ADVANCED_BATTLE_PASS_ACTION = "Action";

	private Action _buyAdvancedBattlePass;

	public static string GetURL()
	{
		return "ui://bfjg32hujljf6j";
	}

	public static UI_main_BuyGvGInsurance CreateInstance()
	{
		return (UI_main_BuyGvGInsurance)(object)UIPackage.CreateObject("GvGBattlePass3", "main_BuyGvGInsurance");
	}

	public static UI_main_BuyGvGInsurance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BuyGvGInsurance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hujljf6j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_BuyGvGinsurance)(object)((GComponent)this).GetChild("Dialog");
	}

	public static void OpenBuyGvGInsurancePanel(bool isAdvanced, Action buy)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
		{
			{
				"State",
				isAdvanced ? 1 : 0
			},
			{ "Action", buy }
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Buy).onClick.Set(new EventCallback0(OnBuyClick));
		((GObject)Dialog.Check).onClick.Set(new EventCallback0(OnCheckClick));
		SharedMessenger.AddListener("ON_GVG3_BATTLE_PASS_UPGRADE_ADVANCED", OnAdvancedBattlePassPaid);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)Dialog.Buy).onClick.Clear();
		((GObject)Dialog.Check).onClick.Clear();
		SharedMessenger.RemoveListener("ON_GVG3_BATTLE_PASS_UPGRADE_ADVANCED", OnAdvancedBattlePassPaid);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		Dialog.State.SetSelectedIndex((int)parameters["State"]);
		_buyAdvancedBattlePass = (Action)parameters["Action"];
	}

	public void OnShow()
	{
		int battlePassInsuranceTimes = Singleton<WorldStateManager>.Instance.Data.BattlePassInsuranceTimes;
		((GObject)Dialog.RemainingCnt).visible = battlePassInsuranceTimes != -1;
		((GObject)Dialog.RemainingCnt).text = string.Format(LanguagesManager.GetDesc("VoidBrawlInsuranceCnt"), battlePassInsuranceTimes);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		_buyAdvancedBattlePass = null;
	}

	private void OnAdvancedBattlePassPaid()
	{
		Dialog.State.SetSelectedIndex(1);
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnBuyClick()
	{
		_buyAdvancedBattlePass?.Invoke();
	}

	private static void OnCheckClick()
	{
		int insuranceIslandId = GetInsuranceIslandId();
		Singleton<GvGIslandFilterManager>.Instance.FocusIslandAndTryOpenIslandCard(insuranceIslandId);
		SharedMessenger.Broadcast("ON_GVG3_CHECK_INSURANCE_ISLAND");
		End();
	}

	private static int GetInsuranceIslandId()
	{
		int campProgress = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress;
		return GvG3InsuranceHelper.GetInsuranceIslandId(campProgress);
	}
}
