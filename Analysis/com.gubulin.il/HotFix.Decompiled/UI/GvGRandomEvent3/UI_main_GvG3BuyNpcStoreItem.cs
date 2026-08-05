using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Helpers;
using UnityEngine;

namespace UI.GvGRandomEvent3;

public class UI_main_GvG3BuyNpcStoreItem : GComponent, IUiController
{
	public GGraph Mask;

	public GMovieClip AdvancedBox;

	public GGraph shiningSfxBack;

	public UI_com_BuyItem PopUp;

	public GGraph openSfxBack;

	public UI_com_OuterTechTelecomBuyPopup Confirm;

	public Transition Open;

	public const string URL = "ui://p4ocf6q0dc6me";

	public static string Name = "UI_main_GvG3BuyNpcStoreItem";

	private bool _rpcMode;

	private int _buyCnt;

	private int _maxCnt;

	private NpcShopBuyData _buyData;

	private int _rpcMaxTimes;

	private int _rpcRemainingTimes;

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6me";
	}

	public static UI_main_GvG3BuyNpcStoreItem CreateInstance()
	{
		return (UI_main_GvG3BuyNpcStoreItem)(object)UIPackage.CreateObject("GvGRandomEvent3", "main_GvG3BuyNpcStoreItem");
	}

	public static UI_main_GvG3BuyNpcStoreItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3BuyNpcStoreItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6me", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		PopUp = (UI_com_BuyItem)(object)((GComponent)this).GetChild("PopUp");
		openSfxBack = (GGraph)((GComponent)this).GetChild("openSfxBack");
		Confirm = (UI_com_OuterTechTelecomBuyPopup)(object)((GComponent)this).GetChild("Confirm");
		Open = ((GComponent)this).GetTransition("Open");
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
		_buyData = (parameters.TryGetValue("BuyData", out var value) ? (value as NpcShopBuyData) : null);
		_rpcMode = parameters.TryGetValue("RpcMode", out var value2) && (bool)value2;
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(Render);
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
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.ConfirmBuyBtn).onClick.Set(new EventCallback0(OnClickBuyBtn));
		((GObject)PopUp.ItemsCounter.reduceBtn).onClick.Set(new EventCallback0(BuyCntReduce));
		((GObject)PopUp.ItemsCounter.increaseBtn).onClick.Set(new EventCallback0(BuyCntAdd));
		((GObject)PopUp.ItemsCounter.MaxValueBtn).onClick.Set(new EventCallback0(SetBuyCntMax));
		((GObject)Confirm.Dialog.Confirm).onClick.Set(new EventCallback0(ConfirmUseRpc));
		((GObject)Confirm.Dialog.Cancel).onClick.Set(new EventCallback0(CancelUseRpc));
		SharedMessenger.AddListener<int>("ON_GVG3_OUTTERTECH_RESET", RenderOuterTechBuffs);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.ConfirmBuyBtn).onClick.Clear();
		((GObject)PopUp.ItemsCounter.reduceBtn).onClick.Clear();
		((GObject)PopUp.ItemsCounter.increaseBtn).onClick.Clear();
		((GObject)PopUp.ItemsCounter.MaxValueBtn).onClick.Clear();
		((GObject)Confirm.Dialog.Confirm).onClick.Clear();
		((GObject)Confirm.Dialog.Cancel).onClick.Clear();
		SharedMessenger.RemoveListener<int>("ON_GVG3_OUTTERTECH_RESET", RenderOuterTechBuffs);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Render()
	{
		((GObject)PopUp.ItemName).text = _buyData.Config.StoreItemName;
		((GObject)PopUp.BuyLimit).text = $"{_buyData.Data.UserBuyLimit - _buyData.Data.UserBuyCnt}/{_buyData.Data.UserBuyLimit}";
		_maxCnt = CalculateMaxBuyCnt();
		_buyCnt = ((_maxCnt >= 1) ? 1 : 0);
		((GObject)PopUp.ItemsCounter.compoundNum).text = _buyCnt.ToString();
		((GObject)PopUp.ConfirmBuyBtn).enabled = _buyCnt > 0;
		RenderNpcShopItem();
		Render远程通信();
		int CalculateMaxBuyCnt()
		{
			int num = Mathf.Min(_buyData.Data.UserBuyLimit - _buyData.Data.UserBuyCnt, _buyData.Data.CurStock);
			foreach (KeyValuePair<string, int> item in _buyData.Config.Input)
			{
				int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(item.Key, includingGSStock: true);
				int costOfInput = _buyData.Config.GetCostOfInput(item.Key);
				int num2 = itemCount / costOfInput;
				num = Mathf.Min(num, num2);
			}
			return num;
		}
	}

	private void RenderOuterTechBuffs(int eOuterTechName)
	{
		if (eOuterTechName == 510 && _rpcMode)
		{
			_rpcRemainingTimes = OuterTechHelper.GetTechState().o远程通信_LimitTime;
		}
	}

	private void Render远程通信()
	{
		if (_rpcMode)
		{
			TechData techData = "I67510".GetTechData();
			_rpcRemainingTimes = OuterTechHelper.GetTechState().o远程通信_LimitTime;
			_rpcMaxTimes = ((TechType1_Parser)techData.TechEffectParser).GetX(techData.Level);
		}
	}

	private void RenderNpcShopItem()
	{
		RenderStoreItem();
		RenderCost();
	}

	private void RenderStoreItem()
	{
		GvGMode3ShopEventFormulaConfigModel formulaConfig = _buyData.Config;
		if (formulaConfig.IsAmplifier)
		{
			RenderAmp();
		}
		else
		{
			RenderItem();
		}
		void RenderAmp()
		{
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(formulaConfig.StoreItemId);
			PopUp.StoreItem.url = "ui://p4ocf6q09ewll";
			if (PopUp.StoreItem.component is UI_com_Amplifier uI_com_Amplifier)
			{
				RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, amplifierModel.Idx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, amplifierModel.Idx);
				int num = formulaConfig.StoreItemCnt * _buyCnt;
				((GObject)uI_com_Amplifier.Count).text = ((num > 1) ? num.ToString() : string.Empty);
			}
		}
		void RenderItem()
		{
			PopUp.StoreItem.url = "ui://p4ocf6q0dc6m5";
			if (PopUp.StoreItem.component is UI_com_Bonus uI_com_Bonus)
			{
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Bonus.ItemIcon, formulaConfig.StoreItemId);
				int num = formulaConfig.StoreItemCnt * _buyCnt;
				((GObject)uI_com_Bonus.Count).text = ((num > 1) ? num.ToString() : string.Empty);
			}
		}
	}

	private void RenderCost()
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		GvGMode3ShopEventFormulaConfigModel formulaConfig = _buyData.Config;
		List<KeyValuePair<string, int>> input = formulaConfig.Input.ToList();
		if (input.Count == 1)
		{
			PopUp.type.SetSelectedIndex(1);
			KeyValuePair<string, int> keyValuePair = input[0];
			FGUIManager.Instance.SetItemIconAndFrame(PopUp.ItemIcon, keyValuePair.Key, null, "", frameVisible: false);
			int costOfInput = formulaConfig.GetCostOfInput(keyValuePair.Key);
			((GObject)PopUp.Count).text = (costOfInput * _buyCnt).ToString();
		}
		else
		{
			PopUp.type.SetSelectedIndex(0);
			PopUp.Cost.itemRenderer = new ListItemRenderer(BonusItemRenderer);
			PopUp.Cost.numItems = input.Count;
		}
		void BonusItemRenderer(int bonusIndex, GObject bonusObj)
		{
			if (bonusObj is UI_com_Cost uI_com_Cost)
			{
				KeyValuePair<string, int> keyValuePair2 = input[bonusIndex];
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Cost.ItemIcon, keyValuePair2.Key, null, "", frameVisible: false);
				int costOfInput2 = formulaConfig.GetCostOfInput(keyValuePair2.Key);
				((GObject)uI_com_Cost.Count).text = (costOfInput2 * _buyCnt).ToString();
			}
		}
	}

	private void BuyCntAdd()
	{
		_buyCnt = Mathf.Min(++_buyCnt, _maxCnt);
		((GObject)PopUp.ItemsCounter.compoundNum).text = _buyCnt.ToString();
		((GObject)PopUp.ConfirmBuyBtn).enabled = _buyCnt > 0;
		RenderNpcShopItem();
	}

	private void BuyCntReduce()
	{
		_buyCnt = Mathf.Max(--_buyCnt, 0);
		((GObject)PopUp.ItemsCounter.compoundNum).text = _buyCnt.ToString();
		((GObject)PopUp.ConfirmBuyBtn).enabled = _buyCnt > 0;
		RenderNpcShopItem();
	}

	private void SetBuyCntMax()
	{
		_buyCnt = _maxCnt;
		((GObject)PopUp.ItemsCounter.compoundNum).text = _maxCnt.ToString();
		((GObject)PopUp.ConfirmBuyBtn).enabled = _buyCnt > 0;
		RenderNpcShopItem();
	}

	private void OnClickBuyBtn()
	{
		if (_rpcMode && !GameLocalDataManager.GetUseRpcTipDontShowAgainByIzId_Shop(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId.ToString()))
		{
			((GComponent)Confirm.Dialog.CheckBox).GetController("button").SetSelectedIndex(0);
			((GObject)Confirm.Dialog.AvailableCount).text = $"[color=#aef224]{_rpcRemainingTimes}/[/color]{_rpcMaxTimes}";
			((GObject)Confirm).visible = true;
			Confirm.showTip.Play();
		}
		else
		{
			BuyNpcItem();
		}
	}

	private void ConfirmUseRpc()
	{
		((GObject)Confirm).visible = false;
		if (((GComponent)Confirm.Dialog.CheckBox).GetController("button").selectedIndex == 1)
		{
			GameLocalDataManager.MarkUseRpcTipDontShowAgainByIzId_Shop(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId.ToString());
		}
		BuyNpcItem();
	}

	private void CancelUseRpc()
	{
		((GObject)Confirm).visible = false;
	}

	private void BuyNpcItem()
	{
		Singleton<GvG3EventMissionManager>.Instance.BuyNpcShop(_buyData.MUid, _buyData.Config.FormulaId, _buyCnt, ShowBuySuccessTip);
		End();
	}

	private void ShowBuySuccessTip()
	{
		GvGMode3ShopEventFormulaConfigModel config = _buyData.Config;
		ILRequestHelper.ShowMessage($"{config.StoreItemName}+{_buyCnt}");
	}
}
