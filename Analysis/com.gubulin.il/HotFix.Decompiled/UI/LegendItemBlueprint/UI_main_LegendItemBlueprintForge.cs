using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Spine.Unity;
using UI.GvGExpeditionHall;
using UI.LegendItemCultivation;
using UI.MainCity;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemBlueprint;

public class UI_main_LegendItemBlueprintForge : GComponent, IUiController
{
	private class BlueprintSubEntryText
	{
		public int TextType;

		public string Text;
	}

	public class ForgeItem
	{
		private string itemName;

		public ForgeCostLegendItemType CostLegendItemType { get; set; }

		public List<string> CostItemId { get; set; }

		public string MainName { get; set; }

		public int ItemRarity { get; set; }

		public LegendItemUi LegendItem { get; set; }

		public string UniversalLegendItemId { get; set; }

		public string ItemName
		{
			get
			{
				if (string.IsNullOrEmpty(itemName))
				{
					switch (CostLegendItemType)
					{
					case ForgeCostLegendItemType.Any:
						itemName = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText321"), ItemRarity, LanguagesManager.GetDesc("CsharpCodeZhTcText322"));
						break;
					case ForgeCostLegendItemType.Random:
					{
						itemName = (LegendItemManager.LegendItemTemplates.TryGetValue(CostItemId[0], out var value) ? value.Name : string.Empty);
						break;
					}
					case ForgeCostLegendItemType.Main:
						itemName = MainName;
						break;
					}
				}
				return itemName;
			}
		}
	}

	public Controller c1;

	public Controller isLocked;

	public GLoader background;

	public UI_com_Title Title;

	public GButton BackBtn;

	public GImage n39;

	public GImage n52;

	public GImage n46;

	public GTextField n47;

	public UI_com_LegendItem MainItemIcon;

	public GTextField MainItemName;

	public GTextField title3;

	public GTextField score;

	public UI_com_LegendItemPreview PreviewEntries;

	public UI_com_Scroll n53;

	public UI_btn_Lock bpLock;

	public GGroup n50;

	public GGraph n55;

	public GImage n2;

	public UI_dec_RobotBottom n6;

	public GImage n13;

	public UI_dec_SmelterFrame n8;

	public GImage n9;

	public UI_com_MainLegendItem MainLegendItem;

	public UI_com_CostLegendItems CostLegendItems;

	public GImage n19;

	public UI_dec_SelectPopupTop n18;

	public UI_btn_ConfirmForgeLarge ConfirmForge;

	public GImage n27;

	public GTextField n28;

	public GTextField n54;

	public GGraph Machinerwork;

	public GTextField n30;

	public GMovieClip n33;

	public GList CostItems;

	public GButton Help;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://h09dvkcgrtmo1d";

	public static string Name = "UI_main_LegendItemBlueprintForge";

	private Blueprint blueprint;

	private List<KeyValuePair<string, int>> costItems = new List<KeyValuePair<string, int>>();

	private List<BlueprintFxText> fxTexts = new List<BlueprintFxText>();

	private List<BlueprintSubEntryText> subEntryTexts = new List<BlueprintSubEntryText>();

	private SkeletonAnimation machinerwork;

	private Vector3 _lockOriginPos;

	public ForgeItem MainInstance;

