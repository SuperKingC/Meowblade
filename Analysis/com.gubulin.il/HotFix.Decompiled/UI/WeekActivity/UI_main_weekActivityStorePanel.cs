using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Tips;
using UI.UseItemResult;

namespace UI.WeekActivity;

public class UI_main_weekActivityStorePanel : GComponent, IUiController
{
	public GLoader background;

	public GImage n39;

	public GComponent n40;

	public GComponent n41;

	public GImage n42;

	public GImage n43;

	public GGraph _mask;

	public GButton backBtn;

	public UI_currencyBtn ticketBtn;

	public UI_com_panelTitle titleCom;

	public UI_com_storeContent Content;

	public const string URL = "ui://jl0c82y5fmsk6";

	public static string Name = "UI_main_weekActivityStorePanel";

	public const string ActivityInfo = "ActivityInfo";

	private GetWeeklyActivityResponse _info;

	private SpinWeekActivityPayload.SpinWeekExchangePrize _itemInfo;

	private List<SpinWeekActivityPayload.SpinWeekExchangePrize> _displayList;

	public static string GetURL()
	{
		return "ui://jl0c82y5fmsk6";
	}

	public static UI_main_weekActivityStorePanel CreateInstance()
	{
		return (UI_main_weekActivityStorePanel)(object)UIPackage.CreateObject("WeekActivity", "main_weekActivityStorePanel");
	}

