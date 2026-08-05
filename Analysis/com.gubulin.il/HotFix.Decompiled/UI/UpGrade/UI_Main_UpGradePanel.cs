using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Helpers;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Collection;
using UI.Dungeons;
using UI.MainCity;
using UI.RecruitingCamp;
using UI.RecyclingCenter;
using UI.Warehouse;
using UI.WorkShop;
using UnityEngine;

namespace UI.UpGrade;

public class UI_Main_UpGradePanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static PlayCompleteCallback _003C_003E9__12_0;

		internal void _003COnShow_003Eb__12_0()
		{
		}
	}

	public GGraph mask;

	public UI_Main_UpgradeDialog tip;

	public Transition popup;

	public const string URL = "ui://lrjfe94hm4fq3g";

	public static string Name = "UI_Main_UpGradePanel";

	private Building building;

	private IUiController parentPanel;

	private int curWorkerNum;

	private List<string> textureList = new List<string>();

	private int MaxLevelLimit => (building.BuildingType == "10") ? 15 : 5;

	public static string GetURL()
	{
		return "ui://lrjfe94hm4fq3g";
	}

	public static UI_Main_UpGradePanel CreateInstance()
	{
		return (UI_Main_UpGradePanel)(object)UIPackage.CreateObject("UpGrade", "Main_UpGradePanel");
	}

	public static UI_Main_UpGradePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Main_UpGradePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		tip = (UI_Main_UpgradeDialog)(object)((GComponent)this).GetChild("tip");
		popup = ((GComponent)this).GetTransition("popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("SortingOrder", out var value))
		{
			((GObject)this).sortingOrder = (int)value;
		}
		else
		{
			((GObject)this).sortingOrder = 1;
		}
		PanelInit(parameters);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GObject)tip.fixButton).onClick.Add(new EventCallback1(UpEvent));
		((GObject)tip.upGradeButton).onClick.Add(new EventCallback1(UpEvent));
		((GObject)tip.acceptButton).onClick.Add(new EventCallback1(UpEvent));
		((GObject)tip.exit).onClick.Add(new EventCallback0(End));
		((GObject)tip.increaseBtn).onClick.Add(new EventCallback0(AddWorkerNum));
		((GObject)tip.reduceBtn).onClick.Add(new EventCallback0(ReduceWorkerNum));
		SharedMessenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", RefreshPanelDelay);
		Timers.inst.Add(0.8f, 0, new TimerCallback(UpdateStock));
		Timers.inst.Add(1f, 0, new TimerCallback(UpdateJobSschedule));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		((GObject)tip.fixButton).onClick.Remove(new EventCallback1(UpEvent));
		((GObject)tip.upGradeButton).onClick.Remove(new EventCallback1(UpEvent));
		((GObject)tip.acceptButton).onClick.Remove(new EventCallback1(UpEvent));
		((GObject)tip.exit).onClick.Remove(new EventCallback0(End));
		((GObject)tip.increaseBtn).onClick.Remove(new EventCallback0(AddWorkerNum));
		((GObject)tip.reduceBtn).onClick.Remove(new EventCallback0(ReduceWorkerNum));
		SharedMessenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", RefreshPanelDelay);
		Timers.inst.Remove(new TimerCallback(UpdateStock));
		Timers.inst.Remove(new TimerCallback(UpdateJobSschedule));
	}

	public void OnShow()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("BuildingUpgradePanel.ConfirmBtn", tip.fixButton);
		instance.Register("BuildingUpgradePanel.AddWorkerBtn", tip.increaseBtn);
		instance.Register("BuildingUpgradePanel.ReduceWorkerBtn", tip.reduceBtn);
		Transition obj = popup;
		object obj2 = _003C_003Ec._003C_003E9__12_0;
		if (obj2 == null)
		{
			PlayCompleteCallback val = delegate
			{
			};
			_003C_003Ec._003C_003E9__12_0 = val;
			obj2 = (object)val;
		}
		obj.Play((PlayCompleteCallback)obj2);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("BuildingUpgradePanel.ConfirmBtn", tip.fixButton);
		instance.Unregister("BuildingUpgradePanel.AddWorkerBtn", tip.increaseBtn);
		instance.Unregister("BuildingUpgradePanel.ReduceWorkerBtn", tip.reduceBtn);
	}

	private void UpEvent(EventContext eventContext)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		if (building.Status == BuildingStatus.Running || building.Status == BuildingStatus.Disabled || building.Status == BuildingStatus.Abandoned)
		{
			Dungeon value = GameController.Contexts.game.dungeon.value;
			int freeManPower = Dungeon.GetFreeManPower(GameManagers.Instance);
			if (building.Level == 0)
			{
				curWorkerNum = 0;
			}
			if (curWorkerNum <= 0 && building.Level >= 1)
			{
				ILRequestHelper.ShowErrorCode(82000004);
				return;
			}
			if (curWorkerNum > freeManPower)
			{
				ILRequestHelper.ShowErrorCode(82000005);
				((GObject)((GComponent)parentPanel).GetChild("addWorkerBtn").asCom.GetChild("CurrentWorkerAmount").asTextField).text = $"{freeManPower}";
				return;
			}
			ActionResult actionResult = building.CheckUpgradeCondition(curWorkerNum);
			if (!actionResult.Result)
			{
				ILRequestHelper.ShowMessage(actionResult.ErrorMessage);
				return;
			}
			ILRequestHelper<UpgradeBuildingResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().UpgradeBuilding(-1L, building.BuildingType, curWorkerNum, null), delegate(UpgradeBuildingResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					ActionResult actionResult2 = building.Upgrade(curWorkerNum);
					if (!actionResult2.Result)
					{
						ILRequestHelper.ShowMessage(actionResult2.ErrorMessage);
					}
					else
					{
						End();
						if (parentPanel is UI_MainCity)
						{
							FGUIManager.Instance.BuildingFocus(building.GameObject, 0.1f, needCloseUi: false);
						}
						else
						{
							if (parentPanel is UI_DungeonsPanel uI_DungeonsPanel)
							{
								uI_DungeonsPanel.End();
							}
							FGUIManager.Instance.BuildingFocus(building.GameObject, 0.8f);
						}
						CloseParentPanel(isReady: false);
					}
				}
			});
		}
		else if (building.Status == BuildingStatus.Ready)
		{
			HitArea component = building.GameObject.GetComponent<HitArea>();
			if (!building.IsReady())
			{
				Debug.LogError((object)$"建筑{building.BuildingType}验收失败 Status: {building.Status}");
				return;
			}
			ILRequestHelper<FinishUpgradeBuildingResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().FinishUpgradeBuilding(-1L, building.BuildingType), delegate(FinishUpgradeBuildingResponse response)
			{
				bool isReady = false;
				if (response.Result && building.FinishUpgrade().Result)
				{
					isReady = true;
				}
				End();
				CloseParentPanel(isReady);
			});
		}
		else
		{
			CloseParentPanel(isReady: false);
		}
	}

	private void CloseParentPanel(bool isReady)
	{
		if (parentPanel != null)
		{
			if (parentPanel is UI_CollectionPanel uI_CollectionPanel)
			{
				uI_CollectionPanel.End();
			}
			else if (parentPanel is UI_WorkShopPanel uI_WorkShopPanel)
			{
				uI_WorkShopPanel.End();
			}
			else if (parentPanel is UI_WarehousePanel uI_WarehousePanel)
			{
				uI_WarehousePanel.End();
			}
			else if (parentPanel is UI_RecruitingCamp uI_RecruitingCamp)
			{
				uI_RecruitingCamp.ExitPanel();
			}
			else if (parentPanel is UI_DungeonsPanel uI_DungeonsPanel && isReady)
			{
				uI_DungeonsPanel.PlayProgressBarSfx();
			}
		}
	}

	private void UpBtnRefresh()
	{
		if (building.Status == BuildingStatus.Running || building.Status == BuildingStatus.Disabled || building.Status == BuildingStatus.Abandoned)
		{
			if (building.Level != 0)
			{
				if (building.CanUpgrade())
				{
					((GObject)((GObject)tip.fixButton).asButton).enabled = true;
					((GObject)((GObject)tip.upGradeButton).asButton).enabled = true;
					tip.consumptionText.c1.SetSelectedIndex(1);
				}
				else
				{
					tip.consumptionText.c1.SetSelectedIndex(0);
					((GObject)((GObject)tip.fixButton).asButton).enabled = false;
					((GObject)((GObject)tip.upGradeButton).asButton).enabled = false;
				}
			}
		}
		else if (building.Status == BuildingStatus.Ready)
		{
			((GObject)((GObject)tip.fixButton).asButton).enabled = true;
		}
		else if (building.Status == BuildingStatus.Constructing)
		{
			((GObject)((GObject)tip.fixButton).asButton).enabled = false;
		}
	}

	private void UpdateBasicInfo()
	{
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		((GObject)tip.gradeTitle).text = LanguagesManager.GetDesc("CurrentLevel_Title");
		((GObject)tip.title).text = building.Name;
		((GObject)tip.buildingDesc).text = building.Desc;
		int num = building.Level + 1;
		if (building.BuildingType == "10" && num >= 6)
		{
			num = 6;
		}
		tip.nextBuildingImage.url = $"ui://UpGrade/{building.Data.Key}_{num}";
		string text = ((building.Status != BuildingStatus.Banned) ? ("Building" + building.BuildingType) : "NotRepair");
		tip.icon.url = "ui://PublicResources/" + text;
		bool flag = building.BuildingType == "14" || building.BuildingType == "16" || building.BuildingType == "7" || building.BuildingType == "18";
		if (flag)
		{
			((GObject)tip.level).text = $"{building.Level}/{1}";
		}
		else
		{
			((GObject)tip.level).text = $"{building.Level}/{MaxLevelLimit}";
		}
		if (building.BuildingType == "18")
		{
		}
		if (flag || building.BuildingType == "18")
		{
			((GObject)((GObject)tip.nextLevelEffectGroup).asGroup).visible = false;
			return;
		}
		((GObject)tip.nextLevelEffectGroup).visible = true;
		if (building.Level == MaxLevelLimit)
		{
			((GObject)((GObject)tip.nextLevelEffectGroup).asGroup).visible = false;
			return;
		}
		((GComponent)tip).GetChild("buildSLotIcon").asLoader.color = Color32.op_Implicit(new Color32((byte)246, (byte)226, (byte)178, byte.MaxValue));
		if (building.BuildingType == "10")
		{
			tip.buildSLotIcon.url = "ui://PublicResources/出兵位";
			((GObject)tip.buildingSlotName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText191");
			((GObject)tip.slotNum).text = building.SomeLevelSlot(building.NextLevel).ToString();
		}
		else if (building.BuildingType == "11")
		{
			tip.buildSLotIcon.url = "ui://PublicResources/库存量";
			((GObject)tip.buildingSlotName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText192");
			((GObject)tip.slotNum).text = $"{building.NextLevel * 100}%";
		}
		else
		{
			tip.buildSLotIcon.url = "ui://PublicResources/工位图标";
			((GObject)tip.buildingSlotName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText193");
			((GObject)tip.slotNum).text = building.SomeLevelSlot(building.NextLevel).ToString();
		}
	}

	private void ShowTempBuilding7Info()
	{
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		tip.consumptionList.RemoveChildrenToPool();
		tip.StateController.selectedIndex = 0;
		((GObject)tip.consumptionText.consumption).text = LanguagesManager.GetDesc("CsharpCodeZhTcText620") + LanguagesManager.GetDesc("CsharpCodeZhTcText621") + LanguagesManager.GetDesc("CsharpCodeZhTcText622");
		Dictionary<string, int> nextLevelRequirements = building.GetNextLevelRequirements();
		ShowExclamationMarkBtn();
		foreach (KeyValuePair<string, int> itemKv in nextLevelRequirements)
		{
			if (!itemKv.Key.Contains("LevelId"))
			{
				UI_com_goodItemConsume uI_com_goodItemConsume = tip.consumptionList.AddItemFromPool() as UI_com_goodItemConsume;
				string key = itemKv.Key;
				int num = Item.Level(GameManagers.Instance, key);
				int stock = GameManagers.Instance.StockController.GetStock(key);
				if (itemKv.Value > stock)
				{
					uI_com_goodItemConsume.check.SetSelectedIndex(0);
				}
				else
				{
					uI_com_goodItemConsume.check.SetSelectedIndex(1);
				}
				GTextField curPrice = uI_com_goodItemConsume.curPrice;
				((GObject)curPrice).text = stock.ShortNumberFormat() + "/" + itemKv.Value.ShortNumberFormat();
				FGUIManager.Instance.SetItemIconAndFrame(((GComponent)uI_com_goodItemConsume).GetChild("icon").asLoader, key, textureList, UiHelper.GetIconFrameBorder(2, (num < 1) ? 1 : num));
				((GObject)uI_com_goodItemConsume).data = itemKv;
				((GObject)uI_com_goodItemConsume).onClick.Set((EventCallback0)delegate
				{
					ItemTip(itemKv.Key);
				});
			}
		}
		tip.consumptionList.ResizeToFit(tip.consumptionList.numItems);
		((GObject)tip.fixButton).enabled = false;
		((GObject)tip.gradeTitle).text = LanguagesManager.GetDesc("CurrentLevel_PlaceHolder");
		((GObject)tip.gradeTitle).visible = false;
		((GObject)tip.level).text = string.Empty;
	}

	private void UpdateAdvanceInfo()
	{
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		tip.consumptionList.RemoveChildrenToPool();
		if (building.Status == BuildingStatus.Running || building.Status == BuildingStatus.Disabled || building.Status == BuildingStatus.Abandoned)
		{
			if (!GameController.Configs.TryGetValue("BLL", out var _))
			{
				if (building.Level == MaxLevelLimit)
				{
					tip.StateController.selectedIndex = 6;
					RenderWorkList(curWorkerNum);
				}
				else if (building.Level == 0)
				{
					tip.StateController.selectedIndex = 1;
				}
				else
				{
					tip.StateController.selectedIndex = 3;
					RenderWorkList(curWorkerNum);
				}
				int buildingLevel = GameManagers.Instance.UserArchiveManager.GetBuildingLevel(building.BuildingType);
				int userLevelRequiredForBuildingUpgrade = GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForBuildingUpgrade(building.BuildingType, buildingLevel);
				if (GameManagers.Instance.UserArchiveManager.GetUserLevel() < userLevelRequiredForBuildingUpgrade)
				{
					if (tip.StateController.selectedIndex == 1)
					{
						tip.StateController.selectedIndex = 0;
					}
					else if (tip.StateController.selectedIndex == 3)
					{
						tip.StateController.selectedIndex = 2;
					}
					((GObject)tip.consumptionText.consumption).text = string.Format("{0} {1}", LanguagesManager.GetDesc("CsharpCodeZhTcText50"), userLevelRequiredForBuildingUpgrade);
				}
				Dictionary<string, int> nextLevelRequirements = building.GetNextLevelRequirements();
				if (nextLevelRequirements != null)
				{
					ShowExclamationMarkBtn();
					foreach (KeyValuePair<string, int> itemKv in nextLevelRequirements)
					{
						if (!itemKv.Key.Contains("LevelId"))
						{
							UI_com_goodItemConsume uI_com_goodItemConsume = tip.consumptionList.AddItemFromPool() as UI_com_goodItemConsume;
							string key = itemKv.Key;
							int num = Item.Level(GameManagers.Instance, key);
							int stock = GameManagers.Instance.StockController.GetStock(key);
							uI_com_goodItemConsume.check.SetSelectedIndex((itemKv.Value <= stock) ? 1 : 0);
							GTextField curPrice = uI_com_goodItemConsume.curPrice;
							((GObject)curPrice).text = stock.ShortNumberFormat() + "/" + itemKv.Value.ShortNumberFormat();
							FGUIManager.Instance.SetItemIconAndFrame(((GComponent)uI_com_goodItemConsume).GetChild("icon").asLoader, key, textureList, UiHelper.GetIconFrameBorder(2, (num < 1) ? 1 : num));
							((GObject)uI_com_goodItemConsume).data = itemKv;
							((GObject)uI_com_goodItemConsume).onClick.Set((EventCallback0)delegate
							{
								ItemTip(itemKv.Key);
							});
						}
					}
				}
				tip.consumptionList.ResizeToFit(tip.consumptionList.numItems);
			}
			else
			{
				tip.StateController.selectedIndex = 6;
				RenderWorkList(curWorkerNum);
			}
		}
		else if (building.Status == BuildingStatus.Ready)
		{
			((GObject)tip.consumption).text = " " + LanguagesManager.GetDesc("CsharpCodeZhTcText623") + "！";
			tip.StateController.selectedIndex = 5;
		}
		else if (building.Status == BuildingStatus.Constructing)
		{
			BuildingConstructingConfig constructingConfig = building.ConstructingConfig;
			double num2 = constructingConfig.UpgradeRemainingTime;
			double num3 = building.GetUpgradeTime(constructingConfig.Workers);
			((GProgressBar)tip.jobSschedule).value = (num3 - num2) / num3 * 100.0;
			((GObject)((GComponent)tip.jobSschedule).GetChild("time").asTextField).text = UiHelper.ParseTime(constructingConfig.UpgradeRemainingTime) ?? "";
			tip.StateController.selectedIndex = 4;
		}
	}

	private void UpdateRequirementTips(string buildingType)
	{
		if (building.Status != BuildingStatus.Running && building.HasStorylineUpgradeRequirement && building.Status != BuildingStatus.Ready && building.Status != BuildingStatus.Constructing)
		{
			tip.StateController.selectedIndex = 0;
			((GObject)tip.consumptionText.consumption).text = StorylineHelper.GetLevelDisplayTextFromLevelID(building.UpgradeRequiredStorylineLevel);
		}
	}

	private void RenderWorkList(int workerNum)
	{
		tip.workersList.numItems = workerNum;
		switch (workerNum)
		{
		case 0:
			((GObject)tip.buildTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText624") + " " + UiHelper.ParseTime(building.GetUpgradeTime());
			((GObject)tip.buildTime).grayed = true;
			return;
		case 1:
			((GObject)tip.buildTime).grayed = false;
			((GObject)tip.buildTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText624") + " " + UiHelper.ParseTime(building.GetUpgradeTime(workerNum));
			return;
		}
		((GObject)tip.buildTime).grayed = false;
		((GObject)tip.buildTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText624") + " " + UiHelper.ParseTime(building.GetUpgradeTime(workerNum)) + " [color=#A5E32E](-" + UiHelper.ParseTimeChinses(building.GetUpgradeTime() - building.GetUpgradeTime(workerNum)) + ")[/color]";
	}

	public void RefreshPanelDelay(string buildingType)
	{
		if (buildingType == building.BuildingType)
		{
			UpdateBasicInfo();
			UpdateAdvanceInfo();
			UpBtnRefresh();
		}
	}

	private void RefreshPanel(string buildingType)
	{
		if (buildingType == building.BuildingType)
		{
			UpdateBasicInfo();
			if ((building.BuildingType == "7" || building.BuildingType == "9" || building.BuildingType == "12") && !Define.GvGMode3UnderDevelopment())
			{
				ShowTempBuilding7Info();
				return;
			}
			if (building.BuildingType == "7" && building.Data.Status == -1)
			{
				ShowTempBuilding7Info();
				return;
			}
			UpdateAdvanceInfo();
			UpdateRequirementTips(buildingType);
			UpBtnRefresh();
		}
	}

	private void ShowExclamationMarkBtn()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("BuildingUpgradeCost");
		if (percentFloatPayload < 0f)
		{
			((GObject)tip.ExclamationMarkBtn).visible = true;
			((GObject)tip.ExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}%", LanguagesManager.GetDesc("CsharpCodeZhTcText553"), Convert.ToInt32(Mathf.Abs(percentFloatPayload) * 100f))
				},
				{
					"Pos",
					(object)new Vector2(960f, 452f)
				}
			};
			((GObject)tip.ExclamationMarkBtn).onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		}
		else
		{
			((GObject)tip.ExclamationMarkBtn).visible = false;
		}
	}

	private void AddWorkerNum()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		Dungeon value = GameController.Contexts.game.dungeon.value;
		int actualNum = Dungeon.GetFreeManPower(GameManagers.Instance);
		GGraph myGraph = null;
		if (parentPanel != null)
		{
			myGraph = ((GComponent)parentPanel).GetChild("addWorkerBtn").asCom.GetChild("workerButtonSpine").asGraph;
		}
		if (curWorkerNum >= 5)
		{
			if (myGraph != null)
			{
				((GObject)myGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(myGraph, FGUIManager.Instance.uiRed, new Vector3(178f, 45f, 45f));
			}
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText626") + "5" + LanguagesManager.GetDesc("CsharpCodeZhTcText627") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		if (curWorkerNum >= actualNum)
		{
			if (myGraph != null)
			{
				((GObject)myGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(myGraph, FGUIManager.Instance.uiRed, new Vector3(178f, 45f, 45f));
			}
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText628") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		curWorkerNum++;
		RenderWorkList(curWorkerNum);
		((GComponent)((GComponent)tip.workersList).GetChildAt(tip.workersList.numItems - 1).asButton).GetTransition("increase").Play((PlayCompleteCallback)delegate
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			if (myGraph != null)
			{
				int num = ((actualNum - curWorkerNum > 0) ? (actualNum - curWorkerNum) : 0);
				((GObject)((GObject)myGraph).parent.GetChild("CurrentWorkerAmount").asTextField).text = $"{num}";
				((GObject)myGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(myGraph, FGUIManager.Instance.uiGreen, new Vector3(178f, 45f, 45f));
			}
		});
	}

	private void ReduceWorkerNum()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		Dungeon value = GameController.Contexts.game.dungeon.value;
		int actualNum = Dungeon.GetFreeManPower(GameManagers.Instance);
		GGraph myGraph = null;
		if (parentPanel != null)
		{
			myGraph = ((GComponent)parentPanel).GetChild("addWorkerBtn").asCom.GetChild("workerButtonSpine").asGraph;
		}
		if (curWorkerNum < 1 || ((GComponent)((GComponent)tip.workersList).GetChildAt(tip.workersList.numItems - 1).asButton).GetTransition("reduce").playing)
		{
			return;
		}
		((GComponent)((GComponent)tip.workersList).GetChildAt(tip.workersList.numItems - 1).asButton).GetTransition("reduce").Play((PlayCompleteCallback)delegate
		{
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			curWorkerNum--;
			RenderWorkList(curWorkerNum);
			if (myGraph != null)
			{
				int num = ((actualNum - curWorkerNum > 0) ? (actualNum - curWorkerNum) : 0);
				((GObject)((GObject)myGraph).parent.GetChild("CurrentWorkerAmount").asTextField).text = $"{num}";
				((GObject)myGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(myGraph, FGUIManager.Instance.uiGreen, new Vector3(178f, 45f, 45f));
			}
		});
	}

	public void UpdateStock(object parameter)
	{
		if (building.Status != BuildingStatus.Running && building.Status != BuildingStatus.Abandoned && building.Status != BuildingStatus.Disabled)
		{
			return;
		}
		Dictionary<string, int> nextLevelRequirements = building.GetNextLevelRequirements();
		if (nextLevelRequirements == null)
		{
			return;
		}
		Dictionary<string, int> evoRequire = building.EvoData[building.NextLevel].EvoRequire;
		for (int i = 0; i < tip.consumptionList.numItems; i++)
		{
			UI_com_goodItemConsume uI_com_goodItemConsume = ((GComponent)tip.consumptionList).GetChildAt(i) as UI_com_goodItemConsume;
			KeyValuePair<string, int> keyValuePair = (KeyValuePair<string, int>)((GObject)uI_com_goodItemConsume).data;
			string key = keyValuePair.Key;
			int stock = GameManagers.Instance.StockController.GetStock(key);
			int value = keyValuePair.Value;
			if (keyValuePair.Value > stock)
			{
				uI_com_goodItemConsume.check.SetSelectedIndex(0);
			}
			else
			{
				uI_com_goodItemConsume.check.SetSelectedIndex(1);
			}
			GTextField curPrice = uI_com_goodItemConsume.curPrice;
			((GObject)curPrice).text = stock.ShortNumberFormat() + "/" + value.ShortNumberFormat();
		}
		if (building.CanUpgrade())
		{
			((GObject)tip.fixButton).enabled = true;
		}
		else
		{
			((GObject)tip.fixButton).enabled = false;
		}
	}

	public void UpdateJobSschedule(object parma)
	{
		if (tip.StateController.selectedIndex == 4)
		{
			BuildingConstructingConfig constructingConfig = building.ConstructingConfig;
			double num = constructingConfig.UpgradeRemainingTime;
			double num2 = building.GetUpgradeTime(constructingConfig.Workers);
			((GProgressBar)tip.jobSschedule).TweenValue((num2 - num) / num2 * 100.0, 1f);
			((GObject)((GComponent)tip.jobSschedule).GetChild("time").asTextField).text = UiHelper.ParseTime(constructingConfig.UpgradeRemainingTime) ?? "";
		}
	}

	private void ItemTip(string itemId)
	{
		List<string> itemBuildingSource = FGUIManager.Instance.GetItemBuildingSource(itemId);
		bool noCheckBtn = false;
		if (itemBuildingSource != null)
		{
			noCheckBtn = itemBuildingSource.Contains(building.BuildingType);
		}
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn);
	}

	private void End()
	{
		tip.consumptionList.numItems = 0;
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		if (parentPanel != null)
		{
			if (parentPanel is UI_CollectionPanel)
			{
				((UI_CollectionPanel)parentPanel).CheckWorkersCanAssign();
			}
			else if (parentPanel is UI_WorkShopPanel)
			{
				((UI_WorkShopPanel)parentPanel).CheckWorkersCanAssign();
			}
			else if (parentPanel is UI_WarehousePanel)
			{
				((UI_WarehousePanel)parentPanel).UpdateWorkerNum();
			}
			else if (parentPanel is UI_RecruitingCamp)
			{
				((UI_RecruitingCamp)parentPanel).UpdateWorkerNum();
			}
			else if (parentPanel is UI_DungeonsPanel)
			{
				((UI_DungeonsPanel)parentPanel).UpdateWorkerNum();
			}
			else if (parentPanel is UI_MainCity)
			{
				((UI_MainCity)parentPanel).UpdateManPower();
			}
			else if (parentPanel is UI_RecyclingCenterPanel)
			{
				((UI_RecyclingCenterPanel)parentPanel).CheckWorkersCanAssign();
			}
		}
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void PanelInit(Dictionary<string, object> parameters)
	{
		if (parameters.ContainsKey("Building"))
		{
			building = parameters["Building"] as Building;
		}
		else
		{
			if (!parameters.ContainsKey("BuildingType"))
			{
				Debug.LogWarning((object)("OpenPanel:" + Name + " 没有指定Building参数"));
				End();
				return;
			}
			building = GameManagers.Instance.BuildingManager.GetBuildingByType(parameters["BuildingType"].ToString());
		}
		if (building != null)
		{
			GameManagers.Instance.NewMsgIncomingManager.CheckBuilding(building.BuildingType);
		}
		if (parameters.ContainsKey("Parent"))
		{
			parentPanel = (IUiController)parameters["Parent"];
		}
		curWorkerNum = 0;
		RefreshPanel(building.BuildingType);
		UpdateStock(1);
	}
}
