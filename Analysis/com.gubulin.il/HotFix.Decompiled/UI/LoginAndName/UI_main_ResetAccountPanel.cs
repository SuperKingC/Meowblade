using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.GvG.Common.Models;

namespace UI.LoginAndName;

public class UI_main_ResetAccountPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_ResetAccuntPanel Dialog;

	public const string URL = "ui://yb3s7uv7sibh5m";

	public static string Name = "UI_main_ResetAccountPanel";

	public const string WechatLoginPanel = "WechatLoginPanel";

	public const string LoginResponse = "LoginResponse";

	public const string PreCheckResponse = "PreCheckResponse";

	private UI_WechatLogin _wechatLogin;

	private LoginResponse _loginResponse;

	public static string GetURL()
	{
		return "ui://yb3s7uv7sibh5m";
	}

	public static UI_main_ResetAccountPanel CreateInstance()
	{
		return (UI_main_ResetAccountPanel)(object)UIPackage.CreateObject("LoginAndName", "main_ResetAccountPanel");
	}

	public static UI_main_ResetAccountPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ResetAccountPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7sibh5m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_com_ResetAccuntPanel)(object)((GComponent)this).GetChild("Dialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.resetBtn).onClick.Set(new EventCallback0(OnClickResetData));
		((GObject)Dialog.cancel).onClick.Set(new EventCallback0(OnClickRefuseResetData));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.resetBtn).onClick.Clear();
		((GObject)Dialog.cancel).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		_wechatLogin = parameters["WechatLoginPanel"] as UI_WechatLogin;
		_loginResponse = parameters["LoginResponse"] as LoginResponse;
		RItem rItem = ((PreCheckResponse)parameters["PreCheckResponse"])?.Bonus?[0] ?? new RItem
		{
			ItemId = "Gem",
			cnt = 1000
		};
		Dialog.rewardIcon.url = UiHelper.GetItemIconPath(rItem.ItemId);
		((GObject)Dialog.rewardCount).text = $"x{rItem.cnt}";
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

	private void OnClickResetData()
	{
		SentrySdk.AddBreadcrumb("User Click Reset Data");
		UiHelper.ResetUserArchiveWithAutoDelete(_loginResponse.User.UserId, delegate
		{
			End();
		});
	}

	private void OnClickRefuseResetData()
	{
		"LoginRefuseResetDataConfirmTip".ToLanguage().ToConfirmPopup(delegate
		{
			End();
			_wechatLogin.AfterLoginSuccess();
		}, null, (AlignType)0);
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
