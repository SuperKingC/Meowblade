using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_VisitorsDialog : GComponent
{
	public Controller Status;

	public GImage back;

	public GImage n23;

	public GImage n22;

	public GImage n21;

	public GTextField title;

	public GList VisitorsList;

	public GButton close;

	public UI_SwitchBtn SwitchBtn;

	public GTextField tip2;

	public UI_ReceiveBtn ReceiveBtn;

	public GImage n3;

	public GImage n4;

	public GTextField moenyNum;

	public GTextField n8;

	public GMovieClip ClaimEffect;

	public UI_com_FloatingText FloatingText;

	public Transition PopText;

	public const string URL = "ui://72poq8plkxix12";

	public static string Name = "UI_VisitorsDialog";

	public static string GetURL()
	{
		return "ui://72poq8plkxix12";
	}

	public static UI_VisitorsDialog CreateInstance()
	{
		return (UI_VisitorsDialog)(object)UIPackage.CreateObject("RecyclingCenter", "VisitorsDialog");
	}

	public static UI_VisitorsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_VisitorsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxix12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		back = (GImage)((GComponent)this).GetChild("back");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://72poq8plkxix12".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		VisitorsList = (GList)((GComponent)this).GetChild("VisitorsList");
		close = (GButton)((GComponent)this).GetChild("close");
		SwitchBtn = (UI_SwitchBtn)(object)((GComponent)this).GetChild("SwitchBtn");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id2 = "ui://72poq8plkxix12".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id2);
		ReceiveBtn = (UI_ReceiveBtn)(object)((GComponent)this).GetChild("ReceiveBtn");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		moenyNum = (GTextField)((GComponent)this).GetChild("moenyNum");
		string id3 = "ui://72poq8plkxix12".Replace("ui://", "") + "-" + ((GObject)moenyNum).id;
		((GObject)moenyNum).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://72poq8plkxix12".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		ClaimEffect = (GMovieClip)((GComponent)this).GetChild("ClaimEffect");
		FloatingText = (UI_com_FloatingText)(object)((GComponent)this).GetChild("FloatingText");
		PopText = ((GComponent)this).GetTransition("PopText");
	}
}
