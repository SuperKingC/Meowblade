using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UI.GvGAmpIntroduction;
using UnityEngine;

namespace UI.UseItemResult;

public class UI_main_GvGUseItemResultPanel : GComponent, IUiController
{
	public enum eSlotType
	{
		Item,
		Amplifier
	}

	public class SlotData
	{
		public eSlotType Type;

		public RItem RewardItem;

		public Bonus Bonus;
	}

	public Controller PageController;

	public Controller HasTalent;

	public GGraph mask;

	public GMovieClip AdvancedBox;

	public GGraph shiningSfxBack;

	public GGraph openSfxBack;

	public GList SmallItemList;

	public UI_btn_ConfirmTake ConfirmTakeBtn;

	public GImage nameBack;

	public GTextField Title;

	public UI_com_GvGUseItemResultDialog Dialog;

	public GTextField Tips;

	public GGroup GroupFor4;

	public Transition ShowDialogItemList;

	public Transition OpenChest;

	public Transition CloseChest;

	public Transition ShowSmallItemList;

	public const string URL = "ui://800w3r8rez1c0";

	public static string Name = "UI_main_GvGUseItemResultPanel";

	private Dictionary<string, TalentRItem> TalentRItems_Dict;

	private List<SlotData> Slot_List;

	private bool IsShowSrcTalent = false;

	private List<string> textureList = new List<string>();

	public static string GetURL()
	{
		return "ui://800w3r8rez1c0";
	}

	public static UI_main_GvGUseItemResultPanel CreateInstance()
	{
		return (UI_main_GvGUseItemResultPanel)(object)UIPackage.CreateObject("UseItemResult", "main_GvGUseItemResultPanel");
	}

