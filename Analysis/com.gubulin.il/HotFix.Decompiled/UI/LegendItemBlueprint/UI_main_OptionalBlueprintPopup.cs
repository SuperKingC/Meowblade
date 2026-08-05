using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.PublicResources;
using UnityEngine;

namespace UI.LegendItemBlueprint;

public class UI_main_OptionalBlueprintPopup : GComponent, IUiController
{
	public class ConfigItem
	{
		public string FXConfig;

		public string PoolConfig;

		public string EnhanceFxEntryId;
	}

	public class FxConfig
	{
		public Dictionary<string, FxConfigItem> SetFX;

		public Dictionary<string, FxConfigItem> SpecialFX;

		public Dictionary<string, FxConfigItem> GeneralFX;

		public Dictionary<string, FxConfigItem> SubGeneralFX;
	}

	public class FxConfigItem
	{
		public string FxPool;

		public string SetAlias;

		public string Fx;

		public int IsConflict;
	}

	public class SaveData
	{
		public string MainItem;

		public string SetAliasItem;

		public string FxItem;
	}

	private class ItemEffectConfig
	{
		public Dictionary<string, int> Bonus;

		public Dictionary<string, string> MainLegendItem;
	}

	private enum SelectPopState
	{
		Empty,
		Main,
		Attribute,
		SubGeneral
	}

	private enum PopAnimState
	{
		Show,
		FadeIn,
		Hide,
		FadeOut
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__32_1;

		public static Func<Task<LegendItemBlueprintGetResponse>> _003C_003E9__49_1;

		public static Comparison<KeyValuePair<string, FxConfigItem>> _003C_003E9__58_3;

		public static Comparison<KeyValuePair<string, FxConfigItem>> _003C_003E9__59_1;

		internal void _003CRegisterUiEventListeners_003Eb__32_1()
		{
			End(releaseResource: true);
		}

		internal Task<LegendItemBlueprintGetResponse> _003CGenerateBlueprint_003Eb__49_1()
		{
			return GameController.Contexts.Service<INetworkService>().LegendItemBlueprintGet();
		}

		internal int _003CRefreshAttributeOptionList_003Eb__58_3(KeyValuePair<string, FxConfigItem> a, KeyValuePair<string, FxConfigItem> b)
		{
			return a.Value.IsConflict.CompareTo(b.Value.IsConflict);
		}

		internal int _003CRefreshSubGeneralOptionList_003Eb__59_1(KeyValuePair<string, FxConfigItem> a, KeyValuePair<string, FxConfigItem> b)
		{
			return a.Value.IsConflict.CompareTo(b.Value.IsConflict);
		}
	}

	public GGraph mask;

	public UI_com_OptionalBlueprintPopup ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://h09dvkcgt49p5ltdq";

	public static string Name = "UI_main_OptionalBlueprintPopup";

	public const string IsPreviewKey = "IsPreview";

	public const string ClickItemIdKey = "ClickItemId";

	private const string LastChoicePresetKey = "OptionalBlueprintLastChoice";

	private Dictionary<string, ConfigItem> _liConfig;

	private Dictionary<string, FxConfig> _fxConfigs;

	private bool _isSingleMode;

	private string _itemId;

	private FxConfig _currentFxConfig;

	private string _selectLegendItemId;

	private List<KeyValuePair<string, FxConfigItem>> _selectFxIds;

	private bool _isPreviewMode;

	private SelectPopState _state;

	private float _showPopProgress;

	private PopAnimState _popAnimState;

	private bool _isClickRespond;

	private Coroutine _animCoroutine;

	private const float ShowPos = 811f;

	private const float HidePos = -4f;

	private bool IsEditCompete => ConfirmDialog.editState.selectedIndex == 0;

	private int ShowReplaceIcon => (!IsEditCompete) ? 1 : 0;

	public static string GetURL()
	{
		return "ui://h09dvkcgt49p5ltdq";
	}

	public static UI_main_OptionalBlueprintPopup CreateInstance()
	{
		return (UI_main_OptionalBlueprintPopup)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_OptionalBlueprintPopup");
	}

