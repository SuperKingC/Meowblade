using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_RegionContent : GComponent
{
	public Controller Type;

	public GTextField battleTotal;

	public GImage n53;

	public GGroup n60;

	public GImage n56;

	public GImage n57;

	public GImage n59;

	public GGroup n61;

	public GTextField textSeason;

	public GGraph n66;

	public GImage n63;

	public GImage n64;

	public GImage n65;

	public const string URL = "ui://82mo10n5fl7udc9";

	public static string Name = "UI_RegionContent";

	public static string GetURL()
	{
		return "ui://82mo10n5fl7udc9";
	}

	public static UI_RegionContent CreateInstance()
	{
		return (UI_RegionContent)(object)UIPackage.CreateObject("PvpSelectSoldiers", "RegionContent");
	}

	public static UI_RegionContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RegionContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5fl7udc9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		battleTotal = (GTextField)((GComponent)this).GetChild("battleTotal");
		string id = "ui://82mo10n5fl7udc9".Replace("ui://", "") + "-" + ((GObject)battleTotal).id;
		((GObject)battleTotal).text = LanguagesManager.GetDesc(id);
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n60 = (GGroup)((GComponent)this).GetChild("n60");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n61 = (GGroup)((GComponent)this).GetChild("n61");
		textSeason = (GTextField)((GComponent)this).GetChild("textSeason");
		string id2 = "ui://82mo10n5fl7udc9".Replace("ui://", "") + "-" + ((GObject)textSeason).id;
		((GObject)textSeason).text = LanguagesManager.GetDesc(id2);
		n66 = (GGraph)((GComponent)this).GetChild("n66");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GImage)((GComponent)this).GetChild("n65");
	}
}
