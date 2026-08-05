using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Tips;

public class UI_GuestRegistPopup : GComponent, IUiController
{
	private class LoginTypeBtnModel
	{
		private string _prefix;

		public EventCallback0 ClickAction;

		public string GetImageUrl(string languageKey)
		{
			return "ui://PublicResources/" + languageKey + "_" + _prefix + "LoginBtn";
		}

		public LoginTypeBtnModel(eLoginSDKCode bindTypeSDKCode, EventCallback0 clickAction)
		{
			_prefix = bindTypeSDKCode.ToString().Replace("LoginSDK", "");
			ClickAction = clickAction;
		}
	}

	public Controller Type;

	public GGraph back;

	public UI_LoginTypeSelectDialog LoginTypeSelectDialog;

	public Transition showTip;

	public Transition ShowTipV;

	public const string URL = "ui://47lbpgx9kcpqtb7";

	public static string Name = "UI_GuestRegistPopup";

	private Dictionary<string, LoginTypeBtnModel> _LoginTypeBtnDict = null;

	public static string GetURL()
	{
		return "ui://47lbpgx9kcpqtb7";
	}

	public static UI_GuestRegistPopup CreateInstance()
	{
		return (UI_GuestRegistPopup)(object)UIPackage.CreateObject("Tips", "GuestRegistPopup");
	}

	public static UI_GuestRegistPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GuestRegistPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9kcpqtb7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GGraph)((GComponent)this).GetChild("back");
		LoginTypeSelectDialog = (UI_LoginTypeSelectDialog)(object)((GComponent)this).GetChild("LoginTypeSelectDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
		ShowTipV = ((GComponent)this).GetTransition("ShowTipV");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (_LoginTypeBtnDict == null)
		{
			_LoginTypeBtnDict = new Dictionary<string, LoginTypeBtnModel>
			{
				{
					eLoginSDKCode.GoogleLoginSDK.ToString(),
					new LoginTypeBtnModel(eLoginSDKCode.GoogleLoginSDK, new EventCallback0(GuestBindByGoogle))
				},
				{
					eLoginSDKCode.FacebookLoginSDK.ToString(),
					new LoginTypeBtnModel(eLoginSDKCode.FacebookLoginSDK, new EventCallback0(GuestBindByFacebook))
				},
				{
					eLoginSDKCode.TapTapIntlLoginSDK.ToString(),
					new LoginTypeBtnModel(eLoginSDKCode.TapTapIntlLoginSDK, new EventCallback0(GuestBindByTapTapIntl))
				},
				{
					eLoginSDKCode.AppleLoginSDK.ToString(),
					new LoginTypeBtnModel(eLoginSDKCode.AppleLoginSDK, new EventCallback0(GuestBindByAppleId))
				},
				{
					eLoginSDKCode.AppleOriginalLoginSDK.ToString(),
					new LoginTypeBtnModel(eLoginSDKCode.AppleOriginalLoginSDK, new EventCallback0(GuestBindByAppleId))
				},
				{
					eLoginSDKCode.TelephoneLoginSDK.ToString(),
					new LoginTypeBtnModel(eLoginSDKCode.TelephoneLoginSDK, new EventCallback0(GuestBindByTelephone))
				}
			};
		}
		string channelCode = HotUpdateProcess.ChannelCode;
		foreach (Intl_SDKInfo item in HotUpdateProcess.Instance.ChannelConfig.login)
		{
			string sdkCode = item.sdkCode;
			if (!(sdkCode == eLoginSDKCode.GuestLoginSDK.ToString()))
			{
				if (_LoginTypeBtnDict.ContainsKey(sdkCode))
				{
					UI_CommonLoginTypeBtn uI_CommonLoginTypeBtn = LoginTypeSelectDialog.LoginTypeBtnList.AddItemFromPool() as UI_CommonLoginTypeBtn;
					uI_CommonLoginTypeBtn.BtnLoader.url = _LoginTypeBtnDict[sdkCode].GetImageUrl(HotUpdateProcess.LanguageKey);
					((GObject)uI_CommonLoginTypeBtn).onClick.Add(_LoginTypeBtnDict[sdkCode].ClickAction);
				}
				else
				{
					ILRuntimeDebug.LogError("GusetRegist Set loginSDK Failed, sdkCode=" + sdkCode);
				}
			}
		}
		((GObject)LoginTypeSelectDialog.LoginTypeBtnList).width = ((GComponent)LoginTypeSelectDialog.LoginTypeBtnList).GetChildAt(0).width;
		LoginTypeSelectDialog.LoginTypeBtnList.ResizeToFit(LoginTypeSelectDialog.LoginTypeBtnList.numItems);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void GuestBindByGoogle()
	{
		GoogleSDK googleSDK = (GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK];
		googleSDK.Login();
	}

	private void GuestBindByFacebook()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			((FacebookSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.FacebookSDK]).Login("");
		}
		else if ((int)Application.platform == 8)
		{
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].FacebookLogin();
		}
	}

	private void GuestBindByTapTapIntl()
	{
		TapTapIntlSDK tapTapIntlSDK = (TapTapIntlSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK];
		tapTapIntlSDK.Login(null);
	}

	private void GuestBindByAppleId()
	{
		BaseIOSSDK baseIOSSDK = SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS];
		baseIOSSDK.InitializeApple();
	}

	private void GuestBindByTelephone()
	{
		string name = "";
		string pwd = "";
		GameController.Contexts.Service<INetworkService>().Authenticate(name, pwd);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener<string, string>("GUEST_USER_BIND_SUCCESS", OnGuestBindSuccess);
		SharedMessenger.AddListener<string, string>("GUEST_USER_BIND_FAILED", OnGuestBindFailed);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)back).onClick.Remove(new EventCallback0(End));
		SharedMessenger.RemoveListener<string, string>("GUEST_USER_BIND_SUCCESS", OnGuestBindSuccess);
		SharedMessenger.RemoveListener<string, string>("GUEST_USER_BIND_FAILED", OnGuestBindFailed);
	}

	private void OnGuestBindSuccess(string credentialType, string userInfo)
	{
		End();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				string.Format(LanguagesManager.GetDesc("CsharpCodeTextGuestBindSuccess"))
			},
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					delegate
					{
						INetworkService networkService = GameController.Contexts.Service<INetworkService>();
						networkService.Logout();
						if (GameManagers.Instance != null)
						{
							networkService.Stop();
						}
						GameController.Quit();
					}
				} }
			},
			{ "PageIndex", 4 }
		});
	}

	private void OnGuestBindFailed(string credentialType, string errMsg)
	{
		End();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				string.Format(LanguagesManager.GetDesc("CsharpCodeTextGuestBindFailed"), errMsg)
			},
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					delegate
					{
					}
				} }
			},
			{ "PageIndex", 4 }
		});
	}
}
