using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Helper;
using UI.FullScreenAnimation;
using UI.GameActivity;
using UI.GiftBag;
using UI.SpecialActivity;
using UI.Warehouse;
using UnityEngine;

namespace UI.Tips;

public class UI_TakeItems_Large : GComponent, IUiController
{
	public Controller PageController;

	public GGraph mask;

	public GMovieClip CommonBox;

	public GMovieClip AdvancedBox;

	public GGraph shiningSfxBack;

	public UI_TakeContent_Large Content;

	public UI_SelectedItem Selected;

	public GGraph openSfxBack;

	public GGroup mainGroup;

	public GImage boxIcon;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public Transition showUp;

	public Transition fade;

	public Transition ShowSelected;

	public const string URL = "ui://47lbpgx9vur65f";

	public static string Name = "UI_TakeItems_Large";

	public static UI_TakeItems_Large TakeItemsPanel;

	private List<Bonus> _items;

	private List<KeyValuePair<string, int>> _selectItems;

	private List<Bonus> _resultBonuses;

	private StoreItem giftBag;

	private List<string> _textureList = new List<string>();

	private int rarity;

	private GMovieClip boxClip;

	private bool CanBuy;

	private bool ShowReward = false;

	private bool AutoBuy = false;

	private bool ShowBoxReward = false;

	private bool ShowSelecledReward = false;

	private string openBoxSound;

	private bool waitOpen;

	private IUiController parent;

	private UI_GiftBagPanel giftBagPanel;

	private UI_SpecialActivityPanel specialActivityPanel;

	private UI_ActivityPanel activityPanel;

	private UI_WarehousePanel warehousePanel;

	private GameStateEntity _gameStateEntity;

	private string selectItemId;

	private UI_TakeItemBtn selectedItem;

	public static string GetURL()
	{
		return "ui://47lbpgx9vur65f";
	}

	public static UI_TakeItems_Large CreateInstance()
	{
		return (UI_TakeItems_Large)(object)UIPackage.CreateObject("Tips", "TakeItems_Large");
	}

