using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using UI.LegendItemInfo;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemBlueprint;

public class UI_main_ShowForgeResult : GComponent, IUiController
{
	public GGraph Mask;

	public UI_eff_LightRingYellow n23;

	public GImage n2;

	public GImage n3;

	public GGroup n4;

	public GImage n11;

	public GImage n18;

	public UI_com_FrameTreasure EvoItem;

	public GTextField MainItemName;

	public GTextField EvoItemName;

	public GGraph n20;

	public GImage n15;

	public UI_com_ForgeResultLeft LefiItem;

	public UI_com_ForgeResultRight RightItem;

	public UI_btn_forge Confirm;

	public Transition t0;

	public const string URL = "ui://h09dvkcgi2xa3a";

	public static string Name = "UI_main_ShowForgeResult";

	private LegendItem leftItem;

	private LegendItem rightItem;

	private List<string> clearEntriesText = new List<string>();

	private List<string> newEntriesText = new List<string>();

	private List<BlueprintFxText> evoItemFxTexts = new List<BlueprintFxText>();

	private List<EntryText> entriesTexts = new List<EntryText>();

	public static string GetURL()
	{
		return "ui://h09dvkcgi2xa3a";
	}

	public static UI_main_ShowForgeResult CreateInstance()
	{
		return (UI_main_ShowForgeResult)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_ShowForgeResult");
	}

