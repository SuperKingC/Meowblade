using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UnityEngine;

namespace UI.GiftOfLord;

public class UI_main_GiftOfLord : GComponent, IUiController
{
	public GLoader background;

	public GGraph n14;

	public GImage n16;

	public GImage n17;

	public UI_com_ListBackground n10;

	public GList Achievements;

	public GImage n4;

	public GImage n5;

	public GImage n20;

	public GImage n21;

	public GImage n19;

	public GMovieClip n39;

	public GImage n32;

	public UI_com_Desc n12;

	public GImage n15;

	public GImage n7;

	public GMovieClip n28;

	public GMovieClip n29;

	public GMovieClip n30;

	public GMovieClip n31;

	public GImage n22;

	public GImage n23;

	public GImage n24;

	public GImage n25;

	public GImage n26;

	public GImage n27;

	public GGraph FxWrapper;

	public GButton backBtn;

	public UI_Title Title;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://nz2z1ab8t0xz0";

	public static string Name = "UI_main_GiftOfLord";

	private readonly List<Achievement> _achievements = new List<Achievement>();

	private readonly Lazy<List<Achievement>> _allAchievements = new Lazy<List<Achievement>>(() => AchievementManager.GetAchievementsByCategory(AchievementCat.GiftOfLord));

	private const string _UI_GIFT_OF_LORD_SPARKLE = "ui_gift_of_lord_sparkle";

	public static string GetURL()
	{
		return "ui://nz2z1ab8t0xz0";
	}

	public static UI_main_GiftOfLord CreateInstance()
	{
		return (UI_main_GiftOfLord)(object)UIPackage.CreateObject("GiftOfLord", "main_GiftOfLord");
	}

