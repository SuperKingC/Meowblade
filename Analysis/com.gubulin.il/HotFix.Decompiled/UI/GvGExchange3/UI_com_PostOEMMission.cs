using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_com_PostOEMMission : GComponent, IFairyComponent
{
	public Controller Type;

	public GImage n13;

	public GList Missions;

	public UI_btn_Receive Receive;

	public GImage n3;

	public GTextField n4;

	public GTextField n18;

	public GTextField n6;

	public GGraph n8;

	public GImage n9;

	public GGroup n12;

	public UI_btn_PostNewAmplifier PostNewAmplifier;

	public GImage n14;

	public GImage n15;

	public GImage n16;

	public GGroup n17;

	public Transition t0;

	public const string URL = "ui://tt2iq07onhzv11";

	public static string Name = "UI_com_PostOEMMission";

	private Coroutine _updateMissionState;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private static readonly Action<int> _onSelect = OpenPostPanel;

	public static string GetURL()
	{
		return "ui://tt2iq07onhzv11";
	}

	public static UI_com_PostOEMMission CreateInstance()
	{
		return (UI_com_PostOEMMission)(object)UIPackage.CreateObject("GvGExchange3", "com_PostOEMMission");
	}

	public static UI_com_PostOEMMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PostOEMMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzv11", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Missions = (GList)((GComponent)this).GetChild("Missions");
		Receive = (UI_btn_Receive)(object)((GComponent)this).GetChild("Receive");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://tt2iq07onhzv11".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id2 = "ui://tt2iq07onhzv11".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id2);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://tt2iq07onhzv11".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		PostNewAmplifier = (UI_btn_PostNewAmplifier)(object)((GComponent)this).GetChild("PostNewAmplifier");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GGroup)((GComponent)this).GetChild("n17");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Destroy()
	{
		if (_updateMissionState != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMissionState);
		}
	}

	public void Init()
	{
		Singleton<GvG3FlagshipReqManager>.Instance.GetSelfOemMissions();
	}

	public void RegisterUiEvent()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.UpdateSelfOemMissions = (Action<List<SelfOEMMission_ToProtocol>>)Delegate.Combine(instance.UpdateSelfOemMissions, new Action<List<SelfOEMMission_ToProtocol>>(Renderer));
		((GObject)Receive).onClick.Set(new EventCallback0(ReceiveOemMissionsReward));
		((GObject)PostNewAmplifier).onClick.Set(new EventCallback0(PostFirstOemMission));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.UpdateSelfOemMissions = (Action<List<SelfOEMMission_ToProtocol>>)Delegate.Remove(instance.UpdateSelfOemMissions, new Action<List<SelfOEMMission_ToProtocol>>(Renderer));
		((GObject)Receive).onClick.Clear();
		((GObject)PostNewAmplifier).onClick.Clear();
	}

	private void Renderer(List<SelfOEMMission_ToProtocol> selfMissions)
	{
		if (_updateMissionState != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMissionState);
		}
		Type.SetSelectedIndex((selfMissions.Count > 0) ? 1 : 0);
		for (int i = 0; i < Missions.numItems; i++)
		{
			if (((GComponent)Missions).GetChildAt(i) is UI_com_MyOEMMission btn)
			{
				SelfMissionRenderer(i, btn);
			}
		}
		_updateMissionState = FGUIManager.Instance.OpenIEnumerator(UpdateMissionsState());
		((GObject)Receive).enabled = CanReceive();
		bool CanReceive()
		{
			return selfMissions.Any((SelfOEMMission_ToProtocol mission) => mission.UiState == 1 || mission.UiState == 2);
		}
		static void FinishedMissionRenderer(UI_com_AmplifierSlot amplifier, SelfOEMMission_ToProtocol mission)
		{
			amplifier.IsCriticalStrike.selectedIndex = (mission.IsCritical ? 1 : 0);
			OemMissionAmplifier oemMissionAmplifier = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(mission.AmpIdx);
			if (mission.IsCritical)
			{
				amplifier.Quatity.selectedIndex = oemMissionAmplifier.AmplifierModel.Quality;
			}
			if (mission.IsTitan)
			{
				amplifier.Count.selectedIndex = (mission.IsTitan ? 1 : 0);
				amplifier.TalentSrc.selectedIndex = (mission.IsTitan ? 1 : 0);
				((GObject)amplifier.AmpCount).text = "x2";
				amplifier.TalentSrcIcon.url = "GvGTalent_36".ToPublicResourcesRgbIcon();
			}
		}
		void SelfMissionRenderer(int index, UI_com_MyOEMMission uI_com_MyOEMMission)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			((GObject)uI_com_MyOEMMission).onClick.Set(new EventCallback1(PostOemMission));
			if (selfMissions.Count <= 0 || index > selfMissions.Count - 1)
			{
				uI_com_MyOEMMission.Type.selectedIndex = 0;
			}
			else
			{
				uI_com_MyOEMMission.Type.selectedIndex = 1;
				SelfOEMMission_ToProtocol selfOEMMission_ToProtocol = selfMissions[index];
				uI_com_MyOEMMission.Status.selectedIndex = selfOEMMission_ToProtocol.UiState;
				RenderHelper_AmplifierIcon.RenderAmplifier(uI_com_MyOEMMission.Amplifier.AmplifierIcon, selfOEMMission_ToProtocol.AmpIdx);
				RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier(uI_com_MyOEMMission.Amplifier.AffectedRange, selfOEMMission_ToProtocol.AmpIdx);
				uI_com_MyOEMMission.Amplifier.IsCriticalStrike.selectedIndex = 0;
				uI_com_MyOEMMission.Amplifier.TalentSrc.selectedIndex = 0;
				switch (uI_com_MyOEMMission.Status.selectedIndex)
				{
				case 0:
					((GObject)uI_com_MyOEMMission.Countdown).text = UiHelper.ParseTimeShort(selfOEMMission_ToProtocol.MissionCountdown);
					break;
				case 1:
					FinishedMissionRenderer(uI_com_MyOEMMission.Amplifier, selfOEMMission_ToProtocol);
					break;
				}
			}
		}
		IEnumerator UpdateMissionsState()
		{
			while (!((GObject)Missions).isDisposed && selfMissions.Count > 0)
			{
				yield return _perSecond;
				for (int itemIndex = 0; itemIndex < Missions.numItems; itemIndex++)
				{
					if (selfMissions.Count <= 0)
					{
						break;
					}
					if (itemIndex > selfMissions.Count - 1)
					{
						break;
					}
					GObject childAt = ((GComponent)Missions).GetChildAt(itemIndex);
					if (childAt is UI_com_MyOEMMission btn2)
					{
						SelfOEMMission_ToProtocol mission = selfMissions[itemIndex];
						btn2.Status.selectedIndex = mission.UiState;
						if (btn2.Status.selectedIndex == 0)
						{
							((GObject)btn2.Countdown).text = UiHelper.ParseTimeShort(mission.MissionCountdown);
						}
					}
				}
			}
		}
	}

	private static void PostOemMission(EventContext context)
	{
		UI_com_MyOEMMission uI_com_MyOEMMission = (UI_com_MyOEMMission)(object)context.sender;
		if (uI_com_MyOEMMission != null && uI_com_MyOEMMission.Type.selectedIndex != 1)
		{
			OpenAllAmpFormulas();
		}
	}

	private static void PostFirstOemMission()
	{
		OpenAllAmpFormulas();
	}

	private static void OpenAllAmpFormulas()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3OutsourcingAmplifier.Name, new Dictionary<string, object> { { "OnSelect", _onSelect } });
	}

	private static void OpenPostPanel(int ampIdx)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3PostOEMMission.Name, new Dictionary<string, object> { { "SelectFormulaAmpIdx", ampIdx } });
	}

	private static void ReceiveOemMissionsReward()
	{
		Singleton<GvG3FlagshipReqManager>.Instance.ClaimSelfOemMissions();
	}
}
