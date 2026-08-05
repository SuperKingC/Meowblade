using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_com_info01 : GComponent
{
	public Controller Type;

	public GImage n207;

	public GImage n208;

	public GTextField n209;

	public GList Contributions;

	public GButton Close;

	public GTextField n213;

	public GTextField n214;

	public const string URL = "ui://ylvfgf90cbjb6p";

	public static string Name = "UI_com_info01";

	public static string GetURL()
	{
		return "ui://ylvfgf90cbjb6p";
	}

	public static UI_com_info01 CreateInstance()
	{
		return (UI_com_info01)(object)UIPackage.CreateObject("GvG3Leaderboard", "com_info01");
	}

	public static UI_com_info01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_info01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90cbjb6p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n207 = (GImage)((GComponent)this).GetChild("n207");
		n208 = (GImage)((GComponent)this).GetChild("n208");
		n209 = (GTextField)((GComponent)this).GetChild("n209");
		string id = "ui://ylvfgf90cbjb6p".Replace("ui://", "") + "-" + ((GObject)n209).id;
		((GObject)n209).text = LanguagesManager.GetDesc(id);
		Contributions = (GList)((GComponent)this).GetChild("Contributions");
		Close = (GButton)((GComponent)this).GetChild("Close");
		n213 = (GTextField)((GComponent)this).GetChild("n213");
		string id2 = "ui://ylvfgf90cbjb6p".Replace("ui://", "") + "-" + ((GObject)n213).id;
		((GObject)n213).text = LanguagesManager.GetDesc(id2);
		n214 = (GTextField)((GComponent)this).GetChild("n214");
		string id3 = "ui://ylvfgf90cbjb6p".Replace("ui://", "") + "-" + ((GObject)n214).id;
		((GObject)n214).text = LanguagesManager.GetDesc(id3);
	}
}
