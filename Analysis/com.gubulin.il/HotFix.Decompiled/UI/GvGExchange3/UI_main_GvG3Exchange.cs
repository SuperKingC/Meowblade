using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.Exchange;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace UI.GvGExchange3;

public class UI_main_GvG3Exchange : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_Exchange ExchangeContent;

	public const string URL = "ui://tt2iq07odwxt0";

	public static string Name = "UI_main_GvG3Exchange";

	private readonly FlagReqAutoRefreshTimer _refreshTimer = new FlagReqAutoRefreshTimer();

	public static string GetURL()
	{
		return "ui://tt2iq07odwxt0";
	}

	public static UI_main_GvG3Exchange CreateInstance()
	{
		return (UI_main_GvG3Exchange)(object)UIPackage.CreateObject("GvGExchange3", "main_GvG3Exchange");
	}

	public static UI_main_GvG3Exchange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3Exchange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxt0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		ExchangeContent = (UI_com_Exchange)(object)((GComponent)this).GetChild("ExchangeContent");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		ExchangeContent.FlagshipReq.Destroy();
		ExchangeContent.OEMMissions.Destroy();
		ExchangeContent.PostOEMMission.Destroy();
		ExchangeContent.FormulaOemMissions.Destroy();
		ExchangeContent.PostFormulaMissions.Destroy();
		ExchangeContent.FormulaMissionsFilter.Destroy();
		_refreshTimer.OnDestroy();
		Singleton<GvG3FlagshipReqManager>.Instance.Destroy();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		Singleton<GvG3FlagshipReqManager>.Instance.Init();
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			_refreshTimer.Init(RefreshFlagReq);
			ExchangeContent.FlagshipReq.Init();
			ExchangeContent.OEMMissions.Init();
			ExchangeContent.PostOEMMission.Init();
			ExchangeContent.FormulaOemMissions.Init(DisplayFormulaMissionsFilter);
			ExchangeContent.PostFormulaMissions.Init();
			ExchangeContent.FormulaMissionsFilter.Init(new Dictionary<string, object>
			{
				{
					"FormulaOemFilter",
					ExchangeContent.FormulaOemMissions.GetOemMissionsRequest.Filter
				},
				{
					"FilterChangeAction",
					ExchangeContent.FormulaOemMissions.OnFilterChange
				}
			});
			ExchangeContent.PageController.SetSelectedIndex(parameters.TryGetValue("CheckPageIndex", out var value) ? ((int)value) : 0);
		});
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)ExchangeContent.Close).onClick.Set(new EventCallback0(End));
		ExchangeContent.OEMMissions.RegisterUiEvent();
		ExchangeContent.PostOEMMission.RegisterUiEvent();
		ExchangeContent.FormulaOemMissions.RegisterUiEvent();
		ExchangeContent.PostFormulaMissions.RegisterUiEvent();
		ExchangeContent.FormulaMissionsFilter.RegisterUiEventListeners();
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.OnPushRefreshUi = (Action<FlagshipMissions>)Delegate.Combine(instance.OnPushRefreshUi, new Action<FlagshipMissions>(ExchangeContent.FlagshipReq.Renderer));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)ExchangeContent.Close).onClick.Clear();
		ExchangeContent.OEMMissions.UnregisterUiEvent();
		ExchangeContent.PostOEMMission.UnregisterUiEvent();
		ExchangeContent.FormulaOemMissions.UnregisterUiEvent();
		ExchangeContent.PostFormulaMissions.UnregisterUiEvent();
		ExchangeContent.FormulaMissionsFilter.UnregisterUiEventListeners();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.OnPushRefreshUi = (Action<FlagshipMissions>)Delegate.Remove(instance.OnPushRefreshUi, new Action<FlagshipMissions>(ExchangeContent.FlagshipReq.Renderer));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		if (incr > 0 && CanShow())
		{
			ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, itemId)}+{incr}");
		}
		bool CanShow()
		{
			StockInContext item = contextTuple.Item1;
			return item == StockInContext.GvGMode3Amplifier_ForgeConsume;
		}
	}

	private void DisplayFormulaMissionsFilter()
	{
		ExchangeContent.FormulaMissionsFilter.OnShow();
	}

	private void RefreshFlagReq()
	{
		Singleton<GvG3FlagshipReqManager>.Instance.RefreshFlagshipMissionsOnAppointedTime(ExchangeContent.FlagshipReq.Renderer);
	}
}
