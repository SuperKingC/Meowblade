using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.PushFirstTopup;
using UnityEngine;

namespace UI.Tips;

public class UI_ShowOfflineEarnings : GComponent, IUiController
{
	public Controller PageController;

	public GGraph mask;

	public GImage OfflineEarningWindow;

	public GButton exitBtn;

	public GTextField title;

	public GTextField OfflineTime;

	public GButton confirmBtn;

	public GList earningsList;

	public GList giftsList;

	public GTextField tip;

	public GImage n54;

	public GImage n55;

	public GImage n56;

	public GTextField GvGMode3Title;

	public GTextField GvGMode3OfflineTime;

	public UI_com_GvGMode3CollectBonus GvGMode3CollectBonus;

	public GTextField GvGMode3Tip;

	public GGroup earningGroup;

	public GImage n45;

	public GImage n44;

	public GGraph n43;

	public GTextField guideName;

	public GGroup LeftGroup;

	public GImage tipBack;

	public GImage corner;

	public GTextField npcWords;

	public GGroup guideNpcGroup;

	public GMovieClip AdvancedBox;

	public GGraph shiningSfxBack;

	public GGraph openSfxBack;

	public GGroup BoxGroup;

	public UI_GiftPanel GiftPanel;

	public UI_btn_OfflineBonusTab Tab0;

	public UI_btn_OfflineBonusTab Tab3;

	public Transition showUp;

	public Transition ShowGiftPanel;

	public Transition TabClick;

	public const string URL = "ui://47lbpgx9xibgg";

	public static string Name = "UI_ShowOfflineEarnings";

	private Action _extraConfirmAction;

	private List<Bonus> bonusList = new List<Bonus>();

	private int offlineSeconds;

	private List<KeyValuePair<string, int>> soldiersDic = new List<KeyValuePair<string, int>>();

	private List<KeyValuePair<string, int>> materialDic = new List<KeyValuePair<string, int>>();

	private List<KeyValuePair<string, int>> equipmentDic = new List<KeyValuePair<string, int>>();

	private List<KeyValuePair<string, int>> _shipCollectBonus = new List<KeyValuePair<string, int>>();

	private UI_earningsPanels earningsPanels;

	private UI_giftsPanels giftsPanels;

	private List<string> textureList = new List<string>();

	private int moneyInr = 0;

	private const string GvGMode3OfflineBonusTime = "GVG_MODE3_OFFLINE_BONUS_TIME";