	public static UI_main_weekActivityStorePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_weekActivityStorePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmsk6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n40 = (GComponent)((GComponent)this).GetChild("n40");
		n41 = (GComponent)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		ticketBtn = (UI_currencyBtn)(object)((GComponent)this).GetChild("ticketBtn");
		titleCom = (UI_com_panelTitle)(object)((GComponent)this).GetChild("titleCom");
		Content = (UI_com_storeContent)(object)((GComponent)this).GetChild("Content");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)backBtn).onClick.Set(new EventCallback0(End));
		((GObject)ticketBtn).onClick.Set(new EventCallback0(OnClickTicketBtn));
		GameManagers.Instance.Messenger.AddListener<GetWeeklyActivityResponse>("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", OnProgressChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)backBtn).onClick.Clear();
		((GObject)ticketBtn).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<GetWeeklyActivityResponse>("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", OnProgressChange);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_info = (GetWeeklyActivityResponse)parameters["ActivityInfo"];
		FGUIManager.Instance.SetItemIconAndFrame(ticketBtn.ticketIcon, _info.ActivityConfig.ExchangeItemId, null, "", frameVisible: false);
		Refresh();
		RefreshTimeCountDown();
	}

	private void Refresh()
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		_displayList = _info.GetDisplayExchangePrizes();
		((GObject)ticketBtn.ticketCount).text = GameManagers.Instance.StockController.GetStock(_info.ActivityConfig.ExchangeItemId).ToString();
		_displayList.Sort((SpinWeekActivityPayload.SpinWeekExchangePrize a, SpinWeekActivityPayload.SpinWeekExchangePrize b) => (a.Priority != b.Priority) ? (a.Priority - b.Priority) : (a.Index - b.Index));
		Content.cardList.itemRenderer = new ListItemRenderer(RenderExchangeCard);
		Content.cardList.numItems = _displayList.Count;
	}

	private void RefreshTimeCountDown()
	{
		int time = (int)(_info.ActivityConfig.EndTime - GameController.Instance.GetServerTime());
		string arg = UiHelper.ParseTimeChinsesDH(time);
		((GObject)Content.ActivityTime).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("SpinWeekStoreResetTip".ToLanguage(), arg);
	}

	private void RenderExchangeCard(int index, GObject item)
	{
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		SpinWeekActivityPayload.SpinWeekExchangePrize info = _displayList[index];
		UI_com_storePackItem btn = (UI_com_storePackItem)(object)item;
		int consumedPointQty = _info.ActivityProgress.ConsumedPointQty;
		bool flag = _info.GetExchangedCount(info.Index) >= info.ExchangeLimit;
		if (consumedPointQty < info.UnlockExchangePoint)
		{
			btn.Status.SetSelectedIndex(0);
			((GObject)btn.lockText).text = $"{consumedPointQty}/{info.UnlockExchangePoint}";
		}
		else if (flag)
		{
			btn.Status.SetSelectedIndex(2);
		}
		else
		{
			btn.Status.SetSelectedIndex(1);
		}
		int num = info.ExchangeLimit - _info.GetExchangedCount(info.Index);
		((GObject)btn.reward).text = "SpinWeekExchangeLimitTip".ToLanguage().Format(num, info.ExchangeLimit);
		KeyValuePair<string, int> kvp = info.PrizeContent.First();
		GDEItemData itemConfig = GDMgr.Get<GDEItemData>(kvp.Key);
		((GObject)btn.result).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, kvp.Key);
		((GObject)btn.Number).text = kvp.Value.ToString();
		btn.currentCurrencyIcon.url = UiHelper.GetItemIconPath(_info.ActivityConfig.ExchangeItemId);
		((GObject)btn.Price1st).text = info.ExchangePoint.ToString();
		btn.icon.url = UiHelper.GetItemIconPath(kvp.Key);
		btn.icon.InitMaterialIntroductionBtn(kvp.Key);
		btn.ticketIcon.url = UiHelper.GetItemIconPath(_info.ActivityConfig.ExchangeItemId);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			if (btn.Status.selectedIndex == 1)
			{
				_itemInfo = info;
				int maxCount = info.ExchangeLimit - _info.GetExchangedCount(info.Index);
				UI_main_StellarKeyBuyPanel.BuyParam value = new UI_main_StellarKeyBuyPanel.BuyParam
				{
					Title = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("SpinWeekExchangeConfirmTitle".ToLanguage(), itemConfig.Name),
					BoughtCount = _info.GetExchangedCount(info.Index),
					Cost = info.ExchangePoint,
					Currency = _info.ActivityConfig.ExchangeItemId,
					ItemId = kvp.Key,
					ItemCount = kvp.Value,
					Limit = info.ExchangeLimit,
					MaxCount = maxCount,
					OnConfirmBuy = OnClickExchange,
					LoadFrame = true
				};
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_StellarKeyBuyPanel.Name, new Dictionary<string, object> { { "Param", value } });
			}
			else if (btn.Status.selectedIndex != 2)
			{
			}
		});
	}

	private void OnClickExchange(int exchangeCount)
	{
		int stock = GameManagers.Instance.StockController.GetStock(_info.ActivityConfig.ExchangeItemId);
		int exchangePoint = _itemInfo.ExchangePoint;
		if (stock < exchangePoint * exchangeCount)
		{
			"SpinWeekExchangeNotEnoughTip".ToLanguage().ToTip();
			return;
		}
		Task<ExchangeSpinWeeklyResponse> task = GameController.Contexts.Service<INetworkService>().ExchangeSpinWeekly(_itemInfo.Index, exchangeCount);
		task.GetAwaiter().OnCompleted(delegate
		{
			ExchangeSpinWeeklyResponse result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(result.StockChangeRecords);
				foreach (StockChangeRecord stockChangeRecord in result.StockChangeRecords)
				{
					if (stockChangeRecord.Offset > 0)
					{
						ILRequestHelper.ShowMessage($"{GDMgr.Get<GDEItemData>(stockChangeRecord.ItemId).Name}+{stockChangeRecord.Offset}");
					}
				}
				_info.ActivityProgress.ConsumedPointQty = result.ConsumedExchangePoint;
				string key = _itemInfo.Index.ToString();
				int exchangedCount = _info.GetExchangedCount(_itemInfo.Index);
				exchangedCount += exchangeCount;
				_info.ActivityProgress.Exchanged[key] = exchangedCount;
				GameManagers.Instance.Messenger.Broadcast("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", _info);
			}
		});
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

	private static void OnClickTicketBtn()
	{
		UnityUiService.Instance.OpenPanel(UI_Popup_getTicket.Name, new Dictionary<string, object>());
	}

	private void OnProgressChange(GetWeeklyActivityResponse info)
	{
		_info = info;
		Refresh();
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
