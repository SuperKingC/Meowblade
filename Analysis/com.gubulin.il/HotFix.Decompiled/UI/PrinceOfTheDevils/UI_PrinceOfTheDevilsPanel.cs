using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.AddCredit;
using UI.Dungeons;
using UI.MainCity;
using UI.PublicResources;
using UI.WorldMap;
using UnityEngine;

namespace UI.PrinceOfTheDevils;

public class UI_PrinceOfTheDevilsPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__43_0;

		internal void _003CGetData_003Eb__43_0()
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
		}
	}

	public UI_dec_bg bg;

	public GButton backBtn;

	public GComponent addDiamondBtn;

	public UI_LeftContent LeftContent;

	public UI_Title Title;

	public GImage n17;

	public GImage n38;

	public GGroup crack;

	public UI_RightContent RightContent;

	public UI_RightTopContent RightTopContent;

	public UI_RightBottomContent RightBottomContent;

	public GGraph AimAchievementListTop;

	public GGraph AimAchievementListBottom;

	public GGraph ProgressBarSfxBack;

	public const string URL = "ui://zko5n3vemxsj0";

	public static string Name = "UI_PrinceOfTheDevilsPanel";

	private List<string> textureList = new List<string>();

	private int selectedAimIndex;

	private List<GButton> aimBtnList = new List<GButton>();

	private List<string> aimLogoKeyList = new List<string>();

	private List<Achievement> curAimAchievementList = new List<Achievement>();

	public IUiController uiParent;

	private List<UI_targetBtn> AchievementList = new List<UI_targetBtn>();

	private List<Achievement> PendingToClaimList = new List<Achievement>();

	private List<Achievement> OngoingList = new List<Achievement>();

	private List<Achievement> ClaimedList = new List<Achievement>();

	private Dictionary<int, List<Achievement>> hideAchievements = new Dictionary<int, List<Achievement>>();

	public UI_ProductionNumFloating NumFloating;

	private IUiController parent;

	private GTweener ProgressBarSfxBack_Tween;

	private List<GTweener> sub_tween;

	private const string DevilGradeKey = "魔王等级";

	private const string DungeonScaleKey = "地城规模";

	private const string LegionScaleKey = "军团规模";

	private const string ManorScaleKey = "领地规模";

	private const string PYXKey = "死亡圣器";

	private const string TreasureKey = "远古宝物";

	public static string GetURL()
	{
		return "ui://zko5n3vemxsj0";
	}

	public static UI_PrinceOfTheDevilsPanel CreateInstance()
	{
		return (UI_PrinceOfTheDevilsPanel)(object)UIPackage.CreateObject("PrinceOfTheDevils", "PrinceOfTheDevilsPanel");
	}

	public static UI_PrinceOfTheDevilsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PrinceOfTheDevilsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3vemxsj0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bg = (UI_dec_bg)(object)((GComponent)this).GetChild("bg");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		LeftContent = (UI_LeftContent)(object)((GComponent)this).GetChild("LeftContent");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		crack = (GGroup)((GComponent)this).GetChild("crack");
		RightContent = (UI_RightContent)(object)((GComponent)this).GetChild("RightContent");
		RightTopContent = (UI_RightTopContent)(object)((GComponent)this).GetChild("RightTopContent");
		RightBottomContent = (UI_RightBottomContent)(object)((GComponent)this).GetChild("RightBottomContent");
		AimAchievementListTop = (GGraph)((GComponent)this).GetChild("AimAchievementListTop");
		AimAchievementListBottom = (GGraph)((GComponent)this).GetChild("AimAchievementListBottom");
		ProgressBarSfxBack = (GGraph)((GComponent)this).GetChild("ProgressBarSfxBack");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 103;
		if (parameters.TryGetValue("Parent", out var value))
		{
			parent = (IUiController)value;
		}
		GetData(parameters);
		SetBuildingName();
		UpdateDiamondNum();
		SetTextShadow();
		UpdateAimTitle(init: true);
		UpdateAchievenments(curAimAchievementList.Count);
		FGUIManager.Instance.AddTextSpecialEffects(bg.FXWrapper, "ui_devilRuby_smoke", Vector3.one * 100f);
	}

	public void RegisterUiEventListeners()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondAddClick));
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)RightTopContent.BigPrize).onClick.Add(new EventCallback1(GetBigPrize));
		((GComponent)RightContent.AchievementList).scrollPane.onScroll.Add(new EventCallback0(HiddenSFX));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondAddClick));
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)RightTopContent.BigPrize).onClick.Remove(new EventCallback1(GetBigPrize));
		((GComponent)RightContent.AchievementList).scrollPane.onScroll.Remove(new EventCallback0(HiddenSFX));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<Cache_PrinceRedDot>(Cache_PrinceRedDot.ON_PAGE_REDDOT_CHANGE, OnPageRedDotChange);
	}

	public void OnShow()
	{
		HiddenSFX();
		if (NumFloating != null)
		{
			Object.Destroy((Object)(object)((GObject)NumFloating).displayObject.gameObject);
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building15_Click");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		if (parent != null && parent is UI_MainCity)
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = GameManagers.Instance.BuildingManager.GetBuildingByType("15").Name;
	}

	private void HiddenSFX()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val2 = default(Vector2);
		for (int i = 0; i < AchievementList.Count; i++)
		{
			Vector2 val = ((GObject)AchievementList[i]).LocalToRoot(Vector2.zero, GRoot.inst);
			((Vector2)(ref val2))._002Ector(0f, 2f);
			if (!((GComponent)AchievementList[i]).GetChild("fxBack").displayObject.isDisposed)
			{
				if (val.y < ((GObject)AimAchievementListTop).y + val2.y || val.y > ((GObject)AimAchievementListBottom).y - ((GObject)AchievementList[i]).height + val2.y)
				{
					((GComponent)AchievementList[i]).GetChild("fxBack").displayObject.visible = false;
				}
				else
				{
					((GComponent)AchievementList[i]).GetChild("fxBack").displayObject.visible = true;
				}
			}
		}
	}

	private void RenderAchievementListItem(int index, UI_targetBtn button)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		AchievementStatus achievementStatus = curAimAchievementList[index].Status(GameManagers.Instance);
		((GComponent)button).GetChild("title").text = curAimAchievementList[index].Desc ?? "";
		((GObject)((GComponent)button).GetChild("num").asTextField).text = $"{curAimAchievementList[index].CurrentValue(GameManagers.Instance)}/{curAimAchievementList[index].TargetValue}";
		switch (achievementStatus)
		{
		case AchievementStatus.Ongoing:
			((GComponent)button).GetChild("num").asTextField.color = Color32.op_Implicit(new Color32((byte)196, (byte)29, (byte)25, byte.MaxValue));
			((GComponent)button).GetChild("receiveBtn").enabled = false;
			break;
		case AchievementStatus.PendingToClaim:
			((GComponent)button).GetChild("num").asTextField.color = Color32.op_Implicit(new Color32((byte)23, (byte)137, (byte)20, byte.MaxValue));
			((GComponent)button).GetChild("receiveBtn").enabled = true;
			break;
		case AchievementStatus.Claimed:
			((GComponent)button).GetChild("num").asTextField.color = Color32.op_Implicit(new Color32((byte)23, (byte)137, (byte)20, byte.MaxValue));
			((GComponent)button).GetChild("receiveBtn").enabled = true;
			break;
		}
		button.isClaimed.SetSelectedIndex((achievementStatus == AchievementStatus.Claimed) ? 1 : 0);
		if (curAimAchievementList[index].Bonuses != null && curAimAchievementList[index].Bonuses.Count > 0)
		{
			((GObject)((GComponent)button).GetChild("rewardNum").asTextField).text = $"{curAimAchievementList[index].Bonuses[0].Qty}";
			Bonus bonus = curAimAchievementList[index].Bonuses[0];
			string itemId = bonus.ItemId;
			((GComponent)button).GetChild("rewardIcon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			((GComponent)button).GetChild("rewardIcon").onClick.Set((EventCallback0)delegate
			{
				UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
			if (bonus.IsShining == 2 && achievementStatus != AchievementStatus.Claimed)
			{
				((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)button).GetChild("fxBack").asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
			}
			else
			{
				((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
			}
			((GObject)((GComponent)button).GetChild("receiveBtn").asButton).data = index;
			((GObject)((GComponent)button).GetChild("receiveBtn").asButton).onClick.Set(new EventCallback1(GetReward));
		}
	}

	private void UpdateParentRedpoint()
	{
		if (uiParent != null)
		{
			if (uiParent is UI_WorldMapPanel)
			{
				((UI_WorldMapPanel)uiParent).SetTitleRedPoint();
			}
			else if (uiParent is UI_DungeonsPanel)
			{
				((UI_DungeonsPanel)uiParent).SetTitleRedPoint();
			}
		}
	}

	private void GetData(Dictionary<string, object> parameters)
	{
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		if (parameters != null)
		{
			if (parameters.TryGetValue("Parent", out var value))
			{
				uiParent = (IUiController)value;
			}
			if (parameters.TryGetValue("Index", out var value2))
			{
				num = (int)value2;
			}
		}
		((GObject)LeftContent.devilGrade).data = AchievementCat.Lord;
		aimLogoKeyList.Add("魔王等级");
		aimBtnList.Add((GButton)(object)LeftContent.devilGrade);
		aimBtnList[0].title = LanguagesManager.GetDesc("CsharpCodeZhTcText112");
		((GObject)LeftContent.dungeonScale).data = AchievementCat.Dungeon;
		aimLogoKeyList.Add("地城规模");
		aimBtnList.Add((GButton)(object)LeftContent.dungeonScale);
		aimBtnList[1].title = LanguagesManager.GetDesc("CsharpCodeZhTcText447");
		((GObject)LeftContent.legionScale).data = AchievementCat.Legion;
		aimLogoKeyList.Add("军团规模");
		aimBtnList.Add((GButton)(object)LeftContent.legionScale);
		aimBtnList[2].title = LanguagesManager.GetDesc("CsharpCodeZhTcText448");
		((GObject)LeftContent.manorScale).data = AchievementCat.Region;
		aimLogoKeyList.Add("领地规模");
		aimBtnList.Add((GButton)(object)LeftContent.manorScale);
		aimBtnList[3].title = LanguagesManager.GetDesc("CsharpCodeZhTcText449");
		((GObject)LeftContent.pyx).data = AchievementCat.Technology;
		aimLogoKeyList.Add("死亡圣器");
		aimBtnList.Add((GButton)(object)LeftContent.pyx);
		aimBtnList[4].title = LanguagesManager.GetDesc("CsharpCodeZhTcText450");
		((GObject)LeftContent.treasure).data = AchievementCat.Item;
		aimLogoKeyList.Add("远古宝物");
		aimBtnList.Add((GButton)(object)LeftContent.treasure);
		aimBtnList[5].title = LanguagesManager.GetDesc("CsharpCodeZhTcText451");
		for (int i = 0; i < aimBtnList.Count; i++)
		{
			List<Achievement> achievementsByCategory = AchievementManager.GetAchievementsByCategory((AchievementCat)((GObject)aimBtnList[i]).data);
			if (achievementsByCategory.Count > 0)
			{
				((GObject)aimBtnList[i]).onClick.Add(new EventCallback1(SetSelectedAimIndex));
			}
			else
			{
				EventListener onClick = ((GObject)aimBtnList[i]).onClick;
				object obj = _003C_003Ec._003C_003E9__43_0;
				if (obj == null)
				{
					EventCallback0 val = delegate
					{
						List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
						SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
					};
					_003C_003Ec._003C_003E9__43_0 = val;
					obj = (object)val;
				}
				onClick.Set((EventCallback0)obj);
			}
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)aimBtnList[i]).GetChild("SfxBack").asGraph, "rubby_light", new Vector3(100f, 100f, 100f));
		}
		UpdateRedPointStatus();
		selectedAimIndex = num;
		((GComponent)aimBtnList[selectedAimIndex]).GetChild("highlight").visible = true;
		AimAchievementListSort();
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
	}

	private void AimAchievementListSort()
	{
		List<Achievement> achievementsByCategory = AchievementManager.GetAchievementsByCategory((AchievementCat)((GObject)aimBtnList[selectedAimIndex]).data);
		curAimAchievementList.Clear();
		PendingToClaimList.Clear();
		OngoingList.Clear();
		ClaimedList.Clear();
		hideAchievements.Clear();
		for (int i = 0; i < achievementsByCategory.Count; i++)
		{
			AchievementStatus achievementStatus = achievementsByCategory[i].Status(GameManagers.Instance);
			if (achievementStatus == AchievementStatus.Claimed)
			{
				ClaimedList.Add(achievementsByCategory[i]);
				continue;
			}
			List<Achievement> list = new List<Achievement>();
			list.AddRange(PendingToClaimList);
			list.AddRange(OngoingList);
			if (list.Count <= 0)
			{
				switch (achievementStatus)
				{
				case AchievementStatus.PendingToClaim:
					PendingToClaimList.Add(achievementsByCategory[i]);
					break;
				case AchievementStatus.Ongoing:
					OngoingList.Add(achievementsByCategory[i]);
					break;
				}
				continue;
			}
			for (int j = 0; j < list.Count && (list[j].Type != achievementsByCategory[i].Type || achievementsByCategory[i].Type == AchievementType.LegendItemSetVariety); j++)
			{
				if (j == list.Count - 1)
				{
					switch (achievementStatus)
					{
					case AchievementStatus.PendingToClaim:
						PendingToClaimList.Add(achievementsByCategory[i]);
						break;
					case AchievementStatus.Ongoing:
						OngoingList.Add(achievementsByCategory[i]);
						break;
					}
				}
			}
		}
		curAimAchievementList.AddRange(PendingToClaimList);
		curAimAchievementList.AddRange(OngoingList);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void UpdateRedPointStatus()
	{
		if (!((GObject)this).isDisposed)
		{
			Cache_PrinceRedDot cache_PrinceRedDot = CacheManager.Instance.Get<Cache_PrinceRedDot>();
			((GComponent)LeftContent.dungeonScale).GetChild("redPoint").visible = cache_PrinceRedDot.HasPageRedDot(AchievementCat.Dungeon);
			((GComponent)LeftContent.manorScale).GetChild("redPoint").visible = cache_PrinceRedDot.HasPageRedDot(AchievementCat.Region);
			((GComponent)LeftContent.treasure).GetChild("redPoint").visible = cache_PrinceRedDot.HasPageRedDot(AchievementCat.Item);
			((GComponent)LeftContent.legionScale).GetChild("redPoint").visible = cache_PrinceRedDot.HasPageRedDot(AchievementCat.Legion);
			((GComponent)LeftContent.devilGrade).GetChild("redPoint").visible = cache_PrinceRedDot.HasPageRedDot(AchievementCat.Lord);
			((GComponent)LeftContent.pyx).GetChild("redPoint").visible = cache_PrinceRedDot.HasPageRedDot(AchievementCat.Technology);
		}
	}

	public void UpdateDiamondNum()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Gem");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ToString();
		addDiamondBtn.GetChild("num").data = stock;
	}

	private void SetTextShadow()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		addDiamondBtn.GetChild("num").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
	}

	private void RenderMainAchievementNode(Achievement achievement, UI_IntegralNode achievementUi)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		UI_nodeBtn nodeBtn = achievementUi.nodeBtn;
		GButton asButton = ((GComponent)nodeBtn).GetChild("middleIcon").asButton;
		Controller status = nodeBtn.Status;
		AchievementStatus achievementStatus = achievement.Status(GameManagers.Instance);
		if (achievementStatus == AchievementStatus.Claimed)
		{
			achievementUi.BonusStatus.selectedIndex = 0;
			status.selectedIndex = 0;
		}
		else if (achievementStatus == AchievementStatus.PendingToClaim && (float)ClaimedList.Count >= achievement.TargetValue)
		{
			achievementUi.BonusStatus.selectedIndex = 1;
			status.selectedIndex = 1;
			FGUIManager.Instance.AddTextSpecialEffects(nodeBtn.sfxBack, "stroke_card_trail_square", Vector3.one * 56f);
		}
		else
		{
			achievementUi.BonusStatus.selectedIndex = 2;
			status.selectedIndex = 2;
		}
		((GObject)achievementUi.AchievementCount).text = $"{achievement.TargetValue:0}";
		if (achievement.Bonuses != null && achievement.Bonuses.Count > 0)
		{
			((GComponent)asButton).GetChild("num").text = $"{achievement.Bonuses[0].Qty}";
			Bonus bonus = achievement.Bonuses[0];
			string itemId = bonus.ItemId;
			((GComponent)asButton).GetChild("leftIcon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			if (bonus.IsShining == 2 && achievementStatus != AchievementStatus.Claimed)
			{
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)asButton).GetChild("SfxBack").asGraph, "activated_fx", new Vector3(75f, 75f, 75f));
			}
			else
			{
				((GObject)((GComponent)asButton).GetChild("SfxBack").asGraph).displayObject.Dispose();
			}
		}
		((GObject)achievementUi).data = achievement;
		((GObject)achievementUi).onClick.Set(new EventCallback1(GetMainAchievementNodeReward));
	}

	private void GetMainAchievementNodeReward(EventContext eventContext)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		Achievement mainAchievement = (Achievement)((GObject)eventContext.sender).data;
		switch (mainAchievement.Status(GameManagers.Instance))
		{
		case AchievementStatus.Claimed:
			break;
		default:
			if (!((float)ClaimedList.Count < mainAchievement.TargetValue))
			{
				UI_IntegralNode achievementUi = (UI_IntegralNode)(object)eventContext.sender;
				ILRequestHelper<AchievementClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().AchievementClaim(mainAchievement.AchievementId), delegate(AchievementClaimResponse response)
				{
					if (!response.Result)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
					else if (mainAchievement.ClaimBonus(GameManagers.Instance))
					{
						ThinkingDataHelper.Instance.GetAchievementTrack(mainAchievement.AchievementId);
						RenderMainAchievementNode(mainAchievement, achievementUi);
					}
				});
				break;
			}
			goto case AchievementStatus.Ongoing;
		case AchievementStatus.Ongoing:
		{
			List<string> arg = new List<string> { string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText452"), Convert.ToInt32(mainAchievement.TargetValue)) };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			break;
		}
		}
	}

	private void UpdateAimTitle(bool init = false, bool achievedSummaryAchievement = true)
	{
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		if (!achievedSummaryAchievement)
		{
			UpdateProgressText();
			return;
		}
		((GObject)RightTopContent.UnderWayProgress).visible = false;
		List<Achievement> achievementSummary = AchievementManager.GetAchievementSummary((AchievementCat)((GObject)aimBtnList[selectedAimIndex]).data);
		Achievement achievement = achievementSummary.Last();
		if (achievement != null)
		{
			AchievementStatus achievementStatus = achievement.Status(GameManagers.Instance);
			switch (achievementStatus)
			{
			case AchievementStatus.PendingToClaim:
			{
				((GObject)RightTopContent.BigPrize).touchable = true;
				for (int i = 0; i < curAimAchievementList.Count; i++)
				{
					if (curAimAchievementList[i].Status(GameManagers.Instance) != AchievementStatus.Claimed)
					{
						((GObject)RightTopContent.BigPrize.redPoint).visible = false;
						((GObject)RightTopContent.BigPrize).touchable = true;
						((GObject)RightTopContent.BigPrize).grayed = false;
						break;
					}
				}
				RightTopContent.BigPrize.claimStatus.SetSelectedIndex(1);
				break;
			}
			case AchievementStatus.Ongoing:
				((GObject)RightTopContent.BigPrize).touchable = true;
				RightTopContent.BigPrize.claimStatus.SetSelectedIndex(2);
				break;
			case AchievementStatus.Claimed:
				((GObject)RightTopContent.BigPrize).touchable = false;
				RightTopContent.BigPrize.claimStatus.SetSelectedIndex(0);
				break;
			}
			if (achievement.Bonuses != null && achievement.Bonuses.Count > 0)
			{
				((GObject)RightTopContent.BigPrize.rewardNum).text = $"x{achievement.Bonuses[0].Qty}";
				Bonus bonus = achievement.Bonuses[0];
				if (bonus.IsShining == 2 && achievementStatus != AchievementStatus.Claimed)
				{
					((GObject)RightTopContent.BigPrize.fxBack).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(RightTopContent.BigPrize.fxBack, "activated_fx", new Vector3(75f, 75f, 75f));
				}
				else
				{
					((GObject)RightTopContent.BigPrize.fxBack).displayObject.Dispose();
				}
			}
		}
		else
		{
			((GObject)RightTopContent.BigPrize.redPoint).visible = false;
			((GObject)RightTopContent.BigPrize).touchable = false;
			((GObject)RightTopContent.BigPrize).grayed = true;
		}
		bool displayUnderWay = RenderProgressUnderWay(achievementSummary);
		for (int j = 0; j < achievementSummary.Count && j <= 2 && j < achievementSummary.Count - 1; j++)
		{
			RenderMainAchievementNode(achievementSummary[j], (UI_IntegralNode)(object)((GComponent)RightTopContent).GetChild($"node{j}"));
		}
		RightTopContent.aimLogoBtn.aimIcon.url = "ui://PublicResources/rubby_devil_" + aimLogoKeyList[selectedAimIndex];
		UpdateProgressText();
		if (!init)
		{
			((GObject)RightTopContent.Progress.textSFXBack).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(RightTopContent.Progress.textSFXBack, FGUIManager.Instance.uiGreen, Vector3.zero);
		}
		else
		{
			((GObject)RightTopContent.Progress.progressBar).asProgress.value = 0.0;
		}
		double num = CalcDisplayClaimedCount(achievementSummary);
		double num2 = achievementSummary.Count;
		((GProgressBar)RightTopContent.Progress.progressBar).TweenValue(num / num2 * 100.0, 0.22f).OnComplete((GTweenCallback)delegate
		{
			((GObject)RightTopContent.UnderWayProgress).visible = displayUnderWay;
			((GObject)ProgressBarSfxBack).relations.ClearAll();
		});
	}

	private void UpdateProgressText()
	{
		int count = AchievementManager.GetAchievementsByCategory((AchievementCat)((GObject)aimBtnList[selectedAimIndex]).data).Count;
		((GObject)RightTopContent.Progress.num).text = $"{ClaimedList.Count}/{count}";
	}

	private int CalcDisplayClaimedCount(List<Achievement> achievements)
	{
		int num = 0;
		int count = ClaimedList.Count;
		foreach (Achievement achievement in achievements)
		{
			float targetValue = achievement.TargetValue;
			if ((float)count >= targetValue)
			{
				num++;
			}
		}
		return num;
	}

	private bool RenderProgressUnderWay(List<Achievement> achievements)
	{
		if (!CalcUnderWayNodeIndex(achievements, out var underWayIndex))
		{
			return false;
		}
		if (underWayIndex < 0)
		{
			((GObject)RightTopContent.UnderWayProgress).x = 267f;
			return true;
		}
		for (int i = 0; i < achievements.Count; i++)
		{
			if (underWayIndex == i)
			{
				GObject child = ((GComponent)RightTopContent).GetChild($"node{i}");
				((GObject)RightTopContent.UnderWayProgress).x = child.x;
				break;
			}
		}
		return true;
	}

	private bool CalcUnderWayNodeIndex(List<Achievement> achievements, out int underWayIndex)
	{
		underWayIndex = -1;
		if (achievements == null)
		{
			return false;
		}
		int count = ClaimedList.Count;
		if ((float)count >= achievements.Last().TargetValue)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < achievements.Count; i++)
		{
			float targetValue = achievements[i].TargetValue;
			if ((float)count < targetValue)
			{
				num = i;
				break;
			}
		}
		underWayIndex = num - 1;
		return true;
	}

	private void RenderAchievementList()
	{
		((GObject)RightContent.AchievementList).touchable = false;
		for (int i = 0; i < AchievementList.Count; i++)
		{
			if (i > curAimAchievementList.Count - 1)
			{
				UI_targetBtn uI_targetBtn = AchievementList[i];
				AchievementList.RemoveAt(i);
				((GComponent)GRoot.inst).RemoveChild((GObject)(object)uI_targetBtn);
				((GObject)uI_targetBtn).Dispose();
				break;
			}
			((GObject)AchievementList[i]).SetXY(0f, (float)i * 149f);
			RenderAchievementListItem(i, AchievementList[i]);
		}
		((GObject)RightContent.AchievementList).touchable = true;
	}

	private void UpdateAchievenments(int num)
	{
		for (int num2 = AchievementList.Count - 1; num2 >= 0; num2--)
		{
			UI_targetBtn uI_targetBtn = AchievementList[num2];
			AchievementList.RemoveAt(num2);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)uI_targetBtn);
			((GObject)uI_targetBtn).Dispose();
		}
		for (int i = 0; i < num; i++)
		{
			UI_targetBtn uI_targetBtn2 = UI_targetBtn.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)uI_targetBtn2);
			((GComponent)RightContent.AchievementList).AddChild((GObject)(object)uI_targetBtn2);
			((GObject)uI_targetBtn2).SetXY(0f, (float)i * 149f);
			AchievementList.Add(uI_targetBtn2);
			RenderAchievementListItem(i, uI_targetBtn2);
		}
		for (int j = 0; j < AchievementList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)AchievementList[j]).AddRelation((GObject)(object)AchievementList[j - 1], (RelationType)9);
			}
			else
			{
				((GObject)AchievementList[j]).relations.ClearAll();
			}
		}
	}

	private void PlayProgressBarSfx(GButton button, bool achievedSummaryAchievement = false)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		Vector2 val = ((GObject)button).LocalToGlobal(Vector2.one / 2f);
		val = ((GObject)this).GlobalToLocal(val);
		((GObject)ProgressBarSfxBack).SetXY(val.x, val.y);
		FGUIManager.Instance.AddTextSpecialEffects(ProgressBarSfxBack, "exp_missile_green", Vector3.zero);
		Vector2 val2 = ((GObject)RightTopContent.Progress.progressBar.SfxBack).LocalToGlobal(Vector2.one / 2f);
		val2 = ((GObject)this).GlobalToLocal(val2);
		ProgressBarSfxBack_Tween = ((GObject)ProgressBarSfxBack).TweenMove(val2, 0.44f).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
		{
			if (!achievedSummaryAchievement)
			{
				UpdateAimTitle(init: false, achievedSummaryAchievement: false);
			}
			else
			{
				((GObject)ProgressBarSfxBack).AddRelation((GObject)(object)RightTopContent.Progress.progressBar.bar, (RelationType)6);
				UpdateAimTitle();
			}
		});
	}

	private bool stop_tween_and_force_render()
	{
		if (sub_tween == null)
		{
			sub_tween = new List<GTweener>();
		}
		bool result = false;
		for (int num = sub_tween.Count - 1; num >= 0; num--)
		{
			GTweener obj = sub_tween[num];
			if (obj != null && !obj.allCompleted)
			{
				GTweener obj2 = sub_tween[num];
				if (obj2 != null)
				{
					obj2.Kill(false);
				}
				result = true;
			}
			sub_tween.RemoveAt(num);
		}
		GTweener progressBarSfxBack_Tween = ProgressBarSfxBack_Tween;
		if (progressBarSfxBack_Tween != null && !progressBarSfxBack_Tween.allCompleted)
		{
			GTweener progressBarSfxBack_Tween2 = ProgressBarSfxBack_Tween;
			if (progressBarSfxBack_Tween2 != null)
			{
				progressBarSfxBack_Tween2.Kill(false);
			}
			result = true;
		}
		return result;
	}

	private void AchievementClaimed(int index)
	{
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		if (stop_tween_and_force_render())
		{
			RenderAchievementList();
		}
		UI_targetBtn button = AchievementList[index];
		if (!((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.isDisposed)
		{
			((GObject)((GComponent)button).GetChild("fxBack").asGraph).displayObject.Dispose();
		}
		((GObject)button).relations.ClearAll();
		AchievementList.RemoveAt(index);
		AimAchievementListSort();
		bool achievedSummaryAchievement = AchievedSummaryAchievement();
		PlayProgressBarSfx(((GComponent)button).GetChild("receiveBtn").asButton, achievedSummaryAchievement);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)button).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Expected O, but got Unknown
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Expected O, but got Unknown
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Expected O, but got Unknown
			//IL_0234: Expected O, but got Unknown
			for (int i = 0; i < AchievementList.Count; i++)
			{
				((GObject)AchievementList[i]).SetPivot(0.5f, 0.5f);
				((GObject)AchievementList[i]).alpha = 0f;
				((GObject)AchievementList[i]).SetScale(0.25f, 0.25f);
			}
			((GObject)button).SetPivot(0.5f, 0.5f);
			((GObject)button).alpha = 0f;
			((GObject)button).SetScale(0.25f, 0.25f);
			if (curAimAchievementList.Count > 0)
			{
				AchievementList.Insert(0, button);
				((GObject)button).SetXY(0f, 0f);
				RenderAchievementList();
				float num = 0.33f;
				for (int j = 0; j < AchievementList.Count; j++)
				{
					int j2 = j;
					sub_tween.Add(((GComponent)(object)AchievementList[j]).SetTimeout((float)j2 * 0.33f).OnComplete((GTweenCallback)delegate
					{
						//IL_0036: Unknown result type (might be due to invalid IL or missing references)
						sub_tween.Add(((GObject)AchievementList[j2]).TweenScale(new Vector2(1f, 1f), 0.33f));
					}));
					sub_tween.Add(((GComponent)(object)AchievementList[j]).SetTimeout((float)j2 * 0.33f).OnComplete((GTweenCallback)delegate
					{
						sub_tween.Add(((GObject)AchievementList[j2]).TweenFade(1f, 0.33f));
					}));
					num += (float)j2 * 0.33f;
				}
				List<GTweener> list = sub_tween;
				GTweener obj = ((GComponent)(object)this).SetTimeout(num);
				GTweenCallback obj2 = val;
				if (obj2 == null)
				{
					GTweenCallback val2 = delegate
					{
						((GObject)RightContent.AchievementList).touchable = true;
						((GObject)LeftContent).touchable = true;
						HiddenSFX();
					};
					GTweenCallback val3 = val2;
					val = val2;
					obj2 = val3;
				}
				list.Add(obj.OnComplete(obj2));
			}
			else
			{
				((GObject)RightContent.AchievementList).touchable = true;
				((GObject)LeftContent).touchable = true;
				HiddenSFX();
			}
		});
		bool AchievedSummaryAchievement()
		{
			int claimedCount = ClaimedList.Count;
			List<Achievement> achievementSummary = AchievementManager.GetAchievementSummary((AchievementCat)((GObject)aimBtnList[selectedAimIndex]).data);
			return achievementSummary.Any((Achievement a) => Convert.ToInt32(a.TargetValue) == claimedCount);
		}
	}

	private void DiamondAddClick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
			},
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void SetSelectedAimIndex(EventContext context)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GComponent)aimBtnList[selectedAimIndex]).GetChild("highlight").visible = false;
		selectedAimIndex = aimBtnList.IndexOf((GButton)context.sender);
		((GComponent)aimBtnList[selectedAimIndex]).GetChild("highlight").visible = true;
		stop_tween_and_force_render();
		AimAchievementListSort();
		UpdateAimTitle(init: true);
		UpdateAchievenments(curAimAchievementList.Count);
		HiddenSFX();
	}

	private void GetBigPrize(EventContext eventContext)
	{
		Achievement mainAchievement = AchievementManager.GetAchievementSummary((AchievementCat)((GObject)aimBtnList[selectedAimIndex]).data).Last();
		if (mainAchievement.Status(GameManagers.Instance) != AchievementStatus.PendingToClaim)
		{
			if (mainAchievement.Bonuses != null && mainAchievement.Bonuses.Count > 0)
			{
				string itemId = mainAchievement.Bonuses[0].ItemId;
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			}
			return;
		}
		ILRequestHelper<AchievementClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().AchievementClaim(mainAchievement.AchievementId), delegate(AchievementClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (mainAchievement.ClaimBonus(GameManagers.Instance))
			{
				ThinkingDataHelper.Instance.GetAchievementTrack(mainAchievement.AchievementId);
				UpdateAimTitle();
			}
		});
	}

	private void GetReward(EventContext eventContext)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)(GButton)eventContext.sender).data;
		Achievement achievement = curAimAchievementList[index];
		ILRequestHelper<AchievementClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().AchievementClaim(achievement.AchievementId), delegate(AchievementClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (achievement.ClaimBonus(GameManagers.Instance))
			{
				ThinkingDataHelper.Instance.GetAchievementTrack(achievement.AchievementId);
				AchievementClaimed(index);
			}
		});
	}

	private void OnPageRedDotChange(Cache_PrinceRedDot cache)
	{
		UpdateRedPointStatus();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (!(itemId == "Gem"))
		{
			return;
		}
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
		int stock2 = GameManagers.Instance.StockController.GetStock("Gem");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = $"{stock}";
		int num = ((addDiamondBtn.GetChild("num").data != null) ? ((int)addDiamondBtn.GetChild("num").data) : stock2);
		if (num != stock2 && stock2 > num)
		{
			int num2 = stock2 - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, addDiamondBtn, stock2 - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		addDiamondBtn.GetChild("num").data = stock2;
	}
}
