using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Services;

namespace UI.Certification;

public class UI_CertificationMainPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_CertificationMainDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://56q48tcqm13td";

	public static string Name = "UI_CertificationMainPanel";

	private bool isVerifying = false;

	public static string GetURL()
	{
		return "ui://56q48tcqm13td";
	}

	public static UI_CertificationMainPanel CreateInstance()
	{
		return (UI_CertificationMainPanel)(object)UIPackage.CreateObject("Certification", "CertificationMainPanel");
	}

	public static UI_CertificationMainPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CertificationMainPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13td", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_CertificationMainDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (GameController.FSM == "2")
		{
			((GObject)Dialog.experience).visible = false;
		}
		object value;
		if (parameters == null)
		{
			End();
		}
		else if (parameters.TryGetValue("Type", out value))
		{
			int selectedIndex = (int)value;
			Dialog.Type.selectedIndex = selectedIndex;
			InputTextInit();
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		}
		else
		{
			End();
		}
	}

	public void OnShow()
	{
		ShowDialog.Play();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Dialog.confirm).onClick.Add(new EventCallback0(Confirm));
		((GObject)Dialog.experience).onClick.Add(new EventCallback0(ContinueExperience));
		((GObject)Dialog.notice).onClick.Add(new EventCallback0(ShowNotice));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Dialog.confirm).onClick.Remove(new EventCallback0(Confirm));
		((GObject)Dialog.experience).onClick.Remove(new EventCallback0(ContinueExperience));
		((GObject)Dialog.notice).onClick.Remove(new EventCallback0(ShowNotice));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ContinueExperience()
	{
		int todayPlayTime = CertificationHelper.GetTodayPlayTime();
		if (todayPlayTime < 3600)
		{
			End();
		}
	}

	private void QuitGame()
	{
		End();
		HotFix_Utils.Restart();
	}

	private void InputTextInit()
	{
		((GObject)Dialog.inputRealName).text = CertificationHelper.RealNameText;
		((GObject)Dialog.inputIdCardNumber).text = CertificationHelper.IdCardNumberText;
	}

	private async void Confirm()
	{
		if (isVerifying)
		{
			return;
		}
		isVerifying = true;
		string realName = ((GObject)Dialog.inputRealName).text;
		string idCardNumber = ((GObject)Dialog.inputIdCardNumber).text;
		if (string.IsNullOrEmpty(realName) || string.IsNullOrEmpty(idCardNumber))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText148") }, 5000, arg3: false);
			isVerifying = false;
			return;
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		CertificationHelper.RealNameText = ((GObject)Dialog.inputRealName).text;
		CertificationHelper.IdCardNumberText = ((GObject)Dialog.inputIdCardNumber).text;
		VerifyIdentityResponse verifyResult = await GameController.Contexts.Service<INetworkService>().VerifyIdentity(idCardNumber, realName);
		if (verifyResult.Result)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText149") }, 5000, arg3: false);
			ThinkingDataHelper.Instance.Track("realname_verify");
			User user = GameController.Contexts.gameState.user.value;
			user.Verified = verifyResult.VerifyStatus;
			ThinkingDataHelper.Instance.SetUserBirthdayOnce(CertificationHelper.GetUserBirthdayDateTime(idCardNumber));
			End();
		}
		else
		{
			User user2 = GameController.Contexts.gameState.user.value;
			user2.Verified = verifyResult.VerifyStatus;
			isVerifying = false;
			ShowFailedResult(user2.Verified, verifyResult.Code, verifyResult.RemainVerifyCnt, FGUIManager.Instance.CustomerServiceQQ);
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
	}

	private void ShowNotice()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationNoticePanel.Name, null);
	}

	private void ShowFailedResult(int curStatus, int _code, int _count, string _qqId = "961307252")
	{
		End();
		string certificationDesc = LanguagesManager.GetCertificationDesc(_code, _count, _qqId);
		int num = ((curStatus == 2) ? 3 : 2);
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Type", num },
			{ "Text", certificationDesc }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationTipPopup.Name, parameters);
	}
}
