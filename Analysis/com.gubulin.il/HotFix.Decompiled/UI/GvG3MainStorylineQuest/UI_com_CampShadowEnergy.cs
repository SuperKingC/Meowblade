using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using ILRuntime_LitJson;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Shift.Legion.Helpers;
using UI.Tips;
using UnityEngine;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_CampShadowEnergy : GComponent, IFairyComponent
{
	private struct Effect
	{
		public string ItemId { get; set; }

		public int ItemCount { get; set; }
	}

	private class I63131Effect
	{
		[JsonIgnore]
		private List<Effect> _keyValuePairs;

		public Dictionary<string, int> Rewards { get; set; } = new Dictionary<string, int>();

		[JsonIgnore]
		public List<Effect> DisplayRewards
		{
			get
			{
				if (_keyValuePairs != null)
				{
					return _keyValuePairs;
				}
				List<Effect> list = new List<Effect>();
				foreach (KeyValuePair<string, int> reward in Rewards)
				{
					string oldItemId = reward.Key;
					FGUIManager.Instance.ItemIdReplace(ref oldItemId);
					list.Add(new Effect
					{
						ItemId = oldItemId,
						ItemCount = reward.Value
					});
				}
				_keyValuePairs = list;
				return _keyValuePairs;
			}
		}

		public Dictionary<string, int> SubmitBonus(int offsetMultiple)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (KeyValuePair<string, int> reward in Rewards)
			{
				string oldItemId = reward.Key;
				FGUIManager.Instance.ItemIdReplace(ref oldItemId);
				dictionary.Add(oldItemId, reward.Value * offsetMultiple);
			}
			return dictionary;
		}

		public void ShowBonusTip(int offsetMultiple)
		{
			foreach (Effect displayReward in DisplayRewards)
			{
				ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, displayReward.ItemId)}+{displayReward.ItemCount * offsetMultiple}");
			}
		}
	}

	public Controller Camp;

	public Controller Type;

	public Controller BuffLevelUp;

	public GImage n0;

	public GImage n45;

	public GImage n46;

	public GLoader n1;

	public GLoader n2;

	public GTextField CampName;

	public GTextField n5;

	public GTextField n7;

	public GList CampBuff;

	public GImage n47;

	public GTextField n39;

	public UI_com_Ability CurBuff;

	public UI_com_Ability NextBuff;

	public UI_com_Ability NewBuff;

	public UI_com_Ability LockBuff;

	public UI_com_EnergyBar Step2Bar;

	public GTextField n49;

	public GTextField n50;

	public GTextField Step2EnergyProgress;

	public GTextField n38;

	public GTextField n59;

	public GTextField ShadowStoneNumber;

	public GTextField n58;

	public GGroup n43;

	public GLoader TicketIcon;

	public GTextField ShadowStoneCnt;

	public UI_btn_Submit Submit;

	public GTextField n53;

	public GImage n54;

	public UI_com_EnergyTotalBar Step1Bar;

	public GTextField Step1EnergyProgress;

	public UI_com_SubmitShadowEnergyBonusPreview BonusPreview;

	public const string URL = "ui://249h3k3dzit42r";

	public static string Name = "UI_com_CampShadowEnergy";

	private static readonly Lazy<I63131Effect> _stoneEffect = new Lazy<I63131Effect>(delegate
	{
		Dictionary<string, int> rewards = JsonHelper.ToObject<Dictionary<string, int>>(GDMgr.Get<GDEItemData>("I63131").Effect);
		return new I63131Effect
		{
			Rewards = rewards
		};
	});

	private const string _I63131 = "I63131";

	private int _selfShadowStoneCount;

	private bool Activated => Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed;

	public static string GetURL()
	{
		return "ui://249h3k3dzit42r";
	}

	public static UI_com_CampShadowEnergy CreateInstance()
	{
		return (UI_com_CampShadowEnergy)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_CampShadowEnergy");
	}

	public static UI_com_CampShadowEnergy CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampShadowEnergy).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dzit42r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected O, but got Unknown
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		Type = ((GComponent)this).GetController("Type");
		BuffLevelUp = ((GComponent)this).GetController("BuffLevelUp");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		CampName = (GTextField)((GComponent)this).GetChild("CampName");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		CampBuff = (GList)((GComponent)this).GetChild("CampBuff");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id3 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id3);
		CurBuff = (UI_com_Ability)(object)((GComponent)this).GetChild("CurBuff");
		NextBuff = (UI_com_Ability)(object)((GComponent)this).GetChild("NextBuff");
		NewBuff = (UI_com_Ability)(object)((GComponent)this).GetChild("NewBuff");
		LockBuff = (UI_com_Ability)(object)((GComponent)this).GetChild("LockBuff");
		Step2Bar = (UI_com_EnergyBar)(object)((GComponent)this).GetChild("Step2Bar");
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id4 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id4);
		n50 = (GTextField)((GComponent)this).GetChild("n50");
		string id5 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n50).id;
		((GObject)n50).text = LanguagesManager.GetDesc(id5);
		Step2EnergyProgress = (GTextField)((GComponent)this).GetChild("Step2EnergyProgress");
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id6 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id6);
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id7 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id7);
		ShadowStoneNumber = (GTextField)((GComponent)this).GetChild("ShadowStoneNumber");
		n58 = (GTextField)((GComponent)this).GetChild("n58");
		string id8 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n58).id;
		((GObject)n58).text = LanguagesManager.GetDesc(id8);
		n43 = (GGroup)((GComponent)this).GetChild("n43");
		TicketIcon = (GLoader)((GComponent)this).GetChild("TicketIcon");
		ShadowStoneCnt = (GTextField)((GComponent)this).GetChild("ShadowStoneCnt");
		Submit = (UI_btn_Submit)(object)((GComponent)this).GetChild("Submit");
		n53 = (GTextField)((GComponent)this).GetChild("n53");
		string id9 = "ui://249h3k3dzit42r".Replace("ui://", "") + "-" + ((GObject)n53).id;
		((GObject)n53).text = LanguagesManager.GetDesc(id9);
		n54 = (GImage)((GComponent)this).GetChild("n54");
		Step1Bar = (UI_com_EnergyTotalBar)(object)((GComponent)this).GetChild("Step1Bar");
		Step1EnergyProgress = (GTextField)((GComponent)this).GetChild("Step1EnergyProgress");
		BonusPreview = (UI_com_SubmitShadowEnergyBonusPreview)(object)((GComponent)this).GetChild("BonusPreview");
	}

	public void Destroy()
	{
	}

	public void Init()
	{
		TicketIcon.InitMaterialIntroductionBtn("I63131");
	}

	public void RegisterUiEvent()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnFinalProgressInfoChange = (Action)Delegate.Combine(instance.OnFinalProgressInfoChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnCampProgressChange = (Action)Delegate.Combine(instance2.OnCampProgressChange, new Action(Render));
		SharedMessenger.AddListener("ON_GVG3_ETERNALNIGHT_TRANSITION_PLAYED", Render);
		((GObject)Submit).onClick.Set(new EventCallback0(SubmitStone));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnFinalProgressInfoChange = (Action)Delegate.Remove(instance.OnFinalProgressInfoChange, new Action(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.OnCampProgressChange = (Action)Delegate.Remove(instance2.OnCampProgressChange, new Action(Render));
		SharedMessenger.RemoveListener("ON_GVG3_ETERNALNIGHT_TRANSITION_PLAYED", Render);
		((GObject)Submit).onClick.Clear();
	}

	public void Render()
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		if (!Activated)
		{
			return;
		}
		C2S_GetFinalProgressInfo.Response finalInfo = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo;
		Camp.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		DisplayShadowStone();
		Type.selectedIndex = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep - 1;
		UpdateUiStep1();
		if (Type.selectedIndex != 1)
		{
			return;
		}
		if (finalInfo.PlayerBuff != null)
		{
			CampBuff.itemRenderer = new ListItemRenderer(RenderMyBuff);
			CampBuff.numItems = finalInfo.PlayerBuff.Count;
		}
		GvG3FlagShipMissionModel eternalNightMission = Singleton<GvG3FlagShipMissionsManager>.Instance.GetEternalNightMission();
		if (eternalNightMission == null)
		{
			((GObject)ShadowStoneNumber).text = finalInfo.CampShadowEnergy.ShortNumberFormat();
			BuffLevelUp.selectedIndex = 2;
			return;
		}
		int collectShadowEnergy = eternalNightMission.Data.CollectShadowEnergy;
		int num = (int)eternalNightMission.CheckValues[0];
		int num2 = num - collectShadowEnergy;
		int num3 = (int)finalInfo.CampShadowEnergy - num2;
		((GObject)Step2EnergyProgress).text = num3.ShortNumberFormat() + "/" + collectShadowEnergy.ShortNumberFormat();
		((GProgressBar)Step2Bar).value = (double)num3 / (double)collectShadowEnergy * 100.0;
		ItemAbility itemAbility = Singleton<GvG3FlagShipMissionsManager>.Instance.ChangeCampBuffLevel(eternalNightMission.ChangeCampBuffLevel);
		if (itemAbility != null)
		{
			bool flag = itemAbility.AbilityLevel <= 1;
			BuffLevelUp.selectedIndex = (flag ? 1 : 0);
			string text = (itemAbility.Icon = itemAbility.AbilityData.Icon.ToPublicResourcesRgbIcon());
			string url = text;
			if (flag)
			{
				((GObject)NewBuff.LvNum).text = $"LV{itemAbility.AbilityLevel}";
				NewBuff.icon.GetChild("Icon").asLoader.url = url;
				((GObject)LockBuff.LvNum).text = $"LV{itemAbility.AbilityLevel}";
				LockBuff.icon.GetChild("Icon").asLoader.url = url;
				((GObject)NewBuff).data = itemAbility;
				((GObject)NewBuff).onClick.Set(new EventCallback1(OnAbilityItemClick));
			}
			else
			{
				((GObject)CurBuff.LvNum).text = $"LV{itemAbility.AbilityLevel - 1}";
				((GObject)NextBuff.LvNum).text = $"LV{itemAbility.AbilityLevel}";
				CurBuff.icon.GetChild("Icon").asLoader.url = url;
				NextBuff.icon.GetChild("Icon").asLoader.url = url;
				((GObject)CurBuff).data = itemAbility;
				((GObject)NextBuff).data = itemAbility;
				((GObject)CurBuff).onClick.Set(new EventCallback1(OnAbilityItemClick));
				((GObject)NextBuff).onClick.Set(new EventCallback1(OnAbilityItemClick));
			}
		}
		void DisplayShadowStone()
		{
			Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(delegate
			{
				_selfShadowStoneCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount("I63131");
				((GObject)ShadowStoneCnt).text = _selfShadowStoneCount.ShortNumberFormat();
				DisplaySubmitStoneBonusPreview(_selfShadowStoneCount);
			});
		}
		void RenderMyBuff(int index, GObject obj)
		{
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			if (obj is UI_com_Ability uI_com_Ability)
			{
				ItemAbility itemAbility2 = (ItemAbility)(((GObject)uI_com_Ability).data = finalInfo.PlayerBuff[index].ItemAbility);
				((GObject)uI_com_Ability.LvNum).text = $"LV{itemAbility2.AbilityLevel}";
				GLoader asLoader = uI_com_Ability.icon.GetChild("Icon").asLoader;
				string url2 = (itemAbility2.Icon = itemAbility2.AbilityData.Icon.ToPublicResourcesRgbIcon());
				asLoader.url = url2;
				((GObject)uI_com_Ability).onClick.Set(new EventCallback1(OnAbilityItemClick));
			}
		}
	}

	private void DisplaySubmitStoneBonusPreview(int stoneCount = 0)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		((GObject)BonusPreview).visible = stoneCount > 0;
		List<Effect> bonus;
		if (((GObject)BonusPreview).visible)
		{
			bonus = _stoneEffect.Value.DisplayRewards;
			BonusPreview.Bonus.itemRenderer = new ListItemRenderer(RenderBonus);
			BonusPreview.Bonus.numItems = bonus.Count;
		}
		void RenderBonus(int index, GObject obj)
		{
			if (obj is UI_com_SubmitShadowEnergyBonus uI_com_SubmitShadowEnergyBonus)
			{
				Effect effect = bonus[index];
				uI_com_SubmitShadowEnergyBonus.Icon.url = UiHelper.GetIcon(effect.ItemId).ToPublicResourceIcon();
				((GObject)uI_com_SubmitShadowEnergyBonus.BonusCount).text = (effect.ItemCount * stoneCount).ShortNumberFormat();
			}
		}
	}

	private void UpdateUiStep1()
	{
		if (Type.selectedIndex == 0)
		{
			CampMainMissionUiModel eternalNightMainMission = Singleton<GvG3FlagShipMissionsManager>.Instance.EternalNightMainMission;
			long num = eternalNightMainMission.MainMission.CheckValues[0];
			long campShadowEnergy = Singleton<GvG3FlagShipMissionsManager>.Instance.FinalProgressInfo.CampShadowEnergy;
			((GProgressBar)Step1Bar).value = (double)campShadowEnergy / (double)num * 100.0;
			((GObject)Step1EnergyProgress).text = ((int)campShadowEnergy).ShortNumberFormat() + "/" + ((int)num).ShortNumberFormat();
		}
	}

	private static void OnAbilityItemClick(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject val = (GObject)context.sender;
		if (val.data is ItemAbility itemAbility)
		{
			Vector2 val2 = default(Vector2);
			((Vector2)(ref val2))._002Ector(960f, 680f);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
			{
				{ "Pos", val2 },
				{ "Data", itemAbility.AbilityData },
				{ "Limit", 0 },
				{ "State", true },
				{ "GList", null },
				{ "SkillIconUrl", itemAbility.Icon },
				{ "Level", itemAbility.AbilityLevel }
			});
		}
	}

	private void SubmitStone()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.SubmitShadowEnergy(UpdateUi, _stoneEffect.Value.SubmitBonus(_selfShadowStoneCount));
		void UpdateUi(int stone)
		{
			_stoneEffect.Value.ShowBonusTip(_selfShadowStoneCount);
			_selfShadowStoneCount = 0;
			((GObject)ShadowStoneCnt).text = _selfShadowStoneCount.ToString();
			DisplaySubmitStoneBonusPreview(_selfShadowStoneCount);
			Singleton<GvG3FlagShipMissionsManager>.Instance.UpdateSelfShadowStoneCount(0);
			Singleton<GvG3FlagShipMissionsManager>.Instance.GetMissions();
			Singleton<GvG3FlagShipMissionsManager>.Instance.GetFinalProgressRank();
			Singleton<GvG3FlagShipMissionsManager>.Instance.GetFinalProgressInfoOnSubmitStone();
			UpdateUiStep1();
		}
	}
}
