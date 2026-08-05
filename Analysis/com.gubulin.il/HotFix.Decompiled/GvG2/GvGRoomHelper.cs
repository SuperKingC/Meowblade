using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using UI.IslandComeAgain;
using UI.Tips;

namespace GvG2;

public static class GvGRoomHelper
{
	public static void GvGRoomOperation(eGvGRoomOperation op, Action<string> callback, bool isInquiring = false, Action<int> onFailed = null)
	{
		ILRequestHelper<GvGRoomOperationResponse>.Request((EventContext)null, (Func<Task<GvGRoomOperationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGRoomOperation(op.ToString())), (Action<GvGRoomOperationResponse>)delegate(GvGRoomOperationResponse response)
		{
			if (response.ErrorCode == 81310400)
			{
				ShowIslandDisabledTip(LanguagesManager.TryParseMultiLanguageTip(response.ServerStatusMessage));
			}
			else if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				if (isInquiring)
				{
					callback(response.JsonResult);
				}
				onFailed?.Invoke(response.ErrorCode);
			}
			else
			{
				callback(response.JsonResult);
			}
		});
	}

	private static void ShowIslandDisabledTip(string message)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "Content", message },
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					delegate
					{
						if (GameController.Contexts.Service<IUiService>().HasShowingUi(UI_IslandComeAgainMatchingPanel.Name))
						{
							GameController.Contexts.Service<IUiService>().ClosePanel(UI_IslandComeAgainMatchingPanel.Name);
						}
					}
				} }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", 999999 }
		});
	}
}
