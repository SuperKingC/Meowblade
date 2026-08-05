using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_Title : GComponent
{
	public Controller Type;

	public GImage n0;

	public GLoader name;

	public GLoader icon;

	public GTextField title0;

	public GTextField title1;

	public const string URL = "ui://ylvfgf90uku34w";

	public static string Name = "UI_com_Title";

	public static string GetURL()
	{
		return "ui://ylvfgf90uku34w";
	}

	public static UI_com_Title CreateInstance()
	{
		return (UI_com_Title)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_Title");
	}

	public static UI_com_Title CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Title).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90uku34w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		name = (GLoader)((GComponent)this).GetChild("name");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://ylvfgf90uku34w".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
		title1 = (GTextField)((GComponent)this).GetChild("title1");
		string id2 = "ui://ylvfgf90uku34w".Replace("ui://", "") + "-" + ((GObject)title1).id;
		((GObject)title1).text = LanguagesManager.GetDesc(id2);
	}
}
