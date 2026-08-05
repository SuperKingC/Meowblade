using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_AmplifierScore : GComponent
{
	public Controller EmptyState;

	public Controller c1;

	public GImage n195;

	public GImage n198;

	public GList BonusList;

	public GImage n202;

	public GImage n203;

	public GTextField n204;

	public GButton Help;

	public GTextField n207;

	public GTextField Score;

	public const string URL = "ui://91jxdrkak0j52y";

	public static string Name = "UI_com_AmplifierScore";

	public static string GetURL()
	{
		return "ui://91jxdrkak0j52y";
	}

	public static UI_com_AmplifierScore CreateInstance()
	{
		return (UI_com_AmplifierScore)(object)UIPackage.CreateObject("GvGSettlement", "com_AmplifierScore");
	}

	public static UI_com_AmplifierScore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierScore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkak0j52y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		EmptyState = ((GComponent)this).GetController("EmptyState");
		c1 = ((GComponent)this).GetController("c1");
		n195 = (GImage)((GComponent)this).GetChild("n195");
		n198 = (GImage)((GComponent)this).GetChild("n198");
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		n202 = (GImage)((GComponent)this).GetChild("n202");
		n203 = (GImage)((GComponent)this).GetChild("n203");
		n204 = (GTextField)((GComponent)this).GetChild("n204");
		string id = "ui://91jxdrkak0j52y".Replace("ui://", "") + "-" + ((GObject)n204).id;
		((GObject)n204).text = LanguagesManager.GetDesc(id);
		Help = (GButton)((GComponent)this).GetChild("Help");
		n207 = (GTextField)((GComponent)this).GetChild("n207");
		string id2 = "ui://91jxdrkak0j52y".Replace("ui://", "") + "-" + ((GObject)n207).id;
		((GObject)n207).text = LanguagesManager.GetDesc(id2);
		Score = (GTextField)((GComponent)this).GetChild("Score");
	}
}
