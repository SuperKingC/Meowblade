using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGIslandBuff;

public class UI_com_OccupyStatus : GComponent
{
	public Controller OccupyStatus;

	public GTextField n7;

	public GTextField n8;

	public GTextField n0;

	public GImage n2;

	public GTextField n1;

	public GGroup n3;

	public GImage n4;

	public GTextField n5;

	public GGroup n6;

	public const string URL = "ui://zh7jgfijnewqfv";

	public static string Name = "UI_com_OccupyStatus";

	public static string GetURL()
	{
		return "ui://zh7jgfijnewqfv";
	}

	public static UI_com_OccupyStatus CreateInstance()
	{
		return (UI_com_OccupyStatus)(object)UIPackage.CreateObject("GvGIslandBuff", "com_OccupyStatus");
	}

	public static UI_com_OccupyStatus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OccupyStatus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zh7jgfijnewqfv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OccupyStatus = ((GComponent)this).GetController("OccupyStatus");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://zh7jgfijnewqfv".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id2 = "ui://zh7jgfijnewqfv".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id2);
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id3 = "ui://zh7jgfijnewqfv".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id3);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id4 = "ui://zh7jgfijnewqfv".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id4);
		n3 = (GGroup)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id5 = "ui://zh7jgfijnewqfv".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id5);
		n6 = (GGroup)((GComponent)this).GetChild("n6");
	}
}
