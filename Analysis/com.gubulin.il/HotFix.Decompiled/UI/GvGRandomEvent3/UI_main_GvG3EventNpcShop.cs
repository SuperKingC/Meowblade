using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.NPC;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGRandomEvent3;

public class UI_main_GvG3EventNpcShop : GComponent, IUiController
{
	private enum TabType
	{
		StoreItems,
		Part,
		Core
	}

	public GGraph Mask;

	public UI_com_NpcShop PopUp;

	public const string URL = "ui://p4ocf6q0dc6m2";

	public static string Name = "UI_main_GvG3EventNpcShop";

	private IIslandEvent _npcDialog;

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private Dictionary<TabType, List<NPCShopModel_ToProtocol>> _tabModels;

	private List<NPCShopModel_ToProtocol> _currentModels;

	private List<TabType> _visibleTabs;

	private int _lastViewTabIndex;

	private bool _rpcMode = false;

	private int _rpcMaxTimes;

	private int _rpcRemainingTimes;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6m2";
	}

	public static UI_main_GvG3EventNpcShop CreateInstance()
	{
		return (UI_main_GvG3EventNpcShop)(object)UIPackage.CreateObject("GvGRandomEvent3", "main_GvG3EventNpcShop");
	}

	public static UI_main_GvG3EventNpcShop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3EventNpcShop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6m2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_NpcShop)(object)((GComponent)this).GetChild("PopUp");
	}

	public void BeforeDestroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_npcDialog = (parameters.TryGetValue("IIslandEvent", out var value) ? (value as IIslandEvent) : null);
		_rpcMode = parameters.TryGetValue("RpcMode", out var value2) && (bool)value2;
		Render远程通信();
		_tabModels = new Dictionary<TabType, List<NPCShopModel_ToProtocol>>();
		_visibleTabs = new List<TabType>();
		_lastViewTabIndex = 0;
		Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
		{
			Singleton<GvG3EventMissionManager>.Instance.GetNpcShop(_npcDialog.MUID, isOpenPage: true);
		});
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdateNpcShop = (Action<C2S_GetNPCShop.Response>)Delegate.Combine(instance.UpdateNpcShop, new Action<C2S_GetNPCShop.Response>(Render));
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.RpcTip).onClick.Set(new EventCallback1(ShowEventBuffsAttribute));
		SharedMessenger.AddListener<int>("ON_GVG3_OUTTERTECH_RESET", UpdateOuterTechBuffs);
	}

	public void UnregisterUiEventListeners()
	{
		GvG3EventMissionManager instance = Singleton<GvG3EventMissionManager>.Instance;
		instance.UpdateNpcShop = (Action<C2S_GetNPCShop.Response>)Delegate.Remove(instance.UpdateNpcShop, new Action<C2S_GetNPCShop.Response>(Render));
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.RpcTip).onClick.Clear();
		SharedMessenger.RemoveListener<int>("ON_GVG3_OUTTERTECH_RESET", UpdateOuterTechBuffs);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void Render(C2S_GetNPCShop.Response response)
	{
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		_tabModels.Clear();
		_visibleTabs.Clear();
		foreach (NPCShopModel_ToProtocol nPCShopModel in response.NPCShopModels)
		{
			GvGMode3ShopEventFormulaConfigModel gvGMode3ShopEventFormulaConfigModel = GvG3FlagShipMissionsConfigHelper.EventShopFormulas(nPCShopModel.ShopItemName);
			TabType key = TabType.StoreItems;
			if (gvGMode3ShopEventFormulaConfigModel.Type == FormulaType.NpcShopPart)
			{
				key = TabType.Part;
			}
			else if (gvGMode3ShopEventFormulaConfigModel.Type == FormulaType.NpcShopCore)
			{
				key = TabType.Core;
			}
			if (!_tabModels.TryGetValue(key, out var value))
			{
				value = new List<NPCShopModel_ToProtocol>();
				_tabModels[key] = value;
			}
			value.Add(nPCShopModel);
		}
		GvGMode3EventMissionConfigModel eventConfig = _npcDialog.EventConfig;
		response.NPCShopModels.Reverse();
		((GObject)PopUp.EventName).text = eventConfig.NameLevelTwo;
		PopUp.NpcIcon.url = eventConfig.NpcIconUrl;
		response.GetNpcText(eventConfig, ShowNpcText);
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
		_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
		for (TabType tabType = TabType.StoreItems; tabType <= TabType.Core; tabType++)
		{
			if (_tabModels.TryGetValue(tabType, out var value2) && value2.Count > 0)
			{
				_visibleTabs.Add(tabType);
			}
		}
		PopUp.TabListBack.itemRenderer = null;
		PopUp.TabListBack.numItems = _visibleTabs.Count;
		PopUp.TabListFront.itemRenderer = new ListItemRenderer(TabItemRenderer);
		PopUp.TabListFront.numItems = _visibleTabs.Count;
		PopUp.TabListFront.selectedIndex = _lastViewTabIndex;
		_lastViewTabIndex = Mathf.Clamp(_lastViewTabIndex, 0, _visibleTabs.Count - 1);
		if (_visibleTabs.Count > 0)
		{
			RenderItems(_tabModels[_visibleTabs[_lastViewTabIndex]]);
		}
		IEnumerator RefreshCountdown()
		{
			while (!((GObject)this).isDisposed)
			{
				int currentTime = CurrentTimestamp;
				bool valid = _npcDialog.StillValid(currentTime);
				int remainingTime = _npcDialog.RemainingTime(currentTime);
				bool hasCountdown = valid && remainingTime > 0;
				((GObject)PopUp.Countdown).text = (hasCountdown ? UiHelper.ParseTimeShort(remainingTime) : "00:00:00");
				yield return _perSecond;
			}
		}
		void ShowNpcText(string npcText)
		{
			if (!((GObject)this).isDisposed)
			{
				((GObject)PopUp.NpcText).text = npcText;
			}
		}
	}

	private void TabItemRenderer(int index, GObject item)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		TabType tab = _visibleTabs[index];
		UI_btn_PageTabFront uI_btn_PageTabFront = (UI_btn_PageTabFront)(object)item;
		((GObject)uI_btn_PageTabFront.title).text = $"ComNpcShopPanelTabList{(int)tab}".ToLanguage();
		((GObject)uI_btn_PageTabFront).onClick.Set((EventCallback0)delegate
		{
			PopUp.TabListFront.selectedIndex = index;
			_lastViewTabIndex = index;
			RenderItems(_tabModels[tab]);
		});
	}

	private void RenderItems(List<NPCShopModel_ToProtocol> models)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		_currentModels = models;
		PopUp.StoreItems.itemRenderer = new ListItemRenderer(ItemRenderer);
		PopUp.StoreItems.numItems = models.Count;
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		UI_com_NpcShopItem shopItemUi = obj as UI_com_NpcShopItem;
		if (shopItemUi == null)
		{
			return;
		}
		NPCShopModel_ToProtocol nPCShopModel_ToProtocol = _currentModels[index];
		GvGMode3ShopEventFormulaConfigModel formulaConfig = GvG3FlagShipMissionsConfigHelper.EventShopFormulas(nPCShopModel_ToProtocol.ShopItemName);
		bool flag = "I67206".IsActive();
		flag &= formulaConfig.Type == FormulaType.NpcShopItem;
		TechData techData = "I67206".GetTechData();
		shopItemUi.hasOuterTech.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("GvG3ShopCostDownTipTitle".ToLanguage());
			string arg = $"{techData.EffectValue:G}";
			stringBuilder.Append(HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("GvG3ShopCostDownTip1".ToLanguage(), arg));
			string tip = stringBuilder.ToString();
			((GObject)shopItemUi.iconOuterTech).onClick.Set((EventCallback0)delegate
			{
				//IL_0033: Unknown result type (might be due to invalid IL or missing references)
				//IL_0039: Unknown result type (might be due to invalid IL or missing references)
				FairyGUITip.ShowTip((GObject)(object)shopItemUi.iconOuterTech, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
				{
					((GObject)popup.title).text = tip;
				});
			});
		}
		shopItemUi.Rarity.selectedIndex = formulaConfig.Rarity;
		((GObject)shopItemUi.Stock).text = nPCShopModel_ToProtocol.CurStock.ToString();
		bool flag2 = nPCShopModel_ToProtocol.CurStock <= 0;
		if (flag2)
		{
			shopItemUi.StockStatus.selectedIndex = 0;
		}
		else if (nPCShopModel_ToProtocol.CurStock * 2 < nPCShopModel_ToProtocol.AllStock)
		{
			shopItemUi.StockStatus.selectedIndex = 1;
		}
		else
		{
			shopItemUi.StockStatus.selectedIndex = 2;
		}
		bool flag3 = nPCShopModel_ToProtocol.UserBuyCnt >= nPCShopModel_ToProtocol.UserBuyLimit;
		((GObject)shopItemUi.Buy.PurchaseLimit).text = $"{nPCShopModel_ToProtocol.UserBuyLimit - nPCShopModel_ToProtocol.UserBuyCnt}/{nPCShopModel_ToProtocol.UserBuyLimit}";
		bool flag4 = !flag2 && !flag3;
		shopItemUi.CanBuy.selectedIndex = (flag4 ? 1 : 0);
		((GObject)shopItemUi.Buy).enabled = flag4;
		List<KeyValuePair<string, int>> input = formulaConfig.Input.ToList();
		shopItemUi.Bonus.itemRenderer = new ListItemRenderer(BonusItemRenderer);
		shopItemUi.Bonus.numItems = input.Count;
		RenderStoreItem();
		((GObject)shopItemUi.Buy).data = new NpcShopBuyData
		{
			MUid = _npcDialog.MUID,
			Config = formulaConfig,
			Data = nPCShopModel_ToProtocol
		};
		((GObject)shopItemUi.Buy).onClick.Set(new EventCallback1(OnClickBuyButton));
		void BonusItemRenderer(int bonusIndex, GObject bonusObj)
		{
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			if (bonusObj is UI_com_NeedItem uI_com_NeedItem)
			{
				KeyValuePair<string, int> bonus = input[bonusIndex];
				int costOfInput = formulaConfig.GetCostOfInput(bonus.Key);
				bool flag5 = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(bonus.Key, includingGSStock: true) >= costOfInput;
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_NeedItem.ItemIcon, bonus.Key, null, "", frameVisible: false);
				uI_com_NeedItem.ItemQuantity.selectedIndex = ((!flag5) ? 1 : 0);
				if (flag5)
				{
					((GObject)uI_com_NeedItem.Count).text = costOfInput.ToString();
				}
				else
				{
					((GObject)uI_com_NeedItem.Count2).text = costOfInput.ToString();
				}
				bonusObj.onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(bonus.Key, 1, noCheckBtn: true);
				});
			}
		}
		void RenderAmp()
		{
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetAmplifier(formulaConfig.StoreItemId);
			shopItemUi.StoreItem.url = "ui://p4ocf6q09ewll";
			if (shopItemUi.StoreItem.component is UI_com_Amplifier uI_com_Amplifier)
			{
				RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_Amplifier.AmplifierIcon, amplifierModel.Idx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_Amplifier.AffectedRange, amplifierModel.Idx);
				((GObject)uI_com_Amplifier.Count).text = ((formulaConfig.StoreItemCnt > 1) ? formulaConfig.StoreItemCnt.ToString() : string.Empty);
			}
		}
		void RenderItem()
		{
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			shopItemUi.StoreItem.url = "ui://p4ocf6q0dc6m5";
			if (shopItemUi.StoreItem.component is UI_com_Bonus uI_com_Bonus)
			{
				FGUIManager.Instance.SetItemIconAndFrame(uI_com_Bonus.ItemIcon, formulaConfig.StoreItemId);
				((GObject)uI_com_Bonus.Count).text = ((formulaConfig.StoreItemCnt > 1) ? formulaConfig.StoreItemCnt.ToString() : string.Empty);
				((GObject)shopItemUi.StoreItem).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(formulaConfig.StoreItemId, 1, noCheckBtn: true);
				});
			}
		}
		void RenderStoreItem()
		{
			if (formulaConfig.IsAmplifier)
			{
				RenderAmp();
			}
			else
			{
				RenderItem();
			}
		}
	}

	private void OnClickBuyButton(EventContext context)
	{
		OpenBuyPanel(context);
	}

	private void OpenBuyPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		NpcShopBuyData value = ((GObject)context.sender).data as NpcShopBuyData;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3BuyNpcStoreItem.Name, new Dictionary<string, object>
		{
			{ "BuyData", value },
			{ "RpcMode", _rpcMode }
		});
	}

	private void UpdateOuterTechBuffs(int eOuterTechName)
	{
		if (eOuterTechName == 510 && _rpcMode)
		{
			_rpcRemainingTimes = OuterTechHelper.GetTechState().o远程通信_LimitTime;
			((GObject)PopUp.RpcTip.ResRemain).text = $"{_rpcRemainingTimes}";
		}
	}

	private void Render远程通信()
	{
		if (_rpcMode)
		{
			PopUp.hasOuterTech.selectedIndex = 1;
			((GObject)PopUp.RpcTip).visible = true;
			TechData techData = "I67510".GetTechData();
			_rpcRemainingTimes = OuterTechHelper.GetTechState().o远程通信_LimitTime;
			_rpcMaxTimes = ((TechType1_Parser)techData.TechEffectParser).GetX(techData.Level);
			((GObject)PopUp.RpcTip.ResRemain).text = $"{_rpcRemainingTimes}";
			((GObject)PopUp.RpcTip.ResTotal).text = $"{_rpcMaxTimes}";
		}
	}

	private void ShowEventBuffsAttribute(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "GvGRemotecommunication".ToLanguage();
		});
	}
}
