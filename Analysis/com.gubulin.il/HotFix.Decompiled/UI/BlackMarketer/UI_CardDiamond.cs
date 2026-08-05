using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.BlackMarketer;

public class UI_CardDiamond : GButton
{
	public GImage n0;

	public GImage n18;

	public GGraph n3;

	public GImage n14;

	public GLoader title;

	public GButton showPicture;

	public GTextField showTitle;

	public const string URL = "ui://036k96hrklbyz";

	public static string Name = "UI_CardDiamond";

	public static string GetURL()
	{
		return "ui://036k96hrklbyz";
	}

	public static UI_CardDiamond CreateInstance()
	{
		return (UI_CardDiamond)(object)UIPackage.CreateObject("BlackMarketer", "CardDiamond");
	}

	public static UI_CardDiamond CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardDiamond).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrklbyz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		title = (GLoader)((GComponent)this).GetChild("title");
		showPicture = (GButton)((GComponent)this).GetChild("showPicture");
		showTitle = (GTextField)((GComponent)this).GetChild("showTitle");
		string id = "ui://036k96hrklbyz".Replace("ui://", "") + "-" + ((GObject)showTitle).id;
		((GObject)showTitle).text = LanguagesManager.GetDesc(id);
	}
}
