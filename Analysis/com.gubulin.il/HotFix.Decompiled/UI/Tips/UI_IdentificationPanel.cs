using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.DebrisCompound;
using UnityEngine;

namespace UI.Tips;

public class UI_IdentificationPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_IdentificationDialog Dialog;

	public GGraph missileBack;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9g6f956";

	public static string Name = "UI_IdentificationPanel";

	private string _materialItemId;

	private Dictionary<string, object> toSourceParameters;

	private GObject sender;

	private List<string> unlockedProducts;

	private string source;

	private Pieces pieces;

	private bool reserveResource = false;

	private IUiController parent;

	private bool hideCheckBtn;

	private List<string> textureList = new List<string>();

	public static string GetURL()
	{
		return "ui://47lbpgx9g6f956";
	}

	public static UI_IdentificationPanel CreateInstance()
	{
		return (UI_IdentificationPanel)(object)UIPackage.CreateObject("Tips", "IdentificationPanel");
	}

	public static UI_IdentificationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IdentificationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9g6f956", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_IdentificationDialog)(object)((GComponent)this).GetChild("Dialog");
		missileBack = (GGraph)((GComponent)this).GetChild("missileBack");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Dialog.checkBtn.title.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		if (!parameters.ContainsKey("ItemId"))
		{
			Debug.LogWarning((object)("OpenPanel:" + Name + " 缺少ItemId参数 " + JsonHelper.ToJson(parameters)));
			End();
			return;
		}
		unlockedProducts = GameManagers.Instance.UserArchiveManager.GetUnlockedProducts();
		_materialItemId = (string)parameters["ItemId"];
		if (parameters.TryGetValue("Parent", out var value))
		{
			parent = (IUiController)value;
		}
		if (parameters.TryGetValue("ReserveResource", out var value2))
		{
			reserveResource = (bool)value2;
		}
		if (parameters.TryGetValue("HideCheckBtn", out var value3))
		{
			hideCheckBtn = (bool)value3;
		}
		((GObject)Dialog.checkBtn).onClick.Set(new EventCallback1(OpenPack));
		((GObject)Dialog.checkBtn).visible = true;
		Dictionary<string, int> dictionary = Shift.Legion.Common.Models.Item.ChestRequirements(GameManagers.Instance, _materialItemId);
		if (dictionary != null && dictionary.Count > 0)
		{
			((GObject)Dialog.consumption).visible = true;
			KeyValuePair<string, int> keyValuePair = dictionary.First();
			int value4 = keyValuePair.Value;
			int stock = GameManagers.Instance.StockController.GetStock(keyValuePair.Key);
			FGUIManager.Instance.SetItemIconAndFrame(Dialog.consumption.frame, keyValuePair.Key, textureList);
			if (stock >= value4)
			{
				((GObject)Dialog.consumption.consumeNum).text = "[color=#FFFFFF]" + stock.ShortNumberFormat() + "/" + value4.ShortNumberFormat() + "[/color]";
				((GObject)Dialog.checkBtn).enabled = true;
			}
			else
			{
				((GObject)Dialog.consumption.consumeNum).text = "[color=#DC143C]" + stock.ShortNumberFormat() + "/[/color][color=#FFFFFF]" + value4.ShortNumberFormat() + "[/color]";
				((GObject)Dialog.checkBtn).enabled = false;
			}
			((GObject)Dialog.consumption).data = keyValuePair.Key;
			((GObject)Dialog.consumption).onClick.Set(new EventCallback1(ItemTip));
			int num = stock / value4;
			int stock2 = GameManagers.Instance.StockController.GetStock(_materialItemId);
			((GObject)Dialog.MaxValueBtn).data = ((num > stock2) ? stock2 : num);
		}
		else
		{
			((GObject)Dialog.consumption).visible = false;
			((GObject)Dialog.MaxValueBtn).data = GameManagers.Instance.StockController.GetStock(_materialItemId);
		}
		((GObject)Dialog.compoundNum).data = 1;
		((GObject)Dialog.compoundNum).text = $"{1}";
		OpenMaterialElevationPanel();
		if (parameters.TryGetValue("Order", out var value5))
		{
			((GObject)this).sortingOrder = (int)value5;
		}
		else
		{
			((GObject)this).sortingOrder = 105;
		}
		((GObject)Dialog.Content.stockNum).text = FGUIManager.Instance.GetStockString(_materialItemId);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.MaxValueBtn).onClick.Add(new EventCallback0(CompoundSoulStoneMaxEvent));
		((GObject)Dialog.increaseBtn).onClick.Add(new EventCallback0(IncreaseCompoundNum));
		((GObject)Dialog.reduceBtn).onClick.Add(new EventCallback0(ReduceCompoundNum));
		SharedMessenger.AddListener<Pieces, int, Dictionary<string, int>, List<KeyValuePair<Bonus, int>>>("PIECES_COMPOUND", OnPiecesCompound);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.MaxValueBtn).onClick.Remove(new EventCallback0(CompoundSoulStoneMaxEvent));
		((GObject)Dialog.increaseBtn).onClick.Remove(new EventCallback0(IncreaseCompoundNum));
		((GObject)Dialog.reduceBtn).onClick.Remove(new EventCallback0(ReduceCompoundNum));
		((GObject)Dialog.checkBtn).onClick.Clear();
		SharedMessenger.RemoveListener<Pieces, int, Dictionary<string, int>, List<KeyValuePair<Bonus, int>>>("PIECES_COMPOUND", OnPiecesCompound);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MaterialIntroductionPanel.ProduceBtn", Dialog.checkBtn);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MaterialIntroductionPanel.ProduceBtn", Dialog.checkBtn);
		((GObject)Dialog.Content.RightContent).SetXY(((GObject)Dialog.Content.RightContent).x, (((GObject)Dialog.Content).height - ((GObject)Dialog.Content.RightContent).height) / 2f);
		showTip.Play();
		showTip.Stop(true, true);
		Dialog.SetButtonTitle();
	}

	public void ItemTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string value = ((GObject)context.sender).data.ToString();
		Dictionary<string, object> dictionary = new Dictionary<string, object> { { "ItemId", value } };
		string name = UI_BoxCostItemTip.Name;
		dictionary.Add("ReserveResource", true);
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(name, dictionary);
	}

	private void OpenMaterialElevationPanel()
	{
		((GObject)Dialog.Content.RightContent.title).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, _materialItemId);
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.Content.icon, _materialItemId);
		((GObject)Dialog.Content.RightContent.introduction).text = "";
		string schemaById = SchemaIndexHelper.GetSchemaById(_materialItemId);
		if (schemaById == "Technology")
		{
			List<Modifier> techEffects = GameManagers.Instance.TechnologyManager.GetTechEffects(_materialItemId, 1);
			GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(_materialItemId);
			if (techEffects == null)
			{
				GTextField introduction = Dialog.Content.RightContent.introduction;
				((GObject)introduction).text = ((GObject)introduction).text + " [color=#9bc52a]" + gDETechnologyData.GainDescrible + "[/color]";
			}
			else
			{
				GTextField introduction2 = Dialog.Content.RightContent.introduction;
				((GObject)introduction2).text = ((GObject)introduction2).text + " [color=#9bc52a]";
				for (int i = 0; i < techEffects.Count; i++)
				{
					Modifier modifier = techEffects[i];
					GDETechnologyEffectData gDETechnologyEffectData = TechnologyManager.TechnologyEffectDataDictionary[gDETechnologyData.Key][1][i];
					if (string.IsNullOrEmpty(gDETechnologyEffectData.Desc))
					{
						GTextField introduction3 = Dialog.Content.RightContent.introduction;
						((GObject)introduction3).text = ((GObject)introduction3).text + modifier.Desc + " ";
					}
					else
					{
						GTextField introduction4 = Dialog.Content.RightContent.introduction;
						((GObject)introduction4).text = ((GObject)introduction4).text + gDETechnologyEffectData.Desc + " ";
					}
				}
				GTextField introduction5 = Dialog.Content.RightContent.introduction;
				((GObject)introduction5).text = ((GObject)introduction5).text + "[/color]";
			}
		}
		else
		{
			((GObject)Dialog.Content.RightContent.introduction).text = Shift.Legion.Common.Models.Item.PostScript(_materialItemId) + source;
		}
		if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 2)
		{
			Dictionary<string, string> itemBonus = Shift.Legion.Common.Models.Item.GetItemBonus(GameManagers.Instance, _materialItemId);
			int num = 0;
			foreach (KeyValuePair<string, string> item in itemBonus)
			{
				KeyValuePair<string, string> keyValuePair = Modifier.TranslateModifierKeyValue(item.Key, item.Value);
				GTextField property = Dialog.Content.RightContent.Property;
				((GObject)property).text = ((GObject)property).text + "[color=#D5BA7A]" + keyValuePair.Key + "[/color] +[color=#AFF627]" + UiHelper.RemoveSurplusZeroBehindDecimalPoint(keyValuePair.Value) + "[/color]";
				if (num < itemBonus.Count - 1)
				{
					GTextField property2 = Dialog.Content.RightContent.Property;
					((GObject)property2).text = ((GObject)property2).text + Environment.NewLine;
				}
				num++;
			}
			Dialog.Content.RightContent.PageController.selectedIndex = 0;
			((GObject)Dialog.Content.RightContent.introduction).text = Shift.Legion.Common.Models.Item.PostScript(_materialItemId);
		}
		else
		{
			Dialog.Content.RightContent.PageController.selectedIndex = 1;
		}
		string text = GDMgr.Get<GDEItemData>(_materialItemId)?.AccessPath ?? string.Empty;
		((GObject)Dialog.Content.RightContent.Access).text = text;
		if (pieces != null)
		{
			int stock = GameManagers.Instance.StockController.GetStock(pieces.ItemId);
			int compositeRequirement = pieces.CompositeRequirement;
			if (stock >= compositeRequirement)
			{
				((GObject)Dialog.consumption.consumeNum).text = "[color=#FFFFFF]" + stock.ShortNumberFormat() + "/" + compositeRequirement.ShortNumberFormat() + "[/color]";
				((GObject)Dialog.checkBtn).enabled = true;
			}
			else
			{
				((GObject)Dialog.consumption.consumeNum).text = "[color=#DC143C]" + stock.ShortNumberFormat() + "/[/color][color=#FFFFFF]" + compositeRequirement.ShortNumberFormat() + "[/color]";
				((GObject)Dialog.checkBtn).enabled = false;
			}
		}
		if (((GObject)Dialog.Content.RightContent).height < ((GObject)Dialog.Content.icon).height)
		{
			((GObject)Dialog.Content).y = (((GObject)Dialog.Content.icon).height - ((GObject)Dialog.Content.RightContent).height) / 2f + 41f;
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reserveResource);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void PlayCompoundSfx()
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		((GObject)Dialog.Content.SfxBack).y = ((GObject)Dialog.Content.SfxBack).y - 30f;
		FGUIManager.Instance.AddTextSpecialEffects(Dialog.Content.SfxBack, "activating_white_sp_2", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject activatingWhiteSp2)
		{
			activatingWhiteSp2.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
		});
		Vector2 val = ((GObject)Dialog.Content.icon).LocalToGlobal(Vector2.one / 2f);
		val = ((GObject)this).GlobalToLocal(val);
		((GObject)missileBack).SetXY(val.x, val.y);
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(missileBack, "rubby_missile", new Vector3(80f, 80f, 80f));
			Vector2 val2 = default(Vector2);
			((Vector2)(ref val2))._002Ector(960f, 540f);
			((GObject)missileBack).TweenMove(val2, 0.2f);
		});
	}

	private void OpenPack(EventContext eventContext)
	{
		if ((int)((GObject)Dialog.compoundNum).data <= 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText584") + "0" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
			return;
		}
		int num = 1;
		if (((GObject)Dialog.compoundNum).data != null)
		{
			string s = $"{(int)((GObject)Dialog.compoundNum).data}";
			num = int.Parse(s);
		}
		GameManagers gameManagers = GameManagers.Instance;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(gameManagers, _materialItemId);
		bool hasTimeMachine = list.Any((Modifier modifier) => modifier.ModifierId == "TimeMachine");
		if (hasTimeMachine)
		{
			gameManagers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_PAUSE_PRODUCE", null, arg2: true);
		}
		ILRequestHelper<UseItemResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().UseItem(-1L, _materialItemId, num, null), delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode == 10014001)
				{
					LanguagesManager.GetErrorMessage(response.ErrorCode).Format(num).ToTip();
				}
				else
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				if (response.StockChangeRecords != null)
				{
					gameManagers.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				}
				if (response.LegendItems != null)
				{
					List<LegendItemUi> list2 = new List<LegendItemUi>();
					List<string> list3 = new List<string>();
					for (int i = 0; i < response.LegendItems.Count; i++)
					{
						ModelsBonus modelsBonus = response.LegendItems[i];
						Bonus bonus = Bonus.Get(modelsBonus.ItemId, modelsBonus.Qty, modelsBonus.Type, modelsBonus.IsShining, modelsBonus.ExtraData);
						Dictionary<string, float> dict = bonus.Claim(GameManagers.Instance);
						long key = long.Parse(dict.First().Key);
						LegendItem legendItem = GameManagers.Instance.InventoryManager.LegendItems[key];
						LegendItemUi legendItemUi = new LegendItemUi(legendItem.InstanceId, legendItem);
						LegendItemsHelper.UpdateLegendItems(legendItemUi);
						list2.Add(legendItemUi);
						list3.Add(legendItemUi.LegendItemData.ItemId);
					}
					LegendItemsHelper.UpdateGetLegendItemsNum(response.LegendItems);
					LegendItemsHelper.UpdateGetLegendItemStars(list2);
					LegendItemsHelper.UpdateGetLegendItemsRarityRecords(list2);
					Dictionary<string, object> parameters = new Dictionary<string, object>
					{
						{ "LegendItems", list2 },
						{
							"SortingOrder",
							((GObject)this).sortingOrder
						},
						{ "ItemId", _materialItemId }
					};
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemBoxPanel.Name, parameters);
					ThinkingDataHelper.Instance.OpenLegendItemBox(_materialItemId, num, list3);
				}
				if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 13)
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChoosePendingLottery.Name, null);
				}
				if (hasTimeMachine)
				{
					gameManagers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
				}
				FGUIManager.Instance.WarehousePanel?.UpdateStockImmediately(_materialItemId);
				End();
			}
		});
	}

	private void Compound(EventContext eventContext)
	{
		PlayCompoundSfx();
		ILRequestHelper<PiecesCompositeResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().PiecesComposite(-1L, pieces.PiecesId, 1), delegate(PiecesCompositeResponse response)
		{
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ActionResult actionResult = GameManagers.Instance.PiecesManager.Composite(pieces.PiecesId);
				if (!actionResult.Result)
				{
					ILRequestHelper.ShowMessage(actionResult.ErrorMessage);
				}
				else
				{
					((GComponent)(object)this).SetTimeout(1.2f).OnComplete(new GTweenCallback(End));
				}
			}
		});
	}

	private void OnPiecesCompound(Pieces piecesData, int compoundCnt, Dictionary<string, int> compoundResult, List<KeyValuePair<Bonus, int>> bonusInfoList)
	{
		Bonus key = bonusInfoList.First().Key;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DebrisCompoundPanel.Name, new Dictionary<string, object> { { "MainCard", key } });
	}

	private void CompoundSoulStoneMaxEvent()
	{
		int num = Convert.ToInt32(((GObject)Dialog.MaxValueBtn).data);
		num = ((num >= 100) ? 100 : num);
		((GObject)Dialog.compoundNum).text = $"{num}";
		((GObject)Dialog.compoundNum).data = num;
	}

	private void IncreaseCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)Dialog.compoundNum).data);
		int num2 = Convert.ToInt32(((GObject)Dialog.MaxValueBtn).data);
		num2 = ((num2 >= 100) ? 100 : num2);
		if (num < num2)
		{
			((GObject)Dialog.compoundNum).data = num + 1;
			((GObject)Dialog.compoundNum).text = $"{num + 1}";
		}
	}

	private void ReduceCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)Dialog.compoundNum).data);
		if (num > 1)
		{
			((GObject)Dialog.compoundNum).data = num - 1;
			((GObject)Dialog.compoundNum).text = $"{num - 1}";
		}
	}
}
