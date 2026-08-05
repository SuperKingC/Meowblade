using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace UI.Tips;

public class UI_GoToReviewPopup : GComponent, IUiController
{
	public GGraph back;

	public UI_GoToReviewDialog GoToReviewDialog;

	public const string URL = "ui://47lbpgx9rc29j5ltfn";

	public static string Name = "UI_GoToReviewPopup";

	public static string GetURL()
	{
		return "ui://47lbpgx9rc29j5ltfn";
	}

	public static UI_GoToReviewPopup CreateInstance()
	{
		return (UI_GoToReviewPopup)(object)UIPackage.CreateObject("Tips", "GoToReviewPopup");
	}

	public static UI_GoToReviewPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToReviewPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9rc29j5ltfn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		GoToReviewDialog = (UI_GoToReviewDialog)(object)((GComponent)this).GetChild("GoToReviewDialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)GoToReviewDialog.GoToReviewBtn).onClick.Set(new EventCallback0(OnClickGoToReview));
		((GObject)GoToReviewDialog.CloseBtn).onClick.Set(new EventCallback0(OnClickCloseBtn));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)GoToReviewDialog.GoToReviewBtn).onClick.Remove(new EventCallback0(OnClickGoToReview));
		((GObject)GoToReviewDialog.CloseBtn).onClick.Remove(new EventCallback0(OnClickCloseBtn));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void OnClickGoToReview()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			GameController.Contexts.Service<INetworkService>().StatsAppStoreReview(HotUpdateProcess.ChannelCode, 0);
			string obj = JsonHelper.ToJson(new BaseIOSSDK.AppleRate
			{
				Title = LanguagesManager.GetDesc("RatePopupTitle"),
				Message = LanguagesManager.GetDesc("RatePopupArticle"),
				RateNow = LanguagesManager.GetDesc("RatePopupConfirm"),
				RateLate = LanguagesManager.GetDesc("RatePopupCancel")
			});
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].Rate(obj);
		}
		else if ((HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay") && UiHelper.LoginTypeStr == UserLoginCredentialsType.TapTap.ToString())
		{
			TapTapSDK tapTapSDK = (TapTapSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapTapSDK];
			Action action = delegate
			{
				TapTapSDK.TapTapUserProfile userProfile = tapTapSDK.UserProfile;
				GameController.Contexts.Service<INetworkService>().StatsTapTapReview(userProfile.openid, userProfile.name);
				tapTapSDK.OpenReview();
			};
			if (tapTapSDK.UserProfile == null)
			{
				tapTapSDK.EnsureLoginState(action);
			}
			else
			{
				action();
			}
		}
		else
		{
			ILRuntimeDebug.LogError("[Review]" + HotUpdateProcess.ChannelCode + " " + UiHelper.LoginTypeStr + "未实现引导评价功能");
		}
		End();
	}

	private void OnClickCloseBtn()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			GameController.Contexts.Service<INetworkService>().StatsAppStoreReview(HotUpdateProcess.ChannelCode, 1);
		}
		else if ((HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay") && UiHelper.LoginTypeStr == UserLoginCredentialsType.TapTap.ToString())
		{
			GameController.Contexts.Service<INetworkService>().StatsTapTapReview(null, null);
		}
		End();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}
}
