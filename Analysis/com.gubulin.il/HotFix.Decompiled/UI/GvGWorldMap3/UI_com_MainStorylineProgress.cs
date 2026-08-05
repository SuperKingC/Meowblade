using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_MainStorylineProgress : GComponent, IFairyComponent
{
	public Controller Progress;

	public GImage n1;

	public UI_btn_CampOverview CampOverview;

	public GImage n2;

	public GTextField n3;

	public GTextField n4;

	public GTextField Progress_2;

	public GImage n7;

	public GList ProgressSteps;

	public GImage n8;

	public GTextField n11;

	public GTextField n12;

	public GTextField n13;

	public GTextField n14;

	public GTextField n15;

	public const string URL = "ui://4eq8fgd2qf7c75";

	public static string Name = "UI_com_MainStorylineProgress";

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private Window _window;

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	private bool Activated => !Singleton<GvG3FlagShipMissionsManager>.Instance.IsEternalNight && !((GObject)this).isDisposed;

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c75";
	}

	public static UI_com_MainStorylineProgress CreateInstance()
	{
		return (UI_com_MainStorylineProgress)(object)UIPackage.CreateObject("GvGWorldMap3", "com_MainStorylineProgress");
	}

	public static UI_com_MainStorylineProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MainStorylineProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c75", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Progress = ((GComponent)this).GetController("Progress");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		CampOverview = (UI_btn_CampOverview)(object)((GComponent)this).GetChild("CampOverview");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		Progress_2 = (GTextField)((GComponent)this).GetChild("Progress");
		string id3 = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)Progress_2).id;
		((GObject)Progress_2).text = LanguagesManager.GetDesc(id3);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		ProgressSteps = (GList)((GComponent)this).GetChild("ProgressSteps");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id4 = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id4);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id5 = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id5);
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id6 = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id6);
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id7 = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id7);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id8 = "ui://4eq8fgd2qf7c75".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id8);
	}

	public void Destroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
		Window window = _window;
		if (window != null)
		{
			((GObject)window).Dispose();
		}
	}

	public void Init()
	{
		if (Activated)
		{
			Render();
		}
	}

	public void RegisterUiEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)CampOverview).onClick.Set(new EventCallback0(ShowCampPlayers));
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(Render));
	}

	public void UnregisterUiEvent()
	{
		((GObject)CampOverview).onClick.Clear();
		GvG3FlagShipMissionsManager instance = Singleton<GvG3FlagShipMissionsManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(Render));
	}

	private void Render()
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		bool isWaitEternalNightProgress;
		int currentProgress;
		int currentStep;
		List<GvGMode3CampProgressConfigModel> progressConfigs;
		if (Activated)
		{
			isWaitEternalNightProgress = Singleton<GvG3FlagShipMissionsManager>.Instance.IsWaitEternalNight;
			currentProgress = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress;
			currentStep = Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep;
			CampOverview.Camp.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
			Progress.selectedIndex = currentProgress - 1;
			progressConfigs = GvG3FlagShipMissionsConfigHelper.CampMainProgressConfig;
			ProgressSteps.itemRenderer = new ListItemRenderer(StepInfoRenderer);
			ProgressSteps.numItems = progressConfigs.Count;
		}
		void StepInfoRenderer(int index, GObject obj)
		{
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Expected O, but got Unknown
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Expected O, but got Unknown
			UI_MainStorylineStepBar stepBar = obj as UI_MainStorylineStepBar;
			if (stepBar != null)
			{
				GvGMode3CampProgressConfigModel gvGMode3CampProgressConfigModel = progressConfigs[index];
				bool flag = gvGMode3CampProgressConfigModel.MissionTag() == eCampMainMissionTag.WaitEternalNight;
				int num = (flag ? 5 : gvGMode3CampProgressConfigModel.Progress);
				stepBar.IsEternalNight.selectedIndex = (flag ? 1 : 0);
				stepBar.IsCurrentStep.selectedIndex = ((currentProgress == num) ? 1 : 0);
				stepBar.IsLastStep.selectedIndex = ((currentProgress - 1 == num) ? 1 : 0);
				LocationData locationData = new LocationData
				{
					IslandId = gvGMode3CampProgressConfigModel.CampControlMoonIsland
				};
				if (currentProgress > num)
				{
					((GProgressBar)stepBar).value = 100.0;
					locationData.Type = 0;
				}
				else if (currentProgress == num)
				{
					int num2 = currentStep - 1;
					if (flag)
					{
						((GProgressBar)stepBar).value = 0.0;
					}
					else
					{
						((GProgressBar)stepBar).value = (double)num2 / (double)gvGMode3CampProgressConfigModel.StepCnt * 100.0;
					}
					locationData.Type = 1;
					locationData.Step = num2;
					stepBar.FlagShip.Camp.selectedIndex = Singleton<WorldStateManager>.Instance.Data.MyCampId;
					((GObject)stepBar.FlagShip).data = new LocationData
					{
						IslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId,
						Type = 3,
						Step = 0
					};
					((GObject)stepBar.FlagShip).onClick.Set(new EventCallback1(FocusIsland));
				}
				else
				{
					((GProgressBar)stepBar).value = 0.0;
					locationData.Type = 2;
				}
				((GObject)stepBar.IslandIcon).data = locationData;
				((GObject)stepBar.IslandIcon).onClick.Set(new EventCallback1(FocusIsland));
				if (flag && isWaitEternalNightProgress)
				{
					if (_updateCountdown != null)
					{
						FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
					}
					_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
				}
			}
			IEnumerator RefreshCountdown()
			{
				while (!((GObject)this).isDisposed)
				{
					int startTimestamp = Singleton<WorldStateManager>.Instance.Data.FinalProgressBegin;
					int izBeginTimestamp = Singleton<WorldStateManager>.Instance.Data.IZBeginTimestamp;
					((GObject)stepBar.Conutdown).text = UiHelper.ParseTimeShort(startTimestamp - CurrentTimestamp);
					((GProgressBar)stepBar).value = (double)(CurrentTimestamp - izBeginTimestamp) / (double)(startTimestamp - izBeginTimestamp) * 100.0;
					yield return _perSecond;
				}
			}
		}
	}

	private void FocusIsland(EventContext context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		LocationData locationData = (LocationData)val.data;
		if (locationData != null && locationData.IslandId != 0)
		{
			UI_com_Islandlocation uI_com_Islandlocation = FairyGUITip.ShowTip<UI_com_Islandlocation>(val, eFairyGUITipDir.Down);
			uI_com_Islandlocation.Step.selectedIndex = locationData.Step;
			uI_com_Islandlocation.Type.selectedIndex = locationData.Type;
			((GObject)uI_com_Islandlocation.IslandName).text = WorldMapConfigHelper.Configs.TryGetIsland(locationData.IslandId)?.Name;
			((GObject)uI_com_Islandlocation.Positioning).onClick.Set((EventCallback0)delegate
			{
				GvGWorldMapController.Instance.FocusIslandById(locationData.IslandId);
			});
		}
	}

	private void ShowCampPlayers()
	{
		Singleton<GvG3FlagShipMissionsManager>.Instance.GetCampInfo(ShowCampInfo);
		static void ShowCampInfo(C2S_GetCampInfo.Response response)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_CampPlayers.Name, new Dictionary<string, object> { { "CampInfo", response } });
		}
	}
}
