using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;

namespace UI.PvpSelectSoldiers;

public class UI_UnlockPeakBattle : GComponent, IUiController
{
	public GGraph Mask;

	public UI_UnlockPeakDialog Dialog;

	public Transition ShowDIalog;

	public const string URL = "ui://82mo10n5x1jlddd";

	public static string Name = "UI_UnlockPeakBattle";

	public static UI_UnlockPeakBattle UnlockPeakBattleDialog;

	public static string GetURL()
	{
		return "ui://82mo10n5x1jlddd";
	}

	public static UI_UnlockPeakBattle CreateInstance()
	{
		return (UI_UnlockPeakBattle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "UnlockPeakBattle");
	}

	public static UI_UnlockPeakBattle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockPeakBattle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jlddd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_UnlockPeakDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDIalog = ((GComponent)this).GetTransition("ShowDIalog");
	}

	public void BeforeDestroy()
	{
		UnlockPeakBattleDialog = null;
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UnlockPeakBattleDialog = this;
	}

	public void OnShow()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.RefreshCardBtn).onClick.Add(new EventCallback0(ConfirmClickEvent));
		((GObject)Dialog.PeakBattleHelp).onClick.Add(new EventCallback0(openHelpPanel));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.RefreshCardBtn).onClick.Remove(new EventCallback0(ConfirmClickEvent));
		((GObject)Dialog.PeakBattleHelp).onClick.Remove(new EventCallback0(openHelpPanel));
	}

	public void UnregisterUiEventListeners()
	{
	}

	private void ConfirmClickEvent()
	{
		ILRequestHelper<GetPvPTopTournamentFormationResponse>.Request((EventContext)null, (Func<Task<GetPvPTopTournamentFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentFormation()), (Action<GetPvPTopTournamentFormationResponse>)delegate(GetPvPTopTournamentFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PeakBattleSelectArrayPanel.Name, new Dictionary<string, object> { { "FormationResponse", response } });
			}
		});
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private async void openHelpPanel()
	{
		UiHelper.OpenHelpPage("游戏帮助界面", "玩法", "天梯巅峰赛");
	}
}
