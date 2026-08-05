using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Sweep;
using UI.AddCredit;
using UI.MtgGiftPacks;

namespace UI.GvGWorldMap3;

public class UI_main_BuySweepCountDialog : GComponent, IUiController
{
	private enum ClickMode
	{
		NotEnough,
		Normal
	}

	public GGraph back;

	public UI_com_BuySweepCountDialog Dialog;

	public const string URL = "ui://4eq8fgd2rf6isb0";

	public static string Name = "UI_main_BuySweepCountDialog";

	private SweepInfo _sweepInfo = new SweepInfo();

	private ClickMode _clickMode;

	private string _buyCostItemId;

	public static string GetURL()
	{
		return "ui://4eq8fgd2rf6isb0";
	}

	public static UI_main_BuySweepCountDialog CreateInstance()
	{
		return (UI_main_BuySweepCountDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "main_BuySweepCountDialog");
	}

	public static UI_main_BuySweepCountDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BuySweepCountDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2rf6isb0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_BuySweepCountDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_sweepInfo = (parameters.TryGetValue("SweepInfo", out var value) ? (value as SweepInfo) : null);
		RenderBuyCount();
		RenderBuyCost();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Set(new EventCallback0(OnConfirmClick));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUiClose);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.Confirm).onClick.Clear();
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUiClose);
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderBuyCount()
	{
		int todayRefillCountByPurchase = _sweepInfo.TodayRefillCountByPurchase;
		int dailyMaxSweepCountAdd = UI_com_SweepOperationDialog.SweepConfig.DailyMaxSweepCountAdd;
		((GObject)Dialog.TodayPurchasedCount).text = "GvGMode3_TodayPurchasedCount".ToLanguage().Format(new object[1] { todayRefillCountByPurchase });
		((GObject)Dialog.DailyMaxSweepCountAdd).text = "GvGMode3_DailyMaxSweepCountAdd".ToLanguage().Format(new object[1] { dailyMaxSweepCountAdd });
		Dialog.AllowToAdd.SetSelectedIndex((todayRefillCountByPurchase >= dailyMaxSweepCountAdd) ? 1 : 0);
	}

	private void OnUiClose(string uiName)
	{
		if (uiName == UI_BlackMarketerAddCredit.Name || uiName == UI_MtgGiftPacksPanel.Name)
		{
			RenderBuyCost();
		}
	}

	private void RenderBuyCost()
	{
		SweepConfig sweepConfig = UI_com_SweepOperationDialog.SweepConfig;
		int buyCount = _sweepInfo.TodayPurchasedCount + 1;
		BuySweepCountConfig buySweepCountConfig = sweepConfig.GetBuySweepConfigByBuyCount(buyCount) ?? sweepConfig.BuySweepCountConfig[sweepConfig.BuySweepCountConfig.Count - 1];
		((GObject)Dialog.ContributionAddValue).text = buySweepCountConfig.ExtraReward.ToRItemList().Find((RItem r) => r.ItemId == "ContributionPoint")?.cnt.ToString();
		RItem rItem = buySweepCountConfig.Cost.ToRItemList()[0];
		_buyCostItemId = rItem.ItemId;
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.CostIcon, rItem.ItemId, null, "", frameVisible: false);
		int cnt = rItem.cnt;
		int stock = GameManagers.Instance.StockController.GetStock(rItem.ItemId);
		bool flag = stock < cnt;
		string arg = (flag ? "#ff1919" : "#AEF224");
		((GObject)Dialog.CostNum).text = $"[color={arg}]{stock}[/color]/{cnt}";
		_clickMode = ((!flag) ? ClickMode.Normal : ClickMode.NotEnough);
	}

	private void OnConfirmClick()
	{
		if (_clickMode == ClickMode.Normal)
		{
			BuyCount();
		}
		else
		{
			GoToRechargePanel();
		}
	}

	private void GoToRechargePanel()
	{
		string buyCostItemId = _buyCostItemId;
		string text = buyCostItemId;
		if (!(text == "Gem"))
		{
			if (text == "MTG")
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_MtgGiftPacksPanel.Name, new Dictionary<string, object>());
			}
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
	}

	private void BuyCount()
	{
		if (_buyCostItemId == "MTG")
		{
			ShowTipBuyByMtg(RequestBuyCount);
		}
		else
		{
			RequestBuyCount();
		}
	}

	private static void ShowTipBuyByMtg(Action onConfirm)
	{
		string tipText = "CsharpCodeZhTcText98".ToLanguage() + "？";
		tipText.ToConfirmPopup(onConfirm, null, (AlignType)1);
	}

	private static void RequestBuyCount()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BuySweepCount
		{
			Req = new C2S_BuySweepCount.Request
			{
				IsBuyCount = true
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BuySweepCount.Response response = (C2S_BuySweepCount.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			End();
		});
	}
}
