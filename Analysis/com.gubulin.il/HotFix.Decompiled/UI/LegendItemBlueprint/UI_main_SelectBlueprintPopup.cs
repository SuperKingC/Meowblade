using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UnityEngine;

namespace UI.LegendItemBlueprint;

public class UI_main_SelectBlueprintPopup : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__14_0;

		public static Func<Task<LegendItemBlueprintGetResponse>> _003C_003E9__28_1;

		internal void _003CRegisterUiEventListeners_003Eb__14_0()
		{
			End(unloadResource: true);
		}

		internal Task<LegendItemBlueprintGetResponse> _003CGenerateBlueprint_003Eb__28_1()
		{
			return GameController.Contexts.Service<INetworkService>().LegendItemBlueprintGet();
		}
	}

	public GGraph mask;

	public UI_com_SelectBlueprintPopup ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://h09dvkcgqyyy5ltdo";

	public static string Name = "UI_main_SelectBlueprintPopup";

	private int _currentPage;

	private Dictionary<string, ConfigItem> _currentLiConfig;

	private string _selectLegendItemId;

	private string _selectFxKey;

	private List<Dictionary<string, ConfigItem>> _selectBlueprints;

	public static string GetURL()
	{
		return "ui://h09dvkcgqyyy5ltdo";
	}

	public static UI_main_SelectBlueprintPopup CreateInstance()
	{
		return (UI_main_SelectBlueprintPopup)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_SelectBlueprintPopup");
	}

	public static UI_main_SelectBlueprintPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SelectBlueprintPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgqyyy5ltdo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		ConfirmDialog = (UI_com_SelectBlueprintPopup)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void RegisterUiEventListeners()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		((GObject)ConfirmDialog.content1.title).onClickLink.Set(new EventCallback1(UI_main_LegendItemBlueprintInfoPanel.OnClickEffectLink));
		((GObject)ConfirmDialog.content2.content2).onClickLink.Set(new EventCallback1(UI_main_LegendItemBlueprintInfoPanel.OnClickEffectLink));
		EventListener onClick = ((GObject)mask).onClick;
		object obj = _003C_003Ec._003C_003E9__14_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				End(unloadResource: true);
			};
			_003C_003Ec._003C_003E9__14_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
		((GObject)ConfirmDialog.confirmBtn).onClick.Set(new EventCallback0(OnClickConfirmGenerate));
		((GObject)ConfirmDialog.backBtn1).onClick.Set((EventCallback0)delegate
		{
			OnClickSetMainItem(string.Empty);
		});
		((GObject)ConfirmDialog.backBtn2).onClick.Set((EventCallback0)delegate
		{
			OnClickSetFx(string.Empty);
		});
		((GObject)ConfirmDialog.pageLast).onClick.Set((EventCallback0)delegate
		{
			OnClickChangePage(-1);
		});
		((GObject)ConfirmDialog.pageNext).onClick.Set((EventCallback0)delegate
		{
			OnClickChangePage(1);
		});
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)ConfirmDialog.content1.title).onClickLink.Clear();
		((GObject)ConfirmDialog.content2.content2).onClickLink.Clear();
		((GObject)mask).onClick.Clear();
		((GObject)ConfirmDialog.confirmBtn).onClick.Clear();
		((GObject)ConfirmDialog.backBtn1).onClick.Clear();
		((GObject)ConfirmDialog.backBtn2).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)ConfirmDialog).visible = false;
		_selectBlueprints = new List<Dictionary<string, ConfigItem>>();
		_currentPage = 0;
		Task<SpecialSelectionBluePrintConfigResponse> task = GameController.Contexts.Service<INetworkService>().GetSpecialSelectionBluePrintConfig();
		task.GetAwaiter().OnCompleted(delegate
		{
			SpecialSelectionBluePrintConfigResponse result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
				End(unloadResource: true);
			}
			else
			{
				List<ConfigItem> configItems = task.Result.ConfigItems;
				for (int i = 0; i < configItems.Count; i++)
				{
					ConfigItem configItem = configItems[i];
					int num = i / 3;
					if (_selectBlueprints.Count <= num)
					{
						_selectBlueprints.Add(new Dictionary<string, ConfigItem>());
					}
					Dictionary<string, ConfigItem> dictionary = _selectBlueprints[num];
					dictionary.Add(configItem.MainId, configItem);
				}
				RefreshPage();
				((GObject)ConfirmDialog).visible = true;
				showTip.Play();
			}
		});
	}

	private void OnClickChangePage(int offset)
	{
		_currentPage += offset;
		_currentPage = Mathf.Clamp(_currentPage, 0, _selectBlueprints.Count - 1);
		_selectLegendItemId = null;
		_selectFxKey = null;
		RefreshPage();
	}

	private void RefreshPage()
	{
		_currentLiConfig = _selectBlueprints[_currentPage];
		((GObject)ConfirmDialog.page).text = $"[color=#fff02c]{_currentPage + 1}[/color][color=#fff2cc]/{_selectBlueprints.Count}[/color]";
		((GObject)ConfirmDialog.pageNext).visible = _currentPage != _selectBlueprints.Count - 1;
		((GObject)ConfirmDialog.pageLast).visible = _currentPage != 0;
		RefreshMainItemList();
		Refresh();
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

	private void OnClickSetMainItem(string key)
	{
		_selectLegendItemId = key;
		_selectFxKey = null;
		Refresh();
	}

	private void OnClickSetFx(string key)
	{
		_selectFxKey = key;
		Refresh();
	}

	private void RefreshMainItemList()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		List<string> itemList = _currentLiConfig.Keys.ToList();
		ConfirmDialog.itemList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			UI_btn_SelectLegendItem2 uI_btn_SelectLegendItem = (UI_btn_SelectLegendItem2)(object)item;
			string key = itemList[index];
			UI_main_OptionalBlueprintPopup.RenderLegendItemWithId((UI_LegendItem)(object)uI_btn_SelectLegendItem.n0, key, showName: true);
			((GObject)uI_btn_SelectLegendItem).onClick.Set((EventCallback1)delegate
			{
				OnClickSetMainItem(key);
			});
		};
		ConfirmDialog.itemList.numItems = itemList.Count;
	}

	private void Refresh()
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		if (string.IsNullOrEmpty(_selectLegendItemId))
		{
			ConfirmDialog.SelectState.SetSelectedIndex(0);
			return;
		}
		GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[_selectLegendItemId];
		((GObject)ConfirmDialog.Desc).text = Blueprint.GetDesc(gDELegendItemData.EvoId);
		UI_main_OptionalBlueprintPopup.RenderLegendItemWithId((UI_LegendItem)(object)ConfirmDialog.EvoLegendItem, gDELegendItemData.EvoId);
		GDELegendItemData gDELegendItemData2 = LegendItemManager.LegendItemTemplates[gDELegendItemData.EvoId];
		((GObject)ConfirmDialog.BlueprintName).text = Blueprint.GetName(gDELegendItemData2.Name);
		ConfirmDialog.BlueprintIcon.LoadBlueprintIcon(Blueprint.GetIconName(gDELegendItemData.EvoId));
		ConfigItem configItem = _currentLiConfig[_selectLegendItemId];
		bool flag = string.IsNullOrEmpty(gDELegendItemData.SetId);
		ConfirmDialog.hasEffect.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			((GObject)ConfirmDialog.content1.title).text = LegendItemsHelper.GetBlueprintFxDesc(configItem.EnhanceFxEntryId);
		}
		if (string.IsNullOrEmpty(_selectFxKey))
		{
			ConfirmDialog.SelectState.SetSelectedIndex(1);
			List<string> list = configItem.RandomFXConfig.Keys.ToList();
			ConfirmDialog.effectList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				//IL_007b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0085: Expected O, but got Unknown
				UI_btn_AttributeIcon2 uI_btn_AttributeIcon = (UI_btn_AttributeIcon2)(object)item;
				string key = list[index];
				GDELegendItemData gDELegendItemData4 = LegendItemManager.LegendItemTemplates[key];
				uI_btn_AttributeIcon.attIcon.LoadArmsIcon(gDELegendItemData4.Icon);
				((GObject)uI_btn_AttributeIcon.attDesc).text = gDELegendItemData4.Name;
				SetLevelControllerIndex(uI_btn_AttributeIcon.level, gDELegendItemData4.Rarity);
				((GObject)uI_btn_AttributeIcon).onClick.Set((EventCallback0)delegate
				{
					OnClickSetFx(key);
				});
			};
			ConfirmDialog.effectList.numItems = list.Count;
		}
		else
		{
			ConfirmDialog.SelectState.SetSelectedIndex(2);
			FxConfigItem fxConfigItem = configItem.RandomFXConfig[_selectFxKey];
			GDELegendItemData gDELegendItemData3 = LegendItemManager.LegendItemTemplates[_selectFxKey];
			bool flag2 = UI_main_OptionalBlueprintPopup.IsSetAlias(fxConfigItem.SetAlias);
			SetLevelControllerIndex(ConfirmDialog.propertyLevel, gDELegendItemData3.Rarity);
			if (flag2)
			{
				((GObject)ConfirmDialog.content2.content2).text = Blueprint.GetSetAliasEffectDecsFirstLine(fxConfigItem.SetAlias);
				ConfirmDialog.showAdditionEffect.SetSelectedIndex((gDELegendItemData3.Rarity >= 5) ? 1 : 0);
			}
			else
			{
				((GObject)ConfirmDialog.content2.content2).text = LegendItemsHelper.GetBlueprintFxDesc(fxConfigItem.Fx);
				ConfirmDialog.showAdditionEffect.SetSelectedIndex(0);
			}
			ConfirmDialog.attIcon.LoadArmsIcon(gDELegendItemData3.Icon);
			((GObject)ConfirmDialog.attDesc).text = gDELegendItemData3.Name;
		}
	}

	private static void SetLevelControllerIndex(Controller controller, int rarity)
	{
		controller.SetSelectedIndex(Mathf.Clamp(rarity - 4, 0, 2));
	}

	private void OnClickConfirmGenerate()
	{
		string sourceItemName = Item.Name(GameManagers.Instance, "I31108");
		GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[_selectLegendItemId];
		GDELegendItemData gDELegendItemData2 = LegendItemManager.LegendItemTemplates[gDELegendItemData.EvoId];
		string nameWithoutColor = Blueprint.GetNameWithoutColor(gDELegendItemData2.Name);
		DoubleConfirmGenerateBlueprint(sourceItemName, nameWithoutColor, GenerateBlueprint);
	}

	private void GenerateBlueprint()
	{
		ConfigItem configItem = _currentLiConfig[_selectLegendItemId];
		int currentPage = _currentPage;
		FxConfigItem fxConfigItem = configItem.RandomFXConfig[_selectFxKey];
		Task<SpecialSelectionBluePrintResponse> task;
		if (UI_main_OptionalBlueprintPopup.IsSetAlias(fxConfigItem.SetAlias))
		{
			task = GameController.Contexts.Service<INetworkService>().SpecialSelectionBluePrintUse(currentPage, configItem.PoolConfig, null, fxConfigItem.FxPool);
		}
		else
		{
			task = GameController.Contexts.Service<INetworkService>().SpecialSelectionBluePrintUse(currentPage, configItem.PoolConfig, fxConfigItem.FxPool, null);
		}
		task.GetAwaiter().OnCompleted(delegate
		{
			SpecialSelectionBluePrintResponse result = task.Result;
			if (result.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(result.StockChangeRecords);
				List<string> blueprintsId = result.BlueprintIds;
				ILRequestHelper<LegendItemBlueprintGetResponse>.Request((EventContext)null, (Func<Task<LegendItemBlueprintGetResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemBlueprintGet()), (Action<LegendItemBlueprintGetResponse>)delegate(LegendItemBlueprintGetResponse response)
				{
					if (response.Blueprints != null)
					{
						GameManagers.Instance.UserArchiveManager.AddLegendItemBlueprints(response.Blueprints);
						GameManagers.Instance.UserArchiveManager.AddOwnedBluePrintsRecord(blueprintsId);
						End(unloadResource: false);
						List<Blueprint> legendItemBlueprints = GameManagers.Instance.UserArchiveManager.GetLegendItemBlueprints(blueprintsId);
						Dictionary<string, object> parameters = new Dictionary<string, object> { 
						{
							"Blueprint",
							legendItemBlueprints[0]
						} };
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ObtainBlueprintPopup.Name, parameters);
					}
				});
			}
		});
	}

	public static void DoubleConfirmGenerateBlueprint(string sourceItemName, string blueprintName, Action onClickSuccess)
	{
		string desc = LanguagesManager.GetDesc("SelectBlueprintDoubleConfirmTip");
		string message = string.Format(desc, sourceItemName, blueprintName);
		UiHelper.ShowConfirmAndCancelDialog(message, onClickSuccess, null, mirror: false);
	}

	private static void End(bool unloadResource)
	{
		UnityUiService.Instance.ClosePanel(Name, !unloadResource);
	}
}