	public static UI_main_ShowForgeResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ShowForgeResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgi2xa3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n23 = (UI_eff_LightRingYellow)(object)((GComponent)this).GetChild("n23");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GGroup)((GComponent)this).GetChild("n4");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		EvoItem = (UI_com_FrameTreasure)(object)((GComponent)this).GetChild("EvoItem");
		MainItemName = (GTextField)((GComponent)this).GetChild("MainItemName");
		EvoItemName = (GTextField)((GComponent)this).GetChild("EvoItemName");
		n20 = (GGraph)((GComponent)this).GetChild("n20");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		LefiItem = (UI_com_ForgeResultLeft)(object)((GComponent)this).GetChild("LefiItem");
		RightItem = (UI_com_ForgeResultRight)(object)((GComponent)this).GetChild("RightItem");
		Confirm = (UI_btn_forge)(object)((GComponent)this).GetChild("Confirm");
		t0 = ((GComponent)this).GetTransition("t0");
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
		((GObject)Mask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		leftItem = (parameters.TryGetValue("MainItem", out var value) ? (value as LegendItem) : null);
		rightItem = (parameters.TryGetValue("EvoItem", out var value2) ? (value2 as LegendItem) : null);
		RenderEvoItem();
		RenderLeftItem();
		RenderRightItem();
	}

	public void OnShow()
	{
		t0.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Confirm).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Confirm).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderEvoItem()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		if (leftItem != null && rightItem != null)
		{
			RenderLegendItem(leftItem);
			((GObject)MainItemName).text = leftItem.Data.Name;
			MainItemName.color = ((leftItem.Data.Rarity > 5) ? new Color(255f, 26f, 45f) : new Color(242f, 127f, 12f));
			((GObject)EvoItemName).text = rightItem.Data.Name;
			t0.SetHook("Update", new TransitionHook(UpdateItem));
		}
		void UpdateItem()
		{
			RenderLegendItem(rightItem);
		}
	}

	private void RenderLegendItem(LegendItem item)
	{
		EvoItem.Item.Type.selectedIndex = 0;
		EvoItem.Item.AvailableState.selectedIndex = 0;
		EvoItem.Item.Level.selectedIndex = item.Data.Rarity - 1;
		((GObject)EvoItem.Item.LevelValue).text = item.EnhanceLevel.ToString();
		EvoItem.Item.Icon.LoadArmsIcon(item.Data.Icon);
	}

	private void RenderLeftItem()
	{
		if (leftItem != null)
		{
			((GObject)LefiItem.score).text = leftItem.Score.ToString();
			string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(leftItem);
			((GObject)LefiItem.primeAttribute).text = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(leftItem);
			RenderLeftItemEntries();
		}
	}

	private void RenderLeftItemEntries()
	{
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		if (leftItem != null)
		{
			entriesTexts.Clear();
			string empty = string.Empty;
			List<string> list = new List<string>();
			string empty2 = string.Empty;
			empty = LegendItemsHelper.GetSubEntries(leftItem).Replace("%[/color] ", "%[/color]  ");
			list = LegendItemsHelper.GetFxEntries(leftItem);
			empty2 = LegendItemsHelper.GetSuitDesc(leftItem);
			if (!string.IsNullOrEmpty(empty))
			{
				entriesTexts.Add(new EntryText
				{
					TextType = 0,
					Text = empty
				});
			}
			for (int i = 0; i < list.Count; i++)
			{
				entriesTexts.Add(new EntryText
				{
					TextType = 1,
					Text = list[i]
				});
			}
			if (!string.IsNullOrEmpty(empty2))
			{
				entriesTexts.Add(new EntryText
				{
					TextType = 2,
					Text = empty2
				});
			}
			LefiItem.Content.itemRenderer = new ListItemRenderer(RenderEntry);
			LefiItem.Content.numItems = entriesTexts.Count;
		}
	}

	private void RenderEntry(int index, GObject obj)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		if (obj is UI_com_Propetry1 uI_com_Propetry)
		{
			EntryText entryText = entriesTexts[index];
			uI_com_Propetry.State.selectedIndex = entryText.TextType;
			uI_com_Propetry.SetControllerPageText();
			((GObject)uI_com_Propetry).relations.ClearAll();
			if (entryText.TextType == 0)
			{
				((GObject)uI_com_Propetry).AddRelation((GObject)(object)uI_com_Propetry.SubEntries, (RelationType)23);
				((GObject)uI_com_Propetry.SubEntries).text = entryText.Text;
			}
			else
			{
				((GObject)uI_com_Propetry).AddRelation((GObject)(object)uI_com_Propetry.content, (RelationType)23);
				((GObject)uI_com_Propetry.content).text = entryText.Text;
			}
			uI_com_Propetry.Type.selectedIndex = ((index != entriesTexts.Count - 1) ? 1 : 0);
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

	private void RenderRightItem()
	{
		if (rightItem != null)
		{
			string arg = ((rightItem.Score > leftItem.Score) ? "#aef224" : "#F3F302");
			((GObject)RightItem.score).text = $"[color={arg}]{rightItem.Score}[/color]";
			string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(rightItem);
			((GObject)RightItem.primeAttribute).text = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(rightItem);
			RenderSubEntriesAndFxEntries();
		}
	}

	private void RenderSubEntriesAndFxEntries()
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		bool flag = leftItem.SubEntries.Count > rightItem.SubEntries.Count;
		bool flag2 = leftItem.SubEntries.Count < rightItem.SubEntries.Count;
		if (flag)
		{
			LegendItemsHelper.GetSubEntriesBlueprint(leftItem, out var blueprintEntryText);
			clearEntriesText.AddRange(blueprintEntryText);
		}
		List<string> blueprintEntryText2;
		string subEntriesBlueprint = LegendItemsHelper.GetSubEntriesBlueprint(rightItem, out blueprintEntryText2);
		newEntriesText.AddRange(blueprintEntryText2);
		((GObject)RightItem.SubEntries.content).text = subEntriesBlueprint;
		if (!flag2 && newEntriesText.Count > 0)
		{
			for (int i = 0; i < newEntriesText.Count; i++)
			{
				GRichTextField content = RightItem.SubEntries.content;
				((GObject)content).text = ((GObject)content).text + Environment.NewLine + newEntriesText[i];
			}
		}
		if (newEntriesText.Count > 0 && flag2)
		{
			RightItem.SubEntries.NewEntry.itemRenderer = new ListItemRenderer(RenderNewEntry);
			RightItem.SubEntries.NewEntry.numItems = newEntriesText.Count;
			RightItem.SubEntries.NewEntry.ResizeToFit(newEntriesText.Count);
		}
		else
		{
			((GObject)RightItem.SubEntries.NewEntry).height = 0f;
		}
		if (clearEntriesText.Count > 0)
		{
			RightItem.SubEntries.OldEntry.itemRenderer = new ListItemRenderer(RenderClearEntry);
			RightItem.SubEntries.OldEntry.numItems = clearEntriesText.Count;
			RightItem.SubEntries.OldEntry.ResizeToFit(clearEntriesText.Count);
		}
		else
		{
			((GObject)RightItem.SubEntries.OldEntry).height = 0f;
		}
		string suitDesc = LegendItemsHelper.GetSuitDesc(rightItem);
		if (!string.IsNullOrEmpty(suitDesc))
		{
			((GObject)RightItem.SubEntries.OriginalFx.FxText).text = LegendItemsHelper.GetFxEntriesExcludeBlueprint(rightItem);
			((GObject)RightItem.SubEntries.OriginalFx.SetText).text = suitDesc;
			List<string> fxEntries = LegendItemsHelper.GetFxEntries(rightItem, isBlueprint: true);
			for (int j = 0; j < fxEntries.Count; j++)
			{
				evoItemFxTexts.Add(new BlueprintFxText
				{
					FxTextType = 1,
					Text = fxEntries[j]
				});
			}
		}
		else
		{
			evoItemFxTexts = LegendItemsHelper.GetFxEntriesForgeResult(rightItem);
			((GObject)RightItem.SubEntries.OriginalFx).height = 0f;
			((GObject)RightItem.SubEntries.OriginalFx).visible = false;
			((GComponent)RightItem.SubEntries.OriginalFx).EnsureBoundsCorrect();
		}
		RightItem.SubEntries.AllFx.itemRenderer = new ListItemRenderer(RenderEvoItemFxEntry);
		RightItem.SubEntries.AllFx.numItems = evoItemFxTexts.Count;
		RightItem.SubEntries.AllFx.ResizeToFit(evoItemFxTexts.Count);
	}

	private void RenderClearEntry(int index, GObject obj)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		if (obj is UI_com_Entry1 uI_com_Entry)
		{
			uI_com_Entry.Type.selectedIndex = 1;
			((GObject)uI_com_Entry.OldEntry).text = clearEntriesText[index];
			((GObject)uI_com_Entry.OldEntry).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	private void RenderNewEntry(int index, GObject obj)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		if (obj is UI_com_Entry1 uI_com_Entry)
		{
			uI_com_Entry.Type.selectedIndex = 0;
			((GObject)uI_com_Entry.NewEntry).text = newEntriesText[index];
			((GObject)uI_com_Entry.NewEntry).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	private void RenderEvoItemFxEntry(int index, GObject obj)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		if (obj is UI_com_Propetry3 uI_com_Propetry)
		{
			BlueprintFxText blueprintFxText = evoItemFxTexts[index];
			uI_com_Propetry.Type.selectedIndex = ((index != evoItemFxTexts.Count - 1) ? 1 : 0);
			uI_com_Propetry.State.selectedIndex = blueprintFxText.FxTextType;
			((GObject)uI_com_Propetry.content).text = blueprintFxText.Text;
			((GObject)uI_com_Propetry.content).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}
}
