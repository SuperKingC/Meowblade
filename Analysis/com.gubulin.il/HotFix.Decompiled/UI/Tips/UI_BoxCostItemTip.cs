using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Collection;
using UI.UpGrade;
using UI.WorkShop;
using UI.WorldMap;
using UnityEngine;

namespace UI.Tips;

public class UI_BoxCostItemTip : GComponent, IUiController
{
	public GGraph back;

	public UI_BoxItemTipDialog tip1;

	public GGraph missileBack;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9gb515a";

	public static string Name = "UI_BoxCostItemTip";

	private const string StrangeKey = "I40109";

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

	public static string GetURL()
	{
		return "ui://47lbpgx9gb515a";
	}

	public static UI_BoxCostItemTip CreateInstance()
	{
		return (UI_BoxCostItemTip)(object)UIPackage.CreateObject("Tips", "BoxCostItemTip");
	}

	public static UI_BoxCostItemTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BoxCostItemTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gb515a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		tip1 = (UI_BoxItemTipDialog)(object)((GComponent)this).GetChild("tip1");
		missileBack = (GGraph)((GComponent)this).GetChild("missileBack");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		tip1.checkBtn.title.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		if (!parameters.ContainsKey("ItemId"))
		{
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
		materialItemType = Item.ItemType(_materialItemId);
		if (materialItemType == 5 && BuildingManager.ItemIdToProductDict.ContainsKey(_materialItemId) && !unlockedProducts.Contains(GameManagers.Instance.BuildingManager.GetProductByItemId(_materialItemId).Key))
		{
			tip1.PageController.selectedIndex = 1;
			GDEProductData productByItemId = GameManagers.Instance.BuildingManager.GetProductByItemId(_materialItemId);
			Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(productByItemId.BuildType.First());
			source = "，" + LanguagesManager.GetDesc("CsharpCodeZhTcText580") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText581") + buildingByType.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText582");
		}
		else
		{
			tip1.PageController.selectedIndex = 1;
		}
		tip1.SetControllerPageText();
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
	}

	public void OnShow()
	{
		((GObject)tip1.Content.RightContent).SetXY(((GObject)tip1.Content.RightContent).x, (((GObject)tip1.Content).height - ((GObject)tip1.Content.RightContent).height) / 2f);
		showTip.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GObject)tip1.checkBtn).onClick.Add(new EventCallback0(ToSourcePanel));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(End));
		((GObject)tip1.checkBtn).onClick.Remove(new EventCallback0(ToSourcePanel));
	}

	private void OpenMaterialElevationPanel()
	{
		((GObject)tip1.Content.RightContent.title).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, _materialItemId);
		FGUIManager.Instance.SetItemIconAndFrame(tip1.Content.icon, _materialItemId);
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
			((GObject)tip1.Content.RightContent.introduction).text = Item.PostScript(_materialItemId) + source;
		}
		if (Item.ItemType(_materialItemId) == 2)
		{
			Dictionary<string, string> itemBonus = Item.GetItemBonus(GameManagers.Instance, _materialItemId);
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
			((GObject)tip1.Content.RightContent.introduction).text = Item.PostScript(_materialItemId);
		}
		else
		{
			tip1.Content.RightContent.PageController.selectedIndex = 1;
		}
		string text = GDMgr.Get<GDEItemData>(_materialItemId)?.AccessPath ?? string.Empty;
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

	private void CloseParentPanel()
	{
		if (parent != null && parent is UI_MaterialIntroductionPanel)
		{
			((UI_MaterialIntroductionPanel)parent).End();
		}
		else if (parent != null && parent is UI_IdentificationPanel)
		{
			((UI_IdentificationPanel)parent).End();
		}
	}

	private void ToSourcePanel()
	{
		if (_materialItemId == "I40109")
		{
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorldMapPanel.Name, parameters);
			End();
			CloseParentPanel();
			return;
		}
		string jumpContext = StockController.GetJumpContext(_materialItemId);
		if (string.IsNullOrEmpty(jumpContext))
		{
			string key = GameManagers.Instance.BuildingManager.GetProductByItemId(_materialItemId).Key;
			if (!BuildingManager.Products.ContainsKey(key))
			{
				Debug.LogWarning((object)("没找到对应的产品 " + key));
				if (Item.ItemType(_materialItemId) == 9)
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
			if (buildingByType == null)
			{
				return;
			}
			if (buildingByType.Level == 0)
			{
				if (GameManagers.Instance.UserArchiveManager.GetBuildingMaxLevel(buildingByType.BuildingType) > 0)
				{
					End();
					Dictionary<string, object> parameters2 = new Dictionary<string, object>
					{
						{ "Building", buildingByType },
						{
							"SortingOrder",
							((GObject)this).sortingOrder
						}
					};
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters2);
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
				CloseParentPanel();
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
		else
		{
			CloseParentPanel();
			End();
			toSourceParameters.Add("SortingOrder", ((GObject)this).sortingOrder);
			if (jumpContext == "UI_MilitaryIntelligencePanel")
			{
				FGUIManager.Instance.OpenMilitaryIntelligencePanel(jumpContext, toSourceParameters);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(jumpContext, toSourceParameters);
			}
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reserveResource);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}
}
