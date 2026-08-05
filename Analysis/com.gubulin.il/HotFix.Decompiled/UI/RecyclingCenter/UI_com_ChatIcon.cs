using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_com_ChatIcon : GComponent
{
	public GImage n54;

	public GTextField level;

	public GGroup n81;

	public const string URL = "ui://72poq8plpy0y33";

	public static string Name = "UI_com_ChatIcon";

	public static string GetURL()
	{
		return "ui://72poq8plpy0y33";
	}

	public static UI_com_ChatIcon CreateInstance()
	{
		return (UI_com_ChatIcon)(object)UIPackage.CreateObject("RecyclingCenter", "com_ChatIcon");
	}

	public static UI_com_ChatIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ChatIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plpy0y33", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n54 = (GImage)((GComponent)this).GetChild("n54");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://72poq8plpy0y33".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		n81 = (GGroup)((GComponent)this).GetChild("n81");
	}
}
