using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_RaceDialog : GComponent
{
	public Controller Status;

	public GImage tipFrame;

	public GGraph n15;

	public GGraph n16;

	public GButton racePicture;

	public GTextField title;

	public GGroup n12;

	public GList soldierList;

	public GGraph line1;

	public GTextField tip;

	public GTextField info;

	public GGraph spacing;

	public const string URL = "ui://47lbpgx9o21u4p";

	public static string Name = "UI_RaceDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://47lbpgx9o21u4p".Replace("ui://", ""), ((GObject)title).id, Status.selectedIndex);
		((GObject)title).text = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://47lbpgx9o21u4p".Replace("ui://", ""), ((GObject)info).id, Status.selectedIndex);
		((GObject)info).text = LanguagesManager.GetDesc(id2);
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9o21u4p";
	}

	public static UI_RaceDialog CreateInstance()
	{
		return (UI_RaceDialog)(object)UIPackage.CreateObject("Tips", "RaceDialog");
	}

	public static UI_RaceDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RaceDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9o21u4p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		tipFrame = (GImage)((GComponent)this).GetChild("tipFrame");
		n15 = (GGraph)((GComponent)this).GetChild("n15");
		n16 = (GGraph)((GComponent)this).GetChild("n16");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9o21u4p".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		soldierList = (GList)((GComponent)this).GetChild("soldierList");
		line1 = (GGraph)((GComponent)this).GetChild("line1");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://47lbpgx9o21u4p".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		info = (GTextField)((GComponent)this).GetChild("info");
		string id3 = "ui://47lbpgx9o21u4p".Replace("ui://", "") + "-" + ((GObject)info).id;
		((GObject)info).text = LanguagesManager.GetDesc(id3);
		spacing = (GGraph)((GComponent)this).GetChild("spacing");
	}
}