	public static UI_main_OptionalBlueprintPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_OptionalBlueprintPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgt49p5ltdq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		ConfirmDialog = (UI_com_OptionalBlueprintPopup)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void RegisterUiEventListeners()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		((GObject)ConfirmDialog.InfoList.selectMainItemBtn).onClick.Set(new EventCallback1(OnClickMainItemBtn));
		((GObject)ConfirmDialog.resetBtn).onClick.Set((EventCallback0)delegate
		{
			ConfirmDialog.editState.SetSelectedIndex(2);
			RefreshMainLegendItem();
			RefreshAttributeList();
		});
		((GObject)ConfirmDialog.confirmBtn).onClick.Set(new EventCallback0(OnClickSaveOption));
		((GObject)ConfirmDialog.generateBtn).onClick.Set(new EventCallback0(OnClickGenerateBlueprint));
		EventListener onClick = ((GObject)ConfirmDialog.exitBtn).onClick;
		object obj = _003C_003Ec._003C_003E9__32_1;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				End(releaseResource: true);
			};
			_003C_003Ec._003C_003E9__32_1 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
		((GObject)ConfirmDialog.selectPopList.closePop).onClick.Set((EventCallback0)delegate
		{
			ShowSelectPop(SelectPopState.Empty);
		});
		((GObject)ConfirmDialog.InfoList.content1).onClickLink.Set((EventCallback1)delegate(EventContext context)
		{
			_isClickRespond = true;
			EffectHelper.CoroutineDelay(0.2f, delegate
			{
				_isClickRespond = false;
			});
			UI_main_LegendItemBlueprintInfoPanel.OnClickEffectLink(context);
		});
		((GObject)ConfirmDialog.InfoList.content1).onClick.Set(new EventCallback1(OnClickMainItemBtn));
		InitScrollDownArrow((GObject)(object)ConfirmDialog.scrollArrow, ((GComponent)ConfirmDialog.InfoList).scrollPane);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)ConfirmDialog.InfoList.selectMainItemBtn).onClick.Clear();
		((GObject)ConfirmDialog.resetBtn).onClick.Clear();
		((GObject)ConfirmDialog.confirmBtn).onClick.Clear();
		((GObject)ConfirmDialog.generateBtn).onClick.Clear();
		((GObject)ConfirmDialog.exitBtn).onClick.Clear();
		((GObject)ConfirmDialog.selectPopList.closePop).onClick.Clear();
		((GObject)ConfirmDialog.InfoList.content1).onClickLink.Clear();
		((GObject)ConfirmDialog.InfoList.content1).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_isPreviewMode = true;
		if (parameters.TryGetValue("IsPreview", out var value))
		{
			_isPreviewMode = (bool)value;
		}
		if (parameters.TryGetValue("ClickItemId", out var value2))
		{
			string text = (string)value2;
			ItemEffectConfig itemEffectConfig = JsonHelper.ToObject<ItemEffectConfig>(GDMgr.Get<GDEItemData>(text).Effect);
			string configKey = itemEffectConfig.MainLegendItem["MainPoolConfig"];
			_liConfig = configKey.ToConfiguration<Dictionary<string, ConfigItem>>();
			_itemId = text;
			ConfirmDialog.bpTitle.url = OptionalBpTitleURL(value2);
			_isSingleMode = _liConfig.Count == 1;
			_fxConfigs = new Dictionary<string, FxConfig>();
			_selectFxIds = new List<KeyValuePair<string, FxConfigItem>>();
			ConfirmDialog.isPreviewMode.SetSelectedIndex(_isPreviewMode ? 1 : 0);
			if (_isSingleMode)
			{
				KeyValuePair<string, ConfigItem> keyValuePair = _liConfig.First();
				_selectLegendItemId = keyValuePair.Key;
				_currentFxConfig = GetFxConfig(keyValuePair.Value.FXConfig);
			}
			bool flag = false;
			ConfirmDialog.editState.SetSelectedIndex((!flag) ? 1 : 0);
			List<KeyValuePair<string, ConfigItem>> liList = _liConfig.ToList();
			ConfirmDialog.selectPopList.mainItemList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
			{
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				//IL_006a: Expected O, but got Unknown
				string key = liList[index].Key;
				UI_btn_SelectLegendItem uI_btn_SelectLegendItem = (UI_btn_SelectLegendItem)(object)item;
				RenderLegendItemWithId((UI_LegendItem)(object)uI_btn_SelectLegendItem.n0, key, showName: true);
				((GObject)uI_btn_SelectLegendItem).onClick.Set((EventCallback1)delegate
				{
					ConfirmDialog.selectPopList.mainItemList.AddSelection(index, false);
					OnClickSetMainItem(key);
				});
			};
			ConfirmDialog.selectPopList.mainItemList.numItems = liList.Count;
			RefreshMainLegendItem();
			RefreshAttributeList();
			((GObject)ConfirmDialog.selectPopList).x = -4f;
			((GObject)ConfirmDialog.selectPopList).alpha = 0f;
			_popAnimState = PopAnimState.Hide;
			_state = SelectPopState.Empty;
			_showPopProgress = 0f;
			((GComponent)ConfirmDialog.InfoList).scrollPane.ScrollTop();
		}
		else
		{
			End(releaseResource: true);
		}
	}

	private static string OptionalBpTitleURL(object itemId)
	{
		return $"ui://LegendItemBlueprint/title_{itemId}";
	}

	public void OnShow()
	{
	}

	private bool TryLoadPreset()
	{
		if (!GameLocalDataManager.HasKey("OptionalBlueprintLastChoice"))
		{
			return false;
		}
		string json = GameLocalDataManager.GetString("OptionalBlueprintLastChoice");
		bool result = false;
		SaveData saveData = json.ToObject<SaveData>();
		if (!string.IsNullOrEmpty(saveData.MainItem) && !string.IsNullOrEmpty(saveData.FxItem) && _liConfig.ContainsKey(saveData.MainItem))
		{
			ConfigItem configItem = _liConfig[saveData.MainItem];
			FxConfig fxConfig = GetFxConfig(configItem.FXConfig);
			if (!string.IsNullOrEmpty(saveData.SetAliasItem))
			{
				if (fxConfig.SetFX.ContainsKey(saveData.SetAliasItem) && fxConfig.SubGeneralFX.ContainsKey(saveData.FxItem))
				{
					result = true;
					_selectLegendItemId = saveData.MainItem;
					_currentFxConfig = fxConfig;
					_selectFxIds.Add(new KeyValuePair<string, FxConfigItem>(saveData.SetAliasItem, fxConfig.SetFX[saveData.SetAliasItem]));
					_selectFxIds.Add(new KeyValuePair<string, FxConfigItem>(saveData.FxItem, fxConfig.SubGeneralFX[saveData.FxItem]));
				}
			}
			else if (fxConfig.SpecialFX.ContainsKey(saveData.FxItem))
			{
				result = true;
				_selectLegendItemId = saveData.MainItem;
				_currentFxConfig = fxConfig;
				_selectFxIds.Add(new KeyValuePair<string, FxConfigItem>(saveData.FxItem, fxConfig.SpecialFX[saveData.FxItem]));
			}
			else if (fxConfig.GeneralFX.ContainsKey(saveData.FxItem))
			{
				result = true;
				_selectLegendItemId = saveData.MainItem;
				_currentFxConfig = fxConfig;
				_selectFxIds.Add(new KeyValuePair<string, FxConfigItem>(saveData.FxItem, fxConfig.GeneralFX[saveData.FxItem]));
			}
		}
		return result;
	}

	private void SavePreset()
	{
		SaveData saveData = new SaveData();
		saveData.MainItem = _selectLegendItemId;
		foreach (KeyValuePair<string, FxConfigItem> selectFxId in _selectFxIds)
		{
			FxConfigItem value = selectFxId.Value;
			if (IsSetAlias(value.SetAlias))
			{
				saveData.SetAliasItem = selectFxId.Key;
			}
			else
			{
				saveData.FxItem = selectFxId.Key;
			}
		}
		string value2 = saveData.ToJson();
		GameLocalDataManager.SetString("OptionalBlueprintLastChoice", value2);
	}

	private void UpdateSubItem(GObject item, bool isSelected)
	{
		if (item is UI_com_OptionalSelectPropertyBtn uI_com_OptionalSelectPropertyBtn)
		{
			uI_com_OptionalSelectPropertyBtn.isSelect.SetSelectedIndex(isSelected ? 1 : 0);
		}
		else if (item is UI_btn_OptionalBlueprintAddAttribute uI_btn_OptionalBlueprintAddAttribute)
		{
			uI_btn_OptionalBlueprintAddAttribute.isSelect.SetSelectedIndex(isSelected ? 1 : 0);
		}
		if (isSelected)
		{
			((GComponent)ConfirmDialog.InfoList).scrollPane.ScrollToView(item, true);
		}
	}

	private void ShowSelectPop(SelectPopState state)
	{
		bool flag = state == SelectPopState.Main;
		ConfirmDialog.InfoList.isSelected.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			((GComponent)ConfirmDialog.InfoList).scrollPane.ScrollTop(true);
		}
		int numItems = ConfirmDialog.InfoList.effectList.numItems;
		for (int i = 0; i < numItems; i++)
		{
			GObject childAt = ((GComponent)ConfirmDialog.InfoList.effectList).GetChildAt(i);
			if (i == 0)
			{
				UpdateSubItem(childAt, state == SelectPopState.Attribute);
			}
			else
			{
				UpdateSubItem(childAt, state == SelectPopState.SubGeneral);
			}
		}
		if (_state != state)
		{
			_state = state;
			if (_animCoroutine != null)
			{
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_animCoroutine);
				_animCoroutine = null;
			}
			_animCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(StartShowPopAnim());
		}
	}

	private IEnumerator StartShowPopAnim()
	{
		if (_popAnimState == PopAnimState.Show || _popAnimState == PopAnimState.FadeIn)
		{
			_popAnimState = PopAnimState.FadeOut;
			float duration = 0.233f;
			TweenerCore<float, float, FloatOptions> tween = DOTween.To((DOGetter<float>)(() => _showPopProgress), (DOSetter<float>)delegate(float x)
			{
				_showPopProgress = x;
				if (!((GObject)ConfirmDialog).isDisposed)
				{
					((GObject)ConfirmDialog.selectPopList).x = Mathf.Lerp(-4f, 811f, x);
					((GObject)ConfirmDialog.selectPopList).alpha = x;
				}
			}, 0f, duration);
			TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(tween, (Ease)8);
			yield return (object)new WaitForSeconds(duration);
		}
		_popAnimState = PopAnimState.Hide;
		if (_state != SelectPopState.Empty)
		{
			ConfirmDialog.selectPopList.selectPop.SetSelectedIndex((_state != SelectPopState.Main) ? 1 : 0);
		}
		if (_state != SelectPopState.Attribute && _state != SelectPopState.Main && _state != SelectPopState.SubGeneral)
		{
			yield break;
		}
		_popAnimState = PopAnimState.FadeIn;
		if (_state == SelectPopState.Attribute)
		{
			RefreshAttributeOptionList();
		}
		else if (_state == SelectPopState.SubGeneral)
		{
			RefreshSubGeneralOptionList();
		}
		else if (_state == SelectPopState.Main)
		{
			InitScrollDownArrow((GObject)(object)ConfirmDialog.selectPopList.scrollArrow, ((GComponent)ConfirmDialog.selectPopList.mainItemList).scrollPane);
		}
		float duration2 = 0.233f;
		TweenerCore<float, float, FloatOptions> tween2 = DOTween.To((DOGetter<float>)(() => _showPopProgress), (DOSetter<float>)delegate(float x)
		{
			_showPopProgress = x;
			if (!((GObject)ConfirmDialog).isDisposed)
			{
				((GObject)ConfirmDialog.selectPopList).x = Mathf.Lerp(-4f, 811f, x);
				((GObject)ConfirmDialog.selectPopList).alpha = x;
			}
		}, 1f, duration2);
		TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(tween2, (Ease)8);
		yield return (object)new WaitForSeconds(duration2);
		_popAnimState = PopAnimState.Show;
	}

	private void OnClickMainItemBtn(EventContext e)
	{
		if (!_isClickRespond && !_isSingleMode && !IsEditCompete)
		{
			ShowSelectPop(SelectPopState.Main);
		}
	}

	private void OnClickSetMainItem(string legendItemId)
	{
		if (!(legendItemId == _selectLegendItemId))
		{
			_selectLegendItemId = legendItemId;
			_selectFxIds.Clear();
			ConfigItem configItem = _liConfig[legendItemId];
			_currentFxConfig = GetFxConfig(configItem.FXConfig);
			ConfirmDialog.editState.SetSelectedIndex(1);
			RefreshMainLegendItem();
			RefreshAttributeList();
		}
	}

	private void OnClickSelectAttribute(KeyValuePair<string, FxConfigItem> attribute, int index)
	{
		if (_selectFxIds.Count <= index)
		{
			_selectFxIds.Add(attribute);
		}
		else
		{
			_selectFxIds[index] = attribute;
		}
		bool flag = true;
		if (index == 0)
		{
			if (IsSetAlias(attribute.Value.SetAlias))
			{
				flag = _selectFxIds.Count >= 2;
			}
			else if (_selectFxIds.Count > 1)
			{
				_selectFxIds.Clear();
				_selectFxIds.Add(attribute);
			}
		}
		RefreshAttributeList();
		ConfirmDialog.editState.SetSelectedIndex((!flag) ? 1 : 2);
	}

	private void OnClickSaveOption()
	{
		ConfirmDialog.editState.SetSelectedIndex(0);
		ShowSelectPop(SelectPopState.Empty);
		RefreshMainLegendItem();
		RefreshAttributeList();
	}

	private void OnClickGenerateBlueprint()
	{
		if (!_isPreviewMode)
		{
			string sourceItemName = Item.Name(GameManagers.Instance, _itemId);
			GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[_selectLegendItemId];
			GDELegendItemData gDELegendItemData2 = LegendItemManager.LegendItemTemplates[gDELegendItemData.EvoId];
			string nameWithoutColor = Blueprint.GetNameWithoutColor(gDELegendItemData2.Name);
			UI_main_SelectBlueprintPopup.DoubleConfirmGenerateBlueprint(sourceItemName, nameWithoutColor, GenerateBlueprint);
		}
	}

	private void GenerateBlueprint()
	{
		string poolConfig = _liConfig[_selectLegendItemId].PoolConfig;
		string fxPool = string.Empty;
		string setAliasPool = string.Empty;
		foreach (KeyValuePair<string, FxConfigItem> selectFxId in _selectFxIds)
		{
			FxConfigItem value = selectFxId.Value;
			if (IsSetAlias(value.SetAlias))
			{
				setAliasPool = value.FxPool;
			}
			else
			{
				fxPool = value.FxPool;
			}
		}
		Task<SelfSelectionBluePrintResponse> task = GameController.Contexts.Service<INetworkService>().SelfSelectionBluePrintUse(_itemId, poolConfig, fxPool, setAliasPool);
		task.GetAwaiter().OnCompleted(delegate
		{
			SelfSelectionBluePrintResponse result = task.Result;
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
						End(releaseResource: false);
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

	private static void End(bool releaseResource)
	{
		UnityUiService.Instance.ClosePanel(Name, !releaseResource);
	}

	private void RefreshMainLegendItem()
	{
		bool flag = !string.IsNullOrEmpty(_selectLegendItemId);
		ConfirmDialog.InfoList.hasMainItem.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[_selectLegendItemId];
			((GObject)ConfirmDialog.InfoList.Desc).text = Blueprint.GetDesc(gDELegendItemData.EvoId);
			RenderLegendItemWithId((UI_LegendItem)(object)ConfirmDialog.InfoList.EvoLegendItem, gDELegendItemData.EvoId);
			GDELegendItemData gDELegendItemData2 = LegendItemManager.LegendItemTemplates[gDELegendItemData.EvoId];
			((GObject)ConfirmDialog.InfoList.BlueprintName).text = Blueprint.GetName(gDELegendItemData2.Name);
			ConfirmDialog.InfoList.BlueprintIcon.LoadBlueprintIcon(Blueprint.GetIconName(gDELegendItemData.EvoId));
			ConfigItem configItem = _liConfig[_selectLegendItemId];
			if (!string.IsNullOrEmpty(gDELegendItemData.SetId))
			{
				((GObject)ConfirmDialog.InfoList.content1).text = GetBlueprintSetDesc(gDELegendItemData.SetId);
			}
			else
			{
				string blueprintFxDesc = LegendItemsHelper.GetBlueprintFxDesc(configItem.EnhanceFxEntryId);
				((GObject)ConfirmDialog.InfoList.content1).text = ReplaceColor(blueprintFxDesc);
			}
			((GObject)ConfirmDialog.InfoList.content1).touchable = true;
			int selectedIndex = ((!IsEditCompete && !_isSingleMode) ? 1 : 0);
			ConfirmDialog.InfoList.showSelectIcon.SetSelectedIndex(selectedIndex);
			int selectedIndex2 = ((!IsSetAlias(configItem.EnhanceFxEntryId)) ? 1 : 0);
			ConfirmDialog.InfoList.hasEffect.SetSelectedIndex(selectedIndex2);
			CopyPosAndSize((GObject)(object)ConfirmDialog.InfoList.n144, (GObject)(object)ConfirmDialog.InfoList.selectMainItemBtn);
			((GObject)ConfirmDialog.InfoList.effectList).y = ((GObject)ConfirmDialog.InfoList.n144).y + ((GObject)ConfirmDialog.InfoList.n144).height + 20f;
		}
		else
		{
			CopyPosAndSize((GObject)(object)ConfirmDialog.InfoList.n23, (GObject)(object)ConfirmDialog.InfoList.selectMainItemBtn);
			((GObject)ConfirmDialog.InfoList.effectList).y = ((GObject)ConfirmDialog.InfoList.n23).y + ((GObject)ConfirmDialog.InfoList.n23).height + 20f;
		}
	}

	private static void CopyPosAndSize(GObject scr, GObject dest)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		dest.position = scr.position;
		dest.size = scr.size;
	}

	private void RefreshAttributeList()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		int num = 0;
		int count = _selectFxIds.Count;
		bool showBlackBoard = string.IsNullOrEmpty(_selectLegendItemId);
		num = ((showBlackBoard || count <= 0) ? 1 : ((!IsSetAlias(_selectFxIds[0].Value.SetAlias)) ? 1 : 2));
		GList effectList = ConfirmDialog.InfoList.effectList;
		effectList.numItems = 0;
		effectList.itemProvider = (ListItemProvider)delegate(int index)
		{
			bool flag = index >= _selectFxIds.Count;
			return (flag || showBlackBoard) ? "ui://h09dvkcgb8pv5ltdv" : "ui://h09dvkcgt49p5ltds";
		};
		UI_btn_OptionalBlueprintAddAttribute emptyNode = null;
		effectList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Expected O, but got Unknown
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			if (index < _selectFxIds.Count)
			{
				UI_com_OptionalSelectPropertyBtn uI_com_OptionalSelectPropertyBtn = (UI_com_OptionalSelectPropertyBtn)(object)item;
				KeyValuePair<string, FxConfigItem> keyValuePair = _selectFxIds[index];
				bool flag = IsSetAlias(keyValuePair.Value.SetAlias);
				uI_com_OptionalSelectPropertyBtn.State.SetSelectedIndex((!flag) ? 1 : 2);
				if (flag)
				{
					((GObject)uI_com_OptionalSelectPropertyBtn.content).text = ReplaceColor(Blueprint.GetSetAliasEffectDecsFirstLine(keyValuePair.Value.SetAlias));
				}
				else
				{
					string blueprintFxDesc = LegendItemsHelper.GetBlueprintFxDesc(keyValuePair.Value.Fx);
					((GObject)uI_com_OptionalSelectPropertyBtn.content).text = ReplaceColor(blueprintFxDesc);
				}
				((GObject)uI_com_OptionalSelectPropertyBtn).onClick.Set(new EventCallback0(OnBtnClick));
				((GObject)uI_com_OptionalSelectPropertyBtn.content).onClickLink.Set(new EventCallback1(UI_main_LegendItemBlueprintInfoPanel.OnClickEffectLink));
				uI_com_OptionalSelectPropertyBtn.showSelectIcon.SetSelectedIndex(ShowReplaceIcon);
			}
			else
			{
				UI_btn_OptionalBlueprintAddAttribute uI_btn_OptionalBlueprintAddAttribute = (UI_btn_OptionalBlueprintAddAttribute)(object)item;
				uI_btn_OptionalBlueprintAddAttribute.Type.SetSelectedIndex(showBlackBoard ? 2 : ((index >= 1) ? 1 : 0));
				((GObject)uI_btn_OptionalBlueprintAddAttribute).onClick.Set(new EventCallback0(OnBtnClick));
				emptyNode = uI_btn_OptionalBlueprintAddAttribute;
			}
			SelectPopState selectPopState = ((index >= 1) ? SelectPopState.SubGeneral : SelectPopState.Attribute);
			UpdateSubItem(item, selectPopState == _state);
			void OnBtnClick()
			{
				if (!IsEditCompete && !showBlackBoard)
				{
					if (index >= 1)
					{
						ShowSelectPop(SelectPopState.SubGeneral);
					}
					else
					{
						ShowSelectPop(SelectPopState.Attribute);
					}
				}
			}
		};
		effectList.numItems = num;
		ResizeToFit(effectList);
		((GObject)effectList).height = ((GObject)effectList).height + 20f;
		if (!showBlackBoard && emptyNode != null)
		{
			((GComponent)ConfirmDialog.InfoList).scrollPane.ScrollToView((GObject)(object)emptyNode, true);
		}
	}

	private void RefreshAttributeOptionList()
	{
		ConfirmDialog.selectPopList.selectPop.SetSelectedIndex(1);
		InitScrollDownArrow((GObject)(object)ConfirmDialog.selectPopList.scrollArrow, ((GComponent)ConfirmDialog.selectPopList.attributeList).scrollPane);
		UI_com_OptionalBlueprintAttributeList attributeList = ConfirmDialog.selectPopList.attributeList;
		List<UI_com_OptionalBlueprintAttSelList> allList = new List<UI_com_OptionalBlueprintAttSelList>();
		allList.Add(attributeList.setList);
		allList.Add(attributeList.specialList);
		allList.Add(attributeList.generalList);
		string mainItemId = _selectLegendItemId;
		string mainItemFx = _liConfig[_selectLegendItemId].EnhanceFxEntryId;
		Dictionary<string, FxConfigItem> setFX = _currentFxConfig.SetFX;
		bool flag = setFX != null && setFX.Count > 0;
		((GObject)attributeList.setList).visible = flag;
		if (flag)
		{
			InitAttributeOption(attributeList.setList, _currentFxConfig.SetFX.ToList());
		}
		else
		{
			((GObject)attributeList.setList).height = 0f;
		}
		Dictionary<string, FxConfigItem> specialFX = _currentFxConfig.SpecialFX;
		bool flag2 = specialFX != null && specialFX.Count > 0;
		((GObject)attributeList.specialList).visible = flag2;
		if (flag2)
		{
			InitAttributeOption(attributeList.specialList, _currentFxConfig.SpecialFX.ToList());
		}
		else
		{
			((GObject)attributeList.specialList).height = 0f;
		}
		InitAttributeOption(attributeList.generalList, _currentFxConfig.GeneralFX.ToList());
		void InitAttributeOption(UI_com_OptionalBlueprintAttSelList subList, List<KeyValuePair<string, FxConfigItem>> attributes)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			subList.setList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				//IL_0096: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a0: Expected O, but got Unknown
				KeyValuePair<string, FxConfigItem> kvp = attributes[i];
				string key2 = kvp.Key;
				GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[key2];
				UI_btn_AttributeIcon uI_btn_AttributeIcon = (UI_btn_AttributeIcon)(object)o;
				uI_btn_AttributeIcon.attIcon.LoadArmsIcon(gDELegendItemData.Icon);
				((GObject)uI_btn_AttributeIcon.attDesc).text = gDELegendItemData.Name;
				((GObject)uI_btn_AttributeIcon).enabled = kvp.Value.IsConflict == 0;
				((GObject)uI_btn_AttributeIcon).onClick.Set((EventCallback0)delegate
				{
					foreach (UI_com_OptionalBlueprintAttSelList item in allList)
					{
						if (((GObject)item).name != ((GObject)subList).name)
						{
							item.setList.ClearSelection();
						}
						else
						{
							subList.setList.AddSelection(i, true);
						}
					}
					OnClickSelectAttribute(kvp, 0);
				});
			};
			bool flag3 = false;
			foreach (KeyValuePair<string, FxConfigItem> attribute in attributes)
			{
				KeyValuePair<string, FxConfigItem> keyValuePair = attribute;
				string key = keyValuePair.Key;
				string property = (IsSetAlias(keyValuePair.Value.SetAlias) ? keyValuePair.Value.SetAlias : keyValuePair.Value.Fx);
				bool flag4 = IsConflict(mainItemId, key, mainItemFx, property);
				keyValuePair.Value.IsConflict = (flag4 ? 1 : 0);
				flag3 = flag3 || !flag4;
			}
			((GObject)subList).visible = flag3;
			if (flag3)
			{
				attributes.InsertionSort((KeyValuePair<string, FxConfigItem> a, KeyValuePair<string, FxConfigItem> b) => a.Value.IsConflict.CompareTo(b.Value.IsConflict));
				int count = attributes.Count;
				subList.setList.numItems = count;
				subList.setList.ClearSelection();
				if (_selectFxIds.Count > 0)
				{
					KeyValuePair<string, FxConfigItem> keyValuePair2 = _selectFxIds[0];
					for (int num = 0; num < count; num++)
					{
						if (attributes[num].Key == keyValuePair2.Key)
						{
							subList.setList.AddSelection(num, true);
						}
					}
				}
				ResizeToFit(subList.setList);
				((GObject)subList).height = ((GObject)subList.setList).height + 124f;
			}
			else
			{
				((GObject)subList).height = 0f;
			}
		}
	}

	private void RefreshSubGeneralOptionList()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		ConfirmDialog.selectPopList.selectPop.SetSelectedIndex(2);
		InitScrollDownArrow((GObject)(object)ConfirmDialog.selectPopList.scrollArrow, ((GComponent)ConfirmDialog.selectPopList.subGeneralList).scrollPane);
		List<KeyValuePair<string, FxConfigItem>> attributes = _currentFxConfig.SubGeneralFX.ToList();
		GList subGeneralList = ConfirmDialog.selectPopList.subGeneralList.generalList.setList;
		string selectLegendItemId = _selectLegendItemId;
		string enhanceFxEntryId = _liConfig[_selectLegendItemId].EnhanceFxEntryId;
		subGeneralList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			KeyValuePair<string, FxConfigItem> kvp = attributes[i];
			string key3 = kvp.Key;
			GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[key3];
			UI_btn_AttributeIcon uI_btn_AttributeIcon = (UI_btn_AttributeIcon)(object)o;
			uI_btn_AttributeIcon.attIcon.LoadArmsIcon(gDELegendItemData.Icon);
			((GObject)uI_btn_AttributeIcon.attDesc).text = gDELegendItemData.Name;
			((GObject)uI_btn_AttributeIcon).enabled = kvp.Value.IsConflict == 0;
			((GObject)uI_btn_AttributeIcon).onClick.Set((EventCallback0)delegate
			{
				subGeneralList.AddSelection(i, false);
				OnClickSelectAttribute(kvp, 1);
			});
		};
		foreach (KeyValuePair<string, FxConfigItem> item in attributes)
		{
			KeyValuePair<string, FxConfigItem> keyValuePair = item;
			string key = keyValuePair.Key;
			string property = (IsSetAlias(keyValuePair.Value.SetAlias) ? keyValuePair.Value.SetAlias : keyValuePair.Value.Fx);
			keyValuePair.Value.IsConflict = (IsConflict(selectLegendItemId, key, enhanceFxEntryId, property) ? 1 : 0);
		}
		attributes.InsertionSort((KeyValuePair<string, FxConfigItem> a, KeyValuePair<string, FxConfigItem> b) => a.Value.IsConflict.CompareTo(b.Value.IsConflict));
		int count = attributes.Count;
		subGeneralList.numItems = count;
		subGeneralList.ClearSelection();
		if (_selectFxIds.Count > 1)
		{
			string key2 = _selectFxIds[1].Key;
			for (int num = 0; num < count; num++)
			{
				if (attributes[num].Key == key2)
				{
					subGeneralList.AddSelection(num, false);
				}
			}
		}
		subGeneralList.numItems = attributes.Count;
		ResizeToFit(ConfirmDialog.selectPopList.subGeneralList.generalList.setList);
	}

	private FxConfig GetFxConfig(string key)
	{
		if (!_fxConfigs.ContainsKey(key))
		{
			FxConfig value = key.ToConfiguration<FxConfig>();
			_fxConfigs[key] = value;
		}
		return _fxConfigs[key];
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public static void RenderLegendItemWithId(UI_LegendItem item, string id, bool showName = false)
	{
		GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[id];
		LegendItemsHelper.RenderLegendItem((GButton)(object)item, gDELegendItemData);
		if (showName)
		{
			((GObject)item.name).text = gDELegendItemData.Name;
		}
	}

	public static bool IsSetAlias(string fxId)
	{
		if (string.IsNullOrEmpty(fxId))
		{
			return false;
		}
		return LegendItemsHelper.LegendItemSetMap.ContainsKey(fxId);
	}

	public static void ResizeToFit(GList list)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		int numItems = list.numItems;
		if ((int)list.layout == 4)
		{
			GObject childAt = ((GComponent)list).GetChildAt(numItems - 1);
			int num = Mathf.CeilToInt(1f * (float)numItems / (float)list.columnCount);
			((GComponent)list).viewHeight = (float)num * (childAt.height + (float)list.lineGap);
		}
		else
		{
			list.ResizeToFit(numItems);
		}
	}

	public static string ReplaceColor(string decs)
	{
		StringBuilder stringBuilder = new StringBuilder(decs);
		stringBuilder.Replace("#aef224", "#1f8c15");
		stringBuilder.Replace("#d2932a", "#4d2408");
		stringBuilder.Replace("#227faa", "#015689");
		stringBuilder.Replace("#00a7ef", "#007fda");
		stringBuilder.Replace("#afabab", "#6d6c6c");
		stringBuilder.Replace("#13c865", "#1b8358");
		stringBuilder.Replace("#f5c73e", "#804f2d");
		return stringBuilder.ToString();
	}

	public static string GetBlueprintSetDesc(string setId)
	{
		string setDesc = LanguagesManager.GetSetDesc(setId);
		return ReplaceColor(setDesc);
	}

	private static void InitScrollDownArrow(GObject arrow, ScrollPane scrollPane)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Refresh();
		scrollPane.onScroll.Set(new EventCallback0(Refresh));
		void Refresh()
		{
			arrow.visible = scrollPane.percY <= 0.98f;
		}
	}

	public static bool IsConflict(string mainItem1, string mainItem2, string property1, string property2)
	{
		bool flag = IsSetAlias(property1);
		bool flag2 = IsSetAlias(property2);
		if (flag && flag2)
		{
			return true;
		}
		List<string> legendItemPropertyExclude = LegendItemsHelper.GetLegendItemPropertyExclude(property1);
		GDELegendItemData gDELegendItemData = LegendItemManager.LegendItemTemplates[mainItem2];
		if (legendItemPropertyExclude.Contains(gDELegendItemData.Identity))
		{
			return true;
		}
		if (flag ^ flag2)
		{
			string key = (flag ? property1 : property2);
			string legendItemId = (flag ? mainItem2 : mainItem1);
			string item = LegendItemsHelper.LegendItemSetMap[key].Tags[0];
			List<string> legendItemTags = LegendItemsHelper.GetLegendItemTags(legendItemId);
			string item2 = "专属";
			return legendItemTags.Contains(item2) && !legendItemTags.Contains(item);
		}
		GDELegendItemPropertyData gDELegendItemPropertyData = GDMgr.Get<GDELegendItemPropertyData>(property1);
		GDELegendItemPropertyData gDELegendItemPropertyData2 = GDMgr.Get<GDELegendItemPropertyData>(property2);
		return gDELegendItemPropertyData.Identity == gDELegendItemPropertyData2.Identity;
	}
}
