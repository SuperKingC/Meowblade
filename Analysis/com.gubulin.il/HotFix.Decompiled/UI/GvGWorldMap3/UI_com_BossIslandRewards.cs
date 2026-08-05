using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGWorldMap3;

public class UI_com_BossIslandRewards : GComponent
{
	public GImage n13;

	public GList Rewards;

	public GImage n8;

	public GTextField n9;

	public UI_com_BossIslandDisplayReward Medal;

	public GLoader CheckLeaderboardRewards;

	public const string URL = "ui://4eq8fgd2c6jrs6u";

	public static string Name = "UI_com_BossIslandRewards";

	private const string DisplayRewardsKey = "GvG3BossIslandDisplayRewards";

	public static string GetURL()
	{
		return "ui://4eq8fgd2c6jrs6u";
	}

	public static UI_com_BossIslandRewards CreateInstance()
	{
		return (UI_com_BossIslandRewards)(object)UIPackage.CreateObject("GvGWorldMap3", "com_BossIslandRewards");
	}

	public static UI_com_BossIslandRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BossIslandRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2c6jrs6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Rewards = (GList)((GComponent)this).GetChild("Rewards");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://4eq8fgd2c6jrs6u".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
		Medal = (UI_com_BossIslandDisplayReward)(object)((GComponent)this).GetChild("Medal");
		CheckLeaderboardRewards = (GLoader)((GComponent)this).GetChild("CheckLeaderboardRewards");
	}

	public void OnLoad()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)CheckLeaderboardRewards).onClick.Add(new EventCallback0(CheckLeaderboardRewardsOnclick));
	}

	public void OnClose()
	{
		((GObject)CheckLeaderboardRewards).onClick.Clear();
	}

	public void OnRender()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		List<KeyValuePair<string, string>> displayRewards = "GvG3BossIslandDisplayRewards".ToConfiguration<Dictionary<string, string>>().ToList();
		KeyValuePair<string, string> medal = RemoveMedal();
		RenderMedal(medal);
		Rewards.itemRenderer = new ListItemRenderer(Render);
		Rewards.numItems = displayRewards.Count;
		KeyValuePair<string, string> RemoveMedal()
		{
			int num = -1;
			foreach (KeyValuePair<string, string> item in displayRewards)
			{
				if (Item.ItemType(item.Key) == 105)
				{
					num = displayRewards.IndexOf(item);
				}
			}
			if (num == -1)
			{
				throw new Exception("UI_com_BossIslandRewards.OnRender:Medal Reward is non-existent");
			}
			KeyValuePair<string, string> keyValuePair = displayRewards[num];
			displayRewards.Remove(keyValuePair);
			return keyValuePair;
		}
		void Render(int index, GObject obj)
		{
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			if (!(obj is UI_com_BossIslandDisplayReward uI_com_BossIslandDisplayReward))
			{
				throw new Exception("UI_com_BossIslandRewards.OnRender.Render: rewardUi is not UI_com_BossIslandDisplayReward");
			}
			KeyValuePair<string, string> reward = displayRewards[index];
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_BossIslandDisplayReward.Icon, reward.Key);
			((GObject)uI_com_BossIslandDisplayReward.Count).text = reward.Value;
			((GObject)uI_com_BossIslandDisplayReward).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(reward.Key, 1, noCheckBtn: true);
			});
		}
		void RenderMedal(KeyValuePair<string, string> keyValuePair)
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			GvGMedalConfig gvGMedalConfig = new GvGMedalConfig(keyValuePair.Key);
			Medal.Icon.url = gvGMedalConfig.BigIcon;
			((GObject)Medal.Count).text = keyValuePair.Value;
			((GObject)Medal).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(keyValuePair.Key, 1, noCheckBtn: true);
			});
		}
	}

	private void CheckLeaderboardRewardsOnclick()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LeaderboardRewards.Name, new Dictionary<string, object> { 
		{
			"LeaderboardType",
			eLeaderboardType.BOSS单日最高输出榜_全副本
		} });
	}
}
