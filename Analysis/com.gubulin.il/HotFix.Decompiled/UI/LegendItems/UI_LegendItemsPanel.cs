using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.GvG3SplitBluePrint;
using UI.LegendItemBlueprint;
using UI.LegendItemInfo;
using UI.LegendItemsDraw;
using UI.PvpSelectSoldiers;
using UI.SoldierCultivate;
using UnityEngine;

namespace UI.LegendItems;

public class UI_LegendItemsPanel : GComponent, IUiController
{
	public Controller TypeController;

	public Controller Content;

	public Controller GvGTipDIsplaying;

	public GLoader background;

	public GImage n1;

	public GImage n52;

	public GImage n53;

	public GGroup backAndCrack;

	public UI_com_Title Title;

	public GButton backBtn;

	public GImage TabDark0;

	public GImage TabDark1;

	public GGroup n66;

	public GImage backB;

	public GImage n55;

	public GImage n56;

	public GGroup backGroup;

	public GGraph endChooseClick;

	public GImage chooseListBack;

	public GGroup chooseListBackGroup;

	public GImage n40;

	public GImage n41;

	public GTextField stockLimitTitle;

	public GTextField stockLimit;

	public GButton ExclamationMarkBtn;

	public GGroup stockLimitGroup;

	public UI_com_ArmsList ArmsList;

	public UI_com_BlueprintList BlueprintList;

	public GImage TabLight0;

	public UI_tab_switchButtonA Tab0;

	public GImage TabLight1;

	public UI_tab_switchButtonA Tab1;

	public GGroup n65;

	public GButton QuicklyGain;

	public UI_BlueprintSplit BlueprintSplit;

	public GTextField n67;

	public GImage n69;

	public GGroup n68;

	public const string URL = "ui://l6qef30pv5cz0";

	public static string Name = "UI_LegendItemsPanel";

	public static UI_LegendItemsPanel LegendItemsPanel;

	public static LegendItemsPanelInfo OpenPanelInfo;

	private List<string> textureList = new List<string>();

	private const int LegendItemsLimit = 500;

	private const int StarLimit = 5;

	private LegendItemsShowType showType;

	public static string soldierId;

	public static int slotIndex;

	private long itemId;

	private List<Blueprint> blueprints = new List<Blueprint>();

	public List<LegendItemUi> legendItems = new List<LegendItemUi>();

	public void SetButtonTitle()
	{
		string id = "ui://l6qef30pv5cz0".Replace("ui://", "") + "-" + ((GObject)Tab0).id + "-title";
		((GObject)Tab0.title).text = LanguagesManager.GetDesc(id);
		string id2 = "ui://l6qef30pv5cz0".Replace("ui://", "") + "-" + ((GObject)Tab1).id + "-title";
		((GObject)Tab1.title).text = LanguagesManager.GetDesc(id2);
	}

	public static string GetURL()
	{
		return "ui://l6qef30pv5cz0";
	}

	public static UI_LegendItemsPanel CreateInstance()
	{
		return (UI_LegendItemsPanel)(object)UIPackage.CreateObject("LegendItems", "LegendItemsPanel");
	}