	public static UI_TakeItems_Large CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeItems_Large).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9vur65f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		CommonBox = (GMovieClip)((GComponent)this).GetChild("CommonBox");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		Content = (UI_TakeContent_Large)(object)((GComponent)this).GetChild("Content");
		Selected = (UI_SelectedItem)(object)((GComponent)this).GetChild("Selected");
		openSfxBack = (GGraph)((GComponent)this).GetChild("openSfxBack");
		mainGroup = (GGroup)((GComponent)this).GetChild("mainGroup");
		boxIcon = (GImage)((GComponent)this).GetChild("boxIcon");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		showUp = ((GComponent)this).GetTransition("showUp");
		fade = ((GComponent)this).GetTransition("fade");
		ShowSelected = ((GComponent)this).GetTransition("ShowSelected");
	}

	public void RegisterUiEventListeners()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		((GObject)Content.ConfirmBtn).onClick.Add(new EventCallback1(OnClickConfirmBtn));
		((GObject)Content.Close).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener<string>("CLOSE_UI", OpenBoxOnUiClose);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Content.ConfirmBtn).onClick.Remove(new EventCallback1(OnClickConfirmBtn));
		((GObject)Content.Close).onClick.Remove(new EventCallback0(End));
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OpenBoxOnUiClose);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 100;
		TakeItemsPanel = this;
		((GObject)Content.t1).text = LanguagesManager.GetDesc("CsharpCodeZhTcText668") + "0/1";
		_selectItems = (List<KeyValuePair<string, int>>)parameters["SelectItems"];
		if (parameters.ContainsKey("Parent"))
		{
			parent = (IUiController)parameters["Parent"];
			if (parent is UI_GiftBagPanel)
			{
				giftBagPanel = (UI_GiftBagPanel)parent;
				ThinkingDataHelper.Instance.PayPreviewTrack(giftBag.StoreItemId);
				ThinkingDataHelper.Instance.TimeEvent("nopay_preview");
			}
			else if (parent is UI_SpecialActivityPanel)
			{
				specialActivityPanel = (UI_SpecialActivityPanel)parent;
				ThinkingDataHelper.Instance.PayPreviewTrack(giftBag.StoreItemId);
				ThinkingDataHelper.Instance.TimeEvent("nopay_preview");
			}
			else if (parent is UI_ActivityPanel)
			{
				activityPanel = (UI_ActivityPanel)parent;
			}
			else if (parent is UI_WarehousePanel)
			{
				warehousePanel = (UI_WarehousePanel)parent;
			}
		}
		string text = (string)parameters["Name"];
		if (parameters.TryGetValue("ShowSelectedReward", out var value))
		{
			ShowSelecledReward = (bool)value;
			CanBuy = false;
			if (parameters.TryGetValue("SelectItemId", out var value2))
			{
				selectItemId = (string)value2;
			}
			((GObject)Content.ConfirmBtn).enabled = false;
			if (parameters.TryGetValue("NoClose", out var value3) && (bool)value3)
			{
				((GObject)mask).touchable = false;
			}
		}
		if (parameters.TryGetValue("WaitOpen", out var value4))
		{
			waitOpen = (bool)value4;
		}
		PageController.selectedIndex = 1;
		((GObject)AdvancedBox).visible = true;
		boxClip = AdvancedBox;
		((GObject)CommonBox).visible = false;
		openBoxSound = "OpenBox";
		((GObject)shiningSfxBack).y = 535f;
		((GObject)openSfxBack).y = 250f;
		if (!waitOpen)
		{
			PlayOpenSfx();
		}
		else
		{
			((GObject)this).visible = false;
		}
		((GObject)Content.helpBtn).visible = false;
	}

	public void OnShow()
	{
		if (!waitOpen)
		{
			UpdatePanel();
		}
		((GObject)mask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
	}

	public void BeforeDestroy()
	{
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
		TakeItemsPanel = null;
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
	}

	public void OnContentShow()
	{
		UiTagManager instance = UiTagManager.Instance;
	}

	public void UpdatePanel()
	{
		RenderMaterialList(ShowSelecledReward ? _selectItems.Count : _items.Count);
	}

	private void OpenBoxOnUiClose(string uiName)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		if (waitOpen && !(uiName != UI_FullScreenAnimationPanel.Name) && !((GObject)this).isDisposed)
		{
			((GObject)this).visible = true;
			UpdatePanel();
			((GComponent)(object)this).SetTimeout(0.2f).OnComplete(new GTweenCallback(PlayOpenSfx));
		}
	}

	private void MaterialListItemRender(int index, GObject obj)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		UI_TakeItemBtn itemButton = (UI_TakeItemBtn)(object)obj;
		UI_TakeItemContent_Large content = itemButton.Content;
		int count = _selectItems.Count;
		if (index < count)
		{
			int value = _selectItems[index].Value;
			string itemId = _selectItems[index].Key;
			GObject child = ((GComponent)content).GetChild("icon");
			child.data = index;
			((GObject)child.asLoader).onClick.Set((EventCallback0)delegate
			{
				OnSelectItem(index, itemButton, itemId);
			});
			FGUIManager.Instance.SetItemIconAndFrame(child.asLoader, itemId, _textureList);
			GObject child2 = ((GComponent)content).GetChild("num");
			child2.text = $"x{value}";
			child2.data = value;
			child2.asTextField.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
	}

	private void OnSelectItem(int index, UI_TakeItemBtn itemButton, string itemId)
	{
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		if (selectedItem != null)
		{
			((GObject)selectedItem.Content).SetScale(1f, 1f);
		}
		selectedItem = itemButton;
		((GObject)selectedItem.Content).SetScale(1.2f, 1.2f);
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		string postScript = gDEItemData.PostScript;
		((GObject)Content.ConfirmBtn).data = index;
		((GObject)Content.ConfirmBtn).enabled = true;
		FGUIManager.Instance.SetItemIconAndFrame(Content.SelectedIcon, itemId, _textureList);
		((GObject)Content.t1).text = LanguagesManager.GetDesc("CsharpCodeZhTcText668") + "1/1";
		((GObject)Content.SelectedName).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GObject)Content.Desc).text = postScript;
		FGUIManager.Instance.SetItemIconAndFrame(Selected.SelectedIcon, itemId, _textureList);
		((GObject)Selected.SelectedName).text = ((GObject)Content.SelectedName).text;
		bool isSummonStone;
		bool shouldShowHelp = UI_TakeItems.ShouldShowPreviewHelpBtn(itemId, out isSummonStone);
		((GObject)Content.helpBtn).visible = shouldShowHelp;
		((GObject)Content.helpBtn).onClick.Set((EventCallback0)delegate
		{
			if (shouldShowHelp)
			{
				UI_TakeItems.OnClickShowItemDetail(itemId);
			}
		});
	}

	private void OnClickConfirmBtn(EventContext eventContext)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)eventContext.sender).data;
		List<int> selectIndexList = new List<int> { num };
		string item = (ShowSelecledReward ? _selectItems[num].Key : _items[num].ItemId);
		List<string> selectList = new List<string> { item };
		if (StorehouseHelper.IsGvGItem(selectItemId))
		{
			OpenGvGPack(selectList, 1);
		}
		else
		{
			OpenPack(selectIndexList, 1);
		}
	}

	private void OpenGvGPack(List<string> selectList, int num)
	{
		Singleton<GvGStoreHouseManager>.Instance.UseItem(selectItemId, num, selectList);
		End();
	}

	private void OpenPack(List<int> selectIndexList, int num)
	{
		GameManagers gameManagers = GameManagers.Instance;
		GTweenCallback val = default(GTweenCallback);
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, selectItemId, num, selectIndexList)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00a7: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				FGUIManager.Instance.AddTextSpecialEffects(openSfxBack, "treasure_open", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureOpen)
				{
					treasureOpen.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
				});
				GTweener obj = ((GComponent)(object)this).SetTimeout(0.6f);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						//IL_0025: Unknown result type (might be due to invalid IL or missing references)
						FGUIManager.Instance.AddTextSpecialEffects(shiningSfxBack, "treasure_shining", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureShining)
						{
							UiAudioManager.Instance.LoadSoundsForSfx(treasureShining, "BoxFlashing", playLoop: true);
						});
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				obj.OnComplete(obj2);
				((GObject)mask).touchable = true;
				List<Bonus> list = new List<Bonus>();
				foreach (ModelsBonus bonuse in response.Bonuses)
				{
					list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
				}
				bool flag = false;
				string text = "";
				if (Shift.Legion.Common.Models.Item.ItemType(selectItemId) == 15 || Shift.Legion.Common.Models.Item.ItemType(selectItemId) == 30)
				{
					foreach (Bonus item in list)
					{
						if (item.ItemId.IndexOf("Unlock.") >= 0)
						{
							string text2 = item.ItemId.Replace("Unlock.", "");
							Bonus bonus = Bonus.Get(text2, new List<int> { 1, item.Qty }, 2);
							if (SchemaIndexHelper.GetSchemaById(text2) == "Soldier")
							{
								text = text2;
								flag = true;
							}
							bonus.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: true, _isChangeStock: false);
						}
						else if (item.ItemId.IndexOf("PotentialLevel.") >= 0)
						{
							string text3 = item.ItemId.Replace("PotentialLevel.", "");
							if (SchemaIndexHelper.GetSchemaById(text3) == "Soldier")
							{
								text = text3;
								flag = true;
							}
							CommandFactory.CreateTakeItemsCommand(new List<Bonus> { item });
						}
						else if (Shift.Legion.Common.Models.Item.ItemType(item.ItemId) == 3)
						{
							List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText396") + Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, item.ItemId) };
							SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
						}
						else if (Shift.Legion.Common.Models.Item.ItemType(item.ItemId) == 103)
						{
							$"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, item.ItemId)}+{item.Qty}".ToTip();
						}
					}
				}
				if (response.StockChangeRecords != null)
				{
					if (flag)
					{
						for (int num2 = response.StockChangeRecords.Count - 1; num2 >= 0; num2--)
						{
							if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].ItemId == text)
							{
								response.StockChangeRecords.RemoveAt(num2);
							}
							else if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].Context == 11 && response.StockChangeRecords[num2].ContextValue.IndexOf(text) >= 0)
							{
								response.StockChangeRecords.RemoveAt(num2);
								break;
							}
						}
					}
					gameManagers.StockController.ReadStockChangeRecords(response.StockChangeRecords);
					TryDisplayClaimI33004BonusTip(response.StockChangeRecords);
				}
				FGUIManager.Instance.WarehousePanel?.UpdateStockImmediately(selectItemId);
				End();
			}
		});
	}

	private void TryDisplayClaimI33004BonusTip(List<StockChangeRecord> records)
	{
		if (selectItemId != "I33004")
		{
			return;
		}
		foreach (StockChangeRecord record in records)
		{
			if (record.Offset > 0)
			{
				ILRequestHelper.ShowMessage($"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, record.ItemId)}+{record.Offset}");
			}
		}
	}

	private void PlayOpenSfx()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		boxClip.playing = true;
		boxClip.SetPlaySettings(0, -1, 1, -1);
		UiAudioManager.Instance.PlaySoundEffect(openBoxSound);
		((GObject)boxClip).TweenFade(((GObject)boxClip).alpha, 0.33f).OnComplete((GTweenCallback)delegate
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			boxClip.playing = false;
			boxClip.frame = 3;
			((GObject)Content).TweenFade(1f, 0.45f).OnComplete(new GTweenCallback(OnContentShow));
		});
		((GObject)boxClip).TweenFade(((GObject)boxClip).alpha, 0.6f);
	}

	private void RenderMaterialList(int num)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Content.materialList.itemRenderer = new ListItemRenderer(MaterialListItemRender);
		Content.materialList.numItems = num;
		for (int i = 0; i < Content.materialList.numItems; i++)
		{
			GButton asButton = ((GComponent)Content.materialList).GetChildAt(i).asButton;
			((GComponent)asButton).GetController("button").selectedIndex = 4;
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
	}
}
