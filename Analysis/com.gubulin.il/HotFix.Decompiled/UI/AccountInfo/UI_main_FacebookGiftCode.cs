using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;

namespace UI.AccountInfo;

public class UI_main_FacebookGiftCode : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_FacebookGiftCode Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://b9yxt7u0cy496i";

	public static string Name = "UI_main_FacebookGiftCode";

	public static string GetURL()
	{
		return "ui://b9yxt7u0cy496i";
	}

	public static UI_main_FacebookGiftCode CreateInstance()
	{
		return (UI_main_FacebookGiftCode)(object)UIPackage.CreateObject("AccountInfo", "main_FacebookGiftCode");
	}

	public static UI_main_FacebookGiftCode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FacebookGiftCode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0cy496i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_com_FacebookGiftCode)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)mask).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.confirmBtn).onClick.Set(new EventCallback0(OnClickConfirm));
		((GObject)Dialog.tip1).onClickLink.Set(new EventCallback0(OnClickGotoFb));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)mask).onClick.Clear();
		((GObject)Dialog.confirmBtn).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ShowDialog.Play();
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

	private void OnClickConfirm()
	{
		Task<GiftRedeemClaimResponse> task = GameController.Contexts.Service<INetworkService>().GiftRedeemClaim(((GObject)Dialog.inputUsername).text);
		task.GetAwaiter().OnCompleted(delegate
		{
			GiftRedeemClaimResponse result = task.Result;
			if (!result.Result)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				LanguagesManager.GetDesc("CsharpFbGiftCodeRedeemSuccess").ToTip();
			}
		});
	}

	private void OnClickGotoFb()
	{
		UiHelper.OpenUrl("https://www.facebook.com/profile.php?id=61550847554459");
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name, reservePackageRes: true);
	}
}
