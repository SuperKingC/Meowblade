using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using UnityEngine;

namespace UI.UseItemResult;

public class UI_main_GSUseItemResultPanel : GComponent, IUiController
{
	public Controller PageController;

	public GGraph mask;

	public GMovieClip AdvancedBox;

	public GGraph shiningSfxBack;

	public GGraph openSfxBack;

	public GList SmallItemList;

	public UI_btn_ConfirmTake ConfirmTakeBtn;

	public GImage nameBack;

	public GTextField Title;

	public UI_com_GSUseItemResultDialog Dialog;

	public Transition ShowDialogItemList;

	public Transition OpenChest;

	public Transition CloseChest;

	public Transition ShowSmallItemList;

	public const string URL = "ui://800w3r8rgv8uh";

	public static string Name = "UI_main_GSUseItemResultPanel";

	private List<Bonus> BonusList = new List<Bonus>();

	private List<RItem> RewardItems;

	private List<string> textureList = new List<string>();

	public static string GetURL()
	{
		return "ui://800w3r8rgv8uh";
	}

	public static UI_main_GSUseItemResultPanel CreateInstance()
	{
		return (UI_main_GSUseItemResultPanel)(object)UIPackage.CreateObject("UseItemResult", "main_GSUseItemResultPanel");
	}

	public static UI_main_GSUseItemResultPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GSUseItemResultPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8rgv8uh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		openSfxBack = (GGraph)((GComponent)this).GetChild("openSfxBack");
		SmallItemList = (GList)((GComponent)this).GetChild("SmallItemList");
		ConfirmTakeBtn = (UI_btn_ConfirmTake)(object)((GComponent)this).GetChild("ConfirmTakeBtn");
		nameBack = (GImage)((GComponent)this).GetChild("nameBack");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://800w3r8rgv8uh".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Dialog = (UI_com_GSUseItemResultDialog)(object)((GComponent)this).GetChild("Dialog");
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
			InitData((UseItemResponse)value);
		}
		if (parameters.TryGetValue("UseItemId", out var value2))
		{
			((GObject)Dialog.Title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, $"{value2}");
			((GObject)Title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, $"{value2}");
		}
		PlayOpenSfx();
		Update();
	}

	private void InitData(UseItemResponse result)
	{
		BonusList = new List<Bonus>();
		RewardItems = new List<RItem>();
		if (result.Bonuses == null)
		{
			return;
		}
		foreach (ModelsBonus bonuse in result.Bonuses)
		{
			RItem rItem = new RItem
			{
				ItemId = bonuse.ItemId,
				cnt = bonuse.Qty
			};
			Bonus item = Bonus.Get(rItem.ItemId, rItem.cnt);
			RewardItems.Add(rItem);
			BonusList.Add(item);
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

	private void Update()
	{
		if (BonusList.Count <= 4)
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

	private void RenderDialogItemList()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Dialog.Content.ItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			DialogItemListItemRender(i, (UI_btn_BonusItemWrapper)(object)o);
		};
		Dialog.Content.ItemList.numItems = BonusList.Count;
	}

	private void DialogItemListItemRender(int index, UI_btn_BonusItemWrapper slotWrapper)
	{
		UI_com_BonusItem bonusItem = slotWrapper.BonusItem;
		RenderBonusItem(index, bonusItem);
	}

	private void RenderSmallItemList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		SmallItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			SmallItemListItemRender(i, (UI_btn_SmallBonusItemWrapper)(object)o);
		};
		SmallItemList.numItems = BonusList.Count;
	}

	private void SmallItemListItemRender(int index, UI_btn_SmallBonusItemWrapper slotWrapper)
	{
		UI_com_BonusItem bonusItem = slotWrapper.BonusItem;
		RenderBonusItem(index, bonusItem);
	}

	private void RenderBonusItem(int index, UI_com_BonusItem slot)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		Bonus bonus = BonusList[index];
		RItem rItem = RewardItems[index];
		string prefix;
		string itemId = FGUIManager.Instance.CutItemIdPrefix(rItem.ItemId, out prefix);
		FGUIManager.Instance.SetItemIconAndFrame(slot.icon, bonus.ItemId, textureList, "", frameVisible: true, 1f, bonus);
		((GObject)slot.num).text = ((prefix == "Unlock" || prefix == "PotentialLevel") ? "" : $"x{rItem.cnt}");
		((GObject)slot.title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GObject)slot.icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void PlayOpenSfx()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
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
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}
}
