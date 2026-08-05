using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_MainMissionStep : GComponent, IFairyComponent
{
	private class JumpEnergyModel
	{
		public int Cur;

		public int Max;
	}

	public Controller Step;

	public Controller Progress;

	public GLoader Icon;

	public GImage n37;

	public GImage n43;

	public GImage n2;

	public UI_dec_01 n44;

	public GImage n50;

	public GImage n45;

	public GImage n46;

	public GList Steps;

	public GImage n4;

	public GLoader n5;

	public GTextField n6;

	public UI_FoodStoreBar Energy;

	public GTextField n10;

	public GTextField n11;

	public GTextField JumpEnergy1;

	public GGroup n27;

	public GTextField Countdown1;

	public GTextField n14;

	public UI_btn_Positioning Positioning;

	public GTextField n16;

	public GTextField n20;

	public GTextField Damage;

	public GTextField n22;

	public GTextField Health;

	public GTextField n24;

	public GTextField EnergyCost;

	public GTextField n26;

	public GTextField TestingMuId;

	public UI_btn_PreviewProgressReward PreviewReward;

	public GTextField n30;

	public GTextField n38;

	public GTextField n35;

	public GTextField n39;

	public GImage n32;

	public GTextField TargetIsland;

	public GGroup n34;

	public GTextField n7;

	public GTextField JumpEnergy0;

	public GGroup n40;

	public GTextField n41;

	public GTextField n42;

	public GTextField n47;

	public GTextField n48;

	public GTextField Countdown2;

	public GTextField n18;

	public GGroup n49;

	public const string URL = "ui://249h3k3dqf7c1e";

	public static string Name = "UI_com_MainMissionStep";

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	public Action CloseMainUi = delegate
	{
	};

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	private bool Activated => !Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNightProgress && !((GObject)this).isDisposed && !Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNightProgress;

	public static string GetURL()
	{
		return "ui://249h3k3dqf7c1e";
	}

	public static UI_com_MainMissionStep CreateInstance()
	{
		return (UI_com_MainMissionStep)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_MainMissionStep");
	}

	public static UI_com_MainMissionStep CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MainMissionStep).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dqf7c1e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected O, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Expected O, but got Unknown
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected O, but got Unknown
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Expected O, but got Unknown
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Expected O, but got Unknown
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Expected O, but got Unknown
		//IL_0766: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Expected O, but got Unknown
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Expected O, but got Unknown
		//IL_087b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0885: Expected O, but got Unknown
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Step = ((GComponent)this).GetController("Step");
		Progress = ((GComponent)this).GetController("Progress");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n44 = (UI_dec_01)(object)((GComponent)this).GetChild("n44");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		Steps = (GList)((GComponent)this).GetChild("Steps");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		Energy = (UI_FoodStoreBar)(object)((GComponent)this).GetChild("Energy");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id3 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id3);
		JumpEnergy1 = (GTextField)((GComponent)this).GetChild("JumpEnergy1");
		n27 = (GGroup)((GComponent)this).GetChild("n27");
		Countdown1 = (GTextField)((GComponent)this).GetChild("Countdown1");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id4 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id4);
		Positioning = (UI_btn_Positioning)(object)((GComponent)this).GetChild("Positioning");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id5 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id5);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id6 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id6);
		Damage = (GTextField)((GComponent)this).GetChild("Damage");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id7 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id7);
		Health = (GTextField)((GComponent)this).GetChild("Health");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id8 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id8);
		EnergyCost = (GTextField)((GComponent)this).GetChild("EnergyCost");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id9 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id9);
		TestingMuId = (GTextField)((GComponent)this).GetChild("TestingMuId");
		PreviewReward = (UI_btn_PreviewProgressReward)(object)((GComponent)this).GetChild("PreviewReward");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id10 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id10);
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id11 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id11);
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id12 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id12);
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id13 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id13);
		n32 = (GImage)((GComponent)this).GetChild("n32");
		TargetIsland = (GTextField)((GComponent)this).GetChild("TargetIsland");
		n34 = (GGroup)((GComponent)this).GetChild("n34");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id14 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id14);
		JumpEnergy0 = (GTextField)((GComponent)this).GetChild("JumpEnergy0");
		n40 = (GGroup)((GComponent)this).GetChild("n40");
		n41 = (GTextField)((GComponent)this).GetChild("n41");
		string id15 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n41).id;
		((GObject)n41).text = LanguagesManager.GetDesc(id15);
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id16 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id16);
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id17 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id17);
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id18 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id18);
		Countdown2 = (GTextField)((GComponent)this).GetChild("Countdown2");
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id19 = "ui://249h3k3dqf7c1e".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id19);
		n49 = (GGroup)((GComponent)this).GetChild("n49");
	}

	public void Destroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderMainMissions = (Action<CampMainMissionUiModel>)Delegate.Combine(instance.RenderMainMissions, new Action<CampMainMissionUiModel>(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.RenderJumpEnergyByAutoGetCampEnergy = (Action<int>)Delegate.Combine(instance2.RenderJumpEnergyByAutoGetCampEnergy, new Action<int>(RenderJumpEnergyByAutoGetCampEnergy));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.RenderMainMissions = (Action<CampMainMissionUiModel>)Delegate.Remove(instance.RenderMainMissions, new Action<CampMainMissionUiModel>(Render));
		GvG3FlagShipMissionsManager instance2 = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance2.RenderJumpEnergyByAutoGetCampEnergy = (Action<int>)Delegate.Remove(instance2.RenderJumpEnergyByAutoGetCampEnergy, new Action<int>(RenderJumpEnergyByAutoGetCampEnergy));
	}

	private void RenderJumpEnergyByAutoGetCampEnergy(int currentValue)
	{
		JumpEnergyModel jumpEnergyModel = (JumpEnergyModel)((GObject)JumpEnergy0).data;
		if (jumpEnergyModel != null)
		{
			jumpEnergyModel.Cur = currentValue;
			((GObject)JumpEnergy0).text = UiHelper.ShortNumberFormat(jumpEnergyModel.Cur, 2) + "/" + UiHelper.ShortNumberFormat(jumpEnergyModel.Max, 2);
			((GProgressBar)Energy).value = (double)jumpEnergyModel.Cur / (double)jumpEnergyModel.Max * 100.0;
		}
	}

	private void Render(CampMainMissionUiModel model)
	{
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		int islandId;
		if (Activated)
		{
			Progress.selectedIndex = model.Progress - 1;
			Step.selectedIndex = model.Step - 1;
			Steps.selectedIndex = Step.selectedIndex;
			islandId = 0;
			GvG3FlagShipMissionModel mainMission = model.MainMission;
			if (Define.GvGMode3UnderTesting)
			{
				((GObject)TestingMuId).text = $"({mainMission.MUid})";
			}
			switch (model.Step)
			{
			case 1:
			{
				long num = ((mainMission.ProgressValue.Count <= 0) ? 0 : mainMission.ProgressValue[0]);
				long num2 = mainMission.CheckValues[0];
				((GObject)JumpEnergy0).text = UiHelper.ShortNumberFormat((int)num, 2) + "/" + UiHelper.ShortNumberFormat((int)num2, 2);
				((GObject)JumpEnergy0).data = new JumpEnergyModel
				{
					Cur = (int)num,
					Max = (int)num2
				};
				((GProgressBar)Energy).value = (double)num / (double)num2 * 100.0;
				break;
			}
			case 3:
				((GObject)EnergyCost).text = UiHelper.ShortNumberFormat(mainMission.ConsumeCampEnergy, 2);
				((GObject)Damage).text = $"GvG3_CannonDamage_Progress_{model.Progress}".ToLanguage();
				((GObject)Health).text = $"GvG3_MoonShield_Progress_{model.Progress}".ToLanguage();
				break;
			case 2:
			case 4:
				((GObject)JumpEnergy1).text = UiHelper.ShortNumberFormat(mainMission.ConsumeCampEnergy, 2);
				islandId = (int)mainMission.CheckValues[0];
				((GObject)TargetIsland).text = WorldMapConfigHelper.Configs.TryGetIsland(islandId).Name;
				break;
			}
			((GObject)Positioning).onClick.Set(new EventCallback0(FocusIsland));
			((GObject)PreviewReward).onClick.Set(new EventCallback0(ShowProgressRewardPreview));
			if (_updateCountdown != null)
			{
				FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
			}
			_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
		}
		void FocusIsland()
		{
			CloseMainUi?.Invoke();
			GvGWorldMapController.Instance.FocusIslandById(islandId);
		}
		IEnumerator RefreshCountdown()
		{
			while (!((GObject)this).isDisposed)
			{
				int countdown = (int)model.MainMission.ExpiredTimestamp - CurrentTimestamp;
				if (countdown < 0)
				{
					countdown = 0;
				}
				string countdownText = UiHelper.ParseTimeShort(countdown);
				switch (Step.selectedIndex)
				{
				case 1:
				case 3:
					((GObject)Countdown1).text = countdownText;
					break;
				case 2:
					((GObject)Countdown2).text = countdownText;
					break;
				}
				yield return _perSecond;
			}
		}
		void ShowProgressRewardPreview()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ProgressRewardPreview.Name, new Dictionary<string, object> { { "CurProgress", model.Progress } });
		}
	}
}
