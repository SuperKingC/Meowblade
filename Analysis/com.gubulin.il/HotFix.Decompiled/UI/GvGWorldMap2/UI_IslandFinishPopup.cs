using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;
using UnityEngine;

namespace UI.GvGWorldMap2;

public class UI_IslandFinishPopup : GComponent, IUiController
{
	public GGraph back;

	public UI_IslandFinishDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://hd2s9kukhger54";

	public static string Name = "UI_IslandFinishPopup";

	private Action OnBackToMap;

	private Action OnWatchMode;

	private Coroutine TimeCounterCoroutine;

	public static string GetURL()
	{
		return "ui://hd2s9kukhger54";
	}

	public static UI_IslandFinishPopup CreateInstance()
	{
		return (UI_IslandFinishPopup)(object)UIPackage.CreateObject("GvGWorldMap2", "IslandFinishPopup");
	}

	public static UI_IslandFinishPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IslandFinishPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukhger54", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_IslandFinishDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Type", out var value))
		{
			Dialog.Type.selectedIndex = (int)value;
			if (Dialog.Type.selectedIndex == 1)
			{
				TimeCounterCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TimeCounter());
			}
		}
		if (parameters.TryGetValue("Data", out var value2))
		{
			S2C_GvGMode2IslandStop.Request request = (S2C_GvGMode2IslandStop.Request)value2;
			if (request.WinnerCamp == -1)
			{
				End();
				return;
			}
			Dialog.CampId.selectedIndex = request.WinnerCamp;
			((GObject)Dialog.Score).text = $"+{request.IslandScore}!";
			((GObject)Dialog.WinInfo).text = string.Format(LanguagesManager.GetDesc("IslandComeAgainWinnerTip"), MapDataManager.GetCampIslandName(request.WinnerCamp));
		}
		if (parameters.TryGetValue("Buttons", out var value3))
		{
			Dictionary<string, Action> dictionary = (Dictionary<string, Action>)value3;
			if (dictionary.TryGetValue("OnBackToMap", out var value4))
			{
				OnBackToMap = value4;
			}
			if (dictionary.TryGetValue("OnWatchMode", out var value5))
			{
				OnWatchMode = value5;
			}
		}
		Popup.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GObject)Dialog.BackToMainCamp).onClick.Add(new EventCallback0(BackToMap));
		((GObject)Dialog.ContinueWatching).onClick.Add(new EventCallback0(SetToWatchMode));
		((GObject)Dialog.ConfirmBtn).onClick.Add(new EventCallback0(BackToMap));
		((GObject)Dialog.ContinueWatching).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener("ON_SOCKET_ERROR", End);
		SharedMessenger.AddListener("ON_GVG2_INSTANCE_END", End);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.BackToMainCamp).onClick.Clear();
		((GObject)Dialog.ContinueWatching).onClick.Clear();
		((GObject)Dialog.ConfirmBtn).onClick.Clear();
		((GObject)Dialog.ContinueWatching).onClick.Clear();
		SharedMessenger.RemoveListener("ON_SOCKET_ERROR", End);
		SharedMessenger.RemoveListener("ON_GVG2_INSTANCE_END", End);
	}

	private IEnumerator TimeCounter()
	{
		int countDown = 5;
		while (countDown != 0)
		{
			((GObject)Dialog.CountDown).text = string.Format(LanguagesManager.GetDesc("IslandComeAgainAutoQuitBattleFieldTip"), countDown--);
			yield return (object)new WaitForSeconds(1f);
		}
		BackToMap();
	}

	private void BackToMap()
	{
		OnBackToMap?.Invoke();
		End();
	}

	private void SetToWatchMode()
	{
		OnWatchMode?.Invoke();
	}

	public void BeforeDestroy()
	{
		if (TimeCounterCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(TimeCounterCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
