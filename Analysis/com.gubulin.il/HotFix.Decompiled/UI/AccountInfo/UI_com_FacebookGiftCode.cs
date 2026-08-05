using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_com_FacebookGiftCode : GComponent
{
	public GImage back;

	public GGraph n7;

	public GTextField title;

	public GRichTextField tip1;

	public GGraph inputUsernameBack;

	public GTextInput inputUsername;

	public UI_confirmBtn confirmBtn;

	public GGraph n9;

	public GTextField n8;

	public GGraph n10;

	public GGroup n11;

	public GGraph n16;

	public GTextField n17;

	public GGraph n18;

	public GGroup n19;

	public const string URL = "ui://b9yxt7u0cy496j";

	public static string Name = "UI_com_FacebookGiftCode";

	public static string GetURL()
	{
		return "ui://b9yxt7u0cy496j";
	}

	public static UI_com_FacebookGiftCode CreateInstance()
	{
		return (UI_com_FacebookGiftCode)(object)UIPackage.CreateObject("AccountInfo", "com_FacebookGiftCode");
	}

	public static UI_com_FacebookGiftCode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FacebookGiftCode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0cy496j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9yxt7u0cy496j".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		tip1 = (GRichTextField)((GComponent)this).GetChild("tip1");
		string id2 = "ui://b9yxt7u0cy496j".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id2);
		inputUsernameBack = (GGraph)((GComponent)this).GetChild("inputUsernameBack");
		inputUsername = (GTextInput)((GComponent)this).GetChild("inputUsername");
		string id3 = "ui://b9yxt7u0cy496j".Replace("ui://", "") + "-" + ((GObject)inputUsername).id + "-prompt";
		inputUsername.promptText = LanguagesManager.GetDesc(id3);
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://b9yxt7u0cy496j".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		n10 = (GGraph)((GComponent)this).GetChild("n10");
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		n16 = (GGraph)((GComponent)this).GetChild("n16");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id5 = "ui://b9yxt7u0cy496j".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id5);
		n18 = (GGraph)((GComponent)this).GetChild("n18");
		n19 = (GGroup)((GComponent)this).GetChild("n19");
	}
}
