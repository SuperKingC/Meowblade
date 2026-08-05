using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_TxtChange : GComponent
{
	public Controller Status;

	public GTextField n14;

	public GTextField n15;

	public const string URL = "ui://tt2iq07oen955s";

	public static string Name = "UI_com_TxtChange";

	public static string GetURL()
	{
		return "ui://tt2iq07oen955s";
	}

	public static UI_com_TxtChange CreateInstance()
	{
		return (UI_com_TxtChange)(object)UIPackage.CreateObject("GvGExchange3", "com_TxtChange");
	}

	public static UI_com_TxtChange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TxtChange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oen955s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://tt2iq07oen955s".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id2 = "ui://tt2iq07oen955s".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id2);
	}
}
