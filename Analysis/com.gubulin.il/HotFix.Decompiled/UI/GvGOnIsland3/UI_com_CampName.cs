using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_CampName : GComponent
{
	public Controller Camp;

	public GLoader CampIcon;

	public GTextField n1;

	public GTextField n6;

	public GTextField n7;

	public GTextField n8;

	public const string URL = "ui://ebc4ciwr9t3hq4g";

	public static string Name = "UI_com_CampName";

	public static string GetURL()
	{
		return "ui://ebc4ciwr9t3hq4g";
	}

	public static UI_com_CampName CreateInstance()
	{
		return (UI_com_CampName)(object)UIPackage.CreateObject("GvGOnIsland3", "com_CampName");
	}

	public static UI_com_CampName CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampName).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwr9t3hq4g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		CampIcon = (GLoader)((GComponent)this).GetChild("CampIcon");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://ebc4ciwr9t3hq4g".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://ebc4ciwr9t3hq4g".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://ebc4ciwr9t3hq4g".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://ebc4ciwr9t3hq4g".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
	}
}
