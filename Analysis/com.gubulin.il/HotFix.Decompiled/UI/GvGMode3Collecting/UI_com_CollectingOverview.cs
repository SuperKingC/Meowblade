using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGMode3Collecting;

public class UI_com_CollectingOverview : GComponent
{
	public GImage n8;

	public GImage n0;

	public GList ItemList;

	public GTextField n7;

	public GImage n10;

	public GTextField stockLimitTitle;

	public GTextField stockLimit;

	public GImage n14;

	public GButton ExclamationMarkBtn;

	public GGroup stockLimitGroup;

	public const string URL = "ui://n2y4xuvarxuq8";

	public static string Name = "UI_com_CollectingOverview";

	public static string GetURL()
	{
		return "ui://n2y4xuvarxuq8";
	}

	public static UI_com_CollectingOverview CreateInstance()
	{
		return (UI_com_CollectingOverview)(object)UIPackage.CreateObject("GvGMode3Collecting", "com_CollectingOverview");
	}

	public static UI_com_CollectingOverview CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CollectingOverview).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://n2y4xuvarxuq8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		ItemList = (GList)((GComponent)this).GetChild("ItemList");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://n2y4xuvarxuq8".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		stockLimitTitle = (GTextField)((GComponent)this).GetChild("stockLimitTitle");
		string id2 = "ui://n2y4xuvarxuq8".Replace("ui://", "") + "-" + ((GObject)stockLimitTitle).id;
		((GObject)stockLimitTitle).text = LanguagesManager.GetDesc(id2);
		stockLimit = (GTextField)((GComponent)this).GetChild("stockLimit");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		stockLimitGroup = (GGroup)((GComponent)this).GetChild("stockLimitGroup");
	}
}
