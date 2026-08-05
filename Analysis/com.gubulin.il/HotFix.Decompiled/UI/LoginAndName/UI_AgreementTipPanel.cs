using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_AgreementTipPanel : GComponent
{
	public Controller typeController;

	public GGraph mask;

	public GImage back;

	public UI_PrivacyTip privacyText;

	public UI_AgreementTip agreementText;

	public UI_AgeRatingTip AgeRatingTip;

	public GTextField title;

	public UI_exitBtn exit;

	public const string URL = "ui://yb3s7uv7ithf2s";

	public static string Name = "UI_AgreementTipPanel";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://yb3s7uv7ithf2s".Replace("ui://", ""), ((GObject)title).id, typeController.selectedIndex);
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://yb3s7uv7ithf2s";
	}

	public static UI_AgreementTipPanel CreateInstance()
	{
		return (UI_AgreementTipPanel)(object)UIPackage.CreateObject("LoginAndName", "AgreementTipPanel");
	}

	public static UI_AgreementTipPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AgreementTipPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ithf2s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		typeController = ((GComponent)this).GetController("typeController");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		privacyText = (UI_PrivacyTip)(object)((GComponent)this).GetChild("privacyText");
		agreementText = (UI_AgreementTip)(object)((GComponent)this).GetChild("agreementText");
		AgeRatingTip = (UI_AgeRatingTip)(object)((GComponent)this).GetChild("AgeRatingTip");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://yb3s7uv7ithf2s".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		exit = (UI_exitBtn)(object)((GComponent)this).GetChild("exit");
	}
}
