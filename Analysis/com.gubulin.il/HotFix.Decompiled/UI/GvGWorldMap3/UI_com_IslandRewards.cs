using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGWorldMap3;

public class UI_com_IslandRewards : GComponent
{
	public Controller Type;

	public Controller HasExtra;

	public GImage n6;

	public GImage n0;

	public GTextField n1;

	public GTextField n2;

	public GTextField n3;

	public GImage n4;

	public const string URL = "ui://4eq8fgd2h4tpdw";

	public static string Name = "UI_com_IslandRewards";

	private IslandRewardsDisplayModel _rewards;

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpdw";
	}

	public static UI_com_IslandRewards CreateInstance()
	{
		return (UI_com_IslandRewards)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandRewards");
	}

	public static UI_com_IslandRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpdw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		HasExtra = ((GComponent)this).GetController("HasExtra");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2h4tpdw".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://4eq8fgd2h4tpdw".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://4eq8fgd2h4tpdw".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}

	public void OnLoad()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		_rewards = new IslandRewardsDisplayModel();
		_rewards.Clear();
		((GObject)this).onClick.Set(new EventCallback0(OpenDisplayRewardPanel));
	}

	public void OnUnload()
	{
		_rewards.Clear();
		((GObject)this).onClick.Clear();
	}

	public void OnRender(IslandStateModel islandState)
	{
		Dictionary<string, List<IslandDisplayReward>> rewardConfig = WorldMapConfigHelper.GetGvGMode3DisplayRewardConfigs(islandState.IslandId);
		if (rewardConfig == null)
		{
			Type.SetSelectedIndex(0);
			HasExtra.SetSelectedIndex(0);
			ILRuntimeDebug.LogError($"UI_com_IslandRewards.OnRender:IslandId={islandState.IslandId} DisplayRewardConfig is null");
		}
		else
		{
			LoadMainReward();
			LoadRandomEventReward();
		}
		void LoadMainReward()
		{
			IslandDisplayRewardType islandDisplayRewardType = islandState.GetBelongStatus() switch
			{
				eGvGMode3IslandBelongStatus.Neutral => IslandDisplayRewardType.FirstClear, 
				eGvGMode3IslandBelongStatus.OwnSide => IslandDisplayRewardType.Suppress, 
				eGvGMode3IslandBelongStatus.Enemy => IslandDisplayRewardType.Normal, 
				_ => IslandDisplayRewardType.FirstClear, 
			};
			if (rewardConfig.TryGetValue(islandDisplayRewardType.ToString(), out var value))
			{
				_rewards.MainReward = islandDisplayRewardType;
				_rewards.MainRewardList = value;
			}
			((GObject)this).visible = _rewards.Count > 0;
			Type.SetSelectedIndex((int)islandDisplayRewardType);
		}
		void LoadRandomEventReward()
		{
			IIslandEvent islandEvent = islandState.IslandEvents.Find((IIslandEvent e) => e.EventType.IsBattleRandomEvent());
			if (islandEvent == null || islandEvent.EventConfig == null)
			{
				HasExtra.SetSelectedIndex(0);
			}
			else
			{
				HasExtra.SetSelectedIndex(1);
				IslandDisplayRewardType randomEventReward = IslandDisplayRewardType.RandomEvent;
				if (islandEvent.EventType == eIslandEvent.RandomEvent_NPCEvent)
				{
					randomEventReward = IslandDisplayRewardType.RandomEvent_NPC;
				}
				else if (islandEvent.EventType == eIslandEvent.RandomEvent_BossEvent)
				{
					randomEventReward = IslandDisplayRewardType.RandomEvent_Boss;
				}
				_rewards.RandomEventReward = randomEventReward;
				_rewards.RandomEventRewardList = islandEvent.EventConfig.DisplayRewards();
			}
		}
	}

	private void OpenDisplayRewardPanel()
	{
		if (_rewards.Count > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_IslandRewards.Name, new Dictionary<string, object> { { "IslandDisplayRewards", _rewards } });
		}
	}
}
