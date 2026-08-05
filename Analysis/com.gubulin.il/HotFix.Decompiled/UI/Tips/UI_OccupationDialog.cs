using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_OccupationDialog : GComponent
{
	public Controller Status;

	public GImage tipFrame;

	public GImage n4;

	public GImage n18;

	public GButton occupationePicture;

	public GTextField title;

	public GTextField tip;

	public GTextField illustrate;

	public GList soldierList;

	public const string URL = "ui://47lbpgx9mimf5ltd9";

	public static string Name = "UI_OccupationDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9mimf5ltd9";
	}

	public static UI_OccupationDialog CreateInstance()
	{
		return (UI_OccupationDialog)(object)UIPackage.CreateObject("Tips", "OccupationDialog");
	}

	public static UI_OccupationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OccupationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9mimf5ltd9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		tipFrame = (GImage)((GComponent)this).GetChild("tipFrame");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		occupationePicture = (GButton)((GComponent)this).GetChild("occupationePicture");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9mimf5ltd9".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://47lbpgx9mimf5ltd9".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		illustrate = (GTextField)((GComponent)this).GetChild("illustrate");
		soldierList = (GList)((GComponent)this).GetChild("soldierList");
	}

	public void SetControllerPageText()
	{
		int selectedIndex = Status.selectedIndex;
		string id = $"CsharpOccupationTitle_{selectedIndex}";
		((GObject)title).text = LanguagesManager.GetDesc(id);
		string id2 = $"CsharpOccupationDesc_{selectedIndex}";
		((GObject)illustrate).text = LanguagesManager.GetDesc(id2);
	}
}
