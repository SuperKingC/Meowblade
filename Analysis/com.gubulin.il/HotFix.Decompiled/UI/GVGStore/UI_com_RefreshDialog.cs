using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_RefreshDialog : GComponent
{
	public Controller RefreshIsFree;

	public GImage back;

	public GTextField title;

	public GTextField tip;

	public GButton exitBtn;

	public UI_btn_RefreshConfirm RefreshCardBtn;

	public UI_com_RefreshContent DialogMiddleContent;

	public GTextField n28;

	public GTextField FreeTicketNumber;

	public GGroup n31;

	public const string URL = "ui://fvc33k3gv6i7x";

	public static string Name = "UI_com_RefreshDialog";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7x";
	}

	public static UI_com_RefreshDialog CreateInstance()
	{
		return (UI_com_RefreshDialog)(object)UIPackage.CreateObject("GVGStore", "com_RefreshDialog");
	}

	public static UI_com_RefreshDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RefreshDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RefreshIsFree = ((GComponent)this).GetController("RefreshIsFree");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://fvc33k3gv6i7x".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://fvc33k3gv6i7x".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		RefreshCardBtn = (UI_btn_RefreshConfirm)(object)((GComponent)this).GetChild("RefreshCardBtn");
		DialogMiddleContent = (UI_com_RefreshContent)(object)((GComponent)this).GetChild("DialogMiddleContent");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id3 = "ui://fvc33k3gv6i7x".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id3);
		FreeTicketNumber = (GTextField)((GComponent)this).GetChild("FreeTicketNumber");
		n31 = (GGroup)((GComponent)this).GetChild("n31");
	}
}
