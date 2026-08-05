using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.GvGAmplifierEntries;
using UI.GvGAmplifierForge;

namespace Shift.Legion.Common.Models;

public class GvGAmplifierSourceJumpData
{
	public string Title;

	public string JumpContext;

	public Dictionary<string, object> JumpContextParams;

	public bool ShowJumpBtn => !string.IsNullOrEmpty(JumpContext);

	public string SourceText => Title.ToLanguage();

	public void GoToRelativeUi()
	{
		if (string.IsNullOrEmpty(JumpContext))
		{
			return;
		}
		string jumpContext = JumpContext;
		string text = jumpContext;
		if (!(text == "UI_main_GvGTalentPanel"))
		{
			if (text == "UI_main_GvGFlagshipPanel")
			{
				OpenFlagShipPanel();
			}
			else
			{
				Contexts.sharedInstance.Service<IUiService>().OpenPanel(JumpContext, JumpContextParams);
			}
		}
		else
		{
			OpenTalentPanel();
		}
		static void CloseAmplifierPanel()
		{
			IUiService uiService = GameController.Contexts.Service<IUiService>();
			if (uiService.HasShowingUi(UI_GvGAmplifierForgePanel.Name))
			{
				GameController.Contexts.Service<IUiService>().ClosePanel(UI_GvGAmplifierForgePanel.Name);
			}
			if (uiService.HasShowingUi(UI_GvGAmplifierEntriesPanel.Name))
			{
				GameController.Contexts.Service<IUiService>().ClosePanel(UI_GvGAmplifierEntriesPanel.Name);
			}
		}
		void OpenFlagShipPanel()
		{
			CloseAmplifierPanel();
			int ourFlagShipStayIslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
			string shipIdStaySomeIsland = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetShipIdStaySomeIsland(ourFlagShipStayIslandId);
			if (string.IsNullOrEmpty(shipIdStaySomeIsland))
			{
				ILRequestHelper.ShowMessage("GvG3CanNotUseFlagShipTip".ToLanguage());
				GvGWorldMapController.Instance.FocusIslandById(ourFlagShipStayIslandId);
			}
			else
			{
				Contexts.sharedInstance.Service<IUiService>().OpenPanel(JumpContext, JumpContextParams);
			}
		}
		void OpenTalentPanel()
		{
			CloseAmplifierPanel();
			Contexts.sharedInstance.Service<IUiService>().OpenPanel(JumpContext, JumpContextParams);
		}
	}
}
