using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace UI.GvGAmplifierStorage;

public class UI_main_SelectAmplifier : GComponent, IUiController
{
	public class GvGServer_SelectAmplifierModel
	{
		public Dictionary<string, int> Items;

		public int TotalPick;
	}

	public GGraph background;

	public UI_com_SelectAmplifierContent Content;

	public Transition ShowDialog;

	public const string URL = "ui://fwpu3639gi5qy";

	public static string Name = "UI_main_SelectAmplifier";

	private const string ItemIdParam = "ItemId";

	private string _itemId;

	private List<AmplifierModel> _filteredAmps;

	private List<AmplifierModel> _allAmps;

	private GvGServer_SelectAmplifierModel _itemEffect;

	private AmplifierModel _selectedAmp;

	private eRace _filterRace;

	private List<eRace> _allRaces;

	public static string GetURL()
	{
		return "ui://fwpu3639gi5qy";
	}

	public static UI_main_SelectAmplifier CreateInstance()
	{
		return (UI_main_SelectAmplifier)(object)UIPackage.CreateObject("GvGAmplifierStorage", "main_SelectAmplifier");
	}

	public static UI_main_SelectAmplifier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SelectAmplifier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639gi5qy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GGraph)((GComponent)this).GetChild("background");
		Content = (UI_com_SelectAmplifierContent)(object)((GComponent)this).GetChild("Content");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public static bool TryShowSelectAmplifier(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		if (gDEItemData.ItemType == 36)
		{
			UnityUiService.Instance.OpenPanel(Name, new Dictionary<string, object> { { "ItemId", itemId } });
			return true;
		}
		return false;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Content.BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)Content.confirmBtn).onClick.Set(new EventCallback0(OnClickConfirm));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Content.BackBtn).onClick.Clear();
		((GObject)Content.confirmBtn).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		if (parameters.TryGetValue("ItemId", out var value))
		{
			_itemId = (string)value;
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(_itemId);
			_itemEffect = JsonHelper.ToObject<GvGServer_SelectAmplifierModel>(gDEItemData.Effect);
		}
		_allAmps = new List<AmplifierModel>();
		foreach (KeyValuePair<string, int> item2 in _itemEffect.Items)
		{
			AmplifierModel item = AmpConfigHelper.Configs.TryGetAmplifier(item2.Key);
			_allAmps.Add(item);
		}
		_allRaces = new List<eRace>
		{
			eRace.全种族,
			eRace.哥布林,
			eRace.恶魔,
			eRace.亡灵,
			eRace.人类,
			eRace.兽族,
			eRace.其他
		};
		_filterRace = eRace.全种族;
		Content.filterList.selectedIndex = -1;
		Content.hasSelectAmp.SetSelectedIndex(0);
		Content.filterList.itemRenderer = (ListItemRenderer)delegate(int index, GObject val)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			UI_raceSiftBtn uI_raceSiftBtn = (UI_raceSiftBtn)(object)val;
			uI_raceSiftBtn.Type.SetSelectedIndex(index);
			((GObject)uI_raceSiftBtn).onClick.Set((EventCallback0)delegate
			{
				Content.filterList.selectedIndex = index;
				Content.hasSelectAmp.SetSelectedIndex(1);
				OnClickChangeRace(index);
			});
		};
		Content.filterList.numItems = _allRaces.Count;
		Content.AmplifierList.itemRenderer = new ListItemRenderer(OnRenderItem);
		Content.AmplifierList.SetVirtual();
		_filteredAmps = _allAmps;
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

	private void OnClickChangeRace(int index)
	{
		if (_allAmps != null && _allAmps.Count != 0)
		{
			_filterRace = _allRaces[index];
			_selectedAmp = null;
			_filteredAmps = AmpConfigHelper.FilterAmplifiers(_allAmps, 0, _filterRace);
			Refresh();
		}
	}

	private void Refresh()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		Content.AmplifierList.numItems = _filteredAmps.Count;
		bool flag = _selectedAmp != null;
		if (flag)
		{
			UI_AmplifierSlot2 selectAmpIcon = Content.selectAmpIcon;
			AmplifierModel selectedAmp = _selectedAmp;
			RenderHelper_AmplifierIcon.RenderAmplifier(selectAmpIcon.AmplifierIcon, selectedAmp);
			RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(selectAmpIcon.AffectedRange, selectedAmp);
			((GObject)Content.ampName).text = selectedAmp.Name;
			Content.PropList.itemRenderer = new ListItemRenderer(AmplifierPropRenderer);
			Content.PropList.numItems = selectedAmp.Desc.Count;
		}
		int num = (flag ? 1 : 0);
		((GObject)Content.countDesc).text = $"{num}/{_itemEffect.TotalPick}";
		Content.hasSelectedAmp.SetSelectedIndex(flag ? 1 : 0);
	}

	private void AmplifierPropRenderer(int index, GObject obj)
	{
		if (obj is UI_com_PropItemShort uI_com_PropItemShort)
		{
			List<KeyValuePair<string, float>> desc = _selectedAmp.Desc;
			KeyValuePair<string, float> keyValuePair = desc[index];
			if (keyValuePair.Key.Contains("{"))
			{
				((GObject)uI_com_PropItemShort.PropName).text = string.Format(keyValuePair.Key, keyValuePair.Value);
				((GObject)uI_com_PropItemShort.PropEffect).text = "";
			}
			else
			{
				((GObject)uI_com_PropItemShort.PropName).text = keyValuePair.Key;
				((GObject)uI_com_PropItemShort.PropEffect).text = $"{keyValuePair.Value}";
			}
		}
	}

	private void OnRenderItem(int index, GObject obj)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		UI_AmplifierSlot2 uI_AmplifierSlot = (UI_AmplifierSlot2)(object)obj;
		AmplifierModel amplifierModel = _filteredAmps[index];
		RenderHelper_AmplifierIcon.RenderAmplifier(uI_AmplifierSlot.AmplifierIcon, amplifierModel);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(uI_AmplifierSlot.AffectedRange, amplifierModel);
		bool flag = _selectedAmp?.Idx == amplifierModel.Idx;
		uI_AmplifierSlot.isSelected.SetSelectedIndex(flag ? 1 : 0);
		uI_AmplifierSlot.Type.SetSelectedIndex(1);
		((GObject)uI_AmplifierSlot).data = index;
		((GObject)uI_AmplifierSlot).onClick.Set(new EventCallback1(OnClickItem));
	}

	private void OnClickItem(EventContext contexts)
	{
		UI_AmplifierSlot2 uI_AmplifierSlot = (UI_AmplifierSlot2)(object)contexts.sender;
		int index = (int)((GObject)uI_AmplifierSlot).data;
		_selectedAmp = _filteredAmps[index];
		Refresh();
	}

	private void OnClickConfirm()
	{
		if (_selectedAmp != null)
		{
			string key = _selectedAmp.Data.Key;
			_selectedAmp = null;
			Singleton<GvGStoreHouseManager>.Instance.UseItem(_itemId, 1, new List<string> { key }, End);
		}
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
