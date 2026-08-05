using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_VisitorItem : GComponent
{
	public Controller Status;

	public GGraph n9;

	public UI_InvitationIcon_foo IconBtn;

	public GImage n2;

	public GTextField level;

	public GTextField name;

	public GTextField n5;

	public GTextField CurEarnings;

	public UI_YesBtn VisitBtn;

	public GList n10;

	public const string URL = "ui://72poq8plkxixt";

	public static string Name = "UI_VisitorItem";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://72poq8plkxixt".Replace("ui://", ""), ((GObject)n5).id, Status.selectedIndex);
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://72poq8plkxixt";
	}

	public static UI_VisitorItem CreateInstance()
	{
		return (UI_VisitorItem)(object)UIPackage.CreateObject("RecyclingCenter", "VisitorItem");
	}

	public static UI_VisitorItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VisitorItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxixt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		IconBtn = (UI_InvitationIcon_foo)(object)((GComponent)this).GetChild("IconBtn");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		level = (GTextField)((GComponent)this).GetChild("level");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://72poq8plkxixt".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://72poq8plkxixt".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		CurEarnings = (GTextField)((GComponent)this).GetChild("CurEarnings");
		VisitBtn = (UI_YesBtn)(object)((GComponent)this).GetChild("VisitBtn");
		n10 = (GList)((GComponent)this).GetChild("n10");
	}
}