	public static UI_LegendItemsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30pv5cz0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		Content = ((GComponent)this).GetController("Content");
		GvGTipDIsplaying = ((GComponent)this).GetController("GvGTipDIsplaying");
		background = (GLoader)((GComponent)this).GetChild("background");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		backAndCrack = (GGroup)((GComponent)this).GetChild("backAndCrack");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		TabDark0 = (GImage)((GComponent)this).GetChild("TabDark0");
		TabDark1 = (GImage)((GComponent)this).GetChild("TabDark1");
		n66 = (GGroup)((GComponent)this).GetChild("n66");
		backB = (GImage)((GComponent)this).GetChild("backB");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		backGroup = (GGroup)((GComponent)this).GetChild("backGroup");
		endChooseClick = (GGraph)((GComponent)this).GetChild("endChooseClick");
		chooseListBack = (GImage)((GComponent)this).GetChild("chooseListBack");
		chooseListBackGroup = (GGroup)((GComponent)this).GetChild("chooseListBackGroup");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		stockLimitTitle = (GTextField)((GComponent)this).GetChild("stockLimitTitle");
		string id = "ui://l6qef30pv5cz0".Replace("ui://", "") + "-" + ((GObject)stockLimitTitle).id;
		((GObject)stockLimitTitle).text = LanguagesManager.GetDesc(id);
		stockLimit = (GTextField)((GComponent)this).GetChild("stockLimit");
		string id2 = "ui://l6qef30pv5cz0".Replace("ui://", "") + "-" + ((GObject)stockLimit).id;
		((GObject)stockLimit).text = LanguagesManager.GetDesc(id2);
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		stockLimitGroup = (GGroup)((GComponent)this).GetChild("stockLimitGroup");
		ArmsList = (UI_com_ArmsList)(object)((GComponent)this).GetChild("ArmsList");
		BlueprintList = (UI_com_BlueprintList)(object)((GComponent)this).GetChild("BlueprintList");
		TabLight0 = (GImage)((GComponent)this).GetChild("TabLight0");
		Tab0 = (UI_tab_switchButtonA)(object)((GComponent)this).GetChild("Tab0");
		TabLight1 = (GImage)((GComponent)this).GetChild("TabLight1");
		Tab1 = (UI_tab_switchButtonA)(object)((GComponent)this).GetChild("Tab1");
		n65 = (GGroup)((GComponent)this).GetChild("n65");
		QuicklyGain = (GButton)((GComponent)this).GetChild("QuicklyGain");
		BlueprintSplit = (UI_BlueprintSplit)(object)((GComponent)this).GetChild("BlueprintSplit");
		n67 = (GTextField)((GComponent)this).GetChild("n67");
		string id3 = "ui://l6qef30pv5cz0".Replace("ui://", "") + "-" + ((GObject)n67).id;
		((GObject)n67).text = LanguagesManager.GetDesc(id3);
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n68 = (GGroup)((GComponent)this).GetChild("n68");
	}

	public void BeforeDestroy()
	{
		LegendItemsPanel = null;
		OpenPanelInfo.ClearInfo();
		UiTagManager instance = UiTagManager.Instance;
		int num = ArmsList.armsList.ItemIndexToChildIndex(0);
		instance.Unregister("LegendItems.FirstItem");
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		if (OpenPanelInfo == null)
		{
			End();
			return;
		}
		showType = OpenPanelInfo.showType;
		int pageIndex = (int)OpenPanelInfo.showType;
		TypeController.selectedIndex = ((pageIndex > 1) ? 1 : pageIndex);
		itemId = OpenPanelInfo.itemId;
		soldierId = OpenPanelInfo.soldierId;
		slotIndex = OpenPanelInfo.slotIndex;
		SetGvGTipDisplay();
		LegendItemsHelper.UiGetLegendItems(RenderUiContent, ((GObject)this).sortingOrder);
		RenderBlueprints();
		LegendItemsPanel = this;
		void SetGvGTipDisplay()
		{
			if (pageIndex >= 1)
			{
				bool flag = showType == LegendItemsShowType.GvGModeChoice;
				GvGTipDIsplaying.SetSelectedIndex(flag ? 1 : 0);
				((GObject)QuicklyGain).visible = !flag;
			}
		}
	}

	private void OpenDrawPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsDrawPanel.Name, null);
		((GObject)ArmsList).visible = false;
		((GObject)BlueprintList).visible = false;
	}

	private void OpenBlueprintSplitPanel()
	{
		UnityUiService.Instance.OpenPanel(UI_main_SplitBlueprint.Name, new Dictionary<string, object> { { "IsOutGvG", true } });
	}

	private void UpdateLegendItemsOnChange(string uiName)
	{
		if (uiName == UI_LegendItemsDrawPanel.Name)
		{
			((GObject)ArmsList).visible = true;
			((GObject)BlueprintList).visible = true;
			RenderUiContent();
		}
		else if (uiName == UI_main_LegendItemBlueprintForge.Name)
		{
			RenderUiContent();
			RenderBlueprints();
		}
		else if (uiName == UI_main_SplitBlueprint.Name)
		{
			RenderUiContent();
			RenderBlueprints();
		}
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("LegendItems.FirstItem", ((GComponent)ArmsList.armsList).GetChildAt(0));
		SetButtonTitle();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)endChooseClick).onClick.Add(new EventCallback0(End));
		((GObject)QuicklyGain).onClick.Add(new EventCallback0(OpenDrawPanel));
		((GObject)BlueprintSplit).onClick.Add(new EventCallback0(OpenBlueprintSplitPanel));
		SharedMessenger.AddListener<string>("CLOSE_UI", UpdateLegendItemsOnChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)endChooseClick).onClick.Remove(new EventCallback0(End));
		((GObject)QuicklyGain).onClick.Remove(new EventCallback0(OpenDrawPanel));
		((GObject)BlueprintSplit).onClick.Remove(new EventCallback0(OpenBlueprintSplitPanel));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", UpdateLegendItemsOnChange);
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText831");
	}

	private void ShowLegendItemsLimit()
	{
		((GObject)stockLimit).text = $"{legendItems.Count}/{500}";
	}

	public void ArmsListRender()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		ArmsList.armsList.SetVirtual();
		ArmsList.armsList.itemRenderer = new ListItemRenderer(LegendItemRender);
		ArmsList.armsList.numItems = legendItems.Count;
	}

	private void LegendItemRender(int index, GObject obj)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((GObject)asButton).grayed = false;
		((GObject)asButton).touchable = true;
		LegendItemUi legendItemUi = legendItems[index];
		GButton asButton2 = ((GComponent)asButton).GetChild("Content").asButton;
		if (legendItems[index] == null)
		{
			((GComponent)asButton2).GetController("TypeController").selectedIndex = 5;
			long num = 0L;
			((GObject)asButton).data = num;
			((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendItemCultivationPanel));
			return;
		}
		UiHelper.TextColorType colorType = UiHelper.TextColorType.Dark;
		if (showType == LegendItemsShowType.Show)
		{
			colorType = UiHelper.TextColorType.Light;
		}
		((GComponent)asButton).GetController("Type").selectedIndex = 0;
		UiHelper.RenderLegendItem(asButton2, legendItemUi, colorType, textureList, -1, grayed: false, showType);
		if (showType == LegendItemsShowType.GvGModeChoice)
		{
			string gvGSoldierIdByEquippedLegendItem = GameManagers.Instance.GetGvGSoldierIdByEquippedLegendItem(legendItemUi.InstanceId);
			int fromShipEntityId = OpenPanelInfo.FromShipEntityId;
			if (Singleton<WorldStateManager>.Instance.Data.TryGetShipEntityIdBySoldierId(gvGSoldierIdByEquippedLegendItem, out var shipEntityId))
			{
				ShipStateModel stateModel = Singleton<WorldStateManager>.Instance.TryGetShip(shipEntityId);
				if (!stateModel.CanFillUpUnits())
				{
					((GObject)asButton).grayed = true;
					((GObject)asButton).touchable = false;
				}
			}
		}
		((GObject)asButton).data = legendItemUi.InstanceId;
		((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendItemCultivationPanel));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void OpenLegendItemCultivationPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		long num = (long)((GObject)context.sender).data;
		switch (showType)
		{
		case LegendItemsShowType.Show:
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(LegendItemsHelper.GetLegendItemUi(num), "", -1, 1);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
			break;
		case LegendItemsShowType.Choice:
			if (num == 0L)
			{
				TakeOffLegendItem(soldierId, slotIndex);
				End();
			}
			else
			{
				UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(LegendItemsHelper.GetLegendItemUi(num), soldierId, slotIndex, 2);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
			}
			break;
		case LegendItemsShowType.TopTopTournamentChoice:
			if (num == 0L)
			{
				UI_PeakBattleSelectArrayPanel.PeakBattleSelectArrayPanel?.UpdateOnTakeOffLegendItem(soldierId, slotIndex);
				UI_SelectServerWideBattleArrayPanel.Instance?.UpdateOnTakeOffLegendItem(soldierId, slotIndex);
				End();
			}
			else
			{
				UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(LegendItemsHelper.GetLegendItemUi(num), soldierId, slotIndex, 4);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
			}
			break;
		case LegendItemsShowType.GvGModeChoice:
			if (num == 0L)
			{
				Singleton<WorldStateManager>.Instance.GVGSolidierTakeOff(soldierId, slotIndex, OpenPanelInfo.FromShipEntityId);
				End();
			}
			else
			{
				UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(LegendItemsHelper.GetLegendItemUi(num), soldierId, slotIndex, 2, null, null, 0, canChangeLockState: false, showType, OpenPanelInfo.FromShipEntityId);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
			}
			break;
		}
	}

	private void WaerLegendItem(string soldierId, int slotId, long itemId)
	{
		ILRequestHelper<SoldierWearLegendItemResponse>.Request((EventContext)null, (Func<Task<SoldierWearLegendItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierWearLegendItem(soldierId, slotId, itemId)), (Action<SoldierWearLegendItemResponse>)delegate(SoldierWearLegendItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				LegendItemsHelper.UpdateSoldiersEquippedItems(soldierId, response.Items);
				UI_SoldierCultivate.SoldierCultivatePanel?.LegendItemButtonsInit();
				UI_SoldierCultivate.SoldierCultivatePanel?.RefreshSoldierDetailInfo(GameManagers.Instance.SoldierManager.Get(soldierId));
				UI_SoldierCultivate.SoldierCultivatePanel?.WaitToRefreshCombatPower(_isUpGrade: false);
				UI_SoldierCultivate.legendItemsChanged = true;
			}
		});
	}

	private void TakeOffLegendItem(string sid, int slotId, Action onFinished = null)
	{
		ILRequestHelper<SoldierTakeOffLegendItemResponse>.Request((EventContext)null, (Func<Task<SoldierTakeOffLegendItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierTakeOffLegendItem(sid, slotId)), (Action<SoldierTakeOffLegendItemResponse>)delegate(SoldierTakeOffLegendItemResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				LegendItemsHelper.UpdateSoldiersEquippedItems(sid, response.Items);
				UI_SoldierCultivate.SoldierCultivatePanel?.LegendItemButtonsInit();
				UI_SoldierCultivate.SoldierCultivatePanel?.RefreshSoldierDetailInfo(GameManagers.Instance.SoldierManager.Get(sid));
				UI_SoldierCultivate.SoldierCultivatePanel?.WaitToRefreshCombatPower(_isUpGrade: false);
				UI_SoldierCultivate.legendItemsChanged = true;
				onFinished?.Invoke();
			}
		});
	}

	public void RenderUiContent()
	{
		GetLengendItemData();
		SetBuildingName();
		ShowLegendItemsLimit();
		ArmsListRender();
	}

	public void UpdateUiContent(List<LegendItemUi> _legendItems)
	{
		legendItems.Clear();
		legendItems = ListExtensions.DeepCopy<LegendItemUi>(_legendItems);
		ShowLegendItemsLimit();
		ArmsListRender();
	}

	public void RenderBlueprints()
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		UI_tab_switchButtonA tab = Tab1;
		bool visible = (((GObject)TabDark1).visible = LegendItemsHelper.DisplayLegendItemBlueprintUi);
		((GObject)tab).visible = visible;
		blueprints.Clear();
		blueprints = (from _blue in GameManagers.Instance.UserArchiveManager.GetLegendItemBlueprints().Clone()
			orderby _blue.EvoId descending, _blue.CreateTimestamp descending
			select _blue).ToList();
		BlueprintList.State.selectedIndex = ((blueprints.Count <= 0) ? 1 : 0);
		BlueprintList.BlueprintList.SetVirtual();
		BlueprintList.BlueprintList.itemRenderer = new ListItemRenderer(BlueprintItemRender);
		BlueprintList.BlueprintList.numItems = blueprints.Count;
		bool visible2 = GameManagers.Instance.StockController.GetStock("I67507") >= 2;
		((GObject)BlueprintSplit).visible = visible2;
	}

	private void BlueprintItemRender(int index, GObject obj)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		if (asButton != null)
		{
			Blueprint blueprint = blueprints[index];
			((GComponent)asButton).GetChild("frame").asLoader.url = "ui://PublicResources/kuang_round 2_lv6";
			((GComponent)asButton).GetChild("max").visible = false;
			((GComponent)asButton).GetChild("icon").asLoader.LoadBlueprintIcon(blueprint.GetIconName());
			((GComponent)asButton).GetChild("name").text = blueprint.GetNameTwoRows();
			((GObject)asButton).data = blueprint;
			((GObject)asButton).onClick.Set(new EventCallback1(ShowBlueprintInfo));
		}
	}

	private void ShowBlueprintInfo(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)context.sender).data is Blueprint value)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintInfoPanel.Name, new Dictionary<string, object> { { "BlueprintData", value } });
		}
	}

	private void GetLengendItemData()
	{
		legendItems.Clear();
		legendItems = ListExtensions.DeepCopy<LegendItemUi>(LegendItemsHelper.GetLegendItemsByRarity());
		if (showType == LegendItemsShowType.Choice || showType == LegendItemsShowType.TopTopTournamentChoice || showType == LegendItemsShowType.GvGModeChoice)
		{
			legendItems.Insert(0, null);
		}
	}
}
