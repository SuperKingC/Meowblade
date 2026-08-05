using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvGOEMResult3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_com_PostedFormulaOemMission : GComponent, IFairyComponent
{
	public Controller Type;

	public GImage n7;

	public GList Missions;

	public UI_btn_Receive Receive;

	public GImage n3;

	public GTextField n4;

	public GTextField n19;

	public GTextField n13;

	public GImage n14;

	public GGraph n8;

	public GImage n9;

	public GImage n10;

	public GGroup n12;

	public UI_btn_PostNewFormula PostNewFormula;

	public GImage n15;

	public GImage n16;

	public GImage n17;

	public GGroup n18;

	public Transition t0;

	public const string URL = "ui://tt2iq07osmtg2w";

	public static string Name = "UI_com_PostedFormulaOemMission";

	private Coroutine _updateMissionState;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private readonly Lazy<C2S_GetSelfFormulaOEMMissions.Response> _response = new Lazy<C2S_GetSelfFormulaOEMMissions.Response>(() => new C2S_GetSelfFormulaOEMMissions.Response
	{
		Records = new List<FormulaOEMMissionsSelfRecord>(5)
	});

	private static readonly Action<int> _selectFormulaAmp = OnSelectAmp;

	private List<FormulaOEMMissionsSelfRecord> Records => _response.Value.Records;

	public static string GetURL()
	{
		return "ui://tt2iq07osmtg2w";
	}

	public static UI_com_PostedFormulaOemMission CreateInstance()
	{
		return (UI_com_PostedFormulaOemMission)(object)UIPackage.CreateObject("GvGExchange3", "com_PostedFormulaOemMission");
	}

	public static UI_com_PostedFormulaOemMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PostedFormulaOemMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07osmtg2w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		Missions = (GList)((GComponent)this).GetChild("Missions");
		Receive = (UI_btn_Receive)(object)((GComponent)this).GetChild("Receive");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://tt2iq07osmtg2w".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id2 = "ui://tt2iq07osmtg2w".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id2);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id3 = "ui://tt2iq07osmtg2w".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id3);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		PostNewFormula = (UI_btn_PostNewFormula)(object)((GComponent)this).GetChild("PostNewFormula");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
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
		Singleton<GvG3FlagshipReqManager>.Instance.GetSelfFormulaOemMissions();
	}

	public void RegisterUiEvent()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.OnFormulaOemMissionsSelfRecordsUpdate = (Action<List<FormulaOEMMissionsSelfRecord>>)Delegate.Combine(instance.OnFormulaOemMissionsSelfRecordsUpdate, new Action<List<FormulaOEMMissionsSelfRecord>>(OnMissionsUpdate));
		GvG3FlagshipReqManager instance2 = Singleton<GvG3FlagshipReqManager>.Instance;
		instance2.OnFormulaOemMissionSelfRecordUpdate = (Action<FormulaOEMMissionsSelfRecord>)Delegate.Combine(instance2.OnFormulaOemMissionSelfRecordUpdate, new Action<FormulaOEMMissionsSelfRecord>(OnMissionUpdate));
		((GObject)Receive).onClick.Set(new EventCallback0(ReceiveOemMissionsReward));
		((GObject)PostNewFormula).onClick.Set(new EventCallback0(PostFirstOemMission));
	}

	public void UnregisterUiEvent()
	{
		GvG3FlagshipReqManager instance = Singleton<GvG3FlagshipReqManager>.Instance;
		instance.OnFormulaOemMissionsSelfRecordsUpdate = (Action<List<FormulaOEMMissionsSelfRecord>>)Delegate.Remove(instance.OnFormulaOemMissionsSelfRecordsUpdate, new Action<List<FormulaOEMMissionsSelfRecord>>(OnMissionsUpdate));
		GvG3FlagshipReqManager instance2 = Singleton<GvG3FlagshipReqManager>.Instance;
		instance2.OnFormulaOemMissionSelfRecordUpdate = (Action<FormulaOEMMissionsSelfRecord>)Delegate.Remove(instance2.OnFormulaOemMissionSelfRecordUpdate, new Action<FormulaOEMMissionsSelfRecord>(OnMissionUpdate));
		((GObject)Receive).onClick.Clear();
		((GObject)PostNewFormula).onClick.Clear();
	}

	private void OnMissionsUpdate(List<FormulaOEMMissionsSelfRecord> selfMissions)
	{
		UpdateSelfMissions(selfMissions);
		RenderMissionsAndUpdateReceiveBtnEnabled();
		SetMissionUiType();
		TryCreateMissionCountdown();
	}

	private void OnMissionUpdate(FormulaOEMMissionsSelfRecord selfMission)
	{
		int num = UpdateSelfMission(selfMission);
		if (num >= 0)
		{
			UpdateSomeMissionAndReceiveBtnEnabled(num);
		}
		else
		{
			RenderMissionsAndUpdateReceiveBtnEnabled();
		}
		SetMissionUiType();
		TryCreateMissionCountdown();
	}

	private void UpdateSomeMissionAndReceiveBtnEnabled(int missionIndex)
	{
		RenderSelfMission(missionIndex);
		((GObject)Receive).enabled = CanReceive();
	}

	private void SetMissionUiType()
	{
		Type.SetSelectedIndex((Records.Count > 0) ? 1 : 0);
	}

	private void UpdateSelfMissions(List<FormulaOEMMissionsSelfRecord> selfMissions)
	{
		Records.Clear();
		Records.AddRange(selfMissions);
	}

	private int UpdateSelfMission(FormulaOEMMissionsSelfRecord selfMission)
	{
		int num = Records.FindIndex((FormulaOEMMissionsSelfRecord r) => r.MUID == selfMission.MUID);
		if (num < 0)
		{
			Records.Add(selfMission);
			return Records.Count - 1;
		}
		if (selfMission.IsCompleted)
		{
			Records.RemoveAt(num);
			return -1;
		}
		Records[num] = selfMission;
		return num;
	}

	private void RenderMissionsAndUpdateReceiveBtnEnabled()
	{
		for (int i = 0; i < Missions.numItems; i++)
		{
			RenderSelfMission(i);
		}
		((GObject)Receive).enabled = CanReceive();
	}

	private void RenderSelfMission(int missionIndex)
	{
		if (((GComponent)Missions).GetChildAt(missionIndex) is UI_com_MyFormulaOemMission btn)
		{
			SelfMissionRenderer(missionIndex, btn);
		}
	}

	private void SelfMissionRenderer(int index, UI_com_MyFormulaOemMission btn)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)btn).onClick.Set(new EventCallback1(PostOemMission));
		if (Records.Count <= 0 || index > Records.Count - 1)
		{
			btn.Type.selectedIndex = 0;
			return;
		}
		btn.Type.selectedIndex = 1;
		FormulaOEMMissionsSelfRecord formulaOEMMissionsSelfRecord = Records[index];
		btn.Status.selectedIndex = formulaOEMMissionsSelfRecord.UiState;
		((UI_com_FormulaOem)(object)btn.Formula).Render(formulaOEMMissionsSelfRecord.AmpIdx);
		int unclaimedCount = formulaOEMMissionsSelfRecord.UnclaimedCount;
		((GObject)btn.RewardCount).visible = unclaimedCount > 0;
		((GObject)btn.RewardCount.RewardCount).text = unclaimedCount.ToString();
		btn.CountColor.SetSelectedIndex((formulaOEMMissionsSelfRecord.FinishCount >= formulaOEMMissionsSelfRecord.TotalCount) ? 1 : 0);
		((GObject)btn.RemainingCount).text = $"{formulaOEMMissionsSelfRecord.TotalCount - formulaOEMMissionsSelfRecord.FinishCount}/{formulaOEMMissionsSelfRecord.TotalCount}";
		if (btn.Status.selectedIndex == 0)
		{
			((GObject)btn.Countdown).text = UiHelper.ParseTimeShort(formulaOEMMissionsSelfRecord.MissionCountdown);
		}
	}

	private void TryCreateMissionCountdown()
	{
		if (_updateMissionState == null)
		{
			_updateMissionState = FGUIManager.Instance.OpenIEnumerator(UpdateMissionsState());
		}
	}

	private IEnumerator UpdateMissionsState()
	{
		while (!((GObject)Missions).isDisposed && Records.Count > 0)
		{
			yield return _perSecond;
			for (int itemIndex = 0; itemIndex < Missions.numItems; itemIndex++)
			{
				if (Records.Count <= 0)
				{
					break;
				}
				if (itemIndex > Records.Count - 1)
				{
					break;
				}
				GObject childAt = ((GComponent)Missions).GetChildAt(itemIndex);
				if (childAt is UI_com_MyFormulaOemMission btn)
				{
					FormulaOEMMissionsSelfRecord mission = Records[itemIndex];
					btn.Status.selectedIndex = mission.UiState;
					if (btn.Status.selectedIndex == 0)
					{
						((GObject)btn.Countdown).text = UiHelper.ParseTimeShort(mission.MissionCountdown);
					}
				}
			}
		}
	}

	private bool CanReceive()
	{
		return Records.Any((FormulaOEMMissionsSelfRecord mission) => mission.UiState == 1 || mission.UiState == 2 || mission.UnclaimedCount > 0);
	}

	private static void PostOemMission(EventContext context)
	{
		UI_com_MyFormulaOemMission uI_com_MyFormulaOemMission = (UI_com_MyFormulaOemMission)(object)context.sender;
		if (uI_com_MyFormulaOemMission != null && uI_com_MyFormulaOemMission.Type.selectedIndex != 1)
		{
			OpenSelectFormulaAmpPanel();
		}
	}

	private static void PostFirstOemMission()
	{
		OpenSelectFormulaAmpPanel();
	}

	private static void OpenSelectFormulaAmpPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_PostFormulaOemFilter.Name, new Dictionary<string, object> { { "OnSelectFormula", _selectFormulaAmp } });
	}

	private static void OnSelectAmp(int ampIdx)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_PostFormulaOem.Name, new Dictionary<string, object> { { "SelectFormulaAmpIdx", ampIdx } });
	}

	private void ReceiveOemMissionsReward()
	{
		UnityUiService.Instance.OpenPanel(UI_main_GvG3FormulaOemResult.Name, new Dictionary<string, object> { { "Record", _response.Value } });
	}
}
