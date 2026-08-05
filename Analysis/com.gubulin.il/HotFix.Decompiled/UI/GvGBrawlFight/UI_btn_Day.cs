using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_Day : GButton
{
	public Controller button;

	public Controller IsClaimed;

	public Controller IsGenerated;

	public GImage n14;

	public GImage n7;

	public GImage n8;

	public GTextField n0;

	public GTextField Day;

	public GTextField Date;

	public GImage n13;

	public GImage n4;

	public GImage n5;

	public GTextField n6;

	public GGroup n10;

	public GImage n12;

	public GImage redPoint;

	public Transition t0;

	public const string URL = "ui://hozu168rswyq3f";

	public static string Name = "UI_btn_Day";

	public static string GetURL()
	{
		return "ui://hozu168rswyq3f";
	}

	public static UI_btn_Day CreateInstance()
	{
		return (UI_btn_Day)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_Day");
	}

	public static UI_btn_Day CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Day).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rswyq3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		IsGenerated = ((GComponent)this).GetController("IsGenerated");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://hozu168rswyq3f".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		Day = (GTextField)((GComponent)this).GetChild("Day");
		string id2 = "ui://hozu168rswyq3f".Replace("ui://", "") + "-" + ((GObject)Day).id;
		((GObject)Day).text = LanguagesManager.GetDesc(id2);
		Date = (GTextField)((GComponent)this).GetChild("Date");
		string id3 = "ui://hozu168rswyq3f".Replace("ui://", "") + "-" + ((GObject)Date).id;
		((GObject)Date).text = LanguagesManager.GetDesc(id3);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id4 = "ui://hozu168rswyq3f".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id4);
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
