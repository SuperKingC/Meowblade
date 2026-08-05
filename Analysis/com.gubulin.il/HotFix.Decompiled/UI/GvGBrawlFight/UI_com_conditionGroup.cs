using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_conditionGroup : GComponent
{
	public GImage n30;

	public GTextField n27;

	public GTextField ampScore;

	public GImage n31;

	public GGroup conditionGroup;

	public const string URL = "ui://hozu168rnt5g8u";

	public static string Name = "UI_com_conditionGroup";

	public static string GetURL()
	{
		return "ui://hozu168rnt5g8u";
	}

	public static UI_com_conditionGroup CreateInstance()
	{
		return (UI_com_conditionGroup)(object)UIPackage.CreateObject("GvGBrawlFight", "com_conditionGroup");
	}

	public static UI_com_conditionGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_conditionGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnt5g8u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id = "ui://hozu168rnt5g8u".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id);
		ampScore = (GTextField)((GComponent)this).GetChild("ampScore");
		string id2 = "ui://hozu168rnt5g8u".Replace("ui://", "") + "-" + ((GObject)ampScore).id;
		((GObject)ampScore).text = LanguagesManager.GetDesc(id2);
		n31 = (GImage)((GComponent)this).GetChild("n31");
		conditionGroup = (GGroup)((GComponent)this).GetChild("conditionGroup");
	}
}
