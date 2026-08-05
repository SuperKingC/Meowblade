using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.LegendItemCultivation;
using UI.Tips;

namespace UI.LegendItemBlueprint;

public class UI_main_LegendItemBlueprintInfoPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_InfoDialog Dialog;

	public const string URL = "ui://h09dvkcgjpqar";

	public static string Name = "UI_main_LegendItemBlueprintInfoPanel";

	private Blueprint blueprint;

	private List<BlueprintFxText> fxTexts = new List<BlueprintFxText>();

	private List<KeyValuePair<string, int>> randomItems = new List<KeyValuePair<string, int>>();

	private List<KeyValuePair<string, int>> anyItems = new List<KeyValuePair<string, int>>();

	private List<KeyValuePair<string, int>> items = new List<KeyValuePair<string, int>>();

	public static string GetURL()
	{
		return "ui://h09dvkcgjpqar";
	}

	public static UI_main_LegendItemBlueprintInfoPanel CreateInstance()
	{
		return (UI_main_LegendItemBlueprintInfoPanel)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_LegendItemBlueprintInfoPanel");
	}

	public static UI_main_LegendItemBlueprintInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemBlueprintInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgjpqar", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_InfoDialog)(object)((GComponent)this).GetChild("Dialog");
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
		blueprint = (parameters.TryGetValue("BlueprintData", out var value) ? (value as Blueprint) : null);
		Dialog.Type.selectedIndex = (parameters.TryGetValue("Type", out var value2) ? ((int)value2) : 0);
		RenderBlueprintMainInfo();
		RenderContent();
		RefreshLockState();
	}

	public void OnShow()
	{
		((GComponent)Dialog.Content).scrollPane.ScrollDown(1f, false);
		((GComponent)Dialog.Content).scrollPane.ScrollTop(false);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GComponent)Dialog.Content).scrollPane.onScroll.Add(new EventCallback0(ShowScrollTip));
		((GObject)Dialog.Content).onClick.Add(new EventCallback0(ShowScrollTip));
		((GObject)Dialog.Forge).onClick.Add(new EventCallback0(OpenForgePanel));
		((GObject)Dialog.bpLock).onClick.Set(new EventCallback0(OnClickSetLockState));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GComponent)Dialog.Content).scrollPane.onScroll.Remove(new EventCallback0(ShowScrollTip));
		((GObject)Dialog.Content).onClick.Remove(new EventCallback0(ShowScrollTip));
		((GObject)Dialog.Forge).onClick.Remove(new EventCallback0(OpenForgePanel));
		((GObject)Dialog.bpLock).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ShowScrollTip()
	{
		((GObject)Dialog.ScrollTip).visible = !((GComponent)Dialog.Content).scrollPane.IsChildInView((GObject)(object)Dialog.Content.ContentBottom);
	}

	private void RenderBlueprintMainInfo()
	{
		if (blueprint != null)
		{
			((GObject)Dialog.BlueprintName).text = blueprint.GetName();
			Dialog.BlueprintIcon.LoadBlueprintIcon(blueprint.GetIconName());
			((GObject)Dialog.Desc).text = blueprint.GetDesc();
			if (LegendItemManager.LegendItemTemplates.TryGetValue(blueprint.EvoId, out var value))
			{
				LegendItemsHelper.RenderLegendItem(Dialog.EvoLegendItem, value);
			}
		}
	}

	private void RenderContent()
	{
		if (blueprint != null)
		{
			RenderCostContent();
			RenderPreviewContent();
		}
	}

	private void RenderPreviewContent()
	{
		RenderEntries();
		RenderFx();
	}

	private void OnClickSetLockState()
	{
		bool isLocked = GameManagers.Instance.BpLockManager.GetIsLocked(blueprint);
		GameManagers.Instance.BpLockManager.SetIsLocked(blueprint, !isLocked, delegate
		{
			UI_LegendItemCultivationPanel.lockSizeChange((GObject)(object)Dialog.bpLock);
			RefreshLockState();
		});
	}

	private void RefreshLockState()
	{
		bool isLocked = GameManagers.Instance.BpLockManager.GetIsLocked(blueprint);
		Dialog.isLocked.SetSelectedIndex(isLocked ? 1 : 0);
	}

	private void RenderEntries()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		float num = 165f;
		Dialog.Content.PreviewContent.Entries.Type.selectedIndex = 0;
		Dialog.Content.PreviewContent.Entries.Entries.ResizeToFit(0);
		if (blueprint.NewSubEntryUnlockLevels != null)
		{
			Dialog.Content.PreviewContent.Entries.Entries.itemRenderer = new ListItemRenderer(RenderEntry);
			Dialog.Content.PreviewContent.Entries.Entries.numItems = blueprint.NewSubEntryUnlockLevels.Count;
			Dialog.Content.PreviewContent.Entries.Entries.ResizeToFit(blueprint.NewSubEntryUnlockLevels.Count);
			num += 40f * (float)blueprint.NewSubEntryUnlockLevels.Count;
		}
		if (string.IsNullOrEmpty(blueprint.EnhanceFxEntryId))
		{
			Dialog.Content.PreviewContent.Entries.Type.selectedIndex = 1;
			num += 160f;
		}
		((GObject)Dialog.Content.PreviewContent.Entries).height = num;
	}

	private void RenderEntry(int index, GObject obj)
	{
		if (obj is UI_com_Entry uI_com_Entry)
		{
			((GObject)uI_com_Entry.UnlockTip).text = string.Format("({0}{1}{2})", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), blueprint.NewSubEntryUnlockLevels[index], LanguagesManager.GetDesc("CsharpCodeZhTcText320"));
		}
	}

	private void RenderFx()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		fxTexts = blueprint.GetBlueprintFxTexts();
		Dialog.Content.PreviewContent.AllFx.Fx.itemRenderer = new ListItemRenderer(RenderFxItem);
		Dialog.Content.PreviewContent.AllFx.Fx.numItems = fxTexts.Count;
		Dialog.Content.PreviewContent.AllFx.Fx.ResizeToFit(fxTexts.Count);
	}

	private void RenderFxItem(int index, GObject obj)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		if (obj is UI_com_Propetry uI_com_Propetry)
		{
			BlueprintFxText blueprintFxText = fxTexts[index];
			uI_com_Propetry.Type.selectedIndex = ((index != fxTexts.Count - 1) ? 1 : 0);
			uI_com_Propetry.State.selectedIndex = blueprintFxText.FxTextType;
			((GObject)uI_com_Propetry.content).text = blueprintFxText.Text;
			((GObject)uI_com_Propetry.content).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	public static void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}

	private void RenderCostContent()
	{
		if (LegendItemManager.LegendItemTemplates.TryGetValue(blueprint.MainId, out var value))
		{
			LegendItemsHelper.RenderLegendItem(Dialog.Content.CostContent.MainLegendItem.EvoLegendItem, value);
			((GObject)Dialog.Content.CostContent.MainLegendItem.Num).text = "x1";
		}
		RenderCostLegendItems();
		RenderCostOtherItems();
	}

	private void RenderCostLegendItems()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		randomItems = blueprint.GetRandom().ToList();
		anyItems = blueprint.GetAny().ToList();
		Dialog.Content.CostContent.CostLegendItems.itemRenderer = new ListItemRenderer(RenderCostLegendItem);
		int num = randomItems.Count + anyItems.Count;
		Dialog.Content.CostContent.CostLegendItems.numItems = num;
		Dialog.Content.CostContent.CostLegendItems.ResizeToFit(num);
	}

	private void RenderCostLegendItem(int index, GObject obj)
	{
		if (!(obj is UI_com_LegendItemCost uI_com_LegendItemCost))
		{
			return;
		}
		bool flag = index < randomItems.Count;
		KeyValuePair<string, int> keyValuePair = (flag ? randomItems[index] : anyItems[index - randomItems.Count]);
		uI_com_LegendItemCost.Type.selectedIndex = ((!flag) ? 1 : 0);
		if (flag)
		{
			if (LegendItemManager.LegendItemTemplates.TryGetValue(keyValuePair.Key, out var value))
			{
				LegendItemsHelper.RenderLegendItem(uI_com_LegendItemCost.EvoLegendItem, value);
			}
		}
		else
		{
			LegendItemsHelper.RenderAnyLegendItem(uI_com_LegendItemCost.EvoLegendItem, int.Parse(keyValuePair.Key));
		}
		((GObject)uI_com_LegendItemCost.Num).text = $"x{keyValuePair.Value}";
	}

	private void RenderCostOtherItems()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		items = blueprint.GetOther().ToList();
		Dialog.Content.CostContent.CostItems.itemRenderer = new ListItemRenderer(RenderCostOtherItem);
		Dialog.Content.CostContent.CostItems.numItems = items.Count;
		Dialog.Content.CostContent.CostItems.ResizeToFit(items.Count);
	}

	private void RenderCostOtherItem(int index, GObject obj)
	{
		if (obj is UI_com_ItemCost uI_com_ItemCost)
		{
			KeyValuePair<string, int> keyValuePair = items[index];
			((GObject)uI_com_ItemCost.ItemNum).text = $"{keyValuePair.Value}";
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_ItemCost.Icon, keyValuePair.Key, null, "", frameVisible: false);
		}
	}

	private void OpenForgePanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintForge.Name, new Dictionary<string, object> { { "BlueprintData", blueprint } });
		End();
	}
}
