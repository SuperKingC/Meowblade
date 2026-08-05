using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.PlayerCommand;

namespace UI.GvGPlayerCommand3;

public class UI_com_CommandMessage : GComponent, IFairyComponent
{
	public GImage Background;

	public GImage n7;

	public GImage n5;

	public GTextField n1;

	public UI_btn_ConfirmBtn2 Confirm;

	public UI_btn_DefaultMessageFilter SelectMessages;

	public GTextInput Message;

	public GButton Close;

	public GTextField n8;

	public const string URL = "ui://vheg8vabeai36";

	public static string Name = "UI_com_CommandMessage";

	public Action<bool> CloseMessageMenu = delegate
	{
	};

	public Action<string> ConfirmCommandMessage = delegate
	{
	};

	private bool _messageChecked;

	public static string GetURL()
	{
		return "ui://vheg8vabeai36";
	}

	public static UI_com_CommandMessage CreateInstance()
	{
		return (UI_com_CommandMessage)(object)UIPackage.CreateObject("GvGPlayerCommand3", "com_CommandMessage");
	}

	public static UI_com_CommandMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CommandMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai36", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://vheg8vabeai36".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		Confirm = (UI_btn_ConfirmBtn2)(object)((GComponent)this).GetChild("Confirm");
		SelectMessages = (UI_btn_DefaultMessageFilter)(object)((GComponent)this).GetChild("SelectMessages");
		Message = (GTextInput)((GComponent)this).GetChild("Message");
		Close = (GButton)((GComponent)this).GetChild("Close");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://vheg8vabeai36".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
	}

	public void Destroy()
	{
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)Confirm).onClick.Set(new EventCallback0(ConfirmOnClick));
		((GObject)Close).onClick.Set(new EventCallback0(CloseUi));
		Message.onChanged.Set(new EventCallback0(OnTextChange));
	}

	public void UnregisterUiEvent()
	{
		((GObject)Confirm).onClick.Clear();
		((GObject)Close).onClick.Clear();
		Message.onChanged.Clear();
	}

	public void Render(eIslandEvent commandType)
	{
		((GObject)Message).text = string.Empty;
		_messageChecked = false;
		LoadDefaultCommandMessages(commandType);
	}

	private void ConfirmOnClick()
	{
		if (_messageChecked)
		{
			ConfirmMessage();
		}
		else
		{
			CheckMessage();
		}
	}

	private void CloseUi()
	{
		CloseMessageMenu?.Invoke(obj: false);
	}

	private void CheckMessage()
	{
		CheckMessageEmpty();
		Singleton<GvG3EventMissionManager>.Instance.CheckPlayerCommandMessage(((GObject)Message).text, OnCheckFinish);
	}

	private void OnCheckFinish(C2S_CheckPlayerCommandMessage.Response response)
	{
		if (response.Changed)
		{
			_messageChecked = true;
			((GObject)Message).text = response.newString;
		}
		else
		{
			ConfirmMessage();
		}
	}

	private void CheckMessageEmpty()
	{
		if (string.IsNullOrEmpty(((GObject)Message).text))
		{
			((GObject)Message).text = "vheg8vabeai36-n4_eai3-prompt".ToLanguage();
		}
	}

	private void ConfirmMessage()
	{
		ConfirmCommandMessage?.Invoke(((GObject)Message).text);
		CloseMessageMenu?.Invoke(obj: false);
	}

	private void OnTextChange()
	{
		_messageChecked = false;
	}

	private void LoadDefaultCommandMessages(eIslandEvent commandType)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		List<string> messages = new List<string>();
		for (int i = 1; i <= 3; i++)
		{
			messages.Add($"GvG3_{commandType}_Message_{i}".ToLanguage());
		}
		SelectMessages.Menu.itemRenderer = new ListItemRenderer(RenderMessage);
		SelectMessages.Menu.numItems = 3;
		void RenderMessage(int index, GObject obj)
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			if (obj is UI_btn_DefaultMessage uI_btn_DefaultMessage)
			{
				((GObject)uI_btn_DefaultMessage.Desc2).text = messages[index];
				((GObject)uI_btn_DefaultMessage).data = index;
				((GObject)uI_btn_DefaultMessage).onClick.Set(new EventCallback1(SelectMessage));
			}
		}
		void SelectMessage(EventContext context)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			int index = (int)((GObject)context.sender).data;
			((GObject)Message).text = messages[index];
		}
	}
}
