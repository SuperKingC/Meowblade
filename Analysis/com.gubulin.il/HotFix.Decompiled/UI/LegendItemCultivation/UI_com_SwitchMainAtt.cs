using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.Common.Services;

namespace UI.LegendItemCultivation;

public class UI_com_SwitchMainAtt : GComponent
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static PlayCompleteCallback _003C_003E9__23_4;

		internal void _003CConfirmSwitchMain_003Eb__23_4()
		{
			SharedMessenger.Broadcast("LEGEND_ITEM_MAIN_SWITCHED");
		}
	}

	public GImage popupBg;

	public GImage popupTitleBack;

	public GTextField popupTitle;

	public GList mainAttrList;

	public GButton ConfirmBtn;

	public const string URL = "ui://b9wlonaqmj0hh6";

	public static string Name = "UI_com_SwitchMainAtt";

	private List<ItemEntry> _alterMainEntries;

	private ItemEntry _currentMainEntry;

	private LegendItemUi _curLegendItem;

	private int _selectedIndex = 0;

	private UI_Details _parentPanel;

	public static string GetURL()
	{
		return "ui://b9wlonaqmj0hh6";
	}

	public static UI_com_SwitchMainAtt CreateInstance()
	{
		return (UI_com_SwitchMainAtt)(object)UIPackage.CreateObject("LegendItemCultivation", "com_SwitchMainAtt");
	}

	public static UI_com_SwitchMainAtt CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SwitchMainAtt).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqmj0hh6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		popupBg = (GImage)((GComponent)this).GetChild("popupBg");
		popupTitleBack = (GImage)((GComponent)this).GetChild("popupTitleBack");
		popupTitle = (GTextField)((GComponent)this).GetChild("popupTitle");
		string id = "ui://b9wlonaqmj0hh6".Replace("ui://", "") + "-" + ((GObject)popupTitle).id;
		((GObject)popupTitle).text = LanguagesManager.GetDesc(id);
		mainAttrList = (GList)((GComponent)this).GetChild("mainAttrList");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
	}

	public void Init(UI_Details parentPanel)
	{
		_parentPanel = parentPanel;
	}

	public void Show(LegendItemUi legendItem)
	{
		_parentPanel.mainAttrPopup.SetSelectedIndex(1);
		_curLegendItem = legendItem;
		_alterMainEntries = _curLegendItem?.LegendItemData?.AlterMainEntries;
		if (_alterMainEntries == null || _alterMainEntries.Count == 0)
		{
			Hide();
			return;
		}
		_currentMainEntry = _curLegendItem?.LegendItemData?.MainEntries?.FirstOrDefault();
		_selectedIndex = 0;
		RenderMainAttrList();
	}

	public void Hide()
	{
		_parentPanel.mainAttrPopup.SetSelectedIndex(0);
		_curLegendItem = null;
		_alterMainEntries = null;
		_currentMainEntry = null;
		_selectedIndex = -1;
	}

	public void RegisterEvents()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)ConfirmBtn).onClick.Add(new EventCallback0(ConfirmSwitchMain));
	}

	public void UnregisterEvents()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)ConfirmBtn).onClick.Remove(new EventCallback0(ConfirmSwitchMain));
	}

	private void RenderMainAttrList()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		_selectedIndex = 0;
		mainAttrList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			if (obj is UI_com_SwitchMainAttItem uI_com_SwitchMainAttItem)
			{
				ItemEntry entries = ((index == 0) ? _currentMainEntry : _alterMainEntries[index - 1]);
				string maxLogoText;
				Dictionary<string, string> reforgeEntry = LegendItemsHelper.GetReforgeEntry(entries, out maxLogoText);
				((GObject)uI_com_SwitchMainAttItem.primeAttribute).text = reforgeEntry?.Values.FirstOrDefault() ?? "";
				uI_com_SwitchMainAttItem.Selected.selectedIndex = ((_selectedIndex == index) ? 1 : 0);
				((GObject)uI_com_SwitchMainAttItem).onClick.Set((EventCallback0)delegate
				{
					OnSelectMainAttr(index);
				});
			}
		};
		mainAttrList.numItems = _alterMainEntries.Count + 1;
	}

	private void OnSelectMainAttr(int index)
	{
		_selectedIndex = index;
		for (int i = 0; i < mainAttrList.numItems; i++)
		{
			if (((GComponent)mainAttrList).GetChildAt(i) is UI_com_SwitchMainAttItem uI_com_SwitchMainAttItem)
			{
				uI_com_SwitchMainAttItem.Selected.selectedIndex = ((i == index) ? 1 : 0);
			}
		}
	}

	private void ConfirmSwitchMain()
	{
		if (_selectedIndex <= 0 || _selectedIndex > _alterMainEntries.Count)
		{
			Hide();
			return;
		}
		ItemEntry targetEntry = _alterMainEntries[_selectedIndex - 1];
		if (targetEntry == null || string.IsNullOrEmpty(targetEntry.EntryId))
		{
			return;
		}
		if (CheckMainSubConflict(targetEntry))
		{
			"SwapLegendItemTip3".ToLanguage().ToTip();
			return;
		}
		ILRequestHelper<LegendItemEnhancementSwitchMainResponse>.Request((EventContext)null, (Func<Task<LegendItemEnhancementSwitchMainResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemEnhancementSwitchMain(_curLegendItem.InstanceId, targetEntry.EntryId)), (Action<LegendItemEnhancementSwitchMainResponse>)delegate(LegendItemEnhancementSwitchMainResponse response)
		{
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Expected O, but got Unknown
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.TargetItem != null)
				{
					_curLegendItem.UpdateFromApiModel(response.TargetItem);
				}
				UI_LegendItemCultivationPanel.CurLegendItemData = _curLegendItem;
				string newText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(_curLegendItem);
				newText += LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(_curLegendItem);
				Hide();
				UI_LegendItemCultivationPanel panel = (UI_LegendItemCultivationPanel)(object)((GObject)_parentPanel).parent;
				UI_AttributeBack primeAttr = _parentPanel.Atrributes.primeAttribute;
				((GObject)panel.LegendItemReplaceAnim).visible = true;
				TransitionHook val = default(TransitionHook);
				panel.LegendItemReplaceAnim.ShowFlash.Play((PlayCompleteCallback)delegate
				{
					//IL_0035: Unknown result type (might be due to invalid IL or missing references)
					//IL_003a: Unknown result type (might be due to invalid IL or missing references)
					//IL_003c: Expected O, but got Unknown
					//IL_0041: Expected O, but got Unknown
					//IL_0067: Unknown result type (might be due to invalid IL or missing references)
					//IL_006c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0072: Expected O, but got Unknown
					((GObject)panel.LegendItemReplaceAnim).visible = false;
					Transition changeText = primeAttr.ChangeText;
					TransitionHook obj = val;
					if (obj == null)
					{
						TransitionHook val2 = delegate
						{
							((GObject)primeAttr.primeAttribute).text = newText;
						};
						TransitionHook val3 = val2;
						val = val2;
						obj = val3;
					}
					changeText.SetHook("ChangeText", obj);
					Transition changeText2 = primeAttr.ChangeText;
					object obj2 = _003C_003Ec._003C_003E9__23_4;
					if (obj2 == null)
					{
						PlayCompleteCallback val4 = delegate
						{
							SharedMessenger.Broadcast("LEGEND_ITEM_MAIN_SWITCHED");
						};
						_003C_003Ec._003C_003E9__23_4 = val4;
						obj2 = (object)val4;
					}
					changeText2.Play((PlayCompleteCallback)obj2);
				});
			}
		});
	}

	private bool CheckMainSubConflict(ItemEntry targetEntry)
	{
		List<ItemEntry> subEntries = _curLegendItem.LegendItemData.SubEntries;
		if (subEntries == null || subEntries.Count == 0)
		{
			return false;
		}
		if (targetEntry.Attributes == null || targetEntry.Attributes.Count == 0)
		{
			return false;
		}
		HashSet<string> hashSet = new HashSet<string>();
		foreach (ItemEntryData attribute in targetEntry.Attributes)
		{
			if (!string.IsNullOrEmpty(attribute.Key))
			{
				hashSet.Add(attribute.Key);
			}
		}
		foreach (ItemEntry item in subEntries)
		{
			if (item.Attributes == null)
			{
				continue;
			}
			foreach (ItemEntryData attribute2 in item.Attributes)
			{
				if (!string.IsNullOrEmpty(attribute2.Key) && hashSet.Contains(attribute2.Key))
				{
					return true;
				}
			}
		}
		return false;
	}
}
