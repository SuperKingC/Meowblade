using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_EnrollStatus : GComponent
{
	public Controller stepIndex;

	public Controller countStatus;

	public GImage n5;

	public GImage n12;

	public GImage n4;

	public GImage n0;

	public GTextField shipCount;

	public UI_btn_HelpBtn helpBtn;

	public GImage n3;

	public GImage n6;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public GGroup anim;

	public Transition t0;

	public const string URL = "ui://hozu168rnt908";

	public static string Name = "UI_com_EnrollStatus";

	public static string GetURL()
	{
		return "ui://hozu168rnt908";
	}

	public static UI_com_EnrollStatus CreateInstance()
	{
		return (UI_com_EnrollStatus)(object)UIPackage.CreateObject("GvGBrawlFight", "com_EnrollStatus");
	}

	public static UI_com_EnrollStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_EnrollStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnt908", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		stepIndex = ((GComponent)this).GetController("stepIndex");
		countStatus = ((GComponent)this).GetController("countStatus");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		shipCount = (GTextField)((GComponent)this).GetChild("shipCount");
		string id = "ui://hozu168rnt908".Replace("ui://", "") + "-" + ((GObject)shipCount).id;
		((GObject)shipCount).text = LanguagesManager.GetDesc(id);
		helpBtn = (UI_btn_HelpBtn)(object)((GComponent)this).GetChild("helpBtn");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		anim = (GGroup)((GComponent)this).GetChild("anim");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
