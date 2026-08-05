using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_PlayersBriefInfo : GComponent
{
	public Controller NoMan;

	public Controller Camp;

	public Controller Occupy;

	public GImage n10;

	public GImage n2;

	public GTextField n3;

	public GTextField PlayersNum;

	public GLoader n5;

	public GTextField n6;

	public GTextField OccupyProgress;

	public GImage n8;

	public GTextField n9;

	public const string URL = "ui://4eq8fgd2mdde2u";

	public static string Name = "UI_com_PlayersBriefInfo";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mdde2u";
	}

	public static UI_com_PlayersBriefInfo CreateInstance()
	{
		return (UI_com_PlayersBriefInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_PlayersBriefInfo");
	}

	public static UI_com_PlayersBriefInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_PlayersBriefInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mdde2u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		NoMan = ((GComponent)this).GetController("NoMan");
		Camp = ((GComponent)this).GetController("Camp");
		Occupy = ((GComponent)this).GetController("Occupy");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://4eq8fgd2mdde2u".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		PlayersNum = (GTextField)((GComponent)this).GetChild("PlayersNum");
		n5 = (GLoader)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://4eq8fgd2mdde2u".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		OccupyProgress = (GTextField)((GComponent)this).GetChild("OccupyProgress");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id3 = "ui://4eq8fgd2mdde2u".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id3);
	}
}