	private List<string> _fullItems = new List<string>();

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://47lbpgx9xibgg".Replace("ui://", ""), ((GObject)title).id, PageController.selectedIndex);
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9xibgg";
	}

	public static UI_ShowOfflineEarnings CreateInstance()
	{
		return (UI_ShowOfflineEarnings)(object)UIPackage.CreateObject("Tips", "ShowOfflineEarnings");
	}

	public static UI_ShowOfflineEarnings CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShowOfflineEarnings).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9xibgg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		OfflineEarningWindow = (GImage)((GComponent)this).GetChild("OfflineEarningWindow");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9xibgg".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		OfflineTime = (GTextField)((GComponent)this).GetChild("OfflineTime");
		string id2 = "ui://47lbpgx9xibgg".Replace("ui://", "") + "-" + ((GObject)OfflineTime).id;
		((GObject)OfflineTime).text = LanguagesManager.GetDesc(id2);
		confirmBtn = (GButton)((GComponent)this).GetChild("confirmBtn");
		earningsList = (GList)((GComponent)this).GetChild("earningsList");
		giftsList = (GList)((GComponent)this).GetChild("giftsList");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id3 = "ui://47lbpgx9xibgg".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id3);
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		GvGMode3Title = (GTextField)((GComponent)this).GetChild("GvGMode3Title");
		string id4 = "ui://47lbpgx9xibgg".Replace("ui://", "") + "-" + ((GObject)GvGMode3Title).id;
		((GObject)GvGMode3Title).text = LanguagesManager.GetDesc(id4);
		GvGMode3OfflineTime = (GTextField)((GComponent)this).GetChild("GvGMode3OfflineTime");
		GvGMode3CollectBonus = (UI_com_GvGMode3CollectBonus)(object)((GComponent)this).GetChild("GvGMode3CollectBonus");
		GvGMode3Tip = (GTextField)((GComponent)this).GetChild("GvGMode3Tip");
		string id5 = "ui://47lbpgx9xibgg".Replace("ui://", "") + "-" + ((GObject)GvGMode3Tip).id;
		((GObject)GvGMode3Tip).text = LanguagesManager.GetDesc(id5);
		earningGroup = (GGroup)((GComponent)this).GetChild("earningGroup");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n43 = (GGraph)((GComponent)this).GetChild("n43");
		guideName = (GTextField)((GComponent)this).GetChild("guideName");
		string id6 = "ui://47lbpgx9xibgg".Replace("ui://", "") + "-" + ((GObject)guideName).id;
		((GObject)guideName).text = LanguagesManager.GetDesc(id6);
		LeftGroup = (GGroup)((GComponent)this).GetChild("LeftGroup");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		corner = (GImage)((GComponent)this).GetChild("corner");
		npcWords = (GTextField)((GComponent)this).GetChild("npcWords");
		guideNpcGroup = (GGroup)((GComponent)this).GetChild("guideNpcGroup");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		openSfxBack = (GGraph)((GComponent)this).GetChild("openSfxBack");
		BoxGroup = (GGroup)((GComponent)this).GetChild("BoxGroup");
		GiftPanel = (UI_GiftPanel)(object)((GComponent)this).GetChild("GiftPanel");
		Tab0 = (UI_btn_OfflineBonusTab)(object)((GComponent)this).GetChild("Tab0");
		Tab3 = (UI_btn_OfflineBonusTab)(object)((GComponent)this).GetChild("Tab3");
		showUp = ((GComponent)this).GetTransition("showUp");
		ShowGiftPanel = ((GComponent)this).GetTransition("ShowGiftPanel");
		TabClick = ((GComponent)this).GetTransition("TabClick");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)LeftGroup).alpha = 0f;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 998;
		if (!parameters.ContainsKey("Bonus"))
		{
			Debug.LogWarning((object)"未包含离线收益Bonus");
			End();
		}
		else
		{
			bonusList.Clear();
			bonusList = (List<Bonus>)parameters["Bonus"];
		}
		UI_btn_OfflineBonusTab tab = Tab0;
		bool visible = (((GObject)Tab3).visible = Define.GvGMode3UnderDevelopment());
		((GObject)tab).visible = visible;
		if (parameters.TryGetValue("Status", out var value))
		{
			PageController.selectedIndex = (int)value;
		}
		else
		{
			PageController.selectedIndex = 0;
		}
		SetControllerPageText();
		if (!parameters.ContainsKey("Time"))
		{
			((GObject)OfflineTime).visible = false;
			Debug.LogWarning((object)"未包含离线生产时间");
		}
		else
		{
			offlineSeconds = (int)parameters["Time"];
			((GObject)OfflineTime).visible = true;
			if (PageController.selectedIndex == 0)
			{
				int num = Mathf.RoundToInt(GameManagers.Instance.UserArchiveManager.GetOfflineYieldTimeLimit() * 60f * 60f);
				if (offlineSeconds < num)
				{
					((GObject)OfflineTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText591") + " [color=#7CFC00]" + UiHelper.ParseTime(offlineSeconds) + "[/color]/" + LanguagesManager.GetDesc("CsharpCodeZhTcText592") + " " + UiHelper.ParseTime(num);
				}
				else
				{
					offlineSeconds = num;
					((GObject)OfflineTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText591") + " [color=#7CFC00]" + UiHelper.ParseTime(offlineSeconds) + "[/color]/" + LanguagesManager.GetDesc("CsharpCodeZhTcText592") + " " + UiHelper.ParseTime(num);
				}
			}
			else
			{
				((GObject)OfflineTime).text = LanguagesManager.GetDesc("CsharpCodeZhTcText593") + " [color=#7CFC00]" + UiHelper.ParseTime(offlineSeconds) + "[/color]";
			}
		}
		if (parameters.TryGetValue("Title", out var value2))
		{
			if (PageController.selectedIndex == 2)
			{
				((GObject)GiftPanel.title).text = value2.ToString();
			}
			else
			{
				((GObject)title).text = value2.ToString();
			}
		}
		if (parameters.TryGetValue("ConfirmAction", out var value3))
		{
			_extraConfirmAction = (Action)value3;
		}
		if (parameters.TryGetValue("ExitButtonVisible", out var value4))
		{
			((GObject)GiftPanel.exitBtn).visible = (bool)value4;
		}
		GetEarningsData();
		CheckStock();
		if (PageController.selectedIndex == 2)
		{
			int num2 = bonusList.FindIndex((Bonus x) => x.ItemId == "Money");
			if (num2 > 0)
			{
				Bonus item = bonusList[num2];
				bonusList.RemoveAt(num2);
				bonusList.Insert(0, item);
			}
			RenderGiftList(bonusList.Count);
		}
		else
		{
			RenderSoldierList(soldiersDic.Count);
			RenderMaterialList(materialDic.Count);
		}
		RenderGvGMode3CollectBonus();
		ThinkingDataHelper.Instance.OffReward(offlineSeconds, moneyInr);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		((GObject)exitBtn).onClick.Add(new EventCallback0(ExitBtnClick));
		((GObject)GiftPanel.exitBtn).onClick.Add(new EventCallback0(ExitBtnClick));
		((GObject)confirmBtn).onClick.Add(new EventCallback0(ConfirmBtnClick));
		((GObject)GiftPanel.confirmBtn).onClick.Add(new EventCallback0(ConfirmBtnClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		((GObject)exitBtn).onClick.Remove(new EventCallback0(ExitBtnClick));
		((GObject)GiftPanel.exitBtn).onClick.Remove(new EventCallback0(ExitBtnClick));
		((GObject)confirmBtn).onClick.Remove(new EventCallback0(ConfirmBtnClick));
		((GObject)GiftPanel.confirmBtn).onClick.Remove(new EventCallback0(ConfirmBtnClick));
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
		if (PageController.selectedIndex == 2)
		{
			PlayOpenSfx();
		}
	}

	private void ExitBtnClick()
	{
		End();
	}

	private void ConfirmBtnClick()
	{
		if (PageController.selectedIndex == 2)
		{
			foreach (Bonus bonus in bonusList)
			{
				if (bonus.ItemId.IndexOf("Unlock.") >= 0)
				{
					CommandFactory.CreateTakeItemsCommand(new List<Bonus> { bonus });
				}
				else if (bonus.ItemId.IndexOf("PotentialLevel.") >= 0)
				{
					CommandFactory.CreateTakeItemsCommand(new List<Bonus> { bonus });
				}
			}
		}
		End();
		_extraConfirmAction?.Invoke();
	}

	private void PlayOpenSfx()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		float duration = 0f;
		((GObject)shiningSfxBack).y = 450f;
		((GObject)openSfxBack).y = 250f;
		((GComponent)(object)this).SetTimeout(duration).OnComplete((GTweenCallback)delegate
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			AdvancedBox.playing = true;
			AdvancedBox.SetPlaySettings(0, -1, 1, -1);
			UiAudioManager.Instance.PlaySoundEffect("OpenBox");
			((GObject)AdvancedBox).TweenFade(((GObject)AdvancedBox).alpha, 0.33f).OnComplete((GTweenCallback)delegate
			{
				//IL_003a: Unknown result type (might be due to invalid IL or missing references)
				AdvancedBox.playing = false;
				AdvancedBox.frame = 2;
				FGUIManager.Instance.AddTextSpecialEffects(openSfxBack, "treasure_open", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureOpen)
				{
					treasureOpen.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
				});
			});
			((GObject)AdvancedBox).TweenFade(((GObject)AdvancedBox).alpha, 0.6f).OnComplete((GTweenCallback)delegate
			{
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				//IL_0066: Unknown result type (might be due to invalid IL or missing references)
				//IL_0070: Expected O, but got Unknown
				FGUIManager.Instance.AddTextSpecialEffects(shiningSfxBack, "treasure_shining", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureOpen)
				{
					UiAudioManager.Instance.LoadSoundsForSfx(treasureOpen, "BoxFlashing", playLoop: true);
				});
				((GComponent)(object)this).SetTimeout(0.25f).OnComplete((GTweenCallback)delegate
				{
					ShowGiftPanel.Play();
				});
			});
		});
	}

	private void End()
	{
		FGUIManager.Instance.MainCityUiTouchable = true;
		if (FGUIManager.Instance.MaincityUi != null)
		{
			((GObject)FGUIManager.Instance.MaincityUi).touchable = FGUIManager.Instance.MainCityUiTouchable;
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		UI_main_FirstTopupPopPanel.TryShow();
	}

	private void GetEarningsData()
	{
		earningsPanels = ((GComponent)earningsList).GetChildAt(0) as UI_earningsPanels;
		giftsPanels = ((GComponent)GiftPanel.giftsList).GetChildAt(0) as UI_giftsPanels;
		soldiersDic.Clear();
		materialDic.Clear();
		_shipCollectBonus.Clear();
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (bonusList[i].ItemId.Contains("BattlePass_Score") || bonusList[i].ItemId.Contains("MoonBattlePassGeneralScore"))
			{
				continue;
			}
			if (bonusList[i].ItemId == "Money")
			{
				KeyValuePair<string, int> item = new KeyValuePair<string, int>(bonusList[i].ItemId, bonusList[i].Qty);
				materialDic.Insert(0, item);
				continue;
			}
			KeyValuePair<string, int> item2 = new KeyValuePair<string, int>(bonusList[i].ItemId, bonusList[i].Qty);
			switch (bonusList[i].Category)
			{
			case 1:
				soldiersDic.Add(item2);
				break;
			case 0:
				if (Item.ItemType(item2.Key) == 31)
				{
					_shipCollectBonus.Add(item2);
				}
				else
				{
					materialDic.Add(item2);
				}
				break;
			case 5:
				equipmentDic.Add(item2);
				break;
			}
		}
		foreach (KeyValuePair<string, int> item3 in equipmentDic)
		{
			materialDic.Add(item3);
		}
		string desc = LanguagesManager.GetDesc("CsharpCodeOfflineRewardDes", returnKey: false);
		if (!string.IsNullOrEmpty(desc))
		{
			((GObject)npcWords).text = desc;
			return;
		}
		((GObject)npcWords).text = LanguagesManager.GetDesc("CsharpCodeZhTcText34") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText594") + "！" + LanguagesManager.GetDesc("CsharpCodeZhTcText595") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText596") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText597") + "！";
	}

	private void CheckStock()
	{
		((GObject)tip).text = "";
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (GameManagers.Instance.StockController.GetStock(bonusList[i].ItemId) < GameManagers.Instance.StockController.GetLimit(bonusList[i].ItemId))
			{
				if (i == bonusList.Count - 1)
				{
					((GObject)tip).text = "";
				}
				continue;
			}
			((GObject)tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText590");
			break;
		}
		((GObject)earningsPanels.separatedLine).visible = soldiersDic.Count != 0;
	}

	private void SoldierListItemRender(int index, GObject obj)
	{
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldiersDic[index].Key);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		((GComponent)asButton).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		UiHelper.LoadSoldierIconFrameMaterial(((GComponent)asButton).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
		((GObject)((GComponent)asButton).GetChild("num").asTextField).text = $"x{soldiersDic[index].Value}";
		string text = "title";
		if (soldier.PotentialLevel >= 8)
		{
			text = "title_Max";
			((GComponent)asButton).GetController("Level").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Level").selectedIndex = 0;
		}
		((GObject)((GComponent)asButton).GetChild(text).asTextField).text = soldier.Name;
		((GComponent)asButton).GetChild(text).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(soldier.PotentialLevel));
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)asButton).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
		if (GameManagers.Instance.StockController.GetStock(soldiersDic[index].Key) >= GameManagers.Instance.StockController.GetLimit(soldiersDic[index].Key))
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(soldier.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void RenderSoldierList(int num)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		earningsPanels.soldierList.itemRenderer = new ListItemRenderer(SoldierListItemRender);
		earningsPanels.soldierList.numItems = num;
		earningsPanels.soldierList.ResizeToFit(num);
	}

	private void MaterialListItemRender(int index, GObject obj)
	{
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string itemId = materialDic[index].Key;
		if (itemId == "Money")
		{
			moneyInr = materialDic[index].Value;
		}
		int num = Item.Level(GameManagers.Instance, itemId);
		int num2 = ((Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : num);
		num2 = ((num2 > 0) ? num2 : Item.Rarity(itemId));
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(materialDic[index].Key);
		((GComponent)asButton).GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, num2);
		((GObject)((GComponent)asButton).GetChild("num").asTextField).text = $"x{materialDic[index].Value}";
		((GObject)((GComponent)asButton).GetChild("title").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("title").asTextField.color = Color32.op_Implicit(UiHelper.GetColorByItemLevel(num2));
		if (GameManagers.Instance.StockController.GetStock(materialDic[index].Key) >= GameManagers.Instance.StockController.GetLimit(materialDic[index].Key))
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void GiftListItemRender(int index, GObject obj)
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		GComponent asCom = ((GComponent)obj.asButton).GetChild("Content").asCom;
		Bonus bonus = bonusList[index];
		string itemId = bonus.ItemId;
		FGUIManager.Instance.SetItemIconAndFrame(asCom.GetChild("icon").asLoader, itemId);
		FGUIManager.Instance.CutItemIdPrefix(itemId, out var prefix);
		if (prefix == "Unlock" || prefix == "PotentialLevel")
		{
			asCom.GetChild("num").text = "";
		}
		else
		{
			asCom.GetChild("num").text = $"x{bonus.Qty}";
		}
		asCom.GetChild("title").text = SchemaIndexHelper.GetNameById(GameManagers.Instance, FGUIManager.Instance.CutItemIdPrefix(itemId, out var _));
		((GObject)asCom.GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(FGUIManager.Instance.CutItemIdPrefix(itemId, out var _), ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void RenderGiftList(int num)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		giftsPanels.materialList.itemRenderer = new ListItemRenderer(GiftListItemRender);
		giftsPanels.materialList.numItems = num;
		giftsPanels.materialList.ResizeToFit(num);
	}

	private void RenderMaterialList(int num)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		earningsPanels.materialList.itemRenderer = new ListItemRenderer(MaterialListItemRender);
		earningsPanels.materialList.numItems = num;
		earningsPanels.materialList.ResizeToFit(num);
	}

	private void RenderGvGMode3CollectBonus()
	{
		if (_shipCollectBonus == null || _shipCollectBonus.Count <= 0)
		{
			UI_btn_OfflineBonusTab tab = Tab0;
			bool visible = (((GObject)Tab3).visible = false);
			((GObject)tab).visible = visible;
			return;
		}
		GvGMode3OfflineBonusModel gvGMode3OfflineBonusInfo = FGUIManager.Instance.GvGMode3OfflineBonusInfo;
		if (gvGMode3OfflineBonusInfo.FullItemId != null)
		{
			_fullItems = new List<string>(gvGMode3OfflineBonusInfo.FullItemId);
		}
		((GObject)GvGMode3OfflineTime).text = string.Format("GVG_MODE3_OFFLINE_BONUS_TIME".ToLanguage(), new object[1] { "[color=#7CFC00]" + UiHelper.ParseTime(gvGMode3OfflineBonusInfo.GvGFetchGapTime) + "[/color]" });
		RenderGvGMode3MaterialList();
		((GObject)GvGMode3Tip).visible = _fullItems.Count > 0;
	}

	private void RenderGvGMode3MaterialList()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		GvGMode3CollectBonus.materialList.itemRenderer = new ListItemRenderer(ShipCollectBonusItemRender);
		GvGMode3CollectBonus.materialList.numItems = _shipCollectBonus.Count;
		GvGMode3CollectBonus.materialList.ResizeToFit(_shipCollectBonus.Count);
	}

	private void ShipCollectBonusItemRender(int index, GObject obj)
	{
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string itemId = _shipCollectBonus[index].Key;
		int num = Item.Level(GameManagers.Instance, itemId);
		int num2 = ((Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : num);
		num2 = ((num2 > 0) ? num2 : Item.Rarity(itemId));
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(_shipCollectBonus[index].Key);
		((GComponent)asButton).GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, num2);
		((GObject)((GComponent)asButton).GetChild("num").asTextField).text = $"x{_shipCollectBonus[index].Value}";
		((GObject)((GComponent)asButton).GetChild("title").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("title").asTextField.color = Color32.op_Implicit(UiHelper.GetColorByItemLevel(num2));
		((GComponent)asButton).GetController("Status").selectedIndex = (_fullItems.Contains(_shipCollectBonus[index].Key) ? 1 : 0);
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}
}
