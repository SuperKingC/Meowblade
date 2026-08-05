using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Propetry4 : GComponent
{
	public Controller Type;

	public Controller State;

	public GImage line;

	public GImage n6;

	public GImage n8;

	public GImage n7;

	public GImage n9;

	public GImage n10;

	public GTextField n11;

	public GImage n15;

	public GRichTextField content;

	public GTextField n12;

	public GGroup n14;

	public GImage arrowIcon;

	public const string URL = "ui://h09dvkcglxbt43";

	public static string Name = "UI_com_Propetry4";

	public static string GetURL()
	{
		return "ui://h09dvkcglxbt43";
	}

	public static UI_com_Propetry4 CreateInstance()
	{
		return (UI_com_Propetry4)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Propetry4");
	}

	public static UI_com_Propetry4 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Propetry4).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcglxbt43", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		line = (GImage)((GComponent)this).GetChild("line");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://h09dvkcglxbt43".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		content = (GRichTextField)((GComponent)this).GetChild("content");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id2 = "ui://h09dvkcglxbt43".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id2);
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		arrowIcon = (GImage)((GComponent)this).GetChild("arrowIcon");
	}
}
