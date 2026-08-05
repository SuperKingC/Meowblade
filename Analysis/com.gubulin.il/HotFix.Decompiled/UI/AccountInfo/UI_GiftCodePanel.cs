using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;

namespace UI.AccountInfo;

public class UI_GiftCodePanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_GiftCodeDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://b9yxt7u0jc5a6y";

	public static string Name = "UI_GiftCodePanel";

	public static string GetURL()
	{
		return "ui://b9yxt7u0jc5a6y";
	}

	public static UI_GiftCodePanel CreateInstance()
	{
		return (UI_GiftCodePanel)(object)UIPackage.CreateObject("AccountInfo", "GiftCodePanel");
	}

	public static UI_GiftCodePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GiftCodePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0jc5a6y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_GiftCodeDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)mask).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.confirmBtn).onClick.Set(new EventCallback0(OnClickConfirm));
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
		string text = ((GObject)Dialog.code).text;
		Task<GiftRedeemClaimResponse> task = GameController.Contexts.Service<INetworkService>().GiftRedeemClaim(text);
		task.GetAwaiter().OnCompleted(delegate
		{
			GiftRedeemClaimResponse result = task.Result;
			if (!result.Result)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpGiftCodeRedeemSuccess") }, 1, arg3: false);
			}
		});
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name, reservePackageRes: true);
	}
}
