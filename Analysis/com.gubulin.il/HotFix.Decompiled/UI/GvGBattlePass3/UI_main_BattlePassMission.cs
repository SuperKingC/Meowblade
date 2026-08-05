using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.GvG3SupplyDepot;
using UnityEngine;

namespace UI.GvGBattlePass3;

public class UI_main_BattlePassMission : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BattlePassMission Dialog;

	public Transition ShowSelf;

	public const string URL = "ui://bfjg32huq1eq4b";

	public static string Name = "UI_main_BattlePassMission";

	public static int DataLoadingStatus = 0;

	private List<Contribution> _contributionsData = new List<Contribution>();

	private UI_main_GvG3BattlePass _parentPanel;

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq4b";
	}

	public static UI_main_BattlePassMission CreateInstance()
	{
		return (UI_main_BattlePassMission)(object)UIPackage.CreateObject("GvGBattlePass3", "main_BattlePassMission");
	}

	public static UI_main_BattlePassMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_BattlePassMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq4b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_BattlePassMission)(object)((GComponent)this).GetChild("Dialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		_parentPanel = (UI_main_GvG3BattlePass)parameters["Parent"];
		_parentPanel.PageController.selectedIndex = 1;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ShowSelf.Play();
		Dialog.MissionList.SetVirtual();
		Dialog.MissionList.itemRenderer = new ListItemRenderer(ItemRenderer);
		Dialog.MissionList.numItems = 0;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetMissionCoroutine());
	}

	private void OnAllDataLoaded()
	{
		UpdateMissionList();
	}

	private IEnumerator GetMissionCoroutine()
	{
		DataLoadingStatus = 1;
		GetAllContribution();
		if (DataLoadingStatus == 1)
		{
			while (DataLoadingStatus != 2)
			{
				yield return null;
			}
		}
		if (DataLoadingStatus == 2)
		{
			OnAllDataLoaded();
		}
	}

	private void ItemRenderer(int index, GObject obj)
	{
		if (!((GObject)this).isDisposed)
		{
			UI_com_MissionSlot uI_com_MissionSlot = (UI_com_MissionSlot)(object)obj;
			if (index >= _contributionsData.Count)
			{
				((GObject)uI_com_MissionSlot.Title).text = "-----";
				((GObject)uI_com_MissionSlot.LevelText).text = "--";
			}
			else
			{
				Contribution contribution = _contributionsData[index];
				((GObject)uI_com_MissionSlot.Title).text = contribution.Key;
				((GObject)uI_com_MissionSlot.LevelText).text = contribution.Value.ToString();
			}
		}
	}

	public void GetAllContribution()
	{
		Singleton<WorldStateManager>.Instance.GetAllContributionExcludingBuy(UpdateLoadingStatus);
		void UpdateLoadingStatus(List<Contribution> contributions)
		{
			_contributionsData = contributions;
			_contributionsData.Sort(UI_com_DailyReward.ContributionInfoSort);
			DataLoadingStatus = 2;
		}
	}

	private void UpdateMissionList()
	{
		if (!((GObject)this).isDisposed)
		{
			Dialog.MissionList.numItems = _contributionsData.Count;
			Dialog.MissionList.RefreshVirtualList();
			Dialog.contribute.SetSelectedIndex((!_contributionsData.Any()) ? 1 : 0);
		}
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void Destroy()
	{
		if (_parentPanel != null && !((GObject)_parentPanel).isDisposed)
		{
			_parentPanel.PageController.selectedIndex = 0;
		}
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}
}
