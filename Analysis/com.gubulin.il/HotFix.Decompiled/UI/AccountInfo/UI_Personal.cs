using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_Personal : GComponent
{
	public Controller isDefault;

	public GImage n140;

	public GImage bgWithCancelBtn;

	public GGraph n146;

	public GLoader PersonalRnage;

	public GImage n144;

	public UI_HeadPortrait AvatarLoader;

	public GLoader FrameLoader;

	public UI_VerifingStatus VerifingStatus;

	public GLoader NamePlateLoader;

	public UI_logoutBtn logoutBtnDefault;

	public UI_DecorateAndSave DeOrSaBtn;

	public UI_logoutBtn logoutBtn;

	public GLoader TitleLoader;

	public GRichTextField NameText;

	public UI_modifyBtn modifyBtn;

	public GTextField IdText;

	public GTextField n115;

	public UI_copyBtn copyBtn;

	public GList n147;

	public UI_cancelAccountBtn cancelBtn;

	public const string URL = "ui://b9yxt7u0wgrq33";

	public static string Name = "UI_Personal";

	public static string GetURL()
	{
		return "ui://b9yxt7u0wgrq33";
	}

	public static UI_Personal CreateInstance()
	{
		return (UI_Personal)(object)UIPackage.CreateObject("AccountInfo", "Personal");
	}

	public static UI_Personal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Personal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0wgrq33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isDefault = ((GComponent)this).GetController("isDefault");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		bgWithCancelBtn = (GImage)((GComponent)this).GetChild("bgWithCancelBtn");
		n146 = (GGraph)((GComponent)this).GetChild("n146");
		PersonalRnage = (GLoader)((GComponent)this).GetChild("PersonalRnage");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		AvatarLoader = (UI_HeadPortrait)(object)((GComponent)this).GetChild("AvatarLoader");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		VerifingStatus = (UI_VerifingStatus)(object)((GComponent)this).GetChild("VerifingStatus");
		NamePlateLoader = (GLoader)((GComponent)this).GetChild("NamePlateLoader");
		logoutBtnDefault = (UI_logoutBtn)(object)((GComponent)this).GetChild("logoutBtnDefault");
		DeOrSaBtn = (UI_DecorateAndSave)(object)((GComponent)this).GetChild("DeOrSaBtn");
		logoutBtn = (UI_logoutBtn)(object)((GComponent)this).GetChild("logoutBtn");
		TitleLoader = (GLoader)((GComponent)this).GetChild("TitleLoader");
		NameText = (GRichTextField)((GComponent)this).GetChild("NameText");
		modifyBtn = (UI_modifyBtn)(object)((GComponent)this).GetChild("modifyBtn");
		IdText = (GTextField)((GComponent)this).GetChild("IdText");
		n115 = (GTextField)((GComponent)this).GetChild("n115");
		string id = "ui://b9yxt7u0wgrq33".Replace("ui://", "") + "-" + ((GObject)n115).id;
		((GObject)n115).text = LanguagesManager.GetDesc(id);
		copyBtn = (UI_copyBtn)(object)((GComponent)this).GetChild("copyBtn");
		n147 = (GList)((GComponent)this).GetChild("n147");
		cancelBtn = (UI_cancelAccountBtn)(object)((GComponent)this).GetChild("cancelBtn");
	}
}
