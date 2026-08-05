using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.BlackMarketer;

public class UI_GiftBag : GButton
{
	public GImage n5;

	public GImage n12;

	public GGraph n6;

	public GLoader payIcon;

	public GTextField payNum;

	public GLoader title;

	public GButton showPicture;

	public GTextField showTitle;

	public const string URL = "ui://036k96hrlkzgv";

	public static string Name = "UI_GiftBag";

	public static string GetURL()
	{
		return "ui://036k96hrlkzgv";
	}

	public static UI_GiftBag CreateInstance()
	{
		return (UI_GiftBag)(object)UIPackage.CreateObject("BlackMarketer", "GiftBag");
	}

	public static UI_GiftBag CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GiftBag).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrlkzgv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		payIcon = (GLoader)((GComponent)this).GetChild("payIcon");
		payNum = (GTextField)((GComponent)this).GetChild("payNum");
		title = (GLoader)((GComponent)this).GetChild("title");
		showPicture = (GButton)((GComponent)this).GetChild("showPicture");
		showTitle = (GTextField)((GComponent)this).GetChild("showTitle");
		string id = "ui://036k96hrlkzgv".Replace("ui://", "") + "-" + ((GObject)showTitle).id;
		((GObject)showTitle).text = LanguagesManager.GetDesc(id);
	}
}
