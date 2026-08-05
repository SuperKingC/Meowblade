using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PointGear1 : GComponent
{
	public Controller StageNum;

	public GImage n69;

	public GList PointList;

	public GImage n52;

	public GImage n53;

	public GImage n54;

	public GImage n60;

	public GImage n56;

	public GImage n57;

	public GImage n58;

	public GImage n59;

	public GTextField n61;

	public GTextField n62;

	public GTextField n63;

	public GTextField n64;

	public GTextField n65;

	public GTextField n66;

	public GTextField n67;

	public GTextField n68;

	public const string URL = "ui://82mo10n51053da0";

	public static string Name = "UI_PointGear1";

	public static string GetURL()
	{
		return "ui://82mo10n51053da0";
	}

	public static UI_PointGear1 CreateInstance()
	{
		return (UI_PointGear1)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PointGear1");
	}

	public static UI_PointGear1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PointGear1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n51053da0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StageNum = ((GComponent)this).GetController("StageNum");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		PointList = (GList)((GComponent)this).GetChild("PointList");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n61 = (GTextField)((GComponent)this).GetChild("n61");
		string id = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n61).id;
		((GObject)n61).text = LanguagesManager.GetDesc(id);
		n62 = (GTextField)((GComponent)this).GetChild("n62");
		string id2 = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n62).id;
		((GObject)n62).text = LanguagesManager.GetDesc(id2);
		n63 = (GTextField)((GComponent)this).GetChild("n63");
		string id3 = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n63).id;
		((GObject)n63).text = LanguagesManager.GetDesc(id3);
		n64 = (GTextField)((GComponent)this).GetChild("n64");
		string id4 = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n64).id;
		((GObject)n64).text = LanguagesManager.GetDesc(id4);
		n65 = (GTextField)((GComponent)this).GetChild("n65");
		string id5 = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n65).id;
		((GObject)n65).text = LanguagesManager.GetDesc(id5);
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id6 = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id6);
		n67 = (GTextField)((GComponent)this).GetChild("n67");
		string id7 = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n67).id;
		((GObject)n67).text = LanguagesManager.GetDesc(id7);
		n68 = (GTextField)((GComponent)this).GetChild("n68");
		string id8 = "ui://82mo10n51053da0".Replace("ui://", "") + "-" + ((GObject)n68).id;
		((GObject)n68).text = LanguagesManager.GetDesc(id8);
	}
}
