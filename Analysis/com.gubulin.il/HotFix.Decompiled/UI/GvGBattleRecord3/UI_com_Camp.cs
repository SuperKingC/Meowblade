using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_Camp : GComponent
{
	public Controller Camp;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public GLoader n8;

	public const string URL = "ui://b3fc6085vtf82o";

	public static string Name = "UI_com_Camp";

	public static string GetURL()
	{
		return "ui://b3fc6085vtf82o";
	}

	public static UI_com_Camp CreateInstance()
	{
		return (UI_com_Camp)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_Camp");
	}

	public static UI_com_Camp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Camp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085vtf82o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://b3fc6085vtf82o".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://b3fc6085vtf82o".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://b3fc6085vtf82o".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id4 = "ui://b3fc6085vtf82o".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id4);
		n8 = (GLoader)((GComponent)this).GetChild("n8");
	}
}
