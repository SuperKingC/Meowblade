using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_FoodStoreBar : GProgressBar
{
	public GImage n16;

	public GImage bar;

	public GTextField FoodNumber;

	public GTextField n9;

	public GButton BuffsTip;

	public const string URL = "ui://pobej4q7uadoc";

	public static string Name = "UI_FoodStoreBar";

	public static string GetURL()
	{
		return "ui://pobej4q7uadoc";
	}

	public static UI_FoodStoreBar CreateInstance()
	{
		return (UI_FoodStoreBar)(object)UIPackage.CreateObject("GvG3SupplyDepot", "FoodStoreBar");
	}

	public static UI_FoodStoreBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FoodStoreBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7uadoc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		bar = (GImage)((GComponent)this).GetChild("bar");
		FoodNumber = (GTextField)((GComponent)this).GetChild("FoodNumber");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://pobej4q7uadoc".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
		BuffsTip = (GButton)((GComponent)this).GetChild("BuffsTip");
	}
}
