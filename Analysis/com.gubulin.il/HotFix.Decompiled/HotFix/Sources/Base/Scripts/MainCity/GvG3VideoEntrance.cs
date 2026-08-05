using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GvG3Video;
using UI.GvGExpeditionHall;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.MainCity;

public class GvG3VideoEntrance : MonoBehaviour
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Constants
	{
		public const string UNLOCK_ENTRANCE_LEVEL_ID = "P620";

		public const int EXPEDITION_HALL_REPAIRED_LEVEL = 1;

		public const string NAME = "VideoEntrance";
	}

	private enum ClickState
	{
		Video,
		ExpeditionHall
	}

	public static GvG3VideoEntrance Instance;

	private ClickState _clickState;

	private GameObject _content;

	private bool _entranceAvailable;

	private void Awake()
	{
		_content = ((Component)((Component)this).transform.Find("Content")).gameObject;
		Instance = this;
		UpdateEntrance();
	}

	private void Start()
	{
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", UpdateOnExpeditionHallRepaired);
		SharedMessenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", UpdateOnCompleteLevelId);
		UiTagManager.Instance.Register("MainCity.VideoEntrance", ((Component)this).gameObject);
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", UpdateOnExpeditionHallRepaired);
		SharedMessenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", UpdateOnCompleteLevelId);
		UiTagManager.Instance.Unregister("MainCity.VideoEntrance", ((Component)this).gameObject);
	}

	private void UpdateOnExpeditionHallRepaired(string buildingType, int level)
	{
		if (level <= 1 && !(buildingType != "7"))
		{
			UpdateEntrance();
		}
	}

	private void UpdateOnCompleteLevelId(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (level.LevelId == "P620")
		{
			UpdateEntrance();
		}
	}

	private void UpdateEntrance()
	{
		UpdateState();
		UpdateVisible();
	}

	private void UpdateState()
	{
		bool flag = GameManagers.Instance.BuildingManager.GetBuildingByType("7").Level > 0;
		_clickState = (flag ? ClickState.ExpeditionHall : ClickState.Video);
	}

	private void UpdateVisible()
	{
		if (!Define.GvGMode3UnderDevelopment())
		{
			_entranceAvailable = false;
			_content.SetActive(_entranceAvailable);
			return;
		}
		bool flag = MissionManager.VideoMissions.Values.Any((Mission vm) => vm.MissionState(GameManagers.Instance).Status < MissionStatus.Completed) && _clickState == ClickState.ExpeditionHall;
		bool flag2 = UnlockLevelComplete() && _clickState == ClickState.Video;
		_entranceAvailable = flag || flag2;
		_content.SetActive(_entranceAvailable);
		static bool UnlockLevelComplete()
		{
			foreach (List<string> value in GameManagers.Instance.UserArchiveManager.GetLevelProgress().Values)
			{
				if (value.Contains("P620"))
				{
					return true;
				}
			}
			return false;
		}
	}

	public void OnClick()
	{
		if (_entranceAvailable)
		{
			switch (_clickState)
			{
			case ClickState.Video:
				OpenVideoUi();
				break;
			case ClickState.ExpeditionHall:
				OpenExpeditionHall();
				break;
			}
		}
	}

	private void OpenVideoUi()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Video.Name, null);
	}

	private void OpenExpeditionHall()
	{
		ILRequestHelper<GvGMode3RoomOperationDiabledResponse>.Request((EventContext)null, (Func<Task<GvGMode3RoomOperationDiabledResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3RoomOperationDisabled()), (Action<GvGMode3RoomOperationDiabledResponse>)delegate(GvGMode3RoomOperationDiabledResponse response)
		{
			if (!response.Result)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"Content",
						LanguagesManager.TryParseMultiLanguageTip(response.ServerStatusMessage)
					},
					{
						"Buttons",
						new Dictionary<string, Action> { 
						{
							"Confirm",
							delegate
							{
							}
						} }
					},
					{ "PageIndex", 4 },
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				});
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGExpeditionHallPanel.Name, null);
			}
		});
	}
}
