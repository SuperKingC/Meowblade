using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_com_FlagShipCannonTip : GComponent
{
	public GImage n2;

	public GTextField n1;

	public GTextField n23;

	public GTextField n3;

	public GTextField Level;

	public const string URL = "ui://tvr786zlshbk1l";

	public static string Name = "UI_com_FlagShipCannonTip";

	public static string GetURL()
	{
		return "ui://tvr786zlshbk1l";
	}

	public static UI_com_FlagShipCannonTip CreateInstance()
	{
		return (UI_com_FlagShipCannonTip)(object)UIPackage.CreateObject("GvGFlagship3", "com_FlagShipCannonTip");
	}

	public static UI_com_FlagShipCannonTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagShipCannonTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlshbk1l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://tvr786zlshbk1l".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id2 = "ui://tvr786zlshbk1l".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id2);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id3 = "ui://tvr786zlshbk1l".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id3);
		Level = (GTextField)((GComponent)this).GetChild("Level");
	}
}
