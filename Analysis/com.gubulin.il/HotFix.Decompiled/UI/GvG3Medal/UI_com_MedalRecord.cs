using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Medal;

public class UI_com_MedalRecord : GComponent
{
	public Controller IsFirst;

	public GTextField Date;

	public GTextField n1;

	public GTextField n2;

	public GTextField IzId;

	public GTextField n4;

	public GTextField MedalLevel;

	public GTextField MedalName;

	public GTextField n7;

	public const string URL = "ui://g5hi1peosxgw13";

	public static string Name = "UI_com_MedalRecord";

	public static string GetURL()
	{
		return "ui://g5hi1peosxgw13";
	}

	public static UI_com_MedalRecord CreateInstance()
	{
		return (UI_com_MedalRecord)(object)UIPackage.CreateObject("GvG3Medal", "com_MedalRecord");
	}

	public static UI_com_MedalRecord CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MedalRecord).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peosxgw13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFirst = ((GComponent)this).GetController("IsFirst");
		Date = (GTextField)((GComponent)this).GetChild("Date");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://g5hi1peosxgw13".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://g5hi1peosxgw13".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		IzId = (GTextField)((GComponent)this).GetChild("IzId");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id3 = "ui://g5hi1peosxgw13".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id3);
		MedalLevel = (GTextField)((GComponent)this).GetChild("MedalLevel");
		MedalName = (GTextField)((GComponent)this).GetChild("MedalName");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id4 = "ui://g5hi1peosxgw13".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id4);
	}
}
