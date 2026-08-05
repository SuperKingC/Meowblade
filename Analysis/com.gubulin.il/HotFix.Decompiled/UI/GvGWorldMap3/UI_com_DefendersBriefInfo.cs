using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_DefendersBriefInfo : GComponent
{
	public Controller Belong;

	public GImage n10;

	public GImage n11;

	public GTextField n0;

	public GTextField n3;

	public GTextField Defenders;

	public GTextField Compliance;

	public GTextField n7;

	public GImage n8;

	public GTextField n9;

	public const string URL = "ui://4eq8fgd2mdde2t";

	public static string Name = "UI_com_DefendersBriefInfo";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2t";
	}

	public static UI_com_DefendersBriefInfo CreateInstance()
	{
		return (UI_com_DefendersBriefInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_DefendersBriefInfo");
	}

	public static UI_com_DefendersBriefInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DefendersBriefInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Belong = ((GComponent)this).GetController("Belong");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://4eq8fgd2mdde2t".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://4eq8fgd2mdde2t".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		Defenders = (GTextField)((GComponent)this).GetChild("Defenders");
		Compliance = (GTextField)((GComponent)this).GetChild("Compliance");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://4eq8fgd2mdde2t".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id4 = "ui://4eq8fgd2mdde2t".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id4);
	}
}