	private List<ForgeItem> CostInstance = new List<ForgeItem>();

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo1d";
	}

	public static UI_main_LegendItemBlueprintForge CreateInstance()
	{
		return (UI_main_LegendItemBlueprintForge)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_LegendItemBlueprintForge");
	}

	public static UI_main_LegendItemBlueprintForge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemBlueprintForge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Expected O, but got Unknown
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		isLocked = ((GComponent)this).GetController("isLocked");
		background = (GLoader)((GComponent)this).GetChild("background");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id = "ui://h09dvkcgrtmo1d".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id);
		MainItemIcon = (UI_com_LegendItem)(object)((GComponent)this).GetChild("MainItemIcon");
		MainItemName = (GTextField)((GComponent)this).GetChild("MainItemName");
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id2 = "ui://h09dvkcgrtmo1d".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id2);
		score = (GTextField)((GComponent)this).GetChild("score");
		PreviewEntries = (UI_com_LegendItemPreview)(object)((GComponent)this).GetChild("PreviewEntries");
		n53 = (UI_com_Scroll)(object)((GComponent)this).GetChild("n53");
		bpLock = (UI_btn_Lock)(object)((GComponent)this).GetChild("bpLock");
		n50 = (GGroup)((GComponent)this).GetChild("n50");
		n55 = (GGraph)((GComponent)this).GetChild("n55");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n6 = (UI_dec_RobotBottom)(object)((GComponent)this).GetChild("n6");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n8 = (UI_dec_SmelterFrame)(object)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		MainLegendItem = (UI_com_MainLegendItem)(object)((GComponent)this).GetChild("MainLegendItem");
		CostLegendItems = (UI_com_CostLegendItems)(object)((GComponent)this).GetChild("CostLegendItems");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n18 = (UI_dec_SelectPopupTop)(object)((GComponent)this).GetChild("n18");
		ConfirmForge = (UI_btn_ConfirmForgeLarge)(object)((GComponent)this).GetChild("ConfirmForge");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id3 = "ui://h09dvkcgrtmo1d".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id3);
		n54 = (GTextField)((GComponent)this).GetChild("n54");
		string id4 = "ui://h09dvkcgrtmo1d".Replace("ui://", "") + "-" + ((GObject)n54).id;
		((GObject)n54).text = LanguagesManager.GetDesc(id4);
		Machinerwork = (GGraph)((GComponent)this).GetChild("Machinerwork");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id5 = "ui://h09dvkcgrtmo1d".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id5);
		n33 = (GMovieClip)((GComponent)this).GetChild("n33");
		CostItems = (GList)((GComponent)this).GetChild("CostItems");
		Help = (GButton)((GComponent)this).GetChild("Help");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		blueprint = (parameters.TryGetValue("BlueprintData", out var value) ? (value as Blueprint) : null);
		_lockOriginPos = ((GObject)bpLock).position;
		ForgeItemDataInit();
		UiHelper.LoadSpine_AB(Machinerwork, "machinerwork", 100f, delegate(SkeletonAnimation animation)
		{
			machinerwork = animation;
			SpineHelper.SetSkin((ISkeletonAnimation)(object)machinerwork, "default");
			machinerwork.AnimationState.SetAnimation(0, "machinerwork", false);
			machinerwork.timeScale = 0f;
		});
		UpdateMainItem();
		RenderCostLegendItems();
		RenderCostItems();
		RenderPreview();
		RefreshConfirmForgeBtn();
		RefreshLockState();
	}

	public void OnShow()
	{
		((GObject)n53).visible = ((GObject)PreviewEntries.Content).height > ((GObject)PreviewEntries).height;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)Help).onClick.Set(new EventCallback0(OnHelpClick));
		((GObject)ConfirmForge).onClick.Add(new EventCallback0(CheckLegendItemIdentity));
		((GComponent)PreviewEntries).scrollPane.onScroll.Add(new EventCallback0(ShowScrollTip));
		((GObject)PreviewEntries).onClick.Add(new EventCallback0(ShowScrollTip));
		SharedMessenger.AddListener<ForgeSelectLegendItem>("UPDATE_FORGE_LEGENDITEM", UpdateForgeItems);
		SharedMessenger.AddListener<string>("CLOSE_UI", UpdateLegendItemsOnChange);
		((GObject)bpLock).onClick.Set(new EventCallback0(OnClickSetLockState));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Help).onClick.Clear();
		((GObject)ConfirmForge).onClick.Remove(new EventCallback0(CheckLegendItemIdentity));
		((GComponent)PreviewEntries).scrollPane.onScroll.Remove(new EventCallback0(ShowScrollTip));
		((GObject)PreviewEntries).onClick.Remove(new EventCallback0(ShowScrollTip));
		SharedMessenger.RemoveListener<ForgeSelectLegendItem>("UPDATE_FORGE_LEGENDITEM", UpdateForgeItems);
		SharedMessenger.AddListener<string>("CLOSE_UI", UpdateLegendItemsOnChange);
		((GObject)bpLock).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnHelpClick()
	{
		"GvG3HelpButtonClick".ToShowLanguageTip();
	}

	private void CheckLegendItemIdentity()
	{
		if (CanForge())
		{
			LegendItemsHelper.ForgeOperation(ConfirmForgeEvent, MainInstance.LegendItem, blueprint);
		}
	}

	private void ConfirmForgeEvent()
	{
		string bluePrintId = blueprint.Id;
		string mainId = MainInstance.LegendItem.InstanceId.ToString();
		Dictionary<string, int> uniItemsDict = GetSelectedUniversalLegendItems();
		List<string> forgeUniIds = GetForgeUniIds();
		List<string> randomList = GetForgeRandomIds();
		List<string> anyList = GetForgeAnyIds();
		Action value = delegate
		{
			Forge(bluePrintId, mainId, randomList, anyList, blueprint.GetOther(), MainInstance.LegendItem.LegendItemData, uniItemsDict.ToRItemList());
		};
		List<string> list = new List<string>();
		list.AddRange(forgeUniIds);
		list.AddRange(randomList);
		list.AddRange(anyList);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintForgeConfirm.Name, new Dictionary<string, object>
		{
			{ "ConfirmAction", value },
			{
				"MainItemInstanceId",
				MainInstance.LegendItem.InstanceId
			},
			{ "CostItemsInstanceId", list },
			{ "UniversalLegendItemDict", uniItemsDict },
			{
				"BlueprintIconUrl",
				blueprint.GetIconName()
			}
		});
	}

	private void ShowScrollTip()
	{
		((GObject)n53).visible = !((GComponent)PreviewEntries).scrollPane.IsChildInView((GObject)(object)PreviewEntries.ContentBottom);
	}

	private void Forge(string bluePrintId, string mainId, List<string> randomList, List<string> anyList, Dictionary<string, int> other, Shift.Legion.Common.Models.LegendItem.LegendItem mainItem, List<RItem> universalLegendItem)
	{
		IEnumerable<string> enumerable = anyList.Union(randomList);
		if (enumerable != null)
		{
			foreach (string item in enumerable)
			{
				if (!long.TryParse(item, out var result))
				{
					continue;
				}
				string gvGSoldierIdByEquippedLegendItem = GameManagers.Instance.GetGvGSoldierIdByEquippedLegendItem(result);
				if (string.IsNullOrEmpty(gvGSoldierIdByEquippedLegendItem))
				{
					continue;
				}
				LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(result);
				string tipText = string.Format(LanguagesManager.GetDesc("LegendItemCostFailed_InGvG"), legendItemUi.LegendItemData.Data.Name);
				tipText.ToConfirmPopup(delegate
				{
					GameController.Contexts.Service<IUiService>().CloseAll(ignoreLoading: true, new List<string> { UI_MainCity.Name });
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGExpeditionHallPanel.Name, null);
				}, null, (AlignType)0);
				return;
			}
		}
		ILRequestHelper<LegendItemEvolvedByBlueprintResponse>.Request((EventContext)null, (Func<Task<LegendItemEvolvedByBlueprintResponse>>)(() => GameController.Contexts.Service<INetworkService>().LegendItemEvolvedByBlueprint(bluePrintId, mainId, randomList, anyList, universalLegendItem)), (Action<LegendItemEvolvedByBlueprintResponse>)delegate(LegendItemEvolvedByBlueprintResponse response)
		{
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			if (!response.Result)
			{
				if (response.ErrorCode == 81311511)
				{
					LegendItemsHelper.ShowCanNotSelectTip(LegendItemsHelper.CanNotSelectTipType.Occupied);
				}
				else
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				LegendItemsHelper.DeleteLegendItemsBeforeForge(randomList, anyList, universalLegendItem);
				LegendItemsHelper.DeleteBlueprint(bluePrintId);
				LegendItemsHelper.UpdateStockBeforeForge(bluePrintId, other);
				Shift.Legion.Common.Models.LegendItem.LegendItem evoItem = LegendItemsHelper.UpdateMainItem(mainId, response.ExtraData);
				PlayForge();
				((GComponent)(object)this).SetTimeout(3f).OnComplete((GTweenCallback)delegate
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ShowForgeResult.Name, new Dictionary<string, object>
					{
						{ "MainItem", mainItem },
						{ "EvoItem", evoItem }
					});
				});
			}
		});
	}

	private void PlayForge()
	{
		machinerwork.timeScale = 1f;
		((GObject)BackBtn).touchable = false;
		c1.selectedIndex = 1;
		CostLegendItems.c1.selectedIndex = 1;
		n8.c1.selectedIndex = 1;
		n6.c1.selectedIndex = 1;
		MainLegendItem.c1.selectedIndex = 1;
	}

	private void UpdateLegendItemsOnChange(string uiName)
	{
		if (uiName == UI_main_ShowForgeResult.Name)
		{
			End();
		}
	}

	private void RenderPreview()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		if (blueprint != null)
		{
			UpdatePreviewEntries();
			RenderPreviewFx();
			((GObject)PreviewEntries.Content.Entries.CurrentSubEntry).onClickLink.Set(new EventCallback1(OnClickEffectLink));
			((GObject)PreviewEntries.Content.Entries.MainFx).onClickLink.Set(new EventCallback1(OnClickEffectLink));
			((GObject)PreviewEntries.Content.Entries.MainSet).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	private void UpdatePreviewEntries()
	{
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Expected O, but got Unknown
		if (MainInstance == null)
		{
			return;
		}
		subEntryTexts.Clear();
		MainItemIcon.Type.selectedIndex = 0;
		MainItemIcon.AvailableState.selectedIndex = 0;
		MainItemIcon.Level.selectedIndex = 5;
		if (LegendItemManager.LegendItemTemplates.TryGetValue(blueprint.EvoId, out var value))
		{
			MainItemIcon.Icon.LoadArmsIcon(value.Icon);
		}
		if (MainInstance.LegendItem == null)
		{
			((GObject)MainItemName).text = blueprint.GetEvoItemName();
			((GObject)score).text = "????";
			PreviewEntries.Content.Entries.Type.selectedIndex = 0;
			((GObject)MainItemIcon.LevelValue).text = string.Empty;
			((GObject)MainItemIcon.LvFrame).visible = false;
			((GObject)PreviewEntries.Content.Entries.CurrentSubEntry).text = " ";
			if (blueprint.NewSubEntryUnlockLevels != null)
			{
				for (int i = 0; i < blueprint.NewSubEntryUnlockLevels.Count; i++)
				{
					subEntryTexts.Add(new BlueprintSubEntryText
					{
						TextType = 0,
						Text = string.Format("（{0}{1}{2}）", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), blueprint.NewSubEntryUnlockLevels[i], LanguagesManager.GetDesc("CsharpCodeZhTcText320"))
					});
				}
			}
		}
		else
		{
			((GObject)MainItemIcon.LevelValue).text = MainInstance.LegendItem.LegendItemData.EnhanceLevel.ToString();
			((GObject)MainItemIcon.LvFrame).visible = true;
			((GObject)MainItemName).text = LegendItemsHelper.GetLegendItemNameTitle(MainInstance.LegendItem?.LegendItemData.Data.Name, MainInstance.LegendItem.LegendItemData.EnhanceLevel);
			string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(MainInstance.LegendItem);
			((GObject)PreviewEntries.Content.Entries.MainEntry).text = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(MainInstance?.LegendItem?.LegendItemData, 0, 1);
			((GObject)PreviewEntries.Content.Entries.MainEntryUp).visible = MainInstance.LegendItem.LegendItemData.Data.Rarity < 6;
			((GObject)score).text = "????";
			PreviewEntries.Content.Entries.Type.selectedIndex = 1;
			((GObject)PreviewEntries.Content.Entries.CurrentSubEntry).text = LegendItemsHelper.GetSubEntriesBlueprint(MainInstance.LegendItem.LegendItemData, out var blueprintEntryText);
			bool flag = MainInstance.LegendItem.LegendItemData.SubEntries.Any((ItemEntry _entry) => _entry.IsBlueprintEntry);
			bool flag2 = blueprint.NewSubEntryPools != null && blueprint.NewSubEntryPools.Count > 0;
			if (flag2 && !flag)
			{
				if (blueprint.NewSubEntryUnlockLevels != null)
				{
					for (int num = 0; num < blueprint.NewSubEntryUnlockLevels.Count; num++)
					{
						string text = ((MainInstance.LegendItem.LegendItemData.EnhanceLevel < blueprint.NewSubEntryUnlockLevels[num]) ? string.Format("（{0}{1}{2}）", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), blueprint.NewSubEntryUnlockLevels[num], LanguagesManager.GetDesc("CsharpCodeZhTcText320")) : string.Empty);
						subEntryTexts.Add(new BlueprintSubEntryText
						{
							TextType = 0,
							Text = text
						});
					}
				}
			}
			else if (flag && !flag2)
			{
				for (int num2 = 0; num2 < blueprintEntryText.Count; num2++)
				{
					subEntryTexts.Add(new BlueprintSubEntryText
					{
						TextType = 1,
						Text = blueprintEntryText[num2]
					});
				}
			}
			else
			{
				for (int num3 = 0; num3 < blueprintEntryText.Count; num3++)
				{
					GRichTextField currentSubEntry = PreviewEntries.Content.Entries.CurrentSubEntry;
					((GObject)currentSubEntry).text = ((GObject)currentSubEntry).text + Environment.NewLine + blueprintEntryText[num3];
				}
			}
		}
		((GComponent)PreviewEntries.Content.Entries).EnsureBoundsCorrect();
		float num4 = 160f + ((GObject)PreviewEntries.Content.Entries.CurrentSubEntry).height - 34f;
		PreviewEntries.Content.Entries.Entries.ResizeToFit(0);
		((GObject)PreviewEntries.Content.Entries.Entries).visible = false;
		if (subEntryTexts.Count > 0)
		{
			((GObject)PreviewEntries.Content.Entries.Entries).visible = true;
			PreviewEntries.Content.Entries.Entries.itemRenderer = new ListItemRenderer(RenderBlueprintEntry);
			PreviewEntries.Content.Entries.Entries.numItems = subEntryTexts.Count;
			PreviewEntries.Content.Entries.Entries.ResizeToFit(subEntryTexts.Count);
			num4 += 40f * (float)subEntryTexts.Count;
		}
		if (!string.IsNullOrEmpty(blueprint.EnhanceFxEntryId))
		{
			PreviewEntries.Content.Entries.HasSet.selectedIndex = 0;
		}
		else if (MainInstance.LegendItem == null)
		{
			PreviewEntries.Content.Entries.HasSet.selectedIndex = 1;
			num4 += ((GObject)PreviewEntries.Content.Entries.n14).height;
		}
		else
		{
			PreviewEntries.Content.Entries.HasSet.selectedIndex = 2;
			((GObject)PreviewEntries.Content.Entries.MainFx).text = LegendItemsHelper.GetFxEntriesExcludeBlueprint(MainInstance.LegendItem.LegendItemData);
			((GObject)PreviewEntries.Content.Entries.MainSet).text = LegendItemsHelper.GetSuitDesc(MainInstance.LegendItem.LegendItemData);
			PreviewEntries.Content.Entries.n20.EnsureBoundsCorrect();
			num4 += ((GObject)PreviewEntries.Content.Entries.n20).height;
		}
		((GObject)PreviewEntries.Content.Entries).height = num4 + 10f;
	}

	private void RenderBlueprintEntry(int index, GObject obj)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		if (obj is UI_com_Entry2 uI_com_Entry)
		{
			BlueprintSubEntryText blueprintSubEntryText = subEntryTexts[index];
			uI_com_Entry.Type.selectedIndex = blueprintSubEntryText.TextType;
			if (blueprintSubEntryText.TextType == 0)
			{
				((GObject)uI_com_Entry.NewEntryUnlockLevel).text = blueprintSubEntryText.Text;
			}
			else
			{
				((GObject)uI_com_Entry.OldEntry).text = blueprintSubEntryText.Text;
			}
			((GObject)uI_com_Entry.OldEntry).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	private void RenderPreviewFx()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		fxTexts.Clear();
		fxTexts.AddRange(blueprint.GetBlueprintFxTexts());
		if (MainInstance.LegendItem != null)
		{
			List<string> fxEntries = LegendItemsHelper.GetFxEntries(MainInstance.LegendItem.LegendItemData, isBlueprint: true);
			List<BlueprintFxText> collection = fxEntries.Select((string t) => new BlueprintFxText
			{
				FxTextType = 3,
				Text = t
			}).ToList();
			if (fxTexts.Count > 0)
			{
				fxTexts.InsertRange(fxTexts.Count - 1, collection);
			}
			else
			{
				fxTexts.AddRange(collection);
			}
		}
		PreviewEntries.Content.Fx.itemRenderer = new ListItemRenderer(RenderFxItem);
		PreviewEntries.Content.Fx.numItems = fxTexts.Count;
		PreviewEntries.Content.Fx.ResizeToFit(fxTexts.Count);
	}

	private void RenderFxItem(int index, GObject obj)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		if (obj is UI_com_Propetry4 uI_com_Propetry)
		{
			BlueprintFxText blueprintFxText = fxTexts[index];
			uI_com_Propetry.Type.selectedIndex = ((index != fxTexts.Count - 1) ? 1 : 0);
			uI_com_Propetry.State.selectedIndex = blueprintFxText.FxTextType;
			if (uI_com_Propetry.State.selectedIndex == 3)
			{
				((GObject)uI_com_Propetry).height = ((GObject)uI_com_Propetry).height + 30f;
			}
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

	private void UpdateMainItem()
	{
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		MainLegendItem.Main.Type.selectedIndex = 1;
		((GObject)MainLegendItem.Main.name).text = MainInstance.ItemName;
		if (MainInstance.LegendItem == null)
		{
			MainLegendItem.Main.State.selectedIndex = 0;
			MainLegendItem.Main.Level.selectedIndex = MainInstance.ItemRarity - 1;
		}
		else
		{
			MainLegendItem.Main.State.selectedIndex = 1;
			MainLegendItem.Main.Level.selectedIndex = MainInstance.LegendItem.LegendItemData.Data.Rarity - 1;
			MainLegendItem.Main.FrameIcon.Type.selectedIndex = 0;
			MainLegendItem.Main.FrameIcon.AvailableState.selectedIndex = 0;
			MainLegendItem.Main.FrameIcon.Level.selectedIndex = MainInstance.LegendItem.LegendItemData.Data.Rarity - 1;
			((GObject)MainLegendItem.Main.FrameIcon.LevelValue).text = MainInstance.LegendItem.LegendItemData.EnhanceLevel.ToString();
			MainLegendItem.Main.FrameIcon.Icon.LoadArmsIcon(MainInstance.LegendItem.LegendItemData.Data.Icon);
		}
		((GObject)MainLegendItem).data = new LegendItemsHelper.OpenPanelData
		{
			ShowLegendItemType = 0,
			FilterItemId = MainInstance.CostItemId,
			FilterRarity = MainInstance.ItemRarity,
			CurrentSlotIndex = -1,
			CurrentSlotInstanceId = ((MainInstance.LegendItem == null) ? (-1) : MainInstance.LegendItem.InstanceId)
		};
		((GObject)MainLegendItem).onClick.Set(new EventCallback1(OpenLegendItemsPanel));
	}

	private void RenderCostLegendItems()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		CostLegendItems.Cost.itemRenderer = new ListItemRenderer(RenderCostLegendItem);
		CostLegendItems.Cost.numItems = CostInstance.Count;
	}

	private void RenderCostLegendItem(int index, GObject obj)
	{
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		if (obj is UI_com_LegendItemForgeCost uI_com_LegendItemForgeCost)
		{
			ForgeItem forgeItem = CostInstance[index];
			uI_com_LegendItemForgeCost.Type.selectedIndex = 0;
			((GObject)uI_com_LegendItemForgeCost.name).text = forgeItem.ItemName;
			uI_com_LegendItemForgeCost.Level.selectedIndex = forgeItem.ItemRarity - 1;
			if (forgeItem.LegendItem != null)
			{
				uI_com_LegendItemForgeCost.State.selectedIndex = 1;
				uI_com_LegendItemForgeCost.FrameIcon.Type.selectedIndex = 0;
				uI_com_LegendItemForgeCost.FrameIcon.AvailableState.selectedIndex = 0;
				uI_com_LegendItemForgeCost.FrameIcon.Level.selectedIndex = forgeItem.ItemRarity - 1;
				((GObject)uI_com_LegendItemForgeCost.FrameIcon.LevelValue).text = forgeItem.LegendItem.LegendItemData.EnhanceLevel.ToString();
				uI_com_LegendItemForgeCost.FrameIcon.Icon.LoadArmsIcon(forgeItem.LegendItem.LegendItemData.Data.Icon);
			}
			else if (forgeItem.UniversalLegendItemId != null)
			{
				uI_com_LegendItemForgeCost.State.selectedIndex = 2;
				string universalLegendItemId = forgeItem.UniversalLegendItemId;
				uI_com_LegendItemForgeCost.UniversalLegendItem.Level.selectedIndex = forgeItem.ItemRarity;
				uI_com_LegendItemForgeCost.UniversalLegendItem.Icon.url = UiHelper.GetIcon(universalLegendItemId).ToPublicResourceIcon();
			}
			else
			{
				uI_com_LegendItemForgeCost.State.selectedIndex = 0;
			}
			((GObject)uI_com_LegendItemForgeCost).data = new LegendItemsHelper.OpenPanelData
			{
				ShowLegendItemType = 1,
				FilterItemId = forgeItem.CostItemId,
				FilterRarity = forgeItem.ItemRarity,
				CurrentSlotIndex = index,
				CurrentSlotInstanceId = ((forgeItem.LegendItem == null) ? (-1) : forgeItem.LegendItem.InstanceId),
				CurrentSlotULItemId = forgeItem.UniversalLegendItemId
			};
			((GObject)uI_com_LegendItemForgeCost).onClick.Set(new EventCallback1(OpenLegendItemsPanel));
		}
	}

	private void RenderCostItems()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		if (blueprint != null)
		{
			costItems = blueprint.GetOther().ToList();
			CostItems.itemRenderer = new ListItemRenderer(RenderCostItem);
			CostItems.numItems = costItems.Count;
		}
	}

	private void RenderCostItem(int index, GObject obj)
	{
		if (obj is UI_com_ItemCost uI_com_ItemCost)
		{
			KeyValuePair<string, int> keyValuePair = costItems[index];
			int stock = GameManagers.Instance.StockController.GetStock(keyValuePair.Key);
			string text = ((stock >= keyValuePair.Value) ? "#aef224" : "#ff1a1a");
			((GObject)uI_com_ItemCost.ItemNum).text = "[color=" + text + "]" + stock.ShortNumberFormat() + "/" + keyValuePair.Value.ShortNumberFormat() + "[/color]";
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_ItemCost.Icon, keyValuePair.Key, null, "", frameVisible: false);
			uI_com_ItemCost.Icon.InitMaterialIntroductionBtn(keyValuePair.Key);
		}
	}

	private void OpenLegendItemsPanel(EventContext context)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		LegendItemsHelper.OpenPanelData openPanelData = ((GObject)context.sender).data as LegendItemsHelper.OpenPanelData;
		if (openPanelData != null)
		{
			LegendItemsHelper.OpenSelectLegendItems(Action);
		}
		void Action()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintSelect.Name, new Dictionary<string, object>
			{
				{ "ShowLegendItemType", openPanelData.ShowLegendItemType },
				{ "FilterItemId", openPanelData.FilterItemId },
				{ "FilterRarity", openPanelData.FilterRarity },
				{ "CurrentSlotIndex", openPanelData.CurrentSlotIndex },
				{ "CurrentSlotInstanceId", openPanelData.CurrentSlotInstanceId },
				{ "CurrentSlotItemId", openPanelData.CurrentSlotULItemId },
				{
					"SelectedUniversalLegendItems",
					GetSelectedUniversalLegendItems()
				}
			});
		}
	}

	private void OnClickSetLockState()
	{
		bool flag = GameManagers.Instance.BpLockManager.GetIsLocked(blueprint);
		GameManagers.Instance.BpLockManager.SetIsLocked(blueprint, !flag, delegate
		{
			UI_LegendItemCultivationPanel.lockSizeChange((GObject)(object)bpLock);
			RefreshLockState();
		});
	}

	private void RefreshLockState()
	{
		bool flag = GameManagers.Instance.BpLockManager.GetIsLocked(blueprint);
		isLocked.SetSelectedIndex(flag ? 1 : 0);
		RefreshConfirmForgeBtn();
	}

	private Dictionary<string, int> GetSelectedUniversalLegendItems()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (ForgeItem item in CostInstance)
		{
			if (item.UniversalLegendItemId != null)
			{
				dictionary.TryAddValue(item.UniversalLegendItemId, 1);
			}
		}
		return dictionary;
	}

	private List<string> GetForgeUniIds()
	{
		return (from t in CostInstance
			where t.UniversalLegendItemId != null
			select t.UniversalLegendItemId ?? "")?.ToList();
	}

	private List<string> GetForgeRandomIds()
	{
		return (from t in CostInstance
			where t.CostLegendItemType == ForgeCostLegendItemType.Random && t.LegendItem != null
			select t.LegendItem.InstanceId.ToString())?.ToList();
	}

	private List<string> GetForgeAnyIds()
	{
		return (from t in CostInstance
			where t.CostLegendItemType == ForgeCostLegendItemType.Any && t.LegendItem != null
			select t.LegendItem.InstanceId.ToString())?.ToList();
	}

	private bool CanForge()
	{
		if (MainInstance == null)
		{
			return false;
		}
		if (CostInstance == null || CostInstance.Count < 0)
		{
			return false;
		}
		if (MainInstance.LegendItem == null)
		{
			return false;
		}
		bool flag = true;
		if (costItems != null)
		{
			for (int i = 0; i < costItems.Count; i++)
			{
				int value = costItems[i].Value;
				int stock = GameManagers.Instance.StockController.GetStock(costItems[i].Key);
				if (value > stock)
				{
					flag = false;
					break;
				}
			}
		}
		return CostInstance.All((ForgeItem t) => t.LegendItem != null || t.UniversalLegendItemId != null) && flag;
	}

	public bool ItemInCostList(long instanceId)
	{
		int slot;
		return MainInstanceIsCost(instanceId, out slot);
	}

	private void UpdateForgeItems(ForgeSelectLegendItem selectInfo)
	{
		if (selectInfo == null)
		{
			return;
		}
		ForgeLegendItemType forgeLegendItemType = (ForgeLegendItemType)Enum.ToObject(typeof(ForgeLegendItemType), selectInfo.ItemType);
		bool flag = selectInfo.InstanceId < 0 && selectInfo.UniversalLegendItemId == null;
		int slot;
		bool flag2 = MainInstanceIsCost(selectInfo.InstanceId, out slot);
		switch (forgeLegendItemType)
		{
		case ForgeLegendItemType.Main:
			MainInstance.LegendItem = (flag ? null : LegendItemsHelper.GetLegendItemUi(selectInfo.InstanceId));
			UpdateMainItem();
			if (flag2 && !flag)
			{
				CostInstance[slot].LegendItem = null;
				CostInstance[slot].UniversalLegendItemId = null;
				RenderCostLegendItems();
			}
			RenderPreview();
			break;
		case ForgeLegendItemType.Cost:
			if (CostInstance.Count <= selectInfo.Slot)
			{
				return;
			}
			if (flag2 && !flag)
			{
				CostInstance[slot].LegendItem = null;
				CostInstance[slot].UniversalLegendItemId = null;
			}
			if (flag)
			{
				CostInstance[selectInfo.Slot].LegendItem = null;
				CostInstance[selectInfo.Slot].UniversalLegendItemId = null;
			}
			else if (selectInfo.InstanceId != -1)
			{
				CostInstance[selectInfo.Slot].LegendItem = LegendItemsHelper.GetLegendItemUi(selectInfo.InstanceId);
				CostInstance[selectInfo.Slot].UniversalLegendItemId = null;
			}
			else if (selectInfo.UniversalLegendItemId != null)
			{
				CostInstance[selectInfo.Slot].LegendItem = null;
				CostInstance[selectInfo.Slot].UniversalLegendItemId = selectInfo.UniversalLegendItemId;
			}
			RenderCostLegendItems();
			break;
		}
		RefreshConfirmForgeBtn();
	}

	private void RefreshConfirmForgeBtn()
	{
		bool enabled = CanForge();
		((GObject)ConfirmForge).enabled = enabled;
	}

	private bool MainInstanceIsCost(long instanceId, out int slot)
	{
		slot = -1;
		if (CostInstance.Count <= 0)
		{
			return false;
		}
		for (int i = 0; i < CostInstance.Count; i++)
		{
			if (CostInstance[i].LegendItem != null && CostInstance[i].LegendItem.InstanceId == instanceId)
			{
				slot = i;
				return true;
			}
		}
		return false;
	}

	private void ForgeItemDataInit()
	{
		MainInstance = new ForgeItem
		{
			CostLegendItemType = ForgeCostLegendItemType.Main,
			CostItemId = new List<string> { blueprint.MainId, blueprint.EvoId },
			MainName = blueprint.GetEvoItemName(),
			ItemRarity = 5
		};
		foreach (KeyValuePair<string, int> item in blueprint.GetRandom())
		{
			for (int i = 0; i < item.Value; i++)
			{
				CostInstance.Add(new ForgeItem
				{
					CostLegendItemType = ForgeCostLegendItemType.Random,
					CostItemId = new List<string> { item.Key },
					ItemRarity = (LegendItemManager.LegendItemTemplates.TryGetValue(item.Key, out var value) ? value.Rarity : 3)
				});
			}
		}
		foreach (KeyValuePair<string, int> item2 in blueprint.GetAny())
		{
			for (int j = 0; j < item2.Value; j++)
			{
				CostInstance.Add(new ForgeItem
				{
					CostLegendItemType = ForgeCostLegendItemType.Any,
					ItemRarity = int.Parse(item2.Key),
					CostItemId = new List<string>()
				});
			}
		}
	}
}
