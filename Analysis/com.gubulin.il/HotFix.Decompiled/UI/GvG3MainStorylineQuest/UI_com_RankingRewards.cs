using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.Tips;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_RankingRewards : GComponent, IFairyComponent
{
	public Controller Progress;

	public Controller Status;

	public Controller Rank;

	public GImage n4;

	public GImage n23;

	public GImage n24;

	public GImage n0;

	public GTextField n2;

	public UI_btn_RewardDetail RewardDetail;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public GTextField n8;

	public UI_com_CampRank RankInCompetition;

	public GList Rewards;

	public GImage n10;

	public GImage n12;

	public UI_btn_Receive Receive;

	public UI_com_CampStep MyCamp;

	public GTextField n16;

	public GTextField n15;

	public GTextField n18;

	public GTextField n19;

	public GTextField n20;

	public GGroup n21;

	public UI_com_CampRank MyRank;

	public GList CampRank;

	public GImage n25;

	public GTextField n27;

	public const string URL = "ui://249h3k3dsuqe16";

	public static string Name = "UI_com_RankingRewards";

	private bool Activated => !Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed && !Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNightProgress;

	public static string GetURL()
	{
		return "ui://249h3k3dsuqe16";
	}

	public static UI_com_RankingRewards CreateInstance()
	{
		return (UI_com_RankingRewards)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_RankingRewards");
	}

	public static UI_com_RankingRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RankingRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dsuqe16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected O, but got Unknown
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Expected O, but got Unknown
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Progress = ((GComponent)this).GetController("Progress");
		Status = ((GComponent)this).GetController("Status");
		Rank = ((GComponent)this).GetController("Rank");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		RewardDetail = (UI_btn_RewardDetail)(object)((GComponent)this).GetChild("RewardDetail");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id4 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id4);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id5 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id5);
		RankInCompetition = (UI_com_CampRank)(object)((GComponent)this).GetChild("RankInCompetition");
		Rewards = (GList)((GComponent)this).GetChild("Rewards");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		Receive = (UI_btn_Receive)(object)((GComponent)this).GetChild("Receive");
		MyCamp = (UI_com_CampStep)(object)((GComponent)this).GetChild("MyCamp");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id6 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id6);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id7 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id7);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id8 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id8);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id9 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id9);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id10 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id10);
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		MyRank = (UI_com_CampRank)(object)((GComponent)this).GetChild("MyRank");
		CampRank = (GList)((GComponent)this).GetChild("CampRank");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id11 = "ui://249h3k3dsuqe16".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id11);
	}

	public void Destroy()
	{
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Receive).onClick.Set(new EventCallback0(ClaimMainMissionRankReward));
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderCampMainProgressRankReward = (Action<CampRankReward>)Delegate.Combine(instance.RenderCampMainProgressRankReward, new Action<CampRankReward>(Render));
	}

	public void UnregisterUiEvent()
	{
		((GObject)Receive).onClick.Clear();
		((GObject)RewardDetail).onClick.Clear();
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderCampMainProgressRankReward = (Action<CampRankReward>)Delegate.Remove(instance.RenderCampMainProgressRankReward, new Action<CampRankReward>(Render));
	}

	private void Render(CampRankReward rewardData)
	{
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		if (!Activated)
		{
			return;
		}
		Progress.selectedIndex = rewardData.CampProgress - 1;
		GvG3FlagShipMissionsConfigHelper.MainMissionBonusByRank.TryGetValue(rewardData.CampProgress.ToString(), out var value);
		int myCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		CampMainProgress campMainProgress = rewardData.MainProgress.Find((CampMainProgress p) => p != null && p.CampId == myCampId);
		int num = 0;
		if (campMainProgress.Rank <= 0)
		{
			int num2 = 0;
			foreach (CampMainProgress item in rewardData.MainProgress)
			{
				if (item != null && item.Rank > 0 && item.Rank > num2)
				{
					num2 = item.Rank;
				}
			}
			Status.selectedIndex = 0;
			num = num2;
			ShowCampsProgress();
		}
		else
		{
			MyRank.Rank.selectedIndex = campMainProgress.Rank - 1;
			Status.selectedIndex = ((!rewardData.SelfClaimCampRankReward) ? 1 : 2);
			num = campMainProgress.Rank - 1;
			MyCamp.Camp.selectedIndex = myCampId;
			MyCamp.IsMe.selectedIndex = 1;
			MyCamp.InCompetition.selectedIndex = 2;
		}
		if (value != null)
		{
			Dictionary<string, int> config = value[(num + 1).ToString()];
			ShowRankingBonus(config, num);
		}
		((GObject)RewardDetail).onClick.Set(new EventCallback0(ShowMainMissionCampBonus));
		void ShowCampsProgress()
		{
			for (int i = 0; i < CampRank.numItems; i++)
			{
				if (((GComponent)CampRank).GetChildAt(i) is UI_com_CampStep uI_com_CampStep)
				{
					CampMainProgress campMainProgress2 = ((rewardData.MainProgress.Count >= i + 1) ? rewardData.MainProgress[i] : null);
					if (campMainProgress2 == null)
					{
						uI_com_CampStep.IsMe.selectedIndex = 0;
						uI_com_CampStep.InCompetition.selectedIndex = 2;
					}
					else
					{
						bool flag = myCampId == campMainProgress2.CampId;
						uI_com_CampStep.IsMe.selectedIndex = (flag ? 1 : 0);
						bool flag2 = campMainProgress2.Rank <= 0;
						uI_com_CampStep.InCompetition.selectedIndex = (flag2 ? 1 : 0);
						if (flag2)
						{
							int num3 = campMainProgress2.Step - 1;
							uI_com_CampStep.CurrentStep.selectedIndex = num3;
							if (((GComponent)uI_com_CampStep.CurrentStep).GetChildAt(num3) is UI_btn_StepRank uI_btn_StepRank)
							{
								((GButton)uI_btn_StepRank).selected = true;
								uI_btn_StepRank.IsMe.selectedIndex = (flag ? 1 : 0);
							}
						}
						else
						{
							uI_com_CampStep.Rank.Rank.selectedIndex = campMainProgress2.Rank - 1;
						}
					}
				}
			}
		}
		void ShowMainMissionCampBonus()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_MainMissionCampBonus.Name, new Dictionary<string, object> { { "CampProgress", rewardData.CampProgress } });
		}
		void ShowRankingBonus(Dictionary<string, int> dictionary, int currentRank)
		{
			RankInCompetition.Rank.selectedIndex = currentRank;
			Rank.selectedIndex = currentRank;
			Rewards.RemoveChildrenToPool();
			foreach (KeyValuePair<string, int> item2 in dictionary)
			{
				GObject val = Rewards.AddItemFromPool();
				if (val is UI_com_Bonus uI_com_Bonus)
				{
					((GObject)uI_com_Bonus.Count).text = item2.Value.ToString();
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_Bonus.ItemIcon, item2.Key);
					uI_com_Bonus.ItemIcon.InitMaterialIntroductionBtn(item2.Key);
				}
			}
		}
	}

	private void ClaimMainMissionRankReward()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.ClaimMainMissionRankReward();
	}
}
