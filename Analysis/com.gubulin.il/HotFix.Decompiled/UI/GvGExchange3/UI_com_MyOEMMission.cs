using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_MyOEMMission : GComponent
{
	public Controller Status;

	public Controller Type;

	public GImage n12;

	public GImage n14;

	public GTextField n15;

	public GImage n16;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public UI_com_AmplifierSlot Amplifier;

	public GTextField n1;

	public GTextField Countdown;

	public GTextField n6;

	public GTextField n7;

	public GTextField n9;

	public GTextField n10;

	public GImage n20;

	public GImage n21;

	public GGroup n13;

	public const string URL = "ui://tt2iq07onhzv12";

	public static string Name = "UI_com_MyOEMMission";

	public static string GetURL()
	{
		return "ui://tt2iq07onhzv12";
	}

	public static UI_com_MyOEMMission CreateInstance()
	{
		return (UI_com_MyOEMMission)(object)UIPackage.CreateObject("GvGExchange3", "com_MyOEMMission");
	}

	public static UI_com_MyOEMMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MyOEMMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzv12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://tt2iq07onhzv12".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		Amplifier = (UI_com_AmplifierSlot)(object)((GComponent)this).GetChild("Amplifier");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id2 = "ui://tt2iq07onhzv12".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id2);
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://tt2iq07onhzv12".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id4 = "ui://tt2iq07onhzv12".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id4);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id5 = "ui://tt2iq07onhzv12".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id5);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id6 = "ui://tt2iq07onhzv12".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id6);
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
	}
}
