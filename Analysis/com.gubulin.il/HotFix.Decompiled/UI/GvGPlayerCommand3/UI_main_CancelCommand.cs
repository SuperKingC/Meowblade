using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UnityEngine;

namespace UI.GvGPlayerCommand3;

public class UI_main_CancelCommand : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_CancelCommand PopUp;

	public Transition t0;

	public const string URL = "ui://vheg8vabeai35";

	public static string Name = "UI_main_CancelCommand";

	private IEvent_PlayerCommand _command;

	private Coroutine _updateCountdown;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://vheg8vabeai35";
	}

	public static UI_main_CancelCommand CreateInstance()
	{
		return (UI_main_CancelCommand)(object)UIPackage.CreateObject("GvGPlayerCommand3", "main_CancelCommand");
	}

	public static UI_main_CancelCommand CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_CancelCommand).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		PopUp = (UI_com_CancelCommand)(object)((GComponent)this).GetChild("PopUp");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_command = (parameters.TryGetValue("PlayerCommand", out var value) ? (value as IEvent_PlayerCommand) : null);
		Render();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
		((GObject)PopUp.Cancel).onClick.Set(new EventCallback0(CancelCommand));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
		((GObject)PopUp.Cancel).onClick.Clear();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void CancelCommand()
	{
		Singleton<GvG3EventMissionManager>.Instance.CancelPlayerCommand(_command.MUID, End);
	}

	private void Render()
	{
		PopUp.Type.selectedIndex = ((_command.UserId == GameController.Contexts.gameState.user.value.UserId) ? 1 : 0);
		PopUp.CurrentCommand.Type.selectedIndex = GetTypeIndex(_command.EventType);
		((GObject)PopUp.CommandDetail).text = string.Format("GvG3_PlayerCommand_Effect2".ToLanguage(), $"GvG3_{_command.EventType}".ToLanguage(), _command.ContributionPointAddPercentage);
		if (_updateCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateCountdown);
		}
		_updateCountdown = FGUIManager.Instance.OpenIEnumerator(RefreshCountdown());
		static int GetTypeIndex(eIslandEvent commandEventType)
		{
			return commandEventType switch
			{
				eIslandEvent.PlayerCommand_Attack => 0, 
				eIslandEvent.PlayerCommand_Defense => 1, 
				eIslandEvent.PlayerCommand_Search => 2, 
				_ => 1, 
			};
		}
		IEnumerator RefreshCountdown()
		{
			while (!((GObject)this).isDisposed)
			{
				((GObject)PopUp.Countdown).text = UiHelper.ParseTimeShort(_command.RemainingTime(CurrentTimestamp));
				yield return _perSecond;
			}
		}
	}
}
