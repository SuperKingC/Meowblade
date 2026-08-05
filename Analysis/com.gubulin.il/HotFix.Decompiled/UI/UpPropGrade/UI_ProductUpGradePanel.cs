using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.RecruitingCamp;
using UI.SoldierCultivate;
using UI.UpGrade;
using UI.WorkShop;
using UnityEngine;

namespace UI.UpPropGrade;

public class UI_ProductUpGradePanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_Dialog tip1;

	public Transition popup;

	public const string URL = "ui://blindbbgx4m20";

	public static string Name = "UI_ProductUpGradePanel";

	private string _itemId;

	private UI_WorkShopPanel mainUi1;

	private UI_SoldierCultivate mainUi2;

	private UI_RecruitingCamp mainUi3;

	private Canvas canvas;

	private Vector2 _xy;

	private int openType;

	private Coroutine OpenMaterialElevation;

	private List<string> textureList = new List<string>();

	public static string GetURL()
	{
		return "ui://blindbbgx4m20";
	}

	public static UI_ProductUpGradePanel CreateInstance()
	{
		return (UI_ProductUpGradePanel)(object)UIPackage.CreateObject("UpPropGrade", "ProductUpGradePanel");
	}

	public static UI_ProductUpGradePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProductUpGradePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://blindbbgx4m20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		tip1 = (UI_Dialog)(object)((GComponent)this).GetChild("tip1");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_itemId = (string)parameters["ProductId"];
		if (_itemId[0] != 'I')
		{
			_itemId = BuildingManager.Products[_itemId].ItemId;
		}
		if ((string)parameters["Style"] == "Work")
		{
			if (parameters.ContainsKey("MainUI"))
			{
				mainUi1 = (UI_WorkShopPanel)parameters["MainUI"];
			}
			if (parameters.ContainsKey("Soldier"))
			{
				mainUi2 = (UI_SoldierCultivate)parameters["Soldier"];
			}
			openType = 0;
		}
		else if ((string)parameters["Style"] == "Soldier")
		{
			mainUi2 = (UI_SoldierCultivate)parameters["MainUI"];
			openType = 1;
			canvas = (Canvas)parameters["Spine"];
			canvas.sortingLayerName = "Default";
		}
		else if ((string)parameters["Style"] == "Camp")
		{
			mainUi3 = (UI_RecruitingCamp)parameters["MainUI"];
			openType = 2;
			canvas = (Canvas)parameters["Spine"];
			canvas.sortingLayerName = "Default";
		}
		OpenMaterialElevationPanel();
		((GObject)this).sortingOrder = 3;
	}

	private void JudgeBuildingLevel()
	{
		string key = GameManagers.Instance.BuildingManager.GetProductByItemId(_itemId).Key;
		if (!BuildingManager.Products.ContainsKey(key))
		{
			((GObject)this).alpha = 0f;
			End();
			return;
		}
		GDEProductData gDEProductData = BuildingManager.Products[key];
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType(gDEProductData.BuildType.First());
		if (buildingByType != null)
		{
			if (buildingByType.Level == 0)
			{
				((GObject)this).alpha = 0f;
				if (GameManagers.Instance.UserArchiveManager.GetBuildingMaxLevel(buildingByType.BuildingType) > 0)
				{
					End();
					Dictionary<string, object> parameters = new Dictionary<string, object> { { "Building", buildingByType } };
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters);
				}
				else
				{
					End();
					List<string> arg = new List<string>
					{
						LanguagesManager.GetDesc("CsharpCodeZhTcText632") + buildingByType.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText633"),
						LanguagesManager.GetDesc("CsharpCodeZhTcText579")
					};
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
			}
		}
		else
		{
			((GObject)this).alpha = 0f;
			End();
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
		((GObject)tip1.ProductUpGradeBtn).onClick.Add(new EventCallback1(EvoBtnClick));
		((GObject)tip1.exitBtn).onClick.Add(new EventCallback0(End));
		Timers.inst.Add(0.8f, 0, new TimerCallback(UpdateStock));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		((GObject)tip1.ProductUpGradeBtn).onClick.Remove(new EventCallback1(EvoBtnClick));
		((GObject)tip1.exitBtn).onClick.Remove(new EventCallback0(End));
		Timers.inst.Remove(new TimerCallback(UpdateStock));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("ProductUpgradePanel.ConfirmBtn", tip1.ProductUpGradeBtn);
	}

	public void OnShow()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		popup.Play((PlayCompleteCallback)delegate
		{
			UiTagManager instance = UiTagManager.Instance;
			instance.Register("ProductUpgradePanel.ConfirmBtn", tip1.ProductUpGradeBtn);
		});
		JudgeBuildingLevel();
	}

	private void UpdateRequirements(bool isInit = true)
	{
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected O, but got Unknown
		//IL_078d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_0687: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Expected O, but got Unknown
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c3: Expected O, but got Unknown
		for (int i = 0; i < 3; i++)
		{
			GGraph asGraph = ((GComponent)tip1.LeftContent).GetChild($"MaterialItem{i}").asCom.GetChild("SfxBack").asGraph;
			((GObject)asGraph).SetXY(45f, 47f);
		}
		int num = Item.Level(GameManagers.Instance, _itemId);
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ItemUpgradeCost", new string[1] { _itemId });
		Dictionary<string, int> dictionary = Item.EvoRequirement(GameManagers.Instance, _itemId, num, percentFloatPayload);
		List<KeyValuePair<string, int>> list = null;
		if (dictionary != null)
		{
			list = new List<KeyValuePair<string, int>>(dictionary);
		}
		int materialCnt = 0;
		Dictionary<GObject, bool> dictionary2 = new Dictionary<GObject, bool>();
		float percentFloatPayload2 = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ItemUpgradeCost");
		if (list != null)
		{
			Dictionary<string, int> dictionary3 = Item.OriginEvoRequirement(GameManagers.Instance, _itemId, num);
			KeyValuePair<string, int> moneyCost = list.First();
			list.RemoveAt(0);
			int stock = GameManagers.Instance.StockController.GetStock(moneyCost.Key);
			GButton consumptionItem = tip1.MiddleContent.ConsumptionItem;
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)consumptionItem).GetChild("icon").asLoader, moneyCost.Key, textureList);
			string text = ((moneyCost.Value > stock) ? "#DC143C" : "#F6E2B2");
			string text2 = "#F6E2B2";
			GComponent asCom = ((GComponent)consumptionItem).GetChild("reqDesc").asCom;
			GComponent asCom2 = asCom.GetChild("originPrice").asCom;
			((GObject)asCom2).SetSize(0f, 0f);
			((GObject)asCom2).visible = false;
			GTextField asTextField = asCom.GetChild("curPrice").asTextField;
			((GObject)asTextField).text = "[color=" + text + "]" + stock.ShortNumberFormat() + "[/color][color=" + text2 + "]/" + moneyCost.Value.ShortNumberFormat() + "[/color]";
			((GObject)consumptionItem).data = moneyCost.Value;
			((GObject)((GComponent)consumptionItem).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
			{
				ItemTip(moneyCost.Key);
			});
			if (percentFloatPayload2 < 0f)
			{
				asCom.GetChild("ExclamationMarkBtn").visible = true;
				asCom.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{
						"Title",
						LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}%", LanguagesManager.GetDesc("CsharpCodeZhTcText553"), Convert.ToInt32(Mathf.Abs(percentFloatPayload2) * 100f))
					},
					{
						"Pos",
						(object)new Vector2(960f, 452f)
					}
				};
				asCom.GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
			else
			{
				asCom.GetChild("ExclamationMarkBtn").visible = false;
			}
			foreach (KeyValuePair<string, int> item in list)
			{
				string itemId = item.Key;
				int num2 = Item.Stock(GameManagers.Instance, itemId);
				ItemType itemType = (ItemType)Item.ItemType(itemId);
				ItemType itemType2 = itemType;
				if ((itemType2 == ItemType.CollectableResource || itemType2 == ItemType.Blueprint) && ((GComponent)tip1.LeftContent).GetChild($"MaterialItem{materialCnt}") is UI_Material { Icon: var icon, Requirement: var requirement } uI_Material)
				{
					bool flag = item.Value <= num2;
					string text3 = (flag ? "#FFFFFF" : "#DC143C");
					string text4 = "#FFFFFF";
					GComponent asCom3 = requirement.GetChild("originPrice").asCom;
					((GObject)asCom3).SetSize(0f, 0f);
					((GObject)asCom3).visible = false;
					GTextField asTextField2 = requirement.GetChild("curPrice").asTextField;
					((GObject)asTextField2).text = "[color=" + text3 + "]" + num2.ShortNumberFormat() + "[/color][color=" + text4 + "]/" + item.Value.ShortNumberFormat() + "[/color]";
					FGUIManager.Instance.SetItemIconAndFrame(icon, itemId, textureList);
					GObject child = ((GComponent)tip1).GetChild($"line{materialCnt}");
					if (child != null)
					{
						dictionary2.Add(child, !flag);
					}
					((GObject)requirement).x = ((GObject)uI_Material).width / 2f;
					if (percentFloatPayload2 < 0f)
					{
						requirement.GetChild("ExclamationMarkBtn").visible = true;
						requirement.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
						{
							{
								"Title",
								LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}%", LanguagesManager.GetDesc("CsharpCodeZhTcText553"), Convert.ToInt32(Mathf.Abs(percentFloatPayload2) * 100f))
							},
							{
								"Pos",
								(object)new Vector2(960f, 452f)
							}
						};
						requirement.GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
					}
					else
					{
						requirement.GetChild("ExclamationMarkBtn").visible = false;
					}
					((GObject)icon).onClick.Set((EventCallback0)delegate
					{
						ItemTip(itemId);
					});
					int num3 = materialCnt;
					materialCnt = num3 + 1;
				}
			}
		}
		if (materialCnt == 3 && !isInit)
		{
			for (int num4 = 0; num4 < 3; num4++)
			{
				if (num4 != 1)
				{
					GGraph asGraph2 = ((GComponent)tip1.LeftContent).GetChild($"MaterialItem{num4}").asCom.GetChild("SfxBack").asGraph;
					FGUIManager.Instance.AddTextSpecialEffects(asGraph2, "item_smoke", new Vector3(150f, 150f, 150f));
				}
			}
			((GComponent)(object)this).SetTimeout(0.1f).OnComplete((GTweenCallback)delegate
			{
				tip1.LeftContent.PageSwitch.selectedIndex = ((materialCnt < 1) ? 3 : (materialCnt - 1));
			});
		}
		else
		{
			tip1.LeftContent.PageSwitch.selectedIndex = ((materialCnt < 1) ? 3 : (materialCnt - 1));
		}
		foreach (KeyValuePair<GObject, bool> item2 in dictionary2)
		{
			item2.Key.grayed = item2.Value;
		}
	}

	private void OpenMaterialElevationPanel(bool isInit = true)
	{
		int num = Item.Level(GameManagers.Instance, _itemId);
		int weaponEvoLevel = GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(_itemId);
		bool flag = num >= GameManagers.Instance.UserArchiveManager.GetWeaponMaxLevel();
		((GObject)tip1.RightContent.Name_t).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, _itemId);
		tip1.LeftContent.Product.Frame.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, weaponEvoLevel);
		tip1.LeftContent.Product.Icon.url = "ui://PublicResources/" + UiHelper.GetIconPath(_itemId, weaponEvoLevel);
		((GObject)tip1.RightContent.CurrentLevel_t).text = string.Format("{0}{1}", num - 1, LanguagesManager.GetDesc("CsharpCodeZhTcText124"));
		((GObject)tip1.RightContent.NextLevel_t).text = (flag ? LanguagesManager.GetDesc("CsharpCodeZhTcText630") : string.Format("{0}{1}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText124")));
		Dictionary<string, string> itemBonus = Item.GetItemBonus(GameManagers.Instance, _itemId);
		Dictionary<string, string> nextLevelItemBonus = Item.GetNextLevelItemBonus(GameManagers.Instance, _itemId);
		tip1.RightContent.PropertyList.RemoveChildrenToPool();
		int num2 = 0;
		if (itemBonus != null)
		{
			foreach (KeyValuePair<string, string> item in itemBonus)
			{
				GComponent asCom = tip1.RightContent.PropertyList.AddItemFromPool().asCom;
				((GObject)asCom).visible = true;
				asCom.GetChild("title").text = item.Key ?? "";
				((GObject)asCom.GetChild("Current_t").asTextField).text = "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint(item.Value);
				((GObject)asCom.GetChild("Next_t").asTextField).text = LanguagesManager.GetDesc("CsharpCodeZhTcText630");
				num2++;
			}
		}
		num2 = 0;
		if (!flag && nextLevelItemBonus != null)
		{
			foreach (KeyValuePair<string, string> item2 in nextLevelItemBonus)
			{
				GComponent asCom2 = ((GComponent)tip1.RightContent.PropertyList).GetChildAt(num2).asCom;
				((GObject)asCom2).visible = true;
				((GObject)asCom2.GetChild("Next_t").asTextField).text = "+" + UiHelper.RemoveSurplusZeroBehindDecimalPoint(item2.Value);
				num2++;
			}
		}
		if (tip1.RightContent.PropertyList.numItems > 2)
		{
			tip1.RightContent.PropertyList.ResizeToFit(tip1.RightContent.PropertyList.numItems);
		}
		UpdateRequirements(isInit);
		if (Item.CanUpgrade(GameManagers.Instance, _itemId, out var _))
		{
			((GObject)tip1.ProductUpGradeBtn).grayed = false;
			((GObject)tip1.ProductUpGradeBtn).touchable = true;
		}
		else
		{
			((GObject)tip1.ProductUpGradeBtn).grayed = true;
			((GObject)tip1.ProductUpGradeBtn).touchable = false;
		}
		if (flag)
		{
			((GObject)tip1.upgradeTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText631");
			((GObject)tip1.MiddleContent).visible = false;
		}
		else
		{
			((GObject)tip1.upgradeTitle).text = "";
			((GObject)tip1.MiddleContent).visible = true;
		}
	}

	public void EvoBtnClick(EventContext eventContext)
	{
		if (!Item.CanUpgrade(GameManagers.Instance, _itemId, out var _))
		{
			return;
		}
		ILRequestHelper<UpgradeItemResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().UpgradeItem(-1L, _itemId), delegate(UpgradeItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OnProductEvoCompleted();
				string soldierId = "";
				if (mainUi2 != null)
				{
					soldierId = mainUi2.soldierId;
				}
				ThinkingDataHelper.Instance.EquipLevelUpTrack(_itemId, Item.Level(GameManagers.Instance, _itemId), soldierId);
			}
		});
	}

	private void OnProductEvoCompleted()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		GGraph aimSfxBack = ((GComponent)tip1.LeftContent).GetChild("Product").asCom.GetChild("SfxBack").asGraph;
		Vector2 xy = ((GObject)aimSfxBack).xy;
		for (int i = 0; i < 3; i++)
		{
			GGraph SfxBack = ((GComponent)tip1.LeftContent).GetChild($"MaterialItem{i}").asCom.GetChild("SfxBack").asGraph;
			FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "item_missile", new Vector3(100f, 100f, 100f));
			Vector2 val = ((GObject)((GComponent)tip1.LeftContent).GetChild("Product").asCom).TransformPoint(xy, (GObject)(object)((GComponent)tip1.LeftContent).GetChild($"MaterialItem{i}").asCom);
			((GObject)SfxBack).TweenMove(val, 0.25f).OnComplete((GTweenCallback)delegate
			{
				((GObject)SfxBack).SetXY(45f, 47f);
			});
		}
		((GComponent)(object)this).SetTimeout(0.25f).OnComplete((GTweenCallback)delegate
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			((GObject)aimSfxBack).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(aimSfxBack, "activating_white", new Vector3(235f, 235f, 235f));
		});
		if (OpenMaterialElevation != null)
		{
			FGUIManager.Instance.CloseIEnumerator(OpenMaterialElevation);
			OpenMaterialElevation = null;
			OpenMaterialElevationPanel(isInit: false);
		}
		OpenMaterialElevation = FGUIManager.Instance.OpenIEnumerator(RefreshMaterial());
		Item.Upgrade(GameManagers.Instance, _itemId);
		if (openType == 0)
		{
			mainUi2?.RefreshDegreeElevationData();
		}
		if (openType == 1)
		{
			mainUi2?.RefreshDegreeElevationData();
			mainUi2?.ChangePageEvent();
		}
		if (openType == 2)
		{
			mainUi3?.InitData(Flag: false, isHide: false);
		}
		SharedMessenger.Broadcast("PRODUCT_UPGRADED");
	}

	private IEnumerator RefreshMaterial()
	{
		yield return (object)new WaitForSeconds(0.4f);
		OpenMaterialElevationPanel(isInit: false);
		OpenMaterialElevation = null;
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		mainUi1 = null;
		mainUi2 = null;
		mainUi3 = null;
		canvas = null;
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (OpenMaterialElevation != null)
		{
			FGUIManager.Instance.CloseIEnumerator(OpenMaterialElevation);
		}
	}

	private void ItemTip(string itemId)
	{
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder);
	}

	public void UpdateStock(object parameter)
	{
		UpdateRequirements();
		if (Item.CanUpgrade(GameManagers.Instance, _itemId, out var _))
		{
			((GObject)tip1.ProductUpGradeBtn).grayed = false;
			((GObject)tip1.ProductUpGradeBtn).touchable = true;
		}
		else
		{
			((GObject)tip1.ProductUpGradeBtn).grayed = true;
			((GObject)tip1.ProductUpGradeBtn).touchable = false;
		}
	}
}
