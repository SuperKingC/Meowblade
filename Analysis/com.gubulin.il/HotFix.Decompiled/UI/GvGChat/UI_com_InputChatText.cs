using System;
using System.Collections;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UnityEngine;

namespace UI.GvGChat;

public class UI_com_InputChatText : GComponent
{
	public GImage n1;

	public UI_btn_SendMessage Send;

	public GTextInput InputText;

	public const string URL = "ui://e3rxkbaprb0jh";

	public static string Name = "UI_com_InputChatText";

	private eChatUiChannel CurUIChannel = eChatUiChannel.World;

	private Coroutine _coolingTime;

	private int _nextCanSendTimestamp;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://e3rxkbaprb0jh";
	}

	public static UI_com_InputChatText CreateInstance()
	{
		return (UI_com_InputChatText)(object)UIPackage.CreateObject("GvGChat", "com_InputChatText");
	}

	public static UI_com_InputChatText CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_InputChatText).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3rxkbaprb0jh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Send = (UI_btn_SendMessage)(object)((GComponent)this).GetChild("Send");
		InputText = (GTextInput)((GComponent)this).GetChild("InputText");
		string id = "ui://e3rxkbaprb0jh".Replace("ui://", "") + "-" + ((GObject)InputText).id + "-prompt";
		InputText.promptText = LanguagesManager.GetDesc(id);
	}

	public void OnInit()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		Send.Type.selectedIndex = 0;
		((GObject)Send).onClick.Add(new EventCallback0(SendMessage));
	}

	public void OnDestroy()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Send).onClick.Remove(new EventCallback0(SendMessage));
		if (_coolingTime != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_coolingTime);
		}
	}

	public void OnPageChanged(int channelIndex)
	{
		CurUIChannel = (eChatUiChannel)channelIndex;
	}

	public void SendMessage()
	{
		if (Send.Type.selectedIndex == 0 && CurUIChannel != eChatUiChannel.System && !string.IsNullOrEmpty(((GObject)InputText).text))
		{
			eChatChannel curUIChannel = (eChatChannel)CurUIChannel;
			Singleton<GvG3MessageManager>.Instance.SendMessage(((GObject)InputText).text, curUIChannel, OnSend);
		}
	}

	public bool SendMessage(string msg, eChatChannel channel, Action onSent = null)
	{
		if (Send.Type.selectedIndex != 0)
		{
			return false;
		}
		CurUIChannel = (eChatUiChannel)channel;
		Singleton<GvG3MessageManager>.Instance.SendMessage(msg, channel, delegate
		{
			OnSend();
			onSent?.Invoke();
		});
		return true;
	}

	private IEnumerator ShowCoolingTime()
	{
		if (CurUIChannel != eChatUiChannel.System)
		{
			eChatChannel channel = (eChatChannel)CurUIChannel;
			Send.Type.selectedIndex = 1;
			_nextCanSendTimestamp = ((channel == eChatChannel.World) ? (CurrentTimestamp + GvGMode3MessageConfigHelper.Config.WoldChatSendingCoolDown) : (CurrentTimestamp + GvGMode3MessageConfigHelper.Config.CampChatSendingCoolDown));
			while (CurrentTimestamp < _nextCanSendTimestamp)
			{
				((GObject)Send.Time).text = $"{Mathf.Max(_nextCanSendTimestamp - CurrentTimestamp, 0)}S";
				yield return _perSecond;
			}
			Send.Type.selectedIndex = 0;
		}
	}

	private void OnSend()
	{
		((GObject)InputText).text = string.Empty;
		_coolingTime = FGUIManager.Instance.OpenIEnumerator(ShowCoolingTime());
	}
}
