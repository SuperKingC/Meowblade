using System;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;

namespace UI.ReturningRewards;

public class UI_com_ExchangeMoney : GComponent
{
	public Controller IsExchangeMoneyExceedLimit;

	public GImage n12;

	public GTextField n13;

	public GButton Exchange;

	public GTextField Limit;

	public UI_mc_Slot Currency;

	public UI_mc_Slot Money;

	public GImage n16;

	public const string URL = "ui://rx5ntv98win2x";

	public static string Name = "UI_com_ExchangeMoney";

	private int _moneyRecord;

	private ActivityManager Manager => GameManagers.Instance.ActivityManager;

	public static string GetURL()
	{
		return "ui://rx5ntv98win2x";
	}

	public static UI_com_ExchangeMoney CreateInstance()
	{
		return (UI_com_ExchangeMoney)(object)UIPackage.CreateObject("ReturningRewards", "com_ExchangeMoney");
	}

	public static UI_com_ExchangeMoney CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ExchangeMoney).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98win2x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsExchangeMoneyExceedLimit = ((GComponent)this).GetController("IsExchangeMoneyExceedLimit");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://rx5ntv98win2x".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		Exchange = (GButton)((GComponent)this).GetChild("Exchange");
		Limit = (GTextField)((GComponent)this).GetChild("Limit");
		string id2 = "ui://rx5ntv98win2x".Replace("ui://", "") + "-" + ((GObject)Limit).id;
		((GObject)Limit).text = LanguagesManager.GetDesc(id2);
		Currency = (UI_mc_Slot)(object)((GComponent)this).GetChild("Currency");
		Money = (UI_mc_Slot)(object)((GComponent)this).GetChild("Money");
		n16 = (GImage)((GComponent)this).GetChild("n16");
	}

	public void Init(int money)
	{
		_moneyRecord = money;
	}

	public void RegisterEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Exchange).onClick.Set(new EventCallback0(ExchangeMoneyEvent));
	}

	public void UnregisterEvent()
	{
		((GObject)Exchange).onClick.Clear();
	}

	public void UpdateScore(int totalScore)
	{
		int val = totalScore * 1000;
		int num = Math.Min(350000 - _moneyRecord, val);
		((GObject)Money.Qty).text = num.ShortNumberFormat() ?? "";
		((GObject)Currency.Qty).text = $"{num / 1000}";
		IsExchangeMoneyExceedLimit.SetSelectedIndex((350000 <= _moneyRecord) ? 1 : 0);
		((GObject)Exchange).enabled = num > 0;
	}

	private void ExchangeMoneyEvent()
	{
		Manager.ExchangeRecallWelfare(OnExchanged);
	}

	private void OnExchanged(ExchangeRecallWelfareResponse res)
	{
		_moneyRecord = res.Money;
		res.StockChangeRecords.DisplayStockChangedRecords();
	}
}
