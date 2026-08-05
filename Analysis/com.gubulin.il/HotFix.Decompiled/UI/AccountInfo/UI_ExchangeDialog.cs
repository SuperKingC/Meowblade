using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_ExchangeDialog : GComponent
{
	public Controller RedeemType;

	public GImage back;

	public GTextField title;

	public GImage n27;

	public GImage n28;

	public GImage n33;

	public GImage n7;

	public GImage n8;

	public GImage n29;

	public GImage n18;

	public GTextField n14;

	public GTextField n16;

	public GTextField n17;

	public GImage n19;

	public GImage n20;

	public GTextField Code;

	public GTextField YourID;

	public GImage n23;

	public UI_CopyBtn2 copyRedeemCodeBtn;

	public GImage n35;

	public GImage n34;

	public GTextInput RedeemCodeInput;

	public UI_confirmBtn ClaimBtn;

	public GGroup redeem_code_container;

	public GImage n32;

	public const string URL = "ui://b9yxt7u0f4szz";

	public static string Name = "UI_ExchangeDialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0f4szz";
	}

	public static UI_ExchangeDialog CreateInstance()
	{
		return (UI_ExchangeDialog)(object)UIPackage.CreateObject("AccountInfo", "ExchangeDialog");
	}

	public static UI_ExchangeDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExchangeDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0f4szz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RedeemType = ((GComponent)this).GetController("RedeemType");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9yxt7u0f4szz".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id2 = "ui://b9yxt7u0f4szz".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id2);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id3 = "ui://b9yxt7u0f4szz".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id3);
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id4 = "ui://b9yxt7u0f4szz".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id4);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		Code = (GTextField)((GComponent)this).GetChild("Code");
		YourID = (GTextField)((GComponent)this).GetChild("YourID");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		copyRedeemCodeBtn = (UI_CopyBtn2)(object)((GComponent)this).GetChild("copyRedeemCodeBtn");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		RedeemCodeInput = (GTextInput)((GComponent)this).GetChild("RedeemCodeInput");
		string id5 = "ui://b9yxt7u0f4szz".Replace("ui://", "") + "-" + ((GObject)RedeemCodeInput).id + "-prompt";
		RedeemCodeInput.promptText = LanguagesManager.GetDesc(id5);
		ClaimBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("ClaimBtn");
		redeem_code_container = (GGroup)((GComponent)this).GetChild("redeem_code_container");
		n32 = (GImage)((GComponent)this).GetChild("n32");
	}
}
