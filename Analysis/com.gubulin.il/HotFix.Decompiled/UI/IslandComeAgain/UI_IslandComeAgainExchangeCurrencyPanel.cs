using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.PublicResources;
using UnityEngine;

namespace UI.IslandComeAgain;

public class UI_IslandComeAgainExchangeCurrencyPanel : GComponent, IUiController
{
	public UI_mc_Bg01 Mask;

	public GLoader background;

	public UI_eff_BGLight01 n19;

	public UI_eff_BGLight02 n27;

	public UI_ExchangeShelfAnimation Dialog;

	public UI_mc_Curtain01 n4;

	public UI_mc_Curtain02 n6;

	public UI_mc_Curtain03 n2;

	public UI_mc_Businessman Businessman;

	public GButton backBtn;

	public GComponent CurrencyAddBtn;

	public const string URL = "ui://k2sprg26laau6t";

	public static string Name = "UI_IslandComeAgainExchangeCurrencyPanel";

	private const int MAX_USE_TICKET_NUM = 100000;

	private const int TICKET_MONEY_EXCHANGE_MULTIPLE = 10;

	private UI_ProductionNumFloating NumFloating;

	private string CurrencyItemId = FGUIManager.Instance.IslandComeAgainActivities?[0].ScoreItem;

	private string MoneyId = "Money";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6t";
	}

	public static UI_IslandComeAgainExchangeCurrencyPanel CreateInstance()
	{
		return (UI_IslandComeAgainExchangeCurrencyPanel)(object)UIPackage.CreateObject("IslandComeAgain", "IslandComeAgainExchangeCurrencyPanel");
	}

	public static UI_IslandComeAgainExchangeCurrencyPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandComeAgainExchangeCurrencyPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (UI_mc_Bg01)(object)((GComponent)this).GetChild("Mask");
		background = (GLoader)((GComponent)this).GetChild("background");
		n19 = (UI_eff_BGLight01)(object)((GComponent)this).GetChild("n19");
		n27 = (UI_eff_BGLight02)(object)((GComponent)this).GetChild("n27");
		Dialog = (UI_ExchangeShelfAnimation)(object)((GComponent)this).GetChild("Dialog");
		n4 = (UI_mc_Curtain01)(object)((GComponent)this).GetChild("n4");
		n6 = (UI_mc_Curtain02)(object)((GComponent)this).GetChild("n6");
		n2 = (UI_mc_Curtain03)(object)((GComponent)this).GetChild("n2");
		Businessman = (UI_mc_Businessman)(object)((GComponent)this).GetChild("Businessman");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		CurrencyAddBtn = (GComponent)((GComponent)this).GetChild("CurrencyAddBtn");
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
		((GObject)Mask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		ShowCurrency();
		RenderMainUi();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Content.Exchange).onClick.Add(new EventCallback0(ExchangeMoneyEvent));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Content.Exchange).onClick.Remove(new EventCallback0(ExchangeMoneyEvent));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == CurrencyItemId)
		{
			UpdateCurrency();
			CurrencyAddBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(CurrencyAddBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
			UpdateMainUi();
		}
	}

	private void ShowCurrency()
	{
		UpdateCurrency();
		CurrencyAddBtn.GetChild("addButton").visible = false;
		CurrencyAddBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(CurrencyItemId);
	}

	public void UpdateCurrency()
	{
		int stock = GameManagers.Instance.StockController.GetStock(CurrencyItemId);
		((GObject)CurrencyAddBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(CurrencyItemId).ToString();
		int num = ((CurrencyAddBtn.GetChild("num").data != null) ? ((int)CurrencyAddBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, CurrencyAddBtn, stock - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		CurrencyAddBtn.GetChild("num").data = stock;
	}

	private void RenderMainUi()
	{
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.Content.Money.icon, MoneyId, null, "", frameVisible: false);
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.Content.Currency.icon, CurrencyItemId, null, "", frameVisible: false);
		UpdateMainUi();
	}

	private void UpdateMainUi()
	{
		int num = ArchiveExtension_GvGMode2Record.GetIslandComeAgainScoreItemCostRecord(activityId: (FGUIManager.Instance.IslandComeAgainActivities?[0])?.ActivityId, manager: GameManagers.Instance.UserArchiveManager);
		int num2 = 100000 - num;
		int stock = GameManagers.Instance.StockController.GetStock(CurrencyItemId);
		int num3 = Mathf.Min(num2, stock);
		int number = 10 * num3;
		((GObject)Dialog.Content.Money.Qty).text = number.ShortNumberFormat() ?? "";
		((GObject)Dialog.Content.Currency.Qty).text = $"{num3}";
		Dialog.Content.IsExchangeMoneyExceedLimit.SetSelectedIndex((num2 <= 0) ? 1 : 0);
		((GObject)Dialog.Content.Exchange).enabled = num3 > 0;
	}

	private void ExchangeMoneyEvent()
	{
		ILRequestHelper<DynamicIslandComeAgainExchangeResponse>.Request((EventContext)null, (Func<Task<DynamicIslandComeAgainExchangeResponse>>)(() => GameController.Contexts.Service<INetworkService>().DynamicIslandComeAgainExchange(-1L)), (Action<DynamicIslandComeAgainExchangeResponse>)delegate(DynamicIslandComeAgainExchangeResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				StockChangeRecord[] stockChangeRecords = new StockChangeRecord[2]
				{
					new StockChangeRecord
					{
						ItemId = CurrencyItemId,
						Offset = -response.CurrencyCost,
						Context = 108,
						ContextValue = CurrencyItemId,
						Type = 1
					},
					new StockChangeRecord
					{
						ItemId = MoneyId,
						Offset = response.Money,
						Context = 109,
						ContextValue = MoneyId,
						Type = 1
					}
				};
				ArchiveExtension_GvGMode2Record.SetIslandComeAgainScoreItemCostRecord(activityId: (FGUIManager.Instance.IslandComeAgainActivities?[0])?.ActivityId, manager: GameManagers.Instance.UserArchiveManager, cost: response.ScoreItemCost);
				GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
				List<string> arg = new List<string> { string.Format("{0}+{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText295"), response.Money) };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		});
	}
}
