using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_btn_OfflineBonusTab : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n5;

	public GImage n6;

	public GTextField n3;

	public GTextField n4;

	public GGroup n9;

	public GTextField n10;

	public GTextField n8;

	public GGroup n11;

	public const string URL = "ui://47lbpgx9hmzntb6";

	public static string Name = "UI_btn_OfflineBonusTab";

	public static string GetURL()
	{
		return "ui://47lbpgx9hmzntb6";
	}

	public static UI_btn_OfflineBonusTab CreateInstance()
	{
		return (UI_btn_OfflineBonusTab)(object)UIPackage.CreateObject("Tips", "btn_OfflineBonusTab");
	}

	public static UI_btn_OfflineBonusTab CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OfflineBonusTab).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9hmzntb6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://47lbpgx9hmzntb6".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://47lbpgx9hmzntb6".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id3 = "ui://47lbpgx9hmzntb6".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://47lbpgx9hmzntb6".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		n11 = (GGroup)((GComponent)this).GetChild("n11");
	}
}
