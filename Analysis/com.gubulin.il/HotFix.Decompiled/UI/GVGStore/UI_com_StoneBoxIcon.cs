using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_StoneBoxIcon : GComponent
{
	public Controller Status;

	public Controller isSelect;

	public GImage n5;

	public UI_dec_bg04 n7;

	public GImage selectBg;

	public GLoader Pack;

	public GTextField itemName;

	public GImage n6;

	public GTextField count;

	public GImage redNote;

	public const string URL = "ui://fvc33k3grlgk32";

	public static string Name = "UI_com_StoneBoxIcon";

	public static string GetURL()
	{
		return "ui://fvc33k3grlgk32";
	}

	public static UI_com_StoneBoxIcon CreateInstance()
	{
		return (UI_com_StoneBoxIcon)(object)UIPackage.CreateObject("GVGStore", "com_StoneBoxIcon");
	}

	public static UI_com_StoneBoxIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StoneBoxIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3grlgk32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		isSelect = ((GComponent)this).GetController("isSelect");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (UI_dec_bg04)(object)((GComponent)this).GetChild("n7");
		selectBg = (GImage)((GComponent)this).GetChild("selectBg");
		Pack = (GLoader)((GComponent)this).GetChild("Pack");
		itemName = (GTextField)((GComponent)this).GetChild("itemName");
		string id = "ui://fvc33k3grlgk32".Replace("ui://", "") + "-" + ((GObject)itemName).id;
		((GObject)itemName).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		count = (GTextField)((GComponent)this).GetChild("count");
		string id2 = "ui://fvc33k3grlgk32".Replace("ui://", "") + "-" + ((GObject)count).id;
		((GObject)count).text = LanguagesManager.GetDesc(id2);
		redNote = (GImage)((GComponent)this).GetChild("redNote");
	}
}
