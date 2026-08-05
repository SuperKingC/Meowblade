using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlBuffInfo : GComponent
{
	public GImage Background;

	public GImage n4;

	public GImage n5;

	public GImage n6;

	public GImage n8;

	public GTextField n2;

	public GTextField n3;

	public GTextField n7;

	public GTextField n9;

	public GList listSelf;

	public GList listCamp;

	public GButton ConfirmBtn;

	public const string URL = "ui://hozu168rxig180";

	public static string Name = "UI_com_BrawlBuffInfo";

	public static string GetURL()
	{
		return "ui://hozu168rxig180";
	}

	public static UI_com_BrawlBuffInfo CreateInstance()
	{
		return (UI_com_BrawlBuffInfo)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlBuffInfo");
	}

	public static UI_com_BrawlBuffInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlBuffInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rxig180", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://hozu168rxig180".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://hozu168rxig180".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://hozu168rxig180".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id4 = "ui://hozu168rxig180".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id4);
		listSelf = (GList)((GComponent)this).GetChild("listSelf");
		listCamp = (GList)((GComponent)this).GetChild("listCamp");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
	}
}