	public static UI_main_GiftOfLord CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GiftOfLord).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xz0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n14 = (GGraph)((GComponent)this).GetChild("n14");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n10 = (UI_com_ListBackground)(object)((GComponent)this).GetChild("n10");
		Achievements = (GList)((GComponent)this).GetChild("Achievements");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n39 = (GMovieClip)((GComponent)this).GetChild("n39");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n12 = (UI_com_Desc)(object)((GComponent)this).GetChild("n12");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n28 = (GMovieClip)((GComponent)this).GetChild("n28");
		n29 = (GMovieClip)((GComponent)this).GetChild("n29");
		n30 = (GMovieClip)((GComponent)this).GetChild("n30");
		n31 = (GMovieClip)((GComponent)this).GetChild("n31");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		FxWrapper = (GGraph)((GComponent)this).GetChild("FxWrapper");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}

	public static void OpenPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, null);
	}

	public void BeforeDestroy()
	{
		if (!((GObject)FxWrapper).displayObject.isDisposed)
		{
			((GObject)FxWrapper).displayObject.Dispose();
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UpdateAchievements();
	}

	public void OnShow()
	{
		DisplayFx();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GObject)backBtn).onClick.Set(new EventCallback0(End));
		Achievements.itemRenderer = new ListItemRenderer(AchievementRenderer);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)backBtn).onClick.Clear();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void UpdateAchievements()
	{
		SortAndFilterAchievements();
		RenderAchievements();
	}

	private void AchievementsAppear(int lastRemoveIndex)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		for (int i = 0; i < ((GComponent)Achievements).numChildren; i++)
		{
			GObject childAt = ((GComponent)Achievements).GetChildAt(i);
			UI_com_AchievementWrapper wrapper = childAt as UI_com_AchievementWrapper;
			if (wrapper != null)
			{
				wrapper.Disappear.Play();
				if (lastRemoveIndex == i)
				{
					((GObject)wrapper.Achievement).x = 0f;
				}
				((GComponent)(object)this).SetTimeout((float)i * 0.1f).OnComplete((GTweenCallback)delegate
				{
					wrapper.Appear.Play();
				});
			}
		}
	}

	private void DisplayFx()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.AddTextSpecialEffects(FxWrapper, "ui_gift_of_lord_sparkle", new Vector3(100f, 100f, 100f));
	}

	private void SortAndFilterAchievements()
	{
		_achievements.Clear();
		List<Achievement> achievements = FilterAchievements();
		IOrderedEnumerable<Achievement> collection = WhereAndOrder(achievements, AchievementStatus.PendingToClaim);
		IOrderedEnumerable<Achievement> collection2 = WhereAndOrder(achievements, AchievementStatus.Ongoing);
		_achievements.AddRange(collection);
		_achievements.AddRange(collection2);
	}

	private List<Achievement> FilterAchievements()
	{
		Dictionary<AchievementType, List<Achievement>> dictionary = new Dictionary<AchievementType, List<Achievement>>();
		foreach (Achievement item in _allAchievements.Value)
		{
			if (dictionary.ContainsKey(item.Type))
			{
				dictionary[item.Type].Add(item);
				continue;
			}
			dictionary[item.Type] = new List<Achievement> { item };
		}
		List<Achievement> list = new List<Achievement>();
		foreach (KeyValuePair<AchievementType, List<Achievement>> item2 in dictionary)
		{
			List<Achievement> achievements = item2.Value.ToList();
			List<Achievement> list2 = WhereAndOrder(achievements, AchievementStatus.PendingToClaim).ToList();
			list2.Sort(TypeGroupAchievementsSort);
			List<Achievement> list3 = WhereAndOrder(achievements, AchievementStatus.Ongoing).ToList();
			list3.Sort(TypeGroupAchievementsSort);
			if (list2.Count > 0)
			{
				list.Add(list2[0]);
			}
			else if (list3.Count > 0)
			{
				list.Add(list3[0]);
			}
		}
		return list;
	}

	private static IOrderedEnumerable<Achievement> WhereAndOrder(List<Achievement> achievements, AchievementStatus status)
	{
		return from a in achievements
			where a.Status(GameManagers.Instance) == status
			orderby a.Type
			select a;
	}

	private int TypeGroupAchievementsSort(Achievement a, Achievement b)
	{
		return (a.TargetValue < b.TargetValue) ? (-1) : ((a.TargetValue > b.TargetValue) ? 1 : 0);
	}

	private void RenderAchievements()
	{
		Achievements.numItems = _achievements.Count;
	}

	private void AchievementRenderer(int index, GObject obj)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		if (!(obj is UI_com_AchievementWrapper { Achievement: var achievement }))
		{
			throw new ArgumentException("UI_main_GiftOfLord.AchievementRenderer obj is not UI_com_AchievementWrapper");
		}
		Achievement achievement2 = _achievements[index];
		achievement.State.SetSelectedIndex((int)achievement2.Status(GameManagers.Instance));
		RenderProgress(achievement, achievement2);
		RenderBonus(achievement, achievement2);
		((GObject)achievement.Receive).data = index;
		((GObject)achievement.Receive).onClick.Set(new EventCallback1(GetReward));
	}

	private static void RenderProgress(UI_com_Achievement ui, Achievement achievement)
	{
		((GObject)ui.Desc).text = achievement.Desc;
		float num = achievement.CurrentValue(GameManagers.Instance);
		float targetValue = achievement.TargetValue;
		string text = ((num >= targetValue) ? "#1f8c15" : "#bf1d1d");
		((GObject)ui.Value).text = "[color=" + text + "]" + achievement.GetProgressCurrentValue() + "[/color]/" + achievement.GetProgressTargetValue();
	}

	private static void RenderBonus(UI_com_Achievement ui, Achievement achievement)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		Bonus bonus = achievement.Bonuses?[0];
		if (bonus != null)
		{
			((GObject)ui.RewardNum).text = $"X{bonus.Qty}";
			ui.RewardIcon.url = UiHelper.GetIcon(bonus.ItemId).ToPublicResourceIcon();
			((GObject)ui.RewardIcon).onClick.Set((EventCallback0)delegate
			{
				bonus.ItemId.DisplayItemTip();
			});
		}
	}

	private void GetReward(EventContext eventContext)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)eventContext.sender).data;
		Achievement achievement = _achievements[index];
		ILRequestHelper<AchievementClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().AchievementClaim(achievement.AchievementId), delegate(AchievementClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (achievement.ClaimBonus(GameManagers.Instance))
			{
				ThinkingDataHelper.Instance.GetAchievementTrack(achievement.AchievementId);
				OnAchievementClaimed(index);
				GameManagers.Instance.AchievementManager.UpdateGiftOfLordEntranceRedDotOnClaimReward(achievement.Type);
			}
		});
	}

	private void OnAchievementClaimed(int index)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		if (!(((GComponent)Achievements).GetChildAt(index) is UI_com_AchievementWrapper uI_com_AchievementWrapper) || ((GObject)uI_com_AchievementWrapper).isDisposed)
		{
			return;
		}
		uI_com_AchievementWrapper.RemoveTrans.Play((PlayCompleteCallback)delegate
		{
			if (!((GObject)this).isDisposed)
			{
				UpdateAchievementsOnClaim(index);
			}
		});
	}

	private void UpdateAchievementsOnClaim(int lastRemoveIndex)
	{
		if (!((GObject)this).isDisposed)
		{
			UpdateAchievements();
			AchievementsAppear(lastRemoveIndex);
		}
	}
}
