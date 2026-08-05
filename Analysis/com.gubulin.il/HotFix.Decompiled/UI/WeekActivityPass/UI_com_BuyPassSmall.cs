using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_BuyPassSmall : GComponent
{
	public Controller Mode;

	public Controller Activation;

	public GImage n83;

	public GImage n86;

	public GImage n91;

	public GImage n98;

	public GImage n84;

	public GImage n92;

	public GTextField Title;

	public GTextField Title3;

	public GList ClaimableList;

	public UI_btn_BuyBtn BuyBtn;

	public GTextField Title2;

	public GTextField Title4;

	public GImage n87;

	public GImage n88;

	public GImage n89;

	public GImage n90;

	public GImage n93;

	public GTextField n95;

	public GImage n94;

	public GGroup n97;

	public const string URL = "ui://11dkggb8c2sz33";

	public static string Name = "UI_com_BuyPassSmall";

	public static string GetURL()
	{
		return "ui://11dkggb8c2sz33";
	}

	public static UI_com_BuyPassSmall CreateInstance()
	{
		return (UI_com_BuyPassSmall)(object)UIPackage.CreateObject("WeekActivityPass", "com_BuyPassSmall");
	}

	public static UI_com_BuyPassSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuyPassSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8c2sz33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mode = ((GComponent)this).GetController("Mode");
		Activation = ((GComponent)this).GetController("Activation");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n91 = (GImage)((GComponent)this).GetChild("n91");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n92 = (GImage)((GComponent)this).GetChild("n92");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://11dkggb8c2sz33".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Title3 = (GTextField)((GComponent)this).GetChild("Title3");
		string id2 = "ui://11dkggb8c2sz33".Replace("ui://", "") + "-" + ((GObject)Title3).id;
		((GObject)Title3).text = LanguagesManager.GetDesc(id2);
		ClaimableList = (GList)((GComponent)this).GetChild("ClaimableList");
		BuyBtn = (UI_btn_BuyBtn)(object)((GComponent)this).GetChild("BuyBtn");
		Title2 = (GTextField)((GComponent)this).GetChild("Title2");
		string id3 = "ui://11dkggb8c2sz33".Replace("ui://", "") + "-" + ((GObject)Title2).id;
		((GObject)Title2).text = LanguagesManager.GetDesc(id3);
		Title4 = (GTextField)((GComponent)this).GetChild("Title4");
		string id4 = "ui://11dkggb8c2sz33".Replace("ui://", "") + "-" + ((GObject)Title4).id;
		((GObject)Title4).text = LanguagesManager.GetDesc(id4);
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		n95 = (GTextField)((GComponent)this).GetChild("n95");
		string id5 = "ui://11dkggb8c2sz33".Replace("ui://", "") + "-" + ((GObject)n95).id;
		((GObject)n95).text = LanguagesManager.GetDesc(id5);
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n97 = (GGroup)((GComponent)this).GetChild("n97");
	}
}
