using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_Component3 : GComponent
{
	public GImage n0;

	public GTextField n1;

	public const string URL = "ui://k2sprg26uctj8r";

	public static string Name = "UI_Component3";

	public static string GetURL()
	{
		return "ui://k2sprg26uctj8r";
	}

	public static UI_Component3 CreateInstance()
	{
		return (UI_Component3)(object)UIPackage.CreateObject("IslandComeAgain", "Component3");
	}

	public static UI_Component3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Component3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj8r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://k2sprg26uctj8r".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
	}
}
