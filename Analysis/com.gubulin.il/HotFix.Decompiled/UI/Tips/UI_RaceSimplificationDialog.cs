using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_RaceSimplificationDialog : GComponent
{
	public Controller Status;

	public GImage tipFrame;

	public GButton racePicture;

	public GTextField title;

	public GGroup n12;

	public GTextField info;

	public const string URL = "ui://47lbpgx9ldgh4r";

	public static string Name = "UI_RaceSimplificationDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://47lbpgx9o21u4p".Replace("ui://", ""), ((GObject)title).id, Status.selectedIndex);
		((GObject)title).text = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://47lbpgx9o21u4p".Replace("ui://", ""), ((GObject)info).id, Status.selectedIndex);
		((GObject)info).text = LanguagesManager.GetDesc(id2);
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9ldgh4r";
	}

	public static UI_RaceSimplificationDialog CreateInstance()
	{
		return (UI_RaceSimplificationDialog)(object)UIPackage.CreateObject("Tips", "RaceSimplificationDialog");
	}

	public static UI_RaceSimplificationDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RaceSimplificationDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ldgh4r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		tipFrame = (GImage)((GComponent)this).GetChild("tipFrame");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9ldgh4r".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		info = (GTextField)((GComponent)this).GetChild("info");
		string id2 = "ui://47lbpgx9ldgh4r".Replace("ui://", "") + "-" + ((GObject)info).id;
		((GObject)info).text = LanguagesManager.GetDesc(id2);
	}
}
