using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.BlackMarketer;

public class UI_CardContract : GButton
{
	public GImage n0;

	public GImage n21;

	public GGraph n3;

	public GLoader logo;

	public GLoader title;

	public GButton showPicture;

	public GTextField showTitle;

	public const string URL = "ui://036k96hrklbyx";

	public static string Name = "UI_CardContract";

	public static string GetURL()
	{
		return "ui://036k96hrklbyx";
	}

	public static UI_CardContract CreateInstance()
	{
		return (UI_CardContract)(object)UIPackage.CreateObject("BlackMarketer", "CardContract");
	}

	public static UI_CardContract CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardContract).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrklbyx", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		logo = (GLoader)((GComponent)this).GetChild("logo");
		title = (GLoader)((GComponent)this).GetChild("title");
		showPicture = (GButton)((GComponent)this).GetChild("showPicture");
		showTitle = (GTextField)((GComponent)this).GetChild("showTitle");
		string id = "ui://036k96hrklbyx".Replace("ui://", "") + "-" + ((GObject)showTitle).id;
		((GObject)showTitle).text = LanguagesManager.GetDesc(id);
	}
}
