using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Medal;

public class UI_com_MedalDialog : GComponent
{
	public GImage n0;

	public UI_com_MedalActivated ActivatedMedal;

	public GTextField MedalName0;

	public GTextField n4;

	public GTextField MedalLevel;

	public GTextField n6;

	public GTextField n7;

	public GTextField Rank;

	public GTextField MedalDesc;

	public GList Records;

	public GImage n13;

	public GImage n14;

	public const string URL = "ui://g5hi1peolq583";

	public static string Name = "UI_com_MedalDialog";

	public static string GetURL()
	{
		return "ui://g5hi1peolq583";
	}

	public static UI_com_MedalDialog CreateInstance()
	{
		return (UI_com_MedalDialog)(object)UIPackage.CreateObject("GvG3Medal", "com_MedalDialog");
	}

	public static UI_com_MedalDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MedalDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peolq583", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		ActivatedMedal = (UI_com_MedalActivated)(object)((GComponent)this).GetChild("ActivatedMedal");
		MedalName0 = (GTextField)((GComponent)this).GetChild("MedalName0");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://g5hi1peolq583".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		MedalLevel = (GTextField)((GComponent)this).GetChild("MedalLevel");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://g5hi1peolq583".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://g5hi1peolq583".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		Rank = (GTextField)((GComponent)this).GetChild("Rank");
		MedalDesc = (GTextField)((GComponent)this).GetChild("MedalDesc");
		Records = (GList)((GComponent)this).GetChild("Records");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
	}
}
