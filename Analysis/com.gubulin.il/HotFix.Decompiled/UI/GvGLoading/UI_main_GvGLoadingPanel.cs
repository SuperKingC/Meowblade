using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GvGLoading;

public class UI_main_GvGLoadingPanel : GComponent, IUiController
{
	public enum eLoadingType
	{
		Enter,
		Exit
	}

	public Controller Type;

	public GLoader background;

	public UI_Temp_Ships n1;

	public const string URL = "ui://wvi1oqrwgfov0";

	public static string Name = "UI_main_GvGLoadingPanel";

	private UICallbackParam<Action> OnShowCallback;

	public static string GetURL()
	{
		return "ui://wvi1oqrwgfov0";
	}

	public static UI_main_GvGLoadingPanel CreateInstance()
	{
		return (UI_main_GvGLoadingPanel)(object)UIPackage.CreateObject("GvGLoading", "main_GvGLoadingPanel");
	}

	public static UI_main_GvGLoadingPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGLoadingPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://wvi1oqrwgfov0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		background = (GLoader)((GComponent)this).GetChild("background");
		n1 = (UI_Temp_Ships)(object)((GComponent)this).GetChild("n1");
	}

	public static void Open(eLoadingType type, Action onShow)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, new Dictionary<string, object>
		{
			{ "Type", type },
			{
				"OnShow",
				new UICallbackParam<Action>(onShow)
			}
		});
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters == null || !parameters.TryGetValue("Type", out var value))
		{
			ILRuntimeDebug.LogError("[UI_main_GvGLoadingPanel] 缺少参数");
			return;
		}
		if (parameters.TryGetValue("OnShow", out var value2))
		{
			OnShowCallback = (UICallbackParam<Action>)value2;
		}
		Type.selectedIndex = (int)value;
	}

	private IEnumerator ShowNextFrame()
	{
		yield return null;
		OnShowCallback?.Callback?.Invoke();
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener("CLOSE_GVGLOADING_UI", End);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener("CLOSE_GVGLOADING_UI", End);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		Singleton<GvGMode3RoomManager>.Instance.StopwatchStop();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ShowNextFrame());
	}
}
