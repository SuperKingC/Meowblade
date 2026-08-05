using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_RecordsFilter2 : GButton
{
	public Controller button;

	public Controller IconController;

	public Controller Type;

	public Controller Camp;

	public GImage n2;

	public GGroup n12;

	public GLoader n5;

	public GLoader n13;

	public GTextField AllDesc;

	public GGroup n9;

	public GTextField n7;

	public GGroup n10;

	public GTextField n6;

	public GGroup n11;

	public const string URL = "ui://b3fc6085iaoi2y";

	public static string Name = "UI_com_RecordsFilter2";

	public static string GetURL()
	{
		return "ui://b3fc6085iaoi2y";
	}

	public static UI_com_RecordsFilter2 CreateInstance()
	{
		return (UI_com_RecordsFilter2)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_RecordsFilter2");
	}

	public static UI_com_RecordsFilter2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RecordsFilter2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085iaoi2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IconController = ((GComponent)this).GetController("IconController");
		Type = ((GComponent)this).GetController("Type");
		Camp = ((GComponent)this).GetController("Camp");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n13 = (GLoader)((GComponent)this).GetChild("n13");
		AllDesc = (GTextField)((GComponent)this).GetChild("AllDesc");
		string id = "ui://b3fc6085iaoi2y".Replace("ui://", "") + "-" + ((GObject)AllDesc).id;
		((GObject)AllDesc).text = LanguagesManager.GetDesc(id);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://b3fc6085iaoi2y".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://b3fc6085iaoi2y".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		n11 = (GGroup)((GComponent)this).GetChild("n11");
	}
}
