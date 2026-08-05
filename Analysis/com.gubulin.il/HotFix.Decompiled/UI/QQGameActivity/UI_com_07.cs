using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_com_07 : GComponent
{
	public Controller c1;

	public Controller c2;

	public GImage n19;

	public GImage n26;

	public GImage n27;

	public GImage n28;

	public GTextField n24;

	public UI_btn_Receive n33;

	public GTextField n34;

	public GTextField n29;

	public GTextField n36;

	public const string URL = "ui://r1j1a2l0szly3w";

	public static string Name = "UI_com_07";

	public static string GetURL()
	{
		return "ui://r1j1a2l0szly3w";
	}

	public static UI_com_07 CreateInstance()
	{
		return (UI_com_07)(object)UIPackage.CreateObject("QQGameActivity", "com_07");
	}

	public static UI_com_07 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_07).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0szly3w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		c2 = ((GComponent)this).GetController("c2");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id = "ui://r1j1a2l0szly3w".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id);
		n33 = (UI_btn_Receive)(object)((GComponent)this).GetChild("n33");
		n34 = (GTextField)((GComponent)this).GetChild("n34");
		string id2 = "ui://r1j1a2l0szly3w".Replace("ui://", "") + "-" + ((GObject)n34).id;
		((GObject)n34).text = LanguagesManager.GetDesc(id2);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id3 = "ui://r1j1a2l0szly3w".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id3);
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id4 = "ui://r1j1a2l0szly3w".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id4);
	}
}
