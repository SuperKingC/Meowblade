using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_CopyInvitingCodeWindow : GComponent, IUiController
{
	public GGraph back;

	public UI_CopyInvitingCodePopup Popup;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9mq51tbe";

	public static string Name = "UI_CopyInvitingCodeWindow";

	public static string GetURL()
	{
		return "ui://47lbpgx9mq51tbe";
	}

	public static UI_CopyInvitingCodeWindow CreateInstance()
	{
		return (UI_CopyInvitingCodeWindow)(object)UIPackage.CreateObject("Tips", "CopyInvitingCodeWindow");
	}

	public static UI_CopyInvitingCodeWindow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CopyInvitingCodeWindow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9mq51tbe", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Popup = (UI_CopyInvitingCodePopup)(object)((GComponent)this).GetChild("Popup");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		GComponent asCom = ((GComponent)this).GetChild("Popup").asCom;
		asCom.GetChild("exitBtn").onClick.Add(new EventCallback0(End));
		asCom.GetChild("CopyBtn").onClick.Add(new EventCallback0(CopyInvitingCode));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		GComponent asCom = ((GComponent)this).GetChild("Popup").asCom;
		asCom.GetChild("exitBtn").onClick.Remove(new EventCallback0(End));
		asCom.GetChild("CopyBtn").onClick.Remove(new EventCallback0(CopyInvitingCode));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
	}

	public void OnShow()
	{
		GComponent asCom = ((GComponent)this).GetChild("Popup").asCom;
		asCom.GetChild("InvitingCode").text = string.Format(LanguagesManager.GetDesc("CsharpCodeTextInvitingCode"), GameController.Contexts.gameState.user.value.InvitingCode);
		asCom.GetChild("Tip").text = string.Format(asCom.GetChild("Tip").text, GameController.Contexts.gameState.user.value.InvitingCode.Length);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void CopyInvitingCode()
	{
		GUIUtility.systemCopyBuffer = GameController.Contexts.gameState.user.value.InvitingCode;
		List<string> arg = new List<string> { string.Format(LanguagesManager.GetDesc("CsharpCodeTextInvitingCodeCopied"), GameController.Contexts.gameState.user.value.InvitingCode) };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}
}
