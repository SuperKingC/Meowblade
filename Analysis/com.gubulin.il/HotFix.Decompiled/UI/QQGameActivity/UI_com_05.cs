using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_com_05 : GComponent
{
	public Controller c1;

	public GImage n19;

	public GImage n26;

	public GImage n27;

	public GImage n28;

	public GTextField n24;

	public GTextField n29;

	public UI_btn_Receive n33;

	public GTextField n34;

	public const string URL = "ui://r1j1a2l0szly3s";

	public static string Name = "UI_com_05";

	public static string GetURL()
	{
		return "ui://r1j1a2l0szly3s";
	}

	public static UI_com_05 CreateInstance()
	{
		return (UI_com_05)(object)UIPackage.CreateObject("QQGameActivity", "com_05");
	}

	public static UI_com_05 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_05).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0szly3s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		c1 = ((GComponent)this).GetController("c1");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id = "ui://r1j1a2l0szly3s".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id2 = "ui://r1j1a2l0szly3s".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id2);
		n33 = (UI_btn_Receive)(object)((GComponent)this).GetChild("n33");
		n34 = (GTextField)((GComponent)this).GetChild("n34");
		string id3 = "ui://r1j1a2l0szly3s".Replace("ui://", "") + "-" + ((GObject)n34).id;
		((GObject)n34).text = LanguagesManager.GetDesc(id3);
	}
}