	public static UI_main_GvGUseItemResultPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGUseItemResultPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rez1c0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		HasTalent = ((GComponent)this).GetController("HasTalent");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		openSfxBack = (GGraph)((GComponent)this).GetChild("openSfxBack");
		SmallItemList = (GList)((GComponent)this).GetChild("SmallItemList");
		ConfirmTakeBtn = (UI_btn_ConfirmTake)(object)((GComponent)this).GetChild("ConfirmTakeBtn");
		nameBack = (GImage)((GComponent)this).GetChild("nameBack");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://800w3r8rez1c0".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Dialog = (UI_com_GvGUseItemResultDialog)(object)((GComponent)this).GetChild("Dialog");
		Tips = (GTextField)((GComponent)this).GetChild("Tips");
		string id2 = "ui://800w3r8rez1c0".Replace("ui://", "") + "-" + ((GObject)Tips).id;
		((GObject)Tips).text = LanguagesManager.GetDesc(id2);
		GroupFor4 = (GGroup)((GComponent)this).GetChild("GroupFor4");
		ShowDialogItemList = ((GComponent)this).GetTransition("ShowDialogItemList");
		OpenChest = ((GComponent)this).GetTransition("OpenChest");
		CloseChest = ((GComponent)this).GetTransition("CloseChest");
		ShowSmallItemList = ((GComponent)this).GetTransition("ShowSmallItemList");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 998;
		if (parameters.TryGetValue("Result", out var value))
		{
			InitData((S2C_GvGStorehouseChange.Request)value);
		}
		if (parameters.TryGetValue("UseItemId", out var value2))
		{
			((GObject)Dialog.Title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, $"{value2}");
			((GObject)Title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, $"{value2}");
		}
		IsShowSrcTalent = false;
		PlayOpenSfx();
		Update();
	}

	private void InitData(S2C_GvGStorehouseChange.Request result)
	{
		TalentRItems_Dict = new Dictionary<string, TalentRItem>();
		if (result.TalentRItems != null)
		{
			foreach (TalentRItem talentRItem in result.TalentRItems)
			{
				TalentRItems_Dict.Add(talentRItem.ItemId, talentRItem);
			}
		}
		Slot_List = new List<SlotData>();
		if (result.RItems_Amplifiers != null)
		{
			foreach (RItem rItems_Amplifier in result.RItems_Amplifiers)
			{
				SlotData item = new SlotData
				{
					RewardItem = rItems_Amplifier,
					Bonus = Bonus.Get(rItems_Amplifier.ItemId, rItems_Amplifier.cnt),
					Type = eSlotType.Amplifier
				};
				Slot_List.Add(item);
			}
		}
		if (result.RItems_RewardItems == null)
		{
			return;
		}
		foreach (RItem rItems_RewardItem in result.RItems_RewardItems)
		{
			SlotData item2 = new SlotData
			{
				RewardItem = rItems_RewardItem,
				Bonus = Bonus.Get(rItems_RewardItem.ItemId, rItems_RewardItem.cnt),
				Type = eSlotType.Item
			};
			if (TalentRItems_Dict.ContainsKey(rItems_RewardItem.ItemId))
			{
				Slot_List.Insert(0, item2);
			}
			else
			{
				Slot_List.Add(item2);
			}
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Dialog.ExitBtn).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(End));
		((GObject)ConfirmTakeBtn).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Dialog.ExitBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.ConfirmBtn).onClick.Remove(new EventCallback0(End));
		((GObject)ConfirmTakeBtn).onClick.Remove(new EventCallback0(End));
	}

	private void OnShowAmpIntro(int idx)
	{
		Dictionary<string, object> parameters = new Dictionary<string, object> { { "AmpIdx", idx } };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_mian_GvGAmpIntroductionPopup.Name, parameters);
	}

	private void Update()
	{
		if (Slot_List.Count <= 4)
		{
			PageController.selectedIndex = 1;
			RenderSmallItemList();
		}
		else
		{
			PageController.selectedIndex = 2;
			RenderDialogItemList();
		}
	}

	private void RenderSmallItemList()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		SmallItemList.itemProvider = new ListItemProvider(provider);
		SmallItemList.itemRenderer = new ListItemRenderer(renderer);
		SmallItemList.numItems = Slot_List.Count;
		string provider(int i)
		{
			eSlotType type = Slot_List[i].Type;
			eSlotType eSlotType = type;
			if (eSlotType != eSlotType.Item && eSlotType == eSlotType.Amplifier)
			{
				return "ui://UseItemResult/btn_AmplifierWrapper";
			}
			return "ui://UseItemResult/btn_SmallBonusItemWrapper";
		}
		void renderer(int i, GObject o)
		{
			eSlotType type = Slot_List[i].Type;
			eSlotType eSlotType = type;
			if (eSlotType != eSlotType.Item && eSlotType == eSlotType.Amplifier)
			{
				RenderAmplifierItem(i, ((UI_btn_AmplifierWrapper)(object)o).AmplifierItem);
			}
			else
			{
				RenderBonusItem(i, ((UI_btn_SmallBonusItemWrapper)(object)o).BonusItem);
			}
		}
	}

	private void RenderDialogItemList()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		Dialog.Content.ItemList.itemProvider = new ListItemProvider(provider);
		Dialog.Content.ItemList.itemRenderer = new ListItemRenderer(renderer);
		Dialog.Content.ItemList.numItems = Slot_List.Count;
		string provider(int i)
		{
			eSlotType type = Slot_List[i].Type;
			eSlotType eSlotType = type;
			if (eSlotType != eSlotType.Item && eSlotType == eSlotType.Amplifier)
			{
				return "ui://UseItemResult/btn_AmplifierWrapper";
			}
			return "ui://UseItemResult/btn_BonusItemWrapper";
		}
		void renderer(int i, GObject o)
		{
			eSlotType type = Slot_List[i].Type;
			eSlotType eSlotType = type;
			if (eSlotType != eSlotType.Item && eSlotType == eSlotType.Amplifier)
			{
				RenderAmplifierItem(i, ((UI_btn_AmplifierWrapper)(object)o).AmplifierItem);
			}
			else
			{
				RenderBonusItem(i, ((UI_btn_BonusItemWrapper)(object)o).BonusItem);
			}
		}
	}

	private void RenderAmplifierItem(int i, UI_com_AmplifierSlot slot)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		string itemId = Slot_List[i].RewardItem.ItemId;
		int cnt = Slot_List[i].RewardItem.cnt;
		AmplifierModel amp = AmpConfigHelper.Configs.TryGetAmplifier(itemId);
		RenderHelper_AmplifierIcon.RenderAmplifier(slot.AmplifierIcon, amp);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedRange(slot.AffectedRange, amp);
		((GObject)slot.Count).text = $"x{cnt}";
		slot.Quatity.selectedIndex = amp.Quality;
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			OnShowAmpIntro(amp.Idx);
		});
	}

	private void RenderBonusItem(int index, UI_com_BonusItem slot)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		Bonus bonus = Slot_List[index].Bonus;
		RItem rewardItem = Slot_List[index].RewardItem;
		string prefix;
		string itemId = FGUIManager.Instance.CutItemIdPrefix(rewardItem.ItemId, out prefix);
		FGUIManager.Instance.SetItemIconAndFrame(slot.icon, bonus.ItemId, textureList, "", frameVisible: true, 1f, bonus);
		((GObject)slot.num).text = ((prefix == "Unlock" || prefix == "PotentialLevel") ? "" : $"x{rewardItem.cnt}");
		((GObject)slot.title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GObject)slot.icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		if (IsShowSrcTalent && TalentRItems_Dict.TryGetValue(rewardItem.ItemId, out var talentRItem))
		{
			slot.ShowSrcTalent.selectedIndex = 1;
			((GObject)slot.num).text = $"x{rewardItem.cnt + talentRItem.cnt}";
			slot.TalentSrcList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				SrcTalentListItemRenderer(i, (UI_com_TalentSrc)(object)o, talentRItem.TalentSrcList);
			};
			slot.TalentSrcList.numItems = talentRItem.TalentSrcList.Count;
		}
	}

	private void SrcTalentListItemRenderer(int index, UI_com_TalentSrc slot, List<int> talentSrcList)
	{
		int idx = talentSrcList[index];
		slot.Icon.url = Singleton<GvGTalentsManager>.Instance.GetTalentUrl(idx);
	}

	private void PlayOpenSfx()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		UiAudioManager.Instance.PlaySoundEffect("OpenBox");
		OpenChest.SetHook("OnShowOpenSfxBack", (TransitionHook)delegate
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(openSfxBack, "treasure_open", new Vector3(100f, 100f, 100f));
		});
		OpenChest.SetHook("OnShowShiningSfxBack", (TransitionHook)delegate
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(shiningSfxBack, "treasure_shining", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureOpen)
			{
				UiAudioManager.Instance.LoadSoundsForSfx(treasureOpen, "BoxFlashing", playLoop: true);
			});
		});
		ShowDialogItemList.SetHook("OnFinished", new TransitionHook(OnPlayFinished));
		ShowSmallItemList.SetHook("OnFinished", new TransitionHook(OnPlayFinished));
	}

	private void OnPlayFinished()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		if (TalentRItems_Dict.Count > 0)
		{
			Timers.inst.Add(0.8f, 1, new TimerCallback(playFinishedCallBack));
		}
	}

	private void playFinishedCallBack(object p)
	{
		if (!((GObject)this).isDisposed)
		{
			IsShowSrcTalent = true;
			HasTalent.selectedIndex = 1;
			Dialog.HasTalent.selectedIndex = 1;
			Update();
		}
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

	private void End()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(playFinishedCallBack)))
		{
			Timers.inst.Remove(new TimerCallback(playFinishedCallBack));
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}
}
