using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
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
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.Helpers;
using UI.BlueprintGachaDetailInfo;
using UI.Collection;
using UI.DebrisCompound;
using UI.GVGStore;
using UI.UpGrade;
using UI.Warehouse;
using UI.WorkShop;
using UnityEngine;

namespace UI.Tips;

public class UI_MaterialIntroductionPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_MaterialIntroductionDialog tip;

	public UI_MaterialIntroduction tip1;

	public GGraph missileBack;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9jnjr0";

	public static string Name = "UI_MaterialIntroductionPanel";

	private int MaxValue;

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

	private bool OpenTakesUiForChest;

	private int materialItemType;

	private Action _onJump;

	private string UseMinChapter;

	private string UseMinLevel;

	private bool HasUseLevelRestriction => !string.IsNullOrEmpty(UseMinChapter) && !string.IsNullOrEmpty(UseMinLevel);

	private bool IsUsable => GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(UseMinChapter).Contains(UseMinLevel);

	public static string GetURL()
	{
		return "ui://47lbpgx9jnjr0";
	}

	public static UI_MaterialIntroductionPanel CreateInstance()
	{
		return (UI_MaterialIntroductionPanel)(object)UIPackage.CreateObject("Tips", "MaterialIntroductionPanel");
	}

	public static UI_MaterialIntroductionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MaterialIntroductionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9jnjr0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		tip = (UI_MaterialIntroductionDialog)(object)((GComponent)this).GetChild("tip");
		tip1 = (UI_MaterialIntroduction)(object)((GComponent)this).GetChild("tip1");
		missileBack = (GGraph)((GComponent)this).GetChild("missileBack");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	private void CompoundSoulStoneMaxEvent()
	{
		int num = Convert.ToInt32(((GObject)tip1.MaxValueBtn).data);
		num = ((num >= MaxValue) ? MaxValue : num);
		((GObject)tip1.compoundNum).text = $"{num}";
		((GObject)tip1.compoundNum).data = num;
		ShowMaxCountTip();
	}

	private void ShowMaxCountTip()
	{
		int num = Convert.ToInt32(((GObject)tip1.compoundNum).data);
		bool visible = num >= MaxValue;
		switch (materialItemType)
		{
		case 62:
		case 64:
			((GObject)tip1.warnning).visible = visible;
			break;
		case 47:
			((GObject)tip1.Warnning2).visible = visible;
			break;
		case 63:
			((GObject)tip1.Warnning3).visible = visible;
			break;
		}
	}

	private void IncreaseCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)tip1.compoundNum).data);
		int num2 = Convert.ToInt32(((GObject)tip1.MaxValueBtn).data);
		num2 = ((num2 >= MaxValue) ? MaxValue : num2);
		if (num >= num2)
		{
			ShowMaxCountTip();
			return;
		}
		((GObject)tip1.compoundNum).data = num + 1;
		((GObject)tip1.compoundNum).text = $"{num + 1}";
		ShowMaxCountTip();
	}

	private void ReduceCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)tip1.compoundNum).data);
		if (num > 1)
		{
			((GObject)tip1.compoundNum).data = num - 1;
			((GObject)tip1.compoundNum).text = $"{num - 1}";
			((GObject)tip1.warnning).visible = false;
			((GObject)tip1.Warnning2).visible = false;
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0b0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_0976: Unknown result type (might be due to invalid IL or missing references)
		//IL_0980: Expected O, but got Unknown
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Expected O, but got Unknown
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		tip1.checkBtn.title.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		if (!parameters.ContainsKey("ItemId"))
		{
			Debug.LogWarning((object)("OpenPanel:" + Name + " 缺少ItemId参数 " + JsonHelper.ToJson(parameters)));
			End();
			return;
		}
		unlockedProducts = GameManagers.Instance.UserArchiveManager.GetUnlockedProducts();
		_materialItemId = (string)parameters["ItemId"];
		if (parameters.ContainsKey("Sender"))
		{
			sender = (GObject)parameters["Sender"];
		}
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
		_onJump = (parameters.TryGetValue("OnJumpAction", out var value4) ? ((Action)value4) : null);
		MaxValue = 1000;
		((GObject)tip1.MaxValueBtn.title).text = $"{MaxValue}";
		materialItemType = Shift.Legion.Common.Models.Item.ItemType(_materialItemId);
		foreach (Modifier item in Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, _materialItemId) ?? new List<Modifier>())
		{
			if (item.ModifierId == "UseMinChapter")
			{
				UseMinChapter = item.GetPayload<string>();
			}
			if (item.ModifierId == "UseMinLevel")
			{
				UseMinLevel = item.GetPayload<string>();
			}
		}
		if (hideCheckBtn || (materialItemType != 2 && materialItemType != 1 && materialItemType != 9 && materialItemType != 5 && materialItemType != 6 && materialItemType != 62 && materialItemType != 63 && materialItemType != 64 && materialItemType != 29 && materialItemType != 30))
		{
			tip1.PageController.selectedIndex = 1;
		}
		else if (materialItemType == 5 && BuildingManager.ItemIdToProductDict.ContainsKey(_materialItemId) && !unlockedProducts.Contains(GameManagers.Instance.BuildingManager.GetProductByItemId(_materialItemId).Key))
		{
			tip1.PageController.selectedIndex = 1;
			GDEProductData productByItemId = GameManagers.Instance.BuildingManager.GetProductByItemId(_materialItemId);
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(productByItemId.BuildType.First());
			source = "，" + LanguagesManager.GetDesc("CsharpCodeZhTcText580") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText581") + buildingByType.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText582");
		}
		else
		{
			tip1.PageController.selectedIndex = 0;
			((GObject)tip1.checkBtn).onClick.Set(new EventCallback0(ToSourcePanel));
		}
		tip1.SetControllerPageText();
		if (parameters.TryGetValue("Pieces", out var value5) && value5 != null)
		{
			pieces = (Pieces)value5;
			((GObject)tip1.checkBtn).onClick.Set(new EventCallback1(Compound));
			if (hideCheckBtn)
			{
				tip1.PageController.selectedIndex = 1;
			}
			else
			{
				tip1.PageController.selectedIndex = 2;
			}
			((GObject)tip1.checkBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText585");
		}
		if (parameters.TryGetValue("TimeMachine", out var _))
		{
			((GObject)tip1.checkBtn).onClick.Set(new EventCallback1(OpenPack));
			tip1.PageController.selectedIndex = 1;
			tip1.SetControllerPageText();
		}
		if (parameters.TryGetValue("Pack", out var value7))
		{
			if (((bool)value7 && (materialItemType == 11 || materialItemType == 15 || materialItemType == 103)) || materialItemType == 16 || materialItemType == 32 || materialItemType == 34 || materialItemType == 46 || materialItemType == 47)
			{
				if (materialItemType == 15 || materialItemType == 30 || materialItemType == 34)
				{
					OpenTakesUiForChest = true;
				}
				((GObject)tip1.checkBtn).onClick.Set(new EventCallback1(OpenPack));
				if (materialItemType == 32 || materialItemType == 47 || materialItemType == 46)
				{
					((GObject)tip1.checkBtn).onClick.Set(new EventCallback0(OpenGvGPack));
					((GObject)tip1.MaxValueBtn).data = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(_materialItemId);
				}
				else if (materialItemType == 29 || materialItemType == 30)
				{
					((GObject)tip1.MaxValueBtn).data = GameManagers.Instance.UserArchiveManager.GvGStoneCanClaim();
				}
				else
				{
					((GObject)tip1.MaxValueBtn).data = GameManagers.Instance.StockController.GetStock(_materialItemId);
				}
				Dictionary<string, int> dictionary = Shift.Legion.Common.Models.Item.ChestRequirements(GameManagers.Instance, _materialItemId);
				if (dictionary != null && dictionary.Count > 0)
				{
					tip1.PageController.selectedIndex = 2;
					KeyValuePair<string, int> keyValuePair = dictionary.First();
					int value8 = keyValuePair.Value;
					int stock = GameManagers.Instance.StockController.GetStock(keyValuePair.Key);
					FGUIManager.Instance.SetItemIconAndFrame(tip1.consumption.frame, keyValuePair.Key, textureList);
					if (stock >= value8)
					{
						((GObject)tip1.consumption.consumeNum).text = "[color=#FFFFFF]" + stock.ShortNumberFormat() + "/" + value8.ShortNumberFormat() + "[/color]";
						((GObject)tip1.checkBtn).enabled = true;
					}
					else
					{
						((GObject)tip1.consumption.consumeNum).text = "[color=#DC143C]" + stock.ShortNumberFormat() + "/[/color][color=#FFFFFF]" + value8.ShortNumberFormat() + "[/color]";
						((GObject)tip1.checkBtn).enabled = false;
					}
					((GObject)tip1.consumption).data = keyValuePair.Key;
					((GObject)tip1.consumption).onClick.Set(new EventCallback1(ItemTip));
					((GObject)tip1.checkBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText586");
					if (materialItemType == 16)
					{
						((GObject)tip1.checkBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText587");
					}
				}
				else
				{
					tip1.PageController.selectedIndex = 3;
					tip1.SetControllerPageText();
				}
				if (materialItemType == 47)
				{
					tip1.PageController.selectedIndex = 3;
					MaxValue = 1;
				}
				((GObject)tip1.compoundNum).data = 1;
				((GObject)tip1.compoundNum).text = $"{1}";
			}
			else if (((bool)value7 && (materialItemType == 22 || materialItemType == 23)) || materialItemType == 24 || materialItemType == 25 || materialItemType == 26)
			{
				((GObject)tip1.checkBtn).onClick.Set(new EventCallback1(OpenPack));
				tip1.PageController.selectedIndex = 0;
				((GObject)tip1.checkBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText588");
			}
			else if ((bool)value7 && parameters.ContainsKey("TimeMachine"))
			{
				if (materialItemType == 63 || materialItemType == 62 || materialItemType == 64)
				{
					tip1.PageController.selectedIndex = 3;
					((GObject)tip1.compoundNum).data = 1;
					((GObject)tip1.compoundNum).text = $"{1}";
					((GObject)tip1.MaxValueBtn).data = GameManagers.Instance.StockController.GetStock(_materialItemId);
					MaxValue = UiHelper.GetMoneyTimeMachineMaxUseNum(_materialItemId);
					((GObject)tip1.MaxValueBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText589");
				}
				else
				{
					tip1.PageController.selectedIndex = 0;
				}
				((GObject)tip1.checkBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText588") ?? "";
			}
		}
		if (parameters.ContainsKey("Pos"))
		{
			Vector2 val = (Vector2)parameters["Pos"];
			((GObject)tip1).SetXY(val.x, val.y);
		}
		else
		{
			((GObject)tip1).SetXY(960f - ((GObject)tip1).width / 2f, 540f - ((GObject)tip1).height / 2f);
		}
		if (parameters.ContainsKey("ToSourceParameters"))
		{
			toSourceParameters = (Dictionary<string, object>)parameters["ToSourceParameters"];
		}
		else
		{
			toSourceParameters = new Dictionary<string, object>();
		}
		OpenMaterialElevationPanel();
		if (parameters.TryGetValue("Order", out var value9))
		{
			((GObject)this).sortingOrder = (int)value9;
		}
		else
		{
			((GObject)this).sortingOrder = 105;
		}
		if (StorehouseHelper.IsGvGItem(_materialItemId))
		{
			int itemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(_materialItemId, includingGSStock: true);
			((GObject)tip1.Content.stockNum).text = $"{itemCount}";
		}
		else if (materialItemType != 126)
		{
			object value10;
			int currentGvGStock = (parameters.TryGetValue("GvGItemStock", out value10) ? ((int)value10) : 0);
			((GObject)tip1.Content.stockNum).text = FGUIManager.Instance.GetStockString(_materialItemId, currentGvGStock);
		}
		SetGemPouchBtnText();
		SetGemPouchVisible();
		InitGachaHelpTip();
		bool flag = (HasUseLevelRestriction && !IsUsable) || !((GObject)tip1.checkBtn).enabled;
		((GObject)tip1.checkBtn).enabled = !flag;
		void SetGemPouchBtnText()
		{
			if (materialItemType == 29 || materialItemType == 30)
			{
				((GObject)tip1.checkBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText306");
			}
		}
		void SetGemPouchVisible()
		{
			if (materialItemType == 29 || materialItemType == 30)
			{
				((GObject)tip1.checkBtn).visible = false;
			}
		}
	}

	public void TryBringToFont(Window windowloader)
	{
		if (windowloader != null)
		{
			windowloader.BringToFront();
			((GObject)windowloader).sortingOrder = 9999;
		}
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
		((GObject)tip1.MaxValueBtn).onClick.Add(new EventCallback0(CompoundSoulStoneMaxEvent));
		((GObject)tip1.increaseBtn).onClick.Add(new EventCallback0(IncreaseCompoundNum));
		((GObject)tip1.reduceBtn).onClick.Add(new EventCallback0(ReduceCompoundNum));
		SharedMessenger.AddListener("WORKSHOP_LIST_SCROLLEND", ReSetXY);
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
		((GObject)tip1.MaxValueBtn).onClick.Remove(new EventCallback0(CompoundSoulStoneMaxEvent));
		((GObject)tip1.increaseBtn).onClick.Remove(new EventCallback0(IncreaseCompoundNum));
		((GObject)tip1.reduceBtn).onClick.Remove(new EventCallback0(ReduceCompoundNum));
		((GObject)tip1.checkBtn).onClick.Clear();
		SharedMessenger.RemoveListener("WORKSHOP_LIST_SCROLLEND", ReSetXY);
		SharedMessenger.RemoveListener<Pieces, int, Dictionary<string, int>, List<KeyValuePair<Bonus, int>>>("PIECES_COMPOUND", OnPiecesCompound);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("MaterialIntroductionPanel.ProduceBtn", tip1.checkBtn);
	}

	public void OnShow()
	{
		if (OpenTakesUiForChest)
		{
			List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, _materialItemId);
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (Modifier item in list)
			{
				if (!(item.ModifierId == "Items"))
				{
					continue;
				}
				foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
				{
					dictionary.Add(item2.Key, Convert.ToInt32(item2.Value));
				}
			}
			List<KeyValuePair<string, int>> list2 = dictionary.ToList();
			string identifier = ((list2.Count > 6) ? UI_TakeItems_Large.Name : UI_TakeItems.Name);
			GameController.Contexts.Service<IUiService>().OpenPanel(identifier, new Dictionary<string, object>
			{
				{
					"Name",
					SchemaIndexHelper.GetNameById(GameManagers.Instance, _materialItemId) ?? ""
				},
				{ "ShowSelectedReward", true },
				{ "SelectItems", list2 },
				{ "Parent", parent },
				{ "SelectItemId", _materialItemId }
			});
			End();
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MaterialIntroductionPanel.ProduceBtn", tip1.checkBtn);
		if (tip1.Content.RightContent != null && !((GObject)tip1.Content.RightContent).isDisposed)
		{
			((GObject)tip1.Content.RightContent).SetXY(((GObject)tip1.Content.RightContent).x, (((GObject)tip1.Content).height - ((GObject)tip1.Content.RightContent).height) / 2f);
		}
		if (!((GObject)this).isDisposed)
		{
			showTip.Play();
		}
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
		((GObject)tip1.Content.RightContent.title).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, _materialItemId);
		FGUIManager.Instance.SetItemIconAndFrame(tip1.Content.icon, _materialItemId, null, "", frameVisible: true, 1f, null, userExpFrameVisible: true);
		((GObject)tip1.Content.RightContent.introduction).text = "";
		string schemaById = SchemaIndexHelper.GetSchemaById(_materialItemId);
		if (schemaById == "Technology")
		{
			List<Modifier> techEffects = GameManagers.Instance.TechnologyManager.GetTechEffects(_materialItemId, 1);
			GDETechnologyData gDETechnologyData = GDMgr.Get<GDETechnologyData>(_materialItemId);
			if (techEffects == null)
			{
				GTextField introduction = tip1.Content.RightContent.introduction;
				((GObject)introduction).text = ((GObject)introduction).text + " [color=#9bc52a]" + gDETechnologyData.GainDescrible + "[/color]";
			}
			else
			{
				GTextField introduction2 = tip1.Content.RightContent.introduction;
				((GObject)introduction2).text = ((GObject)introduction2).text + " [color=#9bc52a]";
				for (int i = 0; i < techEffects.Count; i++)
				{
					Modifier modifier = techEffects[i];
					GDETechnologyEffectData gDETechnologyEffectData = TechnologyManager.TechnologyEffectDataDictionary[gDETechnologyData.Key][1][i];
					if (string.IsNullOrEmpty(gDETechnologyEffectData.Desc))
					{
						GTextField introduction3 = tip1.Content.RightContent.introduction;
						((GObject)introduction3).text = ((GObject)introduction3).text + modifier.Desc + " ";
					}
					else
					{
						GTextField introduction4 = tip1.Content.RightContent.introduction;
						((GObject)introduction4).text = ((GObject)introduction4).text + gDETechnologyEffectData.Desc + " ";
					}
				}
				GTextField introduction5 = tip1.Content.RightContent.introduction;
				((GObject)introduction5).text = ((GObject)introduction5).text + "[/color]";
			}
		}
		else
		{
			((GObject)tip1.Content.RightContent.introduction).text = Shift.Legion.Common.Models.Item.PostScript(_materialItemId) + source;
		}
		if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 2)
		{
			Dictionary<string, string> itemBonus = Shift.Legion.Common.Models.Item.GetItemBonus(GameManagers.Instance, _materialItemId);
			int num = 0;
			foreach (KeyValuePair<string, string> item in itemBonus)
			{
				KeyValuePair<string, string> keyValuePair = Modifier.TranslateModifierKeyValue(item.Key, item.Value);
				GTextField property = tip1.Content.RightContent.Property;
				((GObject)property).text = ((GObject)property).text + "[color=#D5BA7A]" + keyValuePair.Key + "[/color] +[color=#AFF627]" + UiHelper.RemoveSurplusZeroBehindDecimalPoint(keyValuePair.Value) + "[/color]";
				if (num < itemBonus.Count - 1)
				{
					GTextField property2 = tip1.Content.RightContent.Property;
					((GObject)property2).text = ((GObject)property2).text + Environment.NewLine;
				}
				num++;
			}
			tip1.Content.RightContent.PageController.selectedIndex = 0;
			((GObject)tip1.Content.RightContent.introduction).text = Shift.Legion.Common.Models.Item.PostScript(_materialItemId);
		}
		else
		{
			tip1.Content.RightContent.PageController.selectedIndex = 1;
		}
		string text = GDMgr.Get<GDEItemData>(_materialItemId)?.AccessPath ?? string.Empty;
		if (TryGetLevelRestrictionText(_materialItemId, out var text2))
		{
			text = text2;
		}
		((GObject)tip1.Content.RightContent.Access).text = text;
		if (pieces != null)
		{
			int stock = GameManagers.Instance.StockController.GetStock(pieces.ItemId);
			int compositeRequirement = pieces.CompositeRequirement;
			if (stock >= compositeRequirement)
			{
				((GObject)tip1.consumption.consumeNum).text = "[color=#FFFFFF]" + stock.ShortNumberFormat() + "/" + compositeRequirement.ShortNumberFormat() + "[/color]";
				((GObject)tip1.checkBtn).enabled = true;
			}
			else
			{
				((GObject)tip1.consumption.consumeNum).text = "[color=#DC143C]" + stock.ShortNumberFormat() + "/[/color][color=#FFFFFF]" + compositeRequirement.ShortNumberFormat() + "[/color]";
				((GObject)tip1.checkBtn).enabled = false;
			}
		}
		if (((GObject)tip1.Content.RightContent).height < ((GObject)tip1.Content.icon).height)
		{
			((GObject)tip1.Content).y = (((GObject)tip1.Content.icon).height - ((GObject)tip1.Content.RightContent).height) / 2f + 41f;
		}
	}

	private bool TryGetLevelRestrictionText(string itemId, out string text)
	{
		string text2 = "";
		string text3 = "";
		string langKey = null;
		string langKey2 = null;
		text = null;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		if (list != null)
		{
			foreach (Modifier item in list)
			{
				if (item.ModifierId == "UseMinChapter")
				{
					text2 = item.GetPayload<string>();
				}
				if (item.ModifierId == "UseMinLevel")
				{
					text3 = item.GetPayload<string>();
				}
				if (item.ModifierId == "LockText")
				{
					langKey = item.GetPayload<string>();
				}
				if (item.ModifierId == "UnlockText")
				{
					langKey2 = item.GetPayload<string>();
				}
			}
		}
		if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3))
		{
			if (GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(text2).Contains(text3))
			{
				text = langKey2.ToLanguage();
			}
			else
			{
				text = langKey.ToLanguage();
			}
		}
		return !string.IsNullOrEmpty(text);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reserveResource);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void ToSourcePanel()
	{
		string targetUI = StockController.GetJumpContext(_materialItemId);
		if (string.IsNullOrEmpty(targetUI))
		{
			string key = GameManagers.Instance.BuildingManager.GetProductByItemId(_materialItemId).Key;
			if (!BuildingManager.Products.ContainsKey(key))
			{
				Debug.LogWarning((object)("没找到对应的产品 " + key));
				if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 9)
				{
					string currentLevelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
					CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
					{
						{ "LevelId", currentLevelId },
						{ "Asset", "Prefabs/BattleField" },
						{ "ForceCloseOtherUi", true },
						{ "TaskCompletionSource", null }
					}));
				}
				return;
			}
			GDEProductData gDEProductData = BuildingManager.Products[key];
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(gDEProductData.BuildType.First());
			if (!toSourceParameters.ContainsKey("ProductId"))
			{
				toSourceParameters.Add("ProductId", key);
			}
			if (buildingByType != null)
			{
				if (buildingByType.Level == 0)
				{
					if (GameManagers.Instance.UserArchiveManager.GetBuildingMaxLevel(buildingByType.BuildingType) > 0)
					{
						End();
						Dictionary<string, object> parameters = new Dictionary<string, object>
						{
							{ "Building", buildingByType },
							{
								"SortingOrder",
								((GObject)this).sortingOrder
							}
						};
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters);
					}
					else
					{
						End();
						List<string> arg = new List<string>
						{
							LanguagesManager.GetDesc("CsharpCodeZhTcText490") + buildingByType.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText583"),
							LanguagesManager.GetDesc("CsharpCodeZhTcText579")
						};
						SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
					}
				}
				else
				{
					End();
					toSourceParameters.Add("BuildingType", buildingByType.BuildingType);
					if (buildingByType.Feature == "Mine")
					{
						toSourceParameters.Add("SortingOrder", ((GObject)this).sortingOrder);
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_CollectionPanel.Name, toSourceParameters);
					}
					else if (buildingByType.Feature == "WorkShop")
					{
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkShopPanel.Name, toSourceParameters);
					}
				}
			}
			_onJump?.Invoke();
		}
		else
		{
			End();
			toSourceParameters.Add("SortingOrder", ((GObject)this).sortingOrder);
			AddGvGStoreUiParameters();
			if (targetUI == "UI_MilitaryIntelligencePanel")
			{
				FGUIManager.Instance.OpenMilitaryIntelligencePanel(targetUI, toSourceParameters);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(targetUI, toSourceParameters);
			}
			_onJump?.Invoke();
		}
		void AddGvGStoreUiParameters()
		{
			if (targetUI == UI_main_GVGStorePanel.Name && Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 30)
			{
				toSourceParameters.Add("CheckItemId", _materialItemId);
			}
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
		((GObject)tip1.Content.SfxBack).y = ((GObject)tip1.Content.SfxBack).y - 30f;
		FGUIManager.Instance.AddTextSpecialEffects(tip1.Content.SfxBack, "activating_white_sp_2", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject activatingWhiteSp2)
		{
			activatingWhiteSp2.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
		});
		Vector2 val = ((GObject)tip1.Content.icon).LocalToGlobal(Vector2.one / 2f);
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

	private void InitGachaHelpTip()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		if (_materialItemId == "BlueprintBox_3")
		{
			tip1.isBluePrint.SetSelectedIndex(1);
			((GObject)tip1.help).onClick.Set(new EventCallback0(OnClickOpenGachaHelpTip));
		}
	}

	private void OnClickOpenGachaHelpTip()
	{
		UnityUiService.Instance.OpenPanel(UI_main_BlueprintGachaDetailInfoPanel.Name, new Dictionary<string, object>());
	}

	private void OpenPack(EventContext eventContext)
	{
		if (HasUseLevelRestriction && !IsUsable)
		{
			return;
		}
		if (tip1.PageController.selectedIndex == 3 && (int)((GObject)tip1.compoundNum).data <= 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText584") + "0" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
			return;
		}
		int num = 1;
		if (((GObject)tip1.compoundNum).data != null)
		{
			string s = $"{(int)((GObject)tip1.compoundNum).data}";
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
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<Bonus> result_bonusList = new List<Bonus>();
				if (response.Bonuses != null)
				{
					foreach (ModelsBonus bonuse in response.Bonuses)
					{
						result_bonusList.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
					}
				}
				if (response.StockChangeRecords != null)
				{
					bool flag = false;
					string text = "";
					if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 11 || Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 29)
					{
						foreach (Bonus item in result_bonusList)
						{
							if (item.ItemId.IndexOf("Unlock.") >= 0)
							{
								string text2 = item.ItemId.Replace("Unlock.", "");
								if (SchemaIndexHelper.GetSchemaById(text2) == "Soldier")
								{
									text = text2;
									flag = true;
								}
							}
							else if (item.ItemId.StartsWith("PotentialLevel."))
							{
								string text3 = item.ItemId.Replace("PotentialLevel.", "");
								if (SchemaIndexHelper.GetSchemaById(text3) == "Soldier")
								{
									text = text3;
									flag = true;
								}
							}
						}
					}
					if (flag)
					{
						for (int num2 = response.StockChangeRecords.Count - 1; num2 >= 0; num2--)
						{
							if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].ItemId == text)
							{
								response.StockChangeRecords.RemoveAt(num2);
								break;
							}
							if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].Context == 11 && response.StockChangeRecords[num2].ContextValue.IndexOf(text) >= 0)
							{
								response.StockChangeRecords.RemoveAt(num2);
								break;
							}
						}
					}
					gameManagers.StockController.ReadStockChangeRecords(response.StockChangeRecords);
					if (parent is UI_WarehousePanel uI_WarehousePanel)
					{
						uI_WarehousePanel.FlushLastRefresh();
						uI_WarehousePanel.GetData();
					}
				}
				if (response.TimeMachineSeconds > 0)
				{
					if (response.Bonuses != null)
					{
						List<Bonus> list2 = new List<Bonus>();
						foreach (ModelsBonus bonuse2 in response.Bonuses)
						{
							if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) != 63 || !(bonuse2.ItemId != "Money"))
							{
								list2.Add(Bonus.Get(bonuse2.ItemId, bonuse2.Qty, bonuse2.Type, bonuse2.IsShining));
							}
						}
						SharedMessenger.Broadcast("TIME_MACHINE_LAUNCHED", response.TimeMachineSeconds, list2);
					}
					else
					{
						ILRequestHelper.ShowErrorCode(82000002);
					}
				}
				if (response.LegendItems != null)
				{
					List<LegendItemUi> list3 = new List<LegendItemUi>();
					List<string> list4 = new List<string>();
					for (int i = 0; i < response.LegendItems.Count; i++)
					{
						ModelsBonus modelsBonus = response.LegendItems[i];
						Bonus bonus = Bonus.Get(modelsBonus.ItemId, modelsBonus.Qty, modelsBonus.Type, modelsBonus.IsShining, modelsBonus.ExtraData);
						Dictionary<string, float> dict = bonus.Claim(GameManagers.Instance);
						long key = long.Parse(dict.First().Key);
						LegendItem legendItem = GameManagers.Instance.InventoryManager.LegendItems[key];
						LegendItemUi legendItemUi = new LegendItemUi(legendItem.InstanceId, legendItem);
						LegendItemsHelper.UpdateLegendItems(legendItemUi);
						list3.Add(legendItemUi);
						list4.Add(legendItemUi.LegendItemData.ItemId);
					}
					Dictionary<string, object> parameters = new Dictionary<string, object>
					{
						{ "LegendItems", list3 },
						{
							"SortingOrder",
							((GObject)this).sortingOrder
						},
						{ "ItemId", _materialItemId }
					};
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemBoxPanel.Name, parameters);
					ThinkingDataHelper.Instance.OpenLegendItemBox(_materialItemId, num, list4);
				}
				if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 13)
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChoosePendingLottery.Name, null);
				}
				if (hasTimeMachine)
				{
					gameManagers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
					GameManagers.Instance.StockController.NeedGetAllProduceStatus = true;
					GameManagers.Instance.StockController.NeedSyncProduce = true;
				}
				if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 11 || Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 29)
				{
					ShowChestResult();
				}
				else if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 15 || Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 30)
				{
					foreach (Bonus item2 in result_bonusList)
					{
						if (item2.ItemId.IndexOf("Unlock.") >= 0)
						{
							string itemId = item2.ItemId.Replace("Unlock.", "");
							Bonus bonus2 = Bonus.Get(itemId, new List<int> { 1, item2.Qty }, 2);
							bonus2.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: true, _isChangeStock: false);
						}
						else if (item2.ItemId.IndexOf("PotentialLevel.") >= 0)
						{
							CommandFactory.CreateTakeItemsCommand(new List<Bonus> { item2 });
						}
					}
				}
				else if (Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 22 || Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 23 || Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 24 || Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 25 || Shift.Legion.Common.Models.Item.ItemType(_materialItemId) == 26)
				{
					foreach (Bonus item3 in result_bonusList)
					{
						item3.Claim(GameManagers.Instance);
					}
				}
				FGUIManager.Instance.WarehousePanel?.UpdateStockImmediately(_materialItemId);
				End();
			}
		});
		void ShowChestResult()
		{
			reserveResource = true;
			if (string.IsNullOrEmpty(P_0.response.NewBlueprints))
			{
				gameManagers.Messenger.Broadcast("CHEST_CLAIMED", _materialItemId, P_0.result_bonusList, P_0.response.ClaimedContent);
			}
			else
			{
				List<string> list2 = JsonHelper.ToObject<List<string>>(P_0.response.NewBlueprints);
				if (list2.Count <= 0)
				{
					gameManagers.Messenger.Broadcast("CHEST_CLAIMED", _materialItemId, P_0.result_bonusList, P_0.response.ClaimedContent);
				}
				else
				{
					LegendItemsHelper.OpenBlueprintsBoxResult(JsonHelper.ToObject<List<string>>(P_0.response.NewBlueprints), _materialItemId);
				}
			}
		}
	}

	private void OpenGvGPack()
	{
		int count = 1;
		if (((GObject)tip1.compoundNum).data != null)
		{
			string s = $"{(int)((GObject)tip1.compoundNum).data}";
			count = int.Parse(s);
		}
		Singleton<GvGStoreHouseManager>.Instance.UseItem(_materialItemId, count);
		End();
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

	public void ReSetXY()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (sender != null)
		{
			Vector2 val = default(Vector2);
			if (sender is GLoader)
			{
				val = ((GObject)sender.parent).LocalToGlobal(Vector2.zero);
				val = ((GObject)this).GlobalToLocal(val);
			}
			else if (sender is GButton)
			{
				val = ((GObject)((GObject)sender.parent).parent).LocalToGlobal(Vector2.zero);
				val = ((GObject)this).GlobalToLocal(val);
			}
			((GObject)tip1).SetXY(val.x, val.y);
		}
	}
}
