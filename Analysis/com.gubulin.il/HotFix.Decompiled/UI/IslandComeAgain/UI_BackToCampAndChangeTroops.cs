using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_BackToCampAndChangeTroops : GButton
{
	public Controller button;

	public GTextField n3;

	public GImage n5;

	public const string URL = "ui://k2sprg26t0sv9i";

	public static string Name = "UI_BackToCampAndChangeTroops";

	public static string GetURL()
	{
		return "ui://k2sprg26t0sv9i";
	}

	public static UI_BackToCampAndChangeTroops CreateInstance()
	{
		return (UI_BackToCampAndChangeTroops)(object)UIPackage.CreateObject("IslandComeAgain", "BackToCampAndChangeTroops");
	}

	public static UI_BackToCampAndChangeTroops CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BackToCampAndChangeTroops).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26t0sv9i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://k2sprg26t0sv9i".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
