using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Services;

namespace UI.GvGChat;

public class UI_main_GvG3ChatRedirectIsland : GComponent, IUiController
{
	public GGraph back;

	public UI_com_ConfirmRedirectIsland Pop_Ups;

	public Transition t0;

	public const string URL = "ui://e3rxkbaprb0j11";

	public static string Name = "UI_main_GvG3ChatRedirectIsland";

	private Action _confirm;

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0j11";
	}

	public static UI_main_GvG3ChatRedirectIsland CreateInstance()
	{
		return (UI_main_GvG3ChatRedirectIsland)(object)UIPackage.CreateObject("GvGChat", "main_GvG3ChatRedirectIsland");
	}

	public static UI_main_GvG3ChatRedirectIsland CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3ChatRedirectIsland).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0j11", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Pop_Ups = (UI_com_ConfirmRedirectIsland)(object)((GComponent)this).GetChild("Pop-Ups");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_confirm = (parameters.TryGetValue("ConfirmAction", out var value) ? (value as Action) : null);
		object value2;
		string text = (parameters.TryGetValue("IslandName", out value2) ? value2.ToString() : string.Empty);
		((GObject)Pop_Ups.Tip).text = string.Format("GvGMode3_Chat_FocusIsland".ToLanguage(), new object[1] { text });
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Pop_Ups.Cancel).onClick.Add(new EventCallback0(End));
		((GObject)Pop_Ups.Confirm).onClick.Add(new EventCallback0(OnConfirmClick));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Pop_Ups.Cancel).onClick.Remove(new EventCallback0(End));
		((GObject)Pop_Ups.Confirm).onClick.Remove(new EventCallback0(OnConfirmClick));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void OnConfirmClick()
	{
		End();
		_confirm?.Invoke();
	}
}
