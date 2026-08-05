using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_Outsourcing : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField n6;

	public GImage n7;

	public const string URL = "ui://tt2iq07odwxt3";

	public static string Name = "UI_btn_Outsourcing";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxt3";
	}

	public static UI_btn_Outsourcing CreateInstance()
	{
		return (UI_btn_Outsourcing)(object)UIPackage.CreateObject("GvGExchange3", "btn_Outsourcing");
	}

	public static UI_btn_Outsourcing CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Outsourcing).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxt3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://tt2iq07odwxt3".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
