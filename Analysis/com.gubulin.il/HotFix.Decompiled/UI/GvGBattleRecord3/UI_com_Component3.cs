using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_Component3 : GComponent
{
	public GImage n2;

	public GTextField n1;

	public const string URL = "ui://b3fc6085owu59";

	public static string Name = "UI_com_Component3";

	public static string GetURL()
	{
		return "ui://b3fc6085owu59";
	}

	public static UI_com_Component3 CreateInstance()
	{
		return (UI_com_Component3)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_Component3");
	}

	public static UI_com_Component3 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Component3).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085owu59", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://b3fc6085owu59".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
	}
}
