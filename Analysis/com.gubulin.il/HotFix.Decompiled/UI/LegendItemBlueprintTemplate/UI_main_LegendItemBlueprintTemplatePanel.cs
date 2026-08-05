using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.Tips;

namespace UI.LegendItemBlueprintTemplate;

public class UI_main_LegendItemBlueprintTemplatePanel : GComponent, IUiController
{
	private enum OutputType
	{
		Common,
		Random
	}

	public GGraph Mask;

	public UI_com_InfoDialog Dialog;

	public const string URL = "ui://se4hok01wrnf0";

	public static string Name = "UI_main_LegendItemBlueprintTemplatePanel";

	private List<BlueprintFxText> fxTexts = new List<BlueprintFxText>();

	private ArchiveExtension_Formulas.GvGStoreItemInfo _storeItemInfo;

	public static string GetURL()
	{
		return "ui://se4hok01wrnf0";
	}

	public static UI_main_LegendItemBlueprintTemplatePanel CreateInstance()
	{
		return (UI_main_LegendItemBlueprintTemplatePanel)(object)UIPackage.CreateObject("LegendItemBlueprintTemplate", "main_LegendItemBlueprintTemplatePanel");
	}

	public static UI_main_LegendItemBlueprintTemplatePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemBlueprintTemplatePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		_storeItemInfo = (parameters.TryGetValue("Info", out var value) ? (value as ArchiveExtension_Formulas.GvGStoreItemInfo) : null);
		RenderContent();
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
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GComponent)Dialog.Content).scrollPane.onScroll.Add(new EventCallback0(ShowScrollTip));
		((GObject)Dialog.Content).onClick.Add(new EventCallback0(ShowScrollTip));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GComponent)Dialog.Content).scrollPane.onScroll.Remove(new EventCallback0(ShowScrollTip));
		((GObject)Dialog.Content).onClick.Remove(new EventCallback0(ShowScrollTip));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ShowScrollTip()
	{
		((GObject)Dialog.ScrollTip).visible = !((GComponent)Dialog.Content).scrollPane.IsChildInView((GObject)(object)Dialog.Content.ContentBottom);
	}

	private void RenderContent()
	{
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		if (_storeItemInfo != null)
		{
			((GObject)Dialog.BlueprintName).text = _storeItemInfo.GetMainName();
			Dialog.BlueprintIcon.LoadBlueprintIcon(_storeItemInfo.BlueprintIcon);
			((GObject)Dialog.Desc).text = _storeItemInfo.GetDesc();
			if (LegendItemManager.LegendItemTemplates.TryGetValue(_storeItemInfo.MainId, out var value))
			{
				Dialog.Type.SetSelectedIndex(0);
				LegendItemsHelper.RenderLegendItem(Dialog.EvoLegendItem, value);
			}
			else
			{
				Dialog.Type.SetSelectedIndex(1);
			}
			UI_com_Entries entries = Dialog.Content.PreviewContent.Entries;
			((GObject)entries.MainEntry).text = _storeItemInfo.GetMainEntryText();
			((GObject)entries.SubEntry).text = _storeItemInfo.GetSubEntryText();
			string newSubEntryText = _storeItemInfo.GetNewSubEntryText();
			if (string.IsNullOrEmpty(newSubEntryText))
			{
				((GObject)entries.NewEntries).height = 0f;
			}
			else
			{
				UI_com_Entry uI_com_Entry = entries.NewEntries.AddItemFromPool() as UI_com_Entry;
				((GObject)uI_com_Entry.EntryText).text = _storeItemInfo.GetNewSubEntryText();
				entries.NewEntries.ResizeToFit(entries.NewEntries.numItems);
			}
			Dialog.Content.PreviewContent.AllFx.Fx.numItems = 0;
			string fxText = _storeItemInfo.GetFxText();
			if (!string.IsNullOrEmpty(fxText))
			{
				fxTexts.Add(new BlueprintFxText
				{
					Text = fxText,
					FxTextType = 0
				});
			}
			string newFxText = _storeItemInfo.GetNewFxText();
			if (!string.IsNullOrEmpty(newFxText))
			{
				fxTexts.Add(new BlueprintFxText
				{
					Text = newFxText,
					FxTextType = 1
				});
			}
			string newSetAliasText = _storeItemInfo.GetNewSetAliasText();
			if (!string.IsNullOrEmpty(newSetAliasText))
			{
				fxTexts.Add(new BlueprintFxText
				{
					Text = newSetAliasText,
					FxTextType = 2
				});
			}
			Dialog.Content.PreviewContent.AllFx.Fx.itemRenderer = new ListItemRenderer(RenderFxItem);
			Dialog.Content.PreviewContent.AllFx.Fx.numItems = fxTexts.Count;
			Dialog.Content.PreviewContent.AllFx.Fx.ResizeToFit(fxTexts.Count);
			((GObject)Dialog.Content.CostContent.CostText).text = _storeItemInfo.GetCostText();
		}
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

	private void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}
}
