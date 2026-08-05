using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.Tips;
using UI.UpGrade;

namespace UI.ReturningRewards;

public class RecallWelfareMissionJumpContext
{
	public string UiName { get; set; }

	public Dictionary<string, object> Params { get; set; } = new Dictionary<string, object>();

	public void GoToRelativeUi()
	{
		if (!string.IsNullOrEmpty(UiName))
		{
			string uiName = UiName;
			string text = uiName;
			if (text == "UI_GvGExpeditionHallPanel")
			{
				OpenExpeditionHall();
			}
			else
			{
				Contexts.sharedInstance.Service<IUiService>().OpenPanel(UiName, Params);
			}
		}
	}

	private void OpenExpeditionHall()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("7").Level <= 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, new Dictionary<string, object> { 
			{
				"Building",
				GameManagers.Instance.BuildingManager.GetBuildingByType("7")
			} });
			return;
		}
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
				Contexts.sharedInstance.Service<IUiService>().OpenPanel(UiName, Params);
			}
		});
	}
}
