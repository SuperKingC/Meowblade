using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_com_04 : GComponent
{
	public Controller c1;

	public Controller c2;

	public GImage n19;

	public GImage n26;

	public GImage n27;

	public GImage n32;

	public GImage n28;

	public GTextField ExtraText;

	public GTextField n29;

	public GImage n25;

	public GImage n30;

	public GLoader n31;

	public const string URL = "ui://r1j1a2l0szly3r";

	public static string Name = "UI_com_04";

	public static string GetURL()
	{
		return "ui://r1j1a2l0szly3r";
	}

	public static UI_com_04 CreateInstance()
	{
		return (UI_com_04)(object)UIPackage.CreateObject("QQGameActivity", "com_04");
	}

	public static UI_com_04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0szly3r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		c2 = ((GComponent)this).GetController("c2");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		ExtraText = (GTextField)((GComponent)this).GetChild("ExtraText");
		string id = "ui://r1j1a2l0szly3r".Replace("ui://", "") + "-" + ((GObject)ExtraText).id;
		((GObject)ExtraText).text = LanguagesManager.GetDesc(id);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id2 = "ui://r1j1a2l0szly3r".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id2);
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GLoader)((GComponent)this).GetChild("n31");
	}
}
