using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItemEnhancement;
using Shift.Legion.Common.Services;

namespace UI.LegendItemCultivation;

public class UI_main_EffectSwitch : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_EffectSwitch Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://b9wlonaqsrz3h4";

	public static string Name = "UI_main_EffectSwitch";

	internal const string PARAM_LEGEND_ITEM = "LegendItem";

	private LegendItemUi curLegendItem;

	private List<FxEntryGroup> alterFxEntries;

	private int selectedFxIndex = -1;

	private List<FxEntryGroup> switchListData;

	private List<int> switchListOriginalIndex;

	public static string GetURL()
	{
		return "ui://b9wlonaqsrz3h4";
	}

	public static UI_main_EffectSwitch CreateInstance()
	{
		return (UI_main_EffectSwitch)(object)UIPackage.CreateObject("LegendItemCultivation", "main_EffectSwitch");
	}

	public static UI_main_EffectSwitch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_EffectSwitch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqsrz3h4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_com_EffectSwitch)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		if (parameters != null && parameters.TryGetValue("LegendItem", out var value))
		{
			curLegendItem = (LegendItemUi)value;
			alterFxEntries = curLegendItem.LegendItemData.AlterFxEntries;
			if (alterFxEntries == null || alterFxEntries.Count == 0)
			{
				End();
				return;
			}
			RenderCurrentFx();
			RenderSwitchList();
		}
		else
		{
			End();
		}
	}

	public void OnShow()
	{
		ShowDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(ConfirmSwitchFx));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Remove(new EventCallback0(ConfirmSwitchFx));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void RenderCurrentFx()
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		List<ItemEntry> fxEntries = curLegendItem.LegendItemData.FxEntries;
		if (fxEntries == null || fxEntries.Count == 0)
		{
			((GObject)Dialog.originAtt).visible = false;
			return;
		}
		((GObject)Dialog.originAtt).visible = true;
		FxEntryGroup currentFxGroup = new FxEntryGroup
		{
			Entries = new List<ItemEntry>(fxEntries),
			SetAlias = curLegendItem.LegendItemData.SetAlias
		};
		Dialog.originAtt.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			if (obj is UI_com_EffectSwitchItem item)
			{
				RenderFxGroupItem(item, currentFxGroup, selectable: false, -1);
			}
		};
		Dialog.originAtt.numItems = 1;
	}

	private void RenderSwitchList()
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		switchListData = new List<FxEntryGroup>();
		switchListOriginalIndex = new List<int>();
		List<ItemEntry> fxEntries = curLegendItem.LegendItemData.FxEntries;
		if (fxEntries != null && fxEntries.Count > 0)
		{
			switchListData.Add(new FxEntryGroup
			{
				Entries = new List<ItemEntry>(fxEntries),
				SetAlias = curLegendItem.LegendItemData.SetAlias
			});
			switchListOriginalIndex.Add(-1);
		}
		for (int i = 0; i < alterFxEntries.Count; i++)
		{
			FxEntryGroup fxEntryGroup = alterFxEntries[i];
			bool flag = fxEntryGroup.Entries == null || fxEntryGroup.Entries.Count == 0;
			bool flag2 = string.IsNullOrEmpty(fxEntryGroup.SetAlias);
			if (!(flag && flag2))
			{
				switchListData.Add(fxEntryGroup);
				switchListOriginalIndex.Add(i);
			}
		}
		selectedFxIndex = 0;
		Dialog.switchList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			if (obj is UI_com_EffectSwitchItem item)
			{
				FxEntryGroup fxEntryGroup2 = switchListData[index];
				if (fxEntryGroup2.Entries == null)
				{
					fxEntryGroup2.Entries = new List<ItemEntry>();
				}
				RenderFxGroupItem(item, fxEntryGroup2, selectable: true, index);
			}
		};
		Dialog.switchList.numItems = switchListData.Count;
		EffectHelper.CoroutineDelay(0.6f, delegate
		{
			if (!((GObject)this).isDisposed)
			{
				float height = ((GComponent)Dialog.switchList).GetChildAt(0).height;
				float num = height * 0.8f;
				((GComponent)Dialog.switchList).scrollPane.SetPosY(num, true);
			}
		});
	}

	private void RenderFxGroupItem(UI_com_EffectSwitchItem item, FxEntryGroup fxGroup, bool selectable, int index)
	{
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		List<ItemEntry> list = fxGroup.Entries.Where((ItemEntry e) => e.IsBlueprintEntry).ToList();
		if (!string.IsNullOrEmpty(fxGroup.SetAlias))
		{
			if (list.Count > 0)
			{
				List<ItemEntry> entries = new List<ItemEntry> { list[0] };
				((GObject)item.main.primeAttribute).text = LegendItemsHelper.GetEntries(entries, isFxEntry: true);
			}
			else
			{
				((GObject)item.main).visible = false;
			}
			((GObject)item.sub).visible = true;
			string blueprintSetDesc = LegendItemsHelper.GetBlueprintSetDesc(fxGroup.SetAlias);
			((GObject)item.sub.primeAttribute).text = blueprintSetDesc;
		}
		else
		{
			if (list.Count > 0)
			{
				List<ItemEntry> entries2 = new List<ItemEntry> { list[0] };
				((GObject)item.main.primeAttribute).text = LegendItemsHelper.GetEntries(entries2, isFxEntry: true);
			}
			((GObject)item.sub).visible = false;
		}
		if (selectable)
		{
			item.Selected.selectedIndex = ((selectedFxIndex == index) ? 1 : 0);
			((GObject)item).onClick.Set((EventCallback0)delegate
			{
				OnSelectFxGroup(index);
			});
		}
		else
		{
			item.Selected.selectedIndex = 0;
		}
	}

	private void OnSelectFxGroup(int index)
	{
		selectedFxIndex = index;
		for (int i = 0; i < Dialog.switchList.numItems; i++)
		{
			if (((GComponent)Dialog.switchList).GetChildAt(i) is UI_com_EffectSwitchItem uI_com_EffectSwitchItem)
			{
				uI_com_EffectSwitchItem.Selected.selectedIndex = ((i == index) ? 1 : 0);
			}
		}
	}

	private void ConfirmSwitchFx()
	{
		if (selectedFxIndex < 0 || selectedFxIndex >= switchListData.Count)
		{
			return;
		}
		if (selectedFxIndex == 0)
		{
			End();
			return;
		}
		int alterIndex = switchListOriginalIndex[selectedFxIndex];
		if (alterIndex < 0 || alterIndex >= alterFxEntries.Count)
		{
			return;
		}
		ILRequestHelper<LegendItemEnhancementSwitchFxResponse>.Request((EventContext)null, (Func<Task<LegendItemEnhancementSwitchFxResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemEnhancementSwitchFx(curLegendItem.InstanceId, alterIndex)), (Action<LegendItemEnhancementSwitchFxResponse>)delegate(LegendItemEnhancementSwitchFxResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.TargetItem != null)
				{
					curLegendItem.UpdateFromApiModel(response.TargetItem);
				}
				UI_LegendItemCultivationPanel.CurLegendItemData = curLegendItem;
				SharedMessenger.Broadcast("LEGEND_ITEM_FX_SWITCHED");
				End();
			}
		});
	}
}
